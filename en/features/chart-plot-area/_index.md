---
title: Format the chart plot area
description: Set the position, size and fill of a chart's plotting area.
type: docs
url: /features/chart-plot-area/
weight: 1000
feature_id: chart-plot-area
feature_group: charts
translationKey: slides-feature-chart-plot-area
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-plot-area/
---

## **Overview**

Adjust the area where a chart draws its series. Choose a manual layout when the chart needs room for labels or a legend, and set its fill separately from the outer chart area. The layout can be resolved into actual dimensions by the chart engine.

## **Usage example**

This C# example uses Aspose.Slides for .NET. Give the plot area a light-yellow fill and a manual inner layout. Position and size are fractions of the chart frame: 0.15 is 15% from the left and 0.7 is 70% of the frame width. The inner target excludes axes and their labels. No input file is needed. It saves *chart-plot-area.pptx* and *chart-plot-area.png*. Install the library using the [installation guide](/slides/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.Drawing;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 620, 350);
chart.HasTitle = false;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
var firstCategory = workbook.GetCell(0, 1, 0, "North");
var secondCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);
var nameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(nameCell, chart.Type);
var firstValue = workbook.GetCell(0, 1, 1, 20);
var secondValue = workbook.GetCell(0, 2, 1, 40);
series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);
var plot = chart.PlotArea;
plot.AsILayoutable.X = 0.15f;
plot.AsILayoutable.Y = 0.1f;
plot.AsILayoutable.Width = 0.7f;
plot.AsILayoutable.Height = 0.7f;
plot.LayoutTargetType = LayoutTargetType.Inner;
plot.Format.Fill.FillType = FillType.Solid;
plot.Format.Fill.SolidFillColor.Color = Color.LightYellow;
chart.ValidateChartLayout();
presentation.Save("chart-plot-area.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("chart-plot-area.png", ImageFormat.Png);
```

## **FAQ**

### **Is the plot area the same as the full chart frame?**

No. The chart frame also includes elements such as titles and legends. The plot area is the region used for the data display.

### **Can I set a fill for the plot area independently of the chart background?**

Yes. Set the plot area's fill independently of the outer chart background, as in the sample.

### **Can I control plot area position manually?**

Yes. Set its fractional position and dimensions and choose whether the layout target includes axes and labels. Validate the chart layout before reading resolved dimensions.

## **Guides**

- [Customize Plot Areas of Presentation Charts in .NET](/slides/net/chart-plot-area/)

Related feature: [Configure chart legends](/slides/features/chart-legends/).
