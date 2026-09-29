---
title: Управление метками данных диаграмм в презентациях с использованием Python
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
description: "Узнайте, как добавлять и форматировать метки данных диаграмм в презентациях PowerPoint с использованием Aspose.Slides для Python через Java, чтобы сделать слайды более привлекательными."
---
## **Введение**

Метки данных отображают информацию о серииях диаграммы и отдельных точках данных, помогая читателям идентифицировать значения и понимать диаграмму. В этой статье объясняется, как форматировать значения, отображать проценты, читать текст метки, управлять метками за пределами максимума оси, регулировать интервал меток категориальной оси и позиционировать метки круговой диаграммы.

## **Установить точность данных в метках диаграмм**

Используйте [setNumberFormatOfValues](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) для форматирования значений серий. Этот пример создаёт линейную диаграмму с данными по умолчанию, отображает её таблицу данных и включает метки значений для первой серии. Формат `#,##0.00` выводит разделитель тысяч и два знака после запятой, не изменяя исходные значения.

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

Для сложенной столбчатой диаграммы вычислите каждый пункт как процент от общей суммы своей категории и задайте текст фрейму, возвращаемому методом [getTextFrameForOverriding](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datalabel/#getTextFrameForOverriding). Этот пример использует данные диаграммы по умолчанию и выводит проценты с двумя знаками после запятой шрифтом 8 пунктов. Категории с суммой, равной нулю, пропускаются, чтобы избежать деления на ноль. При изменении данных диаграммы пересчитайте пользовательский текст метки.

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

## **Установить знак процента в метках диаграмм**

Когда значения хранятся в виде дробей, используйте [setNumberFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datalabelformat/#setNumberFormat) для отображения процентов. Передайте `False` в [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource), чтобы применить формат метки независимо от исходных ячеек.

В этом примере создаётся 100 % сложенная столбчатая диаграмма с красными и синими сериями в четырёх категориях. Каждая пара значений в сумме даёт 1. Формат метки `0.0%` выводит 0.30 как 30.0 %, а вертикальная ось использует два знака после запятой. Обе серии используют белый текст меток размером 10 пунктов.

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

Используйте [getActualLabelText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datalabel/#getActualLabelText) для получения текста, сформированного настройками метки данных. Это полезно при извлечении меток для отчётов, поиске содержимого презентаций или проверке сгенерированных диаграмм. В примере ниже формат метки данных по умолчанию ([data label format](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datalabelformat/)) комбинирует имя категории, имя серии и значение. Одна точка форматирует своё значение как процент, другая использует пользовательский текст из [getTextFrameForOverriding](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datalabel/#getTextFrameForOverriding).

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

Число, хранящееся в точке данных, остаётся `0.75`, даже если её метка отображает `75 %` вместе с названиями категории и серии. Пользовательский текст заменяет сгенерированный текст метки. [getActualLabelText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datalabel/#getActualLabelText) возвращает полученную строку метки в любом случае. Проверяйте [isVisible](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datalabel/#isVisible) отдельно, как показано выше, когда нужно извлекать только видимые метки.

## **Управление метками данных за пределами максимума оси**

Когда диапазон оси ограничен вручную, некоторые точки данных могут превышать её максимум. Используйте [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) для управления тем, показываются ли их метки. Эта настройка меняет видимость меток; она не меняет диапазон оси и не изменяет исходные значения.

В примере ниже создаётся 2‑D сгруппированная столбчатая диаграмма со значениями 60 и 120. Метод [setAutomaticMaxValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/axis/#setAutomaticMaxValue) получает `False`, а [setMaxValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/axis/#setMaxValue) задаёт максимум 100 на вертикальной оси. На первом слайде метки допускаются за пределами максимума; копия этого слайда отключает их. Оба слайда сохраняются в `DataLabelsOverMaximum.pptx`.

Включите метки значений с помощью [setShowValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datalabelformat/#setShowValue). Настройка уровня диаграммы не включает отображение значений автоматически и не переопределяет отключённый вывод отдельных меток. В этом примере включаются значения для всей серии и используется [setPosition](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datalabelformat/#setPosition) для размещения меток у наружного конца каждого столбца.

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

На следующих изображениях показаны сохранённые слайды, отрисованные Microsoft PowerPoint. При `True` метка **120** видна у верхней границы; при `False` она скрыта. Метка **60** остаётся видимой, максимум оси остаётся **100**, а второе значение данных остаётся **120** в обоих случаях.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Этот пример использует 2‑D столбчатую диаграмму со значительной осью. Диаграммы без значительной оси, такие как круговые и кольцевые, не имеют максимума оси, который можно было бы ограничивать таким способом.
{{% /alert %}}

## **Установить расстояние метки от оси**

Используйте [setLabelOffset](https://reference.aspose.com/slides/ru/python-java/aspose.slides/axis/#setLabelOffset) для контроля расстояния между метками категориальной оси и самой осью. Значение задаётся в процентах от максимального размера шрифта меток оси. Этот пример создаёт сгруппированную столбчатую диаграмму и задаёт смещение меток горизонтальной оси равным 500. Настройка влияет на метки категориальной оси, а не на метки, привязанные к отдельным точкам данных.

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

## **Регулировка расположения метки**

На круговой диаграмме скорректируйте позиции меток данных, чтобы улучшить промежутки и освободить место для линий‑выноски.

В этом примере отображается значение первой точки, её метка помещается за пределы сектора, а горизонтальные и вертикальные смещения регулируются через [setX](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datalabel/#setX) и [setY](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datalabel/#setY). Эти смещения задаются относительно ширины и высоты диаграммы соответственно.

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

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **Часто задаваемые вопросы**

**Как предотвратить наложение меток данных на плотных диаграммах?**  
Сочетайте автоматическое размещение меток, линии‑выноски и уменьшенный размер шрифта; при необходимости скрывайте некоторые поля (например, категорию) или показывайте метки только для экстремальных или ключевых точек.

**Как отключить метки только для нулевых, отрицательных или пустых значений?**  
Отфильтруйте точки данных перед включением меток и отключите отображение для значений 0, отрицательных или отсутствующих согласно заданному правилу.

**Как обеспечить единообразный стиль меток при экспорте в PDF/изображения?**  
Явно задайте семейство шрифта и размер, а также проверьте, что шрифт доступен в среде рендеринга, чтобы избежать замен.