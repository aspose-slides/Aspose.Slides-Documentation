---
title: MathText
type: docs
weight: 160
url: /de/net/examples/elements/math-text/
keywords:
- Beispiel für mathematischen Text
- Mathe-Text hinzufügen
- Mathe-Text abrufen
- Mathe-Text entfernen
- Mathe-Text formatieren
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Arbeiten Sie in C# mit Aspose.Slides an mathematischem Text: Erstellen und bearbeiten Sie Gleichungen, Brüche, Wurzeln, Hoch‑ und Tiefschrift, Formatierung und rendern Sie die Ergebnisse für PPT und PPTX."
---

Zeigt, wie man mit mathematischen Textformen arbeitet und Gleichungen mit **Aspose.Slides for .NET** formatiert.

## **Mathe-Text hinzufügen**

Erstellen Sie eine mathematische Form, die einen Bruch und die pythagoreische Formel enthält.
```csharp
static void Add_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Eine Math-Form zur Folie hinzufügen
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // Auf den mathematischen Absatz zugreifen
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // Einen einfachen Bruch hinzufügen: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // Gleichung hinzufügen: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```


## **Zugriff auf mathematischen Text**

Suchen Sie eine Form, die einen mathematischen Absatz auf der Folie enthält.
```csharp
static void Access_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Finden Sie die erste Form, die einen mathematischen Absatz enthält
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Beispiel: Erstelle einen Bruch (hier nicht hinzugefügt)
        var fraction = new MathematicalText("x").Divide("y");

        // Verwenden Sie mathParagraph oder fraction nach Bedarf...
    }
}
```


## **Mathe-Text entfernen**

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


## **Mathe-Text formatieren**

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
