---
title: Portion
type: docs
weight: 70
url: /fr/net/portion/
keywords: "Portion, forme PowerPoint, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Obtenez la portion dans une présentation PowerPoint en C# ou .NET"
---

## **Obtenir les Coordonnées de Position de la Portion**
La méthode **GetCoordinates()** a été ajoutée à IPortion et à la classe Portion, ce qui permet de récupérer les coordonnées du début de la portion :

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
            Console.Write(Environment.NewLine + "Coordonnées X =" + point.X + " Coordonnées Y =" + point.Y);
        }
    }
}
```