---
title: Chart Data Label
type: docs
url: /python-net/chart-data-label/
keywords: "Chart data label,label distance, Python, Aspose.Slides for Python via .NET"
description: "Set PowerPoint chart data label and distance in Python"
---

## **Set Precision of Data in Chart Data Labels**
Aspose.Slides for Python via .NET provides a simple API for setting precision of data in chart data label. Below sample example is given. 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
	chart.has_data_table = True
	chart.chart_data.series[0].number_format_of_values = "#,##0.00"

	pres.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Display Percentage as Labels**
Aspose.Slides for Python via .NET supports displaying the percentage as labels. In this topic, we will see with example how to display the percentage as labels using Aspose.Slides. In order to set percentage as display. Please follow the steps below.

1. Instantiate [Presentation](https://apireference.aspose.com/slides/python-net/aspose.slides/presentation) object.
1. Add stacked column chart.
1. Calculate the series data point values for particular categories.
1. Displaying the percentage as labels.
1. Set properties of label.
1. Write presentation to disk.

In the example given below, we have set the percentage as label.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Create an instance of Presentation class
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)
    series = chart.chart_data.series[0]
    total_for_Cat = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        cat = chart.chart_data.categories[k]
        for i in range(len(chart.chart_data.series)):
            total_for_Cat[k] += chart.chart_data.series[i].data_points[k].value.data

dataPontPercent = 0

for x in range(len(chart.chart_data.series)):
    series = chart.chart_data.series[x]
    series.labels.default_data_label_format.show_legend_key = False

    for j in range(len(series.data_points)):
        lbl = series.data_points[j].label
        dataPontPercent = series.data_points[j].value.data / total_for_Cat[j] * 100

        port = slides.Portion()
        port.text = "{0:.2f} %".format(dataPontPercent)
        port.portion_format.font_height = 8
        lbl.text_frame_for_overriding.text = ""
        para = lbl.text_frame_for_overriding.paragraphs[0]
        para.portions.add(port)

        lbl.data_label_format.show_series_name = False
        lbl.data_label_format.show_percentage = False
        lbl.data_label_format.show_legend_key = False
        lbl.data_label_format.show_category_name = False
        lbl.data_label_format.show_bubble_size = False

# Save presentation with chart
presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Set Percentage Sign with Chart Data Labels**
In order to set the percentage sign with chart data labels. Please follow the steps below:

- Create an instance of `Presentation` class.
- Get reference of the slide.
- Add PercentsStackedColumn chart on a slide.
- Set NumberFormatLinkedToSource to false.
- Getting the chart data worksheet.
- Add new series.
- Setting the fill color of series.
- Setting LabelFormat properties.
- Write the presentation as a PPTX file.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Create an instance of Presentation class
with slides.Presentation() as presentation:

    # Get reference of the slide
    slide = presentation.slides[0]

    # Add PercentsStackedColumn chart on a slide
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    # Set NumberFormatLinkedToSource to false
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    defaultWorksheetIndex = 0

    # Getting the chart data worksheet
    workbook = chart.chart_data.chart_data_workbook

    # Add new series
    series = chart.chart_data.series.add(workbook.get_cell(defaultWorksheetIndex, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 4, 1, 0.65))

    # Setting the fill color of series
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Setting LabelFormat properties
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # Add new series
    series2 = chart.chart_data.series.add(workbook.get_cell(defaultWorksheetIndex, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 4, 2, 0.35))

    # Setting Fill type and color
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # Write presentation to disk
    presentation.save("SetDatalabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Set Label Distances**
In order to set the Label Distance. Please follow the steps below:

- Create an instance of `Presentation` class.
- Get reference of the slide.
- Adding a chart on slide.
- Setting the position of label from axis.
- Write the presentation as a PPTX file.

In the example given below, we have set the label distance from category axis.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Get reference of the slide
    sld = presentation.slides[0]
    
    # Adding a chart on slide
    ch = sld.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Setting the position of label from axis
    ch.axes.horizontal_axis.label_offset = 500

    # Write the presentation file to disk
    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

