---
title: Управление данными серий диаграммы в презентациях на Python
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

Диаграмма хранит свои построенные данные в рабочей книге данных диаграммы. [ChartSeries](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/) представляет один набор связанных значений, а каждый [ChartDataPoint](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatapoint/) в серии ссылается на одну или несколько ячеек рабочей книги. Объекты [ChartCategory](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartcategory/) предоставляют метки или значения группировки, общие для серий. Поэтому имя серии, категории и значения точек связаны с объектами [ChartDataCell](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatacell/), а не хранятся только как отображаемый текст.

Для типичной диаграммы категорий рабочая книга по умолчанию использует строку 0 для имён серий, столбец 0 для имён категорий и остальные ячейки для значений серий. Индексы листа, строки и столбца, передаваемые в [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdataworkbook/#getCell), нумеруются с нуля. Такой макет удобен, когда вы создаёте диаграмму с данными по умолчанию, но не следует предполагать, что каждая существующая диаграмма использует его. Для загруженной презентации проверьте ячейки, на которые ссылаются серии, категории и точки данных, прежде чем изменять значения в рабочей книге.

Настройки диаграммы имеют три разных уровня области:

- Настройки уровня серии, такие как [ChartSeries.getFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#getFormat), задают оформление по умолчанию для всех точек в одной серии.
- Настройки точки данных, такие как [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatapoint/#getFormat), переопределяют оформление серии для одной точки.
- Групповые настройки применяются к совместимым сериям, принадлежащим к одной [ChartSeriesGroup](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseriesgroup/). Получите доступ к группе через [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#getParentSeriesGroup), когда необходимо задать параметры, такие как перекрытие или ширина промежутка.

Когда явное заполнение точки или серии не задано, стиль и тема диаграммы определяют автоматическое оформление. Если присутствует как форматирование серии, так и точек, форматирование точки имеет приоритет для этой точки.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установить перекрытие серии диаграммы**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#getOverlap) сообщает, насколько столбцы или полосы перекрываются в двумерной диаграмме, от -100 до 100 процентов. Это только чтение проекции параметра в родительской группе серий. Используйте [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseriesgroup/#setOverlap), чтобы обновить каждую совместимую серию в этой группе. Эта опция применяется к типам диаграмм, отображающим сгруппированные столбцы или полосы; она не влияет на несвязанные группы серий в комбинированной диаграмме.

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

    # Новая диаграмма содержит образцы серий, категорий и значений.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Перекрытие серий](series_overlap.png)

## **Изменить цвет заполнения серии**

Используйте [ChartSeries.getFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#getFormat), чтобы задать заполнение по умолчанию для всей серии. Если у точки уже задано явное заполнение, её настройка [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatapoint/#getFormat) переопределит заполнение серии для этой точки.

Следующий пример применяет сплошное синее заполнение к первой серии:

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

![Цвет серии](series_color.png)

## **Изменить имя серии**

Имя серии хранится в рабочей книге данных диаграммы и обычно отображается в легенде. В рабочей книге по умолчанию для столбчатой диаграммы с группировкой ячейка B1 находится в строке 0, столбце 1 и содержит имя первой серии. Именованные переменные в следующем примере делают эту структуру явной:

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

Вы также можете обновить ячейку, уже используемую [ChartSeries.getName](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#getName). Этот подход позволяет не предполагать конкретные строки и столбцы в существующей диаграмме:

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

![Имя серии](series_name.png)

## **Получить автоматически рассчитанный цвет серии**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) возвращает цвет, вычисленный из индекса серии и стиля диаграммы. Это цвет, используемый, когда заполнение серии явно не определено. Вызов метода только читает вычисленный цвет; он не задаёт новое заполнение.

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

## **Установить инвертированный цвет заполнения для серии диаграммы**

Для столбчатых, колонных и пузырьковых серий [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#setInvertIfNegative) может отображать отрицательные значения другим заполнением. Задайте обычное заполнение серии как сплошное, включите инверсию и задайте цвет отрицательного значения через [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Отрицательные числа в рабочей книге остаются без изменений; меняется только их цвет отображения.

Следующий пример заменяет данные диаграммы данными одной серии. Строка 0 листа содержит имя серии, столбец 0 – имена категорий, столбец 1 – значения:

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

![Инвертированный сплошной цвет заполнения](inverted_solid_fill_color.png)

Вы можете включить инверсию для одной точки через [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). В следующем примере инверсия отключена для серии и включена только для выбранной точки. Точка также получает отрицательное значение, чтобы эффект был видим:

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

## **Очистить значение конкретной точки данных**

Чтобы сделать одну точку пустой, не удаляя остальные, задайте её связанную ячейку рабочей книги значением `None`. Для столбчатой диаграммы отображаемое значение доступно через [ChartDataPoint.getValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatapoint/#getValue). Точка остаётся на той же позиции категории, но диаграмма трактует её значение как пустое согласно настройкам отображения пустых значений.

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

В точечных диаграммах используются отдельные ячейки X и Y, а в пузырьковых – также ячейка размера. Очищайте только ячейку, представляющую значение, которое вы хотите удалить. Не вызывайте [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatapointcollection/#clear), если хотите сохранить остальные точки, поскольку этот метод удаляет все точки из коллекции.

## **Управление отображением пустых ячеек**

Скрытые ячейки, содержащие значения, отличаются от пустых ячеек. Чтобы включать или исключать данные из скрытых строк и столбцов листа, см. [Include Data from Hidden Rows and Columns](/slides/ru/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Пустая ячейка рабочей книги представляет отсутствующие данные; ячейка, содержащая `0`, представляет известное числовое значение. Вызовите [ChartDataCell.setValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatacell/#setValue) с параметром `None`, чтобы сделать ячейку пустой. Числовой ноль остаётся нулём независимо от настройки пустой ячейки.

Используйте [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#setDisplayBlanksAs), чтобы выбрать способ отображения пустых ячеек в диаграмме. Эта настройка применяется ко всей диаграмме. Она меняет способ построения пустот, не заполняя пустую ячейку нулём или интерполированным значением.

Следующий самостоятельный пример создаёт линейную диаграмму с одной серией, очищает значение для 3‑го дня и сохраняет одну и ту же диаграмму в каждом режиме. Входной файл не требуется. [ChartDataWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdataworkbook/) использует лист 0, столбец 0 для меток категорий и столбец 1 для значений; строка 0 хранит имя серии. Финальные данные: `10, 20, empty, 30, 40`.

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

    # Оставьте третий день действительно пустым, сохранив его категорию и точку данных.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Каждый выходной файл сохраняет режим, указанный перед сохранением: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` и `empty_cells_Span.pptx`. Чтобы сохранить только одну версию, задайте нужный режим и сохраните презентацию один раз вместо итерации по режимам.

Сравнение ниже показывает одинаковые данные во всех трёх файлах. День 3 пустой в рабочей книге в каждом случае:

![Линейные диаграммы с одинаковыми данными: Gap разрывает линию в день 3, Zero опускает линию до нуля, а Span соединяет день 2 с днём 4.](display_blanks_as.png)

Видимый эффект зависит от типа диаграммы. Линейная диаграмма позволяет удобно сравнивать все три режима. В столбчатых и колонных диаграммах нет линии, соединяющей пропущенную категорию, поэтому `Span` не может создать соединительный сегмент, показанный выше; отсутствующий столбец и столбец нулевой высоты могут выглядеть одинаково. Аналогично, точечная диаграмма только с маркерами не имеет соединительной линии. Не ожидайте трёх разных результатов для каждого типа диаграммы; проверьте вывод для используемого типа.

## **Установить ширину промежутка между сериями**

Ширина промежутка — это пространство между соседними кластерами столбцов или полос, выраженное в процентах от ширины столбца или полосы. Как и перекрытие, она относится к родительской группе серий, а не к отдельной серии. Вызовите [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseriesgroup/#setGapWidth) один раз для группы. Большее значение создаёт больше пространства между кластерами; меньшее значение делает их плотнее.

Следующий пример изменяет ширину промежутка и сохраняет только финальную презентацию:

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

![Ширина промежутка](gap_width.png)

## **FAQ**

**Какие типы диаграмм поддерживают серии данных?**

Все типы диаграмм, представленные перечислением [ChartType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/), используют данные диаграммы, но их серии не имеют одинаковой структуры значений или настроек. Например, диаграммы категорий используют категории и значения, точечные диаграммы используют X и Y, а пузырьковые добавляют размеры пузырей. Используйте метод создания точек данных, соответствующий типу серии. Параметры, такие как перекрытие и ширина промежутка, применимы только к совместимым группам столбцов или полос.

**Что такое группа серий диаграммы?**

[ChartSeriesGroup](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseriesgroup/) содержит совместимые серии, которые разделяют настройки уровня группы. Комбинированная диаграмма может содержать более одной группы, поэтому изменение группы, полученной через одну серию, не обязательно изменит все серии в диаграмме.

**Содержит ли вновь созданная диаграмма данные по умолчанию?**

Да. По умолчанию [ShapeCollection.addChart](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addChart) создаёт образцы серий, категорий и значений. Вы можете редактировать эти ячейки или очистить коллекции серий и категорий перед добавлением полностью пользовательского набора данных. Перегрузка метода также может создавать диаграмму без данных по умолчанию.

**Как объекты диаграммы связаны с ячейками рабочей книги?**

Имена серий, метки категорий и значения точек данных ссылаются на ячейки в [ChartDataWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdataworkbook/). Изменение ссылки ячейки обновляет соответствующий элемент диаграммы. При построении пользовательских данных поддерживайте согласованность строк категорий и строк значений серий, чтобы каждая точка отображалась под нужной категорией.

**Как очистить одну точку, а не всю серию?**

Задайте соответствующую ячейку значения `None`, чтобы сохранить позицию категории точки как пустой. Используйте [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatapointcollection/#clear) только когда хотите удалить все точки из серии. Если вы также удаляете категории, обновите каждую серию, чтобы её значения оставались согласованными с коллекцией категорий.

**Как отображаются пустые точки?**

Результат зависит от типа диаграммы и значения, установленного через [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#setDisplayBlanksAs). Поддерживаемые диаграммы могут отображать пустоты как разрывы, как нулевые значения или соединяя соседние точки. Выберите настройку, соответствующую смыслу отсутствующих данных в вашей презентации. См. раздел [Управление отображением пустых ячеек](#control-the-display-of-empty-cells) для полного примера и визуального сравнения.

**Как форматируются отрицательные значения?**

Для поддерживаемых столбчатых, колонных и пузырьковых серий вызовите [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#setInvertIfNegative) и задайте цвет, возвращаемый [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Поведение отдельной точки можно переопределить через [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Эти методы влияют только на форматирование, а не на хранимые числовые значения.

**Какой формат выигрывает, если форматированы и серия, и точка?**

Явное форматирование точки данных имеет приоритет для этой точки. Другие точки продолжают использовать явный формат серии или, если формат серии не задан, автоматический стиль и тему диаграммы. Групповые настройки, такие как перекрытие и ширина промежутка, управляют компоновкой и не являются переопределением формата на уровне точки.

**Есть ли ограничение на количество серий в диаграмме?**

Aspose.Slides не накладывает отдельного фиксированного ограничения на число серий. На практике ограничения файлов презентации, доступная память, время рендеринга и читаемость диаграммы определяют практический предел.

**Что менять, если столбцы слишком близко или слишком далеко друг от друга?**

Вызовите [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseriesgroup/#setGapWidth) для соответствующей родительской группы серий. Увеличьте значение, чтобы расширить пространство между кластерами, или уменьшите его, чтобы собрать кластеры ближе.