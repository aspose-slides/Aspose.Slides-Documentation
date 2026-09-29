---
title: Управление подписями данных диаграмм в презентациях с помощью Python
linktitle: Подпись данных
type: docs
url: /ru/python-net/chart-data-label/
keywords:
- диаграмма
- подпись данных
- точность данных
- процент
- расстояние подписи
- расположение подписи
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как добавлять и форматировать подписи данных диаграмм в презентациях PowerPoint с помощью Aspose.Slides для Python через .NET, чтобы сделать слайды более увлекательными."
---
## **Введение**

Подписи данных отображают информацию о сериях диаграммы и отдельных точках данных, помогая читателям определять значения и понимать диаграмму. В этой статье объясняется, как форматировать значения, отображать проценты, считывать текст подписи, управлять подписями за пределами максимального значения оси, регулировать интервал подписи оси категорий и позиционировать подписи круговой диаграммы.

## **Установка точности данных в подписьах диаграммы**

Используйте [number_format_of_values](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/number_format_of_values/) для форматирования значений серии. Этот пример создаёт линейную диаграмму с данными по умолчанию, отображает её таблицу данных и включает подписи значений для первой серии. Формат `#,##0.00` выводит разделитель тысяч и два знака после запятой, не изменяя исходные значения.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
    chart.has_data_table = True

    series = chart.chart_data.series[0]
    series.number_format_of_values = "#,##0.00"
    series.labels.default_data_label_format.show_value = True

    presentation.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Отображение процентов в подписях**

Для сложенной столбчатой диаграммы вычислите каждое значение как процент от общей суммы категории и задайте текст через [text_frame_for_overriding](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). Этот пример использует данные диаграммы по умолчанию и выводит проценты с двумя знаками после запятой шрифтом 8 пунктов. Категории с нулевой суммой пропускаются, чтобы избежать деления на ноль. При изменении данных диаграммы пересчитайте пользовательский текст подписи.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)

    category_totals = [0.0] * len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for series in chart.chart_data.series:
            point_value = float(series.data_points[k].value.data)
            category_totals[k] += point_value

    for series in chart.chart_data.series:
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            label = series.data_points[j].label
            if category_totals[j] == 0:
                continue

            point_value = float(series.data_points[j].value.data)
            data_point_percent = point_value / category_totals[j] * 100

            portion = slides.Portion()
            portion.text = f"{data_point_percent:.2f} %"
            portion.portion_format.font_height = 8

            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(portion)

            label.data_label_format.show_value = True
            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка знака процента в подписи диаграммы**

Когда значения хранятся в виде дробей, используйте [number_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datalabelformat/number_format/) для отображения процентов. Установите [is_number_format_linked_to_source](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) в `False`, чтобы применить формат подписи независимо от исходных ячеек.

В этом примере создаётся 100 % сложенная столбчатая диаграмма с красными и синими сериями в четырёх категориях. Каждая пара значений суммируется до 1. Формат подписи `0.0%` выводит 0.30 как 30.0 %, а вертикальная ось использует два знака после запятой. Обе серии используют белый текст подписи размером 10 пунктов.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [drawing.Color.red, drawing.Color.blue]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i in range(len(series_names)):
        series_cell = workbook.get_cell(worksheet_index, 0, i + 1, series_names[i])
        series = chart.chart_data.series.add(series_cell, chart.type)
        for j in range(4):
            value_cell = workbook.get_cell(worksheet_index, j + 1, i + 1, values[i][j])
            series.data_points.add_data_point_for_bar_series(value_cell)

        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = series_colors[i]

        label_format = series.labels.default_data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = False
        label_format.number_format = "0.0%"
        label_format.text_format.portion_format.font_height = 10
        label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.text_format.portion_format.fill_format.solid_fill_color.color = drawing.Color.white

    presentation.save("SetDataLabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Получение фактического текста подписи данных**

Используйте [get_actual_label_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) для получения текста, сформированного настройками подписи данных. Это полезно при извлечении подписей для отчётов, поиске содержимого презентаций или проверке сгенерированных диаграмм. В примере ниже стандартный [data label format](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datalabelformat/) объединяет имя категории, имя серии и значение. Одна точка форматирует своё значение как процент, другая использует пользовательский текст из [text_frame_for_overriding](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    for i, category_name in enumerate(["Q1", "Q2"]):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    north_cell = workbook.get_cell(0, 0, 1, "North")
    north = chart.chart_data.series.add(north_cell, chart.type)
    for i, value in enumerate([0.25, 0.75]):
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        north.data_points.add_data_point_for_bar_series(value_cell)

    south_cell = workbook.get_cell(0, 0, 2, "South")
    south = chart.chart_data.series.add(south_cell, chart.type)
    for i, value in enumerate([0.40, 0.60]):
        value_cell = workbook.get_cell(0, i + 1, 2, value)
        south.data_points.add_data_point_for_bar_series(value_cell)

    for series in chart.chart_data.series:
        label_format = series.labels.default_data_label_format
        label_format.show_category_name = True
        label_format.show_series_name = True
        label_format.show_value = True

    north.labels[1].data_label_format.is_number_format_linked_to_source = False
    north.labels[1].data_label_format.number_format = "0%"
    south.labels[0].text_frame_for_overriding.text = "Reviewed"

    for series in chart.chart_data.series:
        for point in series.data_points:
            label = point.label
            if not label.is_visible:
                continue

            label_text = label.get_actual_label_text()
            print(f"Value: {point.value.data}; label: {label_text}")
```

Число, хранящееся в точке данных, остаётся `0.75`, даже если её подпись показывает `75%` вместе с именами категории и серии. Пользовательский текст заменяет сгенерированный текст подписи. [get_actual_label_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) возвращает полученную строку подписи в обоих случаях. Проверяйте [is_visible](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datalabel/is_visible/) отдельно, как показано выше, когда нужно извлечь только видимые подписи.

## **Управление подписями данных, выходящими за пределы максимума оси**

Когда диапазон оси ограничен вручную, некоторые точки данных могут превышать её максимум. Используйте [show_data_labels_over_maximum](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) для управления тем, показывать ли их подписи. Этот параметр меняет только видимость подписи; он не меняет диапазон оси и исходные значения.

В примере ниже создаётся 2D сгруппированная столбчатая диаграмма со значениями 60 и 120. Для вертикальной оси устанавливаются [is_automatic_max_value](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/axis/is_automatic_max_value/) в `False` и [max_value](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/axis/max_value/) в 100. На первом слайде подписи за пределами максимума отображаются; копия этого слайда отключает их. Оба слайда сохраняются в `DataLabelsOverMaximum.pptx`.

Включите подписи значений с помощью [show_value](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datalabelformat/show_value/). Настройка уровня диаграммы не включает отображение значений сама по себе и не переопределяет отключённое отображение отдельной подписи. Этот пример включает значения для всей серии и использует [position](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datalabelformat/position/) для размещения подписей с внешнего конца каждого столбца.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    first_category = workbook.get_cell(0, 1, 0, "Within range")
    second_category = workbook.get_cell(0, 2, 0, "Above maximum")

    chart.chart_data.categories.add(first_category)
    chart.chart_data.categories.add(second_category)

    series_name = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_name, chart.type)

    first_value = workbook.get_cell(0, 1, 1, 60)
    second_value = workbook.get_cell(0, 2, 1, 120)

    series.data_points.add_data_point_for_bar_series(first_value)
    series.data_points.add_data_point_for_bar_series(second_value)

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 100
    chart.show_data_labels_over_maximum = True

    second_slide = presentation.slides.add_clone(slide)
    second_chart = second_slide.shapes[0]
    second_chart.show_data_labels_over_maximum = False

    presentation.save("DataLabelsOverMaximum.pptx", slides.export.SaveFormat.PPTX)
```

Ниже показаны сохранённые слайды, отрисованные Microsoft PowerPoint. При `True` подпись **120** видна у верхней границы; при `False` она скрыта. Подпись **60** остаётся видимой, максимум оси остаётся **100**, а второй пункт данных остаётся **120** в обоих случаях.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Этот пример использует 2D столбчатую диаграмму с осью значений. Диаграммы без оси значений, такие как круговые и кольцевые, не имеют максимума оси, который можно ограничить таким способом.
{{% /alert %}}

## **Установка расстояния подписи от оси**

Используйте [label_offset](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/axis/label_offset/) для контроля расстояния между подписями оси категорий и самой осью. Значение выражается в процентах от максимального размера шрифта подписей оси. Этот пример создаёт сгруппированную столбчатую диаграмму и задаёт смещение подписи горизонтальной оси равным 500. Эта настройка влияет на подписи оси категорий, а не на подписи, привязанные к отдельным точкам данных.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Регулировка расположения подписи**

На круговой диаграмме отрегулируйте позиции подписей данных, чтобы улучшить интервалы и освободить место для вспомогательных линий.

Этот пример отображает значение первой точки данных, размещает её подпись за пределами сектора и регулирует её смещения [x](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datalabel/x/) и [y](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datalabel/y/). Эти смещения задаются относительно ширины и высоты диаграммы соответственно.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 200, 200)
    series = chart.chart_data.series

    label = series[0].labels[0]
    label.data_label_format.show_value = True
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **FAQ**

**Как предотвратить наложение подписей данных на плотных диаграммах?**

Комбинируйте автоматическое размещение подписей, вспомогательные линии и уменьшенный размер шрифта; при необходимости скрывайте некоторые поля (например, категорию) или отображайте подписи только для экстремальных значений или ключевых точек.

**Как отключить подписи только для нулевых, отрицательных или пустых значений?**

Отфильтруйте точки данных перед включением подписей и отключите отображение для значений 0, отрицательных значений или отсутствующих значений согласно заданному правилу.

**Как обеспечить единый стиль подписи при экспорте в PDF/изображения?**

Явно задайте семейство шрифта и его размер и убедитесь, что шрифт доступен в среде рендеринга, чтобы избежать подстановки.