---
title: Таблица данных графика
type: docs
url: /ru/python-net/chart-data-table/
keywords: "Свойства шрифтов, таблица данных графика, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Установить свойства шрифтов для таблицы данных графика в презентациях PowerPoint на Python"
---

## **Установка свойств шрифтов для таблицы данных графика**
Aspose.Slides для Python через .NET предоставляет поддержку изменения цвета категорий в цвете серии.

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Добавьте график на слайд.
1. Установите таблицу графика.
1. Установите высоту шрифта.
1. Сохраните измененную презентацию.

Ниже приведен пример кода.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.has_data_table = True

	chart.chart_data_table.text_format.portion_format.font_bold = 1
	chart.chart_data_table.text_format.portion_format.font_height = 20

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```