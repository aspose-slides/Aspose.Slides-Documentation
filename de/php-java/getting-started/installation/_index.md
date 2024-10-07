---
title: Installation
type: docs
weight: 70
url: /php-java/installation/
keySlides: "Laden Sie Aspose.Slides herunter, Installieren Sie Aspose.Slides, Aspose.Slides Installation, Windows, macOS, Linux, PHP"
description: "Installieren Sie Aspose.Slides für PHP über Java in Windows, Linux oder macOS"
---

## **Umgebung konfigurieren**

1. Installieren Sie PHP 7, fügen Sie den PHP-Pfad zur Systemvariable `PATH` hinzu und setzen Sie `allow_url_include` auf `On` in der `php.ini`-Datei.
1. Installieren Sie JRE 8. Setzen Sie die Umgebungsvariable `JAVA_HOME` auf den Pfad der installierten JRE.
1. Installieren Sie Apache Tomcat 8.0.

## **Laden Sie Aspose.Slides für PHP über Java herunter**

`packagist` ist der einfachste Weg, um [Aspose.Slides für PHP über Java](https://packagist.org/packages/aspose/slides) herunterzuladen.

Um Aspose.Slides mit Packagist zu installieren, führen Sie diesen Befehl aus:
   ```bash
   composer require aspose/slides
   ```

## **Apache Tomcat konfigurieren**

1. Laden Sie den PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) von http://php-java-bridge.sourceforge.net/pjb/download.php herunter und extrahieren Sie die `JavaBridge.war`-Datei in den Tomcat-Ordner `webapps`.
1. Starten Sie den Apache Tomcat-Dienst.
1. Laden Sie [„Aspose.Slides für PHP über Java“](https://downloads.aspose.com/slides/php-java) herunter und entpacken Sie es in den Ordner `aspose.slides`. Kopieren Sie die Datei `jar/aspose-slides-x.x-php.jar` in den Ordner `webapps\JavaBridge\WEB-INF\lib`. Wenn Sie **PHP 8** verwenden, ersetzen Sie die originale `Java.inc` von PHP-Java Bridge durch die `Java.inc` aus `Java.inc.php8.zip`.
1. Starten Sie den Apache Tomcat-Dienst neu.
1. Führen Sie `example.php` im Ordner `aspose.slides` aus, um das Beispiel mit diesem Befehl auszuführen:
   ```bash
   php example.php
   ```

## Docker-Setup ##

Voraussetzungen:
* Installieren Sie Docker auf Ihrem Rechner. Sie können der offiziellen Installationsanleitung [hier](https://docs.docker.com/get-docker/) folgen.

Schritte:
1. **Erstellen Sie eine Dockerfile**. Erstellen Sie eine neue Datei mit dem Namen Dockerfile in Ihrem Projektverzeichnis mit folgendem Inhalt:
   ```
   # Basisbild (offizielles Ubuntu-Bild)
   FROM ubuntu:20.04
   
   # Setzen Sie die Zeitzone im Voraus, um die interaktive Auswahl zu vermeiden
   ENV DEBIAN_FRONTEND=noninteractive
   RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
       apt-get update && apt-get install -y tzdata && \
       dpkg-reconfigure --frontend noninteractive tzdata
   
   # Installieren Sie erforderliche Pakete und aktualisieren Sie die Paketlisten
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
   
   # Automatisch die Lizenzvereinbarung für die Installation von Microsoft TrueType-Schriften akzeptieren
   RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
   
   # Microsoft TrueType-Schriften installieren
   RUN apt-get update && \
       apt-get install -y ttf-mscorefonts-installer && \
       rm -rf /var/lib/apt/lists/*
   
   # Tomcat installieren - Verwendung von Version 9.0.93
   RUN wget https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.93/bin/apache-tomcat-9.0.93.tar.gz -O /tmp/tomcat.tar.gz && \
       tar xzf /tmp/tomcat.tar.gz -C /opt/ && \
       mv /opt/apache-tomcat-9.0.93 /opt/tomcat && \
       rm /tmp/tomcat.tar.gz
   
   # PHP/Java Bridge installieren
   RUN curl -L http://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download -o /tmp/php-java-bridge.zip && \
       unzip /tmp/php-java-bridge.zip -d /tmp/php-java-bridge && \
       mkdir -p /opt/tomcat/webapps/JavaBridge && \
       cp /tmp/php-java-bridge/JavaBridge.war /opt/tomcat/webapps/JavaBridge && \
       cd /opt/tomcat/webapps/JavaBridge && \
       jar -xvf JavaBridge.war && \
       rm -rf /tmp/php-java-bridge.zip /tmp/php-java-bridge
   
   # Aspose.Slides für PHP über Java herunterladen und installieren
   RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
       unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
       mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       mkdir -p /tmp/sample && \
       cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
       rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides
   
   # Erstellen Sie die test.php-Datei
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
   
   # Erstellen Sie das entrypoint.sh-Skript
   RUN echo '#!/bin/bash\n\
   # Starten Sie Tomcat im Hintergrund\n\
   catalina.sh start\n\
   # Warten Sie, bis Tomcat vollständig gestartet ist\n\
   until curl -s http://localhost:8080 > /dev/null; do\n\
    sleep 2\n\
   done\n\
   echo "PHP-Skript wird ausgeführt..."\n\
   # Führen Sie das PHP-Skript aus\n\
   php /tmp/sample/test.php\n\
   echo "PHP-Skript abgeschlossen, bitte überprüfen Sie die Datei /tmp/output.pdf."\n\
   # Halten Sie den Container am Leben\n\
   echo "Container am Leben halten..."\n\
   tail -f /dev/null\n\
   ' > /tmp/entrypoint.sh
   
   # Gewähren Sie ausdrücklich Ausführungsberechtigungen für das Skript
   RUN chmod 755 /tmp/entrypoint.sh
   
   # Konfigurieren Sie php.ini
   RUN echo "allow_url_include = On" >> /etc/php/7.4/cli/php.ini
   
   # Umgebungsvariablen für Tomcat setzen
   ENV CATALINA_HOME /opt/tomcat
   ENV PATH $CATALINA_HOME/bin:$PATH
   ENV PHP_CLASSPATH /opt/aspose-slides/lib
   
   # Port 8080 für Tomcat und Port 9000 für PHP/Java Bridge freigeben
   EXPOSE 8080
   EXPOSE 9000
   
   # Arbeitsverzeichnis festlegen
   WORKDIR /tmp
   
   # Tomcat starten, wenn der Container gestartet wird
   ENTRYPOINT ["/tmp/entrypoint.sh"]
   ```

2. **Docker-Image erstellen**. Führen Sie den folgenden Befehl im Verzeichnis aus, in dem sich Ihre Dockerfile befindet, um das Docker-Image zu erstellen:
   ```bash
   docker build -t aspose-slides-php-java .
   ```

3. **Docker-Container ausführen**. Nachdem das Image erstellt wurde, führen Sie den Container aus:
   ```bash
   docker run -p 8080:8080 aspose-slides-php-java
   ```

4. **Zugriff auf Aspose.Slides in Docker**. Nachdem Sie den Container gestartet haben, wird das Skript eine PDF-Datei generieren. Sie finden die generierte Ausgabedatei `output.pdf` im Ordner `/tmp` im Container:
   ```bash
   docker exec -it <container-id> ls /tmp
   ```
   Um die generierte PDF-Datei auf Ihren lokalen Rechner zu kopieren, führen Sie den folgenden Befehl aus:
   ```bash
   docker cp <container-id>:/tmp/output.pdf ./output.pdf
   ```