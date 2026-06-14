---
title: 使用 Docker 於 PHP 透過 Java 安裝 Aspose.Slides
type: docs
weight: 75
url: /zh-hant/php-java/installing-slides-php-using-docker/
keywords:
- 下載 Aspose.Slides
- 安裝 Aspose.Slides
- Aspose.Slides 安裝
- Docker
- Windows
- macOS
- Linux
- 跨平台相容性
- 依賴隔離
- 簡化部署
- 專案設定
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在 Docker 容器中執行 Aspose.Slides：配置映像、相依項、字型與授權，以建立可擴展的服務，處理 PowerPoint 與 OpenDocument。"
---
## **先決條件**
* 在您的機器上安裝 Docker。您可以參考官方安裝指南[此處](https://docs.docker.com/get-docker/)。

## **步驟**

### **1. 建立 Dockerfile** 
   在您的專案目錄中建立一個名為 Dockerfile 的新檔案，內容如下：
   ```dockerfile
   # 基礎映像（官方 Ubuntu 映像）
   FROM ubuntu:20.04
   
   # 設定時區以避免互動式選擇
   ENV DEBIAN_FRONTEND=noninteractive
   RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
       apt-get update && apt-get install -y tzdata && \
       dpkg-reconfigure --frontend noninteractive tzdata
   
   # 安裝必要的套件並更新套件清單
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
   
   # 自動接受安裝 Microsoft TrueType 字型的授權協議
   RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
   
   # 安裝 Microsoft TrueType 字型
   RUN apt-get update && \
       apt-get install -y ttf-mscorefonts-installer && \
       rm -rf /var/lib/apt/lists/*
   
   # 安裝 Tomcat - 使用版本 9.0.93
   RUN wget https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.93/bin/apache-tomcat-9.0.93.tar.gz -O /tmp/tomcat.tar.gz && \
       tar xzf /tmp/tomcat.tar.gz -C /opt/ && \
       mv /opt/apache-tomcat-9.0.93 /opt/tomcat && \
       rm /tmp/tomcat.tar.gz
   
   # 安裝 PHP/Java Bridge
   RUN curl -L http://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download -o /tmp/php-java-bridge.zip && \
       unzip /tmp/php-java-bridge.zip -d /tmp/php-java-bridge && \
       mkdir -p /opt/tomcat/webapps/JavaBridge && \
       cp /tmp/php-java-bridge/JavaBridge.war /opt/tomcat/webapps/JavaBridge && \
       cd /opt/tomcat/webapps/JavaBridge && \
       jar -xvf JavaBridge.war && \
       rm -rf /tmp/php-java-bridge.zip /tmp/php-java-bridge
   
   # 下載並安裝 Aspose.Slides for PHP via Java
   RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
       unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
       mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       mkdir -p /tmp/sample && \
       cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
       rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides
   
   # 建立 test.php 檔案
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
   
   # 建立 entrypoint.sh 腳本
   RUN echo '#!/bin/bash\n\
   # 在背景啟動 Tomcat\n\
   catalina.sh start\n\
   # 等待 Tomcat 完全啟動\n\
   until curl -s http://localhost:8080 > /dev/null; do\n\
    sleep 2\n\
   done\n\
   echo "Running the PHP script..."\n\
   # 執行 PHP 腳本\n\
   php /tmp/sample/test.php\n\
   echo "PHP script completed, please check file /tmp/output.pdf."\n\
   # 保持容器運行\n\
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

### **2. 建構 Docker 映像**
   在 Dockerfile 所在的目錄中執行以下指令以建構 Docker 映像：
   ```bash
   docker build -t aspose-slides-php-java .
   ```

### **3. 執行 Docker 容器**
   映像建構完成後，執行容器：
   ```bash
   docker run -p 8080:8080 aspose-slides-php-java
   ```

### 4. **在 Docker 中存取 Aspose.Slides** 
   啟動容器後，腳本會產生 PDF 檔案。您可以在容器內的 `/tmp` 資料夾中找到產生的輸出檔案 `output.pdf`：
   ```bash
   docker exec -it <container-id> ls /tmp
   ```
   若要將產生的 PDF 檔案複製到本機，請執行以下指令：
   ```bash
   docker cp <container-id>:/tmp/output.pdf ./output.pdf
   ```