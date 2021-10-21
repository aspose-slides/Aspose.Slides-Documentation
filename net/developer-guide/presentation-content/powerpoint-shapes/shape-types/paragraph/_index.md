---
title: Paragraph
type: docs
weight: 60
url: /net/paragraph/
keywords: "Paragraph, portion, paragraph coordinate, portion coordinate, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Paragraph and portion in PowerPoint presentation in C# or .NET"
---

## **Get Paragraph and Portion Coordinates in TextFrame**
Using Aspose.Slides for .NET, developers can now get the rectangular coordinates for Paragraph inside paragraphs collection of TextFrame. It also allows you to get the coordinates of portion inside portion collection of a paragraph. In this topic, we are going to demonstrate with the help of an example that how to get the rectangular coordinates for paragraph along with position of portion inside a paragraph.

## **Get Rectangular Coordinates of Paragraph**
The new method **GetRect()** has been added. It allows to get paragraph bounds rectangle.

```c#
// Instantiate a Presentation object that represents a presentation file
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **Get size of paragraph and portion inside table cell text frame** ##

To get the [Portion](https://apireference.aspose.com/slides/net/aspose.slides/portion) or [Paragraph](https://apireference.aspose.com/slides/net/aspose.slides/paragraph) size and coordinates in a table cell text frame, you can use the [IPortion.GetRect](https://apireference.aspose.com/slides/net/aspose.slides/iportion/methods/getrect) and [IParagraph.GetRect](https://apireference.aspose.com/slides/net/aspose.slides/iparagraph/methods/getrect) methods.

This sample code demonstrates the described operation:

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