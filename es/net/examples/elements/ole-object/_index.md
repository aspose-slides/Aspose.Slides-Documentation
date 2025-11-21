---
title: Objeto OLE
type: docs
weight: 210
url: /es/net/examples/elements/ole-object/
keywords:
- Ejemplo de objeto OLE
- Agregar objeto OLE
- Acceder a objeto OLE
- Eliminar objeto OLE
- Actualizar objeto OLE
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Trabaje con objetos OLE en C# usando Aspose.Slides: inserte o actualice archivos incrustados, establezca íconos o enlaces, extraiga contenido, controle el comportamiento para PPT, PPTX y ODP."
---

Demuestra cómo incrustar un archivo como un objeto OLE y actualizar sus datos usando **Aspose.Slides for .NET**.

## Agregar un objeto OLE

Incruste un archivo PDF en la presentación.
```csharp
static void Add_Ole_Object()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);
}
```


## Acceder a un objeto OLE

Recupere el primer fotograma de objeto OLE en una diapositiva.
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


## Eliminar un objeto OLE

Elimine un objeto OLE incrustado de la diapositiva.
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


## Actualizar datos del objeto OLE

Reemplace los datos incrustados en un objeto OLE existente.
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
