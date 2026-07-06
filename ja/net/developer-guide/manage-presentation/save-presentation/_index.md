---
title: ".NET でプレゼンテーションを保存"
linktitle: "プレゼンテーションを保存"
type: docs
weight: 80
url: /ja/net/save-presentation/
keywords:
- "PowerPoint の保存"
- "OpenDocument の保存"
- "プレゼンテーションの保存"
- "スライドの保存"
- "PPT の保存"
- "PPTX の保存"
- "ODP の保存"
- "ファイルへのプレゼンテーション"
- "ストリームへのプレゼンテーション"
- "事前定義されたビュータイプ"
- "Strict Office Open XML 形式"
- "Zip64 モード"
- "サムネイルの更新"
- "保存の進行状況"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides を使用して .NET でプレゼンテーションを保存する方法を解説します。レイアウト、フォント、効果を保持したまま PowerPoint や OpenDocument にエクスポートできます。"
---
## **概要**

[Open Presentations in C#](/slides/ja/net/open-presentation/) では、[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスを使用してプレゼンテーションを開く方法が説明されています。この項では、プレゼンテーションの作成と保存方法を説明します。[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスはプレゼンテーションの内容を保持します。ゼロからプレゼンテーションを作成する場合でも、既存のものを変更する場合でも、完了したら保存したくなるでしょう。Aspose.Slides for .NET を使用すると、**ファイル**または**ストリーム**に保存できます。この項では、プレゼンテーションを保存するさまざまな方法を説明します。

## **プレゼンテーションをファイルに保存する**

[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスの `Save` メソッドを呼び出すことで、プレゼンテーションをファイルに保存します。メソッドにファイル名と保存形式を渡します。以下の例は、Aspose.Slides を使用してプレゼンテーションを保存する方法を示しています。

```cs
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // ここで作業を行います...

    // プレゼンテーションをファイルに保存します。
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **プレゼンテーションをストリームに保存する**

[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスの `Save` メソッドに出力ストリームを渡すことで、プレゼンテーションをストリームに保存できます。プレゼンテーションはさまざまなストリームタイプに書き込むことができます。以下の例では、新しいプレゼンテーションを作成し、ファイルストリームに保存しています。

```cs
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

## **事前定義されたビュータイプでプレゼンテーションを保存する**

Aspose.Slides では、[ViewProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/viewproperties/) クラスを介して、生成されたプレゼンテーションが開かれたときに PowerPoint が使用する初期ビューを設定できます。[LastView](https://reference.aspose.com/slides/ja/net/aspose.slides/viewproperties/lastview/) プロパティに [ViewType](https://reference.aspose.com/slides/ja/net/aspose.slides/viewtype/) 列挙体の値を設定します。

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Strict Office Open XML 形式でプレゼンテーションを保存する**

Aspose.Slides では、Strict Office Open XML 形式でプレゼンテーションを保存できます。保存時に [PptxOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pptxoptions/) クラスを使用し、その `Conformance` プロパティを設定します。`Conformance.Iso29500_2008_Strict` を設定すると、出力ファイルは Strict Office Open XML 形式で保存されます。

下の例はプレゼンテーションを作成し、Strict Office Open XML 形式で保存します。

```cs
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

## **ZIP64 モードで Office Open XML 形式でプレゼンテーションを保存する**

Office Open XML ファイルは ZIP アーカイブであり、非圧縮サイズ 4 GB (2^32 バイト)、圧縮サイズ 4 GB、アーカイブ全体のサイズ 4 GB、ファイル数 65 535 (2^16‑1) の制限があります。ZIP64 形式拡張によりこれらの制限が 2^64 まで緩和されます。

[IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ipptxoptions/zip64mode/) プロパティにより、Office Open XML ファイルを保存する際に ZIP64 形式拡張を使用するタイミングを選択できます。

このプロパティは次のモードを提供します。

- `IfNecessary` は、プレゼンテーションが上記の制限を超える場合にのみ ZIP64 形式拡張を使用します。これがデフォルトモードです。
- `Never` は ZIP64 形式拡張を使用しません。
- `Always` は常に ZIP64 形式拡張を使用します。

以下のコードは、ZIP64 形式拡張を有効にした状態で PPTX ファイルとしてプレゼンテーションを保存する方法を示します。

```cs
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

## **圧縮レベル付きで Office Open XML 形式でプレゼンテーションを保存する**

大規模なプレゼンテーションを扱う場合、ファイルサイズと処理時間のバランスを取るために圧縮レベルを調整できます。要件に応じて、処理速度を優先したり、出力ファイルを小さくしたりできます。

Aspose.Slides は、Office Open XML 形式でプレゼンテーションを保存する際に使用する圧縮レベルを指定できる [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ipptxoptions/compressionlevel/) プロパティを提供します。

利用できる圧縮レベルは次のとおりです。

- **None**: 圧縮せずに保存します。ファイルはそのまま保存されます。
- **Level1**: 最速の圧縮で、圧縮率は最低です。
- **Level2**: **Level1** より若干高い圧縮率で、比較的高速です。
- **Level3**: **Level2** より高い圧縮率で、処理時間への影響は中程度です。
- **Level4**: **Level3** より高い圧縮率です。
- **Level5**: **Level4** より高い圧縮率で、さらに処理時間が増加します。
- **Level6**: 標準的な圧縮で、処理速度とファイルサイズのバランスが良いです。これが *デフォルトの圧縮レベル* です。
- **Level7**: **Level6** より高い圧縮率で、処理は遅くなります。
- **Level8**: **Level7** より高い圧縮率です。
- **Level9**: 最高圧縮。最小のファイルサイズを実現しますが、処理時間が最も長くなります。

以下の例は、圧縮なしで PPTX ファイルとしてプレゼンテーションを保存する方法を示します。
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

この例は、最大圧縮で PPTX ファイルとしてプレゼンテーションを保存する方法を示します。
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **サムネイルを更新せずにプレゼンテーションを保存する**

[PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) プロパティは、PPTX に保存する際のサムネイル生成を制御します。

- `true` に設定すると、保存時にサムネイルが更新されます。これがデフォルトです。
- `false` に設定すると、現在のサムネイルが保持されます。プレゼンテーションにサムネイルがない場合は生成されません。

以下のコードは、サムネイルを更新せずに PPTX にプレゼンテーションを保存する例です。

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
このオプションを使用すると、PPTX 形式での保存にかかる時間を短縮できます。
{{% /alert %}}

## **保存進行状況をパーセンテージで取得する**

[IProgressCallback](https://reference.aspose.com/slides/ja/net/aspose.slides/iprogresscallback/) インターフェイスは、[ISaveOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/isaveoptions/) インターフェイスが公開する `ProgressCallback` プロパティ、および抽象クラス [SaveOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/saveoptions/) を介して使用されます。`ProgressCallback` に [IProgressCallback](https://reference.aspose.com/slides/ja/net/aspose.slides/iprogresscallback/) 実装を割り当てることで、保存の進行状況をパーセンテージで受け取れます。

以下のコードスニペットは、`IProgressCallback` の使用方法を示しています。

```cs
ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
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
Aspose は独自の API を使用した [無料の PowerPoint Splitter アプリ](https://products.aspose.app/slides/ja/splitter) を開発しています。このアプリは、選択したスライドを新しい PPTX または PPT ファイルとして保存することで、プレゼンテーションを複数のファイルに分割できます。
{{% /alert %}}

## **FAQ**

**「高速保存」（インクリメンタル保存）はサポートされていますか？変更部分だけが書き込まれますか？**

いいえ。保存は毎回完全なターゲット ファイルを作成します。インクリメンタルな「高速保存」はサポートされていません。

**同じ Presentation インスタンスを複数スレッドから同時に保存することはスレッドセーフですか？**

いいえ。[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) インスタンスは [スレッドセーフではありません](/slides/ja/net/multithreading/)。単一スレッドから保存してください。

**保存時にハイパーリンクや外部リンクされたファイルはどうなりますか？**

[Hyperlinks](/slides/ja/net/manage-hyperlinks/) はそのまま保持されます。外部リンクされたファイル（例えば相対パスのビデオ）は自動的にコピーされません。参照パスが引き続きアクセス可能であることを確認してください。

**ドキュメントのメタデータ（作者、タイトル、会社、日付など）を設定/保存できますか？**

はい。標準の [document properties](/slides/ja/net/presentation-properties/) がサポートされており、保存時にファイルに書き込まれます。