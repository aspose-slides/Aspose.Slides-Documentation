---
title: Управление сериями данных диаграмм в презентациях на Python
linktitle: Серии данных
type: docs
url: /ru/python-java/chart-series/
keywords:
- серии диаграмм
- перекрытие серий
- цвет серии
- имя серии
- точка данных
- ячейка рабочей книги
- промежуток между сериями
- отрицательное значение
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как управлять сериями диаграмм, точками данных, ячейками рабочей книги, форматированием, перекрытием, шириной промежутка и отрицательными значениями в презентациях с помощью Aspose.Slides для Python через Java."
---
## **Обзор**

Диаграмма хранит свои построенные данные в рабочей книге данных диаграммы. [ChartSeries](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/) представляет один набор связанных значений, и каждый [ChartDataPoint](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatapoint/) в серии ссылается на одну или несколько ячеек рабочей книги. Объекты [ChartCategory](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartcategory/) предоставляют метки или группирующие значения, общие для серии. Таким образом, имя серии, категории и значения точек связаны с объектами [ChartDataCell](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatacell/), а не хранятся только как отображаемый текст.

Для типичной диаграммы категорий по умолчанию рабочая книга использует строку 0 для имён серий, столбец 0 для имён категорий и оставшиеся ячейки для значений серий. Индексы листа, строки и столбца, передаваемые в [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdataworkbook/#getCell), начинаются с нуля. Такая раскладка полезна, когда вы создаёте диаграмму с данными по умолчанию, но не стоит полагаться на то, что каждая существующая диаграмма использует её. Для загруженной презентации проверьте ячейки, на которые ссылаются серии, категории и точки данных, прежде чем изменять значения в рабочей книге.

Настройки диаграммы имеют три разных уровня охвата:

- Настройки уровня серии, такие как [ChartSeries.getFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#getFormat), задают внешний вид по умолчанию для всех точек в одной серии.
- Настройки отдельной точки, такие как [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatapoint/#getFormat), переопределяют внешний вид серии для одной точки.
- Групповые настройки применяются к совместимым сериям, принадлежащим одному [ChartSeriesGroup](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseriesgroup/). Получите группу через [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#getParentSeriesGroup), когда нужно задать параметры, такие как перекрытие или ширина промежутка.

Когда явное заполнение точки или серии не задано, стиль и тема диаграммы определяют автоматический внешний вид. Когда присутствует как форматирование серии, так и точек, форматирование точки имеет приоритет для этой точки.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установить перекрытие серии диаграммы**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#getOverlap) сообщает, насколько столбцы или полосы перекрываются в 2‑D диаграмме, в диапазоне от ‑100 до 100 процентов. Это только чтение проекции настройки группы родительской серии. Используйте [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseriesgroup/#setOverlap), чтобы обновить каждую совместимую серию в этой группе. Этот параметр применяется к типам диаграмм, отображающим сгруппированные столбцы или полосы; он не влияет на несвязанные группы серий в комбинированной диаграмме.

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

    # Новая диаграмма содержит примерные серии, категории и значения.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![The series overlap](series_overlap.png)

## **Изменить цвет заливки серии**

Используйте [ChartSeries.getFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#getFormat), чтобы задать заливку по умолчанию для всей серии. Если у точки уже задана явная заливка, её настройка [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatapoint/#getFormat) переопределяет заливку серии для этой точки.

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

## **Изменить имя серии**

Имя серии хранится в рабочей книге данных диаграммы и обычно отображается в легенде. В рабочей книге по умолчанию, созданной для сгруппированной столбчатой диаграммы, ячейка B1 находится в строке 0, столбце 1 и содержит имя первой серии. Именованные переменные в следующем примере делают эту структуру явной:

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

Вы также можете обновить ячейку, уже полученную через [ChartSeries.getName](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#getName). Такой подход избавляет от предположений о конкретных строках и столбцах в существующей диаграмме:

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

## **Получить автоматический цвет заливки серии**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) возвращает цвет, вычисленный из индекса серии и стиля диаграммы. Это цвет, используемый, когда заливка серии не была явно определена. Вызов метода только читает вычисленный цвет; он не назначает новую заливку.

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

## **Установить инвертированный цвет заливки для серии диаграммы**

Для полосовых, столбчатых и пузырьковых серий [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#setInvertIfNegative) может отображать отрицательные значения другой заливкой. Задайте обычную заливку серии как сплошную, включите инверсию и задайте цвет отрицательного значения через [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Отрицательные числа остаются неизменными в рабочей книге; меняется только их цвет отображения.

Следующий пример заменяет данные диаграммы по умолчанию одной серией. Строка 0 листа содержит имя серии, столбец 0 — имена категорий, столбец 1 — значения:

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

Вы можете включить инверсию для одной точки через [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). В следующем примере инверсия отключена для серии и включена только для выбранной точки. Точке также присвоено отрицательное значение, чтобы эффект был видим:

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

## **Очистить конкретное значение точки данных**

Чтобы сделать одну точку пустой, не удаляя остальные, задайте её ячейку в рабочей книге `None`. Для столбчатой диаграммы построенное значение доступно через [ChartDataPoint.getValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatapoint/#getValue). Точка остаётся на той же позиции категории, но диаграмма рассматривает её значение как пустое в соответствии с настройками отображения пустых значений.

Следующий пример очищает только вторую точку в первой серии:

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

Точечные диаграммы используют отдельные ячейки X и Y, а пузырьковые диаграммы используют также ячейку размера. Очищайте только ту ячейку, которая представляет значение, которое вы хотите удалить. Не вызывайте [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatapointcollection/#clear), если хотите оставить остальные точки, так как этот метод удаляет все точки из коллекции.

## **Управление отображением пустых ячеек**

Пустая ячейка рабочей книги представляет отсутствующие данные; ячейка, содержащая `0`, представляет известное числовое значение. Вызовите [ChartDataCell.setValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatacell/#setValue) с `None`, чтобы сделать ячейку пустой. Числовой ноль остаётся нулём независимо от настройки пустой ячейки.

Используйте [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#setDisplayBlanksAs), чтобы выбрать способ отображения пустых ячеек диаграммой. Эта настройка применяется ко всей диаграмме. Она меняет способ построения пустот, не заполняя пустую ячейку нулём или интерполированным значением.

Следующий автономный пример создаёт линейную диаграмму с одной серией, очищает значение для Дня 3 и сохраняет одну и ту же диаграмму в каждом режиме. Входной файл не требуется. [ChartDataWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdataworkbook/) использует лист 0, столбец 0 для меток категорий и столбец 1 для значений; строка 0 содержит имя серии. Итоговые данные: `10, 20, empty, 30, 40`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Оставить 3‑й день действительно пустым, сохранив его категорию и точку данных.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Каждый выходной файл сохраняет режим, установленный перед сохранением: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` и `empty_cells_Span.pptx`. Чтобы сохранить только одну версию, задайте нужный режим и сохраните презентацию один раз вместо итераций по режимам.

Сравнение ниже показывает одинаковые данные во всех трёх файлах. День 3 пуст в рабочей книге во всех случаях:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Видимый эффект зависит от типа диаграммы. Линейная диаграмма позволяет легко сравнивать все три режима. У столбчатых и полосовых диаграмм нет линии, соединяющей пропущенную категорию, поэтому `Span` не может создать соединительный сегмент, показанный выше; отсутствующий столбец и столбец нулевой высоты также могут выглядеть одинаково. Аналогично, точечная диаграмма только с маркерами не имеет соединительной линии. Не ожидайте трёх разных результатов для каждого типа диаграммы; проверьте вывод для используемого типа.

## **Установить ширину промежутка между сериями**

Ширина промежутка — это пространство между соседними группами столбцов или полос, выраженное в процентах от ширины столбца или полосы. Как и перекрытие, она принадлежит родительской группе серий, а не отдельной серии. Вызовите [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseriesgroup/#setGapWidth) один раз для группы. Большее значение создаёт больше пространства между кластерами; меньшее — делает их плотнее.

Следующий пример меняет ширину промежутка и сохраняет только финальную презентацию:

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

Все типы диаграмм, представленные перечислением [ChartType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/), используют данные диаграммы, но их серии не все имеют одинаковую структуру значений или настройки. Например, диаграммы категорий используют категории и значения, точечные диаграммы — X и Y, а пузырьковые добавляют размер пузыря. Используйте метод создания точек данных, соответствующий типу серии. Параметры, такие как перекрытие и ширина промежутка, применимы только к совместимым группам столбцов или полос.

**Что такое группа серий диаграммы?**

[ChartSeriesGroup](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseriesgroup/) содержит совместимые серии, которые разделяют групповые настройки построения. Комбинированная диаграмма может содержать более одной группы, поэтому изменение группы, полученной через одну серию, не обязательно приводит к изменению всех серий в диаграмме.

**Создаётся ли в новой диаграмме набор данных по умолчанию?**

Да. По умолчанию [ShapeCollection.addChart](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addChart) создаёт примерные серии, категории и значения. Вы можете отредактировать эти ячейки или очистить как коллекцию серий, так и категорий перед добавлением полностью пользовательского набора данных. Перегрузка метода также может создать диаграмму без данных по умолчанию.

**Как объекты диаграммы связаны с ячейками рабочей книги?**

Имена серий, метки категорий и значения точек данных ссылаются на ячейки в [ChartDataWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdataworkbook/). Изменение ссылочной ячейки обновляет соответствующий элемент диаграммы. При построении пользовательских данных поддерживайте выравнивание строк категорий и строк значений серий, чтобы каждая точка была построена под нужной категорией.

**Как очистить одну точку, а не всю серию?**

Установите соответствующую ячейку значения в `None`, чтобы сохранить позицию категории точки как пустую точку. Используйте [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatapointcollection/#clear) только тогда, когда хотите удалить все точки из этой серии. Если вы также удаляете категории, обновите каждую серию, чтобы их значения оставались согласованными с коллекцией категорий.

**Как отображаются пустые точки?**

Результат зависит от типа диаграммы и значения, настроенного через [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#setDisplayBlanksAs). Поддерживаемые диаграммы могут отображать пустоты как разрывы, как нулевые значения или соединяя соседние точки. Выберите настройку, соответствующую смыслу отсутствующих данных в вашей презентации. См. раздел **Управление отображением пустых ячеек** для полного примера и визуального сравнения.

**Как форматируются отрицательные значения?**

Для поддерживаемых столбчатых, полосовых и пузырьковых серий вызовите [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#setInvertIfNegative) и задайте цвет, возвращаемый [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Поведение отдельной точки можно переопределить с помощью [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Эти методы влияют на форматирование, а не на хранимые числовые значения.

**Какой формат выигрывает, когда задан как у серии, так и у точки?**

Явное форматирование отдельной точки имеет приоритет для этой точки. Другие точки продолжают использовать явный формат серии или, если формат серии не определён, автоматический стиль и тему диаграммы. Групповые настройки, такие как перекрытие и ширина промежутка, управляют компоновкой и не являются переопределениями формата уровня точки.

**Есть ли ограничение на количество серий в диаграмме?**

Aspose.Slides не накладывает отдельного фиксированного ограничения на количество серий. На практике ограничения определяют размер файла презентации, доступная память, время рендеринга и читаемость диаграммы.

**Что менять, если столбцы слишком близко друг к другу или слишком далеко?**

Вызовите [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseriesgroup/#setGapWidth) у соответствующей родительской группы серий. Увеличьте значение, чтобы расширить пространство между кластерами, либо уменьшите его, чтобы собрать кластеры ближе.