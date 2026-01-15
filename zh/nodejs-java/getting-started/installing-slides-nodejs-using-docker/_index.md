---
title: 通过 Java 使用 Docker 安装 Aspose.Slides for Node.js
type: docs
weight: 75
url: /zh/nodejs-java/installing-slides-nodejs-using-docker/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Docker 容器中运行 Aspose.Slides：配置镜像、依赖、字体和授权，以构建可扩展的服务，处理 PowerPoint 与 OpenDocument。"
---

## 前置条件：
* 在您的机器上安装 Docker。您可以遵循官方安装指南[here](https://docs.docker.com/get-docker/)。

## 步骤：

### 1. **创建 Dockerfile** 
   在项目目录中创建一个名为 Dockerfile 的新文件，内容如下：
   ```
   # 使用 Ubuntu 20.04 作为基础镜像
   FROM ubuntu:20.04

   # 更新软件包列表并安装添加仓库和下载文件所需的基本软件包
   RUN apt-get update && \
      apt-get install -y curl gnupg2 software-properties-common && \
      rm -rf /var/lib/apt/lists/*

   # 从 Nodesource 仓库安装 Node.js 18.x 版本
   RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash - && \
      apt-get install -y nodejs && \
      rm -rf /var/lib/apt/lists/*

   # 安装 Python 2.x，它是某些 npm 包（如 node-gyp）所需的
   RUN apt-get update && \
      apt-get install -y python2 && \
      rm -rf /var/lib/apt/lists/*

   # 安装 OpenJDK 11，它是 Aspose.Slides 所需的 Java 依赖项
   RUN apt-get update && \
      apt-get install -y openjdk-11-jdk && \
      rm -rf /var/lib/apt/lists/*

   # 安装 build-essential 包，其中包括构建本机模块所需的 'make' 等工具
   RUN apt-get update && \
      apt-get install -y build-essential && \
      rm -rf /var/lib/apt/lists/*

   # 全局安装 node-gyp，这是一款用于编译 Node.js 本机插件的工具
   RUN npm install -g node-gyp

   # 将容器内的工作目录设置为 /app
   WORKDIR /app

   # 创建包含必要细节和依赖项的 package.json 文件
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

   # 创建 index.js 文件，示例代码用于使用 Aspose.Slides 创建演示文稿
   RUN echo 'const slides = require("aspose.slides.via.java");\n\
   var presentation = new slides.Presentation();\n\
   var slide = presentation.getSlides().get_Item(0);\n\
   slide.getShapes().addAutoShape(slides.ShapeType.Line, 50, 150, 300, 0);\n\
   presentation.save("./NewPresentation.pptx", slides.SaveFormat.Pptx);\n\
   console.log("Script completed, please check file /app/NewPresentation.pptx!");' > index.js

   # 安装 package.json 中指定的通过 Java 的 Aspose.Slides 包
   RUN npm install aspose.slides.via.java

   # 设置容器启动时运行应用程序的默认命令
   CMD ["node", "index.js"]
   ```


### 2. **构建 Docker 镜像**
   在包含 Dockerfile 的目录中运行以下命令以构建 Docker 镜像：
   ```bash
   docker build -t aspose-slides-nodejs .
   ```


### 3. **运行 Docker 容器**
   运行容器并保存其 ID：
```bash
CONTAINER_ID=$(docker create aspose-slides-nodejs)
docker start -a $CONTAINER_ID
```


### 4. **在 Docker 中访问 Aspose.Slides** 
   启动容器后，脚本将生成一个 PPTX 文件。您可以在容器内的 `/app` 文件夹中找到生成的输出文件 `NewPresentation.pptx`：
   ```bash
   docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
   ```

   删除临时容器：
   ```bash
   docker rm $CONTAINER_ID
   ```
