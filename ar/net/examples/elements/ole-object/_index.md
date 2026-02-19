---
title: كائن OLE
type: docs
weight: 210
url: /ar/net/examples/elements/ole-object/
keywords:
- كائن OLE
- إضافة كائن OLE
- الوصول إلى كائن OLE
- إزالة كائن OLE
- تحديث كائن OLE
- مثال على الشفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "معالجة كائنات OLE في Aspose.Slides for .NET: إدراج، ربط، تحديث، واستخراج المحتوى المضمن باستخدام C# في عروض PPT و PPTX و ODP."
---
توضح هذه المقالة كيفية تضمين ملف ككائن OLE وتحديث بياناته باستخدام **Aspose.Slides for .NET**.

## **إضافة كائن OLE**

تضمين ملف PDF في العرض التقديمي.

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

## **الوصول إلى كائن OLE**

استرجاع إطار كائن OLE الأول في الشريحة.

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

## **إزالة كائن OLE**

حذف كائن OLE المضمن من الشريحة.

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

## **تحديث بيانات كائن OLE**

استبدال البيانات المضمنة في كائن OLE موجود.

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