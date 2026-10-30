---
title: Edit a chart's embedded workbook
description: Read and update the workbook embedded in a chart.
type: docs
url: /features/chart-workbook/
weight: 1010
feature_id: chart-workbook
feature_group: charts
translationKey: slides-feature-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---

## **Overview**

Access a chart's embedded workbook to change values, category names and data ranges. This keeps the chart and its editable source data together in the presentation. You can also read or replace the workbook as a stream when your application manages workbook data separately.

## **Usage example**

This C# example uses Aspose.Slides for .NET. Create a chart whose North point refers to cell B2 in its embedded workbook, then change that cell from 20 to 55. The saved chart uses the updated value while South remains 40. Workbook row and column indices are zero-based. No input file is needed. It saves *chart-workbook.pptx* and *chart-workbook.png*. Install the library using the [installation guide](/slides/net/installation/).

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
firstValue.Value = 55;
presentation.Save("chart-workbook.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("chart-workbook.png", ImageFormat.Png);
```

## **FAQ**

### **Will the saved chart retain the updated workbook values?**

Yes. The workbook remains embedded with the chart, so the data can be opened and edited later.

### **How do workbook cells map to chart series values?**

A chart point can refer to a workbook cell. Updating that cell changes the value used by the point; keep the series and category references consistent with the workbook layout.

### **Can I read or replace the embedded workbook bytes?**

Yes. The chart-data API can read the embedded workbook as a stream and write a replacement stream. Supply a valid supported workbook and keep the chart's data ranges consistent with its cells.

## **Guides**

- [Manage Chart Workbooks in Presentations in .NET](/slides/net/chart-workbook/)

Related feature: [Recalculate chart workbook formulas](/slides/features/chart-formulas/).

## Runnable .NET examples

- [Extract Chart Data](/slides/net/examples/content-extraction/chart-data/)
