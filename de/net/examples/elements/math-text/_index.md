---
title: Mathetext
type: docs
weight: 160
url: /de/net/examples/elements/math-text/
keywords:
- Mathetext
- Mathetext hinzufügen
- Zugriff auf Mathetext
- Mathetext entfernen
- Mathetext formatieren
- Codebeispiel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie Beispiele für MathematicalText mit Aspose.Slides für .NET: Erstellen und formatieren Sie Gleichungen, Brüche, Matrizen und Symbole mit C# in PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel demonstriert die Arbeit mit mathematischen Textformen und das Formatieren von Gleichungen mit **Aspose.Slides for .NET**.

## **Mathetext hinzufügen**

Erstellen Sie eine mathematische Form, die einen Bruch und die pythagoreische Formel enthält.

```csharp
static void AddMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Fügt der Folie eine mathematische Form hinzu.
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // Greift auf den Mathematik-Absatz zu.
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // Fügt einen einfachen Bruch hinzu: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // Fügt Gleichung hinzu: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```

## **Zugriff auf Mathetext**

Lokalisieren Sie eine Form, die einen mathematischen Absatz auf der Folie enthält.

```csharp
static void AccessMathText()
{
    using var presentation = new Presentation("sample.pptx");
    var slide = presentation.Slides[0];

    // Findet die erste Form, die einen Mathematikabschnitt enthält.
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Beispiel: Erstelle einen Bruch (hier nicht hinzugefügt).
        var fraction = new MathematicalText("x").Divide("y");

        // Verwende mathParagraph oder fraction nach Bedarf...
    }
}
```

## **Mathetext entfernen**

Löschen Sie eine mathematische Form von der Folie.

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

## **Mathetext formatieren**

Legen Sie die Schriftarteigenschaften für einen mathematischen Teil fest.

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