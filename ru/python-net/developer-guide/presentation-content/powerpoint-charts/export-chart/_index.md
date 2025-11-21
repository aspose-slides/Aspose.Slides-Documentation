---
title: Экспорт диаграмм презентации с Python
linktitle: Экспорт диаграммы
type: docs
weight: 90
url: /ru/python-net/export-chart/
keywords:
- диаграмма
- диаграмма в изображение
- диаграмма в виде изображения
- извлечь изображение диаграммы
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как экспортировать диаграммы презентаций с помощью Aspose.Slides для Python через .NET, поддерживая форматы PPT, PPTX и ODP, и оптимизировать построение отчетов в любой рабочий процесс."
---

## **Получить изображение диаграммы**
Aspose.Slides for Python через .NET предоставляет возможность извлекать изображение конкретной диаграммы. Ниже приведён пример.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```


## **FAQ**

**Могу ли я экспортировать диаграмму как вектор (SVG), а не как растровое изображение?**

Да. Диаграмма является фигурой, и её содержимое можно сохранить в SVG с помощью [метода сохранения shape-to-SVG](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/write_as_svg/).

**Как задать точный размер экспортируемой диаграммы в пикселях?**

Используйте перегрузки рендеринга изображения, позволяющие указать размер или масштаб — библиотека поддерживает рендеринг объектов с заданными размерами/масштабом.

**Что делать, если шрифты в подписи и легенде выглядят неправильно после экспорта?**

[Загрузите необходимые шрифты](/slides/ru/python-net/custom-font/) через [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) чтобы рендеринг диаграммы сохранял метрики и внешний вид текста.

**Сохраняет ли экспорт темы PowerPoint, стили и эффекты?**

Да. Рендерер Aspose.Slides следует форматированию презентации (темы, стили, заливки, эффекты), поэтому внешний вид диаграммы сохраняется.

**Где можно найти доступные возможности рендеринга/экспорта помимо изображений диаграмм?**

Смотрите раздел экспорта в [API](https://reference.aspose.com/slides/python-net/aspose.slides.export/)/[документации](/slides/ru/python-net/convert-powerpoint/) для целевых форматов вывода ([PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/), [SVG](/slides/ru/python-net/render-a-slide-as-an-svg-image/), [XPS](/slides/ru/python-net/convert-powerpoint-to-xps/), [HTML](/slides/ru/python-net/convert-powerpoint-to-html/), и т.д.) и связанных параметров рендеринга.