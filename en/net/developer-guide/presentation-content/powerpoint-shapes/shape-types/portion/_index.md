---
title: Portion
type: docs
weight: 70
url: /net/portion/
keywords: "Portion, PowerPoint shape, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Get portion in PowerPoint presentation in C# or .NET"
---

## **Get Position Coordinates of Portion**
**GetCoordinates()** method has been added to IPortion and Portion class which allows retrieving the coordinates of the beginning of the portion:

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

