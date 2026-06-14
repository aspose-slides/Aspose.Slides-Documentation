---
title: 使用 Docker 透過 Java 為 Node.js 安裝 Aspose.Slides
type: docs
weight: 75
url: /zh-hant/nodejs-java/installing-slides-nodejs-using-docker/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Docker 容器中執行 Aspose.Slides：設定映像檔、相依性、字型與授權，以建立可擴充的服務，處理 PowerPoint 與 OpenDocument。"
---
## 先決條件：
* 在您的機器上安裝 Docker。您可以遵循官方安裝指南[此處](https://docs.docker.com/get-docker/)。

## 步驟：

### 1. **建立 Dockerfile** 
   在您的專案目錄中建立一個名為 Dockerfile 的新檔案，內容如下：
   ```
   # 使用 Ubuntu 20.04 作為基礎映像
   FROM ubuntu:20.04

   # 更新套件清單並安裝添加套件庫與下載檔案所需的基本套件
   RUN apt-get update && \
      apt-get install -y curl gnupg2 software-properties-common && \
      rm -rf /var/lib/apt/lists/*

   # 從 Nodesource 套件庫安裝 Node.js 18.x 版
   RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash - && \
      apt-get install -y nodejs && \
      rm -rf /var/lib/apt/lists/*

   # 安裝 Python 2.x，某些 npm 套件如 node-gyp 需要它
   RUN apt-get update && \
      apt-get install -y python2 && \
      rm -rf /var/lib/apt/lists/*

   # 安裝 OpenJDK 11，Aspose.Slides 的 Java 相依性需要它
   RUN apt-get update && \
      apt-get install -y openjdk-11-jdk && \
      rm -rf /var/lib/apt/lists/*

   # 安裝 build-essential 套件，內含建置原生模組所需的 'make' 等工具
   RUN apt-get update && \
      apt-get install -y build-essential && \
      rm -rf /var/lib/apt/lists/*

   # 全域安裝 node-gyp，這是一個用於編譯 Node.js 原生擴充的工具
   RUN npm install -g node-gyp

   # 設定容器內的工作目錄為 /app
   WORKDIR /app

   # 建立包含必要資訊與相依性的 package.json 檔案
   RUN echo '{\n\
     "name": "aspose-slides-app",\n\
     "version": "1.0.0",\n\
     "main": "index.js",\n\
     "scripts": {\n\
      "start": "node index.js"\n\
     },\n\
     "dependencies": {\n\
      "aspose.slides.via.java": "^25.12.0"\n\
     }\n\
   }' > package.json

   # 建立 index.js 檔案，內含使用 Aspose.Slides 建立簡報的範例程式碼
   RUN echo 'const slides = require("aspose.slides.via.java");\n\
   var presentation = new slides.Presentation();\n\
   var slide = presentation.getSlides().get_Item(0);\n\
   slide.getShapes().addAutoShape(slides.ShapeType.Line, 50, 150, 300, 0);\n\
   presentation.save("./NewPresentation.pptx", slides.SaveFormat.Pptx);\n\
   console.log("Script completed, please check file /app/NewPresentation.pptx!");' > index.js

   # 安裝 package.json 中指定的 Aspose.Slides via Java 套件
   RUN npm install aspose.slides.via.java

   # 設定容器啟動時執行應用程式的預設指令
   CMD ["node", "index.js"]
```

### 2. **建置 Docker 映像檔**
   在 Dockerfile 所在的目錄執行以下指令，以建置 Docker 映像檔：
   ```bash
   docker build -t aspose-slides-nodejs .
```

### 3. **執行 Docker 容器**
   執行容器並保存其 ID：
   ```bash
   CONTAINER_ID=$(docker create aspose-slides-nodejs)
   docker start -a $CONTAINER_ID
   ```

### 4. **在 Docker 中存取 Aspose.Slides** 
   容器啟動後，腳本會產生 PPTX 檔案。您可以在容器內的 `/app` 資料夾中找到產生的輸出檔案 `NewPresentation.pptx`：
   ```bash
   docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
   ```
   移除臨時容器：
   ```bash
   docker rm $CONTAINER_ID
   ```