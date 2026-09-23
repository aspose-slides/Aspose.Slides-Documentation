---
title: Управление метками данных диаграмм в презентациях с помощью Python
linktitle: Метка данных
type: docs
url: /ru/python-net/chart-data-label/
keywords:
- диаграмма
- метка данных
- точность данных
- процент
- расстояние метки
- расположение метки
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как добавлять и форматировать метки данных диаграмм в презентациях PowerPoint с помощью Aspose.Slides для Python через .NET, чтобы сделать слайды более привлекательными."
---
## **Введение**

Метки данных отображают информацию о сериях диаграммы и отдельных точках данных, помогая читателям определять значения и понимать диаграмму. В этой статье объясняется, как форматировать значения, отображать проценты, считывать текст меток, регулировать расстояние между метками оси категорий и позиционировать метки круговой диаграммы.

## **Установка точности данных в метках диаграмм**

Используйте [number_format_of_values](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/number_format_of_values/) для форматирования значений серии. В этом примере создаётся линейная диаграмма с данными по умолчанию, отображается её таблица данных и включаются метки значений для первой серии. Формат `#,##0.00` выводит разделитель тысяч и два знака после запятой, не изменяя исходные значения.

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

## **Отображение процентов в виде меток**

Для stacked column диаграммы вычислите каждое значение как процент от общей суммы категории и назначьте текст в [text_frame_for_overriding](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). Этот пример использует данные диаграммы по умолчанию и отображает проценты с двумя знаками после запятой шрифтом 8 пунктов. Категории с нулевой общей суммой пропускаются, чтобы избежать деления на ноль. При изменении данных диаграммы пересчитайте пользовательский текст метки.

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

## **Установка знака процента в метках диаграмм**

Когда значения хранятся в виде дробей, используйте [number_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datalabelformat/number_format/) для отображения процентов. Установите [is_number_format_linked_to_source](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) в `False`, чтобы применить формат метки независимо от исходных ячеек.

В этом примере создаётся 100% stacked column диаграмма с красными и синими сериями в четырёх категориях. Каждая пара значений суммируется до 1. Формат метки `0.0%` отображает 0.30 как 30.0%, в то время как вертикальная ось использует два знака после запятой. Обе серии используют белый текст метки размером 10 пунктов.

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

## **Чтение фактического текста меток данных**

Используйте [get_actual_label_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) для получения текста, сформированного настройками метки данных. Это полезно при извлечении меток для отчётов, поиске содержимого презентаций или проверке сгенерированных диаграмм. В приведённом ниже примере формат метки данных по умолчанию объединяет имя категории, имя серии и значение. Одна точка форматирует своё значение как процент, а другая использует пользовательский текст из [text_frame_for_overriding](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

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

Число, хранящееся в точке данных, остаётся `0.75`, даже если её метка отображает `75%` вместе с именами категории и серии. Пользовательский текст заменяет сгенерированный текст метки. [get_actual_label_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) возвращает полученную строку метки в любом случае. Проверяйте [is_visible](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datalabel/is_visible/) отдельно, как показано выше, если нужно извлекать только видимые метки.

## **Установка расстояния метки от оси**

Используйте [label_offset](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/axis/label_offset/) для управления расстоянием между метками оси категорий и самой осью. Значение задаётся в процентах от максимального размера шрифта меток оси. В этом примере создаётся сгруппированная столбчатая диаграмма, и смещение метки горизонтальной оси устанавливается в 500. Эта настройка влияет на метки оси категорий, а не на метки, прикреплённые к отдельным точкам данных.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Настройка расположения метки**

На круговой диаграмме настройте положение меток данных, чтобы улучшить интервалы и освободить место для выносных линий.

В этом примере отображается значение первой точки данных, её метка размещается вне сектора и корректируются её смещения [x](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datalabel/x/) и [y](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datalabel/y/). Эти смещения задаются относительно ширины и высоты диаграммы соответственно.

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

![Круговая диаграмма с отрегулированным положением метки данных](pie-chart-adjusted-label.png)

## **FAQ**

**Как можно предотвратить наложение меток данных на плотных диаграммах?**  
Сочетайте автоматическое размещение меток, выносные линии и уменьшенный размер шрифта; при необходимости скрывайте некоторые поля (например, категорию) или отображайте метки только для экстремальных значений или ключевых точек.

**Как отключить метки только для нулевых, отрицательных или пустых значений?**  
Отфильтруйте точки данных перед включением меток и отключите отображение для значений 0, отрицательных значений или отсутствующих значений в соответствии с заданным правилом.

**Как обеспечить согласованный стиль меток при экспорте в PDF/изображения?**  
Явно задайте семейство шрифта и размер, а также проверьте наличие шрифта в среде рендеринга, чтобы избежать использования резервных шрифтов.