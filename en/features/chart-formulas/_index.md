---
title: Recalculate chart workbook formulas
description: Calculate supported formulas in a chart's embedded workbook.
type: docs
url: /features/chart-formulas/
weight: 1020
feature_id: chart-formulas
feature_group: charts
translationKey: slides-feature-chart-formulas
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-worksheet-formulas/
---

## **Overview**

Use formulas in the chart workbook to derive totals and other values from its data. Recalculate after updating cells so the chart can use the results. This is useful for straightforward calculations that should remain with the chart's editable data.

## **Usage example**

This C# example uses Aspose.Slides for .NET. Calculate North sales with the formula C2*3, where C2 contains 7. The sample prints North sales: 21, labels the plotted values, and saves the formula with the chart workbook. Cell coordinates are zero-based in the API, while formula references use spreadsheet addresses. No input file is needed. It saves *chart-formulas.pptx* and *chart-formulas.png*. Install the library using the [installation guide](/slides/net/installation/).

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
var inputCell = workbook.GetCell(0, 1, 2, 7);
firstValue.Formula = "C2*3";
workbook.CalculateFormulas();
Console.WriteLine($"North sales: {firstValue.Value}");
series.Labels.DefaultDataLabelFormat.ShowValue = true;
presentation.Save("chart-formulas.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("chart-formulas.png", ImageFormat.Png);
```

## **FAQ**

### **Does this provide the full Excel calculation engine?**

No. Formula coverage and behavior have limits. Use the documented formula support for chart workbooks, or calculate values in your application when needed.

### **When should I calculate formulas after changing source cells?**

Recalculate after changing cells used by formulas and before relying on their results for chart data or output.

### **How do cell references in a formula relate to chart workbook coordinates?**

In the sample, row index 1 and column index 2 select C2. Formula text uses spreadsheet references such as C2, rather than the zero-based API indices.

## **Guides**

- [Apply Chart Worksheet Formulas in Presentations in .NET](/slides/net/chart-worksheet-formulas/)

Related feature: [Edit a chart's embedded workbook](/slides/features/chart-workbook/).
