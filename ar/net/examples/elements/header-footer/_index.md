---
title: رأس وتذييل
type: docs
weight: 220
url: /ar/net/examples/elements/header-footer/
aliases:
  - /net/examples/elements/elements/header-footer/
keywords:
- رأس وتذييل
- إضافة رأس وتذييل
- تحديث رأس وتذييل
- مثال على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "التحكم في رؤوس وتذييلات الشرائح باستخدام Aspose.Slides for .NET: إضافة تواريخ، أرقام الشرائح، ونص مخصص في ملفات PPT و PPTX و ODP مع أمثلة C#."
---
توضح هذه المقالة كيفية إضافة تذييلات وتحديث عناصر نائب التاريخ والوقت باستخدام **Aspose.Slides for .NET**.

## **إضافة تذييل**

أضف نصًا إلى منطقة التذييل في الشريحة واجعله مرئيًا.

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **تحديث التاريخ والوقت**

عدل عنصر نائب التاريخ والوقت في الشريحة.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```