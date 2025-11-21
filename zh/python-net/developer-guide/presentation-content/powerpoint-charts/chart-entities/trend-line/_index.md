---
title: 在 Python 中为演示文稿图表添加趋势线
linktitle: 趋势线
type: docs
url: /zh/python-net/trend-line/
keywords:
- 图表
- 趋势线
- 指数趋势线
- 线性趋势线
- 对数趋势线
- 移动平均趋势线
- 多项式趋势线
- 幂趋势线
- 自定义趋势线
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 快速在 PowerPoint 和 OpenDocument 图表中添加和自定义趋势线——提供实用指南和代码示例，以提高预测准确性并吸引观众。"
---

## **添加趋势线**
Aspose.Slides for Python via .NET 提供了一个简单的 API，用于管理不同图表的趋势线：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个带有默认数据的图表，并使用任意所需类型（本例使用 ChartType.CLUSTERED_COLUMN）。
1. 为图表系列 1 添加指数趋势线。
1. 为图表系列 1 添加线性趋势线。
1. 为图表系列 2 添加对数趋势线。
1. 为图表系列 2 添加移动平均趋势线。
1. 为图表系列 3 添加多项式趋势线。
1. 为图表系列 3 添加幂趋势线。
1. 将修改后的演示文稿写入 PPTX 文件。

以下代码用于创建带有趋势线的图表。
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 创建空的演示文稿
with slides.Presentation() as pres:

    # 创建聚类柱形图
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # 为第1个系列添加指数趋势线
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # 为第1个系列添加线性趋势线
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # 为第2个系列添加对数趋势线
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # 为第2个系列添加移动平均趋势线
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # 为第3个系列添加多项式趋势线
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # 为第3个系列添加幂趋势线
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # 保存演示文稿
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```




## **添加自定义线**
Aspose.Slides for Python via .NET 提供了一个简单的 API，用于在图表中添加自定义线。要向演示文稿的选定幻灯片添加一条简单的直线，请按照以下步骤操作：

- 创建 Presentation 类的实例
- 使用索引获取幻灯片的引用
- 使用 Shapes 对象提供的 AddChart 方法创建新图表
- 使用 Shapes 对象提供的 AddAutoShape 方法添加类型为 Line 的 AutoShape
- 设置形状线条的颜色。
- 将修改后的演示文稿写入 PPTX 文件

以下代码用于创建带有自定义线的图表。
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    shape = chart.user_shapes.shapes.add_auto_shape(slides.ShapeType.LINE, 0, chart.height / 2, chart.width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
    pres.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```


## **常见问题**

**趋势线的“forward”和“backward”是什么意思？**

它们是趋势线向前/向后延伸的长度：对于散点（XY）图表——以坐标轴单位计；对于非散点图表——以类别数计。仅允许非负值。

**导出演示文稿为 PDF 或 SVG，或将幻灯片渲染为图像时，趋势线会被保留吗？**

是的。Aspose.Slides 可将演示文稿转换为 [PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/zh/python-net/render-a-slide-as-an-svg-image/) 并将图表渲染为图像；趋势线作为图表的一部分，在这些操作中会被保留。还提供了一个方法，可[导出图表的图像](/slides/zh/python-net/create-shape-thumbnails/)。