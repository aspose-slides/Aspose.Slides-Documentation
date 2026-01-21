---
title: サンプルの実行方法
type: docs
weight: 140
url: /ja/java/how-to-run-the-examples/
keywords:
- 例
- ソフトウェア要件
- GitHub
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のサンプルを素早く実行する方法: リポジトリをクローンし、パッケージを復元し、PPT、PPTX、ODP の機能をビルドしてテストします。"
---

## **GitHubから Aspose.Slides をダウンロード**
Aspose.Slides for Java のすべてのサンプルは [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java) にホストされています。お好みの Github クライアントでリポジトリをクローンするか、[here](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master) から ZIP ファイルをダウンロードできます。

ZIP ファイルの内容をコンピュータ上の任意のフォルダーに展開します。すべてのサンプルは **Examples** フォルダーにあります。

![todo:image_alt_text](examples_directory.png)

## **IDE にサンプルをインポート**
このプロジェクトは Maven ビルドシステムを使用しています。最新の IDE なら誰でも簡単にプロジェクトとその依存関係を開くかインポートできます。以下に、一般的な IDE を使用してサンプルをビルドおよび実行する方法を示します。

### **IntelliJ IDEA**
**File** メニューをクリックし、**Open** を選択します。プロジェクト フォルダーに移動し、**pom.xml** ファイルを選択します。

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

プロジェクトが開かれ、依存関係が自動的にダウンロードされます。Project タブから **src/main/java** フォルダー内のサンプルを参照できます。サンプルを実行するには、ファイルを右クリックして「Run ..」を選択するだけで、サンプルが実行され、出力は組み込みのコンソール出力ウィンドウに表示されます。

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
**File** メニューをクリックし、**Import** を選択します。**Maven** - Existing Maven Projects を選びます。

![todo:image_alt_text](eclipse_import.png)

クローンまたはダウンロードしたフォルダーに移動し、**pom.xml** ファイルを選択します。プロジェクトが開かれ、依存関係が自動的にダウンロードされます。Package Explorer タブから **src/main/java** フォルダー内のサンプルを参照できます。サンプルを実行するには、ファイルを右クリックして **Run As** - **Java Application** を選択するだけで、サンプルが実行され、出力は組み込みのコンソール出力ウィンドウに表示されます。

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
**File** メニューをクリックし、**Open Project** を選択します。クローンまたはダウンロードしたフォルダーに移動します。**Examples** フォルダーのアイコンが Maven プロジェクトであることを示します。Examples を選択して開きます。

![todo:image_alt_text](netbeans_openproject.png)

プロジェクトが開かれ、依存関係が自動的にダウンロードされます。Projects タブから **source packages** 内のサンプルを参照できます。サンプルを実行するには、ファイルを右クリックして **Run File** を選択するだけで、サンプルが実行され、出力は組み込みのコンソール出力ウィンドウに表示されます。

![todo:image_alt_text](netbeans_run_example.png)

## **Maven ローカルリポジトリに Aspose.Slides ライブラリを追加**
**Aspose.Slides Examples** プロジェクトを IDE にインポートすると、Maven は自動的に [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/) から aspose.slides JAR ファイルをダウンロードします。インターネットにアクセスできない場合は、ローカルリポジトリに JAR を手動で追加できます。

### **mvn install**
[aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) をダウンロードし、展開して aspose.slides-version.jar を別の場所（例: C ドライブ）にコピーします。次のコマンドを実行します。
```
mvn install:install-file
    -Dfile=c:\aspose.slides-version.jar
    -DgroupId=com.aspose
    -DartifactId=aspose-slides
    -Dversion={version}
    -Dpackaging=jar
```


これで **aspose.slides** JAR が Maven ローカルリポジトリにコピーされました。

### **pom.xml**
インストール後、pom.xml に **aspose.slides** の座標を宣言するだけです。repositories タブに次のリポジトリを、dependencies タブに次の依存関係を追加します。
``` xml
<repository>
    <id>AsposeJavaAPI</id>
    <name>Aspose Java API</name>
    <url>https://releases.aspose.com/java/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>25.12</version>
    <classifier>jdk16</classifier>
</dependency>
```


### **Done**
ビルドすると、**aspose.slides** JAR がローカルリポジトリから取得できるようになります。

## **Contribute**
サンプルを追加または改善したい場合は、プロジェクトへの貢献を推奨します。このリポジトリ内のすべてのサンプルとデモプロジェクトはオープンソースであり、自由に自分のアプリケーションで使用できます。

貢献するには、リポジトリをフォークし、ソースコードを編集して Pull Request を送信できます。変更内容を確認し、有用と判断した場合はリポジトリに取り込む予定です。