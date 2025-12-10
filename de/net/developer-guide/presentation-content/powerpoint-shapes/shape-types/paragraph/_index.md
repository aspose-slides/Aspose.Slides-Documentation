---
title: Absatzgrenzen aus Präsentationen in .NET abrufen
linktitle: Absatz
type: docs
weight: 60
url: /de/net/paragraph/
keywords:
- Absatzgrenzen
- Textabschnittsgrenzen
- Absatzkoordinate
- Portionkoordinate
- Absatzgröße
- Textabschnittsgröße
- Textfeld
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Absatz- und Textabschnittsgrenzen in Aspose.Slides für .NET abrufen, um die Textpositionierung in PowerPoint-Präsentationen zu optimieren."
---

## **Koordinaten von Absatz und Portion in einem TextFrame abrufen**
Mit Aspose.Slides für .NET können Entwickler nun die rechteckigen Koordinaten eines Absatzes innerhalb der Absatzsammlung eines TextFrames erhalten. Außerdem können Sie die Koordinaten einer Portion innerhalb der Portionssammlung eines Absatzes abrufen. In diesem Thema zeigen wir anhand eines Beispiels, wie man die rechteckigen Koordinaten eines Absatzes zusammen mit der Position einer Portion innerhalb eines Absatzes ermittelt.

## **Rechteckige Koordinaten eines Absatzes erhalten**
Die neue Methode **GetRect()** wurde hinzugefügt. Sie ermöglicht das Abrufen des Begrenzungsrechtecks eines Absatzes.
```c#
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```


## **Größe eines Absatzes und einer Portion innerhalb eines Tabellenzellen-TextFrames ermitteln**
Um die Größe und Koordinaten einer [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion) oder eines [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) in einem Tabellenzellen-TextFrame zu erhalten, können Sie die Methoden [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/methods/getrect) und [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/methods/getrect) verwenden.

Dieser Beispielcode demonstriert den beschriebenen Vorgang:
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

**In welchen Einheiten werden die Koordinaten eines Absatzes und von Textportionen zurückgegeben?**

In Punkten, wobei 1 Zoll = 72 Punkte entspricht. Dies gilt für alle Koordinaten und Abmessungen auf der Folie.

**Beeinflusst Wortumbruch die Begrenzungen eines Absatzes?**

Ja. Wenn das [wrapping](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/) im [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) aktiviert ist, bricht der Text um, um die Bereichsbreite anzupassen, wodurch sich die tatsächlichen Begrenzungen des Absatzes ändern.

**Können Absatzkoordinaten zuverlässig in Pixel im exportierten Bild umgerechnet werden?**

Ja. Punkte können mit folgender Formel in Pixel umgerechnet werden: pixels = points × (DPI / 72). Das Ergebnis hängt vom für das Rendering/den Export gewählten DPI ab.

**Wie erhalte ich die „effektiven“ Absatzformatierungsparameter unter Berücksichtigung der Stilvererbung?**

Verwenden Sie die [effective paragraph formatting data structure](/slides/de/net/shape-effective-properties/); sie gibt die endgültigen konsolidierten Werte für Einzüge, Abstand, wrapping, RTL und mehr zurück.