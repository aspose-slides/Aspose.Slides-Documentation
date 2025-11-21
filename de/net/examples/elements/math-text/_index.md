---
title: MatheText
type: docs
weight: 160
url: /de/net/examples/elements/math-text/
keywords:
- Math-Text Beispiel
- Math-Text hinzufügen
- Math-Text abrufen
- Math-Text entfernen
- Math-Text formatieren
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Arbeiten Sie mit Math-Text in C# mit Aspose.Slides: Erstellen und Bearbeiten von Gleichungen, Brüchen, Wurzeln, Scripts, Formatierungen und Rendern der Ergebnisse für PPT und PPTX."
---

Veranschaulicht die Arbeit mit mathematischen Textformen und das Formatieren von Gleichungen mit **Aspose.Slides for .NET**.

## Mathe-Text hinzufügen

Erstellen Sie eine mathematische Form, die einen Bruch und die pythagoreische Formel enthält.
```csharp
static void Add_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Füge eine Math-Form zur Folie hinzu
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // Greife auf den Math-Absatz zu
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // Füge einen einfachen Bruch hinzu: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // Füge Gleichung hinzu: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```


## Mathe-Text abrufen

Suchen Sie eine Form, die einen mathematischen Absatz auf der Folie enthält.
```csharp
static void Access_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Finde die erste Form, die einen mathematischen Absatz enthält
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Beispiel: erstelle einen Bruch (hier nicht hinzugefügt)
        var fraction = new MathematicalText("x").Divide("y");

        // Verwende mathParagraph oder fraction nach Bedarf...
    }
}
```


## Mathe-Text entfernen

Löschen Sie eine mathematische Form von der Folie.
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


## Mathe-Text formatieren

Legen Sie die Schriftarteigenschaften für einen mathematischen Teil fest.
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
