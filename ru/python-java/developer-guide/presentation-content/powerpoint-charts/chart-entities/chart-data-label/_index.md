---
title: Управление метками данных диаграммы в презентациях с использованием Python
linktitle: Метка данных
type: docs
url: /ru/python-java/chart-data-label/
keywords:
- диаграмма
- метка данных
- точность данных
- процент
- расстояние метки
- расположение метки
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Научитесь добавлять и форматировать метки данных диаграмм в презентациях PowerPoint с помощью Aspose.Slides для Python через Java для более увлекательных слайдов."
---
## **Введение**

Метки данных отображают информацию о сериях диаграммы и отдельных точках данных, помогая читателям идентифицировать значения и понимать диаграмму. В этой статье объясняется, как форматировать значения, отображать проценты, считывать текст метки, управлять метками за пределами максимума оси, регулировать расстояние между метками оси категорий и позиционировать метки круговой диаграммы.

## **Установить точность данных в метках диаграммы**

Используйте [setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) для форматирования значений серии. Этот пример создает линейную диаграмму с данными по умолчанию, отображает её таблицу данных и включает метки значений для первой серии. Формат `#,##0.00` выводит разделитель тысяч и два знака после запятой, не изменяя исходные значения.

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

## **Отображать процент в виде меток**

Для сложенной столбчатой диаграммы вычислите каждое значение как процент от общей суммы категории и назначьте текст фрейму текста, возвращаемому методом [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding). Этот пример использует данные диаграммы по умолчанию и отображает проценты с двумя знаками после запятой шрифтом 8 пунктов. Категории с нулевой суммой пропускаются, чтобы избежать деления на ноль. При изменении данных диаграммы пересчитайте пользовательский текст метки.

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

## **Установить знак процента в метках диаграммы**

Когда значения хранятся в виде дробей, используйте [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) для отображения процентов. Передайте `False` в [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource), чтобы применить формат метки независимо от исходных ячеек.

Этот пример создает 100% сложенную столбчатую диаграмму с красными и синими сериями по четырём категориям. Каждая пара значений в сумме дает 1. Формат метки `0.0%` отображает 0.30 как 30.0%, тогда как вертикальная ось использует два знака после запятой. Обе серии используют белый текст метки размером 10 пунктов.

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

## **Прочитать фактический текст меток данных**

Используйте [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) для получения текста, сформированного параметрами метки данных. Это полезно при извлечении меток для отчетов, поиске содержимого презентации или проверке сгенерированных диаграмм. В примере ниже формат метки данных по умолчанию ([data label format](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/)) объединяет имя категории, имя серии и значение. Одна точка форматирует своё значение как процент, а другая использует пользовательский текст из [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding).

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

Число, хранящееся в точке данных, остаётся `0.75`, даже когда её метка показывает `75%` вместе с именем категории и серии. Пользовательский текст заменяет сгенерированный текст метки. [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) возвращает полученную строку метки в любом случае. Проверяйте [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible) отдельно, как показано выше, если нужно извлекать только видимые метки.

## **Управление метками данных за пределами максимума оси**

Когда диапазон оси ограничивается вручную, некоторые точки данных могут превышать её максимум. Используйте [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) для управления тем, будут ли их метки данных показаны. Эта настройка меняет видимость меток; она не меняет диапазон оси или исходные значения данных.

В примере ниже создаётся 2D сгруппированная столбчатая диаграмма со значениями 60 и 120. В метод [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) передаётся `False`, а максимум вертикальной оси устанавливается в 100 с помощью [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue). На первом слайде разрешены метки за пределами максимума; копия этого слайда отключает их. Оба слайда сохраняются в `DataLabelsOverMaximum.pptx`.

Включите метки значений с помощью [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue). Настройка уровня диаграммы сама по себе не включает отображение значений и не переопределяет отключённое отображение значений отдельной метки. Этот пример включает значения для всей серии и использует [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition) для размещения меток у внешнего конца каждого столбца.

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

Следующие изображения показывают сохранённые слайды, отрендеренные Microsoft PowerPoint. При `True` метка **120** видна у верхней границы; при `False` она скрыта. Метка **60** остаётся видимой, максимум оси остаётся **100**, а вторая точка данных остаётся **120** в обеих ситуациях.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Этот пример использует 2D столбчатую диаграмму со значительной осью. Диаграммы без значительной оси, такие как круговые и кольцевые, не имеют максимума оси, который можно было бы ограничить таким образом.
{{% /alert %}}

## **Установить расстояние метки от оси**

Используйте [setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset) для управления расстоянием между метками оси категорий и самой осью. Значение представляет собой процент от максимального размера шрифта меток оси. Этот пример создаёт сгруппированную столбчатую диаграмму и задаёт смещение меток горизонтальной оси в 500. Эта настройка влияет на метки оси категорий, а не на метки, привязанные к отдельным точкам данных.

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

## **Регулировать расположение метки**

На круговой диаграмме регулируйте позиции меток данных, чтобы улучшить расстояние между ними и освободить место для линий‑выноски.

Этот пример отображает значение первой точки данных, размещает её метку за пределами сектора и регулирует её горизонтальное и вертикальное смещение с помощью [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) и [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY). Эти смещения задаются относительно ширины и высоты диаграммы соответственно.

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

![Круговая диаграмма с отрегулированным положением метки данных](pie-chart-adjusted-label.png)

## **Форматировать линии-выноски**

Когда метки круговой диаграммы находятся за пределами своих секторов, линии‑выноски помогают читателю сопоставить каждое значение с соответствующим сектором. Контрастный цвет и слегка утолщённая линия делают такие соединения более удобными для восприятия, а прозрачность и пунктирный стиль сохраняют их визуальную незаметность.

Используйте [getLeaderLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getLeaderLinesFormat) для форматирования линий‑выноски на уровне коллекции меток данных серии. Параметры в `series.getLabels().getLeaderLinesFormat().getLine()` применяются ко всей коллекции, а не к отдельной метке.

Этот пример создаёт круговую диаграмму с данными по умолчанию, отображает значения за пределами секторов и включает [setShowLeaderLines](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLeaderLines). Он перемещает две метки дальше от их секторов, используя смещения [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) и [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY), выраженные в долях ширины и высоты диаграммы. Входная презентация не требуется.

Линия‑выноска через [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) задаёт сплошной синий цвет с альфа‑значением 191 из 255, что даёт примерно 25 % прозрачности. [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) устанавливает толщину в 2 пункта, а [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) делает линию пунктирной.

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

    # Переместить две метки дальше от их секторов.
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

Включение линий‑выноски не гарантирует появление линии для каждой метки. Видимость зависит от размещения метки и поведения раскладки диаграммы. В этом примере две смещённые метки имеют видимые линии‑выноски; метки, оставшиеся рядом со своими секторами, их не требуют.

Следующее изображение показывает сохранённый `FormattedLeaderLines.pptx`, отрендеренный с помощью Aspose.Slides:

![Круговая диаграмма с синими, полупрозрачными пунктирными линиями-выносками, соединяющими две внешние метки с их сегментами](formatted-leader-lines.png)

## **Добавить несколько строк меток над столбчатой диаграммой**

Этот пример создаёт столбчатую диаграмму с двумя строками меток данных над областью построения. Серия A отображает видимые столбцы, тогда как серии B и C предоставляют дополнительные метки. Их столбцы скрыты за счёт удаления заливки и контура. Метод [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) выравнивает все три серии по центрам категорий.

Настройки [ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) резервируют место для строк меток. После того как [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) вычислит позиции по умолчанию, методы [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) и [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) сохраняют горизонтальное выравнивание и применяют вертикальные смещения для размещения меток в две строки. Числа остаются метками данных, привязанными к значениям серии; только заголовки строк являются отдельными текстовыми фигурами.

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
            # Скрыть столбцы B и C, но оставить их метки данных.
            series.getFormat().getFill().setFillType(FillType.NoFill)
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
            label_format = series.getLabels().getDefaultDataLabelFormat()
            label_format.setShowValue(True)
            label_format.getTextFormat().getPortionFormat().setFontHeight(12)
            label_fill = label_format.getTextFormat().getPortionFormat().getFillFormat()
            label_fill.setFillType(FillType.Solid)
            label_fill.getSolidFillColor().setColor(Color.BLACK)
            label_format.setPosition(LegendDataLabelPosition.InsideBase)

    # Выровнять все три серии по одинаковым центрам категорий.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(jpype.JByte(100))

    # Использовать меньше линий сетки для этого компактного примера.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setMajorUnit(10)

    # Зарезервировать место над областью построения для двух строк меток данных.
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
            # Сохранить положение по умолчанию по горизонтали. Y — это смещение от
            # позиции метки по умолчанию, выраженное в долях высоты диаграммы.
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

![Столбчатая диаграмма с двумя строками меток над областью построения](multiple-rows-of-labels.png)

## **Часто задаваемые вопросы**

**Как предотвратить наложение меток данных на плотных диаграммах?**

Сочетайте автоматическое размещение меток, линии‑выноски и уменьшенный размер шрифта; при необходимости скрывайте некоторые поля (например, категорию) или показывайте метки только для экстремальных значений или ключевых точек.

**Как отключить метки только для нулевых, отрицательных или пустых значений?**

Отфильтруйте точки данных перед включением меток и отключите отображение для значений 0, отрицательных значений или отсутствующих значений согласно определённому правилу.

**Как обеспечить единообразный стиль меток при экспорте в PDF/изображения?**

Явно задайте семейство шрифтов и размер, а также убедитесь, что шрифт доступен в среде рендеринга, чтобы избежать замещения.