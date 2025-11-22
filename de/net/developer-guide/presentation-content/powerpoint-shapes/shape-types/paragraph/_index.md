---
title: Absatz
type: docs
weight: 60
url: /de/net/paragraph/
keywords: "Absatz, Portion, Absatzkoordinate, Portionskoordinate, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Absatz und Portion in einer PowerPoint-Präsentation in C# oder .NET"
---

## **Paragraph‑ und Portionkoordinaten im TextFrame abrufen**
Mit Aspose.Slides für .NET können Entwickler nun die rechteckigen Koordinaten eines Paragraphen innerhalb der Paragraphensammlung eines TextFrames abrufen. Außerdem können die Koordinaten einer Portion innerhalb der Portionensammlung eines Paragraphen ermittelt werden. In diesem Thema zeigen wir anhand eines Beispiels, wie man die rechteckigen Koordinaten eines Paragraphen zusammen mit der Position einer Portion innerhalb eines Paragraphen erhält.

## **Rechteckige Koordinaten eines Paragraphen abrufen**
Die neue Methode **GetRect()** wurde hinzugefügt. Sie ermöglicht das Abrufen des Begrenzungsrechtecks eines Paragraphen.
```c#
// Erstelle ein Presentation-Objekt, das eine Präsentationsdatei darstellt
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```


## **Größe von Paragraph und Portion innerhalb des TextFrames einer Tabellenzelle abrufen**

Um die Größe und die Koordinaten einer [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion) oder eines [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) in einem TextFrame einer Tabellenzelle zu erhalten, können Sie die Methoden [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/methods/getrect) und [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/methods/getrect) verwenden.

Dieser Beispielcode demonstriert die beschriebene Operation:
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

**In welchen Einheiten werden die Koordinaten für einen Paragraphen und Textportionen zurückgegeben?**

In Punkten, wobei 1 Zoll = 72 Punkte entspricht. Dies gilt für alle Koordinaten und Abmessungen auf der Folie.

**Beeinflusst Wortumbruch die Begrenzungen eines Paragraphen?**

Ja. Wenn das [wrapping](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/) im [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) aktiviert ist, bricht der Text um, um die Breite des Bereichs zu füllen, wodurch sich die tatsächlichen Begrenzungen des Paragraphen ändern.

**Können Paragraphkoordinaten zuverlässig in Pixel des exportierten Bildes umgerechnet werden?**

Ja. Punkte können mit folgender Formel in Pixel umgerechnet werden: pixel = punkt × (DPI / 72). Das Ergebnis hängt vom für die Darstellung/den Export gewählten DPI ab.

**Wie erhalte ich die „effektiven“ Absatzformatierungsparameter unter Berücksichtigung der Stilvererbung?**

Verwenden Sie die [effective paragraph formatting data structure](/slides/de/net/shape-effective-properties/); sie gibt die endgültigen konsolidierten Werte für Einzüge, Abstand, Umbruch, RTL und mehr zurück.