---
title: 趋势线
type: docs
url: /zh/net/trend-line/
keywords: "趋势线, 自定义线 PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中向 PowerPoint 演示文稿添加趋势线和自定义线"
---

## **添加趋势线**
Aspose.Slides for .NET 提供了一个简单的 API 来管理不同的图表趋势线：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个具有默认数据的图表以及所需类型的图表（此示例使用 ChartType.ClusteredColumn）。
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

// 创建一个簇状柱形图
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// 为图表系列 1 添加指数趋势线
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// 为图表系列 1 添加线性趋势线
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// 为图表系列 2 添加对数趋势线
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("新对数趋势线");

// 为图表系列 2 添加移动平均趋势线
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "新趋势线名称";

// 为图表系列 3 添加多项式趋势线
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// 为图表系列 3 添加幂趋势线
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// 保存演示文稿
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```



## **添加自定义线**
Aspose.Slides for .NET 提供了一个简单的 API 来在图表中添加自定义线。要在演示文稿的选定幻灯片中添加简单的直线，请按照以下步骤操作：

- 创建 Presentation 类的实例
- 通过索引获取幻灯片的引用
- 使用 Shapes 对象公开的 AddChart 方法创建一个新图表
- 使用 Shapes 对象公开的 AddAutoShape 方法添加一个类型为 Line 的 AutoShape
- 设置形状线条的颜色。
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