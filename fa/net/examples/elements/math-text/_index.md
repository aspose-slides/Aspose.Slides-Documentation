---
title: متن ریاضی
type: docs
weight: 160
url: /fa/net/examples/elements/math-text/
keywords:
- متن ریاضی
- افزودن متن ریاضی
- دسترسی به متن ریاضی
- حذف متن ریاضی
- قالب‌بندی متن ریاضی
- نمونه کد
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "نمونه‌های MathematicalText در Aspose.Slides برای .NET را بررسی کنید: ایجاد و قالب‌بندی معادلات، کسرها، ماتریس‌ها و نمادها با C# در ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد که چگونه با اشکال متن ریاضی کار کنید و معادلات را با استفاده از **Aspose.Slides for .NET** فرمت‌بندی کنید.

## **افزودن متن ریاضی**

یک شکل ریاضی شامل یک کسر و فرمول فیثاغورث ایجاد کنید.

```csharp
static void AddMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // اضافه کردن یک شکل ریاضی به اسلاید.
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // دسترسی به پاراگراف ریاضی.
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // اضافه کردن یک کسر ساده: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // اضافه کردن معادله: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```

## **دسترسی به متن ریاضی**

یک شکل که شامل پاراگراف ریاضی در اسلاید باشد را پیدا کنید.

```csharp
static void AccessMathText()
{
    using var presentation = new Presentation("sample.pptx");
    var slide = presentation.Slides[0];

    // پیدا کردن اولین شکلی که شامل پاراگراف ریاضی است.
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // مثال: ایجاد یک کسر (در اینجا اضافه نشده).
        var fraction = new MathematicalText("x").Divide("y");

        // استفاده از mathParagraph یا fraction طبق نیاز...
    }
}
```

## **حذف متن ریاضی**

یک شکل ریاضی را از اسلاید حذف کنید.

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

## **قالب‌بندی متن ریاضی**

ویژگی‌های قلم را برای یک بخش ریاضی تنظیم کنید.

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