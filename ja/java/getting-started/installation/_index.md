---
title: インストール
type: docs
weight: 70
url: /ja/java/installation/
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
- Java
- Aspose.Slides
description: "Aspose の Maven リポジトリまたは JAR ファイルから Aspose.Slides for Java をインストールし、Linux の前提条件を設定し、最初のプログラムでインストールを確認します。"
---
## **概要**

この記事では、Aspose.Slides for Java をプロジェクトに追加する方法について説明します。Aspose.Slides for Java は Aspose の独自 Maven リポジトリに公開されており、Maven Central にはありません。そのため、Maven プロジェクトではそのリポジトリを宣言する必要があります。また、JAR ファイルをダウンロードして自分でクラスパスに配置することも可能です。どちらの方法でも、ライブラリが正しく動作することを確認する簡単なプログラムで終了します。

Aspose.Slides for Java は Microsoft PowerPoint を必要としません。必要なプレゼンテーション ファイルはプログラムから自動的に生成されます。ただし、生成されたプレゼンテーションを表示するには、Microsoft PowerPoint や他のプレゼンテーション ビューアが必要になる場合があります。

## **前提条件**

- Java Development Kit (JDK)。本記事のプロジェクトおよびコマンドは JDK 11 以降が必要です。JDK 11 では、インストールを確認するプログラムが「WARNING: An illegal reflective access operation has occurred」という警告を出しますが、結果には影響せず無視して構いません。
- [Apache Maven](https://maven.apache.org/install.html)（Maven ルートを使用する場合）。
- Linux では fontconfig ライブラリと少なくとも 1 つのインストール済みフォントが必要です。[Linux](#linux) を参照してください。

## **Maven リポジトリからのインストール**

Aspose は Java ライブラリを独自の [Maven リポジトリ](https://releases.aspose.com/java/repo/com/aspose/) にホストしています。[Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) を Maven プロジェクトで使用するには、*pom.xml* に 2 つのエントリを追加します。

1. **Aspose の Maven リポジトリを宣言します。**

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
           <version>26.10</version>
           <classifier>jdk8</classifier>
       </dependency>
   </dependencies>
   ```

`jdk8` クラシファイアが必要です。これはライブラリの Java SE ビルドを選択します。`26.10` を、[リポジトリ](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) に記載されている最新バージョンに置き換えてください。リポジトリは各 JAR の隣に SHA-1 チェックサムファイルを公開しており、Maven はダウンロード時にこれを検証します。

### **インストールの確認**

新しいプロジェクトでセットアップを確認するには：

1. プロジェクト用のフォルダーを作成し、この *pom.xml* を保存します：

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
               <version>26.10</version>
               <classifier>jdk8</classifier>
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

   この *pom.xml* はリポジトリと依存関係に加えて、コンパイル対象の Java リリースを設定し、`mvn exec:java` が実行するクラス名を指定し、コンパイラプラグインを固定します。これは、デフォルトで使用される古いプラグインが `maven.compiler.release` 設定を無視するためです。

2. 最初の例を [プレゼンテーションの作成](/slides/ja/java/create-presentation/) から *src/main/java/HelloSlides.java* として保存します。

3. プロジェクトフォルダーで次のコマンドを実行します：

   ```bash
   mvn compile exec:java
   ```

Maven は Aspose.Slides for Java をダウンロードし、プログラムをコンパイルして実行します。プログラムはプロジェクトフォルダーに *new_presentation.pptx* を保存します。

## **Maven を使用せずに JAR ファイルを利用する**

1. リポジトリの [version folder](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.10/) から *aspose-slides-26.10-jdk8.jar* をダウンロードします。他のバージョンを使用する場合は、[repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) の該当フォルダーを開き、*‑jdk8.jar* で終わるファイルをダウンロードしてください。

2. 最初の例を [プレゼンテーションの作成](/slides/ja/java/create-presentation/) から *HelloSlides.java* として、JAR ファイルと同じフォルダーに保存します。

3. そのフォルダーで次のコマンドを実行します：

   ```bash
   java -cp aspose-slides-26.10-jdk8.jar HelloSlides.java
   ```

JDK は単一のソースファイルをコンパイルして実行し、プログラムはフォルダーに *new_presentation.pptx* を保存します。独自のアプリケーションでは、ビルドツールや IDE のクラスパスに JAR ファイルを追加してください。

## **Linux**

Aspose.Slides for Java は Java のフォントサポートを使用しますが、Linux では fontconfig ライブラリと少なくとも 1 つのインストール済みフォントが必要です。これらがないと、プレゼンテーションの保存時に「Fontconfig head is null, check your fonts or fonts configuration」というエラーが発生します。最小構成のサーバーやコンテナイメージではこれらが欠如していることがあり、例えば公式の Ubuntu コンテナイメージにはどちらも含まれていません。

Debian および Ubuntu では、次のコマンドで JDK、Maven、fontconfig、そして DejaVu フォントをインストールできます：

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

プレゼンテーションで使用するフォント、または適切な代替フォントもインストールしておかないと、テキストが正しく表示されません。

## **FAQ**

### Aspose.Slides が正しく統合されているかどうかを確認するには？

プロジェクトをビルドし、空の [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) をインスタンス化して新しい名前で保存します。例外が発生せずにファイルが作成されれば、ライブラリは正常に統合されています。

### 大規模なプレゼンテーションを処理する際のメモリ使用量を制限するには？

JVM のメモリ上限は必要な範囲だけに上げ、`finally` ブロック内で各 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) インスタンスに対して [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) を呼び出してキャッシュを速やかに解放します。これにより、メモリ不足エラーを防ぎ、バッチ処理中の全体的なメモリ使用量を予測可能に保ちます。

### 不要なエクスポート形式を除外して最終的な JAR サイズを縮小できますか？

現在の Aspose.Slides のリリースは単一のモノリシック ライブラリとして提供されているため、ビルド時に PDF や SVG など特定のエクスポータを無効化することはできません。