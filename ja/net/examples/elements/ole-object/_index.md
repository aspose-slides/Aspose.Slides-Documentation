---
title: OleObject
type: docs
weight: 210
url: /ja/net/examples/elements/ole-object/
keywords:
- OLEオブジェクトの例
- OLEオブジェクトの追加
- OLEオブジェクトへのアクセス
- OLEオブジェクトの削除
- OLEオブジェクトの更新
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# で Aspose.Slides を使用して OLE オブジェクトを操作します: 埋め込みファイルの挿入または更新、アイコンやリンクの設定、コンテンツの抽出、PPT、PPTX、ODP の動作を制御します。"
---

**Aspose.Slides for .NET** を使用して、ファイルを OLE オブジェクトとして埋め込み、そのデータを更新する方法を示します。

## OLE オブジェクトの追加

PDF ファイルをプレゼンテーションに埋め込みます。
```csharp
static void Add_Ole_Object()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);
}
```


## OLE オブジェクトへのアクセス

スライド上の最初の OLE オブジェクト フレームを取得します。
```csharp
static void Access_Ole_Object()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);

    var firstOle = slide.Shapes.OfType<IOleObjectFrame>().First();
}
```


## OLE オブジェクトの削除

スライドから埋め込まれた OLE オブジェクトを削除します。
```csharp
static void Remove_Ole_Object()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);

    slide.Shapes.Remove(ole);
}
```


## OLE オブジェクト データの更新

既存の OLE オブジェクトに埋め込まれたデータを置き換えます。
```csharp
static void Update_Ole_Object_Data()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);

    var newData = new OleEmbeddedDataInfo(File.ReadAllBytes("Picture.png"), "png");
    ole.SetEmbeddedData(newData);
}
```
