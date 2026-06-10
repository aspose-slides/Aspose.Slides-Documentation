---
title: Aspose.Slides telepítése PHP-hez Java használatával Dockerben
type: docs
weight: 75
url: /hu/php-java/installing-slides-php-using-docker/
keywords:
- Aspose.Slides letöltése
- Aspose.Slides telepítése
- Aspose.Slides telepítése
- Docker
- Windows
- macOS
- Linux
- platformfüggetlen kompatibilitás
- függőség izoláció
- egyszerűsített telepítés
- projekt beállítása
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Aspose.Slides futtatása Docker konténerekben: képek, függőségek, betűtípusok és licenc beállítása a skálázható szolgáltatások építéséhez, amelyek PowerPointot és OpenDocumentot dolgoznak fel."
---
## **Előfeltételek**
* Telepítse a Docker-t a gépére. Kövesse a hivatalos telepítési útmutatót [itt](https://docs.docker.com/get-docker/).

## **Lépések**

### **1. Dockerfile létrehozása** 
   Hozzon létre egy új fájlt Dockerfile néven a projekt könyvtárában a következő tartalommal:
   ```
   # Alap kép (hivatalos Ubuntu kép)
   FROM ubuntu:20.04
   
   # Állítsa be előre az időzónát az interaktív kiválasztás elkerülése érdekében
   ENV DEBIAN_FRONTEND=noninteractive
   RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
       apt-get update && apt-get install -y tzdata && \
       dpkg-reconfigure --frontend noninteractive tzdata
   
   # Szükséges csomagok telepítése és a csomaglisták frissítése
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
   
   # A Microsoft TrueType betűtípusok telepítéséhez szükséges licencszerződés automatikus elfogadása
   RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
   
   # Microsoft TrueType betűtípusok telepítése
   RUN apt-get update && \
       apt-get install -y ttf-mscorefonts-installer && \
       rm -rf /var/lib/apt/lists/*
   
   # Tomcat telepítése - 9.0.93 verzió használatával
   RUN wget https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.93/bin/apache-tomcat-9.0.93.tar.gz -O /tmp/tomcat.tar.gz && \
       tar xzf /tmp/tomcat.tar.gz -C /opt/ && \
       mv /opt/apache-tomcat-9.0.93 /opt/tomcat && \
       rm /tmp/tomcat.tar.gz
   
   # PHP/Java Bridge telepítése
   RUN curl -L http://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download -o /tmp/php-java-bridge.zip && \
       unzip /tmp/php-java-bridge.zip -d /tmp/php-java-bridge && \
       mkdir -p /opt/tomcat/webapps/JavaBridge && \
       cp /tmp/php-java-bridge/JavaBridge.war /opt/tomcat/webapps/JavaBridge && \
       cd /opt/tomcat/webapps/JavaBridge && \
       jar -xvf JavaBridge.war && \
       rm -rf /tmp/php-java-bridge.zip /tmp/php-java-bridge
   
   # Aspose.Slides letöltése és telepítése PHP-hez Java-on keresztül
   RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
       unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
       mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       mkdir -p /tmp/sample && \
       cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
       rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides
   
   # A test.php fájl létrehozása
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
   
   # Az entrypoint.sh szkript létrehozása
   RUN echo '#!/bin/bash\n\
   # Tomcat indítása a háttérben\n\
   catalina.sh start\n\
   # Várakozás a Tomcat teljes elindulására\n\
   until curl -s http://localhost:8080 > /dev/null; do\n\
    sleep 2\n\
   done\n\
   echo "Running the PHP script..."\n\
   # A PHP szkript futtatása\n\
   php /tmp/sample/test.php\n\
   echo "PHP script completed, please check file /tmp/output.pdf."\n\
   # A konténer életben tartása\n\
   echo "Keeping the container alive..."\n\
   tail -f /dev/null\n\
   ' > /tmp/entrypoint.sh
   
   # Kifejezetten futtatási jogosultságot ad a szkriptnek
   RUN chmod 755 /tmp/entrypoint.sh
   
   # php.ini konfigurálása
   RUN echo "allow_url_include = On" >> /etc/php/7.4/cli/php.ini
   
   # Környezeti változók beállítása a Tomcat számára
   ENV CATALINA_HOME /opt/tomcat
   ENV PATH $CATALINA_HOME/bin:$PATH
   ENV PHP_CLASSPATH /opt/aspose-slides/lib
   
   # 8080-as port kitettre tétele Tomcat-nek és 9000-as port a PHP/Java Bridge számára
   EXPOSE 8080
   EXPOSE 9000
   
   # A munkakönyvtár beállítása
   WORKDIR /tmp
   
   # Tomcat indítása a konténer indításakor
   ENTRYPOINT ["/tmp/entrypoint.sh"]
```

### **2. Docker Image felépítése**
   Futtassa a következő parancsot abban a könyvtárban, ahol a Dockerfile található, a Docker image felépítéséhez:
   ```bash
   docker build -t aspose-slides-php-java .
   ```

### **3. Docker konténer futtatása**
   Miután a kép felépült, futtassa a konténert:
   ```bash
   docker run -p 8080:8080 aspose-slides-php-java
   ```

### 4. **Az Aspose.Slides elérése Dockerben** 
   A konténer indítása után a szkript PDF fájlt generál. A keletkezett `output.pdf` fájlt a konténeren belüli `/tmp` mappában találja:
   ```bash
   docker exec -it <container-id> ls /tmp
   ```
   A generált PDF fájl helyi gépre másolásához futtassa a következő parancsot:
   ```bash
   docker cp <container-id>:/tmp/output.pdf ./output.pdf
   ```