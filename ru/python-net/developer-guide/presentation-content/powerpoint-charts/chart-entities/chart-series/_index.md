---
title: Управление рядами данных диаграммы в презентациях на Python
linktitle: Ряды данных
type: docs
url: /ru/python-net/chart-series/
keywords:
- ряды диаграммы
- перекрытие рядов
- цвет ряда
- цвет категории
- имя ряда
- точка данных
- промежуток между рядами
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как управлять рядами диаграмм, точками данных, ячейками рабочей книги, форматированием, перекрытием, шириной промежутка и отрицательными значениями в презентациях с помощью Python."
---
## **Обзор**

Диаграмма сохраняет свои отображаемые данные в рабочей книге данных диаграммы. [ChartSeries](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/) представляет один набор связанных значений, и каждый [ChartDataPoint](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapoint/) в серии ссылается на одну или несколько ячеек рабочей книги. [ChartCategory](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartcategory/) предоставляют метки или группирующие значения, общие для серии. Поэтому имя серии, категории и значения точек связаны с объектами [ChartDataCell](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatacell/), а не хранятся только как отображаемый текст.

Для типичной диаграммы категорий рабочая книга по умолчанию использует строку 0 для имён серий, столбец 0 для имён категорий и остальные ячейки для значений серий. Индексы листа, строки и столбца, передаваемые в [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdataworkbook/get_cell/), являются нулевыми. Такая компоновка полезна, когда вы создаёте диаграмму с данными по умолчанию, но не следует считать, что каждый существующий график использует её. Для загруженной презентации проверьте ячейки, на которые ссылаются серии, категории и точки данных, прежде чем изменять значения в рабочей книге.

Настройки диаграммы имеют три разных уровня:

- Настройки уровня серии, такие как [ChartSeries.format](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/format/), задают внешний вид по умолчанию для всех точек в одной серии.
- Настройки отдельной точки данных, такие как [ChartDataPoint.format](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapoint/format/), переопределяют внешний вид серии для одной точки.
- Настройки группы применяются к совместимым сериям, принадлежащим к одному [ChartSeriesGroup](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseriesgroup/). Обратитесь к группе через [ChartSeries.parent_series_group](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/parent_series_group/), когда необходимо задать такие параметры, как overlap или gap width.

Когда не задано явное заполнение точки или серии, стиль и тема диаграммы определяют автоматический внешний вид. Когда присутствуют как настройки серии, так и точки, форматирование точки имеет приоритет для этой точки.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установить перекрытие серии диаграммы**

[ChartSeries.overlap](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/overlap/) сообщает, насколько перекрываются столбцы или полосы в 2D‑диаграмме, от -100 до 100 процентов. Это только чтение проекции настройки в родительской группе серий. Установите [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseriesgroup/overlap/), чтобы обновить каждую совместимую серию в этой группе. Этот параметр применяется к типам диаграмм, отображающим сгруппированные столбцы или полосы; он не влияет на несвязанные группы серий в комбинированной диаграмме.

Следующий пример задаёт перекрытие для группы, содержащей первую серию:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Новый график содержит образцы рядов, категорий и значений.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Перекрытие серии](series_overlap.png)

## **Изменить цвет заливки серии**

Используйте [ChartSeries.format](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/format/), чтобы задать заливку по умолчанию для всей серии. Если у точки уже задана явная заливка, её настройка [ChartDataPoint.format](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapoint/format/) переопределит заливку серии для этой точки.

Следующий пример применяет сплошную синюю заливку к первой серии:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = drawing.Color.blue

    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Цвет серии](series_color.png)

## **Изменить имя серии**

Имя серии хранится в рабочей книге данных диаграммы и обычно отображается в легенде. В рабочей книге по умолчанию для сгруппированной столбчатой диаграммы ячейка B1 находится в строке 0, столбце 1 и содержит имя первой серии. Именованные константы в следующем примере делают эту структуру явной:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    workbook = chart.chart_data.chart_data_workbook
    series_name_cell = workbook.get_cell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Вы также можете обновить ячейку, уже используемую [ChartSeries.name](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/name/). Этот подход позволяет не полагаться на конкретные строки и столбцы в существующей диаграмме:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series_name_cell = series.name.as_cells[first_name_cell_index]
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Имя серии](series_name.png)

## **Получить автоматический цвет заливки серии**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) возвращает цвет, вычисленный на основе индекса серии и стиля диаграммы. Это цвет, используемый, когда заливка серии явно не определена. Вызов метода только читает вычисленный цвет; он не назначает новую заливку.

Следующий пример выводит автоматический цвет каждой серии по умолчанию:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series_count = len(chart.chart_data.series)
    for series_index in range(series_count):
        series = chart.chart_data.series[series_index]
        automatic_color = series.get_automatic_series_color()
        print(f"Series {series_index}: {automatic_color.name}")
```

Пример вывода для стиля диаграммы по умолчанию:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Точные цвета зависят от стиля и темы диаграммы.

## **Установить инвертированный цвет заливки для серии диаграммы**

Для линейных, столбчатых и пузырьковых серий [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/invert_if_negative/) позволяет отображать отрицательные значения другой заливкой. Установите обычную заливку серии сплошной, включите инверсию и задайте цвет отрицательного значения через [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Отрицательные числа в рабочей книге остаются неизменными; меняется только их цвет отображения.

Следующий пример заменяет данные диаграммы по умолчанию одной серией. Строка 0 листа содержит имя серии, столбец 0 ‑ имена категорий, а столбец 1 ‑ значения:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    series = chart_data.series.add(series_name_cell, chart.type)

    category_count = len(category_names)
    for category_index in range(category_count):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.get_cell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.data_points.add_data_point_for_bar_series(value_cell)

    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.invert_if_negative = True
    series.inverted_solid_fill_color.color = drawing.Color.red

    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Инвертированный сплошной цвет заливки](inverted_solid_fill_color.png)

Вы можете включить инверсию для отдельной точки через [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). В следующем примере инверсия отключена для серии и включена только для выбранной точки. Точке также присвоено отрицательное значение, чтобы эффект был видим:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.inverted_solid_fill_color.color = drawing.Color.red
    series.invert_if_negative = False

    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = negative_value
    data_point.invert_if_negative = True

    presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **Очистить значение конкретной точки данных**

Чтобы сделать одну точку пустой, не удаляя остальные, задайте её ячейке в рабочей книге значение `None`. Для столбчатой диаграммы отображаемое значение доступно через [ChartDataPoint.value](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapoint/value/). Точка данных остаётся на той же позиции категории, но диаграмма рассматривает её значение как пустое в соответствии с настройками пустых значений диаграммы.

Следующий пример очищает только вторую точку в первой серии:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = None

    presentation.save("clear_data_point_value.pptx", slides.export.SaveFormat.PPTX)
```

Диаграммы разброса используют отдельные ячейки X и Y, а пузырьковые диаграммы также используют ячейку размера. Очищайте только ту ячейку, которая представляет значение, которое вы хотите удалить. Не вызывайте [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapointcollection/clear/), когда хотите сохранить остальные точки, так как этот метод удаляет все точки из коллекции.

## **Установить ширину промежутка между сериями**

Ширина промежутка ‑ это пространство между соседними кластерами столбцов или полос, выраженное в процентах от их ширины. Как и перекрытие, она относится к родительской группе серий, а не к отдельной серии. Установите [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) один раз для группы. Большое значение создаёт больше пространства между кластерами; меньшее — делает их плотнее.

Следующий пример изменяет ширину промежутка и сохраняет только конечную презентацию:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.gap_width = gap_width_percent

    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Ширина промежутка](gap_width.png)

## **FAQ**

**Какие типы диаграмм поддерживают данные серии?**

Все типы диаграмм, представленные перечислением [ChartType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/charttype/), используют данные диаграммы, но их серии не всегда имеют одинаковую структуру значений или настройки. Например, диаграммы категорий используют категории и значения, диаграммы разброса — значения X и Y, а пузырьковые диаграммы добавляют размеры пузырьков. Используйте метод создания точек данных, соответствующий типу серии. Параметры, такие как overlap и gap width, применимы только к совместимым группам столбцов или полос.

**Что такое группа серий диаграммы?**

[ChartSeriesGroup](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseriesgroup/) содержит совместимые серии, которые используют общие параметры построения группы. Комбинированная диаграмма может включать более одной группы, поэтому изменение группы, полученной через одну серию, не обязательно изменит все серии в диаграмме.

**Создаётся ли в новой диаграмме набор данных по умолчанию?**

Да. По умолчанию [ShapeCollection.add_chart](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/add_chart/) создаёт образцы серий, категорий и значений. Вы можете редактировать эти ячейки или очистить обе коллекции серий и категорий перед добавлением полностью пользовательского набора данных. Существует перегрузка, позволяющая создать диаграмму без данных по умолчанию.

**Как объекты диаграммы связаны с ячейками рабочей книги?**

Имена серий, метки категорий и значения точек данных ссылаются на ячейки в [ChartDataWorkbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdataworkbook/). Изменение ссылки ячейки обновляет соответствующий элемент диаграммы. При построении пользовательских данных сохраняйте выравнивание строк категорий и строк значений серий, чтобы каждая точка отображалась под нужной категорией.

**Как очистить одну точку, а не всю серию?**

Задайте соответствующей ячейке значение `None`, чтобы сохранить позицию категории точки как пустую. Используйте [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapointcollection/clear/) только когда необходимо удалить все точки из этой серии. Если вы также удаляете категории, обновите каждую серию, чтобы их значения оставались согласованными с коллекцией категорий.

**Как отображаются пустые точки?**

Результат зависит от типа диаграммы и [Chart.display_blanks_as](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/display_blanks_as/). Поддерживаемые диаграммы могут отображать пустоты как пробелы, как нулевые значения или соединять соседние точки. Выберите настройку, соответствующую смыслу отсутствующих данных в вашей презентации.

**Как форматируются отрицательные значения?**

Для поддерживаемых линейных, столбчатых и пузырьковых серий включите [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/invert_if_negative/) и задайте [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Вы можете переопределить поведение для отдельной точки с помощью [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Эти свойства влияют на форматирование, а не на сохранённые числовые значения.

**Какой формат имеет приоритет, когда заданы и серия, и точка?**

Явное форматирование точки имеет приоритет для этой точки. Другие точки продолжают использовать явный формат серии или, если формат серии не определён, автоматический стиль и тему диаграммы. Свойства группы, такие как overlap и gap width, управляют расположением и не являются переопределениями формата точек.

**Есть ли ограничение на количество серий в диаграмме?**

Aspose.Slides не накладывает отдельного фиксированного ограничения на количество серий. На практике ограничения задаются размером файла презентации, доступной памятью, временем рендеринга и читаемостью диаграммы.

**Что изменить, если столбцы слишком близко или слишком далеко друг от друга?**

Установите [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) в соответствующей родительской группе серий. Увеличьте значение, чтобы расширить пространство между кластерами, или уменьшите его, чтобы сблизить кластеры.