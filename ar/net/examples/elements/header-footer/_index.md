---
title: رأس وتذييل
type: docs
weight: 220
url: /ar/net/examples/elements/elements/header-footer/
keywords:
- مثال رأس وتذييل
- إضافة رأس وتذييل
- تحديث رأس وتذييل
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "التحكم في الرؤوس والتذييلات في C# باستخدام Aspose.Slides: إضافة أو تعديل التاريخ/الوقت، أرقام الشرائح، ونص التذييل، إظهار أو إخفاء العناصر النائبة عبر PPT وPPTX وODP."
---

يوضح كيفية إضافة تذييلات وتحديث عناصر النائب للوقت والتاريخ باستخدام **Aspose.Slides for .NET**.

## **إضافة تذييل**

أضف النص إلى منطقة التذييل في الشريحة واجعلها مرئية.
```csharp
static void Add_Header_Footer()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```


## **تحديث التاريخ والوقت**

تعديل عنصر النائب للتاريخ والوقت في الشريحة.
```csharp
static void Update_Date_Time()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```
