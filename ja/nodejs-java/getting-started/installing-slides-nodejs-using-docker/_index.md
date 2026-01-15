---
title: Docker を使用して Java 経由で Node.js 用 Aspose.Slides をインストール
type: docs
weight: 75
url: /ja/nodejs-java/installing-slides-nodejs-using-docker/
keywords:
- Aspose.Slides のダウンロード
- Aspose.Slides のインストール
- Aspose.Slides のインストール
- Docker
- Windows
- macOS
- Linux
- クロスプラットフォーム互換性
- 依存関係の分離
- 簡素化されたデプロイ
- プロジェクト設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Docker コンテナで Aspose.Slides を実行し、イメージ、依存関係、フォント、ライセンスを構成して、PowerPoint および OpenDocument を処理するスケーラブルなサービスを構築します。"
---

## 前提条件:
* マシンに Docker をインストールしてください。公式インストールガイドは[here](https://docs.docker.com/get-docker/)をご覧ください。

## 手順:

### 1. **Create Dockerfile** 
   プロジェクトディレクトリに Dockerfile という名前の新しいファイルを作成し、以下の内容を記述してください:
   ```
   # Ubuntu 20.04 をベースイメージとして使用
   FROM ubuntu:20.04

   # パッケージリストを更新し、リポジトリ追加やファイルダウンロードに必要な基本パッケージをインストール
   RUN apt-get update && \
      apt-get install -y curl gnupg2 software-properties-common && \
      rm -rf /var/lib/apt/lists/*

   # Nodesource リポジトリから Node.js バージョン 18.x をインストール
   RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash - && \
      apt-get install -y nodejs && \
      rm -rf /var/lib/apt/lists/*

   # 一部の npm パッケージ（例: node-gyp）で必要となる Python 2.x をインストール
   RUN apt-get update && \
      apt-get install -y python2 && \
      rm -rf /var/lib/apt/lists/*

   # Aspose.Slides の Java 依存関係に必要な OpenJDK 11 をインストール
   RUN apt-get update && \
      apt-get install -y openjdk-11-jdk && \
      rm -rf /var/lib/apt/lists/*

   # ネイティブモジュール構築に必要な 'make' などのツールを含む build-essential パッケージをインストール
   RUN apt-get update && \
      apt-get install -y build-essential && \
      rm -rf /var/lib/apt/lists/*

   # Node.js 用のネイティブアドオンをコンパイルするツールである node-gyp をグローバルにインストール
   RUN npm install -g node-gyp

   # コンテナ内の作業ディレクトリを /app に設定
   WORKDIR /app

   # 必要な詳細情報と依存関係を含む package.json ファイルを作成
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

   # Aspose.Slides を使用してプレゼンテーションを作成するサンプルコードを含む index.js ファイルを作成
   RUN echo 'const slides = require("aspose.slides.via.java");\n\
   var presentation = new slides.Presentation();\n\
   var slide = presentation.getSlides().get_Item(0);\n\
   slide.getShapes().addAutoShape(slides.ShapeType.Line, 50, 150, 300, 0);\n\
   presentation.save("./NewPresentation.pptx", slides.SaveFormat.Pptx);\n\
   console.log("Script completed, please check file /app/NewPresentation.pptx!");' > index.js

   # package.json に指定された Aspose.Slides via Java パッケージをインストール
   RUN npm install aspose.slides.via.java

   # コンテナ起動時にアプリケーションを実行するデフォルトコマンドを設定
   CMD ["node", "index.js"]
   ```


### 2. **Build Docker Image**
   Dockerfile があるディレクトリで次のコマンドを実行し、Docker イメージをビルドします:
   ```bash
   docker build -t aspose-slides-nodejs .
   ```


### 3. **Run Docker Container**
   コンテナを実行し、その ID を保存します:
   ```bash
   CONTAINER_ID=$(docker create aspose-slides-nodejs)
   docker start -a $CONTAINER_ID
   ```


### 4. **Access Aspose.Slides in Docker** 
   コンテナを起動すると、スクリプトが PPTX ファイルを生成します。生成された出力ファイル `NewPresentation.pptx` はコンテナ内の `/app` フォルダーにあります:
```bash
docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
```

   一時コンテナを削除します:
   ```bash
   docker rm $CONTAINER_ID
   ```
