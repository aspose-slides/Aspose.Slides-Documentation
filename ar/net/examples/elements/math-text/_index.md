---
title: نص رياضي
type: docs
weight: 160
url: /ar/net/examples/elements/math-text/
keywords:
- مثال نص رياضي
- إضافة نص رياضي
- الوصول إلى نص رياضي
- إزالة نص رياضي
- تنسيق نص رياضي
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "العمل مع نص رياضي في C# باستخدام Aspose.Slides: إنشاء وتحرير المعادلات، الكسور، الجذور، النصوص المتدرجة، التنسيق، وعرض النتائج للـ PPT و PPTX."
---

يوضح كيفية العمل مع أشكال النص الرياضي وتنسيق المعادلات باستخدام **Aspose.Slides for .NET**.

## **إضافة نص رياضي**

إنشاء شكل رياضي يحتوي على كسر وصيغة فيثاغورس.
```csharp
static void Add_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // أضف شكل رياضي إلى الشريحة
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // الوصول إلى الفقرة الرياضية
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // إضافة كسر بسيط: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // إضافة معادلة: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```


## **الوصول إلى نص رياضي**

تحديد شكل يحتوي على فقرة رياضية في الشريحة.
```csharp
static void Access_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // ابحث عن الشكل الأول الذي يحتوي على فقرة رياضية
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // مثال: إنشاء كسر (غير مضاف هنا)
        var fraction = new MathematicalText("x").Divide("y");

        // استخدم mathParagraph أو fraction حسب الحاجة...
    }
}
```


## **إزالة نص رياضي**

حذف شكل رياضي من الشريحة.
```csharp
static void Remove_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    slide.Shapes.Remove(mathShape);
}
```


## **تنسيق نص رياضي**

تعيين خصائص الخط لجزء رياضي.
```csharp
static void Format_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    mathShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 20;
}
```
