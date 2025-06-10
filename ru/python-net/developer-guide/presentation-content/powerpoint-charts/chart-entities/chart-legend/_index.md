---
title: Настройте легенды графиков в презентациях с помощью Python
linktitle: Легенда графика
type: docs
url: /ru/python-net/chart-legend/
keywords:
  - легенда графика
  - положение легенды
  - размер шрифта
  - PowerPoint
  - OpenDocument
  - презентация
  - Python
  - Aspose.Slides
description: "Настройте легенды графиков с помощью Aspose.Slides for Python via .NET, чтобы оптимизировать презентации PowerPoint и OpenDocument с индивидуальным форматированием легенд."
---

## **Позиционирование легенды**
Чтобы установить свойства легенды, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Получите ссылку на слайд.
- Добавьте график на слайд.
- Установите свойства легенды.
- Запишите презентацию в файл PPTX.

В приведенном ниже примере мы установили позицию и размер для легенды графика.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Создайте экземпляр класса Presentation
with slides.Presentation() as presentation:

    # Получите ссылку на слайд
    slide = presentation.slides[0]

    # Добавить столбчатый график на слайд
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # Установите свойства легенды
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Запишите презентацию на диск
    presentation.save("Legend_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Установить размер шрифта легенды**
Aspose.Slides для Python через .NET позволяет разработчикам устанавливать размер шрифта легенды. Пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса `Presentation`.
- Создайте график по умолчанию.
- Установите размер шрифта.
- Установите минимальное значение на оси.
- Установите максимальное значение на оси.
- Запишите презентацию на диск.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.legend.text_format.portion_format.font_height = 20
	chart.axes.vertical_axis.is_automatic_min_value = False
	chart.axes.vertical_axis.min_value = -5
	chart.axes.vertical_axis.is_automatic_max_value = False
	chart.axes.vertical_axis.max_value = 10

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Установить размер шрифта для отдельных элементов легенды**
Aspose.Slides для Python через .NET позволяет разработчикам устанавливать размер шрифта для отдельных элементов легенды. Пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса `Presentation`.
- Создайте график по умолчанию.
- Получите доступ к элементу легенды.
- Установите размер шрифта.
- Установите минимальное значение на оси.
- Установите максимальное значение на оси.
- Запишите презентацию на диск.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw
 
 
with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	tf = chart.legend.entries[1].text_format

	tf.portion_format.font_bold = 1
	tf.portion_format.font_height = 20
	tf.portion_format.font_italic = 1
	tf.portion_format.fill_format.fill_type = slides.FillType.SOLID 
	tf.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```