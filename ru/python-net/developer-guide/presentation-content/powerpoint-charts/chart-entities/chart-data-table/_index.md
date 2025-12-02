---
title: Настройка таблиц данных диаграмм в Python
linktitle: Таблица данных
type: docs
url: /ru/python-net/chart-data-table/
keywords:
- данные диаграммы
- таблица данных
- свойства шрифта
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Настройте таблицы данных диаграмм в Python для PPT, PPTX и ODP с помощью Aspose.Slides, чтобы повысить эффективность и привлекательность презентаций."
---

## **Set Font Properties for Chart Data Table**
Aspose.Slides for Python via .NET предоставляет возможность изменения цвета категорий в серии.

1. Создать объект класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Добавить диаграмму на слайд.
1. Установить таблицу диаграммы.
1. Установить высоту шрифта.
1. Сохранить измененную презентацию.

Ниже приведен пример.
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


## **FAQ**

**Can I show small legend keys next to the values in the chart’s data table?**

Да. Таблица данных поддерживает [legend keys](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datatable/show_legend_key/), и их можно включать и отключать.

**Will the data table be preserved when exporting the presentation to PDF, HTML, or images?**

Да. Aspose.Slides отображает диаграмму как часть слайда, поэтому экспортированный [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/ru/python-net/convert-powerpoint-to-html/)/[image](/slides/ru/python-net/convert-powerpoint-to-png/) включает диаграмму с её таблицей данных.

**Are data tables supported for charts that come from a template file?**

Да. Для любой диаграммы, загруженной из существующей презентации или шаблона, вы можете проверить и изменить, отображается ли таблица данных [is shown](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/) с помощью свойств диаграммы.

**How can I quickly find which charts in a file have the data table enabled?**

Проверьте свойство каждой диаграммы, указывающее, отображается ли таблица данных [is shown](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/), и пройдитесь по слайдам, чтобы определить диаграммы, у которых она включена.