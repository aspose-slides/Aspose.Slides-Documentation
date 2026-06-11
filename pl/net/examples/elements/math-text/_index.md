---
title: Tekst matematyczny
type: docs
weight: 160
url: /pl/net/examples/elements/math-text/
keywords:
- tekst matematyczny
- dodaj tekst matematyczny
- dostęp do tekstu matematycznego
- usuń tekst matematyczny
- formatowanie tekstu matematycznego
- przykład kodu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Poznaj przykłady MathematicalText w Aspose.Slides for .NET: twórz i formatuj równania, ułamki, macierze oraz symbole przy użyciu C# w prezentacjach PPT, PPTX i ODP."
---
Ten artykuł pokazuje, jak pracować z kształtami tekstu matematycznego i formatowaniem równań przy użyciu **Aspose.Slides for .NET**.

## **Dodaj tekst matematyczny**

Utwórz kształt matematyczny zawierający ułamek i wzór pitagorejski.

```csharp
static void AddMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Dodaj kształt matematyczny do slajdu.
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // Uzyskaj dostęp do akapitu matematycznego.
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // Dodaj prosty ułamek: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // Dodaj równanie: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```

## **Dostęp do tekstu matematycznego**

Znajdź kształt, który zawiera akapit matematyczny na slajdzie.

```csharp
static void AccessMathText()
{
    using var presentation = new Presentation("sample.pptx");
    var slide = presentation.Slides[0];

    // Znajdź pierwszy kształt, który zawiera akapit matematyczny.
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Przykład: utwórz ułamek (nie dodano tutaj).
        var fraction = new MathematicalText("x").Divide("y");

        // Użyj mathParagraph lub fraction w razie potrzeby...
    }
}
```

## **Usuń tekst matematyczny**

Usuń kształt matematyczny ze slajdu.

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

## **Formatuj tekst matematyczny**

Ustaw właściwości czcionki dla części matematycznej.

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