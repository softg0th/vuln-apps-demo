    FROM php:7.2-apache

    RUN a2enmod rewrite

    COPY ./app /var/www/html

    COPY ./000-default.conf /etc/apache2/sites-available/000-default.conf

    RUN chown -R www-data:www-data /var/www/html \
        && chmod -R 755 /var/www/html
