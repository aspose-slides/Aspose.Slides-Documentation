---
title: Управляйте метками данных диаграмм в презентациях с помощью Python
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
description: "Узнайте, как добавлять и форматировать метки данных диаграмм в презентациях PowerPoint с помощью Aspose.Slides для Python через .NET для более увлекательных слайдов."
---
## **Введение**

Метки данных отображают информацию о рядах диаграммы и отдельных точках данных, помогая читателям определять значения и понимать диаграмму. В этой статье объясняется, как форматировать значения, отображать проценты, считывать текст метки, управлять метками за пределами максимума оси, регулировать расстояние между метками оси категорий и позиционировать метки круговой диаграммы.

## **Установка точности данных в метках диаграмм**

Используйте [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) для форматирования значений ряда. Этот пример создаёт линейную диаграмму с данными по умолчанию, отображает её таблицу данных и включает метки значений для первого ряда. Формат `#,##0.00` выводит разделитель тысяч и два знака после запятой, не изменяя базовые значения.

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

Чтобы отформатировать числовые ячейки во вложенной рабочей книге диаграммы, см. [Установить пользовательские числовые форматы для ячеек рабочей книги](/slides/ru/python-net/chart-workbook/#set-custom-number-formats-for-workbook-cells). В этом примере также показано, как метки значений используют форматы исходных ячеек, при этом сохраняются сохранённые числовые значения.

## **Отображать процент в виде меток**

Для сложенной столбчатой диаграммы вычислите каждое значение как процент от общей суммы категории и задайте текст в [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). Этот пример использует данные диаграммы по умолчанию и отображает проценты с двумя знаками после запятой шрифтом размером 8 пунктов. Категории с нулевой общей суммой пропускаются, чтобы избежать деления на ноль. При изменении данных диаграммы пересчитайте пользовательский текст метки.

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

## **Установить знак процента в метках данных диаграммы**

Если значения хранятся в виде дробей, используйте [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) для отображения процентов. Установите [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) в `False`, чтобы применить формат метки независимо от исходных ячеек.

Этот пример создаёт 100% сложенную столбчатую диаграмму с красными и синими рядами по четырём категориям. Каждая пара значений суммируется до 1. Формат метки `0.0%` отображает 0.30 как 30.0%, тогда как вертикальная ось использует два знака после запятой. Оба ряда используют белый текст метки размером 10 пунктов.

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

## **Получить фактический текст меток данных**

Используйте [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) для получения текста, сформированного настройками метки данных. Это полезно при извлечении меток для отчетов, поиске содержимого презентации или проверке сгенерированных диаграмм. В примере ниже стандартный [формат метки данных](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) соединяет имя категории, имя ряда и значение. Одна точка форматирует своё значение как процент, а другая использует пользовательский текст из [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

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

Число, хранимое в точке данных, остаётся `0.75`, даже когда его метка показывает `75%` вместе с именами категории и ряда. Пользовательский текст заменяет сгенерированный текст метки. [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) возвращает полученную строку метки в любом случае. Проверяйте [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) отдельно, как показано выше, когда нужно извлекать только видимые метки.

## **Управление метками данных за пределами максимума оси**

Если вы ограничиваете диапазон оси вручную, некоторые точки данных могут превысить её максимум. Используйте [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) для контроля отображения их меток. Эта настройка меняет видимость меток; она не меняет диапазон оси и базовые значения данных.

В примере ниже создаётся 2D сгруппированная столбчатая диаграмма со значениями 60 и 120. На вертикальной оси устанавливается [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) в `False` и [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) в 100. На первом слайде разрешены метки за пределами максимума; копия этого слайда отключает их. Оба слайда сохраняются в `DataLabelsOverMaximum.pptx`.

Включите метки значений с помощью [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). Настройка на уровне диаграммы не включает отображение значений сама по себе и не переопределяет отключённое отображение отдельной метки. Этот пример включает значения для всего ряда и использует [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) для размещения меток на внешнем конце каждого столбца.

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

Следующие изображения показывают сохранённые слайды, отрендеренные в Microsoft PowerPoint. При `True` метка **120** видна у верхней границы; при `False` она скрыта. Метка **60** остаётся видимой, максимум оси остаётся **100**, а вторая точка данных остаётся **120** в обоих случаях.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Этот пример использует 2D столбчатую диаграмму со значительной осью. Диаграммы без значительной оси, такие как круговые и кольцевые, не имеют максимума оси, который можно было бы ограничить таким способом.
{{% /alert %}}

## **Установить расстояние метки от оси**

Используйте [label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) для управления расстоянием между метками оси категорий и самой осью. Значение является процентом от максимального размера шрифта меток оси. Этот пример создаёт сгруппированную столбчатую диаграмму и задаёт смещение метки горизонтальной оси равным 500. Эта настройка влияет на метки оси категорий, а не на метки, привязанные к отдельным точкам данных.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Регулировать расположение метки**

На круговой диаграмме регулируйте позицию меток данных, чтобы улучшить интервалы и освободить место для линий‑соединителей.

Этот пример отображает значение первой точки данных, размещает её метку за пределами сектора и корректирует её смещения по [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) и [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/). Эти смещения задаются относительно ширины и высоты диаграммы соответственно.

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

## **Форматировать линейки‑соединители**

Когда метки круговой диаграммы находятся за пределами своих секторов, линии‑соединители помогают читателю сопоставить каждое значение с соответствующим сектором. Контрастный цвет и слегка утолщённая линия делают эти соединения легче воспринимаемыми, а прозрачность и пунктирный стиль сохраняют их визуальную незаметность.

Используйте [leader_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/leader_lines_format/) для форматирования линий‑соединителей на уровне коллекции меток данных ряда. Настройки в `series.labels.leader_lines_format.line` применяются к коллекции, а не к отдельной метке.

Этот пример создаёт круговую диаграмму с данными по умолчанию, отображает значения за пределами секторов и включает [show_leader_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_leader_lines/). Он удаляет две метки дальше от их секторов, используя смещения по [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) и [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/), выраженные в долях ширины и высоты диаграммы. Входная презентация не требуется.

Линия имеет [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/), задающий сплошной синий цвет с альфа‑значением 191 из 255, что даёт примерно 25 % прозрачности. [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) устанавливает толщину в 2 пункта, а [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) делает линию пунктирной.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 80, 50, 560, 400)
    chart.has_legend = False

    series = chart.chart_data.series[0]

    label_format = series.labels.default_data_label_format
    label_format.show_value = True
    label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label_format.show_leader_lines = True

    # Переместить две метки дальше от их секторов.
    series.labels[0].x = 0.10
    series.labels[0].y = -0.05
    series.labels[1].x = -0.10
    series.labels[1].y = 0.05

    line = series.labels.leader_lines_format.line
    line.fill_format.fill_type = slides.FillType.SOLID
    line.fill_format.solid_fill_color.color = drawing.Color.from_argb(191, 30, 90, 160)
    line.width = 2
    line.dash_style = slides.LineDashStyle.DASH

    presentation.save("FormattedLeaderLines.pptx", slides.export.SaveFormat.PPTX)
```

Включение линий‑соединителей не гарантирует, что линия появится у каждой метки. Видимость зависит от расположения метки и поведения размещения диаграммы. В этом примере две смещённые метки имеют видимые линии‑соединители; метки, оставшиеся близко к своим секторам, их не требуют.

Следующее изображение показывает сохранённый `FormattedLeaderLines.pptx`, отрендеренный с помощью Aspose.Slides:

![Круговая диаграмма с синими, полупрозрачными пунктирными линейками‑соединителями, соединяющими две внешние метки с их секторами](formatted-leader-lines.png)

## **Добавить несколько строк меток данных над столбчатой диаграммой**

Этот пример создаёт столбчатую диаграмму с двумя строками меток данных над областью построения. Ряд A отображает видимые столбцы, а ряды B и C предоставляют дополнительные метки. Их столбцы скрыты удалением заливки и контура. Свойство [overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) выравнивает все три ряда по центрам категорий.

Настройки [plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) резервируют место для строк меток. После того как [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) вычисляет позиции по умолчанию, [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) и [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) сохраняют горизонтальное выравнивание и применяют вертикальные смещения для размещения меток в две строки. Числа остаются метками данных, привязанными к значениям рядов; только заголовки строк являются отдельными текстовыми фигурами.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 40, 640, 200)
    chart.has_title = False
    chart.has_legend = False
    chart.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [
        [35, 42, 28, 47],
        [22, 31, 19, 26],
        [12, 16, 14, 18]
    ]

    for category_index, category_name in enumerate(categories):
        category_cell = workbook.get_cell(0, category_index + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.get_cell(0, 0, series_index + 1, series_name)
        series = chart.chart_data.series.add(series_cell, charts.ChartType.CLUSTERED_COLUMN)

        for category_index in range(len(categories)):
            value_cell = workbook.get_cell(0, category_index + 1, series_index + 1, series_values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

        if series_index > 0:
            # Скрыть столбцы B и C, но оставить их подписи данных.
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # Выравнивание всех трех рядов по одинаковым центрам категорий.
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # Использовать меньше сеток для этого компактного примера.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # Зарезервировать пространство над областью построения для двух строк подписей данных.
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER
    chart.plot_area.x = 0.15
    chart.plot_area.y = 0.32
    chart.plot_area.width = 0.80
    chart.plot_area.height = 0.48
    chart.validate_chart_layout()

    for series_index in range(1, len(series_names)):
        series = chart.chart_data.series[series_index]
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.data_points[category_index].label
            # Сохранить позицию по умолчанию по горизонтали. Y — смещение от
            # позиции подписи по умолчанию, выраженное как доля высоты диаграммы.
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # Только заголовок строки является отдельной текстовой фигурой.
        row_heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, chart.x, chart.y + row_top * chart.height, 85, 18)
        row_heading.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.add_text_frame(series_names[series_index])
        row_heading.text_frame.text_frame_format.margin_top = 0
        row_heading.text_frame.text_frame_format.margin_bottom = 0
        heading_format = row_heading.text_frame.paragraphs[0].portions[0].portion_format
        heading_format.font_height = 12
        heading_format.fill_format.fill_type = slides.FillType.SOLID
        heading_format.fill_format.solid_fill_color.color = drawing.Color.black

    presentation.save("multiple-rows-of-labels.pptx", slides.export.SaveFormat.PPTX)
```

![Столбчатая диаграмма с двумя строками меток данных над областью построения](multiple-rows-of-labels.png)

## **FAQ**

**Как предотвратить наложение меток данных на насыщенных диаграммах?**  
Комбинируйте автоматическое размещение меток, линии‑соединители и уменьшенный размер шрифта; при необходимости скрывайте некоторые поля (например, категорию) или отображайте метки только для экстремальных значений или ключевых точек.

**Как отключить метки только для нулевых, отрицательных или пустых значений?**  
Отфильтруйте точки данных перед включением меток и отключите отображение для значений 0, отрицательных значений или отсутствующих значений согласно заданному правилу.

**Как обеспечить единый стиль меток при экспорте в PDF/изображения?**  
Явно задайте семейство шрифта и размер и убедитесь, что шрифт доступен в среде рендеринга, чтобы избежать подстановки.