---
title: Управление подписями данных диаграммы в презентациях с использованием Python
linktitle: Подпись данных
type: docs
url: /ru/python-java/chart-data-label/
keywords:
- диаграмма
- подпись данных
- точность данных
- процент
- расстояние подписи
- расположение подписи
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как добавлять и форматировать подписи данных диаграммы в презентациях PowerPoint с помощью Aspose.Slides для Python через Java, чтобы сделать слайды более привлекательными."
---
## **Введение**

Подписи данных отображают информацию о рядах диаграммы и отдельных точках данных, помогая читателям определять значения и понимать диаграмму. В этой статье объясняется, как форматировать значения, отображать проценты, читать текст подписи, управлять подписями за пределами максимума оси, настраивать интервал подписи оси категорий и размещать подписи на круговой диаграмме.

## **Подсчет видимых подписей данных**

Используйте [getCountOfVisibleDataLabels](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getCountOfVisibleDataLabels) чтобы проверить, сколько подписей данных включено для отображения перед публикацией презентации. В отличие от [getCount](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getCount), который возвращает общее количество подписей в коллекции, он учитывает значения по умолчанию серии и индивидуальные настройки подписи.

В этом примере создаётся столбчатая диаграмма с одной серией и тремя точками данных. Она получает коллекцию подписей серии через [getLabels](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getLabels) и выводит количество видимых подписей по мере изменения настроек: **0, 3, 2, 3**. Общее количество остаётся **3**.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    series_cell = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    for i in range(3):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JDouble((i + 1) * 10))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    labels = series.getLabels()
    print(f"Total: {labels.getCount()}; visible: {labels.getCountOfVisibleDataLabels()}")  # Всего: 3; видимых: 0

    labels.getDefaultDataLabelFormat().setShowValue(True)
    print(f"Visible: {labels.getCountOfVisibleDataLabels()}")  # Видимых: 3

    labels.get_Item(1).getDataLabelFormat().setShowValue(False)
    print(f"Visible: {labels.getCountOfVisibleDataLabels()}")  # Видимых: 2

    labels.get_Item(1).getDataLabelFormat().setShowLegendKey(True)
    print(f"Visible: {labels.getCountOfVisibleDataLabels()}")  # Видимых: 3
finally:
    presentation.dispose()
```

Метод [getDefaultDataLabelFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getDefaultDataLabelFormat) серии предоставляет настройки по умолчанию. Передача `True` в [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) отображает значения для всех трех подписей. Передача `False` через [getDataLabelFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getDataLabelFormat) отдельной подписи переопределяет эту настройку для выбранной подписи. Передача `True` в [setShowLegendKey](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLegendKey) делает эту подпись снова видимой, хотя её значение остаётся скрытым.

Отображаемое количество отражает настройки видимости. Оно не измеряет, перекрываются ли подписи, обрезаются ли они или читаемы ли они в отрендеренной диаграмме.

## **Установка точности данных в подписях диаграмм**

Используйте [setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) для форматирования значений серии. В этом примере создаётся линейная диаграмма с данными по умолчанию, отображается её таблица данных и включаются подписи значений для первой серии. Формат `#,##0.00` выводит разделитель тысяч и два знака после запятой, не изменяя исходные значения.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)

    series = chart.getChartData().getSeries().get_Item(0)
    series.setNumberFormatOfValues("#,##0.00")
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Чтобы форматировать числовые ячейки в встроенной рабочей книге диаграммы, см. [Установить пользовательские числовые форматы для ячеек рабочей книги](/slides/ru/python-java/chart-workbook/#set-custom-number-formats-for-workbook-cells). Этот пример также показывает подписи значений, следующие форматам исходных ячеек, при сохранении сохранённых числовых значений.

## **Отображение процентов в виде подписей**

Для сложенной столбчатой диаграммы вычислите каждое значение как процент от общей суммы категории и присвойте текст текстовому фрейму, возвращаемому методом [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding). Этот пример использует данные диаграммы по умолчанию и отображает проценты с двумя знаками после запятой шрифтом 8 пунктов. Категории с нулевой общей суммой пропускаются, чтобы избежать деления на ноль. Пересчитайте пользовательский текст подписи, если данные диаграммы изменятся.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Portion, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400)

    chart_series = chart.getChartData().getSeries()
    category_totals = [0.0] * chart.getChartData().getCategories().size()
    for category_index in range(len(category_totals)):
        for series_index in range(chart_series.size()):
            data_point = chart_series.get_Item(series_index).getDataPoints().get_Item(category_index)
            category_totals[category_index] += float(data_point.getValue().getData())

    for series_index in range(chart_series.size()):
        series = chart_series.get_Item(series_index)
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(False)

        for point_index in range(series.getDataPoints().size()):
            data_point = series.getDataPoints().get_Item(point_index)
            label = data_point.getLabel()
            if category_totals[point_index] == 0:
                print(f"Cannot calculate a percentage for category {point_index}: the total is zero.")
                continue
            point_percentage = float(data_point.getValue().getData()) / category_totals[point_index] * 100

            portion = Portion()
            portion.setText(f"{point_percentage:.2f} %")
            portion.getPortionFormat().setFontHeight(8)
            label.getTextFrameForOverriding().setText("")
            paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0)
            paragraph.getPortions().add(portion)

            label_format = label.getDataLabelFormat()
            label_format.setShowValue(True)
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установка знака процента в подписях диаграммы**

Когда значения хранятся в виде дробей, используйте [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) для отображения процентов. Передайте `False` в [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource), чтобы применить формат подписи независимо от исходных ячеек.

В этом примере создаётся 100% сложенная столбчатая диаграмма с красными и синими рядами по четырём категориям. Каждая пара значений в сумме даёт 1. Формат подписи `0.0%` отображает 0.30 как 30.0%, в то время как вертикальная ось использует два знака после запятой. Обе серии используют белый текст подписи размером 10 пунктов.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%")

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [Color.RED, Color.BLUE]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i, series_name in enumerate(series_names):
        series_cell = workbook.getCell(worksheet_index, 0, i + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        for j, value in enumerate(values[i]):
            value_cell = workbook.getCell(worksheet_index, j + 1, i + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        series.getFormat().getFill().setFillType(FillType.Solid)
        series.getFormat().getFill().getSolidFillColor().setColor(series_colors[i])

        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(False)
        label_format.setNumberFormat("0.0%")
        portion_format = label_format.getTextFormat().getPortionFormat()
        portion_format.setFontHeight(10)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Чтение фактического текста подписей данных**

Используйте [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) для получения текста, созданного настройками подписи данных. Это полезно при извлечении подписей для отчетов, поиске содержимого презентации или проверке сгенерированных диаграмм. В примере ниже формат подписи по умолчанию [data label format](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) объединяет название каждой категории, название серии и значение. Одна точка форматирует своё значение как процент, а другая использует пользовательский текст из [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    first_category_cell = workbook.getCell(0, 1, 0, "Q1")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "Q2")
    chart.getChartData().getCategories().add(second_category_cell)

    north_series_cell = workbook.getCell(0, 0, 1, "North")
    north = chart.getChartData().getSeries().add(north_series_cell, chart.getType())
    north_first_value_cell = workbook.getCell(0, 1, 1, jpype.JDouble(0.25))
    north.getDataPoints().addDataPointForBarSeries(north_first_value_cell)
    north_second_value_cell = workbook.getCell(0, 2, 1, jpype.JDouble(0.75))
    north.getDataPoints().addDataPointForBarSeries(north_second_value_cell)

    south_series_cell = workbook.getCell(0, 0, 2, "South")
    south = chart.getChartData().getSeries().add(south_series_cell, chart.getType())
    south_first_value_cell = workbook.getCell(0, 1, 2, jpype.JDouble(0.40))
    south.getDataPoints().addDataPointForBarSeries(south_first_value_cell)
    south_second_value_cell = workbook.getCell(0, 2, 2, jpype.JDouble(0.60))
    south.getDataPoints().addDataPointForBarSeries(south_second_value_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowCategoryName(True)
        label_format.setShowSeriesName(True)
        label_format.setShowValue(True)

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(False)
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%")
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed")

    for series in chart.getChartData().getSeries():
        for point in series.getDataPoints():
            label = point.getLabel()
            if not label.isVisible():
                continue

            print(f"Value: {point.getValue().getData()}; label: {label.getActualLabelText()}")
finally:
    presentation.dispose()
```

Число, хранящееся в точке данных, остаётся `0.75`, даже если её подпись отображает `75%` вместе с названиями категории и серии. Пользовательский текст заменяет сгенерированный текст подписи. [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) возвращает полученную строку подписи в любом случае. Проверьте [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible) отдельно, как показано выше, когда необходимо извлекать только видимые подписи.

## **Управление подписями данных за пределами максимума оси**

Когда вы вручную ограничиваете диапазон оси, некоторые точки данных могут превышать её максимум. Используйте [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) чтобы управлять отображением их подписей данных. Эта настройка изменяет видимость подписи; она не меняет диапазон оси или исходные значения данных.

В приведённом ниже примере создаётся 2D кластерная столбчатая диаграмма со значениями 60 и 120. В неё передаётся `False` в [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) и устанавливается максимум 100 с помощью [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) на вертикальной оси. На первом слайде подписи допускаются за пределами максимума; копия этого слайда отключает их. Оба слайда сохраняются в `DataLabelsOverMaximum.pptx`.

Включите подписи значений с помощью [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue). Настройка на уровне диаграммы не включает отображение значений сама по себе и не переопределяет отключённое отображение значения отдельной подписи. В этом примере значения включаются для всей серии, а [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition) используется для размещения подписей в наружном конце каждого столбца.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    first_category = workbook.getCell(0, 1, 0, "Within range")
    second_category = workbook.getCell(0, 2, 0, "Above maximum")

    chart.getChartData().getCategories().add(first_category)
    chart.getChartData().getCategories().add(second_category)

    series_name = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())

    first_value = workbook.getCell(0, 1, 1, jpype.JDouble(60))
    second_value = workbook.getCell(0, 2, 1, jpype.JDouble(120))

    series.getDataPoints().addDataPointForBarSeries(first_value)
    series.getDataPoints().addDataPointForBarSeries(second_value)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(100)
    chart.setShowDataLabelsOverMaximum(True)

    second_slide = presentation.getSlides().addClone(slide)
    second_chart = second_slide.getShapes().get_Item(0)
    second_chart.setShowDataLabelsOverMaximum(False)

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ниже представлены изображения сохранённых слайдов, отрисованных в Microsoft PowerPoint. При `True` подпись **120** видна у верхней границы; при `False` она скрыта. Подпись **60** остаётся видимой, максимум оси остаётся **100**, и в обоих случаях вторая точка данных остаётся **120**.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![Диаграмма PowerPoint, отображающая подпись со значением 120 при максимуме оси 100](data-labels-over-maximum-true.png) | ![Диаграмма PowerPoint, скрывающая подпись со значением 120 при максимуме оси 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
В этом примере используется 2D столбчатая диаграмма с осью значений. Диаграммы без оси значений, такие как круговые и кольцевые диаграммы, не имеют максимума оси, который можно ограничить таким способом.
{{% /alert %}}

## **Установка расстояния подписи от оси**

Используйте [setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset) для управления расстоянием между подписями оси категорий и самой осью. Значение задаётся в процентах от максимального размера шрифта подписей оси. В этом примере создаётся кластерная столбчатая диаграмма и устанавливается смещение подписи горизонтальной оси в 500. Эта настройка влияет на подписи оси категорий, а не на подписи, привязанные к отдельным точкам данных.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    chart.getAxes().getHorizontalAxis().setLabelOffset(500)

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Регулировка расположения подписи**

На круговой диаграмме регулируйте позиции подписей данных, чтобы улучшить интервал и освободить место для линий‑указателей.

В этом примере отображается значение первой точки данных, её подпись помещается за пределы сектора, и корректируются горизонтальное и вертикальное смещения с помощью [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) и [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY). Эти смещения задаются относительно ширины и высоты диаграммы соответственно.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Круговая диаграмма с скорректированным расположением подписи данных](pie-chart-adjusted-label.png)

## **Форматирование линий‑указателей**

Когда подписи круговой диаграммы находятся за пределами своих секторов, линии‑указатели помогают пользователям сопоставить каждое значение с соответствующим сектором. Контрастный цвет и слегка более толстая линия могут облегчить восприятие этих соединений, а прозрачность и пунктирный стиль делают линии менее заметными визуально.

Используйте [getLeaderLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getLeaderLinesFormat) для форматирования линий‑указателей на уровне коллекции подписей серии. Настройки в `series.getLabels().getLeaderLinesFormat().getLine()` применяются ко всей коллекции, а не к отдельной подписи.

В этом примере создаётся круговая диаграмма с данными по умолчанию, отображаются значения за пределами секторов и включаются [setShowLeaderLines](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLeaderLines). Две подписи перемещаются дальше от своих секторов с помощью смещений [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) и [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY), задаваемых в долях ширины и высоты диаграммы. Входная презентация не требуется.

Метод [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) линии задаёт сплошной синий цвет с альфа‑значением 191 из 255, что обеспечивает примерно 25 % прозрачности. [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) задаёт толщину в 2 пункта, а [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) делает линию пунктирной.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 80, 50, 560, 400)
    chart.setLegend(False)

    series = chart.getChartData().getSeries().get_Item(0)

    label_format = series.getLabels().getDefaultDataLabelFormat()
    label_format.setShowValue(True)
    label_format.setPosition(LegendDataLabelPosition.OutsideEnd)
    label_format.setShowLeaderLines(True)

    # Сдвинуть две подписи дальше от их секторов.
    series.getLabels().get_Item(0).setX(0.10)
    series.getLabels().get_Item(0).setY(-0.05)
    series.getLabels().get_Item(1).setX(-0.10)
    series.getLabels().get_Item(1).setY(0.05)

    line = series.getLabels().getLeaderLinesFormat().getLine()
    line.getFillFormat().setFillType(FillType.Solid)
    color = Color(30, 90, 160, 191)
    line.getFillFormat().getSolidFillColor().setColor(color)
    line.setWidth(2)
    line.setDashStyle(LineDashStyle.Dash)

    presentation.save("FormattedLeaderLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Включение линий‑указателей не гарантирует появление линии для каждой подписи. Видимость зависит от размещения подписи и поведения компоновки диаграммы. В этом примере две перемещённые подписи имеют видимые линии‑указатели; подписи, оставшиеся рядом со своими секторами, их не требуют.

Следующее изображение показывает сохранённый `FormattedLeaderLines.pptx`, отрендеренный с помощью Aspose.Slides:

![Круговая диаграмма с синими полупрозрачными пунктирными линиями‑указателями, соединяющими две наружные подписи с их секторами](formatted-leader-lines.png)

## **Добавление нескольких строк подписей над столбчатой диаграммой**

В этом примере создаётся столбчатая диаграмма с двумя строками подписей над областью построения. Серия A отображает видимые столбцы, тогда как серии B и C предоставляют дополнительные подписи. Их столбцы скрыты путём удаления заливки и контура. Метод [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) выравнивает все три серии по одинаковым центрам категорий.

Настройки [ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) резервируют пространство для строк подписей. После того как [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) вычислит позиции по умолчанию, [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) и [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) сохраняют горизонтальное выравнивание и применяют вертикальные смещения для размещения подписей в две строки. Числа остаются подписями данных, связанными со значениями серии; только заголовки строк являются отдельными текстовыми фигурами.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LayoutTargetType, LegendDataLabelPosition, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200)
    chart.setTitle(False)
    chart.setLegend(False)
    chart.getTextFormat().getPortionFormat().setFontHeight(12)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]]

    for category_index, category in enumerate(categories):
        category_cell = workbook.getCell(0, category_index + 1, 0, category)
        chart.getChartData().getCategories().add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.getCell(0, 0, series_index + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, ChartType.ClusteredColumn)

        for category_index, value in enumerate(series_values[series_index]):
            value_cell = workbook.getCell(0, category_index + 1, series_index + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        if series_index > 0:
            # Скрыть столбцы B и C, но оставить их подписи данных.
            series.getFormat().getFill().setFillType(FillType.NoFill)
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
            label_format = series.getLabels().getDefaultDataLabelFormat()
            label_format.setShowValue(True)
            label_format.getTextFormat().getPortionFormat().setFontHeight(12)
            label_fill = label_format.getTextFormat().getPortionFormat().getFillFormat()
            label_fill.setFillType(FillType.Solid)
            label_fill.getSolidFillColor().setColor(Color.BLACK)
            label_format.setPosition(LegendDataLabelPosition.InsideBase)

    # Выравнивать все три ряда по одинаковым центрам категорий.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(jpype.JByte(100))

    # Использовать меньше линий сетки для этого компактного примера.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setMajorUnit(10)

    # Зарезервировать место над областью построения для двух строк подписей данных.
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner)
    chart.getPlotArea().setX(0.15)
    chart.getPlotArea().setY(0.32)
    chart.getPlotArea().setWidth(0.80)
    chart.getPlotArea().setHeight(0.48)
    chart.validateChartLayout()

    for series_index in range(1, len(series_names)):
        series = chart.getChartData().getSeries().get_Item(series_index)
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.getDataPoints().get_Item(category_index).getLabel()
            # Оставить положение по умолчанию по горизонтали. Y — смещение от
            # позиции подписи по умолчанию, выраженное в долях высоты диаграммы.
            data_label.setX(0)
            data_label.setY(row_top - data_label.getActualY() / chart.getHeight())

        # Только заголовок строки является отдельной текстовой фигурой.
        heading_y = chart.getY() + row_top * chart.getHeight()
        row_heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, chart.getX(), heading_y, 85, 18)
        row_heading.getFillFormat().setFillType(FillType.NoFill)
        row_heading.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        row_heading.addTextFrame(series_names[series_index])
        row_heading.getTextFrame().getTextFrameFormat().setMarginTop(0)
        row_heading.getTextFrame().getTextFrameFormat().setMarginBottom(0)
        heading_format = row_heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        heading_format.setFontHeight(12)
        heading_format.getFillFormat().setFillType(FillType.Solid)
        heading_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Столбчатая диаграмма с двумя строками подписей над областью построения](multiple-rows-of-labels.png)

## **FAQ**

**Как предотвратить наложение подписей данных на плотных диаграммах?**

Сочетайте автоматическое размещение подписей, линии‑указатели и уменьшенный размер шрифта; при необходимости скрывайте некоторые поля (например, категорию) или отображайте подписи только для экстремальных значений или ключевых точек.

**Как отключить подписи только для нулевых, отрицательных или пустых значений?**

Отфильтруйте точки данных перед включением подписей и отключите отображение для значений 0, отрицательных значений или отсутствующих значений согласно заданному правилу.

**Как обеспечить согласованный стиль подписей при экспорте в PDF/изображения?**

Явно задайте семейство шрифта и размер, а также проверьте, что шрифт доступен в окружении рендеринга, чтобы избежать замены.