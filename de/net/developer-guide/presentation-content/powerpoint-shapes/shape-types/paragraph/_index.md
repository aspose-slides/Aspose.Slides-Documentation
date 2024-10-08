---
title: Absatz
type: docs
weight: 60
url: /de/net/paragraph/
keywords: "Absatz, Portion, Absatzkoordinate, Portionkoordinate, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Absatz und Portion in PowerPoint-Präsentation in C# oder .NET"
---

## **Absatz- und Portionskoordinaten im TextFrame erhalten**
Mit Aspose.Slides für .NET können Entwickler jetzt die rechteckigen Koordinaten für Absätze innerhalb der Absatzsammlung des TextFrame abrufen. Es ermöglicht auch, die Koordinaten der Portion innerhalb der Portionssammlung eines Absatzes zu erhalten. In diesem Thema werden wir anhand eines Beispiels demonstrieren, wie man die rechteckigen Koordinaten für den Absatz sowie die Position der Portion innerhalb eines Absatzes erhält.

## **Rechteckige Koordinaten des Absatzes erhalten**
Die neue Methode **GetRect()** wurde hinzugefügt. Sie ermöglicht es, das rechteckige Bereichsrechteck des Absatzes zu erhalten.

```c#
// Erstellen Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **Größe des Absatzes und der Portion im TextFrame der Tabellenzelle erhalten** ##

Um die [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion) oder die [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) Größe und Koordinaten im TextFrame einer Tabellenzelle zu erhalten, können Sie die Methoden [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/methods/getrect) und [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/methods/getrect) verwenden.

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