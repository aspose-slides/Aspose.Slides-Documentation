---
title: 自定义 Python 中演示文稿图表的绘图区域
linktitle: 绘图区域
type: docs
url: /zh/python-net/chart-plot-area/
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
Aspose.Slides for Python via .NET 提供了一个简易的 API 用于 .

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 访问第一张幻灯片。
3. 添加带有默认数据的图表。
4. 在获取实际值之前调用 IChart.ValidateChartLayout() 方法。
5. 获取相对于图表左上角的图表元素实际 X 位置（左）。
6. 获取相对于图表左上角的图表元素实际 Y（顶部）位置。
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
	
	# 保存包含图表的演示文稿
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```




## **设置图表绘图区域的布局模式**
Aspose.Slides for Python via .NET 提供了一个简易的 API 来设置图表绘图区域的布局模式。属性 **LayoutTargetType** 已添加到 **ChartPlotArea** 和 **IChartPlotArea** 类中。如果手动定义绘图区域的布局，此属性指定是按内部（不包括坐标轴和坐标轴标签）还是外部（包括坐标轴和坐标轴标签）来布局绘图区域。**LayoutTargetType** 枚举中定义了两种可能的取值。

- **LayoutTargetType.Inner** - 指定绘图区域的大小应决定绘图区域的尺寸，不包括刻度线和坐标轴标签。
- **LayoutTargetType.Outer** - 指定绘图区域的大小应决定绘图区域的尺寸，包括刻度线和坐标轴标签。

下面提供了示例代码。

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

## **FAQ**

**actual_x、actual_y、actual_width 和 actual_height 以什么单位返回？**

以点（point）为单位；1 英寸 = 72 点。这是 Aspose.Slides 的坐标单位。

**绘图区域在内容上与图表区域有何区别？**

绘图区域是数据绘制区域（系列、网格线、趋势线等）；图表区域则包含周围的元素（标题、图例等）。在三维图表中，绘图区域还包括墙面/地板以及坐标轴。

**当布局为手动时，绘图区域的 X、Y、宽度和高度如何解释？**

它们是相对于图表整体大小的比例（0–1）；在此模式下，自动定位被禁用，使用您设置的比例值。

**为什么在添加/移动图例后绘图区域的位置会变化？**

图例位于图表区域的绘图区域之外，但会影响布局和可用空间，因此在启用自动定位时，添加或移动图例会导致绘图区域移动。（这是 PowerPoint 图表的常规行为。）