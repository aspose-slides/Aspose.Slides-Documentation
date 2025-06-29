---
title: MathText
type: docs
weight: 160
url: /net/examples/elements/mathtext
---

Illustrates working with mathematical text shapes and formatting equations using **Aspose.Slides for .NET**.

## Add Math Text

Create a math shape containing a fraction and the Pythagorean formula.

```csharp
static void Add_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Add a Math shape to the slide
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // Access the math paragraph
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // Add a simple fraction: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // Add equation: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```

## Access Math Text

Locate a shape that contains a math paragraph on the slide.

```csharp
static void Access_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Find the first shape that contains a math paragraph
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Example: create a fraction (not added here)
        var fraction = new MathematicalText("x").Divide("y");

        // Use mathParagraph or fraction as needed...
    }
}
```

## Remove Math Text

Delete a math shape from the slide.

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

## Format Math Text

Set font properties for a math portion.

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
