---
title: Доля
type: docs
weight: 70
url: /net/portion/
keywords: "Доля, Форма PowerPoint, Презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Получить долю в презентации PowerPoint на C# или .NET"
---

## **Получить Координаты Позиции Доли**
Метод **GetCoordinates()** был добавлен в интерфейс IPortion и класс Portion, который позволяет получать координаты начала доли:

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
            Console.Write(Environment.NewLine + "Координаты X =" + point.X + " Координаты Y =" + point.Y);
        }
    }
}
```