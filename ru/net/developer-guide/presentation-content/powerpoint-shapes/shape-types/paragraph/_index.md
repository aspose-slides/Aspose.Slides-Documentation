---
title: Параграф
type: docs
weight: 60
url: /net/paragraph/
keywords: "Параграф, порция, координаты параграфа, координаты порции, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Параграф и порция в презентации PowerPoint на C# или .NET"
---

## **Получить координаты параграфа и порции в TextFrame**
С помощью Aspose.Slides для .NET разработчики теперь могут получать прямоугольные координаты для параграфа внутри коллекции параграфов TextFrame. Это также позволяет получить координаты порции внутри коллекции порций параграфа. В этой теме мы собираемся продемонстрировать на примере, как получить прямоугольные координаты для параграфа вместе с позицией порции внутри параграфа.

## **Получить прямоугольные координаты параграфа**
Метод **GetRect()** был добавлен. Он позволяет получить прямоугольник границ параграфа.

```c#
// Создание объекта Presentation, который представляет файл презентации
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **Получить размер параграфа и порции внутри текстового фрейма ячейки таблицы** ##

Чтобы получить размер [Порции](https://reference.aspose.com/slides/net/aspose.slides/portion) или [Параграфа](https://reference.aspose.com/slides/net/aspose.slides/paragraph) и координаты в текстовом фрейме ячейки таблицы, вы можете использовать методы [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/methods/getrect) и [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/methods/getrect).

Этот пример кода демонстрирует описанную операцию:

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