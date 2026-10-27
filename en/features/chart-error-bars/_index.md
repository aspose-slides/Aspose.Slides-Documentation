---
title: Add chart error bars
description: Show fixed, percentage, statistical or custom error bars.
type: docs
url: /features/chart-error-bars/
weight: 1060
feature_id: chart-error-bars
feature_group: charts
translationKey: slides-feature-chart-error-bars
feature_catalogue_version: 3
feature_guides:
- /slides/net/error-bar/
---

## **Overview**

Add error bars to a chart series to show variability or uncertainty in its values. Choose the calculation type and direction supported by the chart, then format the bars. Custom values can be assigned per point when your application already has the amounts.

## **Usage example**

This C# example uses Aspose.Slides for .NET. Add fixed vertical error bars of 5 units above and below each sales value. Two-point lines and end caps make the bars visible on the two columns. No input file is needed. It saves *chart-error-bars.pptx* and *chart-error-bars.png*. Install the library using the [installation guide](/slides/net/installation/).

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
var errorBars = series.ErrorBarsYFormat;
errorBars.IsVisible = true;
errorBars.ValueType = ErrorBarValueType.Fixed;
errorBars.Value = 5;
errorBars.Type = ErrorBarType.Both;
errorBars.HasEndCap = true;
errorBars.Format.Line.Width = 2;
presentation.Save("chart-error-bars.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("chart-error-bars.png", ImageFormat.Png);
```

## **FAQ**

### **Can horizontal and vertical error bars be configured separately?**

Yes, where the chart type supports them. Choose the appropriate axis direction and error-bar settings.

### **Can I set different positive and negative error values?**

Yes. For custom error bars, assign positive and negative values to each point using the supported axis direction. Fixed bars, as in this example, use one magnitude.

### **Which chart types accept error bars?**

Support depends on the chart family and axis direction. Use a compatible value chart, such as the column chart shown here; do not assume every chart type accepts both directions.

## **Guides**

- [Customize Error Bars in Presentation Charts in .NET](/slides/net/error-bar/)

Related feature: [Work with chart series](/slides/features/chart-series/).
