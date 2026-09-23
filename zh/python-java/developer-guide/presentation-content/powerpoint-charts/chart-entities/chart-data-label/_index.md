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
description: "了解如何使用 Aspose.Slides for Python via Java 在 PowerPoint 演示文稿中添加和格式化图表数据标签，以创建更具吸引力的幻灯片。"
---
## **介绍**

数据标签显示图表系列和单个数据点的信息，帮助读者识别数值并理解图表。本文说明如何格式化数值、显示百分比、读取标签文本、调整类目轴标签间距以及定位饼图标签。

## **在图表数据标签中设置数据精度**

使用[setNumberFormatOfValues](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#setNumberFormatOfValues)来格式化系列数值。此示例创建一个带默认数据的折线图，显示其数据表，并为第一系列启用数值标签。格式`#,##0.00`会显示千位分隔符和两位小数，但不会更改底层数值。

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

对于堆叠柱形图，计算每个数值在其类别总和中的百分比，并将文本分配给[getTextFrameForOverriding](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datalabel/#getTextFrameForOverriding)返回的文本框。此示例使用默认图表数据，并以8磅字体显示保留两位小数的百分比。总和为零的类别将被跳过，以避免除以零。如果图表数据更改，需要重新计算自定义标签文本。

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

当数值以分数形式存储时，使用[setNumberFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datalabelformat/#setNumberFormat)显示百分比。将`False`传递给[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource)可使标签格式独立于源单元格。

此示例创建一个 100% 堆叠柱形图，包含四个类别的红色和蓝色系列。每对数值加起来等于 1。标签格式`0.0%`会将 0.30 显示为 30.0%，而纵轴使用两位小数。两个系列的标签文字均为白色、10 磅。

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

## **读取数据标签的实际文字**

使用[getActualLabelText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datalabel/#getActualLabelText)获取由数据标签设置生成的文字。这在提取报告标签、搜索演示文稿内容或验证生成的图表时非常有用。在下面的示例中，默认的[data label format](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datalabelformat/)将每个类别名称、系列名称和数值组合在一起。一个点将其数值格式化为百分比，另一个则使用[getTextFrameForOverriding](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datalabel/#getTextFrameForOverriding)提供的自定义文字。

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

存储在数据点中的数值仍为`0.75`，即使其标签显示为`75%`并附带类别和系列名称。自定义文字会替换生成的标签文字。无论哪种情况，[getActualLabelText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datalabel/#getActualLabelText)都会返回最终的标签字符串。如上所示，若只想提取可见标签，需要单独检查[isVisible](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datalabel/#isVisible)。

## **设置标签与坐标轴的距离**

使用[setLabelOffset](https://reference.aspose.com/slides/zh/python-java/aspose.slides/axis/#setLabelOffset)控制类目轴标签与坐标轴之间的距离。该值以轴标签最大字体大小的百分比表示。此示例创建一个聚簇柱形图，并将水平轴标签偏移设为 500。此设置影响类目轴标签，而不是附加在单个数据点上的标签。

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

在饼图上，调整数据标签位置以改善间距并为引线留出空间。

此示例显示第一个数据点的数值，将其标签放置在扇形外部，并使用[setX](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datalabel/#setX)和[setY](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datalabel/#setY)调整水平和垂直偏移。这些偏移分别相对于图表宽度和高度。

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

![饼图的调整后数据标签位置](pie-chart-adjusted-label.png)

## **常见问题**

**如何防止在密集图表上出现标签重叠？**

结合自动标签布局、引线以及减小字体大小；如有必要，可隐藏某些字段（例如类别），或仅对极值或关键点显示标签。

**如何仅对零值、负值或空值禁用标签？**

在启用标签之前筛选数据点，并根据定义的规则关闭对值为 0、负值或缺失值的显示。

**如何在导出为 PDF/图片时确保标签样式一致？**

显式设置字体族和大小，并确认渲染环境中已安装该字体，以避免回退。