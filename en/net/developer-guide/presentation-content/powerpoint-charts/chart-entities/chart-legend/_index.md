---
title: Customize Chart Legends in Presentations in .NET
linktitle: Chart Legend
type: docs
url: /net/chart-legend/
keywords:
- chart legend
- legend position
- font size
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Customize chart legends with Aspose.Slides for .NET to optimize PowerPoint presentations with tailored legend formatting."
---

## **Overview**

Aspose.Slides for .NET provides options for customizing chart legends in PowerPoint presentations. This article shows how to position and size a legend, set the font size for the whole legend, format an individual legend entry, and hide or restore selected entries.

The FAQ covers related behaviors, including reserving space for the legend, displaying multiline labels, and inheriting formatting from the presentation theme.

## **Legend Positioning**

Use the legend's [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/), [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/), [Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/), and [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) properties to specify its position and size as fractions of the chart's dimensions.

This example creates a presentation and adds a clustered column chart with default data to the first slide. Dividing the desired legend offsets and dimensions by the chart's width and height converts them to relative values: the legend is offset by 50 points from the chart's top-left corner and sized to 100 by 100 points.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Express the legend's position and size relative to the chart.
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **Set the Font Size of a Legend**

Use the legend's [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/) to access its text formatting and set [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) in points.

This example creates a chart with default data and sets the legend text to 20 points. It also disables automatic bounds for the vertical axis and sets its range to -5 through 10.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = -5;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 10;

presentation.Save("legend_font_size.pptx", SaveFormat.Pptx);
```

## **Set the Font Size of an Individual Legend Entry**

Use the legend's [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/) collection to access formatting for a specific entry. Entry indices are zero-based, so index `1` refers to the second entry.

This example creates a clustered column chart whose default data includes at least two series. It formats the second legend entry with bold, italic, and 20-point blue text.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
var textFormat = chart.Legend.Entries[1].TextFormat;

textFormat.PortionFormat.FontBold = NullableBool.True;
textFormat.PortionFormat.FontHeight = 20;
textFormat.PortionFormat.FontItalic = NullableBool.True;
textFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
textFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("legend_entry_format.pptx", SaveFormat.Pptx);
```

## **Hide Individual Legend Entries**

To exclude an auxiliary series from the legend while keeping its data visible, set [ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/) to `true` through [IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/). This hides only the selected legend entry; it does not remove the series or its data points. Setting [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/) to `false`, in contrast, hides the entire legend.

The example below creates a clustered column chart with multiple series using default data. It hides the second series' legend entry (index `1`) and saves the presentation. It then restores the entry by setting `Hide` to `false` and saves a second copy. The columns remain visible in both files.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 200);
chart.HasLegend = true;

var legendEntry = chart.ChartData.Series[1].RelatedLegendEntry;

legendEntry.Hide = true;
presentation.Save("hidden_legend_entry.pptx", SaveFormat.Pptx);

// Restore the same entry without changing the chart data.
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

The comparison below shows the same chart with all entries visible and with the second entry hidden. The second series' columns remain unchanged.

![Comparison of a chart with all legend entries visible and with Series 2 hidden from the legend; all columns remain visible.](hide-legend-entry.png)

In column, bar, and line charts, legend entries identify series. For pie charts, they identify individual data points (slices), so use [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/) on the selected slice instead. The API documents this data-point property for the `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, and `BarOfPie` chart types. Do not assume it applies to doughnut charts, which are not included in that list.

## **FAQ**

**Can I make the chart allocate space for the legend instead of overlaying it?**

Yes. Set [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) to `false` to reserve space for the legend instead of allowing it to overlap the plot area.

**Can I make multiline legend labels?**

Yes. Long labels can wrap when the available width is insufficient. You can also use newline characters in series names to request line breaks.

**How do I make the legend follow the presentation theme's color scheme?**

Leave the legend's colors, fills, and fonts unset so that it can inherit theme formatting. Explicit formatting overrides the corresponding theme settings.
