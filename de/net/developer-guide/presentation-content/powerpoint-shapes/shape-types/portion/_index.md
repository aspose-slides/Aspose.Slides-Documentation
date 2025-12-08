---
title: Portion
type: docs
weight: 70
url: /de/net/portion/
keywords: "Portion, PowerPoint-Form, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides for .NET"
description: "Portion in PowerPoint-Präsentation in C# oder .NET abrufen"
---

## **Positionskoordinaten des Abschnitts abrufen**
**GetCoordinates()** Methode wurde zur IPortion- und Portion-Klasse hinzugefügt, die das Abrufen der Koordinaten des Beginns des Abschnitts ermöglicht:
```c#
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textFrame = (ITextFrame)shape.TextFrame;

    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (Portion portion in paragraph.Portions)
        {
            PointF point = portion.GetCoordinates();
            Console.Write(Environment.NewLine + "Corrdinates X =" + point.X + " Corrdinates Y =" + point.Y);
        }
    }
}
```


## **FAQ**

**Kann ich einen Hyperlink nur auf einen Teil des Textes innerhalb eines einzelnen Absatzes anwenden?**

Ja, Sie können [einen Hyperlink zuweisen](/slides/de/net/manage-hyperlinks/) einem einzelnen Abschnitt; nur dieses Fragment ist anklickbar, nicht der gesamte Absatz.

**Wie funktioniert die Stilvererbung: Was überschreibt ein Abschnitt und was wird von Absatz/TextFrame übernommen?**

Eigenschaften auf Portion-Ebene haben die höchste Priorität. Wenn eine Eigenschaft nicht im [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) festgelegt ist, übernimmt die Engine sie vom [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/); ist sie dort ebenfalls nicht gesetzt, vom [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) oder vom [theme](https://reference.aspose.com/slides/net/aspose.slides.theme/theme/) Stil.

**Was passiert, wenn die für einen Portion angegebene Schriftart auf dem Zielrechner/Server fehlt?**

[Regeln für die Schriftartsubstitution](/slides/de/net/font-selection-sequence/) gelten. Der Text kann umfließen: Metriken, Silbentrennung und Breite können sich ändern, was für eine präzise Positionierung wichtig ist.

**Kann ich für einen Portion spezifische Textfülltransparenz oder einen Farbverlauf unabhängig vom Rest des Absatzes festlegen?**

Ja, Textfarbe, Füllung und Transparenz auf [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/)‑Ebene können von benachbarten Fragmenten abweichen.