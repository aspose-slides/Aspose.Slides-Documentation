---
title: Installation
type: docs
weight: 70
url: /php-java/installation/
keywords:
- download Aspose.Slides
- install Aspose.Slides
- Aspose.Slides installation
- Windows
- macOS
- Linux
- PHP
description: "Install Aspose.Slides for PHP via Java in Windows, Linux or macOS"
---

## **Configure environment**

1. Install PHP 7, add the PHP path to the system `PATH` variable and set `allow_url_include` to `On` in the `php.ini` file.
1. Install JRE 8. Set the `JAVA_HOME` environment variable to the path of the installed JRE.
1. Install Apache Tomcat 8.0.

## **Download Aspose.Slides for PHP via Java** 

`packagist` is the easiest way to download [Aspose.Slides for PHP via Java](https://packagist.org/packages/aspose/slides). 

To install Aspose.Slides using Packagist, run this command: 
   ```bash
   composer require aspose/slides
   ```

## **Configure Apache Tomcat**

1. Download PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) from http://php-java-bridge.sourceforge.net/pjb/download.php and extract `JavaBridge.war` file to tomcat `webapps` folder.
1. Start Apache Tomcat service.
1. Download [“Aspose.Slides for PHP via Java”](https://downloads.aspose.com/slides/php-java) and extract it to `aspose.slides` folder. Copy `jar/aspose-slides-x.x-php.jar` file to `webapps\JavaBridge\WEB-INF\lib` folder. If you are using **PHP 8**, replace the original `Java.inc` from PHP-Java Bridge with the `Java.inc` from `Java.inc.php8.zip`.
1. Restart Apache Tomcat service.
1. Run `example.php` in `aspose.slides` folder to run the example with this command:
   ```bash
   php example.php
   ```

## Docker Setup ##

Prerequisites:
* Install Docker on your machine. You can follow the official installation guide [here](https://docs.docker.com/get-docker/).

Steps:
1. **Create Dockerfile**. Create a new file named Dockerfile in your project directory with the following content:
   ```
   # Base image (official Ubuntu image)
   FROM ubuntu:20.04
   
   # Set the time zone upfront to avoid interactive selection
   ENV DEBIAN_FRONTEND=noninteractive
   RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
       apt-get update && apt-get install -y tzdata && \
       dpkg-reconfigure --frontend noninteractive tzdata
   
   # Install necessary packages and update package lists
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
   
   # Automatically accept the license agreement for installing Microsoft TrueType fonts
   RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
   
   # Install Microsoft TrueType fonts
   RUN apt-get update && \
       apt-get install -y ttf-mscorefonts-installer && \
       rm -rf /var/lib/apt/lists/*
   
   # Install Tomcat - using version 9.0.93
   RUN wget https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.93/bin/apache-tomcat-9.0.93.tar.gz -O /tmp/tomcat.tar.gz && \
       tar xzf /tmp/tomcat.tar.gz -C /opt/ && \
       mv /opt/apache-tomcat-9.0.93 /opt/tomcat && \
       rm /tmp/tomcat.tar.gz
   
   # Install PHP/Java Bridge
   RUN curl -L http://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download -o /tmp/php-java-bridge.zip && \
       unzip /tmp/php-java-bridge.zip -d /tmp/php-java-bridge && \
       mkdir -p /opt/tomcat/webapps/JavaBridge && \
       cp /tmp/php-java-bridge/JavaBridge.war /opt/tomcat/webapps/JavaBridge && \
       cd /opt/tomcat/webapps/JavaBridge && \
       jar -xvf JavaBridge.war && \
       rm -rf /tmp/php-java-bridge.zip /tmp/php-java-bridge
   
   # Download and install Aspose.Slides for PHP via Java
   RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
       unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
       mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       mkdir -p /tmp/sample && \
       cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
       rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides
   
   # Create the test.php file
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
   
   # Create the entrypoint.sh script
   RUN echo '#!/bin/bash\n\
   # Start Tomcat in the background\n\
   catalina.sh start\n\
   # Wait for Tomcat to fully start\n\
   until curl -s http://localhost:8080 > /dev/null; do\n\
    sleep 2\n\
   done\n\
   echo "Running the PHP script..."\n\
   # Run the PHP script\n\
   php /tmp/sample/test.php\n\
   echo "PHP script completed, please check file /tmp/output.pdf."\n\
   # Keep the container alive\n\
   echo "Keeping the container alive..."\n\
   tail -f /dev/null\n\
   ' > /tmp/entrypoint.sh
   
   # Explicitly grant execute permissions to the script
   RUN chmod 755 /tmp/entrypoint.sh
   
   # Configure php.ini
   RUN echo "allow_url_include = On" >> /etc/php/7.4/cli/php.ini
   
   # Set environment variables for Tomcat
   ENV CATALINA_HOME /opt/tomcat
   ENV PATH $CATALINA_HOME/bin:$PATH
   ENV PHP_CLASSPATH /opt/aspose-slides/lib
   
   # Expose port 8080 for Tomcat and port 9000 for PHP/Java Bridge
   EXPOSE 8080
   EXPOSE 9000
   
   # Set the working directory
   WORKDIR /tmp
   
   # Start Tomcat when the container starts
   ENTRYPOINT ["/tmp/entrypoint.sh"]
   ```

2. **Build Docker Image**. Run the following command in the directory where your Dockerfile is located to build the Docker image:
   ```bash
   docker build -t aspose-slides-php-java .
   ```

3. **Run Docker Container**. Once the image is built, run the container:
   ```bash
   docker run -p 8080:8080 aspose-slides-php-java
   ```

4. **Access Aspose.Slides in Docker**. After starting the container, the script will generate a PDF file. You can find the generated output file `output.pdf` in the `/tmp` folder inside the container:
   ```bash
   docker exec -it <container-id> ls /tmp
   ```
   To copy the generated PDF file to your local machine, run the following command:
   ```bash
   docker cp <container-id>:/tmp/output.pdf ./output.pdf
   ```