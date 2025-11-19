---
title: Customize Chart Axes in Presentations with Python 
linktitle: Chart Axis
type: docs
url: /python-net/chart-axis/
keywords:
- chart axis
- vertical axis
- horizontal axis
- customize axis
- manipulate axis
- manage axis
- axis properties
- max value
- min value
- axis line
- date format
- axis title
- axis position
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Discover how to use Aspose.Slides for Python via .NET to customize chart axes in PowerPoint and OpenDocument presentations for reports and visualizations."
---


## **Getting the Max Values on the Vertical Axis on Charts**
Aspose.Slides for Python via .NET allows you to obtain the minimum and maximum values on a vertical axis. Go through these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Access the first slide.
1. Add a chart with default data.
1. Get the actual maximum value on the axis.
1. Get the actual minimum value on the axis.
1. Get the actual major unit of the axis.
1. Get the actual minor unit of the axis.
1. Get the actual major unit scale of the axis.
1. Get the actual minor unit scale of the axis.

This sample code—an implementation of the steps above—shows you how to get the required values in Python:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# Saves the presentation
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Swapping the Data between Axes**
Aspose.Slides allows you to quickly swap the data between axes—the data represented on the vertical axis (y-axis) moves to the horizontal axis (x-axis) and vice versa. 

This Python code shows you how to perform the data swap task between axes on a chart:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Creates empty presentation
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #Switches rows and columns
    chart.chart_data.switch_row_column()
            
    # Saves presentation
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Disabling the Vertical Axis for Line Charts**

This Python code shows you how to hide the vertical axis for a line chart:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **Disabling the Horizontal Axis for Line Charts**

This code shows you how to hide the horizontal axis for a line chart:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **Changing Category Axis**

Using the **CategoryAxisType** property, you can specify your preferred category axis type (**date** or **text**). This code in Python demonstrates the operation: 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Setting the Date Format for Category Axis Value**
Aspose.Slides for Python via .NET allows you to set the date format for a category axis value. The operation is demonstrated in this Python code:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Setting the Rotation Angle for Chart Axis Title**
Aspose.Slides for Python via .NET allows you to set the rotation angle for a chart axis title. This Python code demonstrates the operation:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Setting the Position Axis in a Category or Value Axis**
Aspose.Slides for Python via .NET allows you to set the position axis in a category or value axis. This Python code shows how to perform the task:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Enabling the Display Unit label on Chart Value Axis**
Aspose.Slides for Python via .NET allows you to configure a chart to show a unit label on its chart value axis. This Python code demonstrates the operation:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**How do I set the value at which one axis crosses the other (axis crossing)?**

Axes provide a [crossing setting](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/): you can choose to cross at zero, at the maximum category/value, or at a specific numeric value. This is useful for shifting the X-axis up or down or for emphasizing a baseline.

**How can I position tick labels relative to the axis (alongside, outside, inside)?**

Set the [label position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) to "cross", "outside", or "inside". This affects readability and helps conserve space, especially on small charts.
