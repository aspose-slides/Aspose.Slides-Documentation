---
title: Получить границы абзаца из презентаций в .NET
linktitle: Абзац
type: docs
weight: 60
url: /ru/net/paragraph/
keywords:
- границы абзаца
- границы текстовой части
- координата абзаца
- координата части
- размер абзаца
- размер текстовой части
- текстовый фрейм
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как получить границы абзаца и текстовой части в Aspose.Slides для .NET, чтобы оптимизировать позиционирование текста в презентациях PowerPoint."
---

## **Получить координаты абзаца и части в TextFrame**
С помощью Aspose.Slides для .NET разработчики теперь могут получать прямоугольные координаты абзаца внутри коллекции абзацев TextFrame. Также можно получить координаты части внутри коллекции частей абзаца. В этой теме мы продемонстрируем на примере, как получить прямоугольные координаты абзаца вместе с положением части внутри абзаца.

## **Получить прямоугольные координаты абзаца**
Добавлен новый метод **GetRect()**. Он позволяет получить прямоугольник границ абзаца.
```c#
// Создайте объект Presentation, представляющий файл презентации
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```


## **Получить размер абзаца и части внутри текстового фрейма ячейки таблицы**

Чтобы получить размер и координаты [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion) или [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) в текстовом фрейме ячейки таблицы, можно использовать методы [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/methods/getrect) и [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/methods/getrect).

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


## **FAQ**

**В каких единицах измеряются координаты, возвращаемые для абзаца и текстовых частей?**

В пунктах, где 1 дюйм = 72 пункта. Это относится ко всем координатам и размерам на слайде.

**Влияет ли перенос слов на границы абзаца?**

Да. Если перенос включён в [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/), текст переносится, чтобы соответствовать ширине области, что изменяет фактические границы абзаца.

**Можно ли надёжно сопоставить координаты абзаца с пикселями в экспортированном изображении?**

Да. Преобразуйте пункты в пиксели с помощью: pixels = points × (DPI / 72). Результат зависит от выбранного DPI при рендеринге/экспорте.

**Как получить «эффективные» параметры форматирования абзаца, учитывая наследование стилей?**

Используйте структуру данных эффективного форматирования абзаца; она возвращает окончательные объединённые значения отступов, интервалов, переноса, RTL и т.д.