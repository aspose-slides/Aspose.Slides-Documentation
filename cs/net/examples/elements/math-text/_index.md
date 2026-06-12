---
title: Matematický text
type: docs
weight: 160
url: /cs/net/examples/elements/math-text/
keywords:
- matematický text
- přidat matematický text
- přístup k matematickému textu
- odstranit matematický text
- formátovat matematický text
- ukázka kódu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prozkoumejte příklady MathematicalText v Aspose.Slides pro .NET: vytvářejte a formátujte rovnice, zlomky, matice a symboly pomocí C# v prezentacích PPT, PPTX a ODP."
---
Tento článek ukazuje práci s matematickými textovými tvary a formátování rovnic pomocí **Aspose.Slides for .NET**.

## **Přidat matematický text**

Vytvořte matematický objekt obsahující zlomkový výraz a Pythagorovu větu.

```csharp
static void AddMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Přidat matematický tvar na snímek.
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // Přístup k matematickému odstavci.
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // Přidat jednoduchý zlomek: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // Přidat rovnici: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```

## **Přístup k matematickému textu**

Najděte objekt, který obsahuje matematický odstavec na snímku.

```csharp
static void AccessMathText()
{
    using var presentation = new Presentation("sample.pptx");
    var slide = presentation.Slides[0];

    // Najít první tvar, který obsahuje matematický odstavec.
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Příklad: vytvořit zlomek (nepřidáno zde).
        var fraction = new MathematicalText("x").Divide("y");

        // Použít mathParagraph nebo fraction podle potřeby...
    }
}
```

## **Odstranit matematický text**

Odstraňte matematický objekt ze snímku.

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

## **Formátovat matematický text**

Nastavte vlastnosti písma pro matematickou část.

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