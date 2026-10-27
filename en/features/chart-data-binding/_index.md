---
title: Fill editable charts with data
description: Populate editable charts with application data.
type: docs
url: /features/chart-data-binding/
weight: 1480
feature_id: chart-data-binding
feature_group: generation
translationKey: slides-feature-chart-data-binding
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---

## **Overview**

Fill a chart's workbook, categories and points with values from your application. You can create a new chart or update one already present in a template. The resulting chart stays editable, which is useful for generated reports that readers will continue working with.

## **Usage example**

This C# example maps two caller-supplied categories and two sales series to an editable column chart. The arrays stand in for records already loaded by your application. It writes values to the embedded chart workbook and saves `chart-data-binding.pptx` plus a PNG preview; it does not query a database.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
string[] categories = { "North", "South" };
string[] seriesNames = { "Actual", "Plan" };
double[,] values = { { 120, 145 }, { 130, 150 } };
var chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 600, 350);
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
for (var category = 0; category < categories.Length; category++)
    chart.ChartData.Categories.Add(workbook.GetCell(0, category + 1, 0, categories[category]));
for (var seriesIndex = 0; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]), chart.Type);
    for (var category = 0; category < categories.Length; category++)
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, category + 1, seriesIndex + 1, values[seriesIndex, category]));
}
presentation.Save("chart-data-binding.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("chart-data-binding.png", Aspose.Slides.ImageFormat.Png);
```

## **FAQ**

### **Can I reuse a designer's chart layout?**

Yes. Load the template and update its chart data while retaining the chart as a presentation object.

### **How do I map my records to chart categories and series?**

Choose a stable category order, create a category for each label and populate each series in that same order. Write the corresponding labels and values to the chart workbook cells.

### **How should my application handle missing category values in its input records?**

Decide whether a missing record means zero, a blank or an excluded category before binding. Keep that policy consistent across series so points still align with their categories.

## **Guides**

- [Manage Chart Workbooks in Presentations in .NET](/slides/net/chart-workbook/)

Related feature: [Create editable charts](/slides/features/create-charts/).
