---
title: 使用 Python 在演示文稿中自定义图表图例
linktitle: 图例
type: docs
url: /zh/python-net/chart-legend/
keywords:
- 图表图例
- 图例位置
- 字体大小
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 自定义图表图例，以针对 PowerPoint 和 OpenDocument 演示文稿进行优化，并提供定制的图例格式。"
---

## **概述**

Aspose.Slides for Python 提供对图表图例的完整控制，使数据标签清晰、适合演示。您可以显示或隐藏图例，选择其在幻灯片上的位置，并调整布局以防止与绘图区域重叠。该 API 允许您设置文本和标记的样式，微调填充和背景，以及格式化边框和填充以匹配主题。开发者还可以访问各个图例项，重命名或过滤它们，确保仅显示最相关的系列。借助这些功能，您的图表保持可读、一致，并符合演示设计标准。

## **图例定位**

使用 Aspose.Slides，您可以快速控制图例出现的位置以及它如何适应幻灯片布局。了解如何精确放置图例。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例。
1. 获取对幻灯片的引用。
1. 向幻灯片添加图表。
1. 设置图例属性。
1. 将演示文稿保存为 PPTX 文件。

下面的示例演示了如何设置图例的位置和大小：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 创建 Presentation 类的实例。
with slides.Presentation() as presentation:

    # 获取幻灯片的引用。
    slide = presentation.slides[0]

    # 向幻灯片添加聚簇柱形图表。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # 设置图例属性。
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # 将演示文稿保存到磁盘。
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **设置图例字体大小**

图例的文字应与其说明的数据一样易读。本节展示如何调整图例的字体大小，以匹配演示文稿的排版并提升可访问性。

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

## **设置图例条目的字体大小**

Aspose.Slides 允许通过格式化单个条目来微调图例外观。下面的示例演示如何定位特定图例项并设置其属性，而不影响其他条目。

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

**我可以启用图例，使图表自动为其分配空间而不是覆盖吗？**

可以。使用非覆盖模式（[overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) = `false`）；此时绘图区域会缩小以容纳图例。

**我可以创建多行图例标签吗？**

可以。当空间不足时，长标签会自动换行；通过在系列名称中插入换行符也支持强制换行。

**如何让图例遵循演示文稿主题的配色方案？**

不要为图例或其文本设置显式的颜色/填充/字体。它们将继承主题，并在设计更改时自动更新。