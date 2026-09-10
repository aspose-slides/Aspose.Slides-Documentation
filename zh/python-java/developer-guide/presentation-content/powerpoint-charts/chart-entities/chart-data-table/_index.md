---
title: 使用 Python 定制演示文稿中的图表数据表
linktitle: 数据表
type: docs
url: /zh/python-java/chart-data-table/
keywords:
- 图表数据
- 数据表
- 字体属性
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 Python 中自定义 PPT 和 PPTX 的图表数据表，提高演示文稿的效率和吸引力。"
---
## **概述**

本文介绍了如何在 Aspose.Slides 中使用图表数据表。它展示了如何为图表显示数据表并通过设置粗体样式和字体高度等字体属性来自定义其文本格式。示例演示了创建演示文稿、添加图表、启用图表数据表、应用字体设置以及保存更新后的演示文稿。  
它还简要回答了有关在图表数据表中显示图例键、导出时保留数据表、处理从现有演示文稿或模板加载的图表以及识别已启用数据表的图表等常见问题。

## **为图表数据表设置字体属性**

Aspose.Slides for Python via Java 允许您显示图表的数据表并更改其文本的字体属性。

1. 实例化 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类。
1. 向幻灯片添加图表。
1. 显示图表数据表。
1. 设置数据表文本的粗体样式和字体高度。
1. 保存修改后的演示文稿。

以下示例演示了这些步骤。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# 创建一个空的演示文稿。
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**我可以在图表数据表的数值旁显示小图例键吗？**

可以。数据表支持 [legend keys](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datatable/#setShowLegendKey)，您可以开启或关闭它们。

**导出演示文稿为 PDF、HTML 或图像时，数据表会被保留吗？**

会。Aspose.Slides 将图表渲染为幻灯片的一部分，因此导出的 [PDF](/slides/zh/python-java/convert-powerpoint-to-pdf/)/[HTML](/slides/zh/python-java/convert-powerpoint-to-html/)/[image](/slides/zh/python-java/convert-powerpoint-to-png/) 包含带有数据表的图表。

**来自模板文件的图表是否支持数据表？**

是的。对于任何从现有演示文稿或模板加载的图表，您可以使用图表的属性检查并更改数据表是否[is shown](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#hasDataTable)。

**如何快速找出文件中哪些图表启用了数据表？**

检查每个图表的属性，该属性指示数据表是否[is shown](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#hasDataTable)，并遍历幻灯片以确定哪些图表已启用数据表。