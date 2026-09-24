---
title: Управление данными серий диаграмм в презентациях на Python
linktitle: Серии данных
type: docs
url: /ru/python-net/chart-series/
keywords:
- серии диаграмм
- перекрытие серий
- цвет серии
- цвет категории
- имя серии
- точка данных
- интервал серии
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как управлять сериями диаграмм, точками данных, ячейками рабочей книги, форматированием, перекрытием, шириной промежутка и отрицательными значениями в презентациях с помощью Python."
---
## **Обзор**

Диаграмма хранит свои построенные данные в рабочей книге данных диаграммы. [ChartSeries](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/) представляет один набор связанных значений, и каждый [ChartDataPoint](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapoint/) в серии ссылается на одну или несколько ячеек рабочей книги. Объекты [ChartCategory](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartcategory/) предоставляют метки или значения группировки, общие для серий. Поэтому имя серии, категории и значения точек соединены с объектами [ChartDataCell](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatacell/), а не хранятся только как отображаемый текст.

Для типичной диаграммы категорий рабочая книга по умолчанию использует строку 0 для имен серий, столбец 0 для имен категорий и оставшиеся ячейки для значений серий. Индексы листа, строки и столбца, передаваемые в [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdataworkbook/get_cell/), нумеруются с нуля. Такое расположение удобно, когда вы создаёте диаграмму с данными по умолчанию, но не следует предполагать, что каждая существующая диаграмма использует его. Для загруженной презентации проверьте ячейки, на которые ссылаются серии, категории и точки данных, прежде чем изменять значения в рабочей книге.

Настройки диаграммы имеют три разных уровня:

- Настройки уровня серии, такие как [ChartSeries.format](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/format/), определяют внешний вид по умолчанию для всех точек в одной серии.
- Настройки точки данных, такие как [ChartDataPoint.format](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapoint/format/), переопределяют внешний вид серии для отдельной точки.
- Настройки группы применяются к совместимым сериям, принадлежащим одному [ChartSeriesGroup](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseriesgroup/). Доступ к группе осуществляется через [ChartSeries.parent_series_group](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/parent_series_group/), когда необходимо задать такие параметры, как перекрытие или ширина промежутка.

Когда явная заливка точки или серии не задана, стиль диаграммы и тема определяют автоматический внешний вид. Когда присутствует как форматирование серии, так и точки, форматирование точки имеет приоритет для этой точки.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установить перекрытие серии диаграммы**

[ChartSeries.overlap](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/overlap/) сообщает, насколько бар‑и или столбцы перекрываются в 2‑D диаграмме, в диапазоне от -100 до 100 процентов. Это только чтение проекции настройки в родительской группе серий. Установите [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseriesgroup/overlap/), чтобы обновить каждую совместимую серию в этой группе. Эта опция применяется к типам диаграмм, отображающим сгруппированные бары или столбцы; она не влияет на несвязанные группы серий в комбинированной диаграмме.

Следующий пример задаёт перекрытие для группы, содержащей первую серию:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Новая диаграмма содержит образцовые серии, категории и значения.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![The series overlap](series_overlap.png)

## **Изменить цвет заливки серии**

Используйте [ChartSeries.format](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/format/) для задания заливки по умолчанию для всей серии. Если у точки уже задана явная заливка, её настройка [ChartDataPoint.format](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapoint/format/) переопределяет заливку серии для этой точки.

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

![The color of the series](series_color.png)

## **Изменить имя серии**

Имя серии хранится в рабочей книге данных диаграммы и обычно отображается в легенде. В рабочей книге по умолчанию для объединённой столбчатой диаграммы ячейка B1 находится в строке 0, столбце 1 и содержит имя первой серии. Именованные константы в следующем примере делают эту структуру явной:

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

Вы также можете обновить ячейку, уже используемую свойством [ChartSeries.name](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/name/). Этот подход избегает предположений о конкретных строке и столбце в существующей диаграмме:

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

![The series name](series_name.png)

## **Получить автоматический цвет заливки серии**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) возвращает цвет, вычисленный на основе индекса серии и стиля диаграммы. Это тот цвет, который используется, когда заливка серии не была явно определена. Вызов метода только считывает вычисленный цвет; он не назначает новую заливку.

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

Для бар‑, столбцовых и пузырьковых серий [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/invert_if_negative/) может отображать отрицательные значения другой заливкой. Установите обычную заливку серии как сплошную, включите инверсию и задайте цвет отрицательного значения через [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Отрицательные числа остаются неизменными в рабочей книге; меняется только их цвет отображения.

Следующий пример заменяет данные диаграммы по умолчанию одной серией. Строка 0 листа содержит имя серии, столбец 0 — имена категорий, столбец 1 — значения:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

Вы можете включить инверсию для отдельной точки через [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). В следующем примере инверсия отключена для серии и включена только для выбранной точки. Точке также присвоено отрицательное значение, чтобы эффект был виден:

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

## **Очистить конкретное значение точки данных**

Чтобы сделать одну точку пустой, не удаляя остальные, задайте её ячейку в рабочей книге значением `None`. Для столбчатой диаграммы отображаемое значение доступно через [ChartDataPoint.value](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapoint/value/). Точка данных остаётся в той же позиции категории, но диаграмма рассматривает её значение как пустое в соответствии с настройками пустых значений диаграммы.

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

Диаграммы рассеяния используют отдельные ячейки X и Y, а пузырьковые диаграммы — также ячейку размера. Очистите только ту ячейку, которая представляет значение, которое вы хотите удалить. Не вызывайте [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapointcollection/clear/), если хотите оставить остальные точки, поскольку этот метод удаляет все точки из коллекции.

## **Управление отображением пустых ячеек**

Пустая ячейка в рабочей книге представляет отсутствие данных; ячейка, содержащая `0`, представляет известное числовое значение. Установите [ChartDataCell.value](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatacell/value/) в `None`, чтобы сделать ячейку пустой. Числовой ноль остаётся нулём независимо от настройки пустой ячейки.

Используйте [Chart.display_blanks_as](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/display_blanks_as/), чтобы выбрать способ отображения пустых ячеек диаграммой. Эта настройка применяется ко всей диаграмме. Она меняет способ построения пустых участков, не заполняя пустую ячейку нулём или интерполированным значением.

Следующий автономный пример создаёт линейную диаграмму с одной серией, очищает значение для Дня 3 и сохраняет одну и ту же диаграмму в каждом режиме. Входного файла не требуется. [ChartDataWorkbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdataworkbook/) использует лист 0, столбец 0 для меток категорий и столбец 1 для значений; строка 0 хранит имя серии. Итоговые данные: `10, 20, empty, 30, 40`.

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

    # Оставьте день 3 действительно пустым, сохранив его категорию и точку данных.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Каждый выходной файл сохраняет выбранный режим: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` и `empty_cells_Span.pptx`. Чтобы сохранить только одну версию, задайте нужный режим и сохраните презентацию один раз вместо перебора режимов.

Сравнение ниже показывает одни и те же данные во всех трёх файлах. День 3 пуст в рабочей книге во всех случаях:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Видимый эффект зависит от типа диаграммы. Линейная диаграмма позволяет легко сравнить все три режима. Бар‑ и столбцовые диаграммы не имеют линии, соединяющей пропущенную категорию, поэтому `SPAN` не может создать соединительный сегмент, показанный выше; отсутствующий столбец и столбец нулевой высоты могут выглядеть одинаково. Аналогично, диаграмма рассеяния только с маркерами не имеет соединительной линии. Не ожидайте трёх разных результатов для каждой диаграммы; проверьте вывод для используемого типа.

## **Установить ширину промежутка между сериями**

Ширина промежутка — это расстояние между соседними кластерами баров или столбцов, выраженное в процентах от ширины бара или столбца. Как и перекрытие, она относится к родительской группе серий, а не к отдельной серии. Установите [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) один раз для группы. Большее значение создаёт больше пространства между кластерами; меньшее значение делает их плотнее.

Следующий пример меняет ширину промежутка и сохраняет только окончательную презентацию:

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

![The gap width](gap_width.png)

## **FAQ**

**Какие типы диаграмм поддерживают данные серии?**

Все типы диаграмм, представленные перечислением [ChartType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/charttype/), используют данные диаграммы, но их серии не имеют одинаковой структуры значений или настроек. Например, диаграммы категорий используют категории и значения, диаграммы рассеяния — значения X и Y, а пузырьковые диаграммы добавляют размеры пузырей. Используйте метод создания точек данных, соответствующий типу серии. Параметры, такие как перекрытие и ширина промежутка, применимы только к совместимым группам баров или столбцов.

**Что такое группа серий диаграммы?**

[ChartSeriesGroup](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseriesgroup/) содержит совместимые серии, которые разделяют настройки уровня группы. Комбинированная диаграмма может содержать более одной группы, поэтому изменение группы через одну серию не обязательно меняет все серии в диаграмме.

**Создаёт ли новая диаграмма данные по умолчанию?**

Да. По умолчанию [ShapeCollection.add_chart](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/add_chart/) создаёт образцовые серии, категории и значения. Вы можете отредактировать эти ячейки или очистить обе коллекции (серий и категорий) перед добавлением полностью пользовательского набора данных. Существует перегрузка, которая также может создать диаграмму без данных по умолчанию.

**Как объекты диаграммы соединены с ячейками рабочей книги?**

Имена серий, метки категорий и значения точек данных ссылаются на ячейки в [ChartDataWorkbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdataworkbook/). Изменение ссылки ячейки обновляет соответствующий элемент диаграммы. При построении пользовательских данных сохраняйте выравнивание строк категорий и строк значений серий, чтобы каждая точка отображалась под нужной категорией.

**Как очистить одну точку, а не всю серию?**

Установите соответствующую ячейку значения в `None`, чтобы сохранить позицию категории точки как пустой. Используйте [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapointcollection/clear/) только когда хотите удалить все точки из серии. Если вы также удаляете категории, обновите каждую серию, чтобы их значения оставались согласованными с коллекцией категорий.

**Как отображаются пустые точки?**

Результат зависит от типа диаграммы и [Chart.display_blanks_as](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/display_blanks_as/). Поддерживаемые диаграммы могут отображать пустоты как разрывы, как нулевые значения или соединяя соседние точки. Выберите настройку, соответствующую смыслу отсутствующих данных в вашей презентации. См. раздел **Управление отображением пустых ячеек** для полного примера и визуального сравнения.

**Как форматировать отрицательные значения?**

Для поддерживаемых бар‑, столбцовых и пузырьковых серий включите [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/invert_if_negative/) и задайте [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Поведение отдельной точки можно переопределить через [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Эти свойства влияют на форматирование, а не на хранимые числовые значения.

**Какой формат имеет приоритет, когда и серия, и точка отформатированы?**

Явное форматирование точек данных имеет приоритет для этой точки. Другие точки продолжают использовать явный формат серии или, если формат серии не задан, автоматический стиль и тему диаграммы. Свойства группы, такие как перекрытие и ширина промежутка, управляют раскладкой и не являются переопределяющими параметрами формата точек.

**Есть ли ограничение на количество серий в диаграмме?**

Aspose.Slides не накладывает отдельного фиксированного ограничения на количество серий. На практике ограничения определяются размером файла презентации, доступной памятью, временем рендеринга и читаемостью диаграммы.

**Что менять, когда столбцы слишком близко или слишком далеко друг от друга?**

Установите [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) в соответствующей родительской группе серий. Увеличьте значение, чтобы расширить промежуток между кластерами, или уменьшите его, чтобы собрать кластеры ближе.