---
title: Docker에서 Aspose.Slides for Java 실행 방법
type: docs
weight: 75
url: /ko/java/how-to-run-aspose-slides-in-docker/
keywords:
- Aspose.Slides 다운로드
- Aspose.Slides 설치
- Aspose.Slides 설치
- Docker
- Windows
- macOS
- Linux
- 크로스 플랫폼 호환성
- 종속성 격리
- 배포 간소화
- 프로젝트 설정
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Docker 컨테이너에서 Aspose.Slides 실행: 이미지, 종속성, 글꼴 및 라이선스를 구성하여 PowerPoint와 OpenDocument를 처리하는 확장 가능한 서비스를 구축합니다."
---
## **소개**

이 가이드는 Aspose Slides와 Docker를 사용하여 Java 애플리케이션을 컨테이너화하는 방법을 설명합니다. 주요 이점은 다음과 같습니다.

- **크로스 플랫폼 호환성** - Windows, macOS 및 Linux에서 실행됩니다.
- **종속성 격리** - 시스템 전체에 설치할 필요가 없습니다.
- **배포 간소화** - 쉽게 공유하고 실행할 수 있습니다.

## **1. Docker 설치**

### **Windows**

**요구 사항:**

- WSL 2가 활성화된 Windows 10/11 Pro/Enterprise/Education (64비트)
- Home 에디션의 경우: 수동으로 WSL 2를 설치해야 합니다.

**단계:**

1. [Docker Desktop for Windows](https://www.docker.com/products/docker-desktop/)를 다운로드합니다.
2. 설치 프로그램을 실행하고 설정 마법사를 따릅니다.
3. 요청 시 컴퓨터를 재시작합니다.
4. 설치를 확인합니다:
   ```powershell
   docker --version
   ```

### **macOS**

**요구 사항:**

- macOS 10.15 (Catalina) 이상
- Apple Silicon 또는 Intel 프로세서

**단계:**

1. [Docker Desktop for Mac](https://www.docker.com/products/docker-desktop/)를 다운로드합니다.
2. 애플리케이션을 `Applications` 폴더로 끌어다 놓습니다.
3. Docker를 실행하고 초기화를 기다립니다.
4. 설치를 확인합니다:
   ```bash
   docker --version
   ```

### **Linux (Ubuntu/Debian)**

**설치:**

```bash
# 패키지 목록 업데이트
sudo apt update && sudo apt upgrade -y

# 필수 패키지 설치
sudo apt install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    software-properties-common

# Docker 공식 GPG 키 추가
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

# 안정적인 저장소 추가
echo "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# Docker Engine 설치
sudo apt update
sudo apt install -y docker-ce docker-ce-cli containerd.io

# 현재 사용자가 Docker 명령을 실행하도록 허용
sudo usermod -aG docker $USER
newgrp docker

# 설치 확인
docker --version
```

## **2. Dockerfile 구성**

### **기본 이미지**

```dockerfile
FROM ubuntu:24.04
```
> **참고**: Docker Hub에서 제공하는 [official Ubuntu image](https://hub.docker.com/_/ubuntu)를 사용합니다.

### **종속성**

```dockerfile
RUN apt-get install -y openjdk-11-jdk wget fontconfig ttf-mscorefonts-installer
```
- **OpenJDK 11**: Java 런타임 환경
- **Font packages**: Microsoft Core Fonts 포함

### **Aspose.Slides 설정**

```dockerfile
ENV ASPOSE_VERSION=25.3

ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}
```
- Aspose Slides 라이브러리를 버전 고정으로 다운로드

## **3. 프로젝트 설정**

### **파일 구조**

```
aspose-docker/
├── Dockerfile          # 컨테이너 구성
├── TestAspose.java     # 애플리케이션 코드
└── output/             # 생성된 PDF가 포함된 폴더 (자동 생성)
```

### **Dockerfile**

`Dockerfile`이라는 파일을 다음 내용으로 생성합니다:
```dockerfile
FROM ubuntu:24.04

# 환경 변수 설정
ENV JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64
ENV PATH=$JAVA_HOME/bin:$PATH
ENV APP_DIR=/tmp
ENV ASPOSE_VERSION=25.3
ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}

# 작업 디렉터리 생성
RUN mkdir -p ${APP_DIR}
WORKDIR ${APP_DIR}

# 종속성 설치
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jdk \
    wget \
    fontconfig \
    ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# 글꼴 구성
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections && \
    apt-get update && \
    apt-get install -y --no-install-recommends ttf-mscorefonts-installer && \
    fc-cache -f -v

# /tmp에 Aspose.Slides 다운로드
RUN wget ${ASPOSE_URL} -O ${APP_DIR}/${ASPOSE_JAR}

# 소스 코드 복사
COPY TestAspose.java ${APP_DIR}/

# 실행 스크립트 생성
RUN echo '#!/bin/bash' > ${APP_DIR}/run.sh && \
    echo 'java --add-opens=java.desktop/sun.java2d=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.awt.image=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.font=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     -cp ".:'"${ASPOSE_JAR}"'" TestAspose' >> ${APP_DIR}/run.sh && \
    chmod +x ${APP_DIR}/run.sh

# 스크립트에 실행 권한을 명시적으로 부여
RUN chmod 755 ${APP_DIR}/run.sh

# Java 코드 컴파일
RUN javac -cp "${APP_DIR}/${ASPOSE_JAR}" ${APP_DIR}/TestAspose.java

# 작업 디렉터리 설정
WORKDIR /tmp

CMD ["sh", "-c", "/tmp/run.sh && cp /tmp/output/output.pdf /output"]
```

### **Java 애플리케이션**

`TestAspose.java` 파일을 다음 내용으로 생성합니다:
```java
import com.aspose.slides.*;

public class TestAspose {
    public static void main(String[] args) throws Exception {
        System.out.println("Creating presentation...");
        
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 190, 300, 25);
            autoShape.getTextFrame().setText("Greetings from Docker!");
            
            presentation.save("/tmp/output/output.pdf", SaveFormat.Pdf);
        } finally {
            if (presentation != null) presentation.dispose();
        }
        System.out.println("Presentation saved as output.pdf");
    }
}
```

## **4. 빌드 및 실행**

### **이미지 빌드**

Dockerfile이 위치한 디렉터리에서 다음 명령을 실행하여 Docker 이미지를 빌드합니다:
```powershell
   docker build -t aspose-test .
   ```

- `-t` 옵션은 이미지 이름을 "aspose-test"로 지정합니다.
- `.` 은 현재 디렉터리의 Dockerfile을 사용합니다.

### **컨테이너 실행**

Dockerfile이 위치한 디렉터리에서 다음 명령을 실행하여 Docker 컨테이너를 실행합니다:
```powershell
   docker run -v "$(pwd)/output:/output" aspose-test
   ```

- `-v` 옵션은 출력 디렉터리를 마운트합니다.
- 로컬 `output` 폴더에 `output.pdf`가 생성됩니다.