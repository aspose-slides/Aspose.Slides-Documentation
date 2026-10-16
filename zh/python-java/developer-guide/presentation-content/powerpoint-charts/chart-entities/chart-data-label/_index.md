---
title: 使用 Python 在演示文稿中管理图表数据标签
linktitle: 数据标签
type: docs
url: /zh/python-java/chart-data-label/
keywords:
- 图表
- 数据标签
- 数据精度
- 百分比
- 标签距离
- 标签位置
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "学习使用 Aspose.Slides for Python via Java 在 PowerPoint 演示文稿中添加和格式化图表数据标签，以创建更具吸引力的幻灯片。"
---
## **简介**

数据标签显示有关图表系列和单个数据点的信息，帮助读者识别数值并理解图表。本文介绍如何格式化值、显示百分比、读取标签文本、控制超过坐标轴最大值的标签、调整类别坐标轴标签间距，以及定位饼图标签。

## **在图表数据标签中设置数据精度**

使用 [setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) 来格式化系列值。此示例创建一个带有默认数据的折线图，显示其数据表，并为第一系列启用数值标签。格式 `#,##0.00` 显示千位分隔符和两位小数，而不更改底层值。

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

## **将百分比显示为标签**

对于堆叠柱形图，计算每个值相对于其类别总和的百分比，并将文本分配给由 [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) 返回的文本框。本示例使用默认图表数据，并以8磅字体显示保留两位小数的百分比。总计为零的类别将被跳过，以避免除以零。如果图表数据更改，需要重新计算自定义标签文本。

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

## **在图表数据标签中设置百分号**

当值以分数形式存储时，使用 [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) 来显示百分比。向 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) 传递 `False`，以使标签格式独立于源单元格。

此示例创建一个100%堆叠柱形图，包含红色和蓝色系列，跨越四个类别。每对值的总和为1。标签格式 `0.0%` 将 0.30 显示为 30.0%，而垂直轴使用两位小数。两个系列的标签文本均为白色、10磅。

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

## **读取数据标签的实际文本**

使用 [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) 来获取数据标签设置生成的文本。这在为报告提取标签、搜索演示文稿内容或验证生成的图表时非常有用。在下面的示例中，默认的 [数据标签格式](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) 将每个类别名称、系列名称和数值组合在一起。一个数据点将其数值格式化为百分比，另一个则使用来自 [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) 的自定义文本。

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

数据点中存储的数值仍为 `0.75`，即使其标签显示为 `75%` 并附带类别和系列名称。自定义文本会替代生成的标签文本。无论哪种情况，[getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) 都会返回相应的标签字符串。如上所示，在只想提取可见标签时，需要单独检查 [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible)。

## **控制超过坐标轴最大值的数据显示标签**

当手动限制坐标轴范围时，某些数据点可能会超过其最大值。使用 [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) 来控制是否显示这些数据标签。此设置仅改变标签可见性，不会更改坐标轴范围或底层数据值。

下面的示例创建一个值为 60 和 120 的二维聚簇柱形图。它向 [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) 传递 `False`，并在垂直轴上使用 [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) 将最大值设为 100。第一张幻灯片允许超出最大值的标签显示；该幻灯片的副本则禁用此功能。两张幻灯片均保存在 `DataLabelsOverMaximum.pptx` 中。

使用 [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) 启用数值标签。图表级别的设置本身并不会启用数值显示，也不会覆盖单个标签已禁用的数值显示。本示例为整个系列启用数值，并使用 [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition) 将标签放置在每个柱形的外端。

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

以下图像展示了 Microsoft PowerPoint 渲染的已保存幻灯片。设置为 `True` 时，标签 **120** 在上边界可见；设置为 `False` 时，则隐藏。标签 **60** 保持可见，坐标轴最大值保持为 **100**，第二个数据点在两种情况下均为 **120**。

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
此示例使用带值轴的二维柱形图。不带值轴的图表，如饼图和环形图，没有可以这样限制的坐标轴最大值。
{{% /alert %}}

## **设置标签与坐标轴的距离**

使用 [setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset) 来控制类别坐标轴标签与坐标轴之间的距离。该值是坐标轴标签最大字体大小的百分比。此示例创建一个聚簇柱形图，并将水平轴标签偏移设置为 500。此设置影响类别坐标轴的标签，而不是附加到单个数据点的标签。

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

## **调整标签位置**

在饼图上，调整数据标签位置以改善间距并为引导线留出空间。

此示例显示第一个数据点的数值，将其标签放置在切片外部，并使用 [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) 和 [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) 调整水平和垂直偏移。这些偏移分别相对于图表的宽度和高度。

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

![调整后数据标签位置的饼图](pie-chart-adjusted-label.png)

## **设置引导线格式**

当饼图标签位于切片外部时，引导线帮助读者将每个数值与对应切片对应。使用对比色和稍粗的线条可以使连接更易辨认，而透明度和虚线样式则保持线条视觉上不突兀。

使用 [getLeaderLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getLeaderLinesFormat) 在系列数据标签集合层面设置引导线格式。`series.getLabels().getLeaderLinesFormat().getLine()` 中的设置适用于整个集合，而非单个标签。

此示例创建一个默认数据的饼图，在切片外显示数值，并启用 [setShowLeaderLines](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLeaderLines)。它使用 [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) 和 [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) 偏移，将两个标签进一步移离切片，偏移以图表宽高的比例表示。无需输入演示文稿。

该线条的 [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) 将填充设置为纯蓝色，透明度为 191/255，约为 25% 透明。 [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) 将粗细设为 2 磅， [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) 将线条设置为虚线。

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

    # 将两个标签远离它们的切片。
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

启用引导线并不能保证每个标签都有对应的线条。可见性取决于标签位置和图表的布局行为。在本示例中，两个偏移的标签拥有可见的引导线；靠近切片的标签则不需要。

下图展示了使用 Aspose.Slides 渲染的已保存 `FormattedLeaderLines.pptx`：

![蓝色半透明虚线引导线将两个外部标签连接到切片的饼图](formatted-leader-lines.png)

## **在柱形图上方添加多行数据标签**

此示例创建一个柱形图，在绘图区域上方放置两行数据标签。系列 A 显示可见的柱形，而系列 B 和系列 C 提供额外的标签。通过去除填充和轮廓来隐藏它们的柱形。 [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) 方法使所有三条系列在同一类别中心对齐。

[ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) 设置为标签行预留空间。在 [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) 计算默认位置后，使用 [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) 和 [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) 保持水平对齐并施加垂直偏移，将标签排列成两行。这些数字仍然是链接到系列数值的数据标签；仅行标题是独立的文本形状。

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
            # 隐藏 B 和 C 的柱形，但保留其数据标签。
            series.getFormat().getFill().setFillType(FillType.NoFill)
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
            label_format = series.getLabels().getDefaultDataLabelFormat()
            label_format.setShowValue(True)
            label_format.getTextFormat().getPortionFormat().setFontHeight(12)
            label_fill = label_format.getTextFormat().getPortionFormat().getFillFormat()
            label_fill.setFillType(FillType.Solid)
            label_fill.getSolidFillColor().setColor(Color.BLACK)
            label_format.setPosition(LegendDataLabelPosition.InsideBase)

    # 将所有三个系列对齐到相同的类别中心。
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(jpype.JByte(100))

    # 在此紧凑示例中使用更少的网格线。
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setMajorUnit(10)

    # 为绘图区上方保留两行数据标签的空间。
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
            # 保持默认的水平位置。Y 是相对于
            # 默认标签位置的偏移量，以图表高度的比例表示。
            data_label.setX(0)
            data_label.setY(row_top - data_label.getActualY() / chart.getHeight())

        # 仅行标题是单独的文本形状。
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

![绘图区域上方有两行数据标签的柱形图](multiple-rows-of-labels.png)

## **常见问题**

**如何防止在密集图表上数据标签重叠？**

结合自动标签布局、引导线和缩小字体大小；必要时隐藏某些字段（例如类别），或仅对极值或关键点显示标签。

**如何仅对零、负值或空值禁用标签？**

在启用标签之前过滤数据点，并根据定义的规则对数值为 0、负值或缺失的点关闭显示。

**在导出为 PDF/图片时，如何确保标签样式的一致性？**

显式设置字体族和大小，并确认渲染环境中存在该字体，以避免回退。