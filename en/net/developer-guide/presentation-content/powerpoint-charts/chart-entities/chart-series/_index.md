---
title: Manage Chart Series in C#
linktitle: Chart Series
type: docs
url: /net/chart-series/
keywords:
- сhart series
- series overlap
- series color
- category color
- series name
- data point
- series gap
- PowerPoint
- presentation
- C#
- .NET
- Aspose.Slides
description: "Learn how to manage chart series in C# for PowerPoint (PPT/PPTX) with practical code examples and best practices to enhance your data presentations."
---

## **Overview**

This article describes the role of [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/) in Aspose.Slides for .NET, focusing on how data is structured and visualized within presentations. These objects provide the foundational elements that define individual sets of data points, categories, and appearance parameters in a chart. By working with [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/), developers can seamlessly integrate underlying data sources and maintain full control over how information is displayed, resulting in dynamic, data-driven presentations that clearly convey insights and analysis.

A series is a row or column of numbers plotted in a chart.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Set Chart Series Overlap**

The [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) property controls how bars and columns overlap in a 2D chart by specifying a range from -100 to 100. Since this property is associated with the series group rather than individual chart series, it is read-only at the series level. To configure overlap values, use the `ParentSeriesGroup.Overlap` read/write property, which applies the specified overlap to all series in that group.

Below is a C# example that demonstrates how to create a presentation, add a clustered column chart, access the first chart series, configure the overlap setting, and then save the result as a PPTX file:

```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Add a clustered column chart with default data.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // Set the series overlap.
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // Save the presentation file to disk.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```

The result:

![The series overlap](series_overlap.png)

## **Change Series Fill Color**

Aspose.Slides makes it straightforward to customize the fill colors of chart series, allowing you to highlight specific data points and create visually appealing charts. This is achieved through the [IFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/) object, which supports various fill types, color configurations, and other advanced styling options. After adding a chart to a slide and accessing the desired series, simply get a series and apply the appropriate fill color. Beyond solid fills, you can also leverage gradient or pattern fills for enhanced design flexibility. Once you’ve set the colors according to your requirements, save the presentation to finalize the updated look.

The following C# code example shows how to change the color of the first series:

```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Add a clustered column chart with default data.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Set the color of the first series.
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // Save the presentation file to disk.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```

The result:

![The color of the series](series_color.png)

## **Change Series Name** 

Aspose.Slides offers a simple way to modify the names of chart series, making it easier to label data in a clear and meaningful way. By accessing the relevant worksheet cell in the chart data, developers can customize how the data is presented. This modification is particularly useful when series names need to be updated or clarified based on the data’s context. After renaming the series, the presentation can be saved to persist the changes. 

Below is a C# code snippet demonstrating this process in action.

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Add a clustered column chart with default data.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Set the name of the first series.
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // Save the presentation file to disk.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

The following C# code shows an alternative way to change the series name:

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Add a clustered column chart with default data.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Set the name of the first series.
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // Save the presentation file to disk.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

The result:

![The series name](series_name.png)

## **Get Automatic Series Fill Color**

Aspose.Slides for .NET allows you to get the automatic fill color for chart series within a plot area. After creating an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class, you can obtain a reference to the desired slide by index, then add a chart using your preferred type (such as `ChartType.ClusteredColumn`). By accessing the series in the chart, you can get the automatic fill color.

The C# code below demonstrates this process in detail.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Add a clustered column chart with default data.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // Get the fill color of the series.
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```

Output:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **Set Invert Fill Color for Chart Series**

When your data series contains both positive and negative values, simply coloring every column or bar the same can make the chart hard to read. Aspose.Slides for .NET lets you assign an invert fill color—a separate fill applied automatically to data points that fall below zero—so negative values stand out at a glance. In this section you’ll learn how to enable that option, choose an appropriate color, and save the updated presentation.

The following code example demonstrates the operation:

```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Add new categories.
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // Add a new series.
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Populate the series data.
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // Set the color settings for the series.
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```

The result:

![The inverted solid fill color](inverted_solid_fill_color.png)

You can invert the fill color for a single data point rather than the whole series. Simply access the desired `IChartDataPoint` and set its `InvertIfNegative` property to true.

The following code example shows how to do this:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200, true);

    chart.ChartData.Series.Clear();
    IChartSeries series = chart.ChartData.Series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);

    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    // Invert the color if the data point at index 2 is negative.
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```

## **Clear Specific Data Point Values**

Sometimes a chart contains test values, outliers, or obsolete entries that you need to remove without rebuilding the entire series. Aspose.Slides for .NET lets you target any data point by index, clear its contents, and instantly refresh the plot so the remaining points shift and the axes rescale automatically.

The following code exammple demonstrates the operation:

```cs
using (Presentation presentation = new Presentation("test_chart.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = (IChart)slide.Shapes[0];
    IChartSeries series = chart.ChartData.Series[0];

    foreach (IChartDataPoint dataPoint in series.DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    series.DataPoints.Clear();

    presentation.Save("clear_data_points.pptx", SaveFormat.Pptx);
}
```

## **Set Series Gap Width**

Gap width controls the amount of empty space between adjacent columns or bars—wider gaps emphasize individual categories, while narrower gaps create a denser, more compact look. Through Aspose.Slides for .NET you can fine‑tune this parameter for an entire series, achieving exactly the visual balance your presentation requires without altering the underlying data.

The following code example shows how to set the gap width for a series:

```cs
ushort gapWidth = 30;

// Create an empty presentation.
using (Presentation presentation = new Presentation())
{
    // Access the first slide.
    ISlide slide = presentation.Slides[0];

    // Add a chart with default data with default data.
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // Save the presentation to disk.
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // Set the GapWidth value.
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // Save the presentation to disk.
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```

The result:

![The gap width](gap_width.png)

## **FAQs**

**Is there a limit to how many series a single chart can contain?**

Aspose.Slides imposes no fixed cap on the number of series you add. The practical ceiling is set by chart readability and by the memory available to your application.

**What if the columns within a cluster are too close together or too far apart?**

Adjust the `GapWidth` setting for that series (or its parent series group). Increasing the value widens the space between columns, while decreasing it brings them closer together.
