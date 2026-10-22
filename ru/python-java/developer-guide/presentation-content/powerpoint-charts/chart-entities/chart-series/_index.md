---
title: Управление данными серии диаграммы в презентациях на Python
linktitle: Серии данных
type: docs
url: /ru/python-java/chart-series/
keywords:
- серии диаграмм
- перекрытие серии
- цвет серии
- имя серии
- точка данных
- ячейка рабочей книги
- промежуток серии
- отрицательное значение
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как управлять сериями диаграмм, точками данных, ячейками рабочей книги, форматированием, перекрытием, шириной промежутка и отрицательными значениями в презентациях с Aspose.Slides для Python через Java."
---
## **Обзор**

Диаграмма может хранить построенные значения в ячейках рабочей книги или непосредственно как числовые литералы. [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) представляет один набор связанных значений, а каждый [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) представляет точку в этом наборе. Объекты [ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) предоставляют метки или значения группировки, общие для серии. В диаграммах, созданных с данными по умолчанию, имена серий, категории и значения точек используют объекты [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) из рабочей книги диаграммы.

Для типичной диаграммы категорий рабочая книга по умолчанию использует строку 0 для имён серий, столбец 0 для имён категорий и остальные ячейки для значений серий. Индексы листа, строки и столбца, передаваемые в [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell), начинаются с нуля. Такой макет полезен при создании диаграммы с данными по умолчанию, но не следует полагать, что каждый существующий график использует его. Для загруженной презентации проверьте ячейки, на которые ссылаются серии, категории и точки данных, перед изменением значений в рабочей книге.

Настройки диаграммы имеют три разных уровня:

- Настройки уровня серии, такие как [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat), задают оформление по умолчанию для всех точек в одной серии.
- Настройки точек данных, такие как [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat), переопределяют оформление серии для отдельной точки.
- Настройки группы применяются к совместимым сериям, принадлежащим одному [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/). Доступ к группе осуществляется через [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup), когда требуется задать параметры, такие как перекрытие или ширина промежутка.

Когда явное заполнение точки или серии не задано, стиль и тема диаграммы определяют автоматическое оформление. Если присутствует как оформление серии, так и точек, оформление точек имеет приоритет для соответствующей точки.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установка значений серии с помощью числовых литералов**

Используйте числовые литералы, когда значения серии берутся из данных приложения или вычислений и не требуют ссылок на ячейки листа. Вызовите [setDataSourceTypeForValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForValues) с параметром [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/#DoubleLiterals) перед назначением результата [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) каждой точки через [setAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#setAsLiteralDouble).

Параметр коллекции управляет типом источника всех значений точек в этой серии. Метод [getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/basechartvalue/#getDataSourceType) каждой точки сообщает выбранный тип; изменить его можно через параметр коллекции. При работе с `Worksheet` используйте [getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsCell) для доступа к ячейке. При работе с `DoubleLiterals` используйте [getAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsLiteralDouble) или `setAsLiteralDouble` для чтения или записи числа напрямую.

Следующий пример создаёт столбчатую диаграмму с сериями и категориями по умолчанию, затем назначает вычисленные значения 10, 20 и так далее существующим точкам первой серии. Пример сохраняет презентацию, открывает её снова и выводит сохранённые значения.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals)
    for i in range(series.getDataPoints().size()):
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10)

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("numeric_literals.pptx")
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_chart = reopened_slide.getShapes().get_Item(0)
    reopened_series = reopened_chart.getChartData().getSeries().get_Item(0)
    for point in reopened_series.getDataPoints():
        print(point.getValue().getAsLiteralDouble())
finally:
    reopened_presentation.dispose()
```

Тип источника значения точки отличается от [ChartData.getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType), который определяет конфигурацию внутренней или внешней рабочей книги диаграммы. Использование числовых литералов само по себе не удаляет встроенную рабочую книгу. В данном примере рабочая книга остаётся доступной для меток категорий, имён серий и остальных серий. См. [Chart Workbook](/slides/ru/python-java/chart-workbook/) для управления рабочими книгами.

Для диаграмм разброса и пузырей используйте [setDataSourceTypeForXValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForXValues) и [setDataSourceTypeForYValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForYValues), чтобы выбрать источники для [getXValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getXValue) и [getYValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getYValue). Диаграммы‑пузыри также используют [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForBubbleSizes) для [getBubbleSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getBubbleSize). Установите каждый применимый источник в `DoubleLiterals` перед назначением чисел через метод `setAsLiteralDouble`.

## **Установка перекрытия серии диаграммы**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) сообщает, насколько бары или столбцы перекрываются в 2‑D диаграмме, от -100 до 100 процентов. Это только чтение проекции настройки группы родительской серии. Используйте [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap), чтобы обновить все совместимые серии в этой группе. Эта опция применяется к типам диаграмм, отображающим сгруппированные бары или столбцы; она не влияет на несвязанные группы серий в комбинированной диаграмме.

Следующий пример задаёт перекрытие для группы, содержащей первую серию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # Новая диаграмма содержит образцовые серии, категории и значения.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![The series overlap](series_overlap.png)

## **Изменение цвета заливки серии**

Используйте [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat), чтобы задать заливку по умолчанию для всей серии. Если у точки уже задана явная заливка, её настройка [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) переопределяет заливку серии для этой точки.

Следующий пример применяет сплошную синюю заливку к первой серии:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![The color of the series](series_color.png)

## **Изменение имени серии**

Имя серии хранится в рабочей книге данных диаграммы и обычно отображается в легенде. В рабочей книге по умолчанию, созданной для кластеризованной столбчатой диаграммы, ячейка B1 находится в строке 0, столбце 1 и содержит имя первой серии. Именованные переменные в следующем примере делают эту структуру явной:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Вы также можете обновить уже используемую ячейку через [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName). Такой подход позволяет избежать предположений о конкретных строке и столбце в существующей диаграмме:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![The series name](series_name.png)

### **Создание серии с именем из нескольких ячеек**

Составное имя серии полезно, когда название продукта и отчётный период хранятся в разных ячейках рабочей книги. Например, вы можете объединить `Product A` в B1 и `2026` в C1 в одно имя серии, при этом обе части остаются связанными со своими исходными ячейками.

Используйте [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection), чтобы получить диапазон имён, а затем передайте эту коллекцию в [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add). Параметр `skipHiddenCells` управляет включением скрытых ячеек: `True` исключает их, `False` включает. В примере используется `False`, чтобы включить каждую ячейку в диапазоне имён.

Следующий пример создаёт презентацию с одной серией и двумя точками данных. Ячейки B1:C1 содержат только имя серии; A2:A3 — метки категорий, B2:B3 — числовые значения.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # Эти две ячейки задают имя серии.
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # Отдельные ячейки задают категории и числовые точки данных.
    north_category = workbook.getCell(0, 1, 0, "North")
    south_category = workbook.getCell(0, 2, 0, "South")
    chart.getChartData().getCategories().add(north_category)
    chart.getChartData().getCategories().add(south_category)
    north_value = workbook.getCell(0, 1, 1, jpype.JInt(120))
    south_value = workbook.getCell(0, 2, 1, jpype.JInt(150))
    series.getDataPoints().addDataPointForBarSeries(north_value)
    series.getDataPoints().addDataPointForBarSeries(south_value)

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Полученное имя серии — `Product A 2026`, между двумя значениями ячеек вставлен пробел. Легенда отображает его как одну запись для обеих колонок. Ниже показан результат:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Получение автоматического цвета заливки серии**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) возвращает цвет, вычисленный на основе индекса серии и стиля диаграммы. Это цвет, используемый, когда заливка серии не определена явно. Вызов метода лишь считывает вычисленный цвет; он не задаёт новую заливку.

Следующий пример выводит автоматический цвет каждой серии по умолчанию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

Пример вывода для стиля диаграммы по умолчанию:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Точные цвета зависят от стиля и темы диаграммы.

## **Установка инвертированного цвета заливки для серии диаграммы**

Для бар‑, столбцовых и пузырьковых серий [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) может отображать отрицательные значения другим цветом. Задайте обычную заливку серии как сплошную, включите инверсию и задайте цвет отрицательного значения через [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Отрицательные числа в рабочей книге остаются неизменными; меняется только их цвет отображения.

Следующий пример заменяет данные диаграммы одной серией. Строка 0 листа содержит имя серии, столбец 0 — имена категорий, столбец 1 — значения:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![The inverted solid fill color](inverted_solid_fill_color.png)

Инверсию можно включить для отдельной точки через [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). В следующем примере инверсия отключена для серии и включена только для выбранной точки. Точке также присваивается отрицательное значение, чтобы эффект был виден:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Очистка конкретного значения точки данных**

Чтобы сделать одну точку пустой, не удаляя остальные, установите её ячейку в рабочей книге в `None`. Для столбчатой диаграммы построенное значение доступно через [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue). Точка остаётся в том же положении категории, но диаграмма считает её значение пустым в соответствии с настройками обработки пустых значений.

Следующий пример очищает только вторую точку первой серии:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Диаграммы разброса используют отдельные ячейки X и Y, а диаграммы‑пузыри – также ячейку размера. Очищайте только ту ячейку, которая представляет значение, которое планируется удалить. Не вызывайте [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear), если необходимо оставить остальные точки, так как этот метод удаляет все точки из коллекции.

## **Управление отображением пустых ячеек**

Скрытые ячейки, содержащие значения, отличаются от пустых ячеек. Чтобы включать или исключать данные из скрытых строк и столбцов листа, см. [Include Data from Hidden Rows and Columns](/slides/ru/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Пустая ячейка рабочей книги обозначает отсутствие данных; ячейка, содержащая `0`, — известное числовое значение. Вызовите [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) с `None`, чтобы сделать ячейку пустой. Числовой ноль остаётся нулём независимо от настройки обработки пустых ячеек.

Используйте [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs), чтобы выбрать способ отображения пустых ячеек. Эта настройка применяется ко всей диаграмме. Она изменяет способ построения пустот, не заполняя пустую ячейку нулём или интерполированным значением.

Следующий самодостаточный пример создаёт линейную диаграмму с одной серией, очищает значение для Дня 3 и сохраняет диаграмму в каждом режиме. Входной файл не требуется. [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) использует лист 0, столбец 0 для меток категорий и столбец 1 для значений; строка 0 содержит имя серии. Итоговые данные: `10, 20, empty, 30, 40`.

```python
import jpide
import asposeslides

if not jpide.isJVMStarted():
    jpide.startJVM()

from asposeslides.api import ChartType, DisplayBlanksAsType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(0, 0, 1, "Measurements")
    series = chart_data.getSeries().add(series_name_cell, chart.getType())
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpide.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Оставить день 3 действительно пустым, при этом сохранить его категорию и точку данных.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Каждый выходной файл сохраняет режим, выбранный перед сохранением: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` и `empty_cells_Span.pptx`. Чтобы сохранить только одну версию, задайте нужный режим и сохраните презентацию один раз вместо перебора режимов.

Сравнение ниже показывает одни и те же данные во всех трёх файлах. День 3 пуст в рабочей книге во всех случаях:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Видимый эффект зависит от типа диаграммы. Линейная диаграмма позволяет легко сравнивать все три режима. Бар‑ и столбцовые диаграммы не имеют линии, соединяющей пропущенную категорию, поэтому `Span` не может создать соединительный сегмент, показанный выше; пустой столбец и столбец нулевой высоты могут выглядеть одинаково. Аналогично, диаграмма разброса только с маркерами не имеет соединительной линии. Не ожидайте три разных результата для каждого типа диаграммы; проверьте вывод для используемого типа.

## **Установка ширины промежутка серии**

Ширина промежутка — это пространство между соседними кластерами баров или столбцов, выраженное в процентах от ширины бара или столбца. Как и перекрытие, она относится к родительской группе серий, а не к отдельной серии. Вызовите [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) один раз для группы. Большое значение создаёт больше пространства между кластерами; меньшее — делает их плотнее.

Следующий пример меняет ширину промежутка и сохраняет только окончательную презентацию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![The gap width](gap_width.png)

## **FAQ**

**Какие типы диаграмм поддерживают серии данных?**

Все типы диаграмм, представленные перечислением [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/), используют данные диаграммы, но их серии не имеют одинаковой структуры значений или настроек. Например, категориальные диаграммы используют категории и значения, диаграммы разброса — X и Y, а диаграммы‑пузыри добавляют размеры пузырей. Используйте метод создания точек данных, соответствующий типу серии. Параметры, такие как перекрытие и ширина промежутка, применимы только к совместимым группам баров или столбцов.

**Что такое группа серий диаграммы?**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) содержит совместимые серии, которые используют общие настройки построения на уровне группы. Комбинированная диаграмма может содержать более одной группы, поэтому изменение группы, полученной через одну серию, не обязательно изменит все серии диаграммы.

**Создаётся ли в новой диаграмме набор данных по умолчанию?**

Да. По умолчанию [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) создаёт образцы серий, категорий и значений. Вы можете изменить эти ячейки или очистить коллекции серий и категорий перед добавлением полностью пользовательского набора данных. Перегрузка метода также позволяет создать диаграмму без данных по умолчанию.

**Как объекты диаграммы связываются с ячейками рабочей книги?**

Имена серий, метки категорий и значения точек данных ссылаются на ячейки в [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/). Изменение ссылки ячейки обновляет соответствующий элемент диаграммы. При построении пользовательских данных следите за тем, чтобы строки категорий и строки значений серий оставались согласованными, чтобы каждая точка отображалась под нужной категорией.

**Как очистить одну точку, а не всю серию?**

Установите соответствующую ячейку значения в `None`, чтобы сохранить позицию категории точки как пустую точку. Используйте [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) только тогда, когда хотите удалить все точки из серии. Если вы также удаляете категории, обновите каждую серию, чтобы их значения оставались согласованными с коллекцией категорий.

**Как отображаются пустые точки?**

Результат зависит от типа диаграммы и значения, заданного в [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs). Поддерживаемые диаграммы могут отображать пустоты как пробелы, как нулевые значения или соединяя соседние точки. Выберите настройку, соответствующую смыслу отсутствующих данных в вашей презентации. См. [Control the Display of Empty Cells](#control-the-display-of-empty-cells) для полного примера и визуального сравнения.

**Как форматировать отрицательные значения?**

Для поддерживаемых бар‑, столбцовых и пузырьковых серий вызовите [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) и задайте цвет, возвращаемый [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Вы можете переопределить поведение для отдельной точки с помощью [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Эти методы влияют на форматирование, а не на сохраняемые числовые значения.

**Какой формат выигрывает, когда одновременно задано форматирование серии и точки?**

Явное форматирование точки данных имеет приоритет для этой точки. Другие точки продолжают использовать явный формат серии или, если формат серии не определён, автоматический стиль и тему диаграммы. Настройки группы, такие как перекрытие и ширина промежутка, управляют расположением и не являются переопределениями формата уровня точки.

**Есть ли лимит на количество серий в диаграмме?**

Aspose.Slides не налагает отдельный фиксированный лимит на количество серий. На практике ограничения определяются размером файла презентации, доступной памятью, временем рендеринга и читаемостью диаграммы.

**Что изменить, если столбцы слишком близко друг к другу или слишком далеко?**

Вызовите [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) у соответствующей родительской группы серий. Увеличьте значение, чтобы расширить промежуток между кластерами, или уменьшите его, чтобы собрать кластеры ближе.