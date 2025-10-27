---
title: 自定义 Python 演示文稿中图表的绘图区域
linktitle: 绘图区域
type: docs
url: /zh/python-net/developer-guide/presentation-content/powerpoint-charts/chart-entities/chart-plot-area/
keywords:
- 图表
- 绘图区域
- 绘图区域宽度
- 绘图区域高度
- 绘图区域大小
- 布局模式
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 演示文稿中自定义图表绘图区域。轻松提升幻灯片视觉效果。"
---

## **获取图表绘图区域的宽度和高度**
Aspose.Slides for Python via .NET 提供了一个简单的 API 用于 .

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 访问第一张幻灯片。
3. 添加一个带默认数据的图表。
4. 在获取实际值之前调用 IChart.ValidateChartLayout() 方法。
5. 获取图表元素相对于图表左上角的实际 X 位置（左）。
6. 获取图表元素相对于图表左上角的实际 Y 位置（上）。
7. 获取图表元素的实际宽度。
8. 获取图表元素的实际高度。

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
	
	# Save presentation with chart
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **设置图表绘图区域的布局模式**
Aspose.Slides for Python via .NET 提供了一个简便的 API 来设置图表绘图区域的布局模式。属性 **LayoutTargetType** 已添加至 **ChartPlotArea** 和 **IChartPlotArea** 类。如果手动定义绘图区域的布局，此属性指定是按绘图区域内部（不包括轴线和轴标签）还是外部（包括轴线和轴标签）进行布局。该枚举 **LayoutTargetType** 定义了两个可能的取值。

- **LayoutTargetType.Inner** - 指定绘图区域的大小应决定绘图区域的尺寸，不包括刻度线和轴标签。
- **LayoutTargetType.Outer** - 指定绘图区域的大小应决定绘图区域、刻度线以及轴标签的尺寸。

Sample code is given below.

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

## **常见问题**

**实际的 actual_x、actual_y、actual_width 和 actual_height 单位是什么？**

单位是点（points）；1 英寸 = 72 点。这些是 Aspose.Slides 使用的坐标单位。

**在内容上，绘图区域与图表区域有什么区别？**

绘图区域是数据绘制区域（系列、网格线、趋势线等）；图表区域则包括周围的元素（标题、图例等）。在 3D 图表中，绘图区域还包括墙面/底面及坐标轴。

**在手动布局时，绘图区域的 X、Y、宽度和高度如何解释？**

它们是相对于图表整体尺寸的比例（0–1）；在此模式下，自动定位被禁用，使用您设置的比例值。

**为什么在添加/移动图例后绘图区域的位置会变化？**

图例位于图表区域的绘图区域之外，但会影响布局和可用空间，因此在自动定位生效时，绘图区域可能会出现位移。（这是 PowerPoint 图表的常规行为。）