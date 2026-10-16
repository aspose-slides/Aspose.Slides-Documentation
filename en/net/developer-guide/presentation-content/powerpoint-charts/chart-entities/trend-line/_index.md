---
title: Add Trend Lines to Presentation Charts in .NET
linktitle: Trend Line
type: docs
url: /net/trend-line/
keywords:
- chart
- trend line
- exponential trend line
- linear trend line
- logarithmic trend line
- moving average trend line
- polynomial trend line
- power trend line
- custom trend line
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Quickly add and customize trend lines in PowerPoint charts with Aspose.Slides for .NET — a practical guide to engage your audience."
---

## **Overview**

This article explains how to add trend lines to presentation charts by using Aspose.Slides. It shows how to create a chart, add trend lines to chart series, and work with several trend line types, including exponential, linear, logarithmic, moving average, polynomial, and power.

It also describes how to add a custom line to a chart by inserting a line shape, and includes a short FAQ about forward and backward trend line projection values and whether trend lines are preserved during export to PDF or SVG and when rendering charts as images.

## **Add a Trend Line**

Use [ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/) to add a trend line to a chart series, selecting its type with [TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/). The example creates a clustered column chart with default data and adds two trend lines to each of its three series.

The exponential trend line hides its equation and R-squared value through [DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) and [DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/), while the linear trend line is red. The logarithmic trend line uses [AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/) for a custom label. The moving average uses a [Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/) of three data points and a custom [TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/).

The polynomial trend line has an [Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/) of three and extends one category forward through [Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/). The power trend line extends one category backward through [Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/).

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

## **Set a Trend Line Intercept**

Use [Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/) to fix a trend line's Y value at X = 0. This setting is supported for linear, exponential, and polynomial trend lines.

For example, a production cost model may need to start at known fixed costs of 100, even when measurements at nonzero production volumes suggest a different baseline. For a linear trend line, fixing the intercept constrains the equation `y = ax + b` to `b = 100`; the slope is fitted to the data under that constraint. It does not simply move an already fitted line. Axis crossing settings control where the chart axes meet, not the coefficients of the fitted trend line.

The following example creates a scatter (XY) chart with production volumes from 1 to 4 and costs of 170, 200, 230, and 260. It saves the chart with the default automatic intercept, sets the intercept to 100, and saves a second PPTX. The two files differ only in the intercept setting. The trend line displays its equation and extends back to X = 0.

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

With automatic calculation, these data produce `y = 30x + 140`. Setting the intercept to 100 instead produces approximately `y = 43.33x + 100`: the fitted value at zero matches the known baseline, while the line no longer passes through every data point.

| Automatic intercept | Fixed intercept of 100 |
| --- | --- |
| ![Linear trend line with an automatically calculated intercept of 140](intercept-automatic.png) | ![Linear trend line with a fixed intercept of 100](intercept-fixed.png) |

Both images use the same data and axis scales. The trend lines are extended back to X = 0 to show their intercepts.

By default, the property contains `double.NaN`, which represents an unspecified intercept rather than zero. The intercept is then calculated automatically from the data.

## **Add a Custom Line**

A custom line is a shape drawn over the chart rather than a trend line calculated from series data. This example uses [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) to add a horizontal line to the slide over the chart. The line's position is specified in slide coordinates, measured in points, so it starts at the chart's left edge and sits halfway down the chart. Its width matches the chart's width. The [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) gives the line a solid red color.

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

## **FAQ**

**What do 'forward' and 'backward' mean for a trend line?**

They are the lengths of the trend line projected forward/backward: for scatter (XY) charts — in axis units; for non-scatter charts — in number of categories. Only non-negative values are allowed.

**Will the trend line be preserved when exporting the presentation to PDF or SVG, or when rendering a slide to an image?**

Yes. Aspose.Slides converts presentations to [PDF](/slides/net/convert-powerpoint-to-pdf/) or [SVG](/slides/net/render-a-slide-as-an-svg-image/) and renders charts to images; trend lines, as part of the chart, are preserved during these operations. A method is also available to [export an image of the chart](/slides/net/create-shape-thumbnails/) itself.
