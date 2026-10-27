---
title: Choose a chart type
description: Choose from the chart types provided by the library.
type: docs
url: /features/chart-types/
weight: 950
feature_id: chart-types
feature_group: charts
translationKey: slides-feature-chart-types
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-types/
---

## **Overview**

Select a chart type appropriate to the data, from familiar columns, lines and pies to newer chart families. The choice controls how series and categories are displayed. Use the chart-type guide for the available options and the settings associated with each family.

## **Usage example**

This C# example uses Aspose.Slides for .NET. Create two concrete chart types: a clustered column chart with explicit sales data and a line chart with the library's default sample data. Their separate positions make both chart types visible. No input file is needed. It saves *chart-types.pptx* and *chart-types.png*. Install the library using the [installation guide](/slides/net/installation/).

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
var lineChart = slide.Shapes.AddChart(ChartType.Line, 360, 230, 320, 250);
chart.Width = 300;
chart.Height = 200;
presentation.Save("chart-types.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("chart-types.png", ImageFormat.Png);
```

## **FAQ**

### **Does every named chart value behave as a standalone chart type?**

Some values are markers or have creation and rendering restrictions. Choose a concrete chart type from the guide rather than treating an enum count as a feature count.

### **Can I change an existing chart's type?**

Yes. Change the chart type and, when needed, the types of its series. Check that the existing data layout is valid for the destination type before saving.

### **Why do different chart types need different data layouts?**

A category chart uses categories and values, while a scatter chart uses numeric X and Y values; bubble charts also need sizes. Supply the data components required by the selected type.

## **Guides**

- [Customize Presentation Charts in .NET](/slides/net/chart-types/)

Related feature: [Create editable charts](/slides/features/create-charts/).
