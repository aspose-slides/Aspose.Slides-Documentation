---
title: サンプルの実行方法
type: docs
weight: 140
url: /java/how-to-run-the-examples/
---

## **GitHubからのダウンロード**
Aspose.Slides for Javaのすべてのサンプルは[Github](https://github.com/aspose-slides/Aspose.Slides-for-Java)にホストされています。お好みのGithubクライアントを使用してリポジトリをクローンするか、[こちら](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master)からZIPファイルをダウンロードできます。

ZIPファイルの内容をコンピュータの任意のフォルダーに展開します。すべてのサンプルは**Examples**フォルダーにあります。

![todo:image_alt_text](examples_directory.png)

## **IDEへのサンプルのインポート**
プロジェクトはMavenビルドシステムを使用しています。任意の最新のIDEはプロジェクトとその依存関係を簡単に開いたりインポートしたりできます。以下に、一般的なIDEを使用してサンプルをビルドして実行する方法を示します。

### **IntelliJ IDEA**
**ファイル**メニューをクリックし、**開く**を選択します。プロジェクトフォルダーに移動し、**pom.xml**ファイルを選択します。

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

プロジェクトが開かれ、依存関係が自動的にダウンロードされます。プロジェクトタブから、**src/main/java**フォルダー内のサンプルを参照します。サンプルを実行するには、ファイルを右クリックし、「実行..」を選択します。サンプルが実行され、出力が内蔵のコンソール出力ウィンドウに表示されます。

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
**ファイル**メニューをクリックし、**インポート**を選択します。**Maven** - 既存のMavenプロジェクトを選択します。

![todo:image_alt_text](eclipse_import.png)

クローンまたはGitHubからダウンロードしたフォルダーに移動し、**pom.xml**ファイルを選択します。プロジェクトが開かれ、依存関係が自動的にダウンロードされます。パッケージエクスプローラタブから、**src/main/java**フォルダー内のサンプルを参照します。サンプルを実行するには、ファイルを右クリックし、**実行として** - **Javaアプリケーション**を選択します。サンプルが実行され、出力が内蔵のコンソール出力ウィンドウに表示されます。

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
**ファイル**メニューをクリックし、**プロジェクトを開く**を選択します。クローンまたはGitHubからダウンロードしたフォルダーに移動します。**Examples**フォルダーのアイコンは、Mavenプロジェクトであることを示します。Examplesを選択し、開きます。

![todo:image_alt_text](netbeans_openproject.png)

プロジェクトが開かれ、依存関係が自動的にダウンロードされます。プロジェクトタブから、**ソースパッケージ**内のサンプルを参照します。サンプルを実行するには、ファイルを右クリックし、**ファイルを実行**を選択します。サンプルが実行され、出力が内蔵のコンソール出力ウィンドウに表示されます。

![todo:image_alt_text](netbeans_run_example.png)

## **Aspose.SlidesライブラリをMavenローカルリポジトリに追加する**
**Aspose.Slides Examples**プロジェクトをIDEにインポートすると、Mavenは自動的に[Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/)からaspose.slides JARファイルをダウンロードします。インターネットにアクセスできない場合は、手動でJARをローカルリポジトリに追加できます。

### **mvn install**
[aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)をダウンロードし、展開してaspose.slides-version.jarを他の場所、例えばCドライブにコピーします。次のコマンドを実行します：

```
mvn install:install-file
    -Dfile=c:\aspose.slides-version.jar
    -DgroupId=com.aspose
    -DartifactId=aspose-slides
    -Dversion={version}
    -Dpackaging=jar
```

これで、**aspose.slides** JARがMavenローカルリポジトリにコピーされました。

### **pom.xml**
インストール後、pom.xmlで**aspose.slides**の座標を宣言します。リポジトリタブに次のリポジトリを追加し、依存関係タブに依存関係を追加します。

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

### **完了**
ビルドします。これで、**aspose.slides** JARがMavenローカルリポジトリから取得できるようになります。

## **貢献**
サンプルを追加したり改善したりしたい場合は、プロジェクトへの貢献をお勧めします。このリポジトリ内のすべてのサンプルとショーケースプロジェクトはオープンソースであり、自由に自分のアプリケーションで使用できます。

貢献するには、リポジトリをフォークし、ソースコードを編集し、プルリクエストを送信できます。変更を確認し、有用であればリポジトリに含めます。