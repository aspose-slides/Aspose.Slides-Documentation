---
title: Matematik Metni
type: docs
weight: 160
url: /tr/net/examples/elements/math-text/
keywords:
- matematik metni
- matematik metni ekle
- matematik metnine eriş
- matematik metni kaldır
- matematik metni biçimlendir
- kod örneği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET MatematikselMetin örneklerini keşfedin: C# ile PPT, PPTX ve ODP sunumlarında denklemler, kesirler, matrisler ve semboller oluşturun ve biçimlendirin."
---
Bu makale, **Aspose.Slides for .NET** kullanarak matematiksel metin şekilleriyle çalışma ve denklemleri biçimlendirme konularını göstermektedir.

## **Matematik Metni Ekle**

Bir kesir ve Pisagor formülünü içeren bir matematik şekli oluşturun.

```csharp
static void AddMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Slayda bir Matematik şekli ekle.
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // Matematik paragrafına eriş.
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // Basit bir kesir ekle: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // Denklem ekle: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```

## **Matematik Metnine Eriş**

Slaytta bir matematik paragrafı içeren bir şekli bulun.

```csharp
static void AccessMathText()
{
    using var presentation = new Presentation("sample.pptx");
    var slide = presentation.Slides[0];

    // İlk matematik paragrafı içeren şekli bul.
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Örnek: bir kesir oluştur (burada eklenmedi).
        var fraction = new MathematicalText("x").Divide("y");

        // Use mathParagraph or fraction as needed...
    }
}
```

## **Matematik Metnini Kaldır**

Slayttan bir matematik şekli silin.

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

## **Matematik Metnini Biçimlendir**

Bir matematik bölümünün yazı tipi özelliklerini ayarlayın.

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