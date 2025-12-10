---
title: Экспорт диаграмм презентаций в .NET
linktitle: Экспорт диаграммы
type: docs
weight: 90
url: /ru/net/export-chart/
keywords:
- диаграмма
- диаграмма в изображение
- диаграмма как изображение
- извлечение изображения диаграммы
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как экспортировать диаграммы презентаций с помощью Aspose.Slides для .NET, поддерживая форматы PPT и PPTX, и оптимизировать отчетность в любой рабочий процесс."
---

## **Получить изображение диаграммы**
Aspose.Slides for .NET предоставляет возможность извлекать изображение конкретной диаграммы. Ниже приведён пример.

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```


## **Часто задаваемые вопросы**

**Могу ли я экспортировать диаграмму как вектор (SVG), а не как растровое изображение?**

Да. Диаграмма является фигурой, и её содержимое можно сохранить в SVG с помощью [метода сохранения shape-to-SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/).

**Как установить точный размер экспортируемой диаграммы в пикселях?**

Используйте перегрузки рендеринга изображений, позволяющие задать размер или масштаб — библиотека поддерживает рендеринг объектов с заданными параметрами размеров/масштаба.

**Что делать, если шрифты в подписьх и легенде выглядят некорректно после экспорта?**

[Загрузите необходимые шрифты](/slides/ru/net/custom-font/) через [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/), чтобы рендеринг диаграммы сохранял метрики и внешний вид текста.

**Учитывает ли экспорт тему, стили и эффекты PowerPoint?**

Да. Рендерер Aspose.Slides следует форматированию презентации (темы, стили, заливки, эффекты), поэтому внешний вид диаграммы сохраняется.

**Где можно найти доступные возможности рендеринга/экспорта помимо изображений диаграмм?**

Смотрите раздел экспорта в [API](https://reference.aspose.com/slides/net/aspose.slides.export/)/[документации](/slides/ru/net/convert-powerpoint/) для целевых форматов вывода ([PDF](/slides/ru/net/convert-powerpoint-to-pdf/), [SVG](/slides/ru/net/render-a-slide-as-an-svg-image/), [XPS](/slides/ru/net/convert-powerpoint-to-xps/), [HTML](/slides/ru/net/convert-powerpoint-to-html/), и т.д.) и соответствующих параметров рендеринга.