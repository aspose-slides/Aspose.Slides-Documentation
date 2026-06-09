---
title: Εγκατάσταση Aspose.Slides για PHP μέσω Java χρησιμοποιώντας Docker
type: docs
weight: 75
url: /el/php-java/installing-slides-php-using-docker/
keywords:
- λήψη Aspose.Slides
- εγκατάσταση Aspose.Slides
- Εγκατάσταση Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- πολυπλατφορμική συμβατότητα
- απομόνωση εξαρτήσεων
- απλοποιημένη ανάπτυξη
- ρύθμιση έργου
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Εκτελέστε το Aspose.Slides σε containers Docker: διαμορφώστε εικόνες, εξαρτήσεις, γραμματοσειρές και άδειες για να δημιουργήσετε κλιμακούμενες υπηρεσίες που επεξεργάζονται PowerPoint & OpenDocument."
---
## **Προαπαιτούμενα**
* Εγκαταστήστε το Docker στον υπολογιστή σας. Μπορείτε να ακολουθήσετε τον επίσημο οδηγό εγκατάστασης [εδώ](https://docs.docker.com/get-docker/).

## **Βήματα**

### **1. Δημιουργία Dockerfile** 
   Δημιουργήστε ένα νέο αρχείο με όνομα Dockerfile στον κατάλογο του έργου σας με το παρακάτω περιεχόμενο:
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

### **2. Δομήστε την Docker εικόνα**
   Εκτελέστε την παρακάτω εντολή στον κατάλογο όπου βρίσκεται το Dockerfile για να δημιουργήσετε την Docker εικόνα:
   ```bash
   docker build -t aspose-slides-php-java .
   ```

### **3. Εκτελέστε το Docker Container**
   Μόλις δημιουργηθεί η εικόνα, εκκινήστε το container:
   ```bash
   docker run -p 8080:8080 aspose-slides-php-java
   ```

### **4. **Πρόσβαση στο Aspose.Slides στο Docker** 
   Αφού εκκινήσετε το container, το script θα δημιουργήσει ένα αρχείο PDF. Μπορείτε να βρείτε το δημιουργημένο αρχείο εξόδου `output.pdf` στον φάκελο `/tmp` μέσα στο container:
   ```bash
   docker exec -it <container-id> ls /tmp
   ```
   Για να αντιγράψετε το δημιουργημένο αρχείο PDF στον τοπικό σας υπολογιστή, εκτελέστε την ακόλουθη εντολή:
   ```bash
   docker cp <container-id>:/tmp/output.pdf ./output.pdf
   ```