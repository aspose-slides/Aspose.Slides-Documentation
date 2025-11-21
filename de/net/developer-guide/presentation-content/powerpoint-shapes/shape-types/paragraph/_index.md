---
title: Absatzgrenzen aus Präsentationen in .NET ermitteln
linktitle: Absatz
type: docs
weight: 60
url: /de/net/paragraph/
keywords:
- Absatzgrenzen
- Textabschnittsgrenzen
- Absatzkoordinate
- Portionskoordinate
- Absatzgröße
- Textabschnittsgröße
- Textfeld
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie in Aspose.Slides für .NET Absatz- und Textabschnittsgrenzen abrufen, um die Textpositionierung in PowerPoint‑Präsentationen zu optimieren."
---

## **Koordinaten von Paragraph und Portion in TextFrame abrufen**
Mit Aspose.Slides für .NET können Entwickler jetzt die rechteckigen Koordinaten für Paragraph innerhalb der Paragraphensammlung eines TextFrames erhalten. Es ermöglicht außerdem, die Koordinaten einer Portion innerhalb der Portionensammlung eines Paragraphen abzurufen. In diesem Thema zeigen wir anhand eines Beispiels, wie man die rechteckigen Koordinaten für Paragraph sowie die Position einer Portion innerhalb eines Paragraphen ermittelt.

## **Rechteckige Koordinaten eines Paragraphen abrufen**
Die neue Methode **GetRect()** wurde hinzugefügt. Sie ermöglicht das Abrufen des Rechtecks, das die Grenzen des Paragraphen beschreibt.
```c#
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```


## **Größe von Paragraph und Portion innerhalb eines Tabellenzellen-TextFrames ermitteln**
Um die Größe und die Koordinaten von [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion) bzw. [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) in einem Tabellenzellen-TextFrame zu erhalten, können Sie die Methoden [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/methods/getrect) und [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/methods/getrect) verwenden.

Dieser Beispielcode demonstriert die beschriebene Vorgehensweise:
```csharp
using (Presentation pres = new Presentation("source.pptx"))
{
    Table tbl = pres.Slides[0].Shapes[0] as Table;

    ICell cell = tbl.Rows[1][1];


    double x = tbl.X + tbl.Rows[1][1].OffsetX;
    double y = tbl.Y + tbl.Rows[1][1].OffsetY;

    foreach (IParagraph para in cell.TextFrame.Paragraphs)
    {
        if (para.Text == "")
            continue;

        RectangleF rect = para.GetRect();
        IAutoShape shape =
            pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
        shape.LineFormat.FillFormat.FillType = FillType.Solid;


        foreach (IPortion portion in para.Portions)
        {
            if (portion.Text.Contains("0"))
            {
                rect = portion.GetRect();
                shape =
                    pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                        rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

                shape.FillFormat.FillType = FillType.NoFill;
            }
        }
    }
}
```


## **FAQ**

**In welchen Einheiten werden die Koordinaten für einen Paragraph und Textportionen zurückgegeben?**

In Punkten, wobei 1 Zoll = 72 Punkte entspricht. Dies gilt für alle Koordinaten und Abmessungen auf der Folie.

**Beeinflusst die Zeilenumbruchs‑Funktion die Grenzen eines Paragraphen?**

Ja. Wenn [wrapping](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/) im [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) aktiviert ist, wird der Text umbrochen, um die Breite des Bereichs zu füllen, wodurch sich die tatsächlichen Grenzen des Paragraphen ändern.

**Lassen sich die Paragraph‑Koordinaten zuverlässig in Pixel im exportierten Bild umrechnen?**

Ja. Punkte können Sie mit folgender Formel in Pixel umrechnen: pixels = points × (DPI / 72). Das Ergebnis hängt vom für die Darstellung/den Export gewählten DPI ab.

**Wie erhalte ich die „effektiven“ Paragraph‑Formatierungsparameter, die die Vererbung von Styles berücksichtigen?**

Verwenden Sie die [effective paragraph formatting data structure](/slides/de/net/shape-effective-properties/); sie liefert die endgültigen konsolidierten Werte für Einzüge, Abstand, Zeilenumbruch, Rechts‑zu‑Links‑Richtung und weitere Einstellungen.