---
title: 在 .NET 中向演示文稿图表添加趋势线
linktitle: 趋势线
type: docs
url: /zh/net/trend-line/
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
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 图表中快速添加和自定义趋势线——实用指南，帮助您吸引观众。"
---

## **Add a Trend Line**
Aspose.Slides for .NET 提供了用于管理不同图表趋势线的简易 API：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个带有默认数据的图表，并选择所需类型（本例使用 ChartType.ClusteredColumn）。
1. 为图表系列 1 添加指数趋势线。
1. 为图表系列 1 添加线性趋势线。
1. 为图表系列 2 添加对数趋势线。
1. 为图表系列 2 添加移动平均趋势线。
1. 为图表系列 3 添加多项式趋势线。
1. 为图表系列 3 添加幂趋势线。
1. 将修改后的演示文稿写入 PPTX 文件。

以下代码用于创建带有趋势线的图表。
```c#
// 创建空的演示文稿
Presentation pres = new Presentation();

// 创建簇状柱形图表
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// 为第 1 系列添加指数趋势线
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// 为第 1 系列添加线性趋势线
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// 为第 2 系列添加对数趋势线
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// 为第 2 系列添加移动平均趋势线
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// 为第 3 系列添加多项式趋势线
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// 为第 3 系列添加幂趋势线
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// 保存演示文稿
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```




## **Add a Custom Line**
Aspose.Slides for .NET 提供了在图表中添加自定义线的简易 API。要在演示文稿的选定幻灯片中添加一条简单的普通线，请按照以下步骤操作：

- 创建 Presentation 类的实例
- 通过使用其 Index 获取幻灯片的引用
- 使用 Shapes 对象提供的 AddChart 方法创建新图表
- 使用 Shapes 对象提供的 AddAutoShape 方法添加线类型的 AutoShape
- 设置形状线的颜色。
- 将修改后的演示文稿写入 PPTX 文件

以下代码用于创建带有自定义线的图表。
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.UserShapes.Shapes.AddAutoShape(ShapeType.Line, 0, chart.Height / 2, chart.Width, 0);
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
    pres.Save("AddCustomLines.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**What do 'forward' and 'backward' mean for a trendline?**

它们是趋势线向前/向后延伸的长度：对于散点 (XY) 图表，以坐标轴单位计量；对于非散点图表，以类别数量计量。仅允许非负值。

**Will the trendline be preserved when exporting the presentation to PDF or SVG, or when rendering a slide to an image?**

是的。Aspose.Slides 可将演示文稿转换为 [PDF](/slides/zh/net/convert-powerpoint-to-pdf/)/[SVG](/slides/zh/net/render-a-slide-as-an-svg-image/)，并将图表渲染为图像；趋势线作为图表的一部分，会在这些操作中被保留。还提供了将图表本身[export an image of the chart](/slides/zh/net/create-shape-thumbnails/)的方法。