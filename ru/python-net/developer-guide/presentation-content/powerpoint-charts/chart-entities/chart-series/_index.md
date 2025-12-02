---
title: Управление данными серий диаграмм в Python
linktitle: Серии данных
type: docs
url: /ru/python-net/chart-series/
keywords:
- серии диаграмм
- перекрытие серий
- цвет серии
- цвет категории
- название серии
- точка данных
- промежуток серии
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как управлять сериями данных диаграмм в Python для PowerPoint (PPT/PPTX) с практическими примерами кода и лучшими практиками для улучшения ваших презентаций данных."
---

## **Обзор**

В этой статье описывается роль [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) в Aspose.Slides for Python, с упором на то, как данные структурируются и визуализируются в презентациях. Эти объекты предоставляют базовые элементы, определяющие отдельные наборы точек данных, категории и параметры отображения в диаграмме. Работая с [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/), разработчики могут без проблем интегрировать исходные данные и полностью контролировать способ их отображения, создавая динамичные, основанные на данных презентации, которые ясно передают выводы и анализ.

Серия — это строка или столбец чисел, построенных в диаграмме.

![серия-диаграммы-powerpoint](chart-series-powerpoint.png)

## **Установка перекрытия серий**

Свойство [ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) управляет тем, как перекрываются столбцы и полосы в 2‑D‑диаграмме, задавая диапазон от ‑100 до 100. Поскольку это свойство относится к группе серий, а не к отдельной серии, оно только для чтения на уровне серии. Чтобы задать значения перекрытия, используйте свойство `parent_series_group.overlap` с доступом для чтения/записи, которое применяет указанное перекрытие ко всем сериям в группе.

Ниже приведён пример на Python, демонстрирующий создание презентации, добавление сгруппированной столбчатой диаграммы, доступ к первой серии, настройку перекрытия и сохранение результата в файл PPTX:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавьте сгруппированную столбчатую диаграмму с данными по умолчанию.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # Установите перекрытие серии.
        series.parent_series_group.overlap = series_overlap

    # Сохраните файл презентации на диск.
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![Перекрытие серий](series_overlap.png)

## **Изменение цвета заливки серии**

Aspose.Slides упрощает настройку цветов заливки серий диаграмм, позволяя выделять определённые точки данных и создавать визуально привлекательные диаграммы. Это достигается через объект [Format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/format/), который поддерживает различные типы заливок, конфигурации цветов и другие расширенные параметры стилей. После добавления диаграммы на слайд и доступа к нужной серии достаточно получить объект серии и применить соответствующий цвет заливки. Помимо сплошных заливок, можно использовать градиентные или узорчатые заливки для большей гибкости дизайна. После установки цветов согласно требованиям сохраните презентацию, чтобы зафиксировать изменения.

Следующий пример кода на Python показывает, как изменить цвет первой серии:
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавьте сгруппированную столбчатую диаграмму с данными по умолчанию.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # Установите цвет первой серии.
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # Сохраните файл презентации на диск.
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![Цвет серии](series_color.png)

## **Переименование серии** 

Aspose.Slides предоставляет простой способ изменить имена серий диаграмм, что упрощает маркировку данных понятным и значимым образом. Получив доступ к соответствующей ячейке листа данных диаграммы, разработчики могут настроить отображение данных. Такое изменение особенно полезно, когда необходимо обновить или уточнить названия серий в контексте данных. После переименования серии презентацию можно сохранить, чтобы изменения сохранились.

Ниже приведён фрагмент кода на Python, демонстрирующий процесс:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавьте сгруппированную столбчатую диаграмму с данными по умолчанию.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # Установите имя первой серии.
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # Сохраните файл презентации на диск.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```


Следующий пример кода на Python показывает альтернативный способ изменить имя серии:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавьте сгруппированную столбчатую диаграмму с данными по умолчанию.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # Установите имя первой серии.
    series.name.as_cells[0].value = series_name

    # Сохраните файл презентации на диск.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```


Результат:

![Имя серии](series_name.png)

## **Получение автоматического цвета заливки серии**

Aspose.Slides for Python позволяет получить автоматический цвет заливки для серий диаграмм в области построения. После создания экземпляра класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) можно получить ссылку на нужный слайд по индексу, затем добавить диаграмму нужного типа (например, `ChartType.CLUSTERED_COLUMN`). Получив доступ к сериям в диаграмме, можно получить автоматический цвет заливки.

Ниже приведён подробный пример кода на Python.
```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавьте сгруппированную столбчатую диаграмму с данными по умолчанию.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    for i in range(len(chart.chart_data.series)):
        # Получите цвет заливки серии.
        color = chart.chart_data.series[i].get_automatic_series_color()
        print(f"Series {i} color: {color.name}")
```


Пример вывода:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```


## **Установка инверсных цветов заливки для серии**

Когда серия данных содержит как положительные, так и отрицательные значения, одинаковая заливка всех столбцов или полос затрудняет чтение диаграммы. Aspose.Slides for Python позволяет задать инверсный цвет заливки — отдельную заливку, автоматически применяемую к точкам данных ниже нуля, благодаря чему отрицательные значения сразу бросаются в глаза. В этом разделе вы узнаете, как включить эту опцию, выбрать подходящий цвет и сохранить обновлённую презентацию.

Следующий пример кода демонстрирует работу:
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

    # Добавьте новые категории.
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Category 3"))

    # Добавьте новую серию.
    series = chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Заполните данные серии.
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))

    # Установите параметры цвета для серии.
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![Инвертированный сплошной цвет заливки](inverted_solid_fill_color.png)

Можно инвертировать цвет заливки для отдельной точки данных, а не всей серии. Просто получите нужный `ChartDataPoint` и установите его свойство `invert_if_negative` в `True`.

Следующий пример кода показывает, как это сделать:
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


## **Очистка данных для конкретных точек**

Иногда в диаграмме присутствуют тестовые значения, выбросы или устаревшие записи, которые необходимо удалить без пересоздания всей серии. Aspose.Slides for Python позволяет выбрать любую точку данных по индексу, очистить её содержимое и мгновенно обновить построение, чтобы оставшиеся точки сдвинулись, а оси автоматически пересчитали масштаб.

Следующий пример кода демонстрирует эту операцию:
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


## **Установка ширины промежутка серии**

Ширина промежутка контролирует количество пустого пространства между соседними столбцами или полосами — большие промежутки подчёркивают отдельные категории, а меньшие создают более плотный вид. С помощью Aspose.Slides for Python можно точно настроить этот параметр для всей серии, достигая нужного визуального баланса в презентации без изменения исходных данных.

Следующий пример кода показывает, как задать ширину промежутка для серии:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# Создайте пустую презентацию.
with slides.Presentation() as presentation:

    # Доступ к первому слайду.
    slide = presentation.slides[0]

    # Добавьте диаграмму с данными по умолчанию.
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    # Сохраните презентацию на диск.
    presentation.save("default_gap_width.pptx", slides.export.SaveFormat.PPTX)

    # Установите значение gap_width.
    series = chart.chart_data.series[0]
    series.parent_series_group.gap_width = gap_width

    # Сохраните презентацию на диск.
    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![Ширина промежутка](gap_width.png)

## **FAQ**

**Есть ли ограничение на количество серий в одной диаграмме?**

Aspose.Slides не накладывает фиксированного лимита на количество добавляемых серий. Практический предел определяется читаемостью диаграммы и доступной памяти приложения.

**Что делать, если столбцы внутри кластера находятся слишком близко друг к другу или слишком далеко?**

Отрегулируйте параметр [gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_width/) для этой серии (или её родительской группы серий). Увеличение значения расширит пространство между столбцами, а уменьшение — сократит его.