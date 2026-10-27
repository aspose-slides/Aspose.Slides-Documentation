---
title: Create 3D charts
description: Create 3D charts and adjust their view, depth and perspective.
type: docs
url: /features/charts-3d/
weight: 1030
feature_id: charts-3d
feature_group: charts
translationKey: slides-feature-charts-3d
feature_catalogue_version: 3
feature_guides:
- /slides/net/3d-chart/
---

## **Overview**

Use a 3D chart type when the presentation calls for that style, then adjust rotation and perspective. You can also format chart walls and floors. These settings are stored with the chart and can influence the chart's rendered appearance.

## **Usage example**

This C# example uses Aspose.Slides for .NET. Create a 3D clustered column chart with two sales values, then set X and Y view rotations to 15 and 20 degrees and depth to 100%. It uses one consistent bar shape. No input file is needed. Trendlines are not available for 3D chart series. It saves *charts-3d.pptx* and *charts-3d.png*. Install the library using the [installation guide](/slides/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 40, 40, 620, 350);
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
chart.Rotation3D.RotationX = 15;
chart.Rotation3D.RotationY = 20;
chart.Rotation3D.DepthPercents = 100;
presentation.Save("charts-3d.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("charts-3d.png", ImageFormat.Png);
```

## **FAQ**

### **Can I mix different 3D bar shapes across series?**

Use a consistent 3D bar shape across the series in a bar or column chart; mixed shapes have rendering limitations.

### **Which chart types offer 3D settings?**

Choose a concrete 3D type, such as the 3D clustered columns in this example. Two-dimensional types do not become 3D simply because rotation settings are assigned.

### **How do depth and rotation affect the chart's appearance?**

Rotation changes the viewing angle; depth changes the space along the chart's depth axis. Check the rendered result for readability and keep bar shapes consistent across series.

## **Guides**

- [Customize 3D Charts in Presentations in .NET](/slides/net/3d-chart/)

Related feature: [Choose a chart type](/slides/features/chart-types/).
