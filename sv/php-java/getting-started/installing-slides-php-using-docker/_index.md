---
title: Installera Aspose.Slides för PHP via Java med Docker
type: docs
weight: 75
url: /sv/php-java/installing-slides-php-using-docker/
keywords:
- ladda ner Aspose.Slides
- installera Aspose.Slides
- installation av Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- plattformsoberoende kompatibilitet
- beroendeisolering
- förenklad distribution
- projektuppsättning
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Kör Aspose.Slides i Docker-containrar: konfigurera avbildningar, beroenden, teckensnitt och licensiering för att skapa skalbara tjänster som behandlar PowerPoint & OpenDocument."
---
## **Förutsättningar**
* Installera Docker på din maskin. Du kan följa den officiella installationsguiden [här](https://docs.docker.com/get-docker/).

## **Steg**

### **1. Skapa en Dockerfile** 
   Skapa en ny fil med namnet Dockerfile i din projektkatalog med följande innehåll:
   ```
   # Basavbild (officiell Ubuntu-avbild)
   FROM ubuntu:20.04
   
   # Ställ in tidszonen i förväg för att undvika interaktivt val
   ENV DEBIAN_FRONTEND=noninteractive
   RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
       apt-get update && apt-get install -y tzdata && \
       dpkg-reconfigure --frontend noninteractive tzdata
   
   # Installera nödvändiga paket och uppdatera paketlistor
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
   
   # Acceptera automatiskt licensavtalet för att installera Microsoft TrueType-teckensnitt
   RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
   
   # Installera Microsoft TrueType-teckensnitt
   RUN apt-get update && \
       apt-get install -y ttf-mscorefonts-installer && \
       rm -rf /var/lib/apt/lists/*
   
   # Installera Tomcat - använder version 9.0.93
   RUN wget https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.93/bin/apache-tomcat-9.0.93.tar.gz -O /tmp/tomcat.tar.gz && \
       tar xzf /tmp/tomcat.tar.gz -C /opt/ && \
       mv /opt/apache-tomcat-9.0.93 /opt/tomcat && \
       rm /tmp/tomcat.tar.gz
   
   # Installera PHP/Java Bridge
   RUN curl -L http://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download -o /tmp/php-java-bridge.zip && \
       unzip /tmp/php-java-bridge.zip -d /tmp/php-java-bridge && \
       mkdir -p /opt/tomcat/webapps/JavaBridge && \
       cp /tmp/php-java-bridge/JavaBridge.war /opt/tomcat/webapps/JavaBridge && \
       cd /opt/tomcat/webapps/JavaBridge && \
       jar -xvf JavaBridge.war && \
       rm -rf /tmp/php-java-bridge.zip /tmp/php-java-bridge
   
   # Hämta och installera Aspose.Slides för PHP via Java
   RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
       unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
       mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       mkdir -p /tmp/sample && \
       cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
       rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides
   
   # Skapa filen test.php
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
   
   # Skapa scriptet entrypoint.sh
   RUN echo '#!/bin/bash\n\
   # Starta Tomcat i bakgrunden\n\
   catalina.sh start\n\
   # Vänta tills Tomcat har startat helt\n\
   until curl -s http://localhost:8080 > /dev/null; do\n\
    sleep 2\n\
   done\n\
   echo "Running the PHP script..."\n\
   # Kör PHP‑skriptet\n\
   php /tmp/sample/test.php\n\
   echo "PHP script completed, please check file /tmp/output.pdf."\n\
   # Håll containern vid liv\n\
   echo "Keeping the container alive..."\n\
   tail -f /dev/null\n\
   ' > /tmp/entrypoint.sh
   
   # Bevilja explicit körbehörigheter till skriptet
   RUN chmod 755 /tmp/entrypoint.sh
   
   # Konfigurera php.ini
   RUN echo "allow_url_include = On" >> /etc/php/7.4/cli/php.ini
   
   # Ställ in miljövariabler för Tomcat
   ENV CATALINA_HOME /opt/tomcat
   ENV PATH $CATALINA_HOME/bin:$PATH
   ENV PHP_CLASSPATH /opt/aspose-slides/lib
   
   # Exponera port 8080 för Tomcat och port 9000 för PHP/Java Bridge
   EXPOSE 8080
   EXPOSE 9000
   
   # Ställ in arbetskatalogen
   WORKDIR /tmp
   
   # Starta Tomcat när containern startar
   ENTRYPOINT ["/tmp/entrypoint.sh"]
   ```

### **2. Bygg Docker‑avbildningen**
   Kör följande kommando i katalogen där din Dockerfile finns för att bygga Docker‑avbildningen:
   ```bash
   docker build -t aspose-slides-php-java .
   ```

### **3. Kör Docker‑behållaren**
   När avbildningen är byggd, kör behållaren:
   ```bash
   docker run -p 8080:8080 aspose-slides-php-java
   ```

### **4. Åtkomst till Aspose.Slides i Docker** 
   Efter att behållaren har startats kommer skriptet att generera en PDF‑fil. Du kan hitta den genererade utdatafilen `output.pdf` i mappen `/tmp` i behållaren:
   ```bash
   docker exec -it <container-id> ls /tmp
   ```
   För att kopiera den genererade PDF‑filen till din lokala maskin, kör följande kommando:
   ```bash
   docker cp <container-id>:/tmp/output.pdf ./output.pdf
   ```