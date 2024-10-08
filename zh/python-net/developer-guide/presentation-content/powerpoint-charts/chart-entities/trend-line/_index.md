---
title: 趋势线
type: docs
url: /python-net/trend-line/
keywords: "趋势线, 自定义线 PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在 Python 中将趋势线和自定义线添加到 PowerPoint 演示文稿"
---

## **添加趋势线**
Aspose.Slides for Python via .NET 提供了一个简单的 API 用于管理不同的图表趋势线：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1.通过索引获取幻灯片的引用。
1. 添加一个带默认数据的图表，以及所需类型的图表（本示例使用 ChartType.CLUSTERED_COLUMN）。
1. 为图表系列 1 添加指数趋势线。
1. 为图表系列 1 添加线性趋势线。
1. 为图表系列 2 添加对数趋势线。
1. 为图表系列 2 添加移动平均趋势线。
1. 为图表系列 3 添加多项式趋势线。
1. 为图表系列 3 添加幂趋势线。
1. 将修改后的演示文稿写入 PPTX 文件。

以下代码用于创建带趋势线的图表。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 创建空演示文稿
with slides.Presentation() as pres:

    # 创建簇状柱形图
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # 为图表系列 1 添加指数趋势线
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # 为图表系列 1 添加线性趋势线
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # 为图表系列 2 添加对数趋势线
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("新的对数趋势线")

    # 为图表系列 2 添加移动平均趋势线
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "新趋势线名称"

    # 为图表系列 3 添加多项式趋势线
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # 为图表系列 3 添加幂趋势线
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # 保存演示文稿
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```



## **添加自定义线**
Aspose.Slides for Python via .NET 提供了一个简单的 API 来在图表中添加自定义线。要在演示文稿的选定幻灯片中添加一条简单的直线，请按照以下步骤操作：

- 创建一个 Presentation 类的实例
- 通过索引获取幻灯片的引用
- 使用 Shapes 对象公开的 AddChart 方法创建一个新图表
- 使用 Shapes 对象公开的 AddAutoShape 方法添加一条线类型的 AutoShape
- 设置形状线的颜色。
- 将修改后的演示文稿写入 PPTX 文件

以下代码用于创建带自定义线的图表。

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