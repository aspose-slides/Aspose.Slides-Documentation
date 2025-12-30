---
title: Aspose.Slides für PHP via Java mit Docker installieren
type: docs
weight: 75
url: /de/php-java/installing-slides-php-using-docker/
keywords:
- Aspose.Slides herunterladen
- Aspose.Slides installieren
- Aspose.Slides Installation
- Docker
- Windows
- macOS
- Linux
- Plattformübergreifende Kompatibilität
- Abhängigkeitsisolierung
- Vereinfachte Bereitstellung
- Projektkonfiguration
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Führen Sie Aspose.Slides in Docker-Containern aus: Konfigurieren Sie Images, Abhängigkeiten, Schriftarten und Lizenzierung, um skalierbare Dienste zu erstellen, die PowerPoint- und OpenDocument-Dateien verarbeiten."
---

## **Voraussetzungen**
* Installieren Sie Docker auf Ihrem Rechner. Sie können die offizielle Installationsanleitung [hier](https://docs.docker.com/get-docker/) lesen.

## **Schritte**

### **1. Erstellen Sie eine Dockerfile** 
   Erstellen Sie eine neue Datei mit dem Namen Dockerfile in Ihrem Projektverzeichnis mit folgendem Inhalt:
```dockerfile
# Basis-Image (offizielles Ubuntu-Image)
FROM ubuntu:20.04

# Zeitzone im Voraus festlegen, um interaktive Auswahl zu vermeiden
ENV DEBIAN_FRONTEND=noninteractive
RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
    apt-get update && apt-get install -y tzdata && \
    dpkg-reconfigure --frontend noninteractive tzdata

# Notwendige Pakete installieren und Paketlisten aktualisieren
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

# Lizenzvereinbarung für die Installation von Microsoft TrueType-Schriftarten automatisch akzeptieren
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections

# Microsoft TrueType-Schriftarten installieren
RUN apt-get update && \
    apt-get install -y ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# Tomcat installieren – Version 9.0.93 verwenden
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

# Aspose.Slides für PHP via Java herunterladen und installieren
RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
    unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
    mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
    mkdir -p /tmp/sample && \
    cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
    cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
    rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides

# test.php-Datei erstellen
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

# entrypoint.sh-Skript erstellen
RUN echo '#!/bin/bash\n\
# Tomcat im Hintergrund starten\n\
catalina.sh start\n\
# Warten, bis Tomcat vollständig gestartet ist\n\
until curl -s http://localhost:8080 > /dev/null; do\n\
 sleep 2\n\
done\n\
echo "Running the PHP script..."\n\
# PHP-Skript ausführen\n\
php /tmp/sample/test.php\n\
echo "PHP script completed, please check file /tmp/output.pdf."\n\
# Container am Leben halten\n\
echo "Keeping the container alive..."\n\
# Halte den Container am Leben...\n\
tail -f /dev/null\n\
' > /tmp/entrypoint.sh

# Ausführungsrechte für das Skript explizit gewähren
RUN chmod 755 /tmp/entrypoint.sh

# php.ini konfigurieren
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

# Tomcat starten, wenn der Container startet
ENTRYPOINT ["/tmp/entrypoint.sh"]
```


### **2. Erstellen Sie das Docker-Image**
   Führen Sie den folgenden Befehl im Verzeichnis aus, in dem sich Ihre Dockerfile befindet, um das Docker-Image zu erstellen:
```bash
docker build -t aspose-slides-php-java .
```


### **3. Führen Sie den Docker-Container aus**
   Sobald das Image erstellt ist, starten Sie den Container:
```bash
docker run -p 8080:8080 aspose-slides-php-java
```


### **4. Zugriff auf Aspose.Slides in Docker** 
   Nach dem Starten des Containers erzeugt das Skript eine PDF-Datei. Sie finden die erzeugte Ausgabedatei `output.pdf` im Ordner `/tmp` innerhalb des Containers:
```bash
docker exec -it <container-id> ls /tmp
```

   Um die erzeugte PDF-Datei auf Ihren lokalen Rechner zu kopieren, führen Sie den folgenden Befehl aus:
```bash
docker cp <container-id>:/tmp/output.pdf ./output.pdf
```
