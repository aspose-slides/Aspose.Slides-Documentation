---
title: Porción
type: docs
weight: 70
url: /es/net/portion/
keywords: "Porción, forma de PowerPoint, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Obtener porción en presentación de PowerPoint en C# o .NET"
---

## **Obtener Coordenadas de Posición de la Porción**
El método **GetCoordinates()** se ha añadido a la interfaz IPortion y a la clase Portion, lo que permite recuperar las coordenadas del inicio de la porción:

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
            Console.Write(Environment.NewLine + "Coordenadas X =" + point.X + " Coordenadas Y =" + point.Y);
        }
    }
}
```