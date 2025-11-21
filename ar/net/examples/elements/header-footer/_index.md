---
title: رأس وتذييل
type: docs
weight: 220
url: /ar/net/examples/elements/elements/header-footer/
keywords:
- مثال على الرأس والتذييل
- إضافة رأس وتذييل
- تحديث رأس وتذييل
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "التحكم في الرؤوس والتذييلات في C# باستخدام Aspose.Slides: إضافة أو تعديل التاريخ/الوقت، أرقام الشرائح، ونص التذييل، إظهار أو إخفاء العناصر النائبة عبر PPT و PPTX و ODP."
---

يوضح كيفية إضافة تذييلات وتحديث عناصر نائب التاريخ والوقت باستخدام **Aspose.Slides for .NET**.

## إضافة تذييل

أضف نصًا إلى منطقة التذييل في الشريحة واجعله مرئيًا.
```csharp
static void Add_Header_Footer()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```


## تحديث التاريخ والوقت

قم بتعديل عنصر نائب التاريخ والوقت في الشريحة.
```csharp
static void Update_Date_Time()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```
