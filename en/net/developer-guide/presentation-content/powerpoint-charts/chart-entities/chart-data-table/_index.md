---
title: Customize Chart Data Tables in Presentations in .NET
linktitle: Data Table
type: docs
url: /net/chart-data-table/
keywords:
- chart data
- data table
- font properties
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Customize chart data table fonts, borders, and legend keys in PowerPoint presentations using Aspose.Slides for .NET and C#."
---

## **Overview**

Aspose.Slides for .NET lets you display a chart's data table and customize its text formatting, borders, and legend keys. This article explains how to enable the table, format its text, control each type of border, and show or hide legend keys. The examples save the configured charts in PPTX files.

## **Set Font Properties**

To display a chart's data table, set [HasDataTable](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/hasdatatable/) to `true`. Use [ChartDataTable](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/chartdatatable/) to access the table and configure its text formatting.

1. Load the presentation using the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
1. Add a clustered column chart to the first slide.
1. Enable the chart's data table.
1. Enable bold text with [FontBold](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontbold/) and set [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) to `20` for 20-point text.
1. Save the modified presentation.

The following example requires `test.pptx` in the working directory with at least one slide. It adds a chart with default data at position (50, 50), with a width of 600 points and a height of 400 points. The saved `output.pptx` contains the chart with its data table enabled and the specified font settings applied.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var portionFormat = chart.ChartDataTable.TextFormat.PortionFormat;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontHeight = 20;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Customize Data Table Borders**

Enable the table with [IChart.HasDataTable](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasdatatable/) and access it through [IChart.ChartDataTable](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdatatable/). You can control three types of borders independently:

- [HasBorderHorizontal](https://reference.aspose.com/slides/net/aspose.slides.charts/idatatable/hasborderhorizontal/) controls horizontal cell borders.
- [HasBorderVertical](https://reference.aspose.com/slides/net/aspose.slides.charts/idatatable/hasbordervertical/) controls vertical cell borders.
- [HasBorderOutline](https://reference.aspose.com/slides/net/aspose.slides.charts/idatatable/hasborderoutline/) controls the outer border of the table.

Set each property to `true` to display its borders or `false` to hide them. The following example creates a clustered column chart with default data, displays horizontal borders and the outer border, and hides vertical borders. It requires no input file. The chart's position and size are specified in points.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = false;
dataTable.HasBorderOutline = true;

presentation.Save("data-table-borders.pptx", SaveFormat.Pptx);
```

The comparison below uses the same chart data and legend key setting in all four cases. Starting with all borders enabled, each remaining variant disables just one border property. The lower-left variant matches the border settings in the example.

![Chart data tables with all borders enabled, no horizontal borders, no vertical borders, and no outer border](data-table-borders.png)

## **Show or Hide Legend Keys**

Legend keys are small colored markers beside the series names in the data table. They help readers match each table row to a chart series. Set [ShowLegendKey](https://reference.aspose.com/slides/net/aspose.slides.charts/idatatable/showlegendkey/) to `true` to show these markers or `false` to hide them.

The chart's separate legend is controlled by [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/). These settings are independent: hiding the separate legend does not hide the keys inside the data table, and hiding the table's keys does not hide the separate legend.

The following example creates a chart with default data, enables its data table, and shows legend keys inside it while hiding the separate legend. All table borders are explicitly enabled. No input presentation is required. To hide only the table's keys, change `dataTable.ShowLegendKey` to `false`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;
chart.HasLegend = false;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = true;
dataTable.HasBorderOutline = true;
dataTable.ShowLegendKey = true;

presentation.Save("data-table-legend-keys.pptx", SaveFormat.Pptx);
```

The comparison below shows the same table with legend keys enabled and disabled. All borders remain enabled, and the separate chart legend is hidden in both cases.

![Chart data tables with legend keys shown on the left and hidden on the right](data-table-legend-keys.png)

## **FAQ**

**Can I show legend keys in a chart's data table?**

Yes. Set [ShowLegendKey](https://reference.aspose.com/slides/net/aspose.slides.charts/datatable/showlegendkey/) to `true` to display legend keys or to `false` to hide them.

**Will the data table be preserved when exporting the presentation to PDF, HTML, or images?**

Yes. Aspose.Slides renders the chart and its displayed data table as part of the slide when exporting to [PDF](/slides/net/convert-powerpoint-to-pdf/), [HTML](/slides/net/convert-powerpoint-to-html/), or [images](/slides/net/convert-powerpoint-to-png/).

**Can I work with data tables in charts loaded from a template?**

Yes. For a chart loaded from an existing presentation or template, use [HasDataTable](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/hasdatatable/) to check or change whether its data table is displayed.

**How can I find charts that have a data table enabled?**

Iterate through the shapes on each slide, identify the charts, and check their [HasDataTable](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/hasdatatable/) property. A value of `true` indicates that the data table is enabled.
