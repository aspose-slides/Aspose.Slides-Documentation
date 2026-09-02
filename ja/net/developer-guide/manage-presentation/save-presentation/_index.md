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
- 事前定義ビュータイプ
- Strict Office Open XML フォーマット
- Zip64 モード
- サムネイルの更新
- 保存進捗
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して .NET でプレゼンテーションを保存する方法を紹介します—レイアウト、フォント、エフェクトを保持したまま PowerPoint や OpenDocument にエクスポートできます。"
---
## **概要**

[Open Presentations in C#](/slides/ja/net/open-presentation/) は、プレゼンテーションを開くために [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスを使用する方法を説明しています。このドキュメントでは、プレゼンテーションの作成と保存方法を解説します。[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスはプレゼンテーションの内容を保持します。ゼロからプレゼンテーションを作成する場合でも、既存のものを変更する場合でも、作業が完了したら保存したくなります。Aspose.Slides for .NET を使用すると、**ファイル**または**ストリーム**に保存できます。本記事では、プレゼンテーションの保存方法の違いを説明します。

## **ファイルにプレゼンテーションを保存**

プレゼンテーションをファイルに保存するには、[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスの `Save` メソッドを呼び出します。メソッドにファイル名と保存形式を渡します。次の例は、Aspose.Slides を使用してプレゼンテーションを保存する方法を示しています。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンス化。
using (Presentation presentation = new Presentation())
{
    // ここで何らかの処理を行う...

    // プレゼンテーションをファイルに保存する。
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **ストリームにプレゼンテーションを保存**

`[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/)` クラスの `Save` メソッドに出力ストリームを渡すことで、プレゼンテーションをストリームに保存できます。プレゼンテーションはさまざまなストリームタイプに書き込むことができます。以下の例では、新しいプレゼンテーションを作成し、ファイルストリームに保存しています。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // プレゼンテーションをストリームに保存します。
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **事前定義ビュータイプでプレゼンテーションを保存**

Aspose.Slides は、生成されたプレゼンテーションが開かれたときに PowerPoint が使用する初期ビューを [ViewProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/viewproperties/) クラスで設定できるようにします。[LastView](https://reference.aspose.com/slides/ja/net/aspose.slides/viewproperties/lastview/) プロパティに [ViewType](https://reference.aspose.com/slides/ja/net/aspose.slides/viewtype/) 列挙体の値を設定します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Strict Office Open XML 形式でプレゼンテーションを保存**

Aspose.Slides を使用すると、プレゼンテーションを Strict Office Open XML 形式で保存できます。保存時に [PptxOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pptxoptions/) クラスを使用し、その Conformance プロパティを設定します。`Conformance.Iso29500_2008_Strict` を設定すると、出力ファイルは Strict Office Open XML 形式で保存されます。

以下の例は、プレゼンテーションを作成し、Strict Office Open XML 形式で保存します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // プレゼンテーションを Strict Office Open XML 形式で保存します。
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Zip64 モードで Office Open XML 形式でプレゼンテーションを保存**

Office Open XML ファイルは ZIP アーカイブであり、任意のファイルの非圧縮サイズ、圧縮サイズ、アーカイブ全体のサイズに対して 4 GB (2^32 バイト) の制限があり、またファイル数は 65 535 (2^16‑1) に制限されます。ZIP64 形式拡張により、これらの制限が 2^64 まで緩和されます。

[IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ipptxoptions/zip64mode/) プロパティを使用すると、Office Open XML ファイルを保存する際に ZIP64 形式拡張を使用するタイミングを選択できます。

このプロパティは次のモードを提供します:

- `IfNecessary` は、プレゼンテーションが上記の制限を超える場合にのみ ZIP64 形式拡張を使用します。これがデフォルトモードです。
- `Never` は、ZIP64 形式拡張を使用しません。
- `Always` は、常に ZIP64 形式拡張を使用します。

以下のコードは、ZIP64 形式拡張を有効にして PPTX ファイルとしてプレゼンテーションを保存する方法を示しています。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
`Zip64Mode.Never` で保存すると、プレゼンテーションを ZIP32 形式で保存できない場合に [PptxException](https://reference.aspose.com/slides/ja/net/aspose.slides/pptxexception/) がスローされます。
{{% /alert %}}

## **圧縮レベルで Office Open XML 形式でプレゼンテーションを保存**

大きなプレゼンテーションを扱う場合、ファイルサイズと処理時間のバランスを取るために圧縮レベルを調整できます。要件に応じて、処理速度を重視したり、出力ファイルを小さくしたりすることができます。

Aspose.Slides は、Office Open XML 形式でプレゼンテーションを保存する際に使用する圧縮レベルを指定できる [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ipptxoptions/compressionlevel/) プロパティを提供します。

利用可能な圧縮レベルは次のとおりです:

- **None**: 圧縮は適用されません。ファイルはそのまま保存されます。
- **Level1**: 圧縮率が最も低く、最速の圧縮です。
- **Level2**: **Level1** よりやや高い圧縮率で、より高速な圧縮です。
- **Level3**: **Level2** より高い圧縮率で、処理時間への影響は中程度です。
- **Level4**: **Level3** より高い圧縮率です。
- **Level5**: **Level4** より圧縮率が向上し、処理時間が増加します。
- **Level6**: 標準的な圧縮で、処理速度とファイルサイズのバランスが良好です。これは *デフォルトの圧縮レベル* です。
- **Level7**: **Level6** より高い圧縮率で、処理は遅くなります。
- **Level8**: **Level7** より高い圧縮率です。
- **Level9**: 最大圧縮です。最も小さなファイルサイズになりますが、処理時間が最長になります。

次の例は、圧縮なしでプレゼンテーションを PPTX ファイルとして保存する方法を示しています。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

この例は、最大圧縮でプレゼンテーションを PPTX ファイルとして保存する方法を示しています。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **サムネイルを更新せずにプレゼンテーションを保存**

`[PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ipptxoptions/refreshthumbnail/)` プロパティは、プレゼンテーションを PPTX に保存する際のサムネイル生成を制御します:

- `true` に設定すると、保存時にサムネイルが更新されます。これはデフォルトです。
- `false` に設定すると、現在のサムネイルが保持されます。プレゼンテーションにサムネイルがない場合は生成されません。

以下のコードでは、サムネイルを更新せずにプレゼンテーションを PPTX に保存しています。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
このオプションは、PPTX 形式でプレゼンテーションを保存するのにかかる時間を短縮するのに役立ちます。
{{% /alert %}}

## **保存進捗をパーセンテージで更新**

[IProgressCallback](https://reference.aspose.com/slides/ja/net/aspose.slides/iprogresscallback/) インターフェイスは、[ISaveOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/isaveoptions/) インターフェイスが公開する `ProgressCallback` プロパティおよび抽象クラス [SaveOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/saveoptions/) を介して使用されます。`ProgressCallback` に [IProgressCallback](https://reference.aspose.com/slides/ja/net/aspose.slides/iprogresscallback/) の実装を割り当てると、保存進捗がパーセンテージで通知されます。

以下のコードスニペットは、`IProgressCallback` の使用方法を示しています。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
using Aspose.Slides;

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // ここで進捗パーセンテージの値を使用します。
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose は独自の API を使用して、[無料の PowerPoint Splitter アプリ](https://products.aspose.app/slides/ja/splitter) を開発しました。このアプリは、選択したスライドを新しい PPTX または PPT ファイルとして保存することで、プレゼンテーションを複数のファイルに分割できます。
{{% /alert %}}

## **よくある質問**

**「高速保存」（インクリメンタル保存）は、変更分だけが書き込まれるようにサポートされていますか？**

いいえ。保存は毎回完全なターゲットファイルを作成します。インクリメンタルの「高速保存」はサポートされていません。

**複数のスレッドから同じ Presentation インスタンスを保存することはスレッドセーフですか？**

いいえ。[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) インスタンスは[スレッドセーフではありません](/slides/ja/net/multithreading/); 1 つのスレッドから保存してください。

**保存時にハイパーリンクや外部リンクされたファイルはどうなりますか？**

[ハイパーリンク](/slides/ja/net/manage-hyperlinks/) は保持されます。外部リンクされたファイル（例: 相対パスで参照される動画）は自動的にコピーされません。参照されているパスが引き続きアクセス可能であることを確認してください。

**ドキュメントのメタデータ（作者、タイトル、会社、日付）を設定/保存できますか？**

はい。標準の[ドキュメント プロパティ](/slides/ja/net/presentation-properties/) がサポートされており、保存時にファイルに書き込まれます。