---
title: 在 Python 中自定义演示文稿图表的绘图区
linktitle: 绘图区
type: docs
url: /zh/python-net/chart-plot-area/
keywords:
- chart
- plot area
- plot area width
- plot area height
- plot area size
- layout mode
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 自定义 PowerPoint 和 OpenDocument 演示文稿中的图表绘图区。轻松提升幻灯片视觉效果。"
---

## **获取图表绘图区的宽度和高度**
Aspose.Slides for Python via .NET 提供了一个简单的 API。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 访问第一张幻灯片。
1. 添加带有默认数据的图表。
1. 在获取实际值之前调用方法 IChart.ValidateChartLayout()。
1. 获取图表元素相对于图表左上角的实际 X 位置（左）。
1. 获取图表元素相对于图表左上角的实际顶部位置。
1. 获取图表元素的实际宽度。
1. 获取图表元素的实际高度。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
	
	# 保存带有图表的演示文稿
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```




## **设置图表绘图区的布局模式**
Aspose.Slides for Python via .NET 提供了一个简单的 API 来设置图表绘图区的布局模式。属性 **LayoutTargetType** 已添加到 **ChartPlotArea** 和 **IChartPlotArea** 类。如果绘图区的布局是手动定义的，则该属性指定是否通过内部（不包括轴和轴标签）或外部（包括轴和轴标签）来布局绘图区。**LayoutTargetType** 枚举中定义了两种可能的值。

- **LayoutTargetType.Inner** - 指定绘图区大小应决定绘图区的大小，不包括刻度线和轴标签。
- **LayoutTargetType.Outer** - 指定绘图区大小应决定绘图区的大小，包括刻度线和轴标签。

以下是示例代码。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.plot_area.as_i_layoutable.x = 0.2
    chart.plot_area.as_i_layoutable.y = 0.2
    chart.plot_area.as_i_layoutable.width = 0.7
    chart.plot_area.as_i_layoutable.height = 0.7
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER

    presentation.save("SetLayoutMode_outer.pptx", slides.export.SaveFormat.PPTX)
```