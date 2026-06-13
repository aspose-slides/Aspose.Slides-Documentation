---
title: Docker를 사용하여 Java로 PHP용 Aspose.Slides 설치
type: docs
weight: 75
url: /ko/php-java/installing-slides-php-using-docker/
keywords:
- Aspose.Slides 다운로드
- Aspose.Slides 설치
- Aspose.Slides 설치 방법
- Docker
- Windows
- macOS
- Linux
- 크로스 플랫폼 호환성
- 종속성 격리
- 간소화된 배포
- 프로젝트 설정
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Docker 컨테이너에서 Aspose.Slides 실행: 이미지, 종속성, 폰트 및 라이선스를 구성하여 PowerPoint 및 OpenDocument를 처리하는 확장 가능한 서비스를 구축합니다."
---
## **전제 조건**
* 머신에 Docker를 설치하세요. 공식 설치 가이드를 [여기](https://docs.docker.com/get-docker/)에서 확인할 수 있습니다.

## **단계**

### **1. Dockerfile 만들기** 
   프로젝트 디렉터리에 Dockerfile이라는 새 파일을 만들고 다음 내용을 넣으세요:
   ```
   # 베이스 이미지 (공식 Ubuntu 이미지)
   FROM ubuntu:20.04
   
   # 인터랙티브 선택을 피하기 위해 사전에 시간대를 설정합니다
   ENV DEBIAN_FRONTEND=noninteractive
   RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
       apt-get update && apt-get install -y tzdata && \
       dpkg-reconfigure --frontend noninteractive tzdata
   
   # 필요한 패키지를 설치하고 패키지 목록을 업데이트합니다
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
   
   # Microsoft TrueType 글꼴 설치를 위한 라이선스 동의를 자동으로 수락합니다
   RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
   
   # Microsoft TrueType 글꼴 설치
   RUN apt-get update && \
       apt-get install -y ttf-mscorefonts-installer && \
       rm -rf /var/lib/apt/lists/*
   
   # Tomcat 설치 - 버전 9.0.93 사용
   RUN wget https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.93/bin/apache-tomcat-9.0.93.tar.gz -O /tmp/tomcat.tar.gz && \
       tar xzf /tmp/tomcat.tar.gz -C /opt/ && \
       mv /opt/apache-tomcat-9.0.93 /opt/tomcat && \
       rm /tmp/tomcat.tar.gz
   
   # PHP/Java Bridge 설치
   RUN curl -L http://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download -o /tmp/php-java-bridge.zip && \
       unzip /tmp/php-java-bridge.zip -d /tmp/php-java-bridge && \
       mkdir -p /opt/tomcat/webapps/JavaBridge && \
       cp /tmp/php-java-bridge/JavaBridge.war /opt/tomcat/webapps/JavaBridge && \
       cd /opt/tomcat/webapps/JavaBridge && \
       jar -xvf JavaBridge.war && \
       rm -rf /tmp/php-java-bridge.zip /tmp/php-java-bridge
   
   # Aspose.Slides for PHP via Java 다운로드 및 설치
   RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
       unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
       mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       mkdir -p /tmp/sample && \
       cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
       rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides
   
   # test.php 파일 생성
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
   
   # entrypoint.sh 스크립트 생성
   RUN echo '#!/bin/bash\n\
   # Tomcat을 백그라운드에서 시작합니다\n\
   catalina.sh start\n\
   # Tomcat이 완전히 시작될 때까지 기다립니다\n\
   until curl -s http://localhost:8080 > /dev/null; do\n\
    sleep 2\n\
   done\n\
   echo "Running the PHP script..."\n\
   # PHP 스크립트를 실행합니다\n\
   php /tmp/sample/test.php\n\
   echo "PHP script completed, please check file /tmp/output.pdf."\n\
   # 컨테이너를 유지합니다\n\
   echo "Keeping the container alive..."\n\
   # 컨테이너를 유지합니다...\n\
   tail -f /dev/null\n\
   ' > /tmp/entrypoint.sh
   
   # 스크립트에 실행 권한을 명시적으로 부여합니다
   RUN chmod 755 /tmp/entrypoint.sh
   
   # php.ini 구성
   RUN echo "allow_url_include = On" >> /etc/php/7.4/cli/php.ini
   
   # Tomcat용 환경 변수를 설정합니다
   ENV CATALINA_HOME /opt/tomcat
   ENV PATH $CATALINA_HOME/bin:$PATH
   ENV PHP_CLASSPATH /opt/aspose-slides/lib
   
   # Tomcat용 포트 8080과 PHP/Java Bridge용 포트 9000을 노출합니다
   EXPOSE 8080
   EXPOSE 9000
   
   # 작업 디렉터리를 설정합니다
   WORKDIR /tmp
   
   # 컨테이너 시작 시 Tomcat을 시작합니다
   ENTRYPOINT ["/tmp/entrypoint.sh"]
   ```

### **2. Docker 이미지 빌드**
   Dockerfile이 있는 디렉터리에서 다음 명령을 실행하여 Docker 이미지를 빌드합니다:
   ```bash
   docker build -t aspose-slides-php-java .
   ```

### **3. Docker 컨테이너 실행**
   이미지가 빌드되면 컨테이너를 실행합니다:
   ```bash
   docker run -p 8080:8080 aspose-slides-php-java
   ```

### 4. **Docker에서 Aspose.Slides 사용** 
   컨테이너를 시작하면 스크립트가 PDF 파일을 생성합니다. 생성된 출력 파일 `output.pdf`는 컨테이너 내부의 `/tmp` 폴더에서 찾을 수 있습니다:
   ```bash
   docker exec -it <container-id> ls /tmp
   ```
   생성된 PDF 파일을 로컬 머신으로 복사하려면 다음 명령을 실행하세요:
   ```bash
   docker cp <container-id>:/tmp/output.pdf ./output.pdf
   ```