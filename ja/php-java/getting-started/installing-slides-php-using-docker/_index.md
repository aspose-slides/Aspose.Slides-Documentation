---
title: Docker を使用して Java 経由で PHP 用 Aspose.Slides をインストール
type: docs
weight: 75
url: /ja/php-java/installing-slides-php-using-docker/
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
- プロジェクトのセットアップ
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Docker コンテナで Aspose.Slides を実行し、イメージ、依存関係、フォント、ライセンスを設定して、PowerPoint と OpenDocument を処理するスケーラブルなサービスを構築します。"
---

## **前提条件**
* マシンに Docker をインストールします。公式インストールガイドは[こちら](https://docs.docker.com/get-docker/)で確認できます。

## **手順**

### **1. Dockerfile の作成** 
   プロジェクトディレクトリに Dockerfile という名前の新しいファイルを作成し、以下の内容を記述します:
   ```
   # ベースイメージ（公式 Ubuntu イメージ）
   FROM ubuntu:20.04
   
   # タイムゾーンを事前に設定し、対話的な選択を回避する
   ENV DEBIAN_FRONTEND=noninteractive
   RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
       apt-get update && apt-get install -y tzdata && \
       dpkg-reconfigure --frontend noninteractive tzdata
   
   # 必要なパッケージをインストールし、パッケージリストを更新する
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
   
   # Microsoft TrueType フォントインストールのためのライセンス契約を自動的に承諾する
   RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
   
   # Microsoft TrueType フォントをインストールする
   RUN apt-get update && \
       apt-get install -y ttf-mscorefonts-installer && \
       rm -rf /var/lib/apt/lists/*
   
   # Tomcat をインストール - バージョン 9.0.93 を使用
   RUN wget https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.93/bin/apache-tomcat-9.0.93.tar.gz -O /tmp/tomcat.tar.gz && \
       tar xzf /tmp/tomcat.tar.gz -C /opt/ && \
       mv /opt/apache-tomcat-9.0.93 /opt/tomcat && \
       rm /tmp/tomcat.tar.gz
   
   # PHP/Java Bridge をインストールする
   RUN curl -L http://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download -o /tmp/php-java-bridge.zip && \
       unzip /tmp/php-java-bridge.zip -d /tmp/php-java-bridge && \
       mkdir -p /opt/tomcat/webapps/JavaBridge && \
       cp /tmp/php-java-bridge/JavaBridge.war /opt/tomcat/webapps/JavaBridge && \
       cd /opt/tomcat/webapps/JavaBridge && \
       jar -xvf JavaBridge.war && \
       rm -rf /tmp/php-java-bridge.zip /tmp/php-java-bridge
   
   # Aspose.Slides for PHP via Java をダウンロードしてインストールする
   RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
       unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
       mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       mkdir -p /tmp/sample && \
       cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
       rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides
   
   # test.php ファイルを作成する
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
   
   # entrypoint.sh スクリプトを作成する
   RUN echo '#!/bin/bash\n\
   # Tomcat をバックグラウンドで起動する\n\
   catalina.sh start\n\
   # Tomcat が完全に起動するまで待機する\n\
   until curl -s http://localhost:8080 > /dev/null; do\n\
    sleep 2\n\
   done\n\
   echo "Running the PHP script..."\n\
   # PHP スクリプトを実行する\n\
   php /tmp/sample/test.php\n\
   echo "PHP script completed, please check file /tmp/output.pdf."\n\
   # コンテナを常に実行状態に保つ\n\
   echo "Keeping the container alive..."\n\
   tail -f /dev/null\n\
   ' > /tmp/entrypoint.sh
   
   # スクリプトに実行権限を明示的に付与する
   RUN chmod 755 /tmp/entrypoint.sh
   
   # php.ini を設定する
   RUN echo "allow_url_include = On" >> /etc/php/7.4/cli/php.ini
   
   # Tomcat 用の環境変数を設定する
   ENV CATALINA_HOME /opt/tomcat
   ENV PATH $CATALINA_HOME/bin:$PATH
   ENV PHP_CLASSPATH /opt/aspose-slides/lib
   
   # Tomcat 用のポート 8080 と PHP/Java Bridge 用のポート 9000 を公開する
   EXPOSE 8080
   EXPOSE 9000
   
   # 作業ディレクトリを設定する
   WORKDIR /tmp
   
   # コンテナ起動時に Tomcat を開始する
   ENTRYPOINT ["/tmp/entrypoint.sh"]
   ```


### **2. Docker イメージのビルド**
   Dockerfile が置かれているディレクトリで次のコマンドを実行し、Docker イメージをビルドします:
```bash
docker build -t aspose-slides-php-java .
```


### **3. Docker コンテナの実行**
   イメージのビルドが完了したら、コンテナを実行します:
```bash
docker run -p 8080:8080 aspose-slides-php-java
```


### **4. Docker で Aspose.Slides にアクセス** 
   コンテナを起動すると、スクリプトが PDF ファイルを生成します。生成された出力ファイル `output.pdf` はコンテナ内の `/tmp` フォルダーにあります:
```bash
docker exec -it <container-id> ls /tmp
```

   生成された PDF ファイルをローカルマシンにコピーするには、次のコマンドを実行します:
```bash
docker cp <container-id>:/tmp/output.pdf ./output.pdf
```
