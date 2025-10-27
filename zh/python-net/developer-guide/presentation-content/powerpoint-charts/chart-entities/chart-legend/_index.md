---
title: Customize Chart Legends in Presentations with Python
linktitle: Chart Legend
type: docs
url: /zh/python-net/chart-legend/
keywords:
- chart legend
- legend position
- font size
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 通过 .NET 自定义图表图例，以针对 PowerPoint 和 OpenDocument 演示文稿的图例格式进行优化。"
---

## **概览**

Aspose.Slides for Python 提供对图表图例的完整控制，让您能够使数据标签清晰、适合演示。您可以显示或隐藏图例，选择其在幻灯片上的位置，并调整布局以避免与绘图区重叠。该 API 允许您设置文本和标记的样式、细调内边距和背景，并格式化边框和填充以匹配主题。开发者还可以访问各个图例项以重新命名或过滤，确保仅显示最相关的系列。借助这些功能，您的图表保持可读、一致，并符合演示文稿的设计标准。

## **图例定位**

使用 Aspose.Slides，您可以快速控制图表图例出现的位置以及其在幻灯片布局中的适配方式。了解如何精确放置图例。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例。
1. 获取幻灯片的引用。
1. 向幻灯片添加图表。
1. 设置图例属性。
1. 将演示文稿保存为 PPTX 文件。

下面的示例演示了如何设置图表图例的位置和大小：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:

    # Get a reference to the slide.
    slide = presentation.slides[0]

    # Add a clustered column chart to the slide.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # Set the legend properties.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Save the presentation to disk.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **设置图例字体大小**

图例的可读性应与其解释的数据相匹配。本节展示如何调整图例字体大小，以匹配演示文稿的排版并提升可访问性。

1. 实例化 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类。
1. 创建图表。
1. 设置字体大小。
1. 将演示文稿保存到磁盘。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **为单个图例项设置字体大小**

Aspose.Slides 允许您通过格式化单个条目来微调图表图例的外观。下面的示例展示如何定位特定的图例项并设置其属性，而不影响其他图例内容。

1. 实例化 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类。
1. 创建图表。
1. 访问图例条目。
1. 设置条目属性。
1. 将演示文稿保存到磁盘。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    text_format = chart.legend.entries[1].text_format

    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**我能否启用图例，使图表自动为其分配空间而不是覆盖？**

可以。使用非覆盖模式（[overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) = `false`）；在此情况下，绘图区域会收缩以容纳图例。

**我能否制作多行图例标签？**

可以。当空间不足时，长标签会自动换行；通过在系列名称中插入换行符可以实现强制换行。

**如何让图例遵循演示文稿主题的配色方案？**

不要为图例或其文本显式设置颜色、填充或字体。这样它们会继承主题，并在主题更改时自动更新。