---
title: OLE objektum
type: docs
weight: 210
url: /hu/net/examples/elements/ole-object/
keywords:
- OLE objektum
- OLE objektum hozzáadása
- OLE objektum elérése
- OLE objektum eltávolítása
- OLE objektum frissítése
- kódpélda
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Kezelje az OLE objektumokat az Aspose.Slides for .NET-ben: beillesztés, hivatkozás, frissítés és a beágyazott tartalom kinyerése C#-val PPT, PPTX és ODP prezentációkban."
---
Ez a cikk bemutatja, hogyan lehet egy fájlt OLE objektumként beágyazni, és frissíteni annak adatait a **Aspose.Slides for .NET** használatával.

## **OLE objektum hozzáadása**

Ágyazzon be egy PDF fájlt a prezentációba.

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

## **OLE objektum elérése**

Szerezze meg az első OLE objektumkeretet egy dián.

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

## **OLE objektum eltávolítása**

Törölje az beágyazott OLE objektumot a diáról.

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

## **OLE objektum adatainak frissítése**

Cserélje ki a meglévő OLE objektumba beágyazott adatokat.

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