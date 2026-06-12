---
title: Wiskundige tekst
type: docs
weight: 160
url: /nl/net/examples/elements/math-text/
keywords:
- wiskundige tekst
- wiskundige tekst toevoegen
- wiskundige tekst benaderen
- wiskundige tekst verwijderen
- wiskundige tekst opmaken
- codevoorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek voorbeelden van MathematicalText in Aspose.Slides voor .NET: maak en formatteer vergelijkingen, breuken, matrices en symbolen met C# in PPT-, PPTX- en ODP-presentaties."
---
Dit artikel toont hoe u met wiskundige tekstvormen kunt werken en vergelijkingen kunt opmaken met **Aspose.Slides for .NET**.

## **Wiskundige tekst toevoegen**

Maak een wiskunde‑vorm die een breuk en de stelling van Pythagoras bevat.

```csharp
static void AddMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Voeg een wiskundige vorm toe aan de dia.
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // Benader de wiskundige alinea.
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // Voeg een eenvoudige breuk toe: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // Voeg vergelijking toe: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```

## **Wiskundige tekst benaderen**

Zoek een vorm die een wiskundige alinea op de dia bevat.

```csharp
static void AccessMathText()
{
    using var presentation = new Presentation("sample.pptx");
    var slide = presentation.Slides[0];

    // Zoek de eerste vorm die een wiskundige alinea bevat.
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Voorbeeld: maak een breuk (hier niet toegevoegd).
        var fraction = new MathematicalText("x").Divide("y");

        // Gebruik mathParagraph of fraction naar behoefte...
    }
}
```

## **Wiskundige tekst verwijderen**

Verwijder een wiskunde‑vorm van de dia.

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

## **Wiskundige tekst opmaken**

Stel de lettertype‑eigenschappen in voor een wiskundig gedeelte.

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