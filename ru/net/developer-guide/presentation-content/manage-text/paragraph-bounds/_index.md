---
title: Получить границы абзаца из презентаций в .NET
linktitle: Границы абзаца
type: docs
weight: 43
url: /ru/net/paragraph-bounds/
keywords:
- границы абзаца
- координаты абзаца
- размер абзаца
- текстовый кадр
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как получить границы абзаца в Aspose.Slides для .NET, чтобы оптимизировать размещение текста в презентациях PowerPoint."
---
## **Обзор**

Эта статья объясняет, как получить границы, размер и координаты абзацев в Aspose.Slides. Она показывает, как извлечь прямоугольник абзаца из [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/) с помощью [IParagraph.GetRect](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/getrect/), как получить координаты абзаца внутри текстового кадра ячейки таблицы и подчёркивает важные детали, такие как единицы измерения, влияние переноса текста на границы, преобразование в пиксели и «эффективные» параметры форматирования абзаца.

## **Получить прямоугольные координаты абзаца**

Используйте [IParagraph.GetRect](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/getrect/) чтобы получить ограничивающий прямоугольник абзаца.

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **Получить размер абзаца внутри текстового кадра ячейки таблицы**

Чтобы получить размер и координаты [IParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/) в текстовом кадре ячейки таблицы, используйте [IParagraph.GetRect](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/getrect/). Возвращаемый прямоугольник относителен к текстовому кадру ячейки таблицы, поэтому добавляйте позицию таблицы и смещение ячейки, когда нужны координаты уровня слайда.

Следующий пример получает границы абзаца внутри ячейки таблицы и рисует прямоугольники на слайде для визуализации этих границ:

```csharp
using var presentation = new Presentation("source.pptx");
var slide = presentation.Slides[0];
var table = (ITable)slide.Shapes[0];
var cell = table.Rows[1][1];

var cellX = table.X + cell.OffsetX;
var cellY = table.Y + cell.OffsetY;

foreach (var paragraph in cell.TextFrame.Paragraphs)
{
    if (string.IsNullOrEmpty(paragraph.Text))
        continue;

    var paragraphRectangle = paragraph.GetRect();
    var paragraphRectangleX = paragraphRectangle.X + (float)cellX;
    var paragraphRectangleY = paragraphRectangle.Y + (float)cellY;

    var paragraphBoundsShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.Width,
        paragraphRectangle.Height);

    paragraphBoundsShape.FillFormat.FillType = FillType.NoFill;
    paragraphBoundsShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
    paragraphBoundsShape.LineFormat.FillFormat.FillType = FillType.Solid;
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **FAQ**

**В каких единицах измеряются координаты абзаца?**

Они измеряются в пунктах, где 1 дюйм равен 72 пунктам. Это относится ко всем координатам и размерам на слайде.

**Влияет ли перенос слов на границы абзаца?**

Да. Если для [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/) включён [TextFrameFormat.WrapText](https://reference.aspose.com/slides/ru/net/aspose.slides/textframeformat/wraptext/), текст разбивается, чтобы вписаться в ширину области, что изменяет фактические границы абзаца.

**Можно ли надёжно отобразить координаты абзаца в пикселях экспортированного изображения?**

Да. Преобразуйте пункты в пиксели по формуле: пиксели = пункты × (DPI / 72). Результат зависит от выбранного DPI при рендеринге или экспорте.

**Как получить «эффективные» параметры форматирования абзаца, учитывая наследование стилей?**

Используйте [структура данных эффективного форматирования абзаца](/slides/ru/net/shape-effective-properties/); она возвращает окончательные консолидированные значения отступов, интервалов, переноса, RTL и др.