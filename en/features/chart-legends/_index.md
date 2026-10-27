---
title: Configure chart legends
description: Show, position and format chart legends.
type: docs
url: /features/chart-legends/
weight: 990
feature_id: chart-legends
feature_group: charts
translationKey: slides-feature-chart-legends
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-legend/
---

## **Overview**

Use a legend to explain the series in a chart. Set its position, adjust text formatting or use a manual layout where needed. You can also hide individual legend entries when they would repeat information already clear from the chart.

## **Usage example**

This C# example uses Aspose.Slides for .NET. Add a Target series alongside Sales and place the legend below the plot. The legend uses 14-point text and does not overlay the data region. No input file is needed. It saves *chart-legends.pptx* and *chart-legends.png*. Install the library using the [installation guide](/slides/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

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
var targetName = workbook.GetCell(0, 0, 2, "Target");
var targetSeries = chart.ChartData.Series.Add(targetName, chart.Type);
var firstTarget = workbook.GetCell(0, 1, 2, 30);
var secondTarget = workbook.GetCell(0, 2, 2, 45);
targetSeries.DataPoints.AddDataPointForBarSeries(firstTarget);
targetSeries.DataPoints.AddDataPointForBarSeries(secondTarget);
chart.HasLegend = true;
chart.Legend.Position = LegendPositionType.Bottom;
chart.Legend.Overlay = false;
chart.Legend.TextFormat.PortionFormat.FontHeight = 14;
presentation.Save("chart-legends.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("chart-legends.png", ImageFormat.Png);
```

## **FAQ**

### **Can I hide the whole legend?**

Yes. Toggle the chart's legend visibility, or hide selected entries while leaving the legend in place.

### **Can I change the font used by legend entries?**

Yes. Apply text formatting to the legend. For example, the sample sets a common font size for its entries.

### **How does overlay mode affect the space available to the plot?**

A non-overlay legend reserves layout space outside the plot. Overlay mode allows it to share the plot region, which may cover data; inspect the result when changing the setting.

## **Guides**

- [Customize Chart Legends in Presentations in .NET](/slides/net/chart-legend/)

Related feature: [Work with chart series](/slides/features/chart-series/).
