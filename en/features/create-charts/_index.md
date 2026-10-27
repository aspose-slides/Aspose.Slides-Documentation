---
title: Create editable charts
description: Add editable charts with series, categories and data.
type: docs
url: /features/create-charts/
weight: 940
feature_id: create-charts
feature_group: charts
translationKey: slides-feature-create-charts
feature_catalogue_version: 3
feature_guides:
- /slides/net/create-chart/
---

## **Overview**

Create a chart on a slide and fill it with the data your presentation needs. The saved presentation contains a chart and its data rather than only a rendered picture. You can format the chart as a whole or adjust individual series and points.

## **Usage example**

This C# example uses Aspose.Slides for .NET. Create an editable clustered column chart with two categories, North and South, and sales values 20 and 40. The sample clears the default data and creates its own workbook cells. Chart coordinates and dimensions are in points. No input file is needed. It saves *create-charts.pptx* and *create-charts.png*. Install the library using the [installation guide](/slides/net/installation/).

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
presentation.Save("create-charts.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("create-charts.png", ImageFormat.Png);
```

## **FAQ**

### **Can the chart data be edited after saving?**

Yes. An embedded chart workbook lets the saved presentation keep the data used by the chart.

### **How do I choose a chart position and size on the slide?**

Set the chart frame coordinates and dimensions when adding it, or adjust the frame afterward. The values are slide points; 72 points equal one inch.

### **How can I replace the default chart data?**

Clear the default series and categories, then add your own workbook cells, categories and series as shown. Keep each series aligned with the category order.

## **Guides**

- [Create or Update PowerPoint Presentation Charts in .NET](/slides/net/create-chart/)

Related feature: [Edit a chart's embedded workbook](/slides/features/chart-workbook/).
