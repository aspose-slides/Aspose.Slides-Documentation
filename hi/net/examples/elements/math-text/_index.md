---
title: गणितीय पाठ
type: docs
weight: 160
url: /hi/net/examples/elements/math-text/
keywords:
- गणितीय पाठ
- गणितीय पाठ जोड़ें
- गणितीय पाठ तक पहुँचें
- गणितीय पाठ हटाएँ
- गणितीय पाठ स्वरूपित करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के गणितीय पाठ उदाहरणों का अन्वेषण करें: C# के साथ PPT, PPTX और ODP प्रस्तुतियों में समीकरण, भिन्न, मैट्रिक्स और प्रतीक बनाएं और स्वरूपित करें।"
---
यह लेख गणितीय पाठ आकारों के साथ काम करने और समीकरणों को स्वरूपित करने का प्रदर्शन करता है, **Aspose.Slides for .NET** का उपयोग करके।

## **गणितीय पाठ जोड़ें**

एक गणितीय आकार बनाएँ जिसमें एक भिन्न और पाइथागोरस सूत्र हो।

```csharp
static void AddMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // स्लाइड में एक गणितीय आकार जोड़ें।
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // गणितीय अनुच्छेद तक पहुँचें।
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // एक सरल भिन्न जोड़ें: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // समीकरण जोड़ें: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```

## **गणितीय पाठ तक पहुँचें**

स्लाइड में वह आकार खोजें जिसमें गणितीय अनुच्छेद हो।

```csharp
static void AccessMathText()
{
    using var presentation = new Presentation("sample.pptx");
    var slide = presentation.Slides[0];

    // पहला आकार खोजें जो गणितीय अनुच्छेद रखता हो।
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // उदाहरण: एक भिन्न बनाएँ (यहाँ नहीं जोड़ा गया)।
        var fraction = new MathematicalText("x").Divide("y");

        // आवश्यकता अनुसार mathParagraph या fraction का उपयोग करें...
    }
}
```

## **गणितीय पाठ हटाएँ**

स्लाइड से एक गणितीय आकार हटाएँ।

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

## **गणितीय पाठ को स्वरूपित करें**

गणितीय भाग के लिए फ़ॉन्ट गुण सेट करें।

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