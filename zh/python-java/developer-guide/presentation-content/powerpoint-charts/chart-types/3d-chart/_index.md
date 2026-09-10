---
title: 使用 Python 在演示文稿中自定义 3D 图表
linktitle: 3D 图表
type: docs
url: /zh/python-java/3d-chart/
keywords:
- 3D 图表
- 旋转
- 深度
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via Java 中创建和自定义 3D 图表，支持 PPT 和 PPTX 文件——立即提升您的演示效果。"
---
## **概述**

本文说明如何通过配置[Rotation3D](https://reference.aspose.com/slides/zh/python-java/aspose.slides/rotation3d/)设置（如[setRotationX](https://reference.aspose.com/slides/zh/python-java/aspose.slides/rotation3d/#setRotationX)、[setRotationY](https://reference.aspose.com/slides/zh/python-java/aspose.slides/rotation3d/#setRotationY)、[setDepthPercents](https://reference.aspose.com/slides/zh/python-java/aspose.slides/rotation3d/#setDepthPercents)和[setRightAngleAxes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/rotation3d/#setRightAngleAxes)）来自定义 Aspose.Slides 中的 3D 图表。它演示了创建演示文稿、添加带默认数据的 3D 图表、应用所需的 3D 视图设置，并将修改后的演示文稿保存为 PPTX 文件的过程。

## **设置 3D 图表的 X 轴旋转、Y 轴旋转和深度**

Aspose.Slides for Python via Java 提供了一个简洁的 API 用于设置这些属性。下面的示例展示了如何设置 3D 图表的 X 旋转、Y 旋转和深度。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
2. 访问第一张幻灯片。
3. 添加一个带默认数据的图表。
4. 设置 3D 旋转属性。
5. 将修改后的演示文稿写入 PPTX 文件。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # 访问第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 添加一个带默认数据的图表。
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # 设置图表数据工作表索引。
    default_worksheet_index = 0

    # 获取图表数据工作簿。
    workbook = chart.getChartData().getChartDataWorkbook()

    # 添加系列。
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # 添加类别。
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # 设置 3D 旋转属性。
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # 访问第二个图表系列。
    series = chart.getChartData().getSeries().get_Item(1)

    # 填充系列数据。
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # 保存演示文稿。
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**Aspose.Slides 中哪些图表类型支持 3D 模式？**

Aspose.Slides 支持柱形图的 3D 变体，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 和 100% Stacked Column 3D，以及通过[ChartType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/charttype/)类公开的相关 3D 类型。要获取准确的最新列表，请在已安装版本的 API 参考中查看[ChartType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/charttype/)成员。

**我可以为报告或网页获取 3D 图表的栅格图像吗？**

可以。您可以通过[chart API](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getImage)将图表导出为图像，或将整个幻灯片渲染为 PNG 或 JPEG 等格式（参见[/slides/zh/python-java/convert-powerpoint-to-png/]）。当您需要像素级预览或想在文档、仪表板或网页中嵌入图表而无需 PowerPoint 时，这非常有用。

**构建和渲染大型 3D 图表的性能如何？**

性能取决于数据量和视觉复杂度。为了获得最佳效果，请尽量减少 3D 效果，避免在墙面和绘图区使用大量纹理，尽可能限制每个系列的数据点数量，并将渲染输出设置为与目标显示或打印需求相匹配的分辨率和尺寸。