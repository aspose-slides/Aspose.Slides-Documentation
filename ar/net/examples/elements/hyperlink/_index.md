---
title: الارتباط التشعبي
type: docs
weight: 130
url: /ar/net/examples/elements/hyperlink/
keywords:
- مثال على الارتباط التشعبي
- إضافة ارتباط تشعبي
- الوصول إلى ارتباط تشعبي
- إزالة ارتباط تشعبي
- تحديث ارتباط تشعبي
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إضافة وتحرير وإزالة الروابط التشعبية في C# باستخدام Aspose.Slides: ربط النص، الأشكال، الشرائح، عناوين URL والبريد الإلكتروني؛ تعيين الأهداف والإجراءات لملفات PPT و PPTX و ODP."
---

يوضح إضافة، وصول، إزالة وتحديث الارتباطات التشعبية على الأشكال باستخدام **Aspose.Slides for .NET**.

## **إضافة ارتباط تشعبي**
إنشاء شكل مستطيل يحتوي على ارتباط تشعبي يشير إلى موقع ويب خارجي.
```csharp
static void Add_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```


## **الوصول إلى ارتباط تشعبي**
قراءة معلومات الارتباط التشعبي من جزء النص في الشكل.
```csharp
static void Access_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```


## **إزالة ارتباط تشعبي**
إزالة الارتباط التشعبي من نص الشكل.
```csharp
static void Remove_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = null;
}
```


## **تحديث ارتباط تشعبي**
تغيير هدف ارتباط تشعبي موجود. استخدم `HyperlinkManager` لتعديل النص الذي يحتوي بالفعل على ارتباط تشعبي، وهو ما يحاكي طريقة تحديث PowerPoint للروابط التشعبية بأمان.
```csharp
static void Update_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // يجب تغيير ارتباط تشعبي داخل النص الموجود عبر
    // HyperlinkManager بدلاً من تعيين الخاصية مباشرة.
    // هذا يحاكي طريقة تحديث PowerPoint للروابط التشعبية بأمان.
    portion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```
