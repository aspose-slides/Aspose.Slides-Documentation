---
title: Add chart trendlines
description: Add and format trendlines for chart series.
type: docs
url: /features/chart-trendlines/
weight: 1050
feature_id: chart-trendlines
feature_group: charts
translationKey: slides-feature-chart-trendlines
feature_catalogue_version: 3
feature_guides:
- /slides/net/trend-line/
---

## **Overview**

Add a trendline to show a pattern in a series and choose its type and settings. Options include forecasting, names and equation display where the chart supports them. Keep the original series data in the chart so readers can compare the line with the values.

## **Usage example**

This C# example uses Aspose.Slides for .NET and creates a 2D scatter chart from four increasing values. It adds a linear trendline with equation display enabled, saves *trendline.pptx*, and renders *trendline.png*. The setting is preserved in the saved chart; check the rendered image separately for equation-label visibility. The R-squared label is explicitly disabled because enabling it can prevent rendering. No input file is needed.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var chart = presentation.Slides[0].Shapes.AddChart(ChartType.ScatterWithMarkers, 40, 40, 600, 350);
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
var nameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(nameCell, ChartType.ScatterWithMarkers);
double[] values = { 10, 20, 30, 40 };
for (var i = 0; i < values.Length; i++)
{
    var xCell = workbook.GetCell(0, i + 1, 0, i + 1);
    var yCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForScatterSeries(xCell, yCell);
}
var trendline = series.TrendLines.Add(TrendlineType.Linear);
trendline.DisplayEquation = true;
trendline.DisplayRSquaredValue = false;
presentation.Save("trendline.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("trendline.png", ImageFormat.Png);
```

## **FAQ**

### **Are there rendering details to consider for R-squared labels?**

Displaying an R-squared label can prevent the chart from rendering. Avoid that setting when you need the library to render the chart. Trendlines are not available for 3D chart series.

### **Can I extend a trendline forward or backward?**

Yes. Set the forward and backward projection lengths. For scatter charts the values are axis units; for non-scatter charts they are category counts. Use non-negative values and keep the extension meaningful for the underlying data.

### **Can I show a trendline equation and give the trendline a custom name?**

Yes. Equation display and the custom trendline name are separate settings, as shown in the [trendline guide](/slides/net/trend-line/). Displaying the equation does not require the R-squared label. Keep that label disabled when rendering.

## **Guides**

- [Add Trend Lines to Presentation Charts in .NET](/slides/net/trend-line/)

Related feature: [Work with chart series](/slides/features/chart-series/).
