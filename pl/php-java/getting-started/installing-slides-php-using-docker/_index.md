---
title: Zainstaluj Aspose.Slides dla PHP poprzez Java przy użyciu Docker
type: docs
weight: 75
url: /pl/php-java/installing-slides-php-using-docker/
keywords:
- pobierz Aspose.Slides
- zainstaluj Aspose.Slides
- instalacja Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- kompatybilność międzyplatformowa
- izolacja zależności
- uproszczone wdrażanie
- konfiguracja projektu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Uruchom Aspose.Slides w kontenerach Docker: skonfiguruj obrazy, zależności, czcionki i licencjonowanie, aby zbudować skalowalne usługi przetwarzające PowerPoint i OpenDocument."
---
## **Wymagania wstępne**
* Zainstaluj Docker na swoim komputerze. Oficjalny przewodnik instalacji znajdziesz [tutaj](https://docs.docker.com/get-docker/).

## **Kroki**

### **1. Utwórz plik Dockerfile** 
   Utwórz nowy plik o nazwie Dockerfile w katalogu projektu z następującą zawartością:
   ```
   # Obraz bazowy (oficjalny obraz Ubuntu)
   FROM ubuntu:20.04
   
   # Ustaw strefę czasową od razu, aby uniknąć interaktywnego wyboru
   ENV DEBIAN_FRONTEND=noninteractive
   RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
       apt-get update && apt-get install -y tzdata && \
       dpkg-reconfigure --frontend noninteractive tzdata
   
   # Zainstaluj niezbędne pakiety i zaktualizuj listy pakietów
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
   
   # Automatycznie zaakceptuj umowę licencyjną przy instalacji czcionek Microsoft TrueType
   RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
   
   # Zainstaluj czcionki Microsoft TrueType
   RUN apt-get update && \
       apt-get install -y ttf-mscorefonts-installer && \
       rm -rf /var/lib/apt/lists/*
   
   # Zainstaluj Tomcat - używając wersji 9.0.93
   RUN wget https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.93/bin/apache-tomcat-9.0.93.tar.gz -O /tmp/tomcat.tar.gz && \
       tar xzf /tmp/tomcat.tar.gz -C /opt/ && \
       mv /opt/apache-tomcat-9.0.93 /opt/tomcat && \
       rm /tmp/tomcat.tar.gz
   
   # Zainstaluj PHP/Java Bridge
   RUN curl -L http://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download -o /tmp/php-java-bridge.zip && \
       unzip /tmp/php-java-bridge.zip -d /tmp/php-java-bridge && \
       mkdir -p /opt/tomcat/webapps/JavaBridge && \
       cp /tmp/php-java-bridge/JavaBridge.war /opt/tomcat/webapps/JavaBridge && \
       cd /opt/tomcat/webapps/JavaBridge && \
       jar -xvf JavaBridge.war && \
       rm -rf /tmp/php-java-bridge.zip /tmp/php-java-bridge
   
   # Pobierz i zainstaluj Aspose.Slides dla PHP poprzez Java
   RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
       unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
       mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       mkdir -p /tmp/sample && \
       cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
       rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides
   
   # Utwórz plik test.php
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
   
   # Utwórz skrypt entrypoint.sh
   RUN echo '#!/bin/bash\n\
   # Uruchom Tomcat w tle\n\
   catalina.sh start\n\
   # Czekaj aż Tomcat w pełni się uruchomi\n\
   until curl -s http://localhost:8080 > /dev/null; do\n\
    sleep 2\n\
   done\n\
   echo "Running the PHP script..."\n\
   # Uruchom skrypt PHP\n\
   php /tmp/sample/test.php\n\
   echo "PHP script completed, please check file /tmp/output.pdf."\n\
   # Utrzymaj kontener aktywny\n\
   echo "Keeping the container alive..."\n\
   tail -f /dev/null\n\
   ' > /tmp/entrypoint.sh
   
   # Jawnie przyznaj uprawnienia wykonywania skryptowi
   RUN chmod 755 /tmp/entrypoint.sh
   
   # Skonfiguruj php.ini
   RUN echo "allow_url_include = On" >> /etc/php/7.4/cli/php.ini
   
   # Ustaw zmienne środowiskowe dla Tomcata
   ENV CATALINA_HOME /opt/tomcat
   ENV PATH $CATALINA_HOME/bin:$PATH
   ENV PHP_CLASSPATH /opt/aspose-slides/lib
   
   # Udostępnij port 8080 dla Tomcata i port 9000 dla PHP/Java Bridge
   EXPOSE 8080
   EXPOSE 9000
   
   # Ustaw katalog roboczy
   WORKDIR /tmp
   
   # Uruchom Tomcat przy starcie kontenera
   ENTRYPOINT ["/tmp/entrypoint.sh"]
   ```

### **2. Zbuduj obraz Dockera**
   Uruchom następujące polecenie w katalogu, w którym znajduje się Twój Dockerfile, aby zbudować obraz Dockera:
   ```bash
   docker build -t aspose-slides-php-java .
   ```

### **3. Uruchom kontener Dockera**
   Po zbudowaniu obrazu uruchom kontener:
   ```bash
   docker run -p 8080:8080 aspose-slides-php-java
   ```

### 4. **Uzyskaj dostęp do Aspose.Slides w Dockerze** 
   Po uruchomieniu kontenera skrypt wygeneruje plik PDF. Wygenerowany plik wyjściowy `output.pdf` znajdziesz w katalogu `/tmp` wewnątrz kontenera:
   ```bash
   docker exec -it <container-id> ls /tmp
   ```
   Aby skopiować wygenerowany plik PDF na swój komputer, uruchom następujące polecenie:
   ```bash
   docker cp <container-id>:/tmp/output.pdf ./output.pdf
   ```