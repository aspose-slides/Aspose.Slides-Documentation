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
description: "Узнайте, как экспортировать диаграммы презентаций с помощью Aspose.Slides для .NET, поддерживая форматы PPT и PPTX, и упростить создание отчетов в любом рабочем процессе."
---

## **Получить изображение диаграммы**
Aspose.Slides для .NET предоставляет возможность извлекать изображение конкретной диаграммы. Ниже приведён пример.  
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

Да. Диаграмма — это фигура, и её содержимое можно сохранить в SVG, используя метод [shape-to-SVG saving method](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/).

**Как задать точный размер экспортируемой диаграммы в пикселях?**

Используйте перегрузки рендеринга изображения, которые позволяют указать размер или масштаб — библиотека поддерживает рендеринг объектов с заданными размерами/масштабом.

**Что делать, если шрифты в подписьях и легенде выглядят неправильно после экспорта?**

[Загрузите необходимые шрифты](/slides/ru/net/custom-font/) через [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) чтобы рендеринг диаграммы сохранял метрики и внешний вид текста.

**Сохраняет ли экспорт тему, стили и эффекты PowerPoint?**

Да. Рендерер Aspose.Slides следует форматированию презентации (темы, стили, заливки, эффекты), поэтому внешний вид диаграммы сохраняется.

**Где можно найти доступные возможности рендеринга/экспорта помимо изображений диаграмм?**

Смотрите раздел экспорта в [API](https://reference.aspose.com/slides/net/aspose.slides.export/)/[документации](/slides/ru/net/convert-powerpoint/) для целевых форматов вывода ([PDF](/slides/ru/net/convert-powerpoint-to-pdf/), [SVG](/slides/ru/net/render-a-slide-as-an-svg-image/), [XPS](/slides/ru/net/convert-powerpoint-to-xps/), [HTML](/slides/ru/net/convert-powerpoint-to-html/), и др.) и связанные параметры рендеринга.