---
title: Instal Aspose.Slides untuk PHP via Java Menggunakan Docker
type: docs
weight: 75
url: /id/php-java/installing-slides-php-using-docker/
keywords:
- unduh Aspose.Slides
- pasang Aspose.Slides
- instalasi Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- kompatibilitas lintas platform
- isolasi dependensi
- penyebaran yang disederhanakan
- penyiapan proyek
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Jalankan Aspose.Slides dalam container Docker: konfigurasikan image, dependensi, font, dan lisensi untuk membangun layanan skalabel yang memproses PowerPoint & OpenDocument."
---
## **Prasyarat**
* Instal Docker di mesin Anda. Anda dapat mengikuti panduan instalasi resmi [di sini](https://docs.docker.com/get-docker/).

## **Langkah-langkah**

### **1. Buat Dockerfile** 
   Buat file baru bernama Dockerfile di direktori proyek Anda dengan konten berikut:
   ```
   # Image dasar (gambar Ubuntu resmi)
   FROM ubuntu:20.04
   
   # Atur zona waktu di awal untuk menghindari pemilihan interaktif
   ENV DEBIAN_FRONTEND=noninteractive
   RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
       apt-get update && apt-get install -y tzdata && \
       dpkg-reconfigure --frontend noninteractive tzdata
   
   # Instal paket yang diperlukan dan perbarui daftar paket
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
   
   # Secara otomatis menerima perjanjian lisensi untuk menginstal font Microsoft TrueType
   RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
   
   # Instal font Microsoft TrueType
   RUN apt-get update && \
       apt-get install -y ttf-mscorefonts-installer && \
       rm -rf /var/lib/apt/lists/*
   
   # Instal Tomcat - menggunakan versi 9.0.93
   RUN wget https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.93/bin/apache-tomcat-9.0.93.tar.gz -O /tmp/tomcat.tar.gz && \
       tar xzf /tmp/tomcat.tar.gz -C /opt/ && \
       mv /opt/apache-tomcat-9.0.93 /opt/tomcat && \
       rm /tmp/tomcat.tar.gz
   
   # Instal PHP/Java Bridge
   RUN curl -L http://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download -o /tmp/php-java-bridge.zip && \
       unzip /tmp/php-java-bridge.zip -d /tmp/php-java-bridge && \
       mkdir -p /opt/tomcat/webapps/JavaBridge && \
       cp /tmp/php-java-bridge/JavaBridge.war /opt/tomcat/webapps/JavaBridge && \
       cd /opt/tomcat/webapps/JavaBridge && \
       jar -xvf JavaBridge.war && \
       rm -rf /tmp/php-java-bridge.zip /tmp/php-java-bridge
   
   # Unduh dan instal Aspose.Slides untuk PHP via Java
   RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
       unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
       mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       mkdir -p /tmp/sample && \
       cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
       rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides
   
   # Buat file test.php
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
   
   # Buat skrip entrypoint.sh
   RUN echo '#!/bin/bash\n\
   # Mulai Tomcat di latar belakang\n\
   catalina.sh start\n\
   # Tunggu Tomcat sepenuhnya mulai\n\
   until curl -s http://localhost:8080 > /dev/null; do\n\
    sleep 2\n\
   done\n\
   echo "Running the PHP script..."\n\
   # Jalankan skrip PHP\n\
   php /tmp/sample/test.php\n\
   echo "PHP script completed, please check file /tmp/output.pdf."\n\
   # Jaga container tetap hidup\n\
   echo "Keeping the container alive..."\n\
   tail -f /dev/null\n\
   ' > /tmp/entrypoint.sh
   
   # Beri izin eksekusi secara eksplisit pada skrip
   RUN chmod 755 /tmp/entrypoint.sh
   
   # Konfigurasikan php.ini
   RUN echo "allow_url_include = On" >> /etc/php/7.4/cli/php.ini
   
   # Atur variabel lingkungan untuk Tomcat
   ENV CATALINA_HOME /opt/tomcat
   ENV PATH $CATALINA_HOME/bin:$PATH
   ENV PHP_CLASSPATH /opt/aspose-slides/lib
   
   # Ekspose port 8080 untuk Tomcat dan port 9000 untuk PHP/Java Bridge
   EXPOSE 8080
   EXPOSE 9000
   
   # Atur direktori kerja
   WORKDIR /tmp
   
   # Mulai Tomcat saat container dimulai
   ENTRYPOINT ["/tmp/entrypoint.sh"]
```

### **2. Bangun Image Docker**
   Jalankan perintah berikut di direktori tempat Dockerfile Anda berada untuk membangun image Docker:
   ```bash
   docker build -t aspose-slides-php-java .
   ```

### **3. Jalankan Container Docker**
   Setelah image selesai dibangun, jalankan container:
   ```bash
   docker run -p 8080:8080 aspose-slides-php-java
   ```

### 4. **Akses Aspose.Slides di Docker** 
   Setelah memulai container, skrip akan menghasilkan file PDF. Anda dapat menemukan file output yang dihasilkan `output.pdf` di folder `/tmp` di dalam container:
   ```bash
   docker exec -it <container-id> ls /tmp
   ```
   Untuk menyalin file PDF yang dihasilkan ke mesin lokal Anda, jalankan perintah berikut:
   ```bash
   docker cp <container-id>:/tmp/output.pdf ./output.pdf
   ```