---
title: Управление рядами данных диаграммы в Python
linktitle: Серии данных
type: docs
url: /ru/python-net/chart-series/
keywords:
- ряды диаграмм
- перекрытие рядов
- цвет серии
- цвет категории
- имя серии
- точка данных
- промежуток серии
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как управлять рядами данных диаграммы в Python для PowerPoint (PPT/PPTX) с практическими примерами кода и рекомендациями по лучшим практикам для улучшения ваших презентаций данных."
---

## **Обзор**

Эта статья описывает роль [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) в Aspose.Slides для Python, фокусируясь на том, как данные структурируются и визуализируются в презентациях. Эти объекты предоставляют базовые элементы, определяющие отдельные наборы точек данных, категории и параметры отображения в диаграмме. Работая с [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/), разработчики могут бесшовно интегрировать источники данных и сохранять полный контроль над способом отображения информации, создавая динамичные, основанные на данных презентации, которые ясно передают выводы и анализ.

Ряд — это строка или столбец чисел, построенных в диаграмме.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установить перекрытие серии**

Свойство [ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) определяет, как столбцы и линии перекрываются в 2D‑диаграмме, задавая диапазон от -100 до 100. Поскольку это свойство относится к группе рядов, а не к отдельному ряду диаграммы, оно доступно только для чтения на уровне ряда. Чтобы задать значение перекрытия, используйте свойство `parent_series_group.overlap` с чтением/записью, которое применяет указанное перекрытие ко всем рядам в этой группе.

Ниже приведён пример на Python, демонстрирующий создание презентации, добавление групповой столбчатой диаграммы, доступ к первому ряду диаграммы, настройку параметра перекрытия и сохранение результата в файл PPTX:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавить группированную столбчатую диаграмму с данными по умолчанию.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # Установить перекрытие серии.
        series.parent_series_group.overlap = series_overlap

    # Сохранить файл презентации на диск.
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The series overlap](series_overlap.png)

## **Изменить цвет заливки серии**

Aspose.Slides упрощает настройку цветов заливки рядов диаграммы, позволяя выделять отдельные точки данных и создавать визуально привлекательные диаграммы. Для этого используется объект [Format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/format/), поддерживающий различные типы заливок, цветовые конфигурации и другие продвинутые параметры оформления. После добавления диаграммы на слайд и доступа к нужному ряду достаточно получить ряд и применить соответствующий цвет заливки. Помимо сплошных заливок, можно использовать градиентные или узорные заливки для повышения гибкости дизайна. После установки цветов в соответствии с требованиями сохраните презентацию, чтобы зафиксировать изменения.

Ниже показан пример кода на Python, изменяющий цвет первого ряда:
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавить группированную столбчатую диаграмму с данными по умолчанию.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # Установить цвет первой серии.
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # Сохранить файл презентации на диск.
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The color of the series](series_color.png)

## **Переименовать серию**

Aspose.Slides предоставляет простой способ изменить имена рядов диаграммы, делая их более понятными и информативными. Получая доступ к соответствующей ячейке листа данных диаграммы, разработчики могут настроить способ представления данных. Это особенно полезно, когда требуется обновить или уточнить имена рядов в зависимости от контекста данных. После переименования ряда презентацию можно сохранить, чтобы изменения сохранились.

Ниже приведён фрагмент кода на Python, демонстрирующий этот процесс:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавить группированную столбчатую диаграмму с данными по умолчанию.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # Установить имя первой серии.
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # Сохранить файл презентации на диск.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```


Следующий пример кода на Python показывает альтернативный способ изменить имя ряда:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавить группированную столбчатую диаграмму с данными по умолчанию.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # Установить имя первой серии.
    series.name.as_cells[0].value = series_name

    # Сохранить файл презентации на диск.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```


Результат:

![The series name](series_name.png)

## **Получить автоматический цвет заливки серии**

Aspose.Slides для Python позволяет получить автоматический цвет заливки рядов диаграммы в области построения. После создания экземпляра класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) можно получить ссылку на нужный слайд по индексу, затем добавить диаграмму выбранного типа (например, `ChartType.CLUSTERED_COLUMN`). Получив доступ к рядам в диаграмме, можно извлечь их автоматический цвет заливки.

Ниже представлен подробный пример кода на Python:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавить группированную столбчатую диаграмму с данными по умолчанию.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    for i in range(len(chart.chart_data.series)):
        # Получить цвет заливки серии.
        color = chart.chart_data.series[i].get_automatic_series_color()
        print(f"Series {i} color: {color.name}")
```


Пример вывода:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```


## **Установить инвертированные цвета заливки для серии**

Когда ряд данных содержит как положительные, так и отрицательные значения, одинаковая заливка всех столбцов или полос может затруднить восприятие диаграммы. Aspose.Slides для Python позволяет задать инвертированный цвет заливки — отдельную заливку, автоматически применяемую к точкам данных, значение которых ниже нуля, так что отрицательные значения сразу выделяются. В этом разделе вы узнаете, как включить эту опцию, выбрать подходящий цвет и сохранить обновлённую презентацию.

Ниже пример кода, демонстрирующий эту операцию:
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

invert_color = draw.Color.red

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Добавить новые категории.
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Category 3"))

    # Добавить новую серию.
    series = chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Заполнить данные серии.
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))

    # Установить настройки цвета для серии.
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The inverted solid fill color](inverted_solid_fill_color.png)

Можно инвертировать цвет заливки для отдельной точки данных, а не для всего ряда. Просто получайте нужный `ChartDataPoint` и задавайте его свойство `invert_if_negative` значение `True`.

Ниже пример кода, показывающий, как это сделать:
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200, True)
	chart.chart_data.series.clear()

	series = series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)

	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series.invert_if_negative = False
	series.data_points[2].invert_if_negative = True

	presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```


## **Очистить данные для конкретных точек данных**

Иногда в диаграмме присутствуют тестовые значения, выбросы или устаревшие записи, которые нужно удалить, не пересоздавая весь ряд. Aspose.Slides для Python позволяет выбрать любую точку данных по индексу, очистить её содержимое и мгновенно обновить построение, так что оставшиеся точки сдвигаются, а оси автоматически пересчитывают масштаб.

Ниже пример кода, демонстрирующий эту операцию:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test_chart.pptx") as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    series = chart.chart_data.series[0]

    for data_point in series.data_points:
        data_point.x_value.as_cell.value = None
        data_point.y_value.as_cell.value = None

    series.data_points.clear()

    presentation.save("clear_data_points.pptx", slides.export.SaveFormat.PPTX)
```


## **Установить ширину промежутка серии**

Ширина промежутка определяет размер пустого пространства между соседними столбцами или полосами — более широкие промежутки подчёркивают отдельные категории, а более узкие создают более плотный, компактный вид. С помощью Aspose.Slides для Python можно точно настроить этот параметр для всего ряда, добиваясь нужного визуального баланса презентации без изменения исходных данных.

Ниже пример кода, показывающий, как задать ширину промежутка для ряда:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# Создать пустую презентацию.
with slides.Presentation() as presentation:

    # Получить доступ к первому слайду.
    slide = presentation.slides[0]

    # Добавить диаграмму с данными по умолчанию.
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    # Сохранить презентацию на диск.
    presentation.save("default_gap_width.pptx", slides.export.SaveFormat.PPTX)

    # Установить значение gap_width.
    series = chart.chart_data.series[0]
    series.parent_series_group.gap_width = gap_width

    # Сохранить презентацию на диск.
    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The gap width](gap_width.png)

## **FAQ**

**Существует ли ограничение на количество рядов, которое может содержать одна диаграмма?**

Aspose.Slides не накладывает фиксированного ограничения на число добавляемых рядов. Практический предел определяется читаемостью диаграммы и доступной оперативной памятью вашего приложения.

**Что делать, если столбцы внутри кластера находятся слишком близко друг к другу или слишком далеко?**

Отрегулируйте настройку [gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_width/) для данного ряда (или его родительской группы рядов). Увеличение значения расширит пространство между столбцами, уменьшение — сблизит их.