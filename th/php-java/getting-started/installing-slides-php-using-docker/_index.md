---
title: ติดตั้ง Aspose.Slides สำหรับ PHP ผ่าน Java โดยใช้ Docker
type: docs
weight: 75
url: /th/php-java/installing-slides-php-using-docker/
keywords:
- ดาวน์โหลด Aspose.Slides
- ติดตั้ง Aspose.Slides
- การติดตั้ง Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- ความเข้ากันได้หลายแพลตฟอร์ม
- การแยกการพึ่งพา
- การปรับใช้ที่เรียบง่าย
- การตั้งค่าโครงการ
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียกใช้ Aspose.Slides ในคอนเทนเนอร์ Docker: กำหนดค่ารูปภาพ, การพึ่งพา, ฟอนต์ และใบอนุญาตเพื่อสร้างบริการที่สามารถขยายได้ซึ่งประมวลผล PowerPoint และ OpenDocument."
---
## **ข้อกำหนดเบื้องต้น**
* ติดตั้ง Docker บนเครื่องของคุณ คุณสามารถทำตามคำแนะนำการติดตั้งอย่างเป็นทางการได้ที่[ที่นี่](https://docs.docker.com/get-docker/).

## **ขั้นตอน**

### **1. สร้าง Dockerfile** 
   สร้างไฟล์ใหม่ชื่อ Dockerfile ในไดเรกทอรีโครงการของคุณด้วยเนื้อหาต่อไปนี้:
   ```
   # ภาพฐาน (ภาพ Ubuntu อย่างเป็นทางการ)
   FROM ubuntu:20.04
   
   # ตั้งค่าโซนเวลาไว้ล่วงหน้าเพื่อหลีกเลี่ยงการเลือกแบบโต้ตอบ
   ENV DEBIAN_FRONTEND=noninteractive
   RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
       apt-get update && apt-get install -y tzdata && \
       dpkg-reconfigure --frontend noninteractive tzdata
   
   # ติดตั้งแพคเกจที่จำเป็นและอัปเดตรายการแพคเกจ
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
   
   # ยอมรับข้อตกลงสิทธิ์ใช้งานโดยอัตโนมัติสำหรับการติดตั้งฟอนต์ Microsoft TrueType
   RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
   
   # ติดตั้งฟอนต์ Microsoft TrueType
   RUN apt-get update && \
       apt-get install -y ttf-mscorefonts-installer && \
       rm -rf /var/lib/apt/lists/*
   
   # ติดตั้ง Tomcat - ใช้เวอร์ชัน 9.0.93
   RUN wget https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.93/bin/apache-tomcat-9.0.93.tar.gz -O /tmp/tomcat.tar.gz && \
       tar xzf /tmp/tomcat.tar.gz -C /opt/ && \
       mv /opt/apache-tomcat-9.0.93 /opt/tomcat && \
       rm /tmp/tomcat.tar.gz
   
   # ติดตั้ง PHP/Java Bridge
   RUN curl -L http://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download -o /tmp/php-java-bridge.zip && \
       unzip /tmp/php-java-bridge.zip -d /tmp/php-java-bridge && \
       mkdir -p /opt/tomcat/webapps/JavaBridge && \
       cp /tmp/php-java-bridge/JavaBridge.war /opt/tomcat/webapps/JavaBridge && \
       cd /opt/tomcat/webapps/JavaBridge && \
       jar -xvf JavaBridge.war && \
       rm -rf /tmp/php-java-bridge.zip /tmp/php-java-bridge
   
   # ดาวน์โหลดและติดตั้ง Aspose.Slides สำหรับ PHP ผ่าน Java
   RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
       unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
       mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       mkdir -p /tmp/sample && \
       cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
       rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides
   
   # สร้างไฟล์ test.php
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
   
   # สร้างสคริปต์ entrypoint.sh
   RUN echo '#!/bin/bash\n\
   # เริ่ม Tomcat ในพื้นหลัง\n\
   catalina.sh start\n\
   # รอให้ Tomcat เริ่มอย่างสมบูรณ์\n\
   until curl -s http://localhost:8080 > /dev/null; do\n\
    sleep 2\n\
   done\n\
   echo "Running the PHP script..."\n\
   # เรียกใช้สคริปต์ PHP\n\
   php /tmp/sample/test.php\n\
   echo "PHP script completed, please check file /tmp/output.pdf."\n\
   # รักษาคอนเทนเนอร์ให้ทำงานต่อเนื่อง\n\
   echo "Keeping the container alive..."\n\
   tail -f /dev/null\n\
   ' > /tmp/entrypoint.sh
   
   # ให้สิทธิ์การทำงานกับสคริปต์อย่างชัดเจน
   RUN chmod 755 /tmp/entrypoint.sh
   
   # ตั้งค่า php.ini
   RUN echo "allow_url_include = On" >> /etc/php/7.4/cli/php.ini
   
   # ตั้งค่าตัวแปรสภาพแวดล้อมสำหรับ Tomcat
   ENV CATALINA_HOME /opt/tomcat
   ENV PATH $CATALINA_HOME/bin:$PATH
   ENV PHP_CLASSPATH /opt/aspose-slides/lib
   
   # เปิดพอร์ต 8080 สำหรับ Tomcat และพอร์ต 9000 สำหรับ PHP/Java Bridge
   EXPOSE 8080
   EXPOSE 9000
   
   # ตั้งค่าไดเรกทอรีทำงาน
   WORKDIR /tmp
   
   # เริ่ม Tomcat เมื่อคอนเทนเนอร์เริ่มทำงาน
   ENTRYPOINT ["/tmp/entrypoint.sh"]
   ```

### **2. สร้าง Docker Image** 
   เรียกใช้คำสั่งต่อไปนี้ในไดเรกทอรีที่มี Dockerfile ของคุณเพื่อสร้าง Docker Image:
   ```bash
   docker build -t aspose-slides-php-java .
   ```

### **3. เรียกใช้ Docker Container** 
   เมื่อตัวภาพถูกสร้างแล้ว ให้เรียกใช้คอนเทนเนอร์:
   ```bash
   docker run -p 8080:8080 aspose-slides-php-java
   ```

### 4. **เข้าถึง Aspose.Slides ใน Docker** 
   หลังจากเริ่มคอนเทนเนอร์ สคริปต์จะสร้างไฟล์ PDF คุณสามารถค้นหาไฟล์ผลลัพธ์ที่สร้างขึ้น `output.pdf` ในโฟลเดอร์ `/tmp` ภายในคอนเทนเนอร์:
   ```bash
   docker exec -it <container-id> ls /tmp
   ```
   เพื่อคัดลอกไฟล์ PDF ที่สร้างขึ้นไปยังเครื่องของคุณ ให้เรียกใช้คำสั่งต่อไปนี้:
   ```bash
   docker cp <container-id>:/tmp/output.pdf ./output.pdf
   ```