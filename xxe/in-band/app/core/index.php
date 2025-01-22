<?php

header('Content-Type: application/xml; charset=utf-8');

$method = $_SERVER['REQUEST_METHOD'];
$uri = explode('/', trim($_SERVER['REQUEST_URI'], '/'));
$endpoint = $uri[0] ?? '';

libxml_disable_entity_loader(false);
libxml_use_internal_errors(true);

switch ($endpoint) {
    case 'calculate':
        if ($method === 'POST') {
            $rawInput = file_get_contents('php://input');

            if (!$rawInput) {
                http_response_code(400);
                echo "<error>Empty request</error>";
                exit;
            }

            try {
                $requestXml = simplexml_load_string(
                    $rawInput,
                    'SimpleXMLElement',
                    LIBXML_NOENT
                );

                if (!$requestXml) {
                    http_response_code(400);
                    echo "<error>Invalid XML format</error>";
                    exit;
                }
            } catch (Exception $e) {
                http_response_code(400);
                echo "<error>Invalid XML format</error>";
                exit;
            }

            $output = [];
            foreach ($requestXml->children() as $child) {
                $output[] = (string)$child;
            }

            $response = new SimpleXMLElement('<?xml version="1.0" encoding="UTF-8"?><response></response>');

            $sum = 0;
            foreach ($requestXml->children() as $child) {
                if (is_numeric((string)$child)) {
                    $sum += (int)$child;
                } else {
                    http_response_code(400);
                    $userRequestItems = [];
                    foreach ($output as $item) {
                        $userRequestItems[] = (string)$item;
                    }
                    $serializedValues = serialize($userRequestItems);
                    $response->addChild('error', "Invalid value: " . htmlspecialchars($serializedValues) . " has non-numerical values");
                    echo $response->asXML();
                    exit;
                }
            }
            $response->addChild('sum', $sum);
            echo $response->asXML();
            exit;
        } else {
            http_response_code(405);
            echo "<error>Method not allowed</error>";
            exit;
        }

    default:
        http_response_code(404);
        echo "<error>Endpoint not found</error>";
        exit;
}
