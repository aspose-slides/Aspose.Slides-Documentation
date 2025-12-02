---
title: Настройка таблиц данных диаграмм на Python
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
description: "Настройте таблицы данных диаграмм на Python для PPT, PPTX и ODP с помощью Aspose.Slides, чтобы повысить эффективность и привлекательность презентаций."
---

## **Установить свойства шрифта для таблицы данных диаграммы**
Aspose.Slides for Python via .NET предоставляет поддержку изменения цвета категорий в серии.  

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
1. Добавьте диаграмму на слайд.  
1. Установите таблицу диаграммы.  
1. Установите высоту шрифта.  
1. Сохраните изменённую презентацию.  

Ниже приведён пример.  
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

**Можно ли отображать небольшие ключи легенды рядом со значениями в таблице данных диаграммы?**

Да. Таблица данных поддерживает [legend keys](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datatable/show_legend_key/), и вы можете включать или отключать их.

**Будет ли таблица данных сохраняться при экспорте презентации в PDF, HTML или изображения?**

Да. Aspose.Slides отображает диаграмму как часть слайда, поэтому экспортированный [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/ru/python-net/convert-powerpoint-to-html/)/[image](/slides/ru/python-net/convert-powerpoint-to-png/) включает диаграмму с её таблицей данных.

**Поддерживаются ли таблицы данных для диаграмм, полученных из шаблонного файла?**

Да. Для любой диаграммы, загруженной из существующей презентации или шаблона, вы можете проверять и изменять, отображается ли таблица данных, используя свойства диаграммы [is shown](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/).

**Как быстро определить, какие диаграммы в файле имеют включённую таблицу данных?**

Проверьте свойство каждой диаграммы, указывающее, отображается ли таблица данных [is shown](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/), и пройдитесь по слайдам, чтобы определить диаграммы, в которых она включена.