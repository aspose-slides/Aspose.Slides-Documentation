---
title: インストール
type: docs
weight: 70
url: /ja/php-java/installation/
keywords:
- Aspose.Slides をインストール
- Aspose.Slides をダウンロード
- Aspose.Slides を使用
- Aspose.Slides のインストール
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PHP via Java 用の Aspose.Slides をすぐにインストールできます。ステップバイステップのガイド、システム要件、コードサンプルを提供し、今日から PowerPoint プレゼンテーションの作成を開始しましょう！"
---

## **環境の構成**

1. PHP 7 をインストールし、システムの `PATH` 環境変数に PHP のパスを追加し、`php.ini` ファイルで `allow_url_include` を `On` に設定します。
1. JRE 8 をインストールします。`JAVA_HOME` 環境変数をインストールした JRE のパスに設定します。
1. Apache Tomcat 8.0 をインストールします。

## **Aspose.Slides for PHP via Java のダウンロード**

`packagist` は、[Aspose.Slides for PHP via Java](https://packagist.org/packages/aspose/slides) をダウンロードする最も簡単な方法です。

Packagist を使用して Aspose.Slides をインストールするには、次のコマンドを実行します:
   ```bash
   composer require aspose/slides
   ```


## **Apache Tomcat の構成**

1. http://php-java-bridge.sourceforge.net/pjb/download.php から PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) をダウンロードし、`JavaBridge.war` ファイルを Tomcat の `webapps` フォルダーに展開します。
1. Apache Tomcat サービスを開始します。
1. https://downloads.aspose.com/slides/php-java から「Aspose.Slides for PHP via Java」をダウンロードし、`aspose.slides` フォルダーに展開します。`jar/aspose-slides-x.x-php.jar` ファイルを `webapps\JavaBridge\WEB-INF\lib` フォルダーにコピーします。**PHP 8** を使用している場合は、PHP-Java Bridge の元の `Java.inc` を `Java.inc.php8.zip` に含まれる `Java.inc` に置き換えます。
1. Apache Tomcat サービスを再起動します。
1. `aspose.slides` フォルダー内の `example.php` を実行して、次のコマンドでサンプルを実行します:
   ```bash
   php example.php
   ```


## **FAQ**

**Aspose.Slides が正しく統合されているかをどうやって確認できますか？**

プロジェクトをビルドし、空白の [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) をインスタンス化して新しい名前で保存します。例外が発生せずにファイルが作成できれば、ライブラリは正常に統合されたと判断できます。

**大きなプレゼンテーションを処理する際にメモリ使用量を制限するにはどうすればよいですか？**

JVM のメモリ上限は必要最低限に設定し、各 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) インスタンスを `finally` ブロックで閉じてキャッシュを速やかに解放します。これによりメモリ不足エラーを防止し、バッチ処理中の総メモリ使用量を予測可能に保ちます。

**不要なエクスポート形式を除外して最終的な JAR のサイズを縮小できますか？**

現在の Aspose.Slides のリリースは単一のモノリシック ライブラリとして提供されているため、ビルド時に PDF や SVG など特定のエクスポーターを無効化することはできません。