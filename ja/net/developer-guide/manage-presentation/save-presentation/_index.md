---
title: .NET でプレゼンテーションを保存する
linktitle: プレゼンテーションの保存
type: docs
weight: 80
url: /ja/net/save-presentation/
keywords:
- PowerPoint の保存
- OpenDocument の保存
- プレゼンテーションの保存
- スライドの保存
- PPT の保存
- PPTX の保存
- ODP の保存
- ファイルへのプレゼンテーション
- ストリームへのプレゼンテーション
- 事前定義ビュータイプ
- Strict Office Open XML 形式
- Zip64 モード
- サムネイルの更新
- 保存進行状況
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して .NET でプレゼンテーションを保存する方法を紹介します—レイアウト、フォント、エフェクトを保持したまま PowerPoint または OpenDocument へエクスポートできます。"
---

## **概要**

[Open Presentations in C#](/slides/ja/net/open-presentation/) では、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスを使用してプレゼンテーションを開く方法が説明されています。本稿では、プレゼンテーションの作成と保存方法を解説します。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスはプレゼンテーションの内容を保持します。ゼロからプレゼンテーションを作成する場合でも、既存のものを変更する場合でも、作業が完了したら保存したくなるでしょう。Aspose.Slides for .NET では、**ファイル**または**ストリーム**に保存できます。本稿では、プレゼンテーションを保存するさまざまな方法を説明します。

## **ファイルにプレゼンテーションを保存する**

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスの `Save` メソッドを呼び出して、ファイルにプレゼンテーションを保存します。メソッドにファイル名と保存形式を渡します。以下の例は、Aspose.Slides を使用してプレゼンテーションを保存する方法を示しています。
```cs
// Presentation クラスのインスタンスを作成します（プレゼンテーション ファイルを表します）。
using (Presentation presentation = new Presentation())
{
    // ここで作業を行います...
    
    // プレゼンテーションをファイルに保存します。
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **ストリームにプレゼンテーションを保存する**

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスの `Save` メソッドに出力ストリームを渡すことで、プレゼンテーションをストリームに保存できます。プレゼンテーションは多くのストリーム型に書き込むことができます。以下の例では、新しいプレゼンテーションを作成し、ファイルストリームに保存します。
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

Aspose.Slides は、[ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/) クラスを介して、生成されたプレゼンテーションが開かれたときに PowerPoint が使用する初期ビューを設定できます。[LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/lastview/) プロパティに、[ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) 列挙体の値を設定します。
```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```


## **Strict Office Open XML 形式でプレゼンテーションを保存する**

Aspose.Slides は、Strict Office Open XML 形式でプレゼンテーションを保存できます。[PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/) クラスを使用し、保存時にその `Conformance` プロパティを設定します。`Conformance.Iso29500_2008_Strict` を設定すると、出力ファイルは Strict Office Open XML 形式で保存されます。

以下の例はプレゼンテーションを作成し、Strict Office Open XML 形式で保存します。
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


## **ZIP64 モードで Office Open XML 形式のプレゼンテーションを保存する**

Office Open XML ファイルは ZIP アーカイブであり、非圧縮サイズ 4 GB (2^32 バイト)、圧縮サイズ 4 GB、アーカイブ全体のサイズ 4 GB、ファイル数 65 535 (2^16‑1) の制限があります。ZIP64 形式拡張により、これらの制限が 2^64 まで緩和されます。

[IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/) プロパティを使用すると、Office Open XML ファイルを保存するときに ZIP64 形式拡張を使用するタイミングを選択できます。

このプロパティは次のモードを提供します:

- `IfNecessary` は、プレゼンテーションが上記の制限を超える場合にのみ ZIP64 形式拡張を使用します。既定のモードです。
- `Never` は ZIP64 形式拡張を使用しません。
- `Always` は常に ZIP64 形式拡張を使用します。

以下のコードは、ZIP64 形式拡張を有効にして PPTX としてプレゼンテーションを保存する方法を示しています:
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
`Zip64Mode.Never` で保存すると、ZIP32 形式で保存できない場合に [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) がスローされます。
{{% /alert %}}

## **サムネイルを更新せずにプレゼンテーションを保存する**

[PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) プロパティは、PPTX 形式で保存する際のサムネイル生成を制御します:

- `true` に設定すると、保存時にサムネイルが更新されます。既定です。
- `false` に設定すると、現在のサムネイルが保持されます。サムネイルが存在しない場合は生成されません。

以下のコードは、サムネイルを更新せずに PPTX としてプレゼンテーションを保存する例です。
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

[IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) インターフェイスは、[ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions/) インターフェイスが公開する `ProgressCallback` プロパティと、抽象クラス [SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) を介して使用されます。`ProgressCallback` に [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) 実装を割り当てると、保存進行状況がパーセンテージで通知されます。

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
Aspose は独自の API を使用した無料の PowerPoint Splitter アプリを提供しています。選択したスライドを新しい PPTX または PPT ファイルとして保存することで、プレゼンテーションを複数のファイルに分割できます。
{{% /alert %}}

## **FAQ**

**「高速保存」（インクリメンタル保存）はサポートされていますか？変更があった部分だけを書き込むことは可能ですか？**

いいえ。保存は毎回完全なターゲットファイルを作成します。インクリメンタルの「高速保存」はサポートされていません。

**同じ Presentation インスタンスを複数スレッドから同時に保存することはスレッドセーフですか？**

いいえ。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) インスタンスは [スレッドセーフではありません](/slides/ja/net/multithreading/)。単一スレッドから保存してください。

**ハイパーリンクや外部リンクされたファイルは保存時にどう扱われますか？**

[ハイパーリンク](/slides/ja/net/manage-hyperlinks/) は保持されます。外部リンクされたファイル（たとえば相対パスで参照される動画など）は自動的にコピーされません。参照先パスが引き続きアクセス可能であることを確認してください。

**文書メタデータ（作成者、タイトル、会社、日付）を設定/保存できますか？**

はい。標準の [文書プロパティ](/slides/ja/net/presentation-properties/) がサポートされており、保存時にファイルに書き込まれます。