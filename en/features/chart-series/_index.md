---
title: Work with chart series
description: Add, remove, reorder and format chart series.
type: docs
url: /features/chart-series/
weight: 960
feature_id: chart-series
feature_group: charts
translationKey: slides-feature-chart-series
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-series/
---

## **Overview**

Manage the data series within a chart as the underlying report changes. Insert or remove series, change their ordering, and give each one its own formatting. Individual data points can also have local formatting when one result needs emphasis.

## **Usage example**

This C# example uses Aspose.Slides for .NET. Build a Sales series, add a temporary second series, then remove that second series. The remaining Sales series is filled blue. The saved chart contains only the North and South values 20 and 40. No input file is needed. It saves *chart-series.pptx* and *chart-series.png*. Install the library using the [installation guide](/slides/net/installation/).

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
var temporaryName = workbook.GetCell(0, 0, 2, "Temporary");
var temporarySeries = chart.ChartData.Series.Add(temporaryName, chart.Type);
var temporaryValue = workbook.GetCell(0, 1, 2, 10);
temporarySeries.DataPoints.AddDataPointForBarSeries(temporaryValue);
chart.ChartData.Series.RemoveAt(1);
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.CornflowerBlue;
presentation.Save("chart-series.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("chart-series.png", ImageFormat.Png);
```

## **FAQ**

### **Can I recolor one bar without changing the whole series?**

Yes. Apply formatting to that data point while keeping the remaining points on the series settings.

### **How can I format one series independently?**

Apply the fill, line or other formatting to the chosen series. Use point-level formatting when only one data point should differ.

### **How do I remove the default series before adding my own?**

Clear the chart's series collection before adding your own. Clear and rebuild the category collection too when replacing the category layout.

## **Guides**

- [Manage Chart Data Series in Presentations in .NET](/slides/net/chart-series/)

Related feature: [Format chart data labels](/slides/features/chart-data-labels/).
