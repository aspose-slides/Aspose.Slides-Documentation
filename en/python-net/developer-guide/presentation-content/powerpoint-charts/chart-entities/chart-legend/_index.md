---
title: Customize Chart Legends in Presentations with Python
linktitle: Chart Legend
type: docs
url: /python-net/chart-legend/
keywords:
- chart legend
- legend position
- font size
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Customize chart legends with Aspose.Slides for Python via .NET to optimize PowerPoint presentations with tailored legend formatting."
---

## **Overview**

Aspose.Slides for Python via .NET provides options for customizing chart legends in PowerPoint presentations. This article shows how to position and size a legend, set the font size for the whole legend, format an individual legend entry, and hide or restore selected entries.

The FAQ covers related behaviors, including reserving space for the legend, displaying multiline labels, and inheriting formatting from the presentation theme.

## **Legend Positioning**

Use the legend's [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/x/), [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/y/), [width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/width/), and [height](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/height/) properties to specify its position and size as fractions of the chart's dimensions.

This example creates a presentation and adds a clustered column chart with default data to the first slide. Dividing the desired legend offsets and dimensions by the chart's width and height converts them to relative values: the legend is offset by 50 points from the chart's top-left corner and sized to 100 by 100 points.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # Express the legend's position and size relative to the chart.
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    presentation.save("legend_position.pptx", slides.export.SaveFormat.PPTX)
```

## **Set the Font Size of a Legend**

Use the legend's [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) to access its text formatting and set [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) in points.

This example creates a chart with default data and sets the legend text to 20 points. It also disables automatic bounds for the vertical axis and sets its range to -5 through 10.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    presentation.save("legend_font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Set the Font Size of an Individual Legend Entry**

Use the legend's [entries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/entries/) collection to access formatting for a specific entry. Entry indices are zero-based, so index `1` refers to the second entry.

This example creates a clustered column chart whose default data includes at least two series. It formats the second legend entry with bold, italic, and 20-point blue text.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    text_format = chart.legend.entries[1].text_format
    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Hide Individual Legend Entries**

To exclude an auxiliary series from the legend while keeping its data visible, set [ILegendEntryProperties.hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) to `True` through [IChartSeries.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/related_legend_entry/). This hides only the selected legend entry; it does not remove the series or its data points. Setting [IChart.has_legend](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichart/has_legend/) to `False`, in contrast, hides the entire legend.

The example below creates a clustered column chart with multiple series using default data. It hides the second series' legend entry (index `1`) and saves the presentation. It then restores the entry by setting [hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) to `False` and saves a second copy. The columns remain visible in both files.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = True

    legend_entry = chart.chart_data.series[1].related_legend_entry
    legend_entry.hide = True

    presentation.save("hidden_legend_entry.pptx", slides.export.SaveFormat.PPTX)

    # Restore the same entry without changing the chart data.
    legend_entry.hide = False

    presentation.save("restored_legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

The comparison below shows the same chart with all entries visible and with the second entry hidden. The second series' columns remain unchanged.

![Comparison of a chart with all legend entries visible and with Series 2 hidden from the legend; all columns remain visible.](hide-legend-entry.png)

In column, bar, and line charts, legend entries identify series. For pie charts, they identify individual data points (slices), so use [IChartDataPoint.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/related_legend_entry/) on the selected slice instead. The API documents this data-point property for the `PIE`, `PIE3D`, `EXPLODED_PIE`, `EXPLODED_PIE3D`, `PIE_OF_PIE`, and `BAR_OF_PIE` chart types. Do not assume it applies to doughnut charts, which are not included in that list.

## **FAQ**

**Can I make the chart allocate space for the legend instead of overlaying it?**

Yes. Set [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) to `False` to reserve space for the legend instead of allowing it to overlap the plot area.

**Can I make multiline legend labels?**

Yes. Long labels can wrap when the available width is insufficient. You can also use newline characters in series names to request line breaks.

**How do I make the legend follow the presentation theme's color scheme?**

Leave the legend's colors, fills, and fonts unset so that it can inherit theme formatting. Explicit formatting overrides the corresponding theme settings.
