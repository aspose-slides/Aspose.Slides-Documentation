---
title: Textportionen in Präsentationen in .NET verwalten
linktitle: Textportion
type: docs
weight: 70
url: /de/net/portion/
keywords:
- Textportion
- Textteil
- Textkoordinaten
- Textposition
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Textportionen in PowerPoint-Präsentationen mit Aspose.Slides für .NET verwalten und dabei Leistung und Anpassbarkeit steigern."
---

## **Positionskoordinaten der Portion abrufen**
**GetCoordinates()**-Methode wurde zu IPortion und Portion-Klasse hinzugefügt, wodurch die Koordinaten des Beginns der Portion abgerufen werden können:
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

**Kann ich einen Hyperlink nur auf einen Teil des Textes in einem einzigen Absatz anwenden?**

Ja, Sie können [einen Hyperlink zuweisen](/slides/de/net/manage-hyperlinks/) einer einzelnen Portion; nur dieses Fragment wird anklickbar sein, nicht der gesamte Absatz.

**Wie funktioniert die Stilvererbung: Was überschreibt eine Portion und was wird aus Paragraph/TextFrame übernommen?**

Eigenschaften auf Portion‑Ebene haben die höchste Priorität. Wenn eine Eigenschaft nicht auf der [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) festgelegt ist, übernimmt die Engine sie vom [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/); ist sie dort ebenfalls nicht festgelegt, wird sie vom [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) oder vom [theme](https://reference.aspose.com/slides/net/aspose.slides.theme/theme/) Stil übernommen.

**Was passiert, wenn die für eine Portion angegebene Schriftart auf dem Zielrechner/-server fehlt?**

[Schriftart‑Ersetzungsregeln](/slides/de/net/font-selection-sequence/) gelten. Der Text kann neu fließen: Metriken, Silbentrennung und Breite können sich ändern, was für genaue Positionierung wichtig ist.

**Kann ich für eine Portion eine eigene Textfülltransparenz oder einen eigenen Farbverlauf festlegen, unabhängig vom Rest des Absatzes?**

Ja, Textfarbe, Füllung und Transparenz auf der [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) Ebene können von benachbarten Fragmenten abweichen.