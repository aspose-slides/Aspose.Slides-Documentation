---
title: 例を実行する方法
type: docs
weight: 140
url: /php-java/how-to-run-the-examples/
---

## **GitHubからダウンロード**
Aspose.Slides for PHP via Javaのすべての例は、[Github](https://github.com/aspose-slides/Aspose.Slides-for-Java)でホストされています。お好きなGithubクライアントを使用してリポジトリをクローンするか、[こちら](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master)からZIPファイルをダウンロードできます。

ZIPファイルの内容をコンピュータの任意のフォルダに抽出します。すべての例は**Examples**フォルダにあります。

![todo:image_alt_text](examples_directory.png)

## **IDEに例をインポート**
このプロジェクトはMavenビルドシステムを使用しています。ほとんどのモダンなIDEはプロジェクトとその依存関係を簡単に開くまたはインポートできます。以下に、人気のあるIDEを使用して例をビルドし、実行する方法を示します。

### **IntelliJ IDEA**
**ファイル**メニューをクリックし、**開く**を選択します。プロジェクトフォルダに移動し、**pom.xml**ファイルを選択します。

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

プロジェクトが開き、依存関係が自動的にダウンロードされます。プロジェクトタブから、**src/main/java**フォルダ内の例をブラウズします。例を実行するには、ファイルを右クリックして「実行..」を選択します。例が実行され、出力が内蔵コンソール出力ウィンドウに表示されます。

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
**ファイル**メニューをクリックし、**インポート**を選択します。**Maven** - 既存のMavenプロジェクトを選択します。

![todo:image_alt_text](eclipse_import.png)

クローンまたはGitHubからダウンロードしたフォルダに移動し、**pom.xml**ファイルを選択します。プロジェクトが開き、依存関係が自動的にダウンロードされます。パッケージエクスプローラタブから、**src/main/java**フォルダ内の例をブラウズします。例を実行するには、ファイルを右クリックして**実行 As** - **Java アプリケーション**を選択します。例が実行され、出力が内蔵コンソール出力ウィンドウに表示されます。

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
**ファイル**メニューをクリックし、**プロジェクトを開く**を選択します。クローンまたはGitHubからダウンロードしたフォルダに移動します。**Examples**フォルダのアイコンは、Mavenプロジェクトであることを示します。Examplesを選択し、開きます。

![todo:image_alt_text](netbeans_openproject.png)

プロジェクトが開き、依存関係が自動的にダウンロードされます。プロジェクトタブから、**ソースパッケージ**内の例をブラウズします。例を実行するには、ファイルを右クリックして**ファイルを実行**を選択します。例が実行され、出力が内蔵コンソール出力ウィンドウに表示されます。

![todo:image_alt_text](netbeans_run_example.png)

## **Aspose.SlidesライブラリをMavenローカルリポジトリに追加**
**Aspose.Slides Examples**プロジェクトをIDEにインポートすると、Mavenは自動的に[Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/)からaspose.slides JARファイルをダウンロードします。インターネットにアクセスできない場合は、手動でJARをローカルリポジトリに追加できます。

### **mvn install**
[aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/)をダウンロードし、抽出してaspose.slides-version.jarをどこかにコピーします。例えば、Cドライブです。以下のコマンドを実行します：

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

これで、**aspose.slides** JARがあなたのMavenローカルリポジトリにコピーされました。

### **pom.xml**
インストール後、pom.xmlに**aspose.slides**の座標を宣言します。リポジトリタブに次のリポジトリを、依存関係タブに次の依存関係を追加します。

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
ビルドします。これで、**aspose.slides** JARをあなたのMavenローカルリポジトリから取得できるようになります。

## **貢献**
例を追加または改善したい場合は、プロジェクトへの貢献をお勧めします。このリポジトリのすべての例とショーケースプロジェクトはオープンソースであり、自分のアプリケーションで自由に使用できます。

貢献するには、リポジトリをフォークし、ソースコードを編集し、プルリクエストを提出できます。変更を確認し、有用であればリポジトリに含めます。