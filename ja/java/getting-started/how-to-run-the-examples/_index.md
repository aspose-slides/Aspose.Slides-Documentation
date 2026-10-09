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
description: "Aspose.Slides for Java のサンプルをすばやく実行するには、リポジトリをクローンし、パッケージを復元してから、PPT、PPTX、ODP の機能をビルドおよびテストします。"
---
## **GitHub から Aspose.Slides をダウンロード**
Aspose.Slides for Java のすべてのサンプルは [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java) にホストされています。好きな Github クライアントを使ってリポジトリをクローンするか、[こちら](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master)から ZIP ファイルをダウンロードできます。

ZIP ファイルの内容をコンピューター上の任意のフォルダーに展開します。すべてのサンプルは **Examples** フォルダーにあります。

![todo:image_alt_text](examples_directory.png)

## **IDE へサンプルをインポート**
プロジェクトは Maven ビルドシステムを使用しています。最新の IDE であればプロジェクトとその依存関係を簡単に開くまたはインポートできます。以下に、一般的な IDE を使用してサンプルをビルドおよび実行する方法を示します。

### **IntelliJ IDEA**
**File** メニューをクリックし、**Open** を選択します。プロジェクトフォルダーへ移動し、**pom.xml** ファイルを選択してください。

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

プロジェクトが開かれ、依存関係が自動的にダウンロードされます。Project タブから **src/main/java** フォルダー内のサンプルを参照できます。サンプルを実行するには、ファイルを右クリックして "Run .." を選択するだけで、実行され、出力が組み込みのコンソールウィンドウに表示されます。

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
**File** メニューをクリックし、**Import** を選択します。**Maven** - Existing Maven Projects を選びます。

![todo:image_alt_text](eclipse_import.png)

クローンまたはダウンロードしたフォルダーへ移動し、**pom.xml** ファイルを選択します。プロジェクトが開かれ、依存関係が自動的にダウンロードされます。Package Explorer タブから **src/main/java** フォルダー内のサンプルを参照できます。サンプルを実行するには、ファイルを右クリックし **Run As** - **Java Application** を選択するだけで、実行され、出力が組み込みのコンソールウィンドウに表示されます。

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
**File** メニューをクリックし、**Open Project** を選択します。クローンまたはダウンロードしたフォルダーへ移動します。**Examples** フォルダーのアイコンが Maven プロジェクトであることを示します。Examples を選択して開きます。

![todo:image_alt_text](netbeans_openproject.png)

プロジェクトが開かれ、依存関係が自動的にダウンロードされます。Projects タブから **source packages** 内のサンプルを参照できます。サンプルを実行するには、ファイルを右クリックし **Run File** を選択するだけで、実行され、出力が組み込みのコンソールウィンドウに表示されます。

![todo:image_alt_text](netbeans_run_example.png)

## **Aspose.Slides ライブラリを Maven ローカルリポジトリに追加**
IDE に **Aspose.Slides Examples** プロジェクトをインポートすると、Maven は [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/) から自動的に aspose.slides JAR ファイルをダウンロードします。インターネットにアクセスできない場合は、ローカルリポジトリに手動で JAR を追加できます。

### **mvn install**
[aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) をダウンロードし、展開して aspose.slides-version.jar を別の場所（例：C ドライブ）にコピーします。次のコマンドを実行してください:

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```

これで **aspose.slides** jar が Maven ローカルリポジトリにコピーされました。

### **pom.xml**
インストール後、pom.xml に **aspose.slides** の座標を宣言するだけです。repositories タブに以下のリポジトリを、dependencies タブに依存関係を追加してください。

``` xml
<repository>
    <id>AsposeJavaAPI</id>
    <name>Aspose Java API</name>
    <url>https://releases.aspose.com/java/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>26.10</version>
    <classifier>jdk8</classifier>
</dependency>
```

### **完了**
ビルドすると、**aspose.slides** jar が Maven ローカルリポジトリから取得できるようになります。

## **貢献**
サンプルを追加または改善したい場合は、プロジェクトへの貢献を推奨します。このリポジトリのすべてのサンプルおよびショーケースプロジェクトはオープンソースで、独自のアプリケーションで自由に使用できます。

貢献するには、リポジトリをフォークし、ソースコードを編集してプルリクエストを送信できます。変更内容を確認し、役立つと判断した場合はリポジトリに取り込む予定です。