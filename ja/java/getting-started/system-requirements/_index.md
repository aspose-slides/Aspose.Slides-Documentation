---
title: システム要件
type: docs
weight: 60
url: /ja/java/system-requirements/
keywords:
- システム要件
- サポートプラットフォーム
- Java バージョン
- JDK
- JRE
- fontconfig
- フォント
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "インストール前に Aspose.Slides for Java が必要とするものを確認してください：サポートされている Java バージョンとオペレーティングシステム、そして Linux が必要とするフォントライブラリとフォントです。"
---
## **イントロダクション**

Aspose.Slides for Java は単体で動作するライブラリです。Microsoft PowerPoint や Microsoft Office は不要です。単一の JAR ファイルで、Aspose の Maven リポジトリで公開されています。この JAR ファイルには Java クラスとリソースだけが含まれ、ネイティブ ライブラリはなく、他のライブラリへの依存関係も宣言されていません。そのため、サポートされた Java ランタイムが利用できるすべての OS とプロセッサで同じファイルが動作します。

このドキュメントでは、サポートされている Java バージョンとオペレーティング システム、Linux が必要とするフォント ライブラリとフォントを列挙し、最後に環境を確認する簡単なプログラムを示します。ライブラリをプロジェクトに追加するには、[インストール](/slides/ja/java/installation/) を参照してください。

## **サポートされている Java バージョン**

Aspose.Slides for Java は Java 8 以降、JDK または JRE 上で動作します。長期サポート版の Java 8、11、17、21、25 に加え、Java 26、27 などの後続リリースもサポート対象です。Java ランタイムはベンダーに依存せず、Eclipse Temurin、Amazon Corretto、Oracle、Linux ディストリビューションの OpenJDK などから取得できます。

これらのバージョンでは `--add-opens` などの JVM オプションは不要です。Java 11 では「WARNING: An illegal reflective access operation has occurred」という警告が出ますが、結果には影響しません。

{{% alert color="warning" title="Warning" %}}
Java 6 と Java 7 は廃止予定です。Aspose.Slides for Java 26.9 は引き続き動作しますが、廃止警告が表示されます。バージョン 26.10 以降は Java 8 が最低要件となり、Java 6 と Java 7 はサポートされなくなります。
{{% /alert %}}

Maven プロジェクトと [インストール](/slides/ja/java/installation/) のコマンドは JDK 11 以降が必要です。Java 8 を使用する場合は、[セットアップの確認](#setups-%E7%A2%BA%E8%AA%8D) に示す手順でコンパイル＆実行してください。

## **サポートされているオペレーティングシステム**

JAR ファイルにネイティブコードが含まれないため、Aspose.Slides for Java は Windows、Linux、macOS のすべてで、Java ランタイムがサポートする任意のアーキテクチャ（例: x64、ARM64）で動作します。Windows では Java ランタイムだけが要件です。Linux では、[Linux](#linux) で説明するフォント ライブラリとフォントが追加で必要です。

## **Linux**

Aspose.Slides for Java は Java ランタイムのフォントサポートを利用してテキストのレイアウトと描画を行います。Linux ではこのサポートに `fontconfig` ライブラリと少なくとも 1 つのフォントが必要です。公式の Linux ディストリビューションのコンテナ イメージにはこれらが含まれていないことが多く、含まれていない場合、[プレゼンテーションの作成](/slides/ja/java/create-presentation/) の最初のサンプルがプレゼンテーションの保存時に空ファイルを残し、次のエラーを報告します。

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

公式の `eclipse-temurin` コンテナ イメージ（Ubuntu と Alpine Linux 用）にはすでに `fontconfig` と DejaVu フォントが含まれているため、追加インストールは不要です。他の環境では以下のパッケージをインストールしてください。Debian、Ubuntu、Red Hat 系のコマンドは `sudo` を使用しますが、Dockerfile では `RUN` 命令内で `sudo` なしで実行します。DejaVu フォントだけで Aspose.Slides は動作します。プレゼンテーションで使用するフォントは [フォント](#fonts) を参照してください。

### **Debian と Ubuntu**

`apt-get` のデフォルト設定で Debian または Ubuntu のパッケージから Java をインストールすると、[インストール](/slides/ja/java/installation/#linux) のコマンドと同様に `fontconfig`、DejaVu フォント、必要な HarfBuzz ライブラリが自動的にインストールされ、他に何も必要ありません。

別のソース（例: Eclipse Temurin アーカイブ）から Java ランタイムを入手した場合は、以下のコマンドで `fontconfig` と DejaVu フォントをインストールします。

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Dockerfile で `openjdk-21-jdk-headless` や `default-jdk-headless` などの Debian/Ubuntu Java パッケージを `--no-install-recommends` オプション付きでインストールすると、上記 3 つが省かれます。その場合は前述のコマンドで `fontconfig` と DejaVu フォント、さらに HarfBuzz をインストールしてください。

```bash
sudo apt-get install -y libharfbuzz0b
```

HarfBuzz が無いと、これらの Java パッケージは `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless` と出力し、保存時に `UnsatisfiedLinkError` が発生して `libharfbuzz.so.0` を開けません。

### **Red Hat Enterprise Linux**

Red Hat Enterprise Linux の `java-<version>-openjdk-headless` パッケージは `fontconfig` をインストールしません。以下のコマンドで `fontconfig` と DejaVu フォントを同時にインストールしてください。

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

完全版の `java-<version>-openjdk` パッケージは依存関係として `fontconfig` とフォントをインストールします。Amazon Linux 2023 の `java-21-amazon-corretto-headless` などの Amazon Corretto パッケージも同様です。

### **Alpine Linux**

Alpine Linux ベースの Dockerfile では、以下のコマンドで `fontconfig` と DejaVu フォントをインストールします。

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

現在の Alpine リリースでは `ttf-dejavu` が `font-dejavu` パッケージを提供します。`openjdk<version>-jre` または `openjdk<version>-jdk`（例: `openjdk25-jdk`）で Java をインストールしてください。Alpine の `openjdk<version>-jre-headless` パッケージには Java のフォントライブラリが含まれないため、フォントをインストールしていても `UnsatisfiedLinkError: no fontmanager in system library path` が発生します。

### **フォント**

テキストを正しいフォントとメトリックで描画するには、プレゼンテーションで使用するフォント（または適切な代替フォント）をシステムにインストールするか、アプリケーションでロードする必要があります。詳しくは [フォントのデプロイ](/slides/ja/java/deploy-fonts/)、[フォント置換](/slides/ja/java/font-substitution/)、[カスタム フォント](/slides/ja/java/custom-font/) を参照してください。

## **セットアップの確認**

ライブラリと必要要件が正しく配置されているか確認するため、プレゼンテーションを保存しスライドを画像にレンダリングするサンプル プログラムを実行します。保存とレンダリングは Java ランタイムのフォントサポートを使用します。

以下のコードを *CheckSetup.java* として、Aspose.Slides の JAR ファイルがあるフォルダーに保存してください。JAR の入手方法は [Maven なしで JAR ファイルを使用する](/slides/ja/java/installation/#use-the-jar-file-without-maven) を参照してください。

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // 最初のスライドにテキスト付きの矩形を追加し、プレゼンテーションを保存します。
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // スライドを1ポイントあたり1ピクセルでレンダリングし、画像を保存します。
            IImage image = slide.getImage(1f, 1f);
            try {
                image.save("hello.png", ImageFormat.Png);
            } finally {
                image.dispose();
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

JDK 11 以上がある環境では、同フォルダーで次のコマンドを実行します。JAR の名前が異なる場合はコマンド内の名前を置き換えてください。

```bash
java -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
```

Java 8 または JRE のみがある環境では、JDK の `javac` でコンパイルし、コンパイル済みクラスを実行します。Linux と macOS の場合は次のように実行します。

```bash
javac -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
java -cp aspose-slides-26.10-jdk8.jar:. CheckSetup
```

Windows では同じ `javac` コマンドを実行し、その後クラス パス区切り文字としてセミコロンを使用してクラスを実行します。PowerShell がセミコロンでコマンドが終了したと解釈しないよう、引用符はそのまま残してください: `java -cp "aspose-slides-26.10-jdk8.jar;." CheckSetup`.

プログラムは最初のスライドにテキスト付きの矩形を追加し、[save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) メソッドで *hello.pptx* に保存します。その後、[getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-) でスライドを画像化し、[IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) を使って *hello.png* として [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/) 形式で保存します。スケール係数 1 はポイントごとに 1 ピクセルをレンダリングするため、既定の 720 × 540 ポイントのスライドが 720 × 540 ピクセルの画像となり、矩形内にテキストが表示されます。ライセンスがない場合、両ファイルには評価版の透かしが入ります; 詳細は [ライセンス](/slides/ja/java/licensing/) をご覧ください。要件が不足していると、[Linux](#linux) で説明したエラーのいずれかでプログラムが停止します。

## **開発ツール**

サポート対象の Java バージョンの任意の JDK を使用して、Aspose.Slides を利用するアプリケーションをビルドできます。Apache Maven を Aspose の Maven リポジトリと組み合わせて使用する方法は [インストール](/slides/ja/java/installation/) に記載されています。他のビルドツールでも Maven リポジトリが利用可能です。JAR ファイルを IDE やビルドツールのクラスパスに手動で追加することもできます。

## **FAQ**

**Microsoft PowerPoint をインストールする必要がありますか？**

いいえ、PowerPoint は必要ありません。Aspose.Slides は [作成](/slides/ja/java/create-presentation/)、変更、[変換](/slides/ja/java/convert-presentation/)、および [レンダリング](/slides/ja/java/convert-powerpoint-to-png/) 用の単体エンジンです。

**Linux サーバーでディスプレイやデスクトップ環境は必要ですか？**

いいえ。Aspose.Slides は X サーバーやディスプレイを必要としないため、サーバーやコンテナ上でも動作します。Linux では [Linux](#linux) で説明したフォント ライブラリとフォントだけが必要です。

**正しいレンダリングのために必要なフォントは何ですか？**

プレゼンテーションで使用したフォント、または適切な [代替フォント](/slides/ja/java/font-substitution/) が利用可能である必要があります。Linux と macOS では、プレゼンテーションで必要なフォント パッケージをインストールして一貫したレンダリングを実現してください。

**カスタム フォントが Linux でフォールバックや欠落テキストとして表示されるのはなぜですか？**

フォント ファイルの name テーブルに不整合や破損があると、Linux のフォントマッチングスタック（FreeType/fontconfig）が無効なレコードを選択し、フォントが解決できなくなります。name テーブルが修正されたバージョンのフォントを使用するか、一貫した代替フォントをインストールすれば解決します。