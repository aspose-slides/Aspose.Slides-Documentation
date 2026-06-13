---
title: شیء OLE
type: docs
weight: 210
url: /fa/net/examples/elements/ole-object/
keywords:
- شیء OLE
- افزودن شیء OLE
- دسترسی به شیء OLE
- حذف شیء OLE
- به‌روزرسانی شیء OLE
- مثال کد
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "مدیریت اشیاء OLE در Aspose.Slides برای .NET: درج، پیوند، به‌روزرسانی و استخراج محتوای جاسازی‌شده با C# در ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد که چگونه یک فایل را به عنوان یک شیء OLE جاسازی کنید و داده‌های آن را با استفاده از **Aspose.Slides for .NET** به‌روزرسانی کنید.

## **افزودن یک شیء OLE**

یک فایل PDF را در ارائه جاسازی کنید.

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

## **دسترسی به شیء OLE**

قاب اولین شیء OLE را در یک اسلاید بازیابی کنید.

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

## **حذف یک شیء OLE**

یک شیء OLE جاسازی‌شده را از اسلاید حذف کنید.

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

## **به‌روزرسانی داده‌های شیء OLE**

داده‌های جاسازی‌شده در یک شیء OLE موجود را جایگزین کنید.

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