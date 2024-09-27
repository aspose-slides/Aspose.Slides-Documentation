---
title: Установка
type: docs
weight: 70
url: /ru/php-java/installation/
keySlides: "Скачайте Aspose.Slides, Установите Aspose.Slides, Установка Aspose.Slides, Windows, macOS, Linux, PHP"
description: "Установите Aspose.Slides для PHP через Java в Windows, Linux или macOS"
---

## **Настройка окружения**

1. Установите PHP 7, добавьте путь к PHP в системную переменную `PATH` и установите `allow_url_include` в `On` в файле `php.ini`.
1. Установите JRE 8. Установите переменную окружения `JAVA_HOME` на путь установленного JRE.
1. Установите Apache Tomcat 8.0.

## **Скачайте Aspose.Slides для PHP через Java**

`packagist` — это самый простой способ скачать [Aspose.Slides для PHP через Java](https://packagist.org/packages/aspose/slides).

Чтобы установить Aspose.Slides с использованием Packagist, выполните эту команду:
   ```bash
   composer require aspose/slides
   ```

## **Настройка Apache Tomcat**

1. Скачайте PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) с http://php-java-bridge.sourceforge.net/pjb/download.php и извлеките файл `JavaBridge.war` в папку `webapps` tomcat.
1. Запустите службу Apache Tomcat.
1. Скачайте [“Aspose.Slides для PHP через Java”](https://downloads.aspose.com/slides/php-java) и извлеките его в папку `aspose.slides`. Скопируйте файл `jar/aspose-slides-x.x-php.jar` в папку `webapps\JavaBridge\WEB-INF\lib`. Если вы используете **PHP 8**, замените оригинальный `Java.inc` из PHP-Java Bridge на `Java.inc` из `Java.inc.php8.zip`.
1. Перезапустите службу Apache Tomcat.
1. Запустите `example.php` в папке `aspose.slides`, чтобы выполнить пример с этой командой:
   ```bash
   php example.php
   ```

## Настройка Docker ##

Предварительные требования:
* Установите Docker на своем компьютере. Вы можете следовать официальному руководству по установке [здесь](https://docs.docker.com/get-docker/).

Шаги:
1. **Создайте Dockerfile**. Создайте новый файл с именем Dockerfile в вашем каталоге проекта со следующим содержимым:
   ```
   # Базовый образ (официальный образ Ubuntu)
   FROM ubuntu:20.04
   
   # Установите часовой пояс заранее, чтобы избежать интерактивного выбора
   ENV DEBIAN_FRONTEND=noninteractive
   RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
       apt-get update && apt-get install -y tzdata && \
       dpkg-reconfigure --frontend noninteractive tzdata
   
   # Установите необходимые пакеты и обновите списки пакетов
   RUN apt-get install -y \
       wget \
       curl \
       apt-transport-https \
       ca-certificates \
       software-properties-common \
       php-cli \
       php-cgi \
       libapache2-mod-php \
       unzip \
       openjdk-8-jdk \
       debconf \
       && rm -rf /var/lib/apt/lists/*
   
   # Автоматически принимайте лицензионное соглашение для установки шрифтов Microsoft TrueType
   RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
   
   # Установите шрифты Microsoft TrueType
   RUN apt-get update && \
       apt-get install -y ttf-mscorefonts-installer && \
       rm -rf /var/lib/apt/lists/*
   
   # Установите Tomcat - используем версию 9.0.93
   RUN wget https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.93/bin/apache-tomcat-9.0.93.tar.gz -O /tmp/tomcat.tar.gz && \
       tar xzf /tmp/tomcat.tar.gz -C /opt/ && \
       mv /opt/apache-tomcat-9.0.93 /opt/tomcat && \
       rm /tmp/tomcat.tar.gz
   
   # Установите PHP/Java Bridge
   RUN curl -L http://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download -o /tmp/php-java-bridge.zip && \
       unzip /tmp/php-java-bridge.zip -d /tmp/php-java-bridge && \
       mkdir -p /opt/tomcat/webapps/JavaBridge && \
       cp /tmp/php-java-bridge/JavaBridge.war /opt/tomcat/webapps/JavaBridge && \
       cd /opt/tomcat/webapps/JavaBridge && \
       jar -xvf JavaBridge.war && \
       rm -rf /tmp/php-java-bridge.zip /tmp/php-java-bridge
   
   # Скачайте и установите Aspose.Slides для PHP через Java
   RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
       unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
       mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       mkdir -p /tmp/sample && \
       cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
       rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides
   
   # Создайте файл test.php
   RUN echo '<?php\n\
   require_once("http://localhost:8080/JavaBridge/java/Java.inc");\n\
   require_once("lib/aspose.slides.php");\n\n\
   use aspose\\slides\\Presentation;\n\
   use aspose\\slides\\ShapeType;\n\
   use aspose\\slides\\SaveFormat;\n\
   use aspose\\slides\\License;\n\n\
   $license = new License();\n\n\
   $presentation = new Presentation();\n\
   $slide = $presentation->getSlides()->get_Item(0);\n\
   $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);\n\
   $presentation->save("output.pdf", SaveFormat::Pdf);\n\n\
   ?>' > /tmp/sample/test.php
   
   # Создайте скрипт entrypoint.sh
   RUN echo '#!/bin/bash\n\
   # Запустите Tomcat в фоновом режиме\n\
   catalina.sh start\n\
   # Подождите, пока Tomcat полностью запустится\n\
   until curl -s http://localhost:8080 > /dev/null; do\n\
    sleep 2\n\
   done\n\
   echo "Запуск PHP-скрипта..."\n\
   # Запустите PHP-скрипт\n\
   php /tmp/sample/test.php\n\
   echo "PHP-скрипт завершен, пожалуйста, проверьте файл /tmp/output.pdf."\n\
   # Поддерживайте контейнер в активном состоянии\n\
   echo "Сохраняем контейнер в активном состоянии..."\n\
   tail -f /dev/null\n\
   ' > /tmp/entrypoint.sh
   
   # Явно предоставьте разрешения на выполнение скрипта
   RUN chmod 755 /tmp/entrypoint.sh
   
   # Настройте php.ini
   RUN echo "allow_url_include = On" >> /etc/php/7.4/cli/php.ini
   
   # Установите переменные окружения для Tomcat
   ENV CATALINA_HOME /opt/tomcat
   ENV PATH $CATALINA_HOME/bin:$PATH
   ENV PHP_CLASSPATH /opt/aspose-slides/lib
   
   # Откройте порт 8080 для Tomcat и порт 9000 для PHP/Java Bridge
   EXPOSE 8080
   EXPOSE 9000
   
   # Установите рабочий каталог
   WORKDIR /tmp
   
   # Запустите Tomcat, когда контейнер запускается
   ENTRYPOINT ["/tmp/entrypoint.sh"]
   ```

2. **Соберите образ Docker**. Выполните следующую команду в каталоге, где находится ваш Dockerfile, чтобы собрать образ Docker:
   ```bash
   docker build -t aspose-slides-php-java .
   ```

3. **Запустите контейнер Docker**. После сборки образа запустите контейнер:
   ```bash
   docker run -p 8080:8080 aspose-slides-php-java
   ```

4. **Получите доступ к Aspose.Slides в Docker**. После запуска контейнера скрипт создаст PDF-файл. Вы можете найти сгенерированный выходной файл `output.pdf` в папке `/tmp` внутри контейнера:
   ```bash
   docker exec -it <container-id> ls /tmp
   ```
   Чтобы скопировать сгенерированный PDF-файл на ваш локальный компьютер, выполните следующую команду:
   ```bash
   docker cp <container-id>:/tmp/output.pdf ./output.pdf
   ```