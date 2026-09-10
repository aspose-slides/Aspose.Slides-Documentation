---
title: 使用 Python 在演示文稿中自定义图表图例
linktitle: 图表图例
type: docs
url: /zh/python-java/chart-legend/
keywords:
- 图表图例
- 图例位置
- 字体大小
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 自定义图表图例，以通过定制的图例格式优化 PowerPoint 演示文稿。"
---
## **概述**

Aspose.Slides 提供了在 PowerPoint 演示文稿中自定义图表图例的选项。本文展示了如何定位和设置图例的大小、为整个图例设置字体大小，以及对单个图例条目应用格式。

本文还在 FAQ 中涵盖了若干相关行为，包括使用非覆盖模式使绘图区域为图例留出空间、允许长图例标签自动换行或使用换行符，以及在未显式设置文本和填充时让图例格式继承演示文稿主题。

## **图例定位**

要设置图例属性，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
2. 获取幻灯片的引用。  
3. 向幻灯片添加图表。  
4. 设置图例属性。  
5. 将演示文稿保存为 PPTX 文件。

下面的示例设置了图表图例的位置和大小。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# 创建一个空白演示文稿。
presentation = Presentation()
try:
    # 获取幻灯片的引用。
    slide = presentation.getSlides().get_Item(0)

    # 向幻灯片添加一个聚簇柱形图表。
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # 设置图例属性。
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # 将演示文稿保存到磁盘。
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **设置图例的字体大小**

Aspose.Slides for Python via Java 允许您设置图例的字体大小。请按以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类。  
2. 创建默认图表。  
3. 设置字体大小。  
4. 设置最小轴值。  
5. 设置最大轴值。  
6. 将演示文稿保存到磁盘。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# 创建一个空白演示文稿。
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **设置单个图例条目的字体大小**

Aspose.Slides for Python via Java 允许您设置单个图例条目的字体大小。请按以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类。  
2. 创建默认图表。  
3. 访问图例条目。  
4. 设置字体大小。  
5. 将演示文稿保存到磁盘。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# 创建一个空白演示文稿。
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**我可以启用图例，使图表自动为其分配空间，而不是覆盖吗？**

是的。使用 setOverlay 并将其设为 `False` 可启用非覆盖模式；此时，绘图区域会收缩以容纳图例。

**我可以制作多行图例标签吗？**

是的。当空间不足时，长标签会自动换行；通过在系列名称中使用换行符可以强制换行。

**如何让图例遵循演示文稿主题的配色方案？**

不要为图例或其文本设置显式的颜色、填充或字体。这样它们将继承主题的设置，并在更改设计时正确更新。