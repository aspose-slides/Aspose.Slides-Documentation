---
title: Управление данными серии диаграммы в презентациях на Python
linktitle: Серии данных
type: docs
url: /ru/python-net/chart-series/
keywords:
- серия диаграммы
- перекрытие серий
- цвет серии
- цвет категории
- имя серии
- точка данных
- промежуток серии
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как управлять сериями диаграмм, точками данных, ячейками рабочей книги, форматированием, перекрытием, шириной промежутка и отрицательными значениями в презентациях с помощью Python."
---
## **Обзор**

Диаграмма может хранить построенные значения в ячейках рабочей книги или напрямую как числовые литералы. [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) представляет один набор связанных значений, а каждый [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) представляет точку в этом наборе. Объекты [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) предоставляют метки или значения группировки, общие для серий. В диаграммах, созданных с данными по умолчанию, имена серий, категории и значения точек используют объекты [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) из рабочей книги диаграммы.

Для типичной диаграммы категории рабочая книга по умолчанию использует строку 0 для имён серий, столбец 0 для имён категорий и остальные ячейки — для значений серий. Индексы листа, строки и столбца, передаваемые в [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/), начинаются с 0. Такая компоновка полезна, когда вы создаёте диаграмму с данными по умолчанию, но не следует предполагать, что каждый существующий график использует её. Для загруженной презентации проверьте ячейки, на которые ссылаются серии, категории и точки данных, перед изменением значений в рабочей книге.

Настройки диаграммы имеют три разных уровня:

- Настройки уровня серии, такие как [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/), задают внешний вид по умолчанию для всех точек в одной серии.
- Настройки отдельной точки, такие как [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/), переопределяют внешний вид серии для одной точки.
- Настройки группы применяются к совместимым сериям, принадлежащим одному [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/). Доступ к группе осуществляется через [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/), когда требуется задать параметры, такие как перекрытие или ширина промежутка.

Если явное заполнение точки или серии не задано, стиль и тема диаграммы определяют автоматический внешний вид. Когда присутствуют и формат серии, и формат точки, приоритет имеет формат точки.

![серия графика powerpoint](chart-series-powerpoint.png)

## **Установка значений серии с использованием числовых литералов**

Используйте числовые литералы, когда значения серии берутся из данных приложения или вычислений и не требуют ссылок на ячейки листа. Установите [data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/) в значение [DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) перед присвоением каждой точке её [value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) через [as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/).

Настройка коллекции управляет типом источника всех значений точек в этой серии. Свойство [value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/) каждой точки показывает выбранный тип; измените его через настройку коллекции. При типе `WORKSHEET` используйте [as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/) для доступа к ссылочной ячейке. При типе `DOUBLE_LITERALS` используйте `as_literal_double` для прямого чтения или записи числа.

В следующем примере создаётся столбчатая диаграмма с серией и категориями по умолчанию, затем вычисленные значения 10, 20 и т.д. назначаются существующим точкам первой серии. Презентация сохраняется, затем открывается вновь, и выводятся сохранённые значения.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    series = chart.chart_data.series[0]

    series.data_points.data_source_type_for_values = charts.DataSourceType.DOUBLE_LITERALS
    for i in range(len(series.data_points)):
        series.data_points[i].value.as_literal_double = (i + 1) * 10

    presentation.save("numeric_literals.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("numeric_literals.pptx") as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_chart = reopened_slide.shapes[0]
    reopened_series = reopened_chart.chart_data.series[0]
    for point in reopened_series.data_points:
        print(point.value.as_literal_double)
```

Тип источника значения точки отдельно от [ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/), который определяет конфигурацию внутренней или внешней рабочей книги диаграммы. Использование числовых литералов само по себе не удаляет встроенную рабочую книгу. В данном примере рабочая книга остаётся доступной для меток категорий, имён серий и остальных серий. См. [Chart Workbook](/slides/ru/python-net/chart-workbook/) для управления рабочей книгой.

Для точечных и пузырьковых диаграмм установите [data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/) и [data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/) в нужный тип, чтобы выбрать источники для [x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/) и [y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/). Пузырьковые диаграммы также используют [data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/) для [bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/). Установите каждый применимый источник в `DOUBLE_LITERALS` перед присвоением чисел через свойство `as_literal_double`.

## **Установка перекрытия серий диаграммы**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) показывает, насколько столбцы или бары перекрываются в 2‑D диаграмме, от -100 до 100 процентов. Это только доступное для чтения отображение параметра в родительской группе серий. Установите [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) для обновления всех совместимых серий в этой группе. Эта опция применяется к типам диаграмм, отображающим сгруппированные столбцы или бары; она не влияет на несвязанные группы серий в комбинированных диаграммах.

В следующем примере задаётся перекрытие для группы, содержащей первую серию:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Новая диаграмма содержит примерные серии, категории и значения.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![перекрытие серий](series_overlap.png)

## **Изменение цвета заливки серии**

Используйте [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) для задания заливки по умолчанию для всей серии. Если у точки уже задана явная заливка, её настройка [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) переопределяет заливку серии для этой точки.

В следующем примере к первой серии применяется сплошная синяя заливка:

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

![цвет серии](series_color.png)

## **Изменение имени серии**

Имя серии хранится в рабочей книге диаграммы и обычно отображается в легенде. В рабочей книге по умолчанию для сгруппированной столбчатой диаграммы ячейка B1 находится в строке 0, столбце 1 и содержит имя первой серии. Именованные константы в следующем примере делают эту структуру явной:

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

Вы также можете обновить ячейку, уже использованную в [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/). Этот подход избавляет от предположений о конкретных строках и столбцах в существующей диаграмме:

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

![имя серии](series_name.png)

### **Создание серии с именем из нескольких ячеек**

Составное имя серии удобно, когда название продукта и отчётный период хранятся в разных ячейках рабочей книги. Например, можно объединить `Product A` из B1 и `2026` из C1 в одно имя серии, при этом обе части остаются привязанными к своим ячейкам‑источникам.

Используйте [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) для получения диапазона имён, затем передайте эту коллекцию в [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/). Параметр `skip_hidden_cells` управляет включением скрытых ячеек: `True` исключает их, `False` — включает. В примере используется `False`, чтобы включить каждую ячейку в диапазоне имён.

В следующем примере создаётся презентация с одной серией и двумя точками данных. Диапазон B1:C1 содержит только имя серии; A2:A3 — метки категорий, а B2:B3 — числовые значения.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 620, 180)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = True

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Эти две ячейки предоставляют имя серии.
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    # Отдельные ячейки предоставляют категории и числовые точки данных.
    north_category = workbook.get_cell(0, 1, 0, "North")
    south_category = workbook.get_cell(0, 2, 0, "South")
    chart.chart_data.categories.add(north_category)
    chart.chart_data.categories.add(south_category)
    north_value = workbook.get_cell(0, 1, 1, 120)
    south_value = workbook.get_cell(0, 2, 1, 150)
    series.data_points.add_data_point_for_bar_series(north_value)
    series.data_points.add_data_point_for_bar_series(south_value)

    presentation.save("composite_series_name.pptx", slides.export.SaveFormat.PPTX)
```

Полученное имя серии — `Product A 2026`, между двумя значениями ячеек вставлен пробел. Легенда отображает его как одну запись для обеих колонок. Ниже изображение, полученное из сохранённой презентации:

![Столбчатая диаграмма с северными и южными значениями и составным именем серии Product A 2026 в легенде](composite_series_name.png)

## **Получение автоматического цвета заливки серии**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) возвращает цвет, вычисленный из индекса серии и стиля диаграммы. Это цвет, который используется, когда заливка серии явно не задана. Вызов метода только читает вычисленный цвет; он не задаёт новую заливку.

В следующем примере выводится автоматический цвет каждой серии по умолчанию:

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

## **Установка инверсии цвета заливки для серии диаграммы**

Для серий баров, столбцов и пузырьков [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) позволяет отображать отрицательные значения другим цветом. Установите обычную заливку серии в сплошную, включите инверсию и задайте цвет для отрицательных значений через [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Отрицательные числа в рабочей книге остаются без изменений; меняется только их цвет отображения.

В следующем примере заменяются данные диаграммы на одну серию. Строка 0 листа содержит имя серии, столбец 0 — имена категорий, столбец 1 — значения:

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

![инвертированный сплошной цвет заливки](inverted_solid_fill_color.png)

Вы можете включить инверсию для одной точки через [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). В следующем примере инверсия отключена для серии и включена только для выбранной точки. Точке также присваивается отрицательное значение, чтобы эффект был виден:

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

## **Очистка конкретного значения точки данных**

Чтобы сделать одну точку пустой, не удаляя остальные, задайте её ячейке в рабочей книге значение `None`. Для столбчатой диаграммы построенное значение доступно через [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/). Точка остаётся на той же позиции категории, но диаграмма рассматривает её значение как пустое в соответствии с настройками отображения пустых значений.

В следующем примере очищается только вторая точка первой серии:

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

Точечные диаграммы используют отдельные ячейки X и Y, а пузырьковые — также ячейку размера. Очищайте только ту ячейку, которая представляет значение, которое вы хотите удалить. Не вызывайте [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) если хотите сохранить остальные точки, поскольку этот метод удаляет все точки из коллекции.

## **Управление отображением пустых ячеек**

Скрытые ячейки, содержащие значения, — отдельный случай от пустых ячеек. Чтобы включать или исключать данные из скрытых строк и столбцов листа, см. [Include Data from Hidden Rows and Columns](/slides/ru/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Пустая ячейка рабочей книги представляет отсутствие данных; ячейка, содержащая `0`, представляет известное числовое значение. Установите [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) в `None`, чтобы сделать ячейку пустой. Числовой ноль остаётся нулём независимо от настройки пустой ячейки.

Используйте [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) для выбора способа отображения пустых ячеек в диаграмме. Эта настройка применяется ко всей диаграмме. Она изменяет способ построения пробелов без заполнения пустой ячейки нулём или интерполированным значением.

В следующем самодостаточном примере создаётся линейная диаграмма с одной серией, очищается значение для 3‑го дня и сохраняется диаграмма в каждом режиме. Входной файл не требуется. [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) использует лист 0, столбец 0 для меток категорий и столбец 1 для значений; строка 0 содержит имя серии. Итоговые данные: `10, 20, empty, 30, 40`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 40, 40, 640, 400)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(0, 0, 1, "Measurements")
    series = chart_data.series.add(series_name_cell, chart.type)
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Оставить 3‑й день действительно пустым, сохраняя его категорию и точку данных.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Каждый выходной файл сохраняет режим, выбранный перед сохранением: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` и `empty_cells_Span.pptx`. Чтобы сохранить только одну версию, задайте нужный режим и сохраните презентацию один раз вместо перебора режимов.

Сравнение ниже показывает одинаковые данные во всех трёх файлах. День 3 пуст в рабочей книге во всех случаях:

![Линейные диаграммы с одинаковыми данными: Gap разрывает линию в День 3, Zero опускает линию до нуля, а Span соединяет День 2 с Днём 4.](display_blanks_as.png)

Видимый эффект зависит от типа диаграммы. Линейная диаграмма позволяет легко сравнивать все три режима. У столбчатых и баровых диаграмм нет линии, соединяющей пропущенную категорию, поэтому `SPAN` не может создать соединительный сегмент, показанный выше; отсутствующий столбец и столбец нулевой высоты могут выглядеть одинаково. Аналогично, точечная диаграмма только с маркерами не имеет соединяющей линии. Не ожидайте три разных результата для каждого типа диаграммы; проверьте вывод для используемого типа.

## **Установка ширины промежутка между сериями**

Ширина промежутка — это пространство между соседними кластерами столбцов или баров, выраженное в процентах от ширины столбца или бара. Как и перекрытие, она относится к родительской группе серий, а не к отдельной серии. Установите [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) один раз для группы. Большое значение создаёт больше пространства между кластерами; меньшее — делает их плотнее.

В следующем примере изменяется ширина промежутка и сохраняется только финальная презентация:

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

![ширина промежутка](gap_width.png)

## **FAQ**

**Какие типы диаграмм поддерживают серии данных?**

Все типы диаграмм, представленные перечислением [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/), используют данные диаграммы, но их серии не всегда имеют одинаковую структуру значений или параметры. Например, диаграммы категорий используют категории и значения, точечные — X и Y, а пузырьковые добавляют размеры пузырей. Используйте метод создания точек, соответствующий типу серии. Такие параметры, как перекрытие и ширина промежутка, применимы только к совместимым группам баров или столбцов.

**Что такое группа серий диаграммы?**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) содержит совместимые серии, которые разделяют параметры построения на уровне группы. Комбинированная диаграмма может содержать более одной группы, поэтому изменение группы, полученной через одну серию, не обязательно изменит все серии в диаграмме.

**Создана ли новая диаграмма с данными по умолчанию?**

Да. По умолчанию [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) создаёт примерные серии, категории и значения. Вы можете изменить эти ячейки или полностью очистить коллекции серий и категорий перед добавлением полностью пользовательского набора данных. Существует перегрузка, позволяющая создать диаграмму без данных по умолчанию.

**Как объекты диаграммы связаны с ячейками рабочей книги?**

Имена серий, метки категорий и значения точек данных ссылаются на ячейки в [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/). Изменение ячейки‑источника обновляет соответствующий элемент диаграммы. При построении пользовательских данных поддерживайте выравнивание строк категорий и строк значений серий, чтобы каждая точка отображалась под нужной категорией.

**Как очистить одну точку, а не всю серию?**

Установите ячейку соответствующего значения в `None`, чтобы точка осталась на своей позиции категории как пустая. Используйте [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) только когда хотите удалить все точки из серии. Если также удаляете категории, обновите каждую серию, чтобы её значения оставались выровненными с коллекцией категорий.

**Как отображаются пустые точки?**

Результат зависит от типа диаграммы и настройки [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/). Поддерживаемые диаграммы могут отображать пробелы, нулевые значения или соединять соседние точки. Выберите настройку, соответствующую смыслу отсутствующих данных в вашей презентации. См. раздел [Управление отображением пустых ячеек](#control-the-display-of-empty-cells) для полного примера и сравнения.

**Как форматируются отрицательные значения?**

Для поддерживаемых баровых, столбчатых и пузырьковых серий включите [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) и задайте [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Поведение для отдельной точки можно переопределить через [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Эти свойства влияют только на форматирование, а не на сохранённые числовые значения.

**Какой формат имеет приоритет, если и серия, и точка отформатированы?**

Явное форматирование точки имеет приоритет для этой точки. Остальные точки продолжают использовать явный формат серии или, если формат серии не определён, автоматический стиль и тему диаграммы. Групповые свойства, такие как перекрытие и ширина промежутка, управляют макетом и не являются переопределениями формата на уровне точки.

**Есть ли ограничение на количество серий в диаграмме?**

Aspose.Slides не вводит отдельного фиксированного ограничения количества серий. На практике ограничение определяется ограничениями файлов презентаций, доступной памятью, временем рендеринга и пригодностью диаграммы для восприятия.

**Что изменить, если столбцы слишком близко либо слишком далеко друг от друга?**

Установите [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) в соответствующей родительской группе серий. Увеличьте значение, чтобы расширить пространство между кластерами, или уменьшите, чтобы сблизить их.