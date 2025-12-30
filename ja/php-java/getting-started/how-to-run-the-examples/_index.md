---
title: サンプルの実行方法
type: docs
weight: 140
url: /ja/php-java/how-to-run-the-examples/
keywords:
- サンプル
- ソフトウェア要件
- GitHub
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java のサンプルを素早く実行するには: リポジトリをクローンし、パッケージを復元し、PPT、PPTX、ODP 用の機能をビルドしてテストします。"
---

## **GitHubからダウンロード**
Aspose.Slides for PHP via Java のすべてのサンプルは[Github](https://github.com/aspose-slides/Aspose.Slides-for-Java)にホストされています。好きな Github クライアントでリポジトリをクローンするか、[here](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master)から ZIP ファイルをダウンロードできます。

ZIP ファイルの内容をコンピュータ上の任意のフォルダーに展開してください。すべてのサンプルは **Examples** フォルダーにあります。

![todo:image_alt_text](examples_directory.png)

## **IDEへのインポート**
このプロジェクトは Maven ビルドシステムを使用しています。任意の最新 IDE でプロジェクトと依存関係を簡単に開くまたはインポートできます。以下では、一般的な IDE を使用してサンプルをビルドおよび実行する方法を示します。

### **IntelliJ IDEA**
**File** メニューをクリックし、**Open** を選択します。プロジェクトフォルダーに移動し、**pom.xml** ファイルを選択してください。

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

プロジェクトが開き、依存関係が自動的にダウンロードされます。Project タブで **src/main/java** フォルダー内のサンプルを参照してください。サンプルを実行するには、ファイルを右クリックし「Run ..」を選択します。サンプルが実行され、出力は組み込みのコンソールウィンドウに表示されます。

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
**File** メニューをクリックし、**Import** を選択します。**Maven** - Existing Maven Projects を選択してください。

![todo:image_alt_text](eclipse_import.png)

GitHub からクローンまたはダウンロードしたフォルダーに移動し、**pom.xml** ファイルを選択してください。プロジェクトが開き、依存関係が自動的にダウンロードされます。Package Explorer タブで **src/main/java** フォルダー内のサンプルを参照してください。サンプルを実行するには、ファイルを右クリックし **Run As** - **Java Application** を選択します。サンプルが実行され、出力は組み込みのコンソールウィンドウに表示されます。

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
**File** メニューをクリックし、**Open Project** を選択します。GitHub からクローンまたはダウンロードしたフォルダーに移動します。**Examples** フォルダーのアイコンが Maven プロジェクトであることを示します。Examples を選択して開いてください。

![todo:image_alt_text](netbeans_openproject.png)

プロジェクトが開き、依存関係が自動的にダウンロードされます。Projects タブで **source packages** 内のサンプルを参照してください。サンプルを実行するには、ファイルを右クリックし **Run File** を選択します。サンプルが実行され、出力は組み込みのコンソールウィンドウに表示されます。

![todo:image_alt_text](netbeans_run_example.png)

## **Aspose.Slides ライブラリを Maven ローカルリポジトリに追加**
IDE に **Aspose.Slides Examples** プロジェクトをインポートすると、Maven は[Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/)から aspose.slides JAR ファイルを自動的にダウンロードします。インターネットにアクセスできない場合は、ローカルリポジトリに JAR を手動で追加できます。

### **mvn install**
[aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/) をダウンロードし、展開して aspose.slides-version.jar を別の場所（例: C ドライブ）にコピーします。以下のコマンドを実行してください:
```php

```

mvn install:install-file
    -Dfile=c:\aspose.slides-version.jar
    -DgroupId=com.aspose
    -DartifactId=aspose-slides
    -Dversion={version}
    -Dpackaging=jar
```php

```


これで **aspose.slides** JAR が Maven ローカルリポジトリにコピーされました。

### **pom.xml**
インストール後、pom.xml に **aspose.slides** の座標を宣言するだけです。repositories タブに以下のリポジトリを追加し、dependencies タブに依存関係を追加してください。
``` xml
<repository>
    <id>aspose-maven-repository</id>
    <url>http://repository.aspose.com/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>18.6</version>
    <classifier>jdk16</classifier>
</dependency>
```php

```


### **完了**
ビルドすると、**aspose.slides** JAR が Maven ローカルリポジトリから取得できるようになります。

## **貢献**
サンプルを追加または改善したい場合は、プロジェクトへの貢献を奨励します。このリポジトリのすべてのサンプルとショーケースプロジェクトはオープンソースであり、自由に自分のアプリケーションで使用できます。

貢献するには、リポジトリをフォークし、ソースコードを編集してプルリクエストを送信できます。変更をレビューし、役立つと判断した場合はリポジトリに取り込みます。