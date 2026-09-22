---
title: Javaでプレゼンテーションを保存
linktitle: プレゼンテーションを保存
type: docs
weight: 80
url: /ja/java/save-presentation/
keywords:
- PowerPointを保存
- OpenDocumentを保存
- プレゼンテーションを保存
- スライドを保存
- PPTを保存
- PPTXを保存
- ODPを保存
- ファイルへのプレゼンテーション
- ストリームへのプレゼンテーション
- 事前定義されたビュータイプ
- Strict Office Open XML 形式
- Zip64 モード
- サムネイルの更新
- 保存の進行状況
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Java で PowerPoint および OpenDocument プレゼンテーションをファイルまたはストリームに保存し、PPTX の出力と進行状況のレポートを構成します。"
---
## **概要**

プレゼンテーションを作成するか、[既存のプレゼンテーションを開く](/slides/ja/java/open-presentation/) と、[Presentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-java.lang.String-int-) メソッドを使用して結果を書き込みます。Aspose.Slides for Java は、PowerPoint、OpenDocument、PDF などの形式でプレゼンテーションをファイルまたはストリームに保存できます。以下のセクションでは、標準的な保存操作と PPTX 出力に利用できるオプションについて説明します。

## **プレゼンテーションをファイルに保存**

プレゼンテーションをファイルに保存するには、出力パスと [SaveFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveformat/) の値を [Presentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-java.lang.String-int-) メソッドに渡します。format 値は、Aspose.Slides が作成するファイルの種類を決定します。

次の例は、プレゼンテーションを作成し、PPTX ファイルとして保存します。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // ここでプレゼンテーションの内容を追加または変更します。

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **元の形式でプレゼンテーションを保存**

ファイルとストリームの検出例、新規作成されたプレゼンテーションの挙動、ソース形式と出力形式の違いについては、[元のプレゼンテーション形式の判定](/slides/ja/java/detect-presentation-source-format/) を参照してください。

バッチ処理アプリケーションでは、入力形式が事前に分からないことがあります。ファイルを読み込んだ後、[IPresentation.getSourceFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#getSourceFormat--) メソッドで元の形式を取得します。得られた [SourceFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/sourceformat/) の値を [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slideutil/#toSaveFormat-int-) に渡して対応する [SaveFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveformat/) の値を取得し、次に [Presentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-java.lang.String-int-) を使用して変更されたプレゼンテーションを書き込みます。

次の完全な例は、入力ディレクトリ内のすべてのファイルを処理し、タイトルを更新し、ロードされた形式のまま出力ディレクトリに保存します。

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slideutil/#toSaveFormat-int-) は PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP、PowerPoint XML をそれぞれ対応するプレゼンテーション保存形式にマッピングします。これはプレゼンテーションのソース形式のみをマッピングし、PDF、HTML、TIFF、画像などのエクスポート形式を選択するためのものではありません。サポートされていない、または無効な [SourceFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/sourceformat/) の値を渡すと、[IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html) がスローされます。

レガシーな PPT、PPS、POT ファイルは同じバイナリコンテナを使用します。拡張子なしのストリームからこのようなプレゼンテーションを読み込むと、PPS または POT ファイルが PPT と識別されることがあります。これらのレガシーサブタイプを保持する必要がある場合は、元のファイル名またはフォーマットメタデータを別途保持し、出力ファイル名とフォーマットを選択する際に使用してください。

## **プレゼンテーションをストリームに保存**

最終的なファイルパスに依存せずにプレゼンテーションを書き込むには、書き込み可能なストリームと [SaveFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveformat/) の値を [Presentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) メソッドに渡します。この方法は、出力を Web サービスから返す必要がある場合や、データベースに保存する場合、メモリ内で処理する場合に便利です。

次の例は、新しいプレゼンテーションをファイルストリームに保存します。

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

保存したプレゼンテーションを PowerPoint が最初に開くビューを指定できます。保存前に [ViewProperties.setLastView](https://reference.aspose.com/slides/ja/java/com.aspose.slides/viewproperties/#setLastView-int-) メソッドに [ViewType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/viewtype/) の値を使用します。

次の例は、スライドマスター ビューを初期ビューとして設定します。

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

Office Open XML の Strict プロファイルに準拠した PPTX ファイルを作成するには、[PptxOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pptxoptions/) インスタンスを作成し、[Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ja/java/com.aspose.slides/conformance/#Iso29500-2008-Strict) を使用してその [setConformance](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pptxoptions/#setConformance-int-) メソッドを呼び出します。その後、オプションを [Presentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドに渡します。

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

標準の ZIP アーカイブは、各エントリの圧縮サイズ・非圧縮サイズ、アーカイブ全体のサイズ、エントリ数に制限を設けています。PPTX ファイルは ZIP アーカイブであるため、非常に大きなプレゼンテーションはこれらの制限を超えることがあります。ZIP64 拡張機能は適用可能なサイズとエントリ数の制限を拡大します。

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pptxoptions/#setZip64Mode-int-) メソッドを使用して、Aspose.Slides が ZIP64 拡張機能を書き込むかどうかを制御します。

- [IfNecessary](https://reference.aspose.com/slides/ja/java/com.aspose.slides/zip64mode/#IfNecessary) は、プレゼンテーションが標準 ZIP 制限を超える場合にのみ ZIP64 を使用します。これがデフォルトモードです。
- [Never](https://reference.aspose.com/slides/ja/java/com.aspose.slides/zip64mode/#Never) は ZIP64 拡張機能を無効にします。
- [Always](https://reference.aspose.com/slides/ja/java/com.aspose.slides/zip64mode/#Always) は常に ZIP64 拡張機能を書き込みます。

次の例は、出力プレゼンテーションに対して常に ZIP64 拡張機能を有効にします。

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
[Zip64Mode.Never](https://reference.aspose.com/slides/ja/java/com.aspose.slides/zip64mode/#Never) が使用され、プレゼンテーションが標準 ZIP 制限内に収まらない場合、保存操作は [PptxException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pptxexception/) をスローします。
{{% /alert %}}

## **圧縮レベルを指定して Office Open XML 形式でプレゼンテーションを保存**

PPTX 出力では、[PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pptxoptions/#setCompressionLevel-int-) メソッドを使用して保存速度とファイルサイズのバランスを取れます。[CompressionLevel](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compressionlevel/) クラスは以下の値を提供します。

- [None](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compressionlevel/#None) は圧縮せずにデータを保存します。
- [Level1](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compressionlevel/#Level1) は最速の圧縮で、圧縮後のサイズが最大になります。
- [Level2](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compressionlevel/#Level2) から [Level5](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compressionlevel/#Level5) は、保存速度よりも小さい出力を優先します。
- [Level6](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compressionlevel/#Level6) は保存速度とファイルサイズのバランスを取ります。これがデフォルトレベルです。
- [Level7](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compressionlevel/#Level7) と [Level8](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compressionlevel/#Level8) は、さらに小さい出力を優先し、保存速度は低下します。
- [Level9](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compressionlevel/#Level9) は最も強い圧縮を行い、処理時間が最も長くなります。

次の例は、圧縮せずにプレゼンテーションを保存します。

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

次の例は、最大の圧縮レベルを使用します。

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

プレゼンテーションを PPTX として保存する際、[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) メソッドでドキュメントのサムネイルを制御できます。

- `true` は保存時にサムネイルを再生成します。これがデフォルト値です。
- `false` は既存のサムネイルを保持します。プレゼンテーションにサムネイルがない場合、Aspose.Slides は生成しません。

次の例は、サムネイルを更新せずにプレゼンテーションを保存します。

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

## **保存の進行状況をパーセンテージで取得**

保存操作を監視するには、[IProgressCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprogresscallback/) インターフェイスを実装し、その実装を [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-) メソッドに渡します。Aspose.Slides はエクスポート中に進行状況の値を渡して [IProgressCallback.reporting](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprogresscallback/#reporting-double-) メソッドを呼び出します。

次の例は、PDF エクスポートの進行状況をコンソールに報告します。

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
Aspose は、Aspose.Slides API を使用して構築された無料の [PowerPoint Splitter](https://products.aspose.app/slides/ja/splitter) を提供しています。これにより、プレゼンテーションから選択したスライドを別々の PPT または PPTX ファイルとして保存できます。
{{% /alert %}}

## **FAQ**

**Aspose.Slides はインクリメンタルまたは「高速保存」をサポートしていますか？**

いいえ。各保存操作は変更された部分だけを更新するのではなく、完全な出力ファイルを書き込みます。

**複数のスレッドで同じ Presentation インスタンスを保存できますか？**

いいえ。[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) インスタンスは[スレッドセーフではありません](/slides/ja/java/multithreading/)。各インスタンスへのアクセスと保存は、同時に 1 つのスレッドからのみ行ってください。

**プレゼンテーションを保存すると、ハイパーリンクや外部リンクされたファイルはどうなりますか？**

[ハイパーリンク](/slides/ja/java/manage-hyperlinks/) はプレゼンテーションに残ります。Aspose.Slides は外部リンクされたファイルをコピーしないため、保存されたプレゼンテーションはそれらの場所に引き続きアクセスできる必要があります。

**作成者、タイトル、会社、作成日などのドキュメント メタデータを保存できますか？**

はい。保存前に適切な[ドキュメント プロパティ](/slides/ja/java/presentation-properties/) を設定すれば、Aspose.Slides がそれらを出力ファイルに書き込みます。