---
title: كائن OLE
type: docs
weight: 210
url: /ar/net/examples/elements/ole-object/
keywords:
- مثال كائن OLE
- إضافة كائن OLE
- الوصول إلى كائن OLE
- إزالة كائن OLE
- تحديث كائن OLE
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "العمل مع كائنات OLE في C# باستخدام Aspose.Slides: إدراج أو تحديث الملفات المدمجة، تعيين الرموز أو الروابط، استخراج المحتوى، التحكم في السلوك لملفات PPT و PPTX و ODP."
---

يُظهر كيفية تضمين ملف ككائن OLE وتحديث بياناته باستخدام **Aspose.Slides for .NET**.

## **إضافة كائن OLE**

تضمين ملف PDF في العرض التقديمي.
```csharp
static void Add_Ole_Object()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);
}
```


## **الوصول إلى كائن OLE**

استرجاع الإطار الأول لكائن OLE على الشريحة.
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


## **إزالة كائن OLE**

حذف كائن OLE المضمّن من الشريحة.
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


## **تحديث بيانات كائن OLE**

استبدال البيانات المُضمّنة في كائن OLE موجود.
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
