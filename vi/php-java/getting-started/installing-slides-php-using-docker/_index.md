---
title: Cài đặt Aspose.Slides cho PHP thông qua Java sử dụng Docker
type: docs
weight: 75
url: /vi/php-java/installing-slides-php-using-docker/
keywords:
- tải xuống Aspose.Slides
- cài đặt Aspose.Slides
- cài đặt Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- tương thích đa nền tảng
- cách ly phụ thuộc
- triển khai đơn giản hoá
- cài đặt dự án
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Chạy Aspose.Slides trong các container Docker: cấu hình hình ảnh, phụ thuộc, phông chữ và giấy phép để xây dựng các dịch vụ mở rộng quy mô xử lý PowerPoint và OpenDocument."
---
## **Yêu cầu trước**
* Cài đặt Docker trên máy của bạn. Bạn có thể tham khảo hướng dẫn cài đặt chính thức [tại đây](https://docs.docker.com/get-docker/).

## **Các bước**

### **1. Tạo Dockerfile** 
   Tạo một tệp mới có tên Dockerfile trong thư mục dự án của bạn với nội dung sau:
   ```
   # Hình ảnh cơ sở (hình ảnh Ubuntu chính thức)
   FROM ubuntu:20.04
   
   # Đặt múi giờ trước để tránh lựa chọn tương tác
   ENV DEBIAN_FRONTEND=noninteractive
   RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
       apt-get update && apt-get install -y tzdata && \
       dpkg-reconfigure --frontend noninteractive tzdata
   
   # Cài đặt các gói cần thiết và cập nhật danh sách gói
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
   
   # Tự động chấp nhận thỏa thuận giấy phép để cài đặt phông chữ Microsoft TrueType
   RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
   
   # Cài đặt phông chữ Microsoft TrueType
   RUN apt-get update && \
       apt-get install -y ttf-mscorefonts-installer && \
       rm -rf /var/lib/apt/lists/*
   
   # Cài đặt Tomcat - sử dụng phiên bản 9.0.93
   RUN wget https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.93/bin/apache-tomcat-9.0.93.tar.gz -O /tmp/tomcat.tar.gz && \
       tar xzf /tmp/tomcat.tar.gz -C /opt/ && \
       mv /opt/apache-tomcat-9.0.93 /opt/tomcat && \
       rm /tmp/tomcat.tar.gz
   
   # Cài đặt PHP/Java Bridge
   RUN curl -L http://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download -o /tmp/php-java-bridge.zip && \
       unzip /tmp/php-java-bridge.zip -d /tmp/php-java-bridge && \
       mkdir -p /opt/tomcat/webapps/JavaBridge && \
       cp /tmp/php-java-bridge/JavaBridge.war /opt/tomcat/webapps/JavaBridge && \
       cd /opt/tomcat/webapps/JavaBridge && \
       jar -xvf JavaBridge.war && \
       rm -rf /tmp/php-java-bridge.zip /tmp/php-java-bridge
   
   # Tải xuống và cài đặt Aspose.Slides cho PHP qua Java
   RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
       unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
       mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       mkdir -p /tmp/sample && \
       cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
       rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides
   
   # Tạo tệp test.php
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
   
   # Tạo script entrypoint.sh
   RUN echo '#!/bin/bash\n\
   # Khởi động Tomcat ở nền\n\
   catalina.sh start\n\
   # Đợi Tomcat khởi động hoàn toàn\n\
   until curl -s http://localhost:8080 > /dev/null; do\n\
    sleep 2\n\
   done\n\
   echo "Running the PHP script..."\n\
   # Chạy script PHP\n\
   php /tmp/sample/test.php\n\
   echo "PHP script completed, please check file /tmp/output.pdf."\n\
   # Giữ container hoạt động\n\
   echo "Keeping the container alive..."\n\
   tail -f /dev/null\n\
   ' > /tmp/entrypoint.sh
   
   # Cấp quyền thực thi cho script một cách rõ ràng
   RUN chmod 755 /tmp/entrypoint.sh
   
   # Cấu hình php.ini
   RUN echo "allow_url_include = On" >> /etc/php/7.4/cli/php.ini
   
   # Đặt biến môi trường cho Tomcat
   ENV CATALINA_HOME /opt/tomcat
   ENV PATH $CATALINA_HOME/bin:$PATH
   ENV PHP_CLASSPATH /opt/aspose-slides/lib
   
   # Mở cổng 8080 cho Tomcat và cổng 9000 cho PHP/Java Bridge
   EXPOSE 8080
   EXPOSE 9000
   
   # Đặt thư mục làm việc
   WORKDIR /tmp
   
   # Khởi động Tomcat khi container khởi chạy
   ENTRYPOINT ["/tmp/entrypoint.sh"]
```

### **2. Xây dựng hình ảnh Docker**
   Chạy lệnh sau trong thư mục chứa Dockerfile để xây dựng hình ảnh Docker:
   ```bash
   docker build -t aspose-slides-php-java .
   ```

### **3. Chạy container Docker**
   Khi hình ảnh đã được xây dựng, chạy container:
   ```bash
   docker run -p 8080:8080 aspose-slides-php-java
   ```

### 4. **Truy cập Aspose.Slides trong Docker** 
   Sau khi khởi động container, script sẽ tạo ra một tệp PDF. Bạn có thể tìm tệp đầu ra `output.pdf` trong thư mục `/tmp` bên trong container:
   ```bash
   docker exec -it <container-id> ls /tmp
   ```
   Để sao chép tệp PDF đã tạo về máy của bạn, chạy lệnh sau:
   ```bash
   docker cp <container-id>:/tmp/output.pdf ./output.pdf
   ```