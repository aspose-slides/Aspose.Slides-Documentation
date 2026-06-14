---
title: 如何在 Docker 中執行 Aspose.Slides for Java
type: docs
weight: 75
url: /zh-hant/java/how-to-run-aspose-slides-in-docker/
keywords:
- 下載 Aspose.Slides
- 安裝 Aspose.Slides
- Aspose.Slides 安裝
- Docker
- Windows
- macOS
- Linux
- 跨平台相容性
- 相依性隔離
- 簡化部署
- 專案設定
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Docker 容器中執行 Aspose.Slides：配置映像、相依性、字型與授權，以建置可擴充的服務，處理 PowerPoint 與 OpenDocument。"
---
## **簡介**

本指南說明如何使用 Docker 將使用 Aspose Slides 的 Java 應用程式容器化。主要好處包括：

- **跨平台相容性** - 可在 Windows、macOS 與 Linux 上執行
- **依賴隔離** - 不需系統層面的安裝
- **簡化部署** - 易於分享與執行

## **1. Docker 安裝**

### **Windows**

**需求：**

- Windows 10/11 Pro/Enterprise/Education（64 位）並已啟用 WSL 2
- Home 版：需要手動安裝 WSL 2

**步驟：**

1. 下載 [Docker Desktop for Windows](https://www.docker.com/products/docker-desktop/)
2. 執行安裝程式並依照設定精靈操作
3. 系統提示時重新啟動電腦
4. 驗證安裝：
   ```powershell
   docker --version
   ```

### **macOS**

**需求：**

- macOS 10.15（Catalina）或更新版本
- Apple Silicon 或 Intel 處理器

**步驟：**

1. 下載 [Docker Desktop for Mac](https://www.docker.com/products/docker-desktop/)
2. 將程式拖曳至 `Applications` 資料夾
3. 啟動 Docker 並等待初始化完成
4. 驗證安裝：
   ```bash
   docker --version
   ```

### **Linux（Ubuntu/Debian）**

**安裝步驟：**

```bash
# 更新套件清單
sudo apt update && sudo apt upgrade -y

# 安裝先決條件
sudo apt install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    software-properties-common

# 加入 Docker 官方 GPG 金鑰
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

# 加入穩定的套件庫
echo "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# 安裝 Docker 引擎
sudo apt update
sudo apt install -y docker-ce docker-ce-cli containerd.io

# 允許目前使用者執行 Docker 命令
sudo usermod -aG docker $USER
newgrp docker

# 驗證安裝
docker --version
```

## **2. Dockerfile 組態**

### **基礎映像**

```dockerfile
FROM ubuntu:24.04
```
> **注意**：使用 Docker Hub 上的[官方 Ubuntu 映像](https://hub.docker.com/_/ubuntu)。

### **相依性**

```dockerfile
RUN apt-get install -y openjdk-11-jdk wget fontconfig ttf-mscorefonts-installer
```
- **OpenJDK 11**：Java 執行環境
- **字型套件**：包含 Microsoft Core Fonts

### **Aspose.Slides 設定**

```dockerfile
ENV ASPOSE_VERSION=25.3

ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}
```
- 下載固定版本的 Aspose Slides 函式庫

## **3. 專案設定**

### **檔案結構**

```
aspose-docker/
├── Dockerfile          # 容器設定
├── TestAspose.java     # 應用程式程式碼
└── output/             # 含已產生 PDF 的資料夾（自動建立）
```

### **Dockerfile**

建立名為 `Dockerfile` 的檔案，內容如下：
```dockerfile
FROM ubuntu:24.04

# 設定環境變數
ENV JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64
ENV PATH=$JAVA_HOME/bin:$PATH
ENV APP_DIR=/tmp
ENV ASPOSE_VERSION=25.3
ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}

# 建立工作目錄
RUN mkdir -p ${APP_DIR}
WORKDIR ${APP_DIR}

# 安裝相依性
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jdk \
    wget \
    fontconfig \
    ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# 設定字型
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections && \
    apt-get update && \
    apt-get install -y --no-install-recommends ttf-mscorefonts-installer && \
    fc-cache -f -v

# 下載 Aspose.Slides 至 /tmp
RUN wget ${ASPOSE_URL} -O ${APP_DIR}/${ASPOSE_JAR}

# 複製原始碼
COPY TestAspose.java ${APP_DIR}/

# 建立執行腳本
RUN echo '#!/bin/bash' > ${APP_DIR}/run.sh && \
    echo 'java --add-opens=java.desktop/sun.java2d=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.awt.image=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.font=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     -cp ".:'"${ASPOSE_JAR}"'" TestAspose' >> ${APP_DIR}/run.sh && \
    chmod +x ${APP_DIR}/run.sh

# 明確授予腳本執行權限
RUN chmod 755 ${APP_DIR}/run.sh

# 編譯 Java 程式碼
RUN javac -cp "${APP_DIR}/${ASPOSE_JAR}" ${APP_DIR}/TestAspose.java

# 設定工作目錄
WORKDIR /tmp

CMD ["sh", "-c", "/tmp/run.sh && cp /tmp/output/output.pdf /output"]
```

### **Java 應用程式**

建立 `TestAspose.java`，內容如下：
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

## **4. 建構與執行**

### **建構映像**

在 Dockerfile 所在目錄執行以下指令以建構 Docker 映像：
```powershell
   docker build -t aspose-test .
   ```

- `-t` 為映像指定名稱「aspose-test」
- `.` 使用目前目錄的 Dockerfile

### **執行容器**

在 Dockerfile 所在目錄執行以下指令以執行 Docker 容器：
```powershell
   docker run -v "$(pwd)/output:/output" aspose-test
   ```

- `-v` 掛載輸出目錄
- 於本地 `output` 資料夾產生 `output.pdf`