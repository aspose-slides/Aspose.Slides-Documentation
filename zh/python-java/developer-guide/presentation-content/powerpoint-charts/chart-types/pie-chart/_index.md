---
title: 使用 Python via Java 在演示文稿中自定义饼图
linktitle: 饼图
type: docs
url: /zh/python-java/pie-chart/
keywords:
- 饼图
- 管理图表
- 自定义图表
- 图表选项
- 图表设置
- 绘图选项
- 切片颜色
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python via Java 中创建并自定义饼图。配置二级绘图、显示数据标签，并在 PowerPoint 中应用自动切片颜色。"
---
## **Overview**

本文说明了如何在 Aspose.Slides 中使用饼图。它展示了如何为 Pie of Pie 和 Bar of Pie 图表配置二级绘图选项，以及如何为标准饼图启用自动切片着色。

这些示例侧重于图表自定义任务，例如向幻灯片添加图表、调整系列和标签设置、使用自定义类别和值替换默认图表数据以及保存更新后的演示文稿。

## **二级绘图选项（适用于 Pie of Pie 和 Bar of Pie 图表）**

Aspose.Slides for Python via Java 支持 Pie of Pie 和 Bar of Pie 图表的二级绘图选项。这些选项控制二级绘图的大小以及数据点在两个绘图之间的分割方式。

以下示例在新演示文稿中创建一个 Pie of Pie 图表，并将数据点值显示为标签。[setSecondPieSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSecondPieSize) 方法将二级绘图的大小设置为主绘图的 149%。[setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) 选择基于百分比的拆分方式，且 [setPieSplitPosition](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) 将阈值设置为 53%。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)
    series = chart.getChartData().getSeries().get_Item(0)

    # 显示值并配置二级绘图。
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **选择二级绘图的类别**

当您希望在二级绘图中对特定类别进行分组且不考虑其百分比值时，可使用自定义拆分。例如，销售报告可能会将 Online 和 Events 放在一起显示，以便读者比较这两个渠道，尽管它们分别占总销售额的 35% 和 10%。

调用 [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) 并使用 [PieSplitType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/piesplittype/#Custom)，通过 [getPieSplitCustomPoints](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) 选择点。集合的 [add](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#add) 方法接受系列中的零基索引；使用 [addItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#addItem) 添加数据点对象。在本例中，索引 1 选中 Online，索引 3 选中 Events。Partners 也被临时添加，然后使用 [removeItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#removeItem) 将其排除。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200)

    # 用渠道销售数据替换默认数据。
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(0, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setPieSplitBy(PieSplitType.Custom)
    series_group.setColorVaried(True)

    # 通过零基索引选择 Online，并通过数据点对象选择 Events。
    series_group.getPieSplitCustomPoints().add(1)
    series_group.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3))

    # 在不删除其源数据的情况下，从选择中排除 Partners。
    series_group.getPieSplitCustomPoints().add(2)
    series_group.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2))

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Online（35）和 Events（10）在二级绘图中显示为独立的切片。在主绘图中，它们与 Retail（40）和 Partners（15）一起被表示为一个值为 45 的合并切片。从自定义选择中移除 Partners 后，它仍保留在主绘图中；不会从图表的源数据中删除该类别或其数值。

下图显示了在 PowerPoint 中保存的演示文稿：

![二级绘图中包含 Online 和 Events 的 Pie of Pie 图表，以及它们在主绘图中合并后值为 45 的显示](pie_of_pie_custom.png)

## **设置自动饼图切片颜色**

Aspose.Slides for Python via Java 可以自动为饼图切片分配不同的颜色。以下示例创建了一个带居中标题的饼图，并用三个季度类别及其数值替换默认数据。[setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) 方法将数值 20、50 和 30 显示为标签，而 [setColorVaried](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setColorVaried) 为每个切片启用不同颜色。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # 添加居中的图表标题。
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # 使用第一个工作表替换默认数据。
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    # 显示数值并为切片分配不同的颜色。
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getParentSeriesGroup().setColorVaried(True)

    presentation.save("pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**是否支持 Pie of Pie 和 Bar of Pie 变体？**

是的，库 [supports](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 二级绘图用于饼图，包括 Pie of Pie 和 Bar of Pie 类型。

**我可以仅将图表导出为图像（例如 PNG）吗？**

是的，您可以 [export the chart itself as an image](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage)（例如 PNG），而无需导出整个演示文稿。