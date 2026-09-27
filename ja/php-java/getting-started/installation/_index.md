---
title: インストール
type: docs
weight: 70
url: /ja/php-java/installation/
keywords:
- Aspose.Slides のインストール
- Aspose.Slides のダウンロード
- Aspose.Slides の使用
- Aspose.Slides のインストール
- Windows
- Linux
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Linux と Windows 上で PHP via Java 用の Aspose.Slides をインストールします：PHP、Java、Apache Tomcat、PHP/Java Bridge を設定し、Composer でパッケージを追加し、短いスクリプトでセットアップを確認します。"
---
## **概要**

Aspose.Slides for PHP via Java は 2 つのプロセスで実行されます。PHP スクリプトは PHP クラスを使用し、すべての呼び出しを PHP/Java Bridge 経由で Aspose.Slides に渡します。Aspose.Slides は Apache Tomcat 上の Java で動作します。本記事では、両側の設定方法、Composer でのパッケージインストール手順、インストール確認のための簡単なスクリプト実行方法を説明します。

## **前提条件**

- **PHP 7.0 から 8.3**、`php.ini` で `allow_url_include = On` が設定されていること。スクリプトは Tomcat から HTTP 経由でブリッジのクライアントライブラリ `Java.inc` を読み込みます。PHP 8.4 以降では、`xml` 拡張がロードされていると `Java.inc` が「end() expects exactly 1 argument」というエラーで停止し、Windows ビルドの PHP は常にそれをロードします。
- **[Composer](https://getcomposer.org/)**。
- **Java 8 以上**。JRE で構いません。
- **Apache Tomcat 9**。PHP/Java Bridge は `javax.servlet` API 上に構築されており、Tomcat 10 以降では提供されなくなるため、Bridge は起動しません。
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1**（最新リリース）。その Web アプリケーション `JavaBridge.war` を Tomcat 上で実行します。

この手順では Tomcat と PHP スクリプトを同一マシン上で動かします。Aspose.Slides は Tomcat 内でファイルを開閉するため、スクリプトが渡すすべてのパスは Tomcat 側でも有効である必要があります。

## **Linux へのインストール**

以下のコマンドは Ubuntu 24.04 のホームディレクトリにすべてをインストールします。他のディストリビューションでは、同等のパッケージをディストリビューションのパッケージマネージャでインストールしてください。

1. PHP、Composer、Java、ダウンロードツールをインストールし、PHP コマンドライン用に `allow_url_include` を有効化します：

   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
   ```

2. Apache Tomcat 9 と PHP/Java Bridge をダウンロードし、Bridge の `JavaBridge.war` を Tomcat の `webapps` フォルダーに配置して Tomcat を起動します。Tomcat は起動時に WAR ファイルを `webapps/JavaBridge` に展開します：

   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

3. プロジェクトフォルダーを作成し、[Packagist](https://packagist.org/packages/aspose/slides) から Aspose.Slides for PHP via Java をインストールします：

   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

4. Tomcat を停止し、パッケージから Aspose.Slides の JAR ファイルを Bridge の `WEB-INF/lib` フォルダーにコピーし、パッケージに含まれる PHP 8 用の `Java.inc` に置き換えてから Tomcat を再起動します：

   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/ja/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/ja/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

   PHP 7 を使用する場合は `Java.inc` の置き換えを省略してください。Tomcat の起動には数秒かかり、スクリプトが Aspose.Slides を使用するたびに実行中である必要があります。

## **Windows へのインストール**

1. [PHP 8.3 for Windows](https://www.php.net/downloads.php?os=windows) をインストールし、インストールフォルダーを `PATH` 環境変数に追加します。`php.ini-production` を同フォルダーにコピーして `php.ini` とし、`allow_url_include = On` を設定し、`extension_dir = "ext"`、`extension=openssl`、`extension=zip` の行のコメントを外します。Composer がパッケージをダウンロードする際に `openssl` が必要で、`zip` は 7‑Zip がインストールされていないか `PATH` に `unzip` コマンドがない場合に必要です。
2. [Composer](https://getcomposer.org/download/) をインストールします。
3. Java をインストールし、`JAVA_HOME` 環境変数を Java のインストールフォルダーに設定します。これがないと Tomcat は起動しません。
4. コマンドプロンプトで Apache Tomcat 9 と PHP/Java Bridge をダウンロードし、Bridge の `JavaBridge.war` を Tomcat の `webapps` フォルダーに配置して Tomcat を起動します。Tomcat のスクリプトは `CATALINA_HOME` 変数で Tomcat を検出するため、以降の手順は同じコマンドプロンプトウィンドウで続けてください。Tomcat は起動時に WAR ファイルを `webapps\JavaBridge` に展開します：

   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

5. プロジェクトフォルダーを作成し、[Packagist](https://packagist.org/packages/aspose/slides) から Aspose.Slides for PHP via Java をインストールします：

   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

6. Tomcat を停止し、パッケージから Aspose.Slides の JAR ファイルを Bridge の `WEB-INF\lib` フォルダーにコピーし、パッケージに含まれる PHP 8 用の `Java.inc` に置き換えてから Tomcat を再起動します：

   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

   PHP 7 を使用する場合は `Java.inc` の置き換えを省略してください。Tomcat の起動には数秒かかり、スクリプトが Aspose.Slides を使用するたびに実行中である必要があります。

## **インストールの確認**

以下のスクリプトをプロジェクトフォルダーに *hello.php* として保存します。スクリプトはテキストボックスを 1 つ含むプレゼンテーションを作成し、スクリプトと同じフォルダーに保存します：

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/ja/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

プロジェクトフォルダーから実行します：

```bash
php hello.php
```

スクリプトは *hello.pptx* を生成し、テキストボックスを含むスライドが 1 枚作成されます。ライセンスがない場合、スライドには評価用の透かしが表示されます。詳細は [ライセンス](/slides/ja/php-java/licensing/) を参照してください。

スクリプトは `aspose.slides.php` を直接インクルードしています。Composer のオートローダーはこれらのクラスをロードできません。これらのクラスはすべて同一ファイルに定義されているためです。また、`save` には絶対パスを渡しています。Aspose.Slides は Tomcat 内で実行され、相対パスは Tomcat の作業フォルダーに対して解決されるためです。

## **FAQ**

**Aspose.Slides が正しく統合されているかどうか、どのように確認できますか？**

[インストールの確認](#インストールの確認) のスクリプトを実行してください。エラーなく *hello.pptx* が生成されれば、PHP、PHP/Java Bridge、Aspose.Slides が正常に連携しています。

**スクリプトが「Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc'」で停止します。原因は何ですか？**

Tomcat から `Java.inc` が読み込めません。エラーメッセージに `http://` ラッパーが無効とある場合は、実行中の PHP が使用している `php.ini` で `allow_url_include = On` を設定してください。`php --ini` で使用中の設定ファイルを確認できます。メッセージが「Connection refused」の場合は Tomcat が起動していません。Tomcat を起動するか、起動完了まで数秒待ってから再度実行してください。

**大容量のプレゼンテーションを処理する際のメモリ使用量を抑えるにはどうすればよいですか？**

JVM のメモリ上限は必要最低限に設定し、`Presentation` インスタンスは `finally` ブロックで必ず `close()` してキャッシュを速やかに解放してください。これによりメモリ不足エラーを防ぎ、バッチ処理中のメモリ使用量を予測可能に保てます。

**不要なエクスポート形式を除外して最終 JAR のサイズを小さくできますか？**

現在の Aspose.Slides のリリースは単一のモノリシックライブラリとして配布されており、PDF や SVG など特定のエクスポート機能をビルド時に無効化することはできません。