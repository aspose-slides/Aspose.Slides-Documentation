---
title: الارتباط التشعبي
type: docs
weight: 130
url: /ar/net/examples/elements/hyperlink/
keywords:
- الارتباط التشعبي
- إضافة ارتباط تشعبي
- الوصول إلى ارتباط تشعبي
- إزالة ارتباط تشعبي
- تحديث ارتباط تشعبي
- مثال على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إضافة وإدارة الارتباطات التشعبية في Aspose.Slides for .NET: ربط النصوص والأشكال والصور، تعيين الأهداف والإجراءات لملفات PPT و PPTX و ODP مع أمثلة بلغة C#."
---
توضح هذه المقالة إضافة، الوصول، إزالة وتحديث الروابط التشعبية على الأشكال باستخدام **Aspose.Slides for .NET**.

## **إضافة ارتباط تشعبي**

قم بإنشاء شكل مستطيل يحتوي على ارتباط تشعبي يوجه إلى موقع ويب خارجي.

```csharp
static void AddHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```

## **الوصول إلى ارتباط تشعبي**

اقرأ معلومات الارتباط التشعبي من جزء النص داخل الشكل.

```csharp
static void AccessHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```

## **إزالة ارتباط تشعبي**

امسح الارتباط التشعبي من نص الشكل.

```csharp
static void RemoveHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    textPortion.PortionFormat.HyperlinkClick = null;
}
```

## **تحديث ارتباط تشعبي**

غيّر هدف الارتباط التشعبي الموجود. استخدم `HyperlinkManager` لتعديل النص الذي يحتوي بالفعل على ارتباط تشعبي، مما يحاكي طريقة تحديث PowerPoint للارتباطات التشعبية بأمان.

```csharp
static void UpdateHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // يجب تعديل ارتباط تشعبي داخل نص موجود عبر
    // HyperlinkManager بدلاً من تعيين الخاصية مباشرةً.
    // هذا يحاكي طريقة تحديث PowerPoint للروابط التشعبية بأمان.
    textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```