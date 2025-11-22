---
title: Абзац
type: docs
weight: 60
url: /ru/net/paragraph/
keywords: "Абзац, фрагмент, координаты абзаца, координаты фрагмента, презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Абзац и фрагмент в презентации PowerPoint на C# или .NET"
---

## **Получить координаты абзаца и фрагмента в TextFrame**
С помощью Aspose.Slides for .NET разработчики теперь могут получить прямоугольные координаты Paragraph внутри коллекции абзацев TextFrame. Это также позволяет получить координаты Portion внутри коллекции фрагментов абзаца. В этой теме мы продемонстрируем на примере, как получить прямоугольные координаты абзаца вместе с позицией фрагмента внутри абзаца.

## **Получить прямоугольные координаты абзаца**
В новый метод **GetRect()** был добавлен. Он позволяет получить прямоугольник границ абзаца.
```c#
// Создать объект Presentation, представляющий файл презентации
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```


## **Получить размер абзаца и фрагмента внутри текстового кадра ячейки таблицы**
Чтобы получить размер и координаты [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion) или [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) в текстовом кадре ячейки таблицы, вы можете использовать методы [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/methods/getrect) и [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/methods/getrect).
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

**В каких единицах измеряются возвращаемые координаты абзаца и текстовых фрагментов?**  
В пунктах, где 1 дюйм = 72 пункта. Это применимо ко всем координатам и размерам на слайде.

**Влияет ли перенос слов на границы абзаца?**  
Да. Если [wrapping](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/) включен в [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/), текст разбивается, чтобы помещаться в ширину области, что меняет реальные границы абзаца.

**Можно ли надежно сопоставить координаты абзаца пикселям в экспортированном изображении?**  
Да. Переведите пункты в пиксели с помощью формулы: pixels = points × (DPI / 72). Результат зависит от выбранного DPI для рендеринга/экспорта.

**Как получить «эффективные» параметры форматирования абзаца, учитывая наследование стилей?**  
Используйте [структуру данных эффективного форматирования абзаца](/slides/ru/net/shape-effective-properties/); она возвращает окончательные объединённые значения для отступов, интервалов, переноса, RTL и прочего.