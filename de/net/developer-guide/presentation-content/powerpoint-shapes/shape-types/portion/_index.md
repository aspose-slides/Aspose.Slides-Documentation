---
title: Portion
type: docs
weight: 70
url: /net/portion/
keywords: "Portion, PowerPoint-Form, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Erhalten Sie die Portion in einer PowerPoint-Präsentation in C# oder .NET"
---

## **Positionkoordinaten der Portion abrufen**
Die **GetCoordinates()**-Methode wurde zur IPortion- und Portion-Klasse hinzugefügt, die es ermöglicht, die Koordinaten des Anfangs der Portion abzurufen:

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
            Console.Write(Environment.NewLine + "Koordinaten X =" + point.X + " Koordinaten Y =" + point.Y);
        }
    }
}
```