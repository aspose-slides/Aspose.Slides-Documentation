---
title: 使用 Docker 通过 Java 为 PHP 安装 Aspose.Slides
type: docs
weight: 75
url: /zh/php-java/installing-slides-php-using-docker/
keywords:
- 下载 Aspose.Slides
- 安装 Aspose.Slides
- Aspose.Slides 安装
- Docker
- Windows
- macOS
- Linux
- 跨平台兼容性
- 依赖隔离
- 简化部署
- 项目设置
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "在 Docker 容器中运行 Aspose.Slides：配置镜像、依赖、字体和授权，以构建可扩展的服务，处理 PowerPoint 和 OpenDocument。"
---

## **先决条件**
* 在您的机器上安装 Docker。您可以按照官方安装指南[此处](https://docs.docker.com/get-docker/)。

## **步骤**

### **1. 创建 Dockerfile** 
   在项目目录中创建一个名为 Dockerfile 的新文件，内容如下：
   ```
   # 基础镜像（官方 Ubuntu 镜像）
   FROM ubuntu:20.04
   
   # 提前设置时区以避免交互式选择
   ENV DEBIAN_FRONTEND=noninteractive
   RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
       apt-get update && apt-get install -y tzdata && \
       dpkg-reconfigure --frontend noninteractive tzdata
   
   # 安装必要的软件包并更新软件列表
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
   
   # 自动接受安装 Microsoft TrueType 字体的许可证协议
   RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
   
   # 安装 Microsoft TrueType 字体
   RUN apt-get update && \
       apt-get install -y ttf-mscorefonts-installer && \
       rm -rf /var/lib/apt/lists/*
   
   # 安装 Tomcat - 使用版本 9.0.93
   RUN wget https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.93/bin/apache-tomcat-9.0.93.tar.gz -O /tmp/tomcat.tar.gz && \
       tar xzf /tmp/tomcat.tar.gz -C /opt/ && \
       mv /opt/apache-tomcat-9.0.93 /opt/tomcat && \
       rm /tmp/tomcat.tar.gz
   
   # 安装 PHP/Java Bridge
   RUN curl -L http://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download -o /tmp/php-java-bridge.zip && \
       unzip /tmp/php-java-bridge.zip -d /tmp/php-java-bridge && \
       mkdir -p /opt/tomcat/webapps/JavaBridge && \
       cp /tmp/php-java-bridge/JavaBridge.war /opt/tomcat/webapps/JavaBridge && \
       cd /opt/tomcat/webapps/JavaBridge && \
       jar -xvf JavaBridge.war && \
       rm -rf /tmp/php-java-bridge.zip /tmp/php-java-bridge
   
   # 下载并安装 Aspose.Slides for PHP via Java
   RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
       unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
       mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       mkdir -p /tmp/sample && \
       cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
       rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides
   
   # 创建 test.php 文件
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
   
   # 创建 entrypoint.sh 脚本
   RUN echo '#!/bin/bash\n\
   # 在后台启动 Tomcat\n\
   catalina.sh start\n\
   # 等待 Tomcat 完全启动\n\
   until curl -s http://localhost:8080 > /dev/null; do\n\
    sleep 2\n\
   done\n\
   echo "Running the PHP script..."\n\
   # 运行 PHP 脚本\n\
   php /tmp/sample/test.php\n\
   echo "PHP script completed, please check file /tmp/output.pdf."\n\
   # 保持容器运行\n\
   echo "Keeping the container alive..."\n\
   tail -f /dev/null\n\
   ' > /tmp/entrypoint.sh
   
   # 显式授予脚本执行权限
   RUN chmod 755 /tmp/entrypoint.sh
   
   # 配置 php.ini
   RUN echo "allow_url_include = On" >> /etc/php/7.4/cli/php.ini
   
   # 为 Tomcat 设置环境变量
   ENV CATALINA_HOME /opt/tomcat
   ENV PATH $CATALINA_HOME/bin:$PATH
   ENV PHP_CLASSPATH /opt/aspose-slides/lib
   
   # 为 Tomcat 暴露 8080 端口，为 PHP/Java Bridge 暴露 9000 端口
   EXPOSE 8080
   EXPOSE 9000
   
   # 设置工作目录
   WORKDIR /tmp
   
   # 容器启动时启动 Tomcat
   ENTRYPOINT ["/tmp/entrypoint.sh"]
   ```


### **2. 构建 Docker 镜像**
   在 Dockerfile 所在的目录中运行以下命令以构建 Docker 镜像：
```bash
docker build -t aspose-slides-php-java .
```


### **3. 运行 Docker 容器**
   镜像构建完成后，运行容器：
```bash
docker run -p 8080:8080 aspose-slides-php-java
```


### 4. **在 Docker 中访问 Aspose.Slides** 
   启动容器后，脚本将生成一个 PDF 文件。您可以在容器内的 `/tmp` 文件夹中找到生成的输出文件 `output.pdf`：
```bash
docker exec -it <container-id> ls /tmp
```

   要将生成的 PDF 文件复制到本地机器，请运行以下命令：
```bash
docker cp <container-id>:/tmp/output.pdf ./output.pdf
```
