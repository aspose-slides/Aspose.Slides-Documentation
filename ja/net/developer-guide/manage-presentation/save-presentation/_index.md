---
title: .NET でプレゼンテーションを保存する
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
- Strict Office Open XML 形式
- Zip64 モード
- サムネイルの更新
- 保存進行状況
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して .NET でプレゼンテーションを保存する方法を学びます — レイアウト、フォント、エフェクトを保持しながら PowerPoint または OpenDocument にエクスポートします。"
---

## **概要**

[Open Presentations in C#](/slides/ja/net/open-presentation/) では、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスを使用してプレゼンテーションを開く方法が説明されています。このドキュメントでは、プレゼンテーションの作成と保存方法を説明します。[Presentation] クラスはプレゼンテーションの内容を保持します。最初からプレゼンテーションを作成する場合でも、既存のものを変更する場合でも、完了したら保存したくなります。Aspose.Slides for .NET を使用すると、**ファイル**または**ストリーム**に保存できます。本稿では、プレゼンテーションを保存するさまざまな方法を説明します。

## **プレゼンテーションをファイルに保存する**

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスの `Save` メソッドを呼び出してプレゼンテーションをファイルに保存します。メソッドにファイル名と保存形式を渡します。以下の例は、Aspose.Slides を使用してプレゼンテーションを保存する方法を示しています。
```cs
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // ここで何らかの処理を行います...

    // プレゼンテーションをファイルに保存します。
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **プレゼンテーションをストリームに保存する**

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスの `Save` メソッドに出力ストリームを渡すことで、プレゼンテーションをストリームに保存できます。プレゼンテーションはさまざまなストリームタイプに書き込むことができます。以下の例では、新しいプレゼンテーションを作成し、ファイルストリームに保存しています。
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

Aspose.Slides では、[ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/) クラスを使用して、生成されたプレゼンテーションが開かれたときに PowerPoint が使用する初期ビューを設定できます。[LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/lastview/) プロパティに [ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) 列挙体の値を設定します。
```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```


## **厳格な Office Open XML 形式でプレゼンテーションを保存する**

Aspose.Slides を使用すると、プレゼンテーションを Strict Office Open XML 形式で保存できます。保存時に [PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/) クラスを使用し、その `Conformance` プロパティを設定します。`Conformance.Iso29500_2008_Strict` を設定すると、出力ファイルは Strict Office Open XML 形式で保存されます。

以下の例は、プレゼンテーションを作成し、Strict Office Open XML 形式で保存する方法を示しています。
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


## **Office Open XML 形式で Zip64 モードでプレゼンテーションを保存する**

Office Open XML ファイルは ZIP アーカイブで、非圧縮サイズ 4 GB（2^32 バイト）や圧縮サイズ・アーカイブ全体サイズの制限、最大 65 535（2^16‑1）ファイルという制限があります。ZIP64 形式拡張によりこれらの制限が 2^64 まで緩和されます。

[IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/) プロパティを使用して、Office Open XML ファイルを保存する際に ZIP64 形式拡張を使用するタイミングを選択できます。

このプロパティは以下のモードを提供します。

- `IfNecessary` は、プレゼンテーションが上記の制限を超える場合にのみ ZIP64 形式拡張を使用します。デフォルトのモードです。
- `Never` は、ZIP64 形式拡張を使用しません。
- `Always` は、常に ZIP64 形式拡張を使用します。

以下のコードは、ZIP64 形式拡張を有効にして PPTX としてプレゼンテーションを保存する方法を示しています。
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
`Zip64Mode.Never` で保存すると、プレゼンテーションを ZIP32 形式で保存できない場合に [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) がスローされます。
{{% /alert %}}

## **サムネイルを更新せずにプレゼンテーションを保存する**

[PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) プロパティは、PPTX 形式で保存する際のサムネイル生成を制御します。

- `true` に設定すると、保存時にサムネイルが更新されます（デフォルト）。
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

## **保存進行状況をパーセンテージで更新する**

[IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) インターフェイスは、[ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions/) インターフェイスが公開する `ProgressCallback` プロパティと抽象クラス [SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) を通じて使用されます。`ProgressCallback` に [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) の実装を割り当てると、保存進行状況がパーセンテージで通知されます。

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
        // ここで進捗のパーセンテージ値を使用します。
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```


{{% alert title="Info" color="info" %}}
Aspose は自社 API を使用した無料の PowerPoint Splitter アプリを提供しています。このアプリは、選択したスライドを新しい PPTX または PPT ファイルとして保存することで、プレゼンテーションを複数のファイルに分割できます。
{{% /alert %}}

## **よくある質問**

**「高速保存」（インクリメンタル保存）は、変更分だけを書き込むことはサポートされていますか？**

いいえ。保存は毎回完全なターゲット ファイルを作成します。インクリメンタルの「高速保存」はサポートされていません。

**同じ Presentation インスタンスを複数スレッドから同時に保存しても安全ですか？**

いいえ。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) インスタンスは[スレッド安全ではありません](/slides/ja/net/multithreading/)。単一スレッドから保存してください。

**保存時にハイパーリンクや外部リンクされたファイルはどうなりますか？**

[ハイパーリンク](/slides/ja/net/manage-hyperlinks/) は保持されます。外部リンクされたファイル（例えば相対パスのビデオなど）は自動的にコピーされません。参照パスが引き続きアクセス可能であることを確認してください。

**ドキュメント メタデータ（作者、タイトル、会社、日付など）を設定/保存できますか？**

はい。標準の[ドキュメント プロパティ](/slides/ja/net/presentation-properties/) がサポートされており、保存時にファイルに書き込まれます。