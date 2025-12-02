---
title: Управление данными серии диаграммы в Python
linktitle: Серии данных
type: docs
url: /ru/python-net/chart-series/
keywords:
- серии диаграмм
- перекрытие серии
- цвет серии
- цвет категории
- имя серии
- точка данных
- промежуток серии
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как управлять данными серии диаграммы в Python для PowerPoint (PPT/PPTX) с практическими примерами кода и лучшими практиками для улучшения ваших презентаций данных."
---

## **Обзор**

Эта статья описывает роль [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) в Aspose.Slides for Python, сосредотачивая внимание на том, как данные структурированы и визуализированы в презентациях. Эти объекты предоставляют базовые элементы, определяющие отдельные наборы точек данных, категории и параметры отображения в диаграмме. Работая с [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/), разработчики могут бесшовно интегрировать исходные источники данных и сохранять полный контроль над тем, как информация отображается, что приводит к динамичным, основанным на данных презентациям, ясно передающим инсайты и анализ.

Серия — это строка или колонка чисел, отображаемая на диаграмме.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установка наложения серии**

Свойство [ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) управляет тем, как столбцы и колонки перекрываются в двумерной диаграмме, задавая диапазон от -100 до 100. Поскольку это свойство связано с группой серий, а не с отдельной серией, оно доступно только для чтения на уровне серии. Чтобы задать значение наложения, используйте свойство `parent_series_group.overlap` с возможностью чтения/записи, которое применяет указанное наложение ко всем сериям в этой группе.

Ниже приведён пример на Python, показывающий, как создать презентацию, добавить сгруппированную колонную диаграмму, получить доступ к первой серии, настроить параметр наложения и сохранить результат в файл PPTX:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавить сгруппированную столбчатую диаграмму с данными по умолчанию.
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

## **Изменение цвета заливки серии**

Aspose.Slides упрощает настройку цветов заливки серии диаграммы, позволяя выделять конкретные точки данных и создавать визуально привлекательные диаграммы. Это достигается через объект [Format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/format/), который поддерживает различные типы заливки, конфигурации цветов и другие продвинутые параметры стилей. После добавления диаграммы на слайд и доступа к нужной серии достаточно получить её и применить соответствующий цвет заливки. Помимо сплошных заливок, можно использовать градиентные или шаблонные заливки для большей гибкости дизайна. После установки цветов согласно требованиям сохраните презентацию, чтобы завершить обновление внешнего вида.

Следующий пример кода на Python показывает, как изменить цвет первой серии:
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавить сгруппированную столбчатую диаграмму с данными по умолчанию.
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

## **Переименование серии** 

Aspose.Slides предлагает простой способ изменить имена серий диаграммы, делая маркировку данных более понятной и значимой. Получив доступ к соответствующей ячейке листа в данных диаграммы, разработчики могут настроить представление данных. Это особенно полезно, когда имена серий необходимо обновить или уточнить в зависимости от контекста данных. После переименования серии презентацию можно сохранить, чтобы изменения сохранились. 

Ниже приведён фрагмент кода на Python, демонстрирующий этот процесс.
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавить сгруппированную столбчатую диаграмму с данными по умолчанию.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # Установить имя первой серии.
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # Сохранить файл презентации на диск.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```


Следующий пример кода на Python показывает альтернативный способ изменить имя серии:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавить сгруппированную столбчатую диаграмму с данными по умолчанию.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # Установить имя первой серии.
    series.name.as_cells[0].value = series_name

    # Сохранить файл презентации на диск.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```


Результат:

![The series name](series_name.png)

## **Получение автоматического цвета заливки серии**

Aspose.Slides for Python позволяет получить автоматический цвет заливки серии диаграммы в области построения. После создания экземпляра класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) вы можете получить ссылку на нужный слайд по индексу, затем добавить диаграмму требуемого типа (например, `ChartType.CLUSTERED_COLUMN`). Получив доступ к сериям в диаграмме, можно получить автоматический цвет заливки.

Ниже приведён подробный пример кода на Python.
```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавить сгруппированную столбчатую диаграмму с данными по умолчанию.
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


## **Установка инвертированных цветов заливки для серии**

Когда ваша серия данных содержит как положительные, так и отрицательные значения, одинаковая заливка всех колонок или баров может затруднить восприятие диаграммы. Aspose.Slides for Python позволяет задать инвертированный цвет заливки — отдельную заливку, автоматически применяемую к точкам данных ниже нуля, — чтобы отрицательные значения сразу бросались в глаза. В этом разделе вы узнаете, как включить эту опцию, выбрать подходящий цвет и сохранить обновлённую презентацию.

Следующий пример кода демонстрирует эту операцию:
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

Вы можете инвертировать цвет заливки для отдельной точки данных, а не для всей серии. Просто получите нужный `ChartDataPoint` и установите его свойство `invert_if_negative` в `True`.

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


## **Очистка данных для конкретных точек данных**

Иногда в диаграмме присутствуют тестовые значения, выбросы или устаревшие записи, которые нужно удалить без пересоздания всей серии. Aspose.Slides for Python позволяет выбрать любую точку данных по индексу, очистить её содержимое и мгновенно обновить построение, чтобы оставшиеся точки сдвинулись, а оси автоматически пересчитали масштабы.

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

Ширина промежутка управляет количеством пустого пространства между соседними колонками или барами — более широкие промежутки подчёркивают отдельные категории, а более узкие создают более плотный, компактный вид. С помощью Aspose.Slides for Python вы можете точно настроить этот параметр для всей серии, достигая нужного визуального баланса без изменения исходных данных.

Следующий пример кода показывает, как задать ширину промежутка для серии:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# Создать пустую презентацию.
with slides.Presentation() as presentation:

    # Доступ к первому слайду.
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

**Есть ли ограничение на количество серий в одной диаграмме?**

Aspose.Slides не накладывает фиксированных ограничений на количество добавляемых серий. Практический предел определяется читаемостью диаграммы и доступной памяти вашего приложения.

**Что делать, если столбцы внутри кластера находятся слишком близко друг к другу или слишком далеко?**

Отрегулируйте параметр [gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_width/) для этой серии (или её родительской группы серий). Увеличение значения расширит пространство между столбцами, уменьшение — сделает их ближе друг к другу.