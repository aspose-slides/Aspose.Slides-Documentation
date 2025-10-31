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
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как добавлять и форматировать подписи данных диаграмм в презентациях PowerPoint и OpenDocument, используя Aspose.Slides для Python через .NET, для более захватывающих слайдов."
---

## **Обзор**

Подписи данных на диаграмме показывают детали о серии данных диаграммы или отдельных точках данных. Они позволяют читателям быстро определить серии данных и делают диаграммы более понятными. В Aspose.Slides для Python вы можете включать, настраивать и форматировать подписи данных для любой диаграммы — выбирая, что отображать (значения, проценты, имена серий или категорий), где размещать подписи и как они выглядят (шрифт, числовой формат, разделители, линии‑проводники и многое другое). Эта статья описывает основные API и примеры, необходимые для добавления четких, информативных подписей к вашим диаграммам.

## **Установка точности подписи данных**

Подписи данных диаграммы часто отображают числовые значения, которым требуется единообразная точность. В этом разделе показано, как контролировать количество знаков после запятой для подписей данных в Aspose.Slides, применяя соответствующий числовой формат.

Следующий пример на Python показывает, как установить числовую точность для подписей данных диаграммы:

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

## **Отображение процентов в виде подписей**

С помощью Aspose.Slides вы можете отображать проценты в подписьах данных на диаграммах. Пример ниже вычисляет долю каждой точки в своей категории и форматирует подпись, чтобы показать процент.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Создать экземпляр класса Presentation.
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

    # Сохранить презентацию, содержащую диаграмму.
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Отображение знака процента в подписях данных диаграммы**

В этом разделе показано, как отображать проценты в подписях данных диаграммы и включать знак процента с помощью Aspose.Slides. Вы узнаете, как включать процентные значения для всей серии или отдельных точек (идеально для круговых, кольцевых и 100 % сложенных диаграмм) и как управлять форматированием через параметры подписи или пользовательский числовой формат.

Следующий пример на Python показывает, как добавить знак процента к подписи данных диаграммы:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# Создать экземпляр класса Presentation.
with slides.Presentation() as presentation:

    # Получить ссылку на слайд по индексу.
    slide = presentation.slides[0]

    # Создать диаграмму PercentsStackedColumn на слайде.
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # Получить рабочую книгу данных диаграммы.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # Добавить новую серию.
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # Установить цвет заливки серии.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Установить свойства формата подписи.
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # Добавить новую серию.
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # Установить тип и цвет заливки.
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # Сохранить презентацию.
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка расстояния подписи от оси**

В этом разделе показано, как контролировать расстояние между подписями данных и осью диаграммы в Aspose.Slides. Регулировка этого смещения помогает избежать наложения и улучшает читаемость при плотных визуализациях.

Следующий код на Python показывает, как установить расстояние подписи от категориальной оси при работе с диаграммой, основанной на осях:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Создать экземпляр класса Presentation.
with slides.Presentation() as presentation:
    # Получить ссылку на слайд.
    slide = presentation.slides[0]

    # Создать группированную колонную диаграмму на слайде.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Установить расстояние подписи от категориальной (горизонтальной) оси.
    chart.axes.horizontal_axis.label_offset = 500

    # Сохранить презентацию.
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **Регулировка положения подписи**

Когда вы создаете диаграмму без осей, например круговую диаграмму, подписи данных могут быть слишком близко к краю. В таком случае отрегулируйте положение подписи, чтобы линии‑проводники отображались четко.

Следующий код на Python показывает, как отрегулировать положение подписи на круговой диаграмме:

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

![Измененное положение подписи](changed_label_position.png)

## **FAQ**

**Как предотвратить наложение подписей данных на плотных диаграммах?**

Сочетайте автоматическое размещение подписей, линии‑проводники и уменьшенный размер шрифта; при необходимости скрывайте некоторые поля (например, категорию) или показывайте подписи только для экстремальных/ключевых точек.

**Как отключить подписи только для нулевых, отрицательных или пустых значений?**

Отфильтруйте точки данных перед включением подписей и отключите отображение для значений 0, отрицательных значений или отсутствующих данных согласно заданному правилу.

**Как обеспечить единообразный стиль подписи при экспорте в PDF/изображения?**

Явно задайте шрифты (семейство, размер) и убедитесь, что шрифт доступен на стороне рендеринга, чтобы избежать замены.