---
title: Matematikai szöveg
type: docs
weight: 160
url: /hu/net/examples/elements/math-text/
keywords:
- matematikai szöveg
- matematikai szöveg hozzáadása
- matematikai szöveg elérése
- matematikai szöveg eltávolítása
- matematikai szöveg formázása
- kódpélda
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for .NET MathematicalText példákat: egyenletek, törtek, mátrixok és szimbólumok létrehozása és formázása C#-val PPT, PPTX és ODP prezentációkban."
---
Ez a cikk bemutatja a matematikai szöveges alakzatok használatát és egyenletek formázását a **Aspose.Slides for .NET** segítségével.

## **Matematikai szöveg hozzáadása**

Hozzon létre egy olyan matematikai alakzatot, amely tartalmaz egy törtet és a Pitagorasz-formulát.

```csharp
static void AddMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Adj egy Math alakzatot a diára.
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // A math bekezdés elérése.
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // Egyszerű tört hozzáadása: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // Egyenlet hozzáadása: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```

## **Matematikai szöveg elérése**

Keressen egy alakzatot a dián, amely matematikai bekezdést tartalmaz.

```csharp
static void AccessMathText()
{
    using var presentation = new Presentation("sample.pptx");
    var slide = presentation.Slides[0];

    // Keresse meg az első alakzatot, amely matematikai bekezdést tartalmaz.
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Példa: egy tört létrehozása (itt nincs hozzáadva).
        var fraction = new MathematicalText("x").Divide("y");

        // Használja a mathParagraph-et vagy a fraction-t szükség szerint...
    }
}
```

## **Matematikai szöveg eltávolítása**

Törölje a matematikai alakzatot a diáról.

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

## **Matematikai szöveg formázása**

Állítsa be a betűtulajdonságokat egy matematikai részhez.

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