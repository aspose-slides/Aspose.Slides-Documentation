---
title: الحبر
type: docs
weight: 180
url: /ar/net/examples/elements/ink/
keywords:
- مثال الحبر
- الوصول إلى الحبر
- إزالة الحبر
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعامل مع الحبر الرقمي على الشرائح في C# باستخدام Aspose.Slides: أضف ضربات القلم، حرّر المسارات، اضبط اللون والعرض، وقم بتصدير النتائج إلى PowerPoint و OpenDocument."
---

يوفر أمثلة على الوصول إلى أشكال الحبر الموجودة وإزالتها باستخدام **Aspose.Slides for .NET**.

> ❗ **ملاحظة:** تمثل أشكال الحبر مدخلات المستخدم من الأجهزة المتخصصة. لا يمكن لـ Aspose.Slides إنشاء ضربات حبر جديدة برمجياً،ولكن يمكنك قراءة الحبر الموجود وتعديله.

## **الوصول إلى الحبر**

قراءة العلامات من أول شكل حبر في الشريحة.
```csharp
static void Access_Ink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // استخدم tagName حسب الحاجة
        }
    }
}
```


## **إزالة الحبر**

حذف شكل الحبر من الشريحة إذا كان موجودًا.
```csharp
static void Remove_Ink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```
