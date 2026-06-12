---
title: Installeer Aspose.Slides voor PHP via Java met Docker
type: docs
weight: 75
url: /nl/php-java/installing-slides-php-using-docker/
keywords:
- downloaden Aspose.Slides
- installeren Aspose.Slides
- Aspose.Slides installatie
- Docker
- Windows
- macOS
- Linux
- cross-platform compatibiliteit
- afhankelijkheidsisolatie
- vereenvoudigde implementatie
- projectinstelling
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Voer Aspose.Slides uit in Docker-containers: configureer images, afhankelijkheden, lettertypen en licenties om schaalbare services te bouwen die PowerPoint & OpenDocument verwerken."
---
## **Voorvereisten**
* Installeer Docker op je machine. Je kunt de officiële installatiehandleiding [hier](https://docs.docker.com/get-docker/) volgen.

## **Stappen**

### **1. Maak een Dockerfile aan** 
   Maak een nieuw bestand met de naam Dockerfile aan in je projectmap met de volgende inhoud:
   ```
   # Basisafbeelding (officiële Ubuntu-afbeelding)
   FROM ubuntu:20.04
   
   # Stel de tijdzone meteen in om interactieve selectie te voorkomen
   ENV DEBIAN_FRONTEND=noninteractive
   RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
       apt-get update && apt-get install -y tzdata && \
       dpkg-reconfigure --frontend noninteractive tzdata
   
   # Installeer benodigde pakketten en werk pakketlijsten bij
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
   
   # Accepteer automatisch de licentieovereenkomst voor het installeren van Microsoft TrueType-lettertypen
   RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
   
   # Installeer Microsoft TrueType-lettertypen
   RUN apt-get update && \
       apt-get install -y ttf-mscorefonts-installer && \
       rm -rf /var/lib/apt/lists/*
   
   # Installeer Tomcat - gebruik versie 9.0.93
   RUN wget https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.93/bin/apache-tomcat-9.0.93.tar.gz -O /tmp/tomcat.tar.gz && \
       tar xzf /tmp/tomcat.tar.gz -C /opt/ && \
       mv /opt/apache-tomcat-9.0.93 /opt/tomcat && \
       rm /tmp/tomcat.tar.gz
   
   # Installeer PHP/Java Bridge
   RUN curl -L http://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download -o /tmp/php-java-bridge.zip && \
       unzip /tmp/php-java-bridge.zip -d /tmp/php-java-bridge && \
       mkdir -p /opt/tomcat/webapps/JavaBridge && \
       cp /tmp/php-java-bridge/JavaBridge.war /opt/tomcat/webapps/JavaBridge && \
       cd /opt/tomcat/webapps/JavaBridge && \
       jar -xvf JavaBridge.war && \
       rm -rf /tmp/php-java-bridge.zip /tmp/php-java-bridge
   
   # Download en installeer Aspose.Slides voor PHP via Java
   RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
       unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
       mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       mkdir -p /tmp/sample && \
       cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
       rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides
   
   # Maak het bestand test.php aan
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
   
   # Maak het script entrypoint.sh aan
   RUN echo '#!/bin/bash\n\
   # Start Tomcat op de achtergrond\n\
   catalina.sh start\n\
   # Wacht tot Tomcat volledig gestart is\n\
   until curl -s http://localhost:8080 > /dev/null; do\n\
    sleep 2\n\
   done\n\
   echo "Running the PHP script..."\n\
   # Voer het PHP‑script uit\n\
   php /tmp/sample/test.php\n\
   echo "PHP script completed, please check file /tmp/output.pdf."\n\
   # Houd de container actief\n\
   echo "Keeping the container alive..."\n\
   tail -f /dev/null\n\
   ' > /tmp/entrypoint.sh
   
   # Verleen expliciet uitvoerrechten aan het script
   RUN chmod 755 /tmp/entrypoint.sh
   
   # Configureer php.ini
   RUN echo "allow_url_include = On" >> /etc/php/7.4/cli/php.ini
   
   # Stel omgevingsvariabelen in voor Tomcat
   ENV CATALINA_HOME /opt/tomcat
   ENV PATH $CATALINA_HOME/bin:$PATH
   ENV PHP_CLASSPATH /opt/aspose-slides/lib
   
   # Stel poort 8080 bloot voor Tomcat en poort 9000 voor PHP/Java Bridge
   EXPOSE 8080
   EXPOSE 9000
   
   # Stel de werkdirectory in
   WORKDIR /tmp
   
   # Start Tomcat wanneer de container start
   ENTRYPOINT ["/tmp/entrypoint.sh"]
```

### **2. Bouw de Docker-image** 
   Voer de volgende opdracht uit in de map waar je Dockerfile zich bevindt om de Docker-image te bouwen:
   ```bash
   docker build -t aspose-slides-php-java .
   ```

### **3. Start de Docker-container** 
   Zodra de image is gebouwd, start je de container:
   ```bash
   docker run -p 8080:8080 aspose-slides-php-java
   ```

### 4. **Toegang tot Aspose.Slides in Docker** 
   Na het starten van de container genereert het script een PDF‑bestand. Je kunt het gegenereerde uitvoerbestand `output.pdf` vinden in de map `/tmp` binnen de container:
   ```bash
   docker exec -it <container-id> ls /tmp
   ```
   Om het gegenereerde PDF‑bestand naar je lokale machine te kopiëren, voer je de volgende opdracht uit:
   ```bash
   docker cp <container-id>:/tmp/output.pdf ./output.pdf
   ```