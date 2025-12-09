---
title: .NET でプレゼンテーションを保存
linktitle: プレゼンテーションの保存
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
- 事前定義されたビュータイプ
- Strict Office Open XML 形式
- Zip64 モード
- サムネイルの更新
- 保存の進捗
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して .NET でプレゼンテーションを保存する方法を紹介します—レイアウト、フォント、エフェクトを保持しながら PowerPoint や OpenDocument へエクスポートできます。"
---

## **概要**

[Open Presentations in C#](/slides/ja/net/open-presentation/) では、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスを使用してプレゼンテーションを開く方法が説明されています。本記事では、プレゼンテーションの作成と保存方法を解説します。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスはプレゼンテーションの内容を保持します。最初からプレゼンテーションを作成する場合でも、既存のものを変更する場合でも、作業が完了したら保存したくなるでしょう。Aspose.Slides for .NET を使用すると、**ファイル** または **ストリーム** に保存できます。本記事では、プレゼンテーションの保存方法の違いを説明します。

## **ファイルへのプレゼンテーション保存**

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスの `Save` メソッドを呼び出して、プレゼンテーションをファイルに保存します。メソッドにファイル名と保存形式を渡します。以下の例は、Aspose.Slides でプレゼンテーションを保存する方法を示しています。
```cs
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // ここで作業を行います...
    // プレゼンテーションをファイルに保存します。
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **ストリームへのプレゼンテーション保存**

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスの `Save` メソッドに出力ストリームを渡すことで、プレゼンテーションをストリームに保存できます。プレゼンテーションはさまざまなストリームタイプに書き込むことができます。以下の例では、新しいプレゼンテーションを作成し、ファイルストリームに保存しています。
```cs
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // プレゼンテーションをストリームに保存します。
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```


## **事前定義された表示タイプでのプレゼンテーション保存**

Aspose.Slides は、生成されたプレゼンテーションが開かれたときに PowerPoint が使用する初期ビューを [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/) クラスを通じて設定できます。[LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/lastview/) プロパティに [ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) 列挙体から値を設定してください。
```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```


## **Strict Office Open XML 形式でのプレゼンテーション保存**

Aspose.Slides は、プレゼンテーションを Strict Office Open XML 形式で保存できます。保存時に [PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/) クラスを使用し、その Conformance プロパティを設定します。`Conformance.Iso29500_2008_Strict` を設定すると、出力ファイルは Strict Office Open XML 形式で保存されます。

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


## **Zip64 モードでの Office Open XML 形式でのプレゼンテーション保存**

Office Open XML ファイルは ZIP アーカイブであり、非圧縮サイズ 4 GB（2^32 バイト）や圧縮サイズ、アーカイブ全体のサイズ、ファイル数（65 535 個）の制限があります。ZIP64 形式拡張により、これらの制限が 2^64 まで緩和されます。

[IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/) プロパティを使用すると、Office Open XML ファイルを保存する際に ZIP64 形式拡張を使用するタイミングを選択できます。

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

## **サムネイルを更新せずにプレゼンテーション保存**

[PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) プロパティは、PPTX に保存する際のサムネイル生成を制御します。

- `true` に設定すると、保存時にサムネイルが更新されます（デフォルト）。
- `false` に設定すると、現在のサムネイルが保持されます。プレゼンテーションにサムネイルがない場合は生成されません。

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
このオプションは、PPTX 形式でプレゼンテーションを保存する際の時間短縮に役立ちます。
{{% /alert %}}

## **保存進捗のパーセンテージ更新**

[IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) インターフェイスは、[ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions/) インターフェイスが公開する `ProgressCallback` プロパティおよび抽象クラス [SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) を通じて使用されます。`ProgressCallback` に [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) の実装を割り当てることで、保存進捗がパーセンテージで通知されます。

以下のコードスニペットは、`IProgressCallback` の使用例を示しています。
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
Aspose は、独自の API を使用した無料の PowerPoint Splitter アプリ ([https://products.aspose.app/slides/splitter](https://products.aspose.app/slides/splitter)) を提供しています。このアプリは、選択したスライドを新しい PPTX または PPT ファイルとして保存することで、プレゼンテーションを複数のファイルに分割できます。
{{% /alert %}}

## **FAQ**

**「高速保存」（インクリメンタル保存）はサポートされていますか？変更分だけが書き込まれますか？**

いいえ。保存は毎回完全なターゲットファイルを作成します。インクリメンタルの「高速保存」はサポートされていません。

**複数スレッドから同じ Presentation インスタンスを保存することはスレッドセーフですか？**

いいえ。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) インスタンスは[/slides/net/multithreading/](/slides/ja/net/multithreading/) で述べられているようにスレッドセーフではありません。単一スレッドから保存してください。

**保存時にハイパーリンクや外部参照ファイルはどうなりますか？**

[ハイパーリンク](/slides/ja/net/manage-hyperlinks/) は保持されます。外部参照ファイル（例: 相対パスで指定されたビデオ）は自動的にコピーされません。参照パスが引き続きアクセス可能であることを確認してください。

**ドキュメントメタデータ（作成者、タイトル、会社、日付など）を設定/保存できますか？**

はい。標準の[ドキュメントプロパティ](/slides/ja/net/presentation-properties/) がサポートされており、保存時にファイルへ書き込まれます。