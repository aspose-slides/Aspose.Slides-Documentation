---
title: "使用 Python via Java 定制演示文稿中的饼图"
linktitle: "饼图"
type: docs
url: /zh/python-java/pie-chart/
keywords:
- "饼图"
- "管理图表"
- "定制图表"
- "图表选项"
- "图表设置"
- "绘图选项"
- "切片颜色"
- "PowerPoint"
- "演示文稿"
- "Python"
- "Java"
- "Aspose.Slides"
description: "了解如何使用 Aspose.Slides 在 Python via Java 中创建和定制饼图，并导出为 PowerPoint，让您在几秒钟内提升数据叙事。"
---
## **概述**

本文说明了如何在 Aspose.Slides 中使用饼图。它展示了如何为 Pie of Pie 和 Bar of Pie 图表配置二级绘图选项，以及如何为标准饼图启用自动切片着色。

示例侧重于实际的图表自定义步骤，例如向幻灯片添加图表，调整系列和标签设置，用自定义类别和数值替换默认图表数据，并保存更新后的演示文稿。

## **Pie of Pie 和 Bar of Pie 图表的二级绘图选项**

Aspose.Slides for Python via Java 支持 Pie of Pie 和 Bar of Pie 图表的二级绘图选项。本节展示如何使用 Aspose.Slides 指定这些选项。请按以下步骤操作：

1. 实例化一个[Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/)对象。
1. 向幻灯片添加图表。
1. 指定图表的二级绘图选项。
1. 将演示文稿写入磁盘。

下面的示例设置了 Pie of Pie 图表的不同属性。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

# 创建 Presentation 类的实例。
presentation = Presentation()
try:
    # 向幻灯片添加图表。
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

    # 设置不同的属性。
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    # 将演示文稿写入磁盘。
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **设置自动饼图切片颜色**

Aspose.Slides for Python via Java 提供了一个简单的 API 用于设置自动饼图切片颜色。以下示例演示如何应用这些设置。

1. 创建一个[Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/)类的实例。
1. 访问第一张幻灯片。
1. 添加带有默认数据的图表。
1. 设置图表标题。
1. 设置图表数据工作表的索引。
1. 获取图表数据工作簿。
1. 删除默认的系列和类别。
1. 添加新类别。
1. 添加新系列。
1. 将新系列设置为显示数值。

将修改后的演示文稿写入 PPTX 文件。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# 创建 Presentation 类的实例。
presentation = Presentation()
try:
    # 添加带有默认数据的图表。
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # 设置图表标题。
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # 设置图表数据工作表的索引。
    default_worksheet_index = 0

    # 获取图表数据工作簿。
    workbook = chart.getChartData().getChartDataWorkbook()

    # 删除默认的系列和类别。
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # 添加新类别。
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # 添加新系列。
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # 填充系列数据。
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # 将新系列设置为显示数值。
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**是否支持 “Pie of Pie” 与 “Bar of Pie” 变体？**

是的，库[支持](https://reference.aspose.com/slides/zh/python-java/aspose.slides/charttype/)饼图的二级绘图，包括 “Pie of Pie” 和 “Bar of Pie” 类型。

**我能否仅将图表导出为图像（例如 PNG）？**

是的，您可以[将图表本身导出为图像](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getImage)（如 PNG），而无需导出整个演示文稿。