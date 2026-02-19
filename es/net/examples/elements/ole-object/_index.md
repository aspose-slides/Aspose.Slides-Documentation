---
title: Objeto OLE
type: docs
weight: 210
url: /es/net/examples/elements/ole-object/
keywords:
- objeto OLE
- agregar objeto OLE
- acceder a objeto OLE
- eliminar objeto OLE
- actualizar objeto OLE
- ejemplo de código
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Maneje objetos OLE en Aspose.Slides for .NET: inserte, vincule, actualice y extraiga contenido incrustado con C# en presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo incrustar un archivo como objeto OLE y actualizar sus datos usando **Aspose.Slides for .NET**.

## **Agregar un objeto OLE**

Incruste un archivo PDF en la presentación.

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

## **Acceder a un objeto OLE**

Recupere el primer marco de objeto OLE en una diapositiva.

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

## **Eliminar un objeto OLE**

Elimine un objeto OLE incrustado de la diapositiva.

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

## **Actualizar datos del objeto OLE**

Reemplace los datos incrustados en un objeto OLE existente.

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