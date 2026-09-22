---
title: Android でプレゼンテーションを保存
linktitle: プレゼンテーションを保存
type: docs
weight: 80
url: /ja/androidjava/save-presentation/
keywords:
- PowerPoint を保存
- OpenDocument を保存
- プレゼンテーションを保存
- スライドを保存
- PPT を保存
- PPTX を保存
- ODP を保存
- ファイルへのプレゼンテーション
- ストリームへのプレゼンテーション
- 事前定義されたビュータイプ
- Strict Office Open XML 形式
- Zip64 モード
- サムネイルの更新
- 保存の進捗
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Android で PowerPoint および OpenDocument のプレゼンテーションをファイルまたはストリームに保存し、PPTX の出力や進捗レポートを構成できます。"
---
## **概要**

プレゼンテーションを作成したり、[既存のプレゼンテーションを開く](/slides/ja/androidjava/open-presentation/) ときは、[Presentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) メソッドを使用して結果を書き込みます。Aspose.Slides for Android via Java は、PowerPoint、OpenDocument、PDF などの形式でプレゼンテーションをファイルまたはストリームに保存できます。以下のセクションでは、標準的な保存操作と PPTX 出力に利用できるオプションについて説明します。

## **ファイルへのプレゼンテーション保存**

プレゼンテーションをファイルに保存するには、出力パスと [SaveFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveformat/) の値を [Presentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) メソッドに渡します。format の値は、Aspose.Slides が作成するファイルの種類を決定します。

次の例はプレゼンテーションを作成し、PPTX ファイルとして保存します。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // プレゼンテーションのコンテンツを追加または変更してください。

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **元の形式でプレゼンテーションを保存**

ファイルとストリームの検出例、 新規作成プレゼンテーションの動作、 そしてソース形式と出力形式の区別については、[元のプレゼンテーション形式を判別](/slides/ja/androidjava/detect-presentation-source-format/) を参照してください。

バッチ処理アプリケーションでは、入力形式が事前に分からないことがあります。ファイルを読み込んだ後、[IPresentation.getSourceFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) メソッドで元の形式を取得します。得られた [SourceFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sourceformat/) の値を [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) に渡して対応する [SaveFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveformat/) を取得し、[Presentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) で変更済みプレゼンテーションを書き込みます。

次の完全な例は、入力ディレクトリ内のすべてのファイルを処理し、タイトルを更新して、ロードされた形式のまま出力ディレクトリに保存します。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SlideUtil;
import java.io.File;

File inputDirectory = new File("Input");
File outputDirectory = new File("Output");

if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    System.err.println("Cannot create the output directory.");
}

File[] inputFiles = inputDirectory.listFiles(File::isFile);
if (inputFiles != null && outputDirectory.isDirectory()) {
    for (File inputFile : inputFiles) {
        try {
            Presentation presentation = new Presentation(inputFile.getPath());
            try {
                int saveFormat = SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                File outputFile = new File(outputDirectory, inputFile.getName());
                presentation.save(outputFile.getPath(), saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (IllegalArgumentException exception) {
            System.err.println("Cannot map the source format of '" + inputFile.getPath() + "': " + exception.getMessage());
        } catch (Exception exception) {
            System.err.println("Cannot process '" + inputFile.getPath() + "': " + exception.getMessage());
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) は PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP、PowerPoint XML をそれぞれ対応するプレゼンテーション保存形式にマップします。これはプレゼンテーションのソース形式のみを対象とし、PDF、HTML、TIFF、画像などのエクスポート形式を選択するためのものではありません。サポートされていない、または無効な [SourceFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sourceformat/) を渡すと、[IllegalArgumentException](https://developer.android.com/reference/java/lang/IllegalArgumentException) がスローされます。

レガシーな PPT、PPS、POT ファイルは同じバイナリコンテナーを使用します。このようなプレゼンテーションを拡張子なしのストリームからロードした場合、PPS または POT ファイルが PPT として識別されることがあります。これらのレガシーサブタイプを保持する必要がある場合は、元のファイル名または形式メタデータを別途保持し、出力ファイル名と形式を選択するときに使用してください。

## **ストリームへのプレゼンテーション保存**

最終的なファイルパスに依存せずにプレゼンテーションを書き込むには、書き込み可能なストリームと [SaveFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveformat/) の値を [Presentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) メソッドに渡します。この方法は、出力を Web サービスから返す必要がある場合や、データベースに保存する場合、メモリ内で処理する場合に便利です。

次の例は新しいプレゼンテーションをファイルストリームに保存します。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileOutputStream;
import java.io.OutputStream;

Presentation presentation = new Presentation();
try {
    OutputStream outputStream = new FileOutputStream("Output.pptx");
    try {
        presentation.save(outputStream, SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **事前定義されたビュータイプでプレゼンテーションを保存**

保存されたプレゼンテーションが PowerPoint で最初に開くビューを指定できます。[ViewProperties.setLastView](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) メソッドに [ViewType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/viewtype/) の値を渡してから保存してください。

次の例はスライドマスタービューを初期ビューとして設定します。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Strict Office Open XML 形式でプレゼンテーションを保存**

Strict プロファイルの Office Open XML に準拠した PPTX ファイルを作成するには、[PptxOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pptxoptions/) インスタンスを作成し、[setConformance](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pptxoptions/#setConformance-int-) メソッドに [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) を指定します。次にオプションを [Presentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドに渡します。

```java
import com.aspose.slides.Conformance;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

Presentation presentation = new Presentation();
try {
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Zip64 モードで Office Open XML 形式でプレゼンテーションを保存**

標準の ZIP アーカイブは、各エントリの圧縮サイズ・非圧縮サイズ、アーカイブ全体のサイズ、エントリ数に制限があります。PPTX ファイルは ZIP アーカイブであるため、非常に大きなプレゼンテーションはこれらの制限を超えることがあります。ZIP64 拡張機能はサイズとエントリ数の上限を引き上げます。

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pptxoptions/#setZip64Mode-int-) メソッドで Aspose.Slides が ZIP64 拡張を書き込むかどうかを制御します。

- [IfNecessary](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/zip64mode/#IfNecessary) はプレゼンテーションが標準 ZIP の制限を超える場合にのみ ZIP64 を使用します。これがデフォルトモードです。
- [Never](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/zip64mode/#Never) は ZIP64 拡張を書き込みません。
- [Always](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/zip64mode/#Always) は常に ZIP64 拡張を書き込みます。

次の例は出力プレゼンテーションに対して常に ZIP64 拡張を有効にします。

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.Zip64Mode;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setZip64Mode(Zip64Mode.Always);

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
[Zip64Mode.Never](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/zip64mode/#Never) を使用し、プレゼンテーションが標準 ZIP の制限内に収まらない場合、保存操作は [PptxException](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pptxexception/) をスローします。
{{% /alert %}}

## **圧縮レベルを指定して Office Open XML 形式でプレゼンテーションを保存**

PPTX 出力では、[PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pptxoptions/#setCompressionLevel-int-) メソッドを使用して保存速度とファイルサイズのバランスを取れます。[CompressionLevel](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compressionlevel/) クラスは次の値を提供します。

- [None](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compressionlevel/#None) は圧縮せずにデータを保存します。
- [Level1](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compressionlevel/#Level1) は最速の圧縮で、圧縮後のサイズが最大になります。
- [Level2](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compressionlevel/#Level2) から [Level5](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compressionlevel/#Level5) は、保存速度よりも小さな出力を優先します。
- [Level6](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compressionlevel/#Level6) は保存速度とファイルサイズのバランスを取り、デフォルトレベルです。
- [Level7](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compressionlevel/#Level7) と [Level8](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compressionlevel/#Level8) はさらに小さな出力を優先します。
- [Level9](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compressionlevel/#Level9) は最強の圧縮を行い、最も多くの処理時間が必要です。

次の例は圧縮なしでプレゼンテーションを保存します。

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.None);

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

次の例は最大圧縮レベルで保存します。

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.Level9);

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **サムネイルを更新せずにプレゼンテーションを保存**

プレゼンテーションを PPTX として保存する際、[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) メソッドでドキュメントサムネイルの振る舞いを制御できます。

- `true` は保存時にサムネイルを再生成します。これがデフォルト値です。
- `false` は既存のサムネイルを保持します。プレゼンテーションにサムネイルがない場合、Aspose.Slides はサムネイルを生成しません。

次の例はサムネイルを更新せずにプレゼンテーションを保存します。

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("Output.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
サムネイルの更新を無効にすると、PPTX ファイルの保存にかかる時間を短縮できます。
{{% /alert %}}

## **進捗をパーセンテージで取得**

保存操作の進捗を監視するには、[IProgressCallback](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iprogresscallback/) インターフェイスを実装し、その実装を [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-) メソッドに渡します。Aspose.Slides はエクスポート中に [IProgressCallback.reporting](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iprogresscallback/#reporting-double-) メソッドを呼び出して進捗値を通知します。

次の例は PDF エクスポートの進捗をコンソールに出力します。

```java
import com.aspose.slides.IProgressCallback;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        int progress = (int) progressValue;
        System.out.println(progress + "% of the file has been converted.");
    }
}

PdfOptions options = new PdfOptions();
options.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose は Aspose.Slides API を使用して構築された無料の [PowerPoint Splitter](https://products.aspose.app/slides/ja/splitter) を提供しています。これにより、プレゼンテーションから選択したスライドを個別の PPT または PPTX ファイルとして保存できます。
{{% /alert %}}

## **FAQ**

**Aspose.Slides はインクリメンタル保存または「高速保存」をサポートしていますか？**

いいえ。各保存操作は変更された部分だけを更新するのではなく、完全な出力ファイルを書き込みます。

**複数のスレッドから同じ Presentation インスタンスを保存できますか？**

いいえ。[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) インスタンスは[スレッド セーフではありません](/slides/ja/androidjava/multithreading/)。インスタンスへのアクセスおよび保存は同時に 1 つのスレッドからのみ行ってください。

**プレゼンテーションを保存するとハイパーリンクや外部リンクされたファイルはどうなりますか？**

[ハイパーリンク](/slides/ja/androidjava/manage-hyperlinks/) はプレゼンテーションに残ります。Aspose.Slides は外部リンクされたファイルをコピーしないため、保存されたプレゼンテーションは引き続きそれらの場所にアクセスできる必要があります。

**作者、タイトル、会社、作成日などのドキュメントメタデータを保存できますか？**

はい。保存前に適切な [ドキュメント プロパティ](/slides/ja/androidjava/presentation-properties/) を設定すれば、Aspose.Slides がそれらを出力ファイルに書き込みます。