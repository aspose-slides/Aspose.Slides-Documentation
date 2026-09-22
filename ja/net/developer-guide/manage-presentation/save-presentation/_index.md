---
title: .NET でプレゼンテーションを保存
linktitle: プレゼンテーションを保存
type: docs
weight: 80
url: /ja/net/save-presentation/
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
- 事前定義ビュー タイプ
- Strict Office Open XML 形式
- Zip64 モード
- サムネイルの更新
- 保存の進捗
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して C# で PowerPoint および OpenDocument プレゼンテーションをファイルまたはストリームに保存し、PPTX の出力と進捗レポートを設定します。"
---
## **概要**

プレゼンテーションを作成するか、[既存のプレゼンテーションを開く](/slides/ja/net/open-presentation/) ときは、[Presentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) メソッドを使用して結果を書き込みます。Aspose.Slides for .NET は、PowerPoint、OpenDocument、PDF などの形式で、プレゼンテーションをファイルまたはストリームに保存できます。以下のセクションでは、標準的な保存操作と PPTX 出力に利用できるオプションについて説明します。

## **プレゼンテーションをファイルに保存**

プレゼンテーションをファイルに保存するには、出力パスと [SaveFormat](https://reference.aspose.com/slides/ja/net/aspose.slides.export/saveformat/) の値を [Presentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) メソッドに渡します。フォーマットの値は、Aspose.Slides が作成するファイルの種類を決定します。

次の例は、プレゼンテーションを作成し、PPTX ファイルとして保存します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

// プレゼンテーションのコンテンツを追加または変更します。

presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **元の形式でプレゼンテーションを保存**

ファイルおよびストリームの検出例、新規作成プレゼンテーションの動作、ソース形式と出力形式の区別については、[Determine the Original Presentation Format](/slides/ja/net/detect-presentation-source-format/) を参照してください。

バッチ処理アプリケーションでは、入力形式が事前に判明していない場合があります。ファイルを読み込んだ後、[IPresentation.SourceFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/sourceformat/) プロパティから元の形式を取得します。取得した [SourceFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/sourceformat/) の値を [SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/ja/net/aspose.slides.util/slideutil/tosaveformat/) に渡して対応する [SaveFormat](https://reference.aspose.com/slides/ja/net/aspose.slides.export/saveformat/) の値を取得し、[Presentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) で変更後のプレゼンテーションを書き込みます。

次の完全な例は、入力ディレクトリ内のすべてのファイルを処理し、タイトルを更新して、読み込まれた形式のまま出力ディレクトリに保存します。

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

var inputDirectory = "Input";
var outputDirectory = "Output";

Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory))
{
    try
    {
        using var presentation = new Presentation(inputPath);

        var sourceFormat = presentation.SourceFormat;
        var saveFormat = SlideUtil.ToSaveFormat(sourceFormat);

        presentation.DocumentProperties.Title = "Processed by the batch application";

        var outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
        presentation.Save(outputPath, saveFormat);
    }
    catch (ArgumentException exception)
    {
        Console.Error.WriteLine($"Cannot map the source format of '{inputPath}': {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Cannot process '{inputPath}': {exception.Message}");
    }
}
```

[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/ja/net/aspose.slides.util/slideutil/tosaveformat/) は PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP、PowerPoint XML をそれぞれのプレゼンテーション保存形式にマップします。これはプレゼンテーションのソース形式のみを対象としており、PDF、HTML、TIFF、画像などのエクスポート形式を選択する目的では使用しません。[SourceFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/sourceformat/) にサポートされていないまたは無効な値を渡すと、[ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception) がスローされます。

レガシーな PPT、PPS、POT ファイルは同じバイナリコンテナを使用します。拡張子なしでストリームからそのようなプレゼンテーションを読み込むと、PPS や POT が PPT として識別されることがあります。これらのレガシーサブタイプを保持する必要がある場合は、元のファイル名または形式メタデータを別途保存し、出力ファイル名と形式を決定する際に使用してください。

## **プレゼンテーションをストリームに保存**

最終的なファイルパスに依存せずにプレゼンテーションを書き込むには、書き込み可能な [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) と [SaveFormat](https://reference.aspose.com/slides/ja/net/aspose.slides.export/saveformat/) の値を [Presentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) メソッドに渡します。この方法は、出力を Web サービスから返す必要がある場合や、データベースに保存する場合、メモリ内で処理する場合に便利です。

次の例は、新しいプレゼンテーションをファイルストリームに保存します。

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **事前に定義されたビュータイプでプレゼンテーションを保存**

PowerPoint が保存されたプレゼンテーションを最初に開くビューを指定できます。[ViewProperties.LastView](https://reference.aspose.com/slides/ja/net/aspose.slides/viewproperties/lastview/) プロパティを [ViewType](https://reference.aspose.com/slides/ja/net/aspose.slides/viewtype/) の値に設定してから保存してください。

次の例は、スライドマスター表示を初期ビューとして構成します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **Strict Office Open XML 形式でプレゼンテーションを保存**

Office Open XML の Strict プロファイルに準拠した PPTX ファイルを作成するには、[PptxOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pptxoptions/) のインスタンスを作成し、その [Conformance](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pptxoptions/conformance/) プロパティを `Conformance.Iso29500_2008_Strict` に設定します。その後、オプションを [Presentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) メソッドに渡します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PptxOptions
{
    Conformance = Conformance.Iso29500_2008_Strict
};

using var presentation = new Presentation();

presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
```

## **Office Open XML 形式で Zip64 モードでプレゼンテーションを保存**

標準の ZIP アーカイブは、各エントリの圧縮サイズ・非圧縮サイズ、アーカイブ全体のサイズ、エントリ数に制限があります。PPTX ファイルは ZIP アーカイブであるため、非常に大きなプレゼンテーションはこれらの制限を超えることがあります。Zip64 拡張により、これらのサイズおよびエントリ数の上限が拡大されます。

[PptxOptions.Zip64Mode](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pptxoptions/zip64mode/) プロパティで Aspose.Slides が Zip64 拡張を書き込むかどうかを制御します。

- `IfNecessary` はプレゼンテーションが標準 ZIP の制限を超える場合にのみ Zip64 を使用します。デフォルトモードです。
- `Never` は Zip64 拡張を書き込みません。
- `Always` は常に Zip64 拡張を書き込みます。

次の例は、出力プレゼンテーションに対して常に Zip64 拡張を有効にします。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    Zip64Mode = Zip64Mode.Always
};

presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, options);
```

{{% alert color="warning" title="Warning" %}}
`Zip64Mode` が `Never` に設定され、プレゼンテーションが標準 ZIP の制限内に収まらない場合、保存操作は [PptxException](https://reference.aspose.com/slides/ja/net/aspose.slides/pptxexception/) をスローします。
{{% /alert %}}

## **Office Open XML 形式で圧縮レベルを指定してプレゼンテーションを保存**

PPTX の出力では、[PptxOptions.CompressionLevel](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pptxoptions/compressionlevel/) プロパティを設定することで、保存速度とファイルサイズのバランスを調整できます。[CompressionLevel](https://reference.aspose.com/slides/ja/net/aspose.slides.export/compressionlevel/) 列挙体は次の値を提供します。

- `None` は圧縮せずにデータを保存します。
- `Level1` は最速の圧縮で、圧縮後のサイズが最大になります。
- `Level2` から `Level5` は、保存速度よりも小さな出力を徐々に優先します。
- `Level6` は保存速度とファイルサイズのバランスを取ります。デフォルトレベルです。
- `Level7` と `Level8` は、保存速度よりもさらに小さな出力を優先します。
- `Level9` は最強の圧縮を行い、最も多くの処理時間が必要です。

次の例は、圧縮なしでプレゼンテーションを保存します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.None
};

presentation.Save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
```

次の例は、最大圧縮レベルで保存します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.Level9
};

presentation.Save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
```

## **サムネイルを更新せずにプレゼンテーションを保存**

プレゼンテーションを PPTX として保存する際、[PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pptxoptions/refreshthumbnail/) プロパティでドキュメントサムネイルの挙動を制御します。

- `true` は保存時にサムネイルを再生成します。既定値です。
- `false` は既存のサムネイルを保持します。プレゼンテーションにサムネイルがない場合、Aspose.Slides は新たに生成しません。

次の例は、サムネイルを更新せずにプレゼンテーションを保存します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    RefreshThumbnail = false
};

presentation.Save("Output.pptx", SaveFormat.Pptx, options);
```

{{% alert color="info" title="Note" %}}
サムネイルの更新を無効にすると、PPTX ファイルの保存にかかる時間を短縮できます。
{{% /alert %}}

## **保存進捗をパーセンテージで更新**

保存操作の進捗を監視するには、[IProgressCallback](https://reference.aspose.com/slides/ja/net/aspose.slides/iprogresscallback/) インターフェイスを実装し、その実装を [ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/ja/net/aspose.slides.export/isaveoptions/progresscallback/) プロパティに割り当てます。Aspose.Slides はエクスポート中に [IProgressCallback.Reporting](https://reference.aspose.com/slides/ja/net/aspose.slides/iprogresscallback/reporting/) メソッドを呼び出し、進捗値を通知します。

次の例は、PDF エクスポートの進捗をコンソールに出力します。

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PdfOptions
{
    ProgressCallback = new ExportProgressHandler()
};

using var presentation = new Presentation("Sample.pptx");

presentation.Save("Output.pdf", SaveFormat.Pdf, options);

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        var progress = Convert.ToInt32(progressValue);
        Console.WriteLine($"{progress}% of the file has been converted.");
    }
}
```

{{% alert color="info" title="Note" %}}
Aspose は、Aspose.Slides API を使用して構築された無料の [PowerPoint Splitter](https://products.aspose.app/slides/ja/splitter) を提供しています。選択したスライドを個別の PPT または PPTX ファイルとして保存できます。
{{% /alert %}}

## **FAQ**

**Aspose.Slides はインクリメンタル保存または「高速保存」をサポートしていますか？**

いいえ。各保存操作は、変更された部分だけを更新するのではなく、完全な出力ファイルを書き込みます。

**複数のスレッドで同じ Presentation インスタンスを保存できますか？**

いいえ。[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) インスタンスは **スレッド セーフではありません** (/slides/ja/net/multithreading/)。各インスタンスは同時に 1 つのスレッドからのみアクセスして保存してください。

**プレゼンテーションを保存するときにハイパーリンクや外部リンクファイルはどうなりますか？**

[ハイパーリンク](/slides/ja/net/manage-hyperlinks/) はプレゼンテーション内に残ります。Aspose.Slides は外部リンクファイルをコピーしないため、保存されたプレゼンテーションはそれらの場所に引き続きアクセスできる必要があります。

**作者、タイトル、会社、作成日などのドキュメントメタデータを保存できますか？**

はい。保存前に適切な [ドキュメント プロパティ](/slides/ja/net/presentation-properties/) を設定すれば、Aspose.Slides はそれらを出力ファイルに書き込みます。