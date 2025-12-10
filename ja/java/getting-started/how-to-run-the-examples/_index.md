---
title: サンプルの実行方法
type: docs
weight: 140
url: /ja/java/how-to-run-the-examples/
keywords:
- サンプル
- ソフトウェア要件
- GitHub
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のサンプルを素早く実行するには、リポジトリをクローンし、パッケージを復元してから、PPT、PPTX、ODP の機能をビルドおよびテストします。"
---

## **GitHub から Aspose.Slides をダウンロード**
すべての Aspose.Slides for Java のサンプルは [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java) にホストされています。お気に入りの Github クライアントでリポジトリをクローンするか、[here](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master) から ZIP ファイルをダウンロードできます。

ZIP ファイルの内容をコンピューター上の任意のフォルダーに展開します。すべてのサンプルは **Examples** フォルダーにあります。

![todo:image_alt_text](examples_directory.png)

## **IDE にサンプルをインポート**
このプロジェクトは Maven ビルドシステムを使用しています。最新の IDE であればプロジェクトとその依存関係を簡単に開くかインポートできます。以下に、代表的な IDE を使用してサンプルをビルドおよび実行する方法を示します。

### **IntelliJ IDEA**
**File** メニューをクリックし、**Open** を選択します。プロジェクト フォルダーに移動し、**pom.xml** ファイルを選択します。

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

プロジェクトが開き、依存関係が自動的にダウンロードされます。**Project** タブで **src/main/java** フォルダー内のサンプルを参照できます。サンプルを実行するには、ファイルを右クリックして **Run ..** を選択します。サンプルが実行され、出力は組み込みのコンソールウィンドウに表示されます。

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
**File** メニューをクリックし、**Import** を選択します。**Maven** - **Existing Maven Projects** を選びます。

![todo:image_alt_text](eclipse_import.png)

クローンまたはダウンロードしたフォルダーに移動し、**pom.xml** ファイルを選択します。プロジェクトが開き、依存関係が自動的にダウンロードされます。**Package Explorer** タブで **src/main/java** フォルダー内のサンプルを参照できます。サンプルを実行するには、ファイルを右クリックして **Run As** - **Java Application** を選択します。サンプルが実行され、出力は組み込みのコンソールウィンドウに表示されます。

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
**File** メニューをクリックし、**Open Project** を選択します。クローンまたはダウンロードしたフォルダーに移動します。**Examples** フォルダーのアイコンが Maven プロジェクトであることを示します。Examples を選択して開きます。

![todo:image_alt_text](netbeans_openproject.png)

プロジェクトが開き、依存関係が自動的にダウンロードされます。**Projects** タブで **source packages** 内のサンプルを参照できます。サンプルを実行するには、ファイルを右クリックして **Run File** を選択します。サンプルが実行され、出力は組み込みのコンソールウィンドウに表示されます。

![todo:image_alt_text](netbeans_run_example.png)

## **Maven ローカルリポジトリに Aspose.Slides ライブラリを追加**
IDE に **Aspose.Slides Examples** プロジェクトをインポートすると、Maven は自動的に [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/) から aspose.slides JAR ファイルをダウンロードします。インターネットにアクセスできない場合は、JAR を手動でローカルリポジトリに追加できます。

### **mvn install**
[aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) をダウンロードし、解凍して aspose.slides‑version.jar を任意の場所（例: C ドライブ）にコピーします。次のコマンドを実行してください:
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
インストール後、pom.xml に **aspose.slides** の座標を宣言するだけです。repositories タブに以下のリポジトリを、dependencies タブに以下の依存関係を追加してください。
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
```


### **Done**
ビルドすれば、**aspose.slides** JAR を Maven ローカルリポジトリから取得できるようになります。

## **Contribute**
サンプルを追加または改良したい場合は、ぜひプロジェクトに貢献してください。このリポジトリ内のすべてのサンプルとショーケース プロジェクトはオープンソースで、独自のアプリケーションで自由に使用できます。

貢献するには、リポジトリをフォークし、ソースコードを編集して Pull Request を送信してください。変更内容を確認し、役立つと判断した場合はリポジトリに取り込みます。