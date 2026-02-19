---
title: نص رياضي
type: docs
weight: 160
url: /ar/net/examples/elements/math-text/
keywords:
- نص رياضي
- إضافة نص رياضي
- الوصول إلى نص رياضي
- إزالة نص رياضي
- تنسيق نص رياضي
- مثال على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استكشف أمثلة Aspose.Slides for .NET لـ MathematicalText: إنشاء وتنسيق المعادلات والكُسور والمصفوفات والرموز باستخدام C# في عروض PPT و PPTX و ODP."
---
توضح هذه المقالة العمل مع أشكال النص الرياضي وتنسيق المعادلات باستخدام **Aspose.Slides for .NET**.

## **إضافة نص رياضي**

إنشاء شكل رياضي يحتوي على كسر وصيغة فيثاغورس.

```csharp
static void AddMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // إضافة شكل رياضي إلى الشريحة.
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // الوصول إلى الفقرة الرياضية.
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
static void AccessMathText()
{
    using var presentation = new Presentation("sample.pptx");
    var slide = presentation.Slides[0];

    // ابحث عن أول شكل يحتوي على فقرة رياضية.
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // مثال: إنشاء كسر (غير مضاف هنا).
        var fraction = new MathematicalText("x").Divide("y");

        // Use mathParagraph or fraction as needed...
    }
}
```

## **إزالة نص رياضي**

حذف شكل رياضي من الشريحة.

```csharp
static void RemoveMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

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
static void FormatMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    mathShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 20;
}
```