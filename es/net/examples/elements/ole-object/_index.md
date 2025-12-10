---
title: ObjetoOLE
type: docs
weight: 210
url: /es/net/examples/elements/ole-object/
keywords:
- Ejemplo de objeto OLE
- agregar objeto OLE
- acceder a objeto OLE
- eliminar objeto OLE
- actualizar objeto OLE
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Trabaje con objetos OLE en C# usando Aspose.Slides: inserte o actualice archivos incrustados, establezca íconos o enlaces, extraiga contenido, controle el comportamiento para PPT, PPTX y ODP."
---

Demuestra la inserción de un archivo como objeto OLE y la actualización de sus datos usando **Aspose.Slides for .NET**.

## **Agregar un objeto OLE**

Inserte un archivo PDF en la presentación.
```csharp
static void Add_Ole_Object()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);
}
```


## **Acceder a un objeto OLE**

Recupere el primer marco de objeto OLE en una diapositiva.
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


## **Eliminar un objeto OLE**

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


## **Actualizar datos del objeto OLE**

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
