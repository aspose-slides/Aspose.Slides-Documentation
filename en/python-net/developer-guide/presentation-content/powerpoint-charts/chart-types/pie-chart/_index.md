---
title: Customize Pie Charts in Presentations with Python
linktitle: Pie Chart
type: docs
url: /python-net/pie-chart/
keywords:
- pie chart
- manage chart
- customize chart
- chart options
- chart settings
- plot options
- slice color
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn how to create and customize pie charts in Python with Aspose.Slides, exportable to PowerPoint and OpenDocument, boosting your data storytelling in seconds."
---

## **Second Plot Options for Pie of Pie and Bar of Pie Chart**
Aspose.Slides for Python via .NET now supports, second plot options for Pie of Pie or Bar of Pie chart. In this topic, we will see with example how to Specify these options using Aspose.Slides. In order to specify the properties. Please follow the steps below:

1. Instantiate [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class object.
1. Add chart on the slide.
1. Specify the second plot options of chart.
1. Write presentation to disk.

In the example given below, we have set different properties of Pie of Pie chart.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Create an instance of Presentation class
with slides.Presentation() as presentation:
    # Add chart on slide
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # Set different properties
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # Write presentation to disk
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Set Automatic Pie Chart Slice Colors**
Aspose.Slides for Python via .NET provides a simple API for setting automatic pie chart slide colors. The sample code applies setting the above said properties.

1. Create an instance of the Presentation class.
1. Access first slide.
1. Add chart with default data.
1. Set chart Title.
1. Set first series to Show Values.
1. Set the index of chart data sheet.
1. Getting the chart data worksheet.
1. Delete default generated series and categories.
1. Add new categories.
1. Add new series.

Write the modified presentation to a PPTX file.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate Presentation class that represents PPTX file
with slides.Presentation() as presentation:
	# Access first slide
	slide = presentation.slides[0]

	# Add chart with default data
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# Setting chart Title
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# Set first series to Show Values
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# Setting the index of chart data sheet
	defaultWorksheetIndex = 0

	# Getting the chart data worksheet
	fact = chart.chart_data.chart_data_workbook

	# Delete default generated series and categories
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# Adding new categories
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# Adding new series
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# Now populating series data
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Are the 'Pie of Pie' and 'Bar of Pie' variations supported?**

Yes, the library [supports](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) a secondary plot for pie charts, including the 'Pie of Pie' and 'Bar of Pie' types.

**Can I export just the chart as an image (for example, PNG)?**

Yes, you can [export the chart itself as an image](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (such as PNG) without the entire presentation.
