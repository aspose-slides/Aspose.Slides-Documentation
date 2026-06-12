---
title: OLE objekt
type: docs
weight: 210
url: /cs/net/examples/elements/ole-object/
keywords:
- OLE objekt
- přidat OLE objekt
- přístup k OLE objektu
- odstranit OLE objekt
- aktualizovat OLE objekt
- ukázka kódu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Pracujte s OLE objekty v Aspose.Slides pro .NET: vkládejte, propojujte, aktualizujte a získávejte vložený obsah pomocí C# v prezentacích PPT, PPTX a ODP."
---
Tento článek ukazuje, jak vložit soubor jako OLE objekt a aktualizovat jeho data pomocí **Aspose.Slides for .NET**.

## **Přidat OLE objekt**

Vložte soubor PDF do prezentace.

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

## **Přístup k OLE objektu**

Získejte první rámeček OLE objektu na snímku.

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

## **Odstranit OLE objekt**

Smažte vložený OLE objekt ze snímku.

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

## **Aktualizovat data OLE objektu**

Nahraďte data vložená v existujícím OLE objektu.

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