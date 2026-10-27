---
title: Format chart data labels
description: Show values, percentages and category names on chart points.
type: docs
url: /features/chart-data-labels/
weight: 980
feature_id: chart-data-labels
feature_group: charts
translationKey: slides-feature-chart-data-labels
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-data-label/
---

## **Overview**

Add data labels to explain the values plotted in a chart. Choose the label content, separator and position, then customize particular points when they need a different treatment. Labels can also take their text from chart workbook cells.

## **Usage example**

This C# example uses Aspose.Slides for .NET. Show each category name and numeric value on a two-column chart, separated by a colon. The expected labels are North: 20 and South: 40. No input file is needed. It saves *chart-data-labels.pptx* and *chart-data-labels.png*. Install the library using the [installation guide](/slides/net/installation/).

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
var labels = series.Labels.DefaultDataLabelFormat;
labels.ShowValue = true;
labels.ShowCategoryName = true;
labels.Separator = ": ";
presentation.Save("chart-data-labels.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("chart-data-labels.png", ImageFormat.Png);
```

## **FAQ**

### **Can I move just one label outside a pie slice?**

Yes. A point can override the chart's general label settings, including position and layout.

### **Can I format a single data point's label?**

Yes. Change the label attached to the selected data point to override its series defaults, for example to move or format that label.

### **How can I hide labels for only one series?**

Disable the relevant label-content flags for that series, such as showing values or category names. Other series retain their own label settings.

## **Guides**

- [Manage Chart Data Labels in Presentations in .NET](/slides/net/chart-data-label/)

Related feature: [Edit a chart's embedded workbook](/slides/features/chart-workbook/).
