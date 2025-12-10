---
title: 如何在 Docker 中运行 Aspose.Slides for Java
type: docs
weight: 75
url: /zh/java/how-to-run-aspose-slides-in-docker/
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
- Java
- Aspose.Slides
description: "在 Docker 容器中运行 Aspose.Slides：配置镜像、依赖、字体和许可，以构建可扩展的服务，处理 PowerPoint 和 OpenDocument。"
---

## **介绍**

本指南解释如何使用 Aspose Slides 与 Docker 将 Java 应用程序容器化。主要优势包括：

- **跨平台兼容性** - 在 Windows、macOS 和 Linux 上运行
- **依赖隔离** - 无需系统范围的安装
- **简化部署** - 轻松共享和执行

## **1. Docker 安装**

### **Windows**

**要求：**

- Windows 10/11 Pro/Enterprise/Education（64 位）并启用 WSL 2
- 对于 Home 版：需要手动安装 WSL 2

**步骤：**

1. 下载 [Docker Desktop for Windows](https://www.docker.com/products/docker-desktop/)
2. 运行安装程序并按照设置向导操作
3. 出现提示时重启计算机
4. 验证安装：
   ```powershell
   docker --version
   ```


### **macOS**

**要求：**

- macOS 10.15（Catalina）或更高版本
- Apple Silicon 或 Intel 处理器

**步骤：**

1. 下载 [Docker Desktop for Mac](https://www.docker.com/products/docker-desktop/)
2. 将应用程序拖动到 `Applications` 文件夹
3. 启动 Docker 并等待初始化
4. 验证安装：
   ```bash
   docker --version
   ```


### **Linux (Ubuntu/Debian)**

**安装：**
```bash
# 更新软件包列表
sudo apt update && sudo apt upgrade -y

# 安装前置依赖
sudo apt install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    software-properties-common

# 添加 Docker 官方 GPG 密钥
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

# 添加稳定版仓库
echo "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# 安装 Docker 引擎
sudo apt update
sudo apt install -y docker-ce docker-ce-cli containerd.io

# 允许当前用户运行 Docker 命令
sudo usermod -aG docker $USER
newgrp docker

# 验证安装
docker --version
```


## **2. Dockerfile 配置**

### **基础镜像**
```dockerfile
FROM ubuntu:24.04
```

> **注意**：使用来自 Docker Hub 的 [官方 Ubuntu 镜像](https://hub.docker.com/_/ubuntu)。

### **依赖项**
```dockerfile
RUN apt-get install -y openjdk-11-jdk wget fontconfig ttf-mscorefonts-installer
```

- **OpenJDK 11**：Java 运行时环境
- **字体包**：包含 Microsoft Core 字体

### **Aspose.Slides 设置**
```dockerfile
ENV ASPOSE_VERSION=25.3

ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}
```

- 固定版本下载 Aspose Slides 库

## **3. 项目设置**

### **文件结构**
```
aspose-docker/
├── Dockerfile          # 容器配置
├── TestAspose.java     # 应用程序代码
└── output/             # 包含生成的 PDF 的文件夹（自动创建）
```


### **Dockerfile**

创建一个名为 `Dockerfile` 的文件，内容如下：
```dockerfile
FROM ubuntu:24.04

# 设置环境变量
ENV JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64
ENV PATH=$JAVA_HOME/bin:$PATH
ENV APP_DIR=/tmp
ENV ASPOSE_VERSION=25.3
ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}

# 创建工作目录
RUN mkdir -p ${APP_DIR}
WORKDIR ${APP_DIR}

# 安装依赖
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jdk \
    wget \
    fontconfig \
    ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# 配置字体
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections && \
    apt-get update && \
    apt-get install -y --no-install-recommends ttf-mscorefonts-installer && \
    fc-cache -f -v

# 下载 Aspose.Slides 到 /tmp
RUN wget ${ASPOSE_URL} -O ${APP_DIR}/${ASPOSE_JAR}

# 复制源代码
COPY TestAspose.java ${APP_DIR}/

# 创建运行脚本
RUN echo '#!/bin/bash' > ${APP_DIR}/run.sh && \
    echo 'java --add-opens=java.desktop/sun.java2d=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.awt.image=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.font=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     -cp ".:'"${ASPOSE_JAR}"'" TestAspose' >> ${APP_DIR}/run.sh && \
    chmod +x ${APP_DIR}/run.sh

# 明确授予脚本执行权限
RUN chmod 755 ${APP_DIR}/run.sh

# 编译 Java 代码
RUN javac -cp "${APP_DIR}/${ASPOSE_JAR}" ${APP_DIR}/TestAspose.java

# 设置工作目录
WORKDIR /tmp

CMD ["sh", "-c", "/tmp/run.sh && cp /tmp/output/output.pdf /output"]
```


### **Java 应用程序**

创建 `TestAspose.java`，内容如下：
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


## **4. 构建与运行**

### **构建镜像**

在 Dockerfile 所在目录运行以下命令以构建 Docker 镜像：
   ```powershell
   docker build -t aspose-test .
   ```

- `-t` 为镜像命名为 "aspose-test"
- `.` 使用当前目录的 Dockerfile

### **运行容器**

在 Dockerfile 所在目录运行以下命令以运行 Docker 容器：
   ```powershell
   docker run -v "$(pwd)/output:/output" aspose-test
   ```

- `-v` 挂载输出目录
- 在本地 `output` 文件夹中创建 `output.pdf`