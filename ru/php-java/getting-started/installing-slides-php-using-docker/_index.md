---
title: Установить Aspose.Slides для PHP через Java с использованием Docker
type: docs
weight: 75
url: /ru/php-java/installing-slides-php-using-docker/
keywords:
- скачать Aspose.Slides
- установить Aspose.Slides
- установка Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- кроссплатформенная совместимость
- изоляция зависимостей
- упрощённое развертывание
- настройка проекта
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Запустите Aspose.Slides в контейнерах Docker: настройте образы, зависимости, шрифты и лицензирование для создания масштабируемых сервисов, обрабатывающих PowerPoint и OpenDocument."
---

## **Требования**
* Установите Docker на свой компьютер. Вы можете следовать официальному руководству по установке [здесь](https://docs.docker.com/get-docker/).

## **Шаги**

### **1. Создайте Dockerfile** 
   Создайте новый файл с именем Dockerfile в каталоге вашего проекта со следующим содержимым:
   ```
   # Базовый образ (официальный образ Ubuntu)
   FROM ubuntu:20.04
   
   # Установить часовой пояс заранее, чтобы избежать интерактивного выбора
   ENV DEBIAN_FRONTEND=noninteractive
   RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
       apt-get update && apt-get install -y tzdata && \
       dpkg-reconfigure --frontend noninteractive tzdata
   
   # Установить необходимые пакеты и обновить списки пакетов
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
   
   # Автоматически принимать лицензионное соглашение при установке шрифтов Microsoft TrueType
   RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
   
   # Установить шрифты Microsoft TrueType
   RUN apt-get update && \
       apt-get install -y ttf-mscorefonts-installer && \
       rm -rf /var/lib/apt/lists/*
   
   # Установить Tomcat - используем версию 9.0.93
   RUN wget https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.93/bin/apache-tomcat-9.0.93.tar.gz -O /tmp/tomcat.tar.gz && \
       tar xzf /tmp/tomcat.tar.gz -C /opt/ && \
       mv /opt/apache-tomcat-9.0.93 /opt/tomcat && \
       rm /tmp/tomcat.tar.gz
   
   # Установить PHP/Java Bridge
   RUN curl -L http://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download -o /tmp/php-java-bridge.zip && \
       unzip /tmp/php-java-bridge.zip -d /tmp/php-java-bridge && \
       mkdir -p /opt/tomcat/webapps/JavaBridge && \
       cp /tmp/php-java-bridge/JavaBridge.war /opt/tomcat/webapps/JavaBridge && \
       cd /opt/tomcat/webapps/JavaBridge && \
       jar -xvf JavaBridge.war && \
       rm -rf /tmp/php-java-bridge.zip /tmp/php-java-bridge
   
   # Скачать и установить Aspose.Slides для PHP через Java
   RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
       unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
       mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       mkdir -p /tmp/sample && \
       cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
       rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides
   
   # Создать файл test.php
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
   
   # Создать скрипт entrypoint.sh
   RUN echo '#!/bin/bash\n\
   # Запустить Tomcat в фоновом режиме\n\
   catalina.sh start\n\
   # Ожидать полного запуска Tomcat\n\
   until curl -s http://localhost:8080 > /dev/null; do\n\
    sleep 2\n\
   done\n\
   echo "Running the PHP script..."\n\
   # Запустить PHP-скрипт\n\
   php /tmp/sample/test.php\n\
   echo "PHP script completed, please check file /tmp/output.pdf."\n\
   # Держать контейнер запущенным\n\
   echo "Keeping the container alive..."\n\
   tail -f /dev/null\n\
   ' > /tmp/entrypoint.sh
   
   # Явно предоставить скрипту права на исполнение
   RUN chmod 755 /tmp/entrypoint.sh
   
   # Настроить php.ini
   RUN echo "allow_url_include = On" >> /etc/php/7.4/cli/php.ini
   
   # Установить переменные окружения для Tomcat
   ENV CATALINA_HOME /opt/tomcat
   ENV PATH $CATALINA_HOME/bin:$PATH
   ENV PHP_CLASSPATH /opt/aspose-slides/lib
   
   # Открыть порт 8080 для Tomcat и порт 9000 для PHP/Java Bridge
   EXPOSE 8080
   EXPOSE 9000
   
   # Установить рабочий каталог
   WORKDIR /tmp
   
   # Запустить Tomcat при старте контейнера
   ENTRYPOINT ["/tmp/entrypoint.sh"]
   ```


### **2. Соберите Docker-образ**
   Запустите следующую команду в каталоге, где находится ваш Dockerfile, чтобы собрать Docker-образ:
   ```bash
   docker build -t aspose-slides-php-java .
   ```


### **3. Запустите Docker-контейнер**
   После сборки образа запустите контейнер:
```bash
docker run -p 8080:8080 aspose-slides-php-java
```


### 4. **Доступ к Aspose.Slides в Docker** 
   После запуска контейнера скрипт сгенерирует PDF-файл. Вы можете найти сгенерированный файл `output.pdf` в папке `/tmp` внутри контейнера:
   ```bash
   docker exec -it <container-id> ls /tmp
   ```

   Чтобы скопировать сгенерированный PDF-файл на ваш локальный компьютер, выполните следующую команду:
```bash
docker cp <container-id>:/tmp/output.pdf ./output.pdf
```
