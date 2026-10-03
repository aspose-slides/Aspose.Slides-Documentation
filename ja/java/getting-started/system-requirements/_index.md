---
title: システム要件
type: docs
weight: 60
url: /ja/java/system-requirements/
keywords:
- システム要件
- サポート対象プラットフォーム
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
## **はじめに**

Aspose.Slides for Java はスタンドアロンのライブラリです。Microsoft PowerPoint や Microsoft Office は必要ありません。単一の JAR ファイルで、Aspose の Maven リポジトリに公開されています。JAR ファイルには Java クラスとリソースのみが含まれ、ネイティブライブラリはなく、他のライブラリへの依存関係も宣言していません。そのため、サポートされている Java ランタイムが提供されているすべての OS とプロセッサで同じファイルが動作します。

この記事では、サポートされている Java バージョンとオペレーティングシステム、Linux が必要とするフォントライブラリとフォントを列記し、設定を確認する簡単なプログラムで締めくくります。ライブラリをプロジェクトに追加する手順は [インストール](/slides/ja/java/installation/) を参照してください。

## **サポートされている Java バージョン**

Aspose.Slides for Java は JDK または JRE があれば Java 8 以降で動作します。これには長期サポート版の Java 8、11、17、21、25 と、Java 26、27 などの以降のリリースが含まれます。Java ランタイムは Eclipse Temurin、Amazon Corretto、Oracle、または Linux ディストリビューションの OpenJDK パッケージなど、任意のベンダーから入手可能です。

Aspose.Slides はこれらのバージョンで `--add-opens` のような JVM オプションを必要としません。Java 11 では「WARNING: An illegal reflective access operation has occurred」という警告が出ますが、結果には影響しません。

{{% alert color="warning" title="Warning" %}}
Java 6 と Java 7 は非推奨です。Aspose.Slides for Java 26.9 はまだ動作しますが、非推奨警告が表示されます。バージョン 26.10 以降では Java 8 が最低要件となり、Java 6 と Java 7 はサポート対象外です。
{{% /alert %}}

[インストール](/slides/ja/java/installation/) の Maven プロジェクトとコマンドは JDK 11 以降が必要です。Java 8 を使用する場合は、[セットアップの確認](#check-your-setup) に示すようにプログラムをコンパイルして実行してください。

## **サポートされているオペレーティングシステム**

JAR ファイルにネイティブコードが含まれないため、Aspose.Slides for Java は Windows、Linux、macOS のいずれでも、Java ランタイムがサポートする任意のアーキテクチャ（例: x64、ARM64）で動作します。Windows では Java ランタイムのみが要件です。Linux では、Java のフォントサポートに加えて [Linux](#linux) で説明したフォントライブラリとフォントが必要です。

## **Linux**

Aspose.Slides for Java は Java ランタイムのフォントサポートを使用してテキストの配置と描画を行います。Linux ではこのサポートに fontconfig ライブラリと最低 1 つのフォントが必要です。公式の Linux ディストリビューションのコンテナイメージはこれらが含まれていないことが多く、含まれていない場合、[プレゼンテーションの作成](/slides/ja/java/create-presentation/) の最初の例が保存時に空ファイルを作成し、次のエラーを報告します。

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

公式の `eclipse-temurin` コンテナイメージ（Ubuntu と Alpine Linux 用）には既に fontconfig と DejaVu フォントが含まれているため、追加インストールは不要です。その他の環境では以下のパッケージをインストールしてください。Debian、Ubuntu、Red Hat のコマンドは `sudo` を使用しますが、Dockerfile では `RUN` 命令内で `sudo` なしで実行します。DejaVu フォントだけで Aspose.Slides は実行可能です。プレゼンテーションで使用するフォントは [フォント](#fonts) を参照してください。

### **Debian と Ubuntu**

デフォルトの `apt-get` 設定で Debian または Ubuntu のパッケージから Java をインストールすると、[インストール](/slides/ja/java/installation/#linux) のコマンドと同様に、Java パッケージが fontconfig ライブラリ、DejaVu フォント、そしてこれらの Java パッケージが必要とする HarfBuzz ライブラリもインストールし、他に何も必要ありません。

別のソース（例: Eclipse Temurin アーカイブ）から Java ランタイムを入手した場合は、fontconfig と DejaVu フォントをインストールします。

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Dockerfile で `openjdk-21-jdk-headless` や `default-jdk-headless` などの Debian／Ubuntu Java パッケージを `--no-install-recommends` オプション付きでインストールすると、上記 3 つがスキップされます。その場合は上記コマンドで fontconfig と DejaVu フォントをインストールし、さらに HarfBuzz もインストールしてください。

```bash
sudo apt-get install -y libharfbuzz0b
```

HarfBuzz がないと、これらの Java パッケージは `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless` と表示し、`libharfbuzz.so.0` が開けないという `UnsatisfiedLinkError` が発生して保存に失敗します。

### **Red Hat Enterprise Linux**

Red Hat Enterprise Linux の `java-<version>-openjdk-headless` パッケージは fontconfig ライブラリをインストールしません。fontconfig と DejaVu フォントを同時にインストールしてください。

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

フルパッケージの `java-<version>-openjdk` は fontconfig とフォントを依存関係としてインストールします。Amazon Linux 2023 の `java-21-amazon-corretto-headless` などの Amazon Corretto パッケージも同様です。

### **Alpine Linux**

Alpine Linux をベースにした Dockerfile では、fontconfig と DejaVu フォントをインストールします。

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

現在の Alpine リリースでは `ttf-dejavu` が `font-dejavu` パッケージを提供します。Java は `openjdk<version>-jre` または `openjdk<version>-jdk`（例: `openjdk25-jdk`）でインストールしてください。Alpine の `openjdk<version>-jre-headless` パッケージは Java のフォントライブラリを含まないため、フォントをインストールしていても `UnsatisfiedLinkError: no fontmanager in system library path` が発生し、プログラムが失敗します。

### **フォント**

テキストを正しいフォントとメトリクスで描画するには、プレゼンテーションで使用するフォント（もしくは適切な代替フォント）をシステムにインストールするか、アプリケーションでロードする必要があります。詳細は [フォントのデプロイ](/slides/ja/java/deploy-fonts/)、[フォント置換](/slides/ja/java/font-substitution/)、および [カスタムフォント](/slides/ja/java/custom-font/) を参照してください。

## **セットアップの確認**

ライブラリとその要件が正しく配置されているか確認するため、プレゼンテーションを保存しスライドを画像にレンダリングするプログラムを実行します。保存とレンダリングは Java ランタイムのフォントサポートを利用します。Linux の要件は上記で説明した通りです。

以下のコードを *CheckSetup.java* として、Aspose.Slides の JAR ファイルがあるフォルダーに保存してください。JAR ファイルのダウンロード方法は [Maven なしで JAR を使用](/slides/ja/java/installation/#use-the-jar-file-without-maven) を参照してください。

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

            // スライドをポイントあたり1ピクセルでレンダリングし、画像を保存します。
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

JDK 11 以降を使用する場合は、以下のコマンドで同フォルダー内でプログラムを実行します。JAR ファイル名が異なる場合はコマンド内の名前を変更してください。

```bash
java -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
```

Java 8 を使用するか、JRE のみがある環境では、JDK の `javac` でコンパイルし、コンパイル済みクラスを実行します。Linux と macOS では次のように実行します。

```bash
javac -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
java -cp aspose-slides-26.9-jdk16.jar:. CheckSetup
```

Windows では同じ `javac` コマンドを実行し、クラスパス区切り文字をセミコロンにします。PowerShell がセミコロンをコマンドの終端と解釈しないように、引用符は残してください: `java -cp "aspose-slides-26.9-jdk16.jar;." CheckSetup`.

プログラムは最初のスライドにテキスト入りの矩形を追加し、[save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-java.lang.String-int-) メソッドで *hello.pptx* として保存します。その後、[getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slide/#getImage-float-float-) でスライドをレンダリングし、[IImage.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/#save-java.lang.String-int-) を使って *hello.png* を [ImageFormat.Png](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imageformat/) 形式で保存します。スケールファクタ 1 はポイントあたり 1 ピクセルを描画するため、デフォルトの 720 × 540 ポイントスライドは 720 × 540 ピクセル画像になり、矩形内にテキストが表示されます。ライセンスがない場合、両ファイルには評価用の透かしが付加されます。詳細は [ライセンス](/slides/ja/java/licensing/) を参照してください。要件が欠けていると、[Linux](#linux) で説明したエラーのいずれかでプログラムが停止します。

## **開発ツール**

サポート対象の Java バージョンの任意の JDK を使用して、Aspose.Slides を利用したアプリケーションをビルドできます。Apache Maven と Aspose の Maven リポジトリを利用する方法は [インストール](/slides/ja/java/installation/) に記載されています。他の Maven リポジトリ対応のビルドツールでも構いません。IDE やビルドツールのクラスパスに JAR ファイルを手動で追加することもできます。

## **FAQ**

**変換やレンダリングに Microsoft PowerPoint のインストールは必要ですか？**

いいえ、PowerPoint は必要ありません。Aspose.Slides はプレゼンテーションの[作成](/slides/ja/java/create-presentation/)、変更、[変換](/slides/ja/java/convert-presentation/)、および[レンダリング](/slides/ja/java/convert-powerpoint-to-png/) のためのスタンドアロンエンジンです。

**Linux サーバーで Aspose.Slides for Java はディスプレイやデスクトップ環境が必要ですか？**

いいえ。Aspose.Slides は X サーバーやディスプレイを必要としないため、サーバーやコンテナ上でも動作します。Linux では [Linux](#linux) で説明したフォントライブラリとフォントだけが必要です。

**正しいレンダリングのために必要なフォントは何ですか？**

プレゼンテーションで使用されているフォント、または適切な[代替フォント](/slides/ja/java/font-substitution/) が利用可能である必要があります。Linux と macOS では、プレゼンテーションが期待通りに表示されるよう、必要なフォントパッケージをインストールしてください。

**カスタムフォントが Linux でフォールバックまたは欠損テキストとして表示されるのはなぜですか？**

フォントファイルの name テーブルエントリが不整合または破損していると、Linux のフォントマッチングスタック（FreeType/fontconfig）が無効なレコードを選択し、フォントが解決できなくなります。修正された name テーブルを持つフォントバージョンを使用するか、一貫した代替フォントをインストールすれば問題は解消します。