---
title: Docker で Aspose.Slides for Java を実行する方法
type: docs
weight: 75
url: /ja/java/how-to-run-aspose-slides-in-docker/
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
- Java
- Aspose.Slides
description: "Docker コンテナで Aspose.Slides を実行: イメージ、依存関係、フォント、ライセンスを構成し、PowerPoint と OpenDocument を処理するスケーラブルなサービスを構築します。"
---

## **はじめに**

このガイドでは、Aspose Slides を使用して Java アプリケーションを Docker でコンテナ化する方法を説明します。主なメリットは次のとおりです。

- **クロスプラットフォーム互換性** - Windows、macOS、Linux で動作します
- **依存関係の分離** - システム全体へのインストールは不要です
- **簡素化されたデプロイ** - 共有と実行が簡単です

## **1. Docker のインストール**

### **Windows**

**Requirements:**

- Windows 10/11 Pro/Enterprise/Education（64 ビット）で WSL 2 が有効化されていること
- Home エディションの場合: 手動で WSL 2 をインストールする必要があります

**Steps:**

1. [Docker Desktop for Windows](https://www.docker.com/products/docker-desktop/) をダウンロードします
2. インストーラーを実行し、セットアップウィザードに従います
3. プロンプトが表示されたらコンピューターを再起動します
4. インストールを確認します:
   ```powershell
   docker --version
   ```


### **macOS**

**Requirements:**

- macOS 10.15（Catalina）以降
- Apple Silicon または Intel プロセッサ

**Steps:**

1. [Docker Desktop for Mac](https://www.docker.com/products/docker-desktop/) をダウンロードします
2. アプリケーションを `Applications` フォルダーへドラッグします
3. Docker を起動し、初期化が完了するのを待ちます
4. インストールを確認します:
   ```bash
   docker --version
   ```


### **Linux (Ubuntu/Debian)**

**Installation:**
```bash
# パッケージリストを更新
sudo apt update && sudo apt upgrade -y

# 前提条件をインストール
sudo apt install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    software-properties-common

# Docker の公式 GPG 鍵を追加
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

# 安定版リポジトリを追加
echo "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# Docker エンジンをインストール
sudo apt update
sudo apt install -y docker-ce docker-ce-cli containerd.io

# 現在のユーザーが Docker コマンドを実行できるようにする
sudo usermod -aG docker $USER
newgrp docker

# インストールを検証
docker --version
```


## **2. Dockerfile の構成**

### **ベースイメージ**
```dockerfile
FROM ubuntu:24.04
```

> **注**: Docker Hub の [official Ubuntu image](https://hub.docker.com/_/ubuntu) を使用しています。

### **依存関係**
```dockerfile
RUN apt-get install -y openjdk-11-jdk wget fontconfig ttf-mscorefonts-installer
```

- **OpenJDK 11**: Java ランタイム環境
- **フォントパッケージ**: Microsoft Core Fonts を含みます

### **Aspose.Slides のセットアップ**
```dockerfile
ENV ASPOSE_VERSION=25.3

ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}
```

- Aspose Slides ライブラリをバージョン固定でダウンロード

## **3. プロジェクトのセットアップ**

### **ファイル構成**
```
aspose-docker/
├── Dockerfile          # コンテナ構成
├── TestAspose.java     # アプリケーションコード
└── output/             # 生成された PDF が入るフォルダー（自動作成）
```


### **Dockerfile**

`Dockerfile` という名前のファイルを作成し、以下を記述します:
```dockerfile
FROM ubuntu:24.04

# 環境変数を設定
ENV JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64
ENV PATH=$JAVA_HOME/bin:$PATH
ENV APP_DIR=/tmp
ENV ASPOSE_VERSION=25.3
ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}

# 作業ディレクトリを作成
RUN mkdir -p ${APP_DIR}
WORKDIR ${APP_DIR}

# 依存関係をインストール
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jdk \
    wget \
    fontconfig \
    ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# フォントを設定
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections && \
    apt-get update && \
    apt-get install -y --no-install-recommends ttf-mscorefonts-installer && \
    fc-cache -f -v

# /tmp に Aspose.Slides をダウンロード
RUN wget ${ASPOSE_URL} -O ${APP_DIR}/${ASPOSE_JAR}

# ソースコードをコピー
COPY TestAspose.java ${APP_DIR}/

# 実行スクリプトを作成
RUN echo '#!/bin/bash' > ${APP_DIR}/run.sh && \
    echo 'java --add-opens=java.desktop/sun.java2d=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.awt.image=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.font=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     -cp ".:'"${ASPOSE_JAR}"'" TestAspose' >> ${APP_DIR}/run.sh && \
    chmod +x ${APP_DIR}/run.sh

# スクリプトに実行権限を明示的に付与
RUN chmod 755 ${APP_DIR}/run.sh

# Java コードをコンパイル
RUN javac -cp "${APP_DIR}/${ASPOSE_JAR}" ${APP_DIR}/TestAspose.java

# 作業ディレクトリを設定
WORKDIR /tmp

CMD ["sh", "-c", "/tmp/run.sh && cp /tmp/output/output.pdf /output"]
```


### **Java アプリケーション**

`TestAspose.java` を作成し、以下を記述します:
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


## **4. ビルドと実行**

### **イメージのビルド**

Dockerfile があるディレクトリで次のコマンドを実行して Docker イメージをビルドします:
   ```powershell
   docker build -t aspose-test .
   ```


- `-t` はイメージ名を "aspose-test" に設定します
- `.` は現在のディレクトリの Dockerfile を使用します

### **コンテナの実行**

Dockerfile があるディレクトリで次のコマンドを実行して Docker コンテナを起動します:
   ```powershell
   docker run -v "$(pwd)/output:/output" aspose-test
   ```


- `-v` は出力ディレクトリをマウントします
- `output.pdf` がローカルの `output` フォルダーに作成されます