---
title: Управление метками данных диаграммы в презентациях с помощью Python
linktitle: Метка данных
type: docs
url: /ru/python-net/chart-data-label/
keywords:
- chart
- data label
- data precision
- percentage
- label distance
- label location
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Узнайте, как добавлять и форматировать метки данных диаграмм в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET, чтобы создать более привлекательные слайды."
---

## **Обзор**

Метки данных на диаграмме показывают подробную информацию о серии данных диаграммы или отдельном пункте данных. Они позволяют читателям быстро идентифицировать серии данных и делают диаграммы более понятными. В Aspose.Slides для Python вы можете включать, настраивать и форматировать метки данных для любой диаграммы — выбирая, что отображать (значения, проценты, имена серий или категорий), где позиционировать метки и как они будут выглядеть (шрифт, числовой формат, разделители, линии‑выноски и многое другое). В этой статье описаны основные API и примеры, необходимые для добавления чётких информативных меток к вашим диаграммам.

## **Установка точности метки данных**

Меткам данных диаграммы часто требуется отображать числовые значения с одинаковой точностью. В этом разделе показано, как контролировать количество десятичных знаков в метках данных диаграмм в Aspose.Slides, применяя соответствующий числовой формат.

Следующий пример на Python показывает, как задать числовую точность для меток данных диаграммы:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 500, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.number_format_of_values = "#,##0.00"

    presentation.save("data_label_precision.pptx", slides.export.SaveFormat.PPTX)
```

## **Отображение процентов в виде меток**

С помощью Aspose.Slides вы можете отображать проценты в виде меток данных на диаграммах. Пример ниже вычисляет долю каждой точки в своей категории и формирует метку для отображения процента.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 600, 400)
    series = chart.chart_data.series[0]

    total_for_categories = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for i in range(len(chart.chart_data.series)):
            total_for_categories[k] += chart.chart_data.series[i].data_points[k].value.data

    for i in range(len(chart.chart_data.series)):
        series = chart.chart_data.series[i]
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            data_point_percent = series.data_points[j].value.data / total_for_categories[j] * 100

            text_portion = slides.Portion()
            text_portion.text = "{0:.2f} %".format(data_point_percent)
            text_portion.portion_format.font_height = 8

            label = series.data_points[j].label
            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(text_portion)

            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    # Save the presentation containing the chart.
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Отображение знака процента в метках данных диаграммы**

В этом разделе показано, как отображать проценты в метках данных диаграмм и включать знак процента с помощью Aspose.Slides. Вы узнаете, как включать процентные значения для всей серии или отдельных точек (идеально для круговых, кольцевых и 100% сложенных диаграмм) и как контролировать форматирование через параметры меток или пользовательский числовой формат.

Следующий пример на Python показывает, как добавить знак процента к метке данных диаграммы:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:

    # Get a slide reference by index.
    slide = presentation.slides[0]

    # Create a PercentsStackedColumn chart on the slide.
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # Get the chart data workbook.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # Add a new series.
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # Set the series fill color.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Set label format properties.
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # Add a new series.
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # Set the fill type and color.
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # Save the presentation.
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка расстояния метки от оси**

В этом разделе показано, как контролировать расстояние между метками данных и осью диаграммы в Aspose.Slides. Регулировка этого смещения помогает избежать наложения и улучшает читаемость в плотных визуализациях.

Следующий код на Python показывает, как задать расстояние метки от категориальной оси при работе с диаграммой, использующей оси:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    # Get a slide reference.
    slide = presentation.slides[0]

    # Create a clustered column chart on the slide.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Set the label distance from the category (horizontal) axis.
    chart.axes.horizontal_axis.label_offset = 500

    # Save the presentation.
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **Корректировка положения метки**

Когда вы создаёте диаграмму без осей, например круговую диаграмму, метки данных могут быть слишком близко к краю. В этом случае отрегулируйте положение метки, чтобы линии‑выноски отображались чётко.

Следующий код на Python показывает, как скорректировать положение метки на круговой диаграмме:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.show_leader_lines = True

    label = series.labels[0]
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    label.x = 0.05
    label.y = 0.1

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Изменённое положение метки](changed_label_position.png)

## **Часто задаваемые вопросы**

**Как избежать наложения меток данных на плотных диаграммах?**

Комбинируйте автоматическое размещение меток, линии‑выноски и уменьшенный размер шрифта; при необходимости скрывайте некоторые поля (например, категорию) или показывайте метки только для экстремальных/ключевых точек.

**Как отключить метки только для нулевых, отрицательных или пустых значений?**

Отфильтруйте точки данных перед включением меток и отключите отображение для значений 0, отрицательных или отсутствующих значений в соответствии с заданным правилом.

**Как обеспечить единообразный стиль меток при экспорте в PDF/изображения?**

Явно задайте шрифты (семейство, размер) и убедитесь, что шрифт доступен на стороне рендеринга, чтобы избежать подстановки.