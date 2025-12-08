---
title: Настройка таблиц данных диаграмм в Python
linktitle: Таблица данных диаграммы
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

## **Установка параметров шрифта для таблицы данных диаграммы**
Aspose.Slides для Python через .NET предоставляет возможность изменять цвет категорий в серии.

1. Создайте объект класса [Презентация](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
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


## **Часто задаваемые вопросы**

**Можно ли отображать небольшие ключи легенды рядом со значениями в таблице данных диаграммы?**

Да. Таблица данных поддерживает [ключи легенды](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datatable/show_legend_key/), и их можно включать или отключать.

**Сохранится ли таблица данных при экспорте презентации в PDF, HTML или изображения?**

Да. Aspose.Slides рендерит диаграмму как часть слайда, поэтому экспортированный [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/ru/python-net/convert-powerpoint-to-html/)/[изображение](/slides/ru/python-net/convert-powerpoint-to-png/) включает диаграмму с её таблицей данных.

**Поддерживаются ли таблицы данных для диаграмм, полученных из файла шаблона?**

Да. Для любой диаграммы, загруженной из существующей презентации или шаблона, вы можете проверить и изменить, отображается ли таблица данных, используя свойства диаграммы. Для проверки используйте ссылку [отображается](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/).

**Как быстро найти диаграммы в файле, у которых включена таблица данных?**

Проверьте свойство каждой диаграммы, указывающее, отображается ли таблица данных, и пройдитесь по слайдам, чтобы определить диаграммы, у которых она включена. Ссылка [отображается](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/).