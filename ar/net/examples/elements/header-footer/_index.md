---
title: ترويسة وتذييل
type: docs
weight: 220
url: /ar/net/examples/elements/header-footer/
keywords:
- ترويسة وتذييل
- إضافة ترويسة وتذييل
- تحديث ترويسة وتذييل
- مثال على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تحكم في رؤوس وتذييلات الشرائح باستخدام Aspose.Slides for .NET: أضف التواريخ، أرقام الشرائح، ونصًا مخصصًا في صيغ PPT و PPTX و ODP مع أمثلة C#."
---
توّضح هذه المقالة كيفية إضافة تذييلات وتحديث العنصر النائب للتاريخ والوقت باستخدام **Aspose.Slides for .NET**.

## **إضافة تذييل**

أضف نصًا إلى منطقة التذييل في الشريحة واجعلها مرئية.

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

عدّل العنصر النائب للتاريخ والوقت في الشريحة.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```