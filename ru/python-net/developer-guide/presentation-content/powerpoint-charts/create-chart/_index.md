---
title: Создание или обновление диаграмм презентаций PowerPoint на Python
linktitle: Создание или обновление диаграммы
type: docs
weight: 10
url: /ru/python-net/create-chart/
keywords:
- добавить диаграмму
- создать диаграмму
- редактировать диаграмму
- изменить диаграмму
- обновить диаграмму
- точечная диаграмма
- круговая диаграмма
- линейная диаграмма
- диаграмма Tree Map
- фондовая диаграмма
- коробочная диаграмма с усами
- воронковая диаграмма
- диаграмма Sunburst
- гистограмма
- радиальная диаграмма
- мультикатегориальная диаграмма
- презентация PowerPoint
- Python
- Aspose.Slides
description: "Узнайте, как создавать и настраивать диаграммы в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET. Описание охватывает добавление, форматирование и редактирование диаграмм в презентациях с практическими примерами кода на Python."
---

## **Обзор**

Эта статья предоставляет исчерпывающее руководство по созданию и настройке диаграмм с помощью Aspose.Slides for Python via .NET. Вы узнаете, как программно добавить диаграмму на слайд, заполнить её данными и применить различные параметры форматирования для соответствия вашим требованиям к дизайну. На протяжении статьи детальные примеры кода иллюстрируют каждый шаг, от инициализации презентации и объекта диаграммы до настройки рядов, осей и легенд. Следуя этому руководству, вы получите твердое понимание интеграции динамического создания диаграмм в ваши приложения, упростив процесс создания презентаций, основанных на данных.

## **Создание диаграммы**

Диаграммы помогают людям быстро визуализировать данные и получать инсайты, которые могут быть неочевидны из таблицы или таблицы Excel.

**Зачем создавать диаграммы?**

С помощью диаграмм вы можете:

* агрегировать, конденсировать или суммировать большие объёмы данных на одном слайде презентации;
* выявлять закономерности и тренды в данных;
* определять направление и динамику данных во времени или относительно конкретной единицы измерения;
* обнаруживать выбросы, аномалии, отклонения, ошибки и бессмысленные данные;
* представлять или демонстрировать сложные данные.

В PowerPoint вы можете создавать диаграммы через функцию *Insert*, которая предоставляет шаблоны для разработки множества типов диаграмм. С помощью Aspose.Slides вы можете создавать как обычные диаграммы (на основе популярных типов), так и пользовательские диаграммы.

{{% alert color="primary" %}} 
Используйте перечисление [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) из пространства имён [Aspose.Slides.Charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/). Значения этого перечисления соответствуют разным типам диаграмм.
{{% /alert %}} 

### **Создание группированных столбчатых диаграмм**

В этом разделе объясняется, как создавать группированные столбчатые диаграммы с помощью Aspose.Slides for Python via .NET. Вы научитесь инициализировать презентацию, добавить диаграмму и настроить её элементы, такие как заголовок, данные, ряды, категории и стиль. Следуйте шагам ниже, чтобы увидеть, как генерируется стандартная группированная столбчатая диаграмма:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с некоторыми данными и укажите тип `ChartType.CLUSTERED_COLUMN`.
1. Добавьте заголовок к диаграмме.
1. Получите доступ к листу данных диаграммы.
1. Очистите все строки и категории по умолчанию.
1. Добавьте новые ряды и категории.
1. Добавьте новые данные диаграммы для рядов.
1. Примените цвет заливки к рядам диаграммы.
1. Добавьте подписи к рядам диаграммы.
1. Сохраните изменённую презентацию в файл PPTX.

Этот Python‑код демонстрирует, как создать группированную столбчатую диаграмму:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation, представляющего файл PPTX.
with slides.Presentation() as presentation:

    # Получить первый слайд.
    slide = presentation.slides[0]

    # Добавить группированную столбчатую диаграмму с данными по умолчанию.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Установить заголовок диаграммы.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Установить отображение значений для первого ряда.
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # Установить индекс листа данных диаграммы.
    worksheet_index = 0

    # Получить рабочую книгу данных диаграммы.
    workbook = chart.chart_data.chart_data_workbook

    # Удалить автоматически созданные ряды и категории.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Добавить новые ряды.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    # Добавить новые категории.
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

    # Получить первый ряд диаграммы.
    series = chart.chart_data.series[0]

    # Заполнить данные ряда.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # Установить цвет заливки для ряда.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Получить второй ряд диаграммы.
    series = chart.chart_data.series[1]

    # Заполнить данные ряда.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    # Установить цвет заливки для ряда.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # Установить отображение названия категории в первой подписи.
    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    # Установить отображение значения в третьей подписи ряда.
    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"
                
    # Сохранить презентацию на диск в формате PPTX.
    presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The Clustered Column chart](clustered_column_chart.png)

### **Создание точечных (Scatter) диаграмм**

Точечные диаграммы (также известные как scatter plot или графики x‑y) часто используются для поиска закономерностей или демонстрации корреляций между двумя переменными.

Используйте точечную диаграмму, когда:

* У вас есть парные числовые данные.
* У вас есть две переменные, которые хорошо сочетаются друг с другом.
* Вы хотите определить, связаны ли две переменные.
* Есть независимая переменная, имеющая несколько значений для зависимой переменной.

Этот Python‑код показывает, как создать точечную диаграмму с разными маркерами рядов:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]

    # Создайте диаграмму рассеяния по умолчанию.
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    # Установите индекс листа данных диаграммы.
    worksheet_index = 0

    # Получите рабочую книгу данных диаграммы.
    workbook = chart.chart_data.chart_data_workbook

    # Удалите ряд по умолчанию.
    chart.chart_data.series.clear()

    # Добавьте новые ряды.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 3, "Series 2"), chart.type)

    # Получите первый ряд диаграммы.
    series = chart.chart_data.series[0]

    # Добавьте новую точку (1:3) в ряд.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 1, 1), workbook.get_cell(worksheet_index, 2, 2, 3))

    # Добавьте новую точку (2:10).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 1, 2), workbook.get_cell(worksheet_index, 3, 2, 10))

    # Измените тип ряда.
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # Измените маркер ряда диаграммы.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # Получите второй ряд диаграммы.
    series = chart.chart_data.series[1]

    # Добавьте новую точку (5:2) в ряд диаграммы.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 5), workbook.get_cell(worksheet_index, 2, 4, 2))

    # Добавьте новую точку (3:1).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 3, 3), workbook.get_cell(worksheet_index, 3, 4, 1))

    # Добавьте новую точку (2:2).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 4, 3, 2), workbook.get_cell(worksheet_index, 4, 4, 2))

    # Добавьте новую точку (5:1).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 5, 3, 5), workbook.get_cell(worksheet_index, 5, 4, 1))

    # Измените маркер ряда диаграммы.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("ScatterChart.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The Scatter chart](scatter_chart.png)

### **Создание круговых диаграмм**

Круговые диаграммы лучше всего использовать для отображения соотношения части к целому в данных, особенно когда данные содержат категориальные метки с числовыми значениями. Однако, если в ваших данных много частей или меток, возможно, стоит рассмотреть использование столбчатой диаграммы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с данными по умолчанию и укажите тип `ChartType.PIE`.
1. Получите доступ к рабочей книге данных диаграммы ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Очистите ряды и категории по умолчанию.
1. Добавьте новые ряды и категории.
1. Добавьте новые данные диаграммы для рядов.
1. Добавьте новые точки для диаграммы и задайте пользовательские цвета секторам круговой диаграммы.
1. Установите подписи для рядов.
1. Включите линии‑выноски для подписи рядов.
1. Установите угол вращения для круговой диаграммы.
1. Сохраните изменённую презентацию в файл PPTX.

Этот Python‑код показывает, как создать круговую диаграмму:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation, представляющего файл PPTX.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте диаграмму с данными по умолчанию.
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    # Установите заголовок диаграммы.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Настройте первый ряд для отображения значений.
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # Установите индекс листа данных диаграммы.
    worksheet_index = 0

    # Получите рабочую книгу данных диаграммы.
    workbook = chart.chart_data.chart_data_workbook

    # Удалите автоматически сгенерированные ряды и категории.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Добавьте новые категории.
    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "First Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "2nd Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "3rd Qtr"))

    # Добавьте новые ряды.
    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Заполните данные ряда.
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # Установите цвет сектора.
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan

    # Установите границу сектора.
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # Установите границу сектора.
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # Установите границу сектора.
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # Создайте пользовательские подписи для каждой категории в новом ряду.
    label1 = series.data_points[0].label

    label1.data_label_format.show_value = True

    label2 = series.data_points[1].label
    label2.data_label_format.show_value = True
    label2.data_label_format.show_legend_key = True
    label2.data_label_format.show_percentage = True

    label3 = series.data_points[2].label
    label3.data_label_format.show_series_name = True
    label3.data_label_format.show_percentage = True

    # Настройте ряд на отображение выноски (линий‑выноски) для диаграммы.
    series.labels.default_data_label_format.show_leader_lines = True

    # Установите угол поворота секторов круговой диаграммы.
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # Сохраните презентацию на диск в формате PPTX.
    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The Pie chart](pie_chart.png)

### **Создание линейных диаграмм**

Линейные диаграммы (также известные как линейные графики) лучше всего использовать, когда необходимо продемонстрировать изменения значений во времени. С помощью линейной диаграммы можно одновременно сравнивать большой объём данных, отслеживать изменения и тренды, выделять аномалии в рядах данных и многое другое.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с данными по умолчанию и укажите тип `ChartType.LINE`.
1. Получите доступ к рабочей книге данных диаграммы ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Очистите ряды и категории по умолчанию.
1. Добавьте новые ряды и категории.
1. Добавьте новые данные диаграммы для рядов.
1. Сохраните изменённую презентацию в файл PPTX.

Этот Python‑код показывает, как создать линейную диаграмму:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```


По умолчанию точки на линейной диаграмме соединяются прямыми сплошными линиями. Если вы хотите соединять точки пунктиром, задайте нужный тип пунктирной линии следующим образом:
```python
line_chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

for series in line_chart.chart_data.series:
    series.format.line.dash_style = slides.charts.LineDashStyle.DASH
```


Результат:

![The Line chart](line_chart.png)

### **Создание диаграмм Tree Map**

Диаграммы Tree Map лучше всего использовать для данных о продажах, когда нужно показать относительные размеры категорий данных и быстро привлечь внимание к элементам, которые являются крупными вкладами в каждой категории.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с данными по умолчанию и укажите тип `ChartType.TREEMAP`.
1. Получите доступ к рабочей книге данных диаграммы ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Очистите ряды и категории по умолчанию.
1. Добавьте новые ряды и категории.
1. Добавьте новые данные диаграммы для рядов.
1. Сохраните изменённую презентацию в файл PPTX.

Этот Python‑код показывает, как создать диаграмму Tree Map:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.TREEMAP, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Ветка 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # Ветка 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D8", 3))

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    presentation.save("TreeMap.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The Treemap chart](treemap_chart.png)

### **Создание фондовых (Stock) диаграмм**

Фондовые диаграммы используются для отображения финансовых данных, таких как цены открытия, максимума, минимума и закрытия, помогая анализировать рыночные тренды и волатильность. Они предоставляют ключевые инсайты о динамике акций, способствуя принятию обоснованных решений инвесторами и аналитиками.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с данными по умолчанию и укажите тип `ChartType.OPEN_HIGH_LOW_CLOSE`.
1. Получите доступ к рабочей книге данных диаграммы ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Очистите ряды и категории по умолчанию.
1. Добавьте новые ряды и категории.
1. Добавьте новые данные диаграммы для рядов.
1. Укажите формат HiLowLines.
1. Сохраните изменённую презентацию в файл PPTX.

Этот Python‑код показывает, как создать фондовую диаграмму:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 300, False)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "A"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "B"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C"))

    chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Open"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "High"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 3, "Low"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 4, "Close"), chart.type)

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 1, 72))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 1, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 1, 38))

    series = chart.chart_data.series[1]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 2, 172))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 2, 57))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 2, 57))

    series = chart.chart_data.series[2]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 3, 13))

    series = chart.chart_data.series[3]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 4, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 4, 38))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 4, 50))

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for ser in chart.chart_data.series:
        ser.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("StockChart.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The Stock chart](stock_chart.png)

### **Создание диаграмм Box and Whisker**

Диаграммы Box and Whisker используются для отображения распределения данных, суммируя ключевые статистические показатели, такие как медиана, квартиль и потенциальные выбросы. Они особенно полезны в исследовательском анализе данных и статистических исследованиях для быстрого понимания изменчивости данных и выявления аномалий.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с данными по умолчанию и укажите тип `ChartType.BOX_AND_WHISKER`.
1. Получите доступ к рабочей книге данных диаграммы ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Очистите ряды и категории по умолчанию.
1. Добавьте новые ряды и категории.
1. Добавьте новые данные диаграммы для рядов.
1. Сохраните изменённую презентацию в файл PPTX.

Этот Python‑код показывает, как создать диаграмму Box and Whisker:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 1"))

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B1", 15))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B2", 41))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B3", 16))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B4", 10))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B5", 23))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B6", 16))

    presentation.save("BoxAndWhiskerChart.pptx", slides.export.SaveFormat.PPTX)
```


### **Создание воронкообразных (Funnel) диаграмм**

Воронкообразные диаграммы используются для визуализации процессов, состоящих из последовательных этапов, где объём данных уменьшается по мере продвижения от одного шага к следующему. Они особенно полезны для анализа коэффициентов конверсии, выявления узких мест и отслеживания эффективности процессов продаж или маркетинга.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с данными по умолчанию и укажите тип `ChartType.FUNNEL`.
1. Сохраните изменённую презентацию в файл PPTX.

Этот Python‑код показывает, как создать воронкообразную диаграмму:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 4"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 5"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 6"))

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B1", 50))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B2", 100))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B3", 200))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B4", 300))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B5", 400))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B6", 500))

    presentation.save("FunnelChart.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The Funnel chart](funnel_chart.png)

### **Создание Sunburst диаграмм**

Sunburst диаграммы используются для визуализации иерархических данных, отображая уровни в виде концентрических колец. Они помогают иллюстрировать отношения «часть‑целое» и идеальны для представления вложенных категорий и подкатегорий в компактном виде.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с данными по умолчанию и укажите тип `ChartType.SUNBURST`.
1. Сохраните изменённую презентацию в файл PPTX.

Этот Python‑код показывает, как создать Sunburst диаграмму:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Ветка 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # Ветка 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D8", 3))

    presentation.save("SunburstChart.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The Sunburst chart](sunburst_chart.png)

### **Создание гистограмм (Histogram) диаграмм**

Гистограммы используются для представления распределения количественных данных, группируя значения в диапазоны (баги). Они особенно полезны для выявления шаблонов в данных, таких как частота, асимметрия и размах, а также для обнаружения выбросов в наборе данных.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с некоторыми данными и укажите тип `ChartType.HISTOGRAM`.
1. Получите доступ к рабочей книге данных диаграммы ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Очистите ряды и категории по умолчанию.
1. Добавьте новые ряды и категории.
1. Сохраните изменённую презентацию в файл PPTX.

Этот Python‑код показывает, как создать гистограмму:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A1", 15))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A2", -41))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A3", 16))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A4", 10))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A5", -23))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A6", 16))

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    presentation.save("HistogramChart.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The Histogram chart](histogram_chart.png)

### **Создание радиальных (Radar) диаграмм**

Радиальные диаграммы используются для отображения многомерных данных в двумерном виде, позволяя легко сравнивать несколько переменных одновременно. Они особенно полезны для выявления паттернов, сильных и слабых сторон по нескольким метрикам или атрибутам.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с некоторыми данными и укажите тип `ChartType.RADAR`.
1. Сохраните изменённую презентацию в файл PPTX.

Этот Python‑код показывает, как создать радиальную диаграмму:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarСhart.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The Radar chart](radar_chart.png)

### **Создание мультикатегориальных диаграмм**

Мультикатегориальные диаграммы используются для отображения данных, включающих более одной категориальной группировки, позволяя сравнивать значения по нескольким измерениям одновременно. Они особенно полезны при анализе трендов и взаимосвязей в сложных, многослойных наборах данных.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с данными по умолчанию и укажите тип `ChartType.CLUSTERED_COLUMN`.
1. Получите доступ к рабочей книге данных диаграммы ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Очистите ряды и категории по умолчанию.
1. Добавьте новые ряды и категории.
1. Добавьте новые данные диаграммы для рядов.
1. Сохраните изменённую презентацию в файл PPTX.

Этот Python‑код показывает, как создать мультикатегориальную диаграмму:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    worksheet_index = 0

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c2", "A"))
    category.grouping_levels.set_grouping_item(1, "Group1")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c3", "B"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c4", "C"))
    category.grouping_levels.set_grouping_item(1, "Group2")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c5", "D"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c6", "E"))
    category.grouping_levels.set_grouping_item(1, "Group3")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c7", "F"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c8", "G"))
    category.grouping_levels.set_grouping_item(1, "Group4")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c9", "H"))

    # Добавить серию.
    series = chart.chart_data.series.add(workbook.get_cell(0, "D1", "Series 1"), charts.ChartType.CLUSTERED_COLUMN)

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D2", 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D3", 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D4", 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D5", 40))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D6", 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D7", 60))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D8", 70))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D9", 80))

    # Сохранить презентацию с диаграммой.
    presentation.save("MultiCategoryChart.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The multi category chart](multi_category_chart.png)

### **Создание картографических (Map) диаграмм**

Картографические диаграммы используются для визуализации географических данных, сопоставляя информацию с конкретными местоположениями, такими как страны, штаты или города. Они особенно полезны для анализа региональных трендов, демографических данных и пространственного распределения в наглядной форме.

Этот Python‑код показывает, как создать картографическую диаграмму:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The Map chart](map_chart.png)

### **Создание комбинированных диаграмм**

Комбинированная диаграмма (или combo chart) объединяет два или более типа диаграмм в один график. Этот тип диаграммы позволяет выделять, сравнивать или просматривать различия между несколькими наборами данных, выявляя взаимосвязи между ними.

![The combination chart](combination_chart.png)

Этот Python‑код показывает, как создать комбинированную диаграмму в презентации PowerPoint:
```python
import aspose.slides as slides
import aspose.slides.charts as charts


def create_combo_chart():
    presentation = slides.Presentation()

    chart = create_chart(presentation.slides[0])
    add_first_series_to_chart(chart)
    add_second_series_to_chart(chart)

    presentation.save("ComboChart.pptx", slides.export.SaveFormat.PPTX)


def create_chart(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    series = chart.chart_data.series[1]

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    return chart


def add_first_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), charts.ChartType.SCATTER_WITH_SMOOTH_LINES)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 0, 1, 3), workbook.get_cell(worksheet_index, 0, 2, 5))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 10), workbook.get_cell(worksheet_index, 1, 4, 13))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 20), workbook.get_cell(worksheet_index, 2, 4, 15))

    series.plot_on_second_axis = True


def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 5, "Series 4"), charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 5), workbook.get_cell(worksheet_index, 1, 4, 2))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 5, 10), workbook.get_cell(worksheet_index, 1, 6, 7))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 5, 15), workbook.get_cell(worksheet_index, 2, 6, 12))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 5, 12), workbook.get_cell(worksheet_index, 3, 6, 9))

    series.plot_on_second_axis = True
```


## **Обновление диаграмм**

Aspose.Slides for Python via .NET позволяет обновлять диаграммы PowerPoint, изменяя их данные, форматирование и стили. Эта возможность упрощает поддержание презентаций в актуальном состоянии с динамическим содержимым и гарантирует, что диаграммы точно отражают текущие данные и визуальные стандарты.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), представляющего презентацию с диаграммой.
1. Получите ссылку на слайд, используя его индекс.
1. Пройдите по всем фигурам, чтобы найти диаграмму.
1. Получите доступ к листу данных диаграммы.
1. Измените ряд данных диаграммы, изменив значения рядов.
1. Добавьте новый ряд и заполните его данными.
1. Сохраните изменённую презентацию в файл PPTX.

Этот Python‑код показывает, как обновить диаграмму:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# Создайте экземпляр класса Presentation, представляющего файл PPTX.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape

            # Установите индекс листа данных диаграммы.
            worksheet_index = 0

            # Получите рабочую книгу данных диаграммы.
            workbook = chart.chart_data.chart_data_workbook

            # Измените имена категорий диаграммы.
            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            # Получите первый ряд диаграммы.
            series = chart.chart_data.series[0]

            # Обновите данные ряда.
            workbook.get_cell(worksheet_index, 0, 1, "New_Series1")  # Изменение имени ряда.
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            # Получите второй ряд диаграммы.
            series = chart.chart_data.series[1]

            # Обновите данные ряда.
            workbook.get_cell(worksheet_index, 0, 2, "New_Series2")  # Изменение имени ряда.
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            # Добавьте новый ряд.
            series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), chart.type)

            # Заполните данные ряда.
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 3, 20))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 3, 50))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 3, 30))

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

            # Сохраните презентацию с диаграммой.
            presentation.save("ModifiedChart.pptx", slides.export.SaveFormat.PPTX)
```


## **Установка диапазона данных для диаграмм**

Aspose.Slides for Python via .NET предоставляет гибкость определения конкретного диапазона данных из листа как источника данных для вашей диаграммы. Это означает, что вы можете напрямую сопоставлять часть листа с диаграммой, контролируя, какие ячейки участвуют в рядах и категориях диаграммы. В результате вы сможете легко обновлять и синхронизировать диаграммы с последними изменениями данных в листе, обеспечивая актуальность и точность информации в ваших презентациях PowerPoint.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), представляющего презентацию с диаграммой.
1. Получите ссылку на слайд, используя его индекс.
1. Пройдите по всем фигурам, чтобы найти диаграмму.
1. Получите доступ к данным диаграммы и задайте диапазон.
1. Сохраните изменённую презентацию в файл PPTX.

Этот Python‑код показывает, как задать диапазон данных для диаграммы:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# Создайте экземпляр класса Presentation, представляющего файл PPTX.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # Получите первый слайт.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("DataRange.pptx", slides.export.SaveFormat.PPTX)
```


## **Использование маркеров по умолчанию в диаграммах**

При использовании маркеров по умолчанию в диаграммах каждый ряд получает автоматически другой символ маркера.

Этот Python‑код показывает, как автоматически задать маркер для ряда диаграммы:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "C1"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 1, 24))

    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "C2"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 1, 23))

    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C3"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 1, -10))

    chart.chart_data.categories.add(workbook.get_cell(0, 4, 0, "C4"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 1, None))

    series2 = chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "Series 2"), chart.type)

    # Заполнить данные серии.
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Какие типы диаграмм поддерживает Aspose.Slides for Python via .NET?**

Aspose.Slides for Python via .NET поддерживает широкий спектр типов диаграмм, включая столбчатые, линейные, круговые, областные, точечные, гистограммы, радиальные и многие другие. Эта гибкость позволяет выбрать наиболее подходящий тип диаграммы для ваших потребностей в визуализации данных.

**Как добавить новую диаграмму на слайд?**

Чтобы добавить диаграмму, сначала создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), получите нужный слайд по его индексу и вызовите метод добавления диаграммы, указав тип диаграммы и начальные данные. Этот процесс интегрирует диаграмму напрямую в вашу презентацию.

**Как обновить данные, отображаемые в диаграмме?**

Вы можете обновлять данные диаграммы, получив доступ к её рабочей книге данных ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)), очистив любые ряды и категории по умолчанию и затем добавив свои собственные данные. Это позволяет программно обновлять диаграмму, отражая последние данные.

**Можно ли настроить внешний вид диаграммы?**

Да, Aspose.Slides for Python via .NET предоставляет обширные возможности настройки. Вы можете модифировать цвета, шрифты, подписи, легенды и другие элементы форматирования, чтобы адаптировать внешний вид диаграммы к вашим требованиям к дизайну.