---
title: Format Charts in Presentations Using Python
linktitle: Chart Formatting
type: docs
weight: 60
url: /python-net/chart-formatting/
keywords:
- format chart
- chart formatting
- chart entity
- chart properties
- chart settings
- chart options
- font properties
- rounded border
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn chart formatting in Aspose.Slides for Python via .NET and elevate your PowerPoint or OpenDocument presentation with professional, eye-catching styling."
---

## **Overview**

This guide shows how to format PowerPoint charts using Aspose.Slides for Python. It walks through customizing core chart entities—such as category and value axes, gridlines, labels, titles, legends, and secondary axes—and demonstrates how to control fonts, numeric formats, fills, outlines, plot area and back wall colors, and rounded chart corners with concise, runnable code samples. By following the step-by-step examples, you’ll create a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), add and configure a chart, and save the result to PPTX while applying precise visual and typographic settings.

## **Format Chart Elements**

Aspose.Slides for Python allows developers to add custom charts to their slides from scratch. This section explains how to format various chart elements, including the category and value axes.

Aspose.Slides provides a simple API for managing chart elements and applying custom formatting:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to the slide by its index.
1. Add a chart with default data of the desired type (in this example, `ChartType.LINE_WITH_MARKERS`).
1. Access the chart’s value axis and set the following:
   1. Set the **line format** for value-axis major gridlines.
   1. Set the **line format** for value-axis minor gridlines.
   1. Set the **number format** for the value axis.
   1. Set the **min, max, major, and minor units** for the value axis.
   1. Set the **text properties** for value-axis labels.
   1. Set the **title** for the value axis.
   1. Set the **line format** for the value axis.
1. Access the chart’s category axis and set the following:
   1. Set the **line format** for category-axis major gridlines.
   1. Set the **line format** for category-axis minor gridlines.
   1. Set the **text properties** for category-axis labels.
   1. Set the **title** for the category axis.
   1. Set the **label positioning** for the category axis.
   1. Set the **rotation angle** for category-axis labels.
1. Access the chart legend and set its **text properties**.
1. Show the chart legend without overlapping the chart.
1. Access the chart’s **secondary value axis** and set the following:
   1. Enable the secondary **value axis**.
   1. Set the **line format** for the secondary value axis.
   1. Set the **number format** for the secondary value axis.
   1. Set the **min, max, major, and minor units** for the secondary value axis.
1. Plot the first chart series on the secondary value axis.
1. Set the chart back-wall fill color.
1. Set the chart plot-area fill color.
1. Write the modified presentation to a PPTX file.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Access the first slide.
    slide = presentation.slides[0]

    # Add a sample chart.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Set the chart title.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # Set major gridline format for the value axis.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Set minor gridline format for the value axis.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Set the value axis number format.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Set value-axis maximum, minimum, major unit, and minor unit.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Set value-axis text properties.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # Set the value axis title.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # Set major gridline format for the category axis.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Set minor gridline format for the category axis.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Set category-axis text properties.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # Set the category axis title.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # Set the category-axis label position.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Set the category-axis label rotation angle.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Set legend text properties.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Show the chart legend overlapping the chart.
    chart.legend.overlay = True
                
    # Set chart back wall color.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # Set the plot area color.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Save the presentation.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Chart Font Properties**

Aspose.Slides for Python supports setting font-related properties for charts. Follow the steps below to configure chart font properties:

1. Instantiate a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object.
1. Add a chart to the slide.
1. Set the font height.
1. Save the modified presentation.

A sample code is provided below.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Numeric Format**

Aspose.Slides for Python provides a simple API for managing chart data formats:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Obtain a reference to the slide by its index.
1. Add a chart with default data of any desired type.
1. Set a preset number format from the available preset values.
1. Traverse the chart data cells in each series and set the number format.
1. Save the presentation.
1. Set a custom number format.
1. Traverse the chart data cells in each series and set a different number format.
1. Save the presentation.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Add a default clustered column chart.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Set the preset number format.
    # Traverse each chart series.
    for series in chart.chart_data.series:
        # Traverse each data point in the series.
        for cell in series.data_points:
            # Set the number format.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # Save the presentation.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

The available preset number formats and their corresponding indices are listed below.

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Set Rounded Borders for the Chart Area**

Aspose.Slides for Python supports configuring the chart area using the `Chart.has_rounded_corners` property.

1. Instantiate a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object.
2. Add a chart to the slide.
3. Set the chart’s fill type and fill color.
4. Set the rounded-corners property to `True`.
5. Save the modified presentation.

A sample is provided below.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I set semi-transparent fills for columns/areas while keeping the border opaque?**

Yes. Fill transparency and the outline are configured separately. This is useful for improving the readability of the grid and data in dense visualizations.

**How can I deal with data labels when they overlap?**

Reduce the font size, disable nonessential label components (for example, categories), set the label offset/position, show labels only for selected points if necessary, or switch the format to "value + legend".

**Can I apply gradient or pattern fills to series?**

Yes. Both solid and gradient/pattern fills are typically available. In practice, use gradients sparingly and avoid combinations that reduce contrast with the grid and text.
