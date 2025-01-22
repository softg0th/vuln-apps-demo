<?php

if (php_sapi_name() === 'cli-server') {
    $file = __DIR__ . $_SERVER['REQUEST_URI'];
    if (file_exists($file) && !is_dir($file)) {
        return false;
    }
}

include __DIR__ . '/core/index.php';
