---
title: حبر
type: docs
weight: 180
url: /ar/net/examples/elements/ink/
keywords:
- حبر
- الوصول إلى الحبر
- إزالة الحبر
- مثال على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "العمل مع الحبر في Aspose.Slides for .NET: رسم، استيراد، وتعديل الخطوط، ضبط اللون والعرض، وتصدير إلى PPT، PPTX، و ODP باستخدام أمثلة C#."
---
توفر هذه المقالة أمثلة على الوصول إلى أشكال الحبر الموجودة وإزالتها باستخدام **Aspose.Slides for .NET**.

> ❗ **ملاحظة:** تمثل أشكال الحبر إدخال المستخدم من الأجهزة المتخصصة. لا يمكن لـ Aspose.Slides إنشاء ضربات حبر جديدة برمجياً، ولكن يمكنك قراءة الحبر الموجود وتعديله.

## **الوصول إلى الحبر**

اقرأ الوسوم من أول شكل حبر في الشريحة.

```csharp
static void AccessInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // استخدم tagName حسب الحاجة.
        }
    }
}
```

## **إزالة الحبر**

احذف شكل حبر من الشريحة إذا كان موجوداً.

```csharp
static void RemoveInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```