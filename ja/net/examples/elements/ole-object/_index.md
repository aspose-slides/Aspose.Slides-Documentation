---
title: OLE オブジェクト
type: docs
weight: 210
url: /ja/net/examples/elements/ole-object/
keywords:
- OLE オブジェクト
- OLE オブジェクトの追加
- OLE オブジェクトへのアクセス
- OLE オブジェクトの削除
- OLE オブジェクトの更新
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET で OLE オブジェクトを操作します。C# を使用して PPT、PPTX、ODP プレゼンテーション内の埋め込みコンテンツを挿入、リンク、更新、抽出できます。"
---
この記事では、ファイルをOLEオブジェクトとして埋め込み、そのデータを**Aspose.Slides for .NET**を使用して更新する方法を示します。

## **OLEオブジェクトの追加**
プレゼンテーションにPDFファイルを埋め込みます。

```csharp
static void AddOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);
}
```

## **OLEオブジェクトへのアクセス**
スライド上の最初のOLEオブジェクトフレームを取得します。

```csharp
static void AccessOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    var firstOleFrame = slide.Shapes.OfType<IOleObjectFrame>().First();
}
```

## **OLEオブジェクトの削除**
スライドから埋め込まれたOLEオブジェクトを削除します。

```csharp
static void RemoveOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    slide.Shapes.Remove(oleFrame);
}
```

## **OLEオブジェクトデータの更新**
既存のOLEオブジェクトに埋め込まれたデータを置き換えます。

```csharp
static void UpdateOleObjectData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    var newData = File.ReadAllBytes("Picture.png");
    var newDataInfo = new OleEmbeddedDataInfo(newData, "png");
    oleFrame.SetEmbeddedData(newDataInfo);
}
```