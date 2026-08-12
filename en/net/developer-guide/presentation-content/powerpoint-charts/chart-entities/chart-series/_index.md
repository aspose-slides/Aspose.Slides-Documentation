---
title: Manage Chart Data Series in Presentations in .NET
linktitle: Data Series
type: docs
url: /net/chart-series/
keywords:
- chart series
- series overlap
- series color
- category color
- series name
- data point
- series gap
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Learn how to manage chart series, data points, workbook cells, formatting, overlap, gap width, and negative values in presentations with C#."
---

## **Overview**

A chart stores its plotted data in a chart data workbook. An [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) represents one set of related values, and each [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) in the series refers to one or more workbook cells. [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) objects provide the labels or grouping values shared by the series. The series name, categories, and point values are therefore connected to [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) objects rather than stored only as display text.

For a typical category chart, the default workbook uses row 0 for series names, column 0 for category names, and the remaining cells for series values. Worksheet, row, and column indexes passed to [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) are zero-based. This layout is useful when you create a chart with default data, but do not assume that every existing chart uses it. For a loaded presentation, inspect the cells referenced by the series, categories, and data points before changing workbook values.

Chart settings have three different scopes:

- Series-level settings, such as [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/), provide the default appearance for all points in one series.
- Data-point settings, such as [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/), override the series appearance for one point.
- Group settings apply to compatible series that belong to the same [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/). Access the group through [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) when you need to set options such as overlap or gap width.

When no explicit point or series fill is set, the chart style and theme determine the automatic appearance. When both series and point formatting are present, the point formatting takes precedence for that point.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Set the Chart Series Overlap**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) reports how much bars or columns overlap in a 2D chart, from -100 through 100 percent. It is a read-only projection of the setting on the parent series group. Set [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) to update every compatible series in that group. This option applies to chart types that display grouped bars or columns; it does not affect unrelated series groups in a combination chart.

The following example sets the overlap for the group that contains the first series:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// The new chart contains sample series, categories, and values.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

The result:

![The series overlap](series_overlap.png)

## **Change the Series Fill Color**

Use [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) to set the default fill for an entire series. If a point already has an explicit fill, its [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) setting overrides the series fill for that point.

The following example applies a solid blue fill to the first series:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Blue;

presentation.Save("series_color.pptx", SaveFormat.Pptx);
```

The result:

![The color of the series](series_color.png)

## **Change the Series Name**

A series name is stored in the chart data workbook and is normally displayed in the legend. In the default workbook created for a clustered column chart, cell B1 is at row 0, column 1 and contains the name of the first series. The named constants in the following example make that structure explicit:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesNameCell = workbook.GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

You can also update the cell already referenced by [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/). This approach avoids assuming a particular row and column in an existing chart:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var seriesNameCell = series.Name.AsCells[firstNameCellIndex];
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

The result:

![The series name](series_name.png)

## **Get the Automatic Series Fill Color**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) returns the color calculated from the series index and the chart style. This is the color used when the series fill has not been explicitly defined. Calling the method reads the calculated color; it does not assign a new fill.

The following example prints the automatic color of each default series:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

const int firstSlideIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var seriesCount = chart.ChartData.Series.Count;
for (var seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    var automaticColor = series.GetAutomaticSeriesColor();
    Console.WriteLine($"Series {seriesIndex}: {automaticColor.Name}");
}
```

Example output for the default chart style:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

The exact colors depend on the chart style and theme.

## **Set Invert Fill Color for a Chart Series**

For bar, column, and bubble series, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) can display negative values with a different fill. Set the regular series fill to solid, enable inversion, and assign the negative-value color through [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Negative numbers remain unchanged in the workbook; only their display color changes.

The following example replaces the default chart data with one series. Worksheet row 0 contains the series name, column 0 contains category names, and column 1 contains the values:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;

var categoryNames = new[] { "Category 1", "Category 2", "Category 3" };
var seriesValues = new[] { -20, 50, -30 };

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
var series = chartData.Series.Add(seriesNameCell, chart.Type);

for (var categoryIndex = 0; categoryIndex < categoryNames.Length; categoryIndex++)
{
    var dataRowIndex = firstDataRowIndex + categoryIndex;
    var categoryName = categoryNames[categoryIndex];
    var seriesValue = seriesValues[categoryIndex];

    var categoryCell = workbook.GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
    chartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertIfNegative = true;
series.InvertedSolidFillColor.Color = Color.Red;

presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
```

The result:

![The inverted solid fill color](inverted_solid_fill_color.png)

You can enable inversion for one point through [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). In the following example, inversion is disabled for the series and enabled only for the selected point. The point is also assigned a negative value so that the effect is visible:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertedSolidFillColor.Color = Color.Red;
series.InvertIfNegative = false;

var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = negativeValue;
dataPoint.InvertIfNegative = true;

presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
```

## **Clear a Specific Data Point Value**

To make one point empty without removing the other points, set its backing workbook cell to `null`. For a column chart, the plotted value is available through [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). The data point stays at the same category position, but the chart treats its value as blank according to the chart's blank-value settings.

The following example clears only the second point in the first series:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = null;

presentation.Save("clear_data_point_value.pptx", SaveFormat.Pptx);
```

Scatter charts use separate X and Y cells, and bubble charts also use a size cell. Clear only the cell that represents the value you intend to remove. Do not call [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) when you want to keep the other points, because that method removes every data point from the collection.

## **Set the Series Gap Width**

Gap width is the space between adjacent bar or column clusters, expressed as a percentage of the bar or column width. Like overlap, it belongs to the parent series group rather than to one series. Set [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) once for the group. A larger value creates more space between clusters; a smaller value makes them denser.

The following example changes the gap width and saves only the final presentation:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int gapWidthPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.GapWidth = gapWidthPercent;

presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
```

The result:

![The gap width](gap_width.png)

## **FAQ**

**Which chart types support data series?**

All chart types represented by the [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) enumeration use chart data, but their series do not all have the same value structure or settings. For example, category charts use categories and values, scatter charts use X and Y values, and bubble charts add bubble sizes. Use the data-point creation method that matches the series type. Options such as overlap and gap width apply only to compatible bar or column groups.

**What is a chart series group?**

An [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) contains compatible series that share group-level plotting settings. A combination chart can contain more than one group, so changing the group reached through one series does not necessarily change every series in the chart.

**Does a newly created chart contain default data?**

Yes. By default, [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) creates sample series, categories, and values. You can edit those cells or clear both the series and category collections before adding a completely custom data set. An overload can also create a chart without default data.

**How are chart objects connected to workbook cells?**

Series names, category labels, and data-point values reference cells in an [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/). Changing a referenced cell updates the corresponding chart element. When you build custom data, keep category rows and series-value rows aligned so that each point is plotted under the intended category.

**How do I clear one point instead of the whole series?**

Set the relevant value cell to `null` to retain the point's category position as an empty point. Use [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) only when you intend to remove all points from that series. If you also remove categories, update every series so their values remain aligned with the category collection.

**How are empty points displayed?**

The result depends on the chart type and [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/). Supported charts can display blanks as gaps, as zero values, or by connecting neighboring points. Choose the setting that matches the meaning of missing data in your presentation.

**How are negative values formatted?**

For supported bar, column, and bubble series, enable [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) and set [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). You can override the behavior for an individual point with [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). These properties affect formatting, not the stored numeric values.

**Which formatting wins when both a series and a point are formatted?**

Explicit data-point formatting takes precedence for that point. Other points continue to use the explicit series format or, when the series format is not defined, the automatic chart style and theme. Group properties such as overlap and gap width control layout and are not point-level formatting overrides.

**Is there a limit to how many series a chart can contain?**

Aspose.Slides does not impose a separate fixed series-count limit. In practice, presentation file constraints, available memory, rendering time, and chart readability determine a useful limit.

**What should I change when columns are too close together or too far apart?**

Set [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) on the appropriate parent series group. Increase the value to widen the space between clusters, or decrease it to bring the clusters closer together.
