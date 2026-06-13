---
title: نصب Aspose.Slides برای PHP از طریق Java با استفاده از Docker
type: docs
weight: 75
url: /fa/php-java/installing-slides-php-using-docker/
keywords:
- دانلود Aspose.Slides
- نصب Aspose.Slides
- نصب Aspose.Slides
- Docker
- ویندوز
- macOS
- لینوکس
- سازگاری چندپلتفرمی
- جداسازی وابستگی‌ها
- استقرار ساده‌شده
- تنظیم پروژه
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "اجرای Aspose.Slides در کانتینرهای Docker: پیکربندی تصاویر، وابستگی‌ها، قلم‌ها و مجوزها برای ساخت سرویس‌های مقیاس‌پذیر که PowerPoint و OpenDocument را پردازش می‌کنند."
---
## **پیش‌نیازها**
* Docker را بر روی دستگاه خود نصب کنید. می‌توانید راهنمای نصب رسمی را در [اینجا](https://docs.docker.com/get-docker/) دنبال کنید.

## **مراحل**

### **۱. Create a Dockerfile**
یک فایل جدید به نام Dockerfile در پوشه پروژه خود ایجاد کنید و محتویات زیر را در آن قرار دهید:
```dockerfile
   # تصویر پایه (تصویر رسمی اوبونتو)
   FROM ubuntu:20.04
   
   # تنظیم منطقه زمانی از ابتدا برای جلوگیری از انتخاب تعاملی
   ENV DEBIAN_FRONTEND=noninteractive
   RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
       apt-get update && apt-get install -y tzdata && \
       dpkg-reconfigure --frontend noninteractive tzdata
   
   # نصب بسته‌های ضروری و به‌روزرسانی فهرست بسته‌ها
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
   
   # پذیرش خودکار توافق‌نامه لایسنس برای نصب قلم‌های TrueType مایکروسافت
   RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
   
   # نصب قلم‌های TrueType مایکروسافت
   RUN apt-get update && \
       apt-get install -y ttf-mscorefonts-installer && \
       rm -rf /var/lib/apt/lists/*
   
   # نصب Tomcat - استفاده از نسخه 9.0.93
   RUN wget https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.93/bin/apache-tomcat-9.0.93.tar.gz -O /tmp/tomcat.tar.gz && \
       tar xzf /tmp/tomcat.tar.gz -C /opt/ && \
       mv /opt/apache-tomcat-9.0.93 /opt/tomcat && \
       rm /tmp/tomcat.tar.gz
   
   # نصب PHP/Java Bridge
   RUN curl -L http://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download -o /tmp/php-java-bridge.zip && \
       unzip /tmp/php-java-bridge.zip -d /tmp/php-java-bridge && \
       mkdir -p /opt/tomcat/webapps/JavaBridge && \
       cp /tmp/php-java-bridge/JavaBridge.war /opt/tomcat/webapps/JavaBridge && \
       cd /opt/tomcat/webapps/JavaBridge && \
       jar -xvf JavaBridge.war && \
       rm -rf /tmp/php-java-bridge.zip /tmp/php-java-bridge
   
   # دانلود و نصب Aspose.Slides برای PHP از طریق Java
   RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
       unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
       mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       mkdir -p /tmp/sample && \
       cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
       rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides
   
   # ایجاد فایل test.php
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
   
   # ایجاد اسکریپت entrypoint.sh
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
   
   # به‌صورت صریح اعطای دسترسی اجرا به اسکریپت
   RUN chmod 755 /tmp/entrypoint.sh
   
   # پیکربندی php.ini
   RUN echo "allow_url_include = On" >> /etc/php/7.4/cli/php.ini
   
   # تنظیم متغیرهای محیطی برای Tomcat
   ENV CATALINA_HOME /opt/tomcat
   ENV PATH $CATALINA_HOME/bin:$PATH
   ENV PHP_CLASSPATH /opt/aspose-slides/lib
   
   # در معرض قرار دادن پورت 8080 برای Tomcat و پورت 9000 برای PHP/Java Bridge
   EXPOSE 8080
   EXPOSE 9000
   
   # تنظیم پوشه کاری
   WORKDIR /tmp
   
   # راه‌اندازی Tomcat هنگام شروع کانتینر
   ENTRYPOINT ["/tmp/entrypoint.sh"]
```

### **۲. Build the Docker Image**
دستور زیر را در پوشه‌ای که Dockerfile شما قرار دارد اجرا کنید تا تصویر Docker ساخته شود:
```bash
   docker build -t aspose-slides-php-java .
   ```

### **۳. Run the Docker Container**
پس از ساخت تصویر، کانتینر را اجرا کنید:
```bash
   docker run -p 8080:8080 aspose-slides-php-java
   ```

### **۴. **Access Aspose.Slides in Docker**
پس از راه‌اندازی کانتینر، اسکریپت یک فایل PDF تولید می‌کند. می‌توانید فایل خروجی تولید شده `output.pdf` را در پوشه `/tmp` داخل کانتینر پیدا کنید:
```bash
   docker exec -it <container-id> ls /tmp
   ```
برای کپی کردن فایل PDF تولید شده به ماشین محلی خود، دستور زیر را اجرا کنید:
```bash
   docker cp <container-id>:/tmp/output.pdf ./output.pdf
   ```