---
title: インストール
type: docs
weight: 70
url: /php-java/installation/
keySlides: "Aspose.Slidesをダウンロード, Aspose.Slidesのインストール, Aspose.Slidesのインストール, Windows, macOS, Linux, PHP"
description: "Windows、Linux、またはmacOS上でJava経由でAspose.Slides for PHPをインストール"
---

## **環境の設定**

1. PHP 7をインストールし、PHPのパスをシステムの`PATH`変数に追加し、`php.ini`ファイルで`allow_url_include`を`On`に設定します。
1. JRE 8をインストールします。インストールされたJREのパスを`JAVA_HOME`環境変数に設定します。
1. Apache Tomcat 8.0をインストールします。

## **Java経由でAspose.Slides for PHPをダウンロード**

`packagist`は、[Aspose.Slides for PHP via Java](https://packagist.org/packages/aspose/slides)をダウンロードする最も簡単な方法です。

Packagistを使用してAspose.Slidesをインストールするには、次のコマンドを実行します：
   ```bash
   composer require aspose/slides
   ```

## **Apache Tomcatの設定**

1. http://php-java-bridge.sourceforge.net/pjb/download.php からPHP/Java Bridge（`php-java-bridge_x.x.x_documentation.zip`）をダウンロードし、`JavaBridge.war`ファイルをTomcatの`webapps`フォルダに抽出します。
1. Apache Tomcatサービスを開始します。
1. [“Aspose.Slides for PHP via Java”](https://downloads.aspose.com/slides/php-java) をダウンロードし、`aspose.slides`フォルダに抽出します。`jar/aspose-slides-x.x-php.jar`ファイルを`webapps\JavaBridge\WEB-INF\lib`フォルダにコピーします。**PHP 8**を使用している場合は、PHP-Java Bridgeの元の`Java.inc`を`Java.inc.php8.zip`からの`Java.inc`で置き換えます。
1. Apache Tomcatサービスを再起動します。
1. `aspose.slides`フォルダ内の`example.php`を次のコマンドで実行して例を実行します：
   ```bash
   php example.php
   ```

## Dockerセットアップ ##

前提条件：
* マシンにDockerをインストールします。公式インストールガイドは[こちら](https://docs.docker.com/get-docker/)をご覧ください。

手順：
1. **Dockerfileの作成**。プロジェクトディレクトリ内に以下の内容のDockerfileという名前の新しいファイルを作成します：
   ```
   # ベースイメージ（公式Ubuntuイメージ）
   FROM ubuntu:20.04
   
   # インタラクティブな選択を避けるために、事前にタイムゾーンを設定
   ENV DEBIAN_FRONTEND=noninteractive
   RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
       apt-get update && apt-get install -y tzdata && \
       dpkg-reconfigure --frontend noninteractive tzdata
   
   # 必要なパッケージをインストールし、パッケージリストを更新
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
   
   # Microsoft TrueTypeフォントのインストールに関するライセンス契約を自動的に受け入れる
   RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
   
   # Microsoft TrueTypeフォントをインストール
   RUN apt-get update && \
       apt-get install -y ttf-mscorefonts-installer && \
       rm -rf /var/lib/apt/lists/*
   
   # Tomcatをインストール - バージョン9.0.93を使用
   RUN wget https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.93/bin/apache-tomcat-9.0.93.tar.gz -O /tmp/tomcat.tar.gz && \
       tar xzf /tmp/tomcat.tar.gz -C /opt/ && \
       mv /opt/apache-tomcat-9.0.93 /opt/tomcat && \
       rm /tmp/tomcat.tar.gz
   
   # PHP/Java Bridgeをインストール
   RUN curl -L http://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download -o /tmp/php-java-bridge.zip && \
       unzip /tmp/php-java-bridge.zip -d /tmp/php-java-bridge && \
       mkdir -p /opt/tomcat/webapps/JavaBridge && \
       cp /tmp/php-java-bridge/JavaBridge.war /opt/tomcat/webapps/JavaBridge && \
       cd /opt/tomcat/webapps/JavaBridge && \
       jar -xvf JavaBridge.war && \
       rm -rf /tmp/php-java-bridge.zip /tmp/php-java-bridge
   
   # Java経由でAspose.Slides for PHPをダウンロードしてインストール
   RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
       unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
       mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       mkdir -p /tmp/sample && \
       cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
       rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides
   
   # test.phpファイルを作成
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
   
   # entrypoint.shスクリプトを作成
   RUN echo '#!/bin/bash\n\
   # Tomcatをバックグラウンドで起動\n\
   catalina.sh start\n\
   # Tomcatが完全に起動するのを待つ\n\
   until curl -s http://localhost:8080 > /dev/null; do\n\
    sleep 2\n\
   done\n\
   echo "PHPスクリプトを実行中..."\n\
   # PHPスクリプトを実行\n\
   php /tmp/sample/test.php\n\
   echo "PHPスクリプトが完了しました。/tmp/output.pdfファイルをご確認ください。"\n\
   # コンテナを生かしておく\n\
   echo "コンテナを生かしておきます..."\n\
   tail -f /dev/null\n\
   ' > /tmp/entrypoint.sh
   
   # スクリプトに実行権限を明示的に付与
   RUN chmod 755 /tmp/entrypoint.sh
   
   # php.iniの設定
   RUN echo "allow_url_include = On" >> /etc/php/7.4/cli/php.ini
   
   # Tomcatの環境変数を設定
   ENV CATALINA_HOME /opt/tomcat
   ENV PATH $CATALINA_HOME/bin:$PATH
   ENV PHP_CLASSPATH /opt/aspose-slides/lib
   
   # Tomcatのポート8080とPHP/Java Bridgeのポート9000を公開
   EXPOSE 8080
   EXPOSE 9000
   
   # 作業ディレクトリを設定
   WORKDIR /tmp
   
   # コンテナが起動時にTomcatを開始
   ENTRYPOINT ["/tmp/entrypoint.sh"]
   ```

2. **Dockerイメージのビルド**。Dockerfileがあるディレクトリで以下のコマンドを実行してDockerイメージをビルドします：
   ```bash
   docker build -t aspose-slides-php-java .
   ```

3. **Dockerコンテナの実行**。イメージがビルドされたら、コンテナを実行します：
   ```bash
   docker run -p 8080:8080 aspose-slides-php-java
   ```

4. **Docker内でAspose.Slidesにアクセス**。コンテナを起動した後、スクリプトはPDFファイルを生成します。生成された出力ファイル`output.pdf`はコンテナ内の`/tmp`フォルダにあります：
   ```bash
   docker exec -it <container-id> ls /tmp
   ```
   生成されたPDFファイルをローカルマシンにコピーするには、次のコマンドを実行します：
   ```bash
   docker cp <container-id>:/tmp/output.pdf ./output.pdf
   ```