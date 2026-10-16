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
description: "快速在 PowerPoint 图表中使用 Aspose.Slides for .NET 添加并自定义趋势线 — 一份实用指南，帮助您吸引观众。"
---
## **概述**

本文介绍如何使用 Aspose.Slides 向演示文稿图表添加趋势线。它展示了如何创建图表、向图表系列添加趋势线，以及使用多种趋势线类型，包括指数、线性、对数、移动平均、多项式和幂。

它还描述了如何通过插入直线形状向图表添加自定义线，并包含一个关于前向和后向趋势线投影值以及在导出为 PDF 或 SVG 或将图表渲染为图像时趋势线是否会被保留的简短 FAQ。

## **添加趋势线**

使用 [ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/) 向图表系列添加趋势线，并使用 [TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/) 选择其类型。示例创建了一个带默认数据的簇状柱形图，并为其三个系列中的每个系列添加了两条趋势线。

指数趋势线通过 [DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) 和 [DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/) 隐藏其公式和决定系数（R 平方）值，而线性趋势线为红色。对数趋势线使用 [AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/) 添加自定义标签。移动平均使用 [Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/) 为三个数据点，并使用自定义的 [TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/)。

多项式趋势线的 [Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/) 为三，并通过 [Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/) 向前延伸一个类别。幂趋势线通过 [Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/) 向后延伸一个类别。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

var firstSeries = chart.ChartData.Series[0];

var exponentialTrendline = firstSeries.TrendLines.Add(TrendlineType.Exponential);
exponentialTrendline.DisplayEquation = false;
exponentialTrendline.DisplayRSquaredValue = false;

var linearTrendline = firstSeries.TrendLines.Add(TrendlineType.Linear);
linearTrendline.Format.Line.FillFormat.FillType = FillType.Solid;
linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

var secondSeries = chart.ChartData.Series[1];

var logarithmicTrendline = secondSeries.TrendLines.Add(TrendlineType.Logarithmic);
logarithmicTrendline.AddTextFrameForOverriding("New log trend line");

var movingAverageTrendline = secondSeries.TrendLines.Add(TrendlineType.MovingAverage);
movingAverageTrendline.Period = 3;
movingAverageTrendline.TrendlineName = "New TrendLine Name";

var thirdSeries = chart.ChartData.Series[2];

var polynomialTrendline = thirdSeries.TrendLines.Add(TrendlineType.Polynomial);
polynomialTrendline.Forward = 1;
polynomialTrendline.Order = 3;

var powerTrendline = thirdSeries.TrendLines.Add(TrendlineType.Power);
powerTrendline.Backward = 1;

presentation.Save("ChartTrendLines.pptx", SaveFormat.Pptx);
```

## **设置趋势线截距**

使用 [Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/) 将趋势线在 X = 0 时的 Y 值固定。此设置支持线性、指数和多项式趋势线。

例如，生产成本模型可能需要在已知的固定成本 100 处开始，即使在非零生产量的测量值暗示不同的基线。对于线性趋势线，固定截距将方程 `y = ax + b` 约束为 `b = 100`；斜率在此约束下拟合数据。这并不是简单地移动已拟合的线。坐标轴交叉设置控制图表坐标轴的相交位置，而不是已拟合趋势线的系数。

下面的示例创建了一个散点 (XY) 图表，生产量从 1 到 4，成本分别为 170、200、230 和 260。它使用默认的自动截距保存图表，然后将截距设置为 100 并保存第二个 PPTX。两个文件仅在截距设置上有所不同。趋势线显示其公式并向后延伸至 X = 0。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var nameCell = workbook.GetCell(0, 0, 1, "Production cost");
var series = chart.ChartData.Series.Add(nameCell, ChartType.ScatterWithMarkers);
double[] costs = { 170, 200, 230, 260 };

for (var i = 0; i < costs.Length; i++)
{
    var xCell = workbook.GetCell(0, i + 1, 0, i + 1);
    var yCell = workbook.GetCell(0, i + 1, 1, costs[i]);
    series.DataPoints.AddDataPointForScatterSeries(xCell, yCell);
}

var trendline = series.TrendLines.Add(TrendlineType.Linear);
trendline.DisplayEquation = true;
trendline.Backward = 1;

presentation.Save("AutomaticIntercept.pptx", SaveFormat.Pptx);

trendline.Intercept = 100;
presentation.Save("FixedIntercept.pptx", SaveFormat.Pptx);
```

使用自动计算时，这些数据产生 `y = 30x + 140`。将截距设置为 100 则大约得到 `y = 43.33x + 100`：零点的拟合值与已知基线匹配，但此时直线不再通过所有数据点。

| 自动截距 | 固定截距 100 |
| --- | --- |
| ![线性趋势线，自动计算截距为 140](intercept-automatic.png) | ![线性趋势线，固定截距为 100](intercept-fixed.png) |

两幅图像使用相同的数据和坐标轴比例。趋势线向后延伸至 X = 0 以显示其截距。

默认情况下，该属性包含 `double.NaN`，表示未指定的截距而非零。随后截距会根据数据自动计算。

## **添加自定义线**

自定义线是一种绘制在图表之上的形状，而不是根据系列数据计算的趋势线。此示例使用 [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) 在幻灯片的图表上方添加一条水平线。该线的位置以幻灯片坐标（点）指定，因此从图表的左边缘开始，位于图表高度的中间。其宽度与图表宽度相同。[LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) 为该线提供实线红色。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

var line = slide.Shapes.AddAutoShape(ShapeType.Line, chart.X, chart.Y + chart.Height / 2, chart.Width, 0);
line.LineFormat.FillFormat.FillType = FillType.Solid;
line.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("AddCustomLines.pptx", SaveFormat.Pptx);
```

## **常见问题**

**趋势线的“前向”和“后向”是什么意思？**

它们指的是趋势线向前/向后投射的长度：对于散点 (XY) 图表，以坐标轴单位表示；对于非散点图表，以类别数量表示。仅允许非负值。

**在将演示文稿导出为 PDF 或 SVG，或将幻灯片渲染为图像时，趋势线会被保留吗？**

是的。Aspose.Slides 可以将演示文稿转换为 [PDF](/slides/zh/net/convert-powerpoint-to-pdf/) 或 [SVG](/slides/zh/net/render-a-slide-as-an-svg-image/)，并将图表渲染为图像；作为图表一部分的趋势线在这些操作中会被保留。还提供了将图表本身[导出图表图像](/slides/zh/net/create-shape-thumbnails/)的方法。