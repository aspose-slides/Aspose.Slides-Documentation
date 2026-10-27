---
title: Configure chart axes
description: Configure chart scales, units, labels, titles and logarithmic axes.
type: docs
url: /features/chart-axes/
weight: 970
feature_id: chart-axes
feature_group: charts
translationKey: slides-feature-chart-axes
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-axis/
---

## **Overview**

Control the axes used by a chart so its scale and labels suit the data. Set bounds and intervals, choose number formats, and adjust titles or label rotation. Use automatic settings where appropriate or set explicit values when charts need a common scale.

## **Usage example**

This C# example uses Aspose.Slides for .NET. Plot sales values 20 and 40 against an explicit value-axis range of 0 to 60, with a major interval of 20 and integer labels. Explicit scales help compare multiple charts. No input file is needed. It saves *chart-axes.pptx* and *chart-axes.png*. Install the library using the [installation guide](/slides/net/installation/).

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
var valueAxis = chart.Axes.VerticalAxis;
valueAxis.IsAutomaticMinValue = false;
valueAxis.MinValue = 0;
valueAxis.IsAutomaticMaxValue = false;
valueAxis.MaxValue = 60;
valueAxis.IsAutomaticMajorUnit = false;
valueAxis.MajorUnit = 20;
valueAxis.IsNumberFormatLinkedToSource = false;
valueAxis.NumberFormat = "0";
presentation.Save("chart-axes.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("chart-axes.png", ImageFormat.Png);
```

## **FAQ**

### **Can several charts use the same minimum and maximum?**

Yes. Set explicit axis bounds on each chart to make their scales consistent.

### **Can I format axis numbers as percentages?**

Yes. Disable linkage to the source number format and choose a percentage format. Store fractional values, such as 0.25 for 25%, when that matches the data.

### **How do category axes differ from value axes?**

A category axis identifies groups such as North and South. A value axis represents a numeric scale and supports bounds and intervals. The axis settings available depend on the chart type.

## **Guides**

- [Customize Chart Axes in Presentations in .NET](/slides/net/chart-axis/)

Related feature: [Format the chart plot area](/slides/features/chart-plot-area/).
