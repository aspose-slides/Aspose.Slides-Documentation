---
title: Instalace Aspose.Slides pro PHP pomocí Java a Dockeru
type: docs
weight: 75
url: /cs/php-java/installing-slides-php-using-docker/
keywords:
- stáhnout Aspose.Slides
- nainstalovat Aspose.Slides
- instalace Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- kompatibilita napříč platformami
- izolace závislostí
- zjednodušené nasazení
- nastavení projektu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Spusťte Aspose.Slides v Docker kontejnerech: nakonfigurujte obrazy, závislosti, písma a licencování k vytvoření škálovatelných služeb, které zpracovávají PowerPoint a OpenDocument."
---
## **Požadavky**
* Nainstalujte Docker na svůj počítač. Oficiální průvodce instalací najdete [zde](https://docs.docker.com/get-docker/).

## **Kroky**

### **1. Vytvořte Dockerfile** 
   Vytvořte nový soubor s názvem Dockerfile ve svém adresáři projektu s následujícím obsahem:
   ```
   # Základní obraz (oficiální Ubuntu image)
   FROM ubuntu:20.04
   
   # Nastavte časové pásmo předem, aby se zabránilo interaktivnímu výběru
   ENV DEBIAN_FRONTEND=noninteractive
   RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
       apt-get update && apt-get install -y tzdata && \
       dpkg-reconfigure --frontend noninteractive tzdata
   
   # Nainstalujte potřebné balíčky a aktualizujte seznam balíčků
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
   
   # Automaticky přijměte licenční smlouvu pro instalaci písem Microsoft TrueType
   RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
   
   # Instalovat písma Microsoft TrueType
   RUN apt-get update && \
       apt-get install -y ttf-mscorefonts-installer && \
       rm -rf /var/lib/apt/lists/*
   
   # Instalovat Tomcat - verze 9.0.93
   RUN wget https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.93/bin/apache-tomcat-9.0.93.tar.gz -O /tmp/tomcat.tar.gz && \
       tar xzf /tmp/tomcat.tar.gz -C /opt/ && \
       mv /opt/apache-tomcat-9.0.93 /opt/tomcat && \
       rm /tmp/tomcat.tar.gz
   
   # Instalovat PHP/Java Bridge
   RUN curl -L http://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download -o /tmp/php-java-bridge.zip && \
       unzip /tmp/php-java-bridge.zip -d /tmp/php-java-bridge && \
       mkdir -p /opt/tomcat/webapps/JavaBridge && \
       cp /tmp/php-java-bridge/JavaBridge.war /opt/tomcat/webapps/JavaBridge && \
       cd /opt/tomcat/webapps/JavaBridge && \
       jar -xvf JavaBridge.war && \
       rm -rf /tmp/php-java-bridge.zip /tmp/php-java-bridge
   
   # Stáhnout a nainstalovat Aspose.Slides pro PHP přes Java
   RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
       unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
       mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       mkdir -p /tmp/sample && \
       cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
       rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides
   
   # Vytvořit soubor test.php
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
   
   # Vytvořit skript entrypoint.sh
   RUN echo '#!/bin/bash\n\
   # Spustit Tomcat na pozadí\n\
   catalina.sh start\n\
   # Počkat, až se Tomcat plně spustí\n\
   until curl -s http://localhost:8080 > /dev/null; do\n\
    sleep 2\n\
   done\n\
   echo "Running the PHP script..."\n\
   # Spustit PHP skript\n\
   php /tmp/sample/test.php\n\
   echo "PHP script completed, please check file /tmp/output.pdf."\n\
   # Udržet kontejner běžící\n\
   echo "Keeping the container alive..."\n\
   tail -f /dev/null\n\
   ' > /tmp/entrypoint.sh
   
   # Výslovně udělat skript spustitelným
   RUN chmod 755 /tmp/entrypoint.sh
   
   # Konfigurovat php.ini
   RUN echo "allow_url_include = On" >> /etc/php/7.4/cli/php.ini
   
   # Nastavit proměnné prostředí pro Tomcat
   ENV CATALINA_HOME /opt/tomcat
   ENV PATH $CATALINA_HOME/bin:$PATH
   ENV PHP_CLASSPATH /opt/aspose-slides/lib
   
   # Otevřít port 8080 pro Tomcat a port 9000 pro PHP/Java Bridge
   EXPOSE 8080
   EXPOSE 9000
   
   # Nastavit pracovní adresář
   WORKDIR /tmp
   
   # Spustit Tomcat při startu kontejneru
   ENTRYPOINT ["/tmp/entrypoint.sh"]
   ```


### **2. Vytvořte Docker image**
   Spusťte následující příkaz v adresáři, kde se nachází váš Dockerfile, a vytvořte Docker image:
   ```bash
   docker build -t aspose-slides-php-java .
   ```

### **3. Spusťte Docker kontejner**
   Po vytvoření image spusťte kontejner:
   ```bash
   docker run -p 8080:8080 aspose-slides-php-java
   ```

### **4. Přístup k Aspose.Slides v Dockeru** 
   Po spuštění kontejneru skript vygeneruje soubor PDF. Vygenerovaný výstupní soubor `output.pdf` najdete ve složce `/tmp` uvnitř kontejneru:
   ```bash
   docker exec -it <container-id> ls /tmp
   ```
   Pro zkopírování vygenerovaného souboru PDF do vašeho místního počítače spusťte následující příkaz:
   ```bash
   docker cp <container-id>:/tmp/output.pdf ./output.pdf
   ```