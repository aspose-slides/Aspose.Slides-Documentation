---
title: インストール
type: docs
weight: 70
url: /ja/java/installation/
keywords:
- Aspose.Slides のインストール
- Aspose.Slides のダウンロード
- Aspose.Slides の使用
- Aspose.Slides のインストール
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose の Maven リポジトリまたは JAR ファイルから Java 用 Aspose.Slides をインストールし、Linux の前提条件を設定し、最初のプログラムでインストールを確認します。"
---
## **概要**

このページでは、Aspose.Slides for Java をプロジェクトに追加する方法を説明します。Aspose.Slides for Java は Aspose が提供する Maven リポジトリに掲載されており、Maven Central にはありません。そのため、Maven プロジェクトではそのリポジトリを宣言する必要があります。また、JAR ファイルをダウンロードしてクラスパスに配置することもできます。どちらの場合も、ライブラリが動作することを確認する簡単なプログラムで終了します。

Aspose.Slides for Java は Microsoft PowerPoint を必要としません。必要なプレゼンテーションファイルはプログラムで生成されます。ただし、生成されたプレゼンテーションを表示するには Microsoft PowerPoint または別のプレゼンテーションビューアが必要になる場合があります。

## **前提条件**

- Java Development Kit (JDK)。本記事のプロジェクトとコマンドは JDK 11 以降が必要です。JDK 11 でインストールを確認するプログラムを実行すると「WARNING: An illegal reflective access operation has occurred」という警告が表示されますが、結果には影響せず無視できます。
- [Apache Maven](https://maven.apache.org/install.html)、Maven ルートを使用する場合。
- Linux の場合、fontconfig ライブラリと少なくとも 1 つのフォントがインストールされている必要があります。詳細は [Linux](#linux) を参照してください。

## **Maven リポジトリからインストール**

Aspose は自社の [Maven リポジトリ](https://releases.aspose.com/java/repo/com/aspose/) に Java ライブラリを掲載しています。[Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) を Maven プロジェクトで使用するには、*pom.xml* に以下の 2 つのエントリを追加します。

1. **Aspose Maven リポジトリを宣言します。**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Aspose.Slides for Java の依存関係を追加します。**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.9</version>
           <classifier>jdk16</classifier>
       </dependency>
   </dependencies>
   ```

`jdk16` クラシファイアが必要です。これはライブラリの Java SE ビルドを選択します。`26.9` の部分は、[リポジトリ](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) に掲載されている最新バージョンに置き換えてください。このリポジトリは各 JAR の横に SHA-1 チェックサムファイルを公開しており、Maven はダウンロード時にそれを検証します。

### **インストールの確認**

新しいプロジェクトで設定を確認する手順:

1. プロジェクト用のフォルダーを作成し、以下の *pom.xml* を保存します。

   ```xml
   <project xmlns="http://maven.apache.org/POM/4.0.0">
       <modelVersion>4.0.0</modelVersion>
       <groupId>com.example</groupId>
       <artifactId>hello-slides</artifactId>
       <version>1.0</version>

       <properties>
           <maven.compiler.release>11</maven.compiler.release>
           <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
           <exec.mainClass>HelloSlides</exec.mainClass>
       </properties>

       <repositories>
           <repository>
               <id>AsposeJavaAPI</id>
               <name>Aspose Java API</name>
               <url>https://releases.aspose.com/java/repo/</url>
           </repository>
       </repositories>

       <dependencies>
           <dependency>
               <groupId>com.aspose</groupId>
               <artifactId>aspose-slides</artifactId>
               <version>26.9</version>
               <classifier>jdk16</classifier>
           </dependency>
       </dependencies>

       <build>
           <plugins>
               <plugin>
                   <groupId>org.apache.maven.plugins</groupId>
                   <artifactId>maven-compiler-plugin</artifactId>
                   <version>3.15.0</version>
               </plugin>
           </plugins>
       </build>
   </project>
   ```

   この *pom.xml* にはリポジトリと依存関係に加えて、コンパイル対象の Java リリースを指定し、`mvn exec:java` が実行するクラス名を設定し、古いプラグインがデフォルトで無視する `maven.compiler.release` 設定を有効にするためにコンパイラプラグインを固定しています。

2. 最初のサンプルを [Create Presentations](/slides/ja/java/create-presentation/) から取得し、*src/main/java/HelloSlides.java* として保存します。

3. プロジェクトフォルダーで次を実行します。

   ```bash
   mvn compile exec:java
   ```

Maven が Aspose.Slides for Java をダウンロードし、プログラムをコンパイルして実行します。プログラムは *new_presentation.pptx* をプロジェクトフォルダーに保存します。

## **Maven を使用しないで JAR ファイルを使用**

1. リポジトリの [バージョン フォルダー](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.9/) から *aspose-slides-26.9-jdk16.jar* をダウンロードします。別バージョンを使用する場合は、[リポジトリ](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) の該当フォルダーを開き、`-jdk16.jar` で終わるファイルをダウンロードしてください。
2. 最初のサンプルを [Create Presentations](/slides/ja/java/create-presentation/) から取得し、JAR ファイルと同じフォルダーに *HelloSlides.java* として保存します。
3. そのフォルダーで次を実行します。

   ```bash
   java -cp aspose-slides-26.9-jdk16.jar HelloSlides.java
   ```

JDK が単一ソースファイルをコンパイルして実行し、プログラムは *new_presentation.pptx* をそのフォルダーに保存します。自分のアプリケーションでは、ビルドツールや IDE のクラスパスに JAR ファイルを追加してください。

## **Linux**

Aspose.Slides for Java は Java のフォントサポートを利用しますが、Linux では fontconfig ライブラリと少なくとも 1 つのインストール済みフォントが必要です。これらがないと、プレゼンテーションの保存時に「Fontconfig head is null, check your fonts or fonts configuration」というエラーが発生します。最小構成のサーバーやコンテナイメージでは両方が欠如していることがあり、例えば公式の Ubuntu コンテナイメージにはどちらも含まれていません。

Debian と Ubuntu では、次のコマンドで JDK、Maven、fontconfig、DejaVu フォントをインストールできます。

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

プレゼンテーションで使用するフォント、または適切な代替フォントもインストールしておかないと、テキストが正しく表示されません。

## **FAQ**

### Aspose.Slides が正しく統合されているかどうか、どのように確認できますか？

プロジェクトをビルドし、空の [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) をインスタンス化して新しい名前で保存します。例外がスローされずにファイルが作成されれば、ライブラリは正常に統合されています。

### 大きなプレゼンテーションを処理する際のメモリ消費を抑えるにはどうすればよいですか？

必要な分だけ JVM のメモリ上限を上げ、`finally` ブロック内で各 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) インスタンスに対して [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) を呼び出してキャッシュを速やかに解放します。これによりメモリ不足エラーを防ぎ、バッチ処理中のメモリ使用量を予測しやすくなります。

### 不要なエクスポート形式を除外して最終的な JAR サイズを小さくできますか？

現在の Aspose.Slides のリリースは単一のモノリシックライブラリとして提供されており、ビルド時に PDF や SVG など特定のエクスポート機能を無効化することはできません。