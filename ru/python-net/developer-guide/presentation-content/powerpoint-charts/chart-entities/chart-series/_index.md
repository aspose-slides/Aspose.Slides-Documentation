---
title: Управление сериями данных диаграмм в презентациях с Python
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
- зазор серии
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как управлять сериями диаграмм, точками данных, ячейками рабочей книги, форматированием, перекрытием, шириной зазора и отрицательными значениями в презентациях с помощью Python."
---
## **Обзор**

Диаграмма хранит свои отображаемые данные в рабочей книге данных диаграммы. [ChartSeries](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/) представляет один набор связанных значений, и каждый [ChartDataPoint](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapoint/) в серии ссылается на одну или несколько ячеек рабочей книги. Объекты [ChartCategory](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartcategory/) предоставляют подписи или значения группировки, общие для серий. Поэтому имя серии, категории и значения точек связаны с объектами [ChartDataCell](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatacell/), а не хранятся только как отображаемый текст.

Для типичной диаграммы категорий рабочая книга по умолчанию использует строку 0 для имен серий, столбец 0 для имен категорий и остальные ячейки для значений серий. Индексы листа, строки и столбца, передаваемые в [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdataworkbook/get_cell/), являются нулевыми (нумерация с нуля). Такой макет полезен, когда вы создаёте диаграмму с данными по умолчанию, но не следует предполагать, что каждая существующая диаграмма использует его. Для загруженной презентации проверьте ячейки, на которые ссылаются серии, категории и точки данных, прежде чем менять значения в рабочей книге.

Настройки диаграммы имеют три разных уровня:

- Настройки уровня серии, такие как [ChartSeries.format](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/format/), задают внешний вид по умолчанию для всех точек в одной серии.
- Настройки отдельной точки, такие как [ChartDataPoint.format](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapoint/format/), переопределяют внешний вид серии для одной точки.
- Настройки группы применяются к совместимым сериям, принадлежащим одному [ChartSeriesGroup](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseriesgroup/). Доступ к группе осуществляется через [ChartSeries.parent_series_group](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/parent_series_group/), когда необходимо установить параметры, такие как overlap или ширина пробела.

Если явное заполнение точки или серии не задано, стиль и тема диаграммы определяют автоматический внешний вид. Когда присутствует как форматирование серии, так и точки, форматирование точки имеет приоритет для этой точки.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установить перекрытие серий диаграммы**

[ChartSeries.overlap](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/overlap/) показывает, насколько перекрываются столбцы или бары в 2D диаграмме, от -100 до 100 процентов. Это только для чтения проекция настройки в родительской группе серий. Установите [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseriesgroup/overlap/), чтобы обновить каждую совместимую серию в этой группе. Эта опция применяется к типам диаграмм, отображающим сгруппированные бары или столбцы; она не влияет на несвязанные группы серий в комбинированной диаграмме.

Следующий пример устанавливает перекрытие для группы, содержащей первую серию:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Новая диаграмма содержит образцы серий, категорий и значений.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Перекрытие серий](series_overlap.png)

## **Изменить цвет заполнения серии**

Используйте [ChartSeries.format](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/format/) для задания заполнения по умолчанию для всей серии. Если у точки уже задано явное заполнение, её настройка [ChartDataPoint.format](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapoint/format/) переопределяет заполнение серии для этой точки.

Следующий пример задаёт сплошное синее заполнение первой серии:

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

Имя серии хранится в рабочей книге данных диаграммы и обычно отображается в легенде. В рабочей книге по умолчанию, создаваемой для сгруппированной колонной диаграммы, ячейка B1 находится в строке 0, столбце 1 и содержит имя первой серии. Именованные константы в следующем примере делают эту структуру явной:

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

Вы также можете обновить ячейку, уже упомянутую в [ChartSeries.name](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/name/). Такой подход позволяет не полагаться на конкретную строку и столбец в существующей диаграмме:

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

## **Получить автоматический цвет заполнения серии**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) возвращает цвет, вычисленный из индекса серии и стиля диаграммы. Это цвет, используемый, когда заполнение серии не задано явно. Вызов метода лишь считывает вычисленный цвет; он не назначает новое заполнение.

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

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Точные цвета зависят от стиля и темы диаграммы.

## **Установить инвертированный цвет заполнения для серии диаграммы**

Для бар‑, колон­ных и пузырьковых серий [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/invert_if_negative/) может отображать отрицательные значения другим заполнением. Задайте обычное заполнение серии сплошным, включите инверсию и укажите цвет отрицательного значения через [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Отрицательные числа в рабочей книге остаются без изменений; меняется только их цвет отображения.

Следующий пример заменяет данные диаграммы по умолчанию одной серией. Строка 0 листа содержит имя серии, столбец 0 — названия категорий, столбец 1 — значения:

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

![Инвертированный сплошной цвет заполнения](inverted_solid_fill_color.png)

Вы можете включить инверсию для одной точки через [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). В следующем примере инверсия отключена для серии и включена только для выбранной точки. Точке также присвоено отрицательное значение, чтобы эффект был видим:

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

Чтобы сделать одну точку пустой, не удаляя остальные, задайте её ячейке в рабочей книге значение `None`. Для колонной диаграммы отображаемое значение доступно через [ChartDataPoint.value](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapoint/value/). Точка остаётся в той же позиции категории, но диаграмма рассматривает её значение как пустое согласно настройкам отображения пустых значений.

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

Диаграммы рассеяния используют отдельные ячейки X и Y, а пузырьковые также используют ячейку размера. Очищайте только ту ячейку, которая представляет значение, которое вы хотите удалить. Не вызывайте [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapointcollection/clear/), если хотите сохранить остальные точки, потому что этот метод удаляет все точки из коллекции.

## **Управление отображением пустых ячеек**

Скрытые ячейки, содержащие значения, — отдельный случай от пустых ячеек. Чтобы включать или исключать данные из скрытых строк и столбцов листа, смотрите [Include Data from Hidden Rows and Columns](/slides/ru/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Пустая ячейка рабочей книги представляет отсутствие данных; ячейка, содержащая `0`, представляет известное числовое значение. Установите [ChartDataCell.value](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatacell/value/) в `None`, чтобы сделать ячейку пустой. Числовой ноль остаётся нулём независимо от настройки пустой ячейки.

Используйте [Chart.display_blanks_as](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/display_blanks_as/) для выбора способа отображения пустых ячеек. Эта настройка применяется ко всей диаграмме. Она изменяет способ построения пустот, не заполняя пустую ячейку нулём или интерполированным значением.

Следующий самостоятельный пример создаёт линейную диаграмму с одной серией, очищает значение для Дня 3 и сохраняет одну и ту же диаграмму в каждом режиме. Входной файл не требуется. [ChartDataWorkbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdataworkbook/) использует лист 0, столбец 0 для меток категорий и столбец 1 для значений; строка 0 содержит имя серии. Итоговые данные: `10, 20, empty, 30, 40`.

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

    # Оставьте день 3 действительно пустым, при этом сохранив его категорию и точку данных.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Каждый выходной файл сохраняет режим, указанный перед сохранением: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` и `empty_cells_Span.pptx`. Чтобы сохранить только одну версию, задайте нужный режим и сохраните презентацию один раз вместо перебора режимов.

Сравнение ниже показывает одинаковые данные во всех трех файлах. День 3 пустой в рабочей книге во всех случаях:

![Линейные диаграммы с одинаковыми данными: Gap разрывает линию на День 3, Zero опускает линию до нуля, а Span соединяет День 2 с Днем 4.](display_blanks_as.png)

Видимый эффект зависит от типа диаграммы. Линейная диаграмма позволяет легко сравнивать все три режима. Для бар‑ и колонных диаграмм нет линии, соединяющей категории, поэтому `SPAN` не может создать показанный выше соединительный сегмент; колонка, находящаяся в отсутствии, и колонка нулевой высоты могут выглядеть одинаково. Аналогично, в диаграмме рассеяния только с маркерами нет соединительной линии. Не ожидайте трёх разных результатов для каждого типа диаграммы; проверьте вывод для используемого типа.

## **Установить ширину зазора между сериями**

Ширина зазора — это пространство между соседними кластерами баров или колонн, выраженное в процентах от ширины бара или колонки. Как и overlap, она относится к родительской группе серий, а не к отдельной серии. Установите [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) один раз для группы. Большое значение создаёт больший промежуток между кластерами; меньшее — делает их плотнее.

Следующий пример изменяет ширину зазора и сохраняет только итоговую презентацию:

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

![Ширина зазора](gap_width.png)

## **FAQ**

**Какие типы диаграмм поддерживают серии данных?**

Все типы диаграмм, перечисленные в перечислении [ChartType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/charttype/), используют данные диаграммы, но их серии не имеют одинаковой структуры значений или настроек. Например, диаграммы категорий используют категории и значения, диаграммы рассеяния — X и Y, а пузырьковые — дополнительно размеры пузырей. Используйте метод создания точек данных, соответствующий типу серии. Параметры, такие как overlap и gap width, применимы только к совместимым группам баров или колонн.

**Что такое группа серий диаграммы?**

[ChartSeriesGroup](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseriesgroup/) содержит совместимые серии, которые разделяют настройки уровня группы. Комбинированная диаграмма может включать более одной группы, поэтому изменение группы через одну серию не обязательно меняет все серии в диаграмме.

**Создаётся ли в новой диаграмме набор данных по умолчанию?**

Да. По умолчанию [ShapeCollection.add_chart](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/add_chart/) создаёт примерные серии, категории и значения. Вы можете отредактировать эти ячейки или очистить обе коллекции серий и категорий перед добавлением полностью пользовательского набора данных. Существует перегрузка, позволяющая создать диаграмму без данных по умолчанию.

**Как объекты диаграмм связаны с ячейками рабочей книги?**

Имена серий, подписи категорий и значения точек данных ссылаются на ячейки в [ChartDataWorkbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdataworkbook/). Изменение ячейки, на которую ссылается элемент, обновляет соответствующий элемент диаграммы. При построении пользовательских данных держите строки категорий и строки значений серий согласованными, чтобы каждая точка отображалась под нужной категорией.

**Как очистить одну точку вместо всей серии?**

Установите соответствующую ячейку значения в `None`, чтобы сохранить позицию категории точки как пустой. Используйте [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapointcollection/clear/) только когда необходимо удалить все точки из этой серии. Если вы также удаляете категории, обновите каждую серию, чтобы их значения оставались согласованными с коллекцией категорий.

**Как отображаются пустые точки?**

Результат зависит от типа диаграммы и [Chart.display_blanks_as](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/display_blanks_as/). Поддерживаемые диаграммы могут показывать пустоты как разрывы, как нули или соединяя соседние точки. Выберите настройку, соответствующую смыслу отсутствующих данных в вашей презентации. См. раздел **Управление отображением пустых ячеек** для полного примера и визуального сравнения.

**Как форматировать отрицательные значения?**

Для поддерживаемых бар‑, колонных и пузырьковых серий включите [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/invert_if_negative/) и задайте [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Поведение отдельной точки можно переопределить с помощью [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Эти свойства влияют только на форматирование, а не на хранимые числовые значения.

**Какая форматировка имеет приоритет, когда задана и серия, и точка?**

Явное форматирование отдельной точки имеет приоритет для этой точки. Другие точки продолжают использовать явный формат серии или, если формат серии не определён, автоматический стиль и тему диаграммы. Свойства группы, такие как overlap и gap width, управляют расположением и не являются переопределениями формата уровня точки.

**Существует ли ограничение на количество серий в диаграмме?**

Aspose.Slides не накладывает отдельного фиксированного ограничения на количество серий. На практике ограничения файлов презентации, доступная память, время рендеринга и читаемость диаграммы определяют практический предел.

**Что изменить, если столбцы находятся слишком близко друг к другу или слишком далеко?**

Установите [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) в соответствующей родительской группе серий. Увеличьте значение, чтобы расширить пространство между кластерами, или уменьшите его, чтобы собрать кластеры ближе друг к другу.