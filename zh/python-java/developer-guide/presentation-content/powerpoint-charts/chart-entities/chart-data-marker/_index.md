---
title: 使用 Python 在演示文稿中管理图表数据标记
linktitle: 数据标记
type: docs
url: /zh/python-java/chart-data-marker/
keywords:
- 图表
- 数据点
- 标记
- 标记选项
- 标记大小
- 填充类型
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides 中为 Python（通过 Java）自定义图表数据标记，通过清晰的 Python 示例代码提升 PPT 和 PPTX 演示文稿的效果。"
---
## **概述**

本文说明了如何在 Aspose.Slides 中使用图表数据标记。它展示了如何创建图表、访问系列及其数据点、在数据点级别为标记应用图片填充、调整标记大小以及保存更新后的演示文稿。文中还指出，标准标记形状可通过 [MarkerStyleType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/markerstyletype/) 枚举获得，并且在将图表导出为光栅格式或 SVG 时，标记外观会被保留。

## **设置图表标记选项**
可以在特定系列的图表数据点上设置标记。要设置图表标记选项，请按以下步骤操作：

- 实例化 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类。
- 创建默认图表。
- 设置图片。
- 访问第一个图表系列。
- 添加新数据点。
- 将演示文稿写入磁盘。

以下示例在数据点级别设置图表标记选项。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

# 创建一个空的演示文稿。
presentation = Presentation()
try:
    # 访问第一张幻灯片
    slide = presentation.getSlides().get_Item(0)

    # 创建默认图表
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

    # 获取默认图表数据工作表索引。
    default_worksheet_index = 0

    # 获取图表数据工作簿。
    workbook = chart.getChartData().getChartDataWorkbook()

    # 删除示例系列
    chart.getChartData().getSeries().clear()

    # 添加新系列
    series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    # 加载第一张图片。
    desert_bytes = Path("Desert.jpg").read_bytes()
    desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

    # 加载第二张图片。
    tulips_bytes = Path("Tulips.jpg").read_bytes()
    tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

    # 访问第一个图表系列。
    series = chart.getChartData().getSeries().get_Item(0)

    # 添加数据点。
    value_cell = workbook.getCell(default_worksheet_index, 1, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 2, 1, 2.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    value_cell = workbook.getCell(default_worksheet_index, 3, 1, 3.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 4, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    # 更改图表系列标记大小。
    series.getMarker().setSize(15)

    # 保存带有图表的演示文稿
    presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**默认提供了哪些标记形状？**

提供标准形状（圆形、方形、菱形、三角形等）；列表由 [MarkerStyleType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/markerstyletype/) 类定义。如果需要非标准形状，可使用带图片填充的标记来模拟自定义视觉效果。

**在将图表导出为图像或 SVG 时，标记会被保留吗？**

会的。将图表渲染为 [光栅格式](/slides/zh/python-java/convert-powerpoint-to-png/) 或保存 [将形状保存为 SVG](/slides/zh/python-java/render-a-slide-as-an-svg-image/) 时，标记会保留其外观和设置，包括大小、填充和轮廓。