---
title: Matematiskt text
type: docs
weight: 160
url: /sv/net/examples/elements/math-text/
keywords:
- matematiktext
- lägg till matematiktext
- åtkomst till matematiktext
- ta bort matematiktext
- formatera matematiktext
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Utforska exempel på Matematiskt Text i Aspose.Slides för .NET: skapa och formatera ekvationer, bråktal, matriser och symboler med C# i PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur man arbetar med matematiska textformer och formaterar ekvationer med **Aspose.Slides for .NET**.

## **Lägg till matematiktext**

Skapa en matematikform som innehåller en bråkdel och Pythagoras formel.

```csharp
static void AddMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Lägg till en matematisk form på bilden.
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // Kom åt det matematiska stycket.
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // Lägg till ett enkelt bråk: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // Lägg till ekvation: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```

## **Åtkomst till matematiktext**

Lokalisera en form som innehåller ett matematikstycke på bilden.

```csharp
static void AccessMathText()
{
    using var presentation = new Presentation("sample.pptx");
    var slide = presentation.Slides[0];

    // Hitta den första formen som innehåller ett matematiskt stycke.
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Exempel: skapa ett bråk (ej tillagt här).
        var fraction = new MathematicalText("x").Divide("y");

        // Använd mathParagraph eller fraction vid behov...
    }
}
```

## **Ta bort matematiktext**

Ta bort en matematikform från bilden.

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

## **Formatera matematiktext**

Ange teckensnittsegenskaper för en matematisk del.

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