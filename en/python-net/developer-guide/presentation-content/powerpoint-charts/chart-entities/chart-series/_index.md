---
title: Manage Chart Series in Python
linktitle: Chart Series
type: docs
url: /python-net/chart-series/
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
- Python
- Aspose.Slides
description: "Learn how to manage chart series in Python for PowerPoint (PPT/PPTX) with practical code examples and best practices to enhance your data presentations."
---

A series is a row or column of numbers plotted in a chart.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Set Chart Series Overlap**

With the [IChartSeriesOverlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/) property, you can specify how much bars and columns should overlap on a 2D chart (range: -100 to 100). This property applies to all series of the parent series group: this is a projection of the appropriate group property. Therefore, this property is read-only. 

Use the `parent_series_group.overlap` read/write property to set your preferred value for `overlap`. 

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Add a clustered column chart on a slide.
1. Access the first chart series.
1. Access the chart series' `parent_series_group` and set your preferred overlap value for the series. 
1. Write the modified presentation to a PPTX file.

This Python code shows you how to set the overlap for a chart series:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Adds chart
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400, True)
    series = chart.chart_data.series
    if series[0].overlap == 0:
        # Sets series overlap
        series[0].parent_series_group.overlap = -30

    # Writes the presentation file to disk
    presentation.save("SetChartSeriesOverlap_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Change Series Color**
Aspose.Slides for Python via .NET allows you to change a series' color this way:

1. Create an instance of the `Presentation` class.
1. Add chart on the slide.
1. Access the series whose color you want to change. 
1. Set your preferred fill type and fill color.
1. Save the modified presentation.

This Python code shows you how to change a series' color:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 400)
	point = chart.chart_data.series[0].data_points[1]
	
	point.explosion = 30
	point.format.fill.fill_type = slides.FillType.SOLID
	point.format.fill.solid_fill_color.color = draw.Color.blue

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Change Series Category's Color**
Aspose.Slides for Python via .NET allows you to change a series category's color this way:

1. Create an instance of the `Presentation` class.
1. Add chart on the slide.
1. Access the series category whose color you want to change.
1. Set your preferred fill type and fill color.
1. Save the modified presentation.

This code in Python shows you how to change a series category's color:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	point = chart.chart_data.series[0].data_points[0]
	
	point.format.fill.fill_type = slides.FillType.SOLID
	point.format.fill.solid_fill_color.color = draw.Color.blue

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Change Series' Name** 

By default, the legend names for a chart are the contents of cells above each column or row of data. 

In our example (sample image), 

* the columns are *Series 1, Series 2,* and *Series 3*;
* the rows are *Category 1, Category 2, Category 3,* and *Category 4.* 

Aspose.Slides for Python via .NET allows you to update or change a series name in its chart data and legend. 

This Python code shows you how to change a series' name in its chart data `ChartDataWorkbook`:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    
    seriesCell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    seriesCell.value = "New name"
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

This Python code shows you how to change a series name in its legend through`Series`:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    
    series.name.as_cells[0].value = "New name"

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX) 
```

## **Set Chart Series Fill Color**

Aspose.Slides for Python via .NET allows you to set the automatic fill color for chart series inside a plot area this way:

1. Create an instance of the `Presentation` class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data based on your preferred type (in the example below, we used `ChartType.CLUSTERED_COLUMN`).
1. Access the chart series and set the fill color to Automatic.
1. Save the presentation to a PPTX file.

This Python code shows you how to set the automatic fill color for a chart series:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Creates a clustered column chart
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 50, 600, 400)

    # Sets series fill format to automatic
    for i in range(len(chart.chart_data.series)):
        chart.chart_data.series[i].get_automatic_series_color()

    # Writes the presentation file to disk
    presentation.save("AutoFillSeries_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Chart Series Invert Fill Colors**
Aspose.Slides allows you to set the invert fill color for chart series inside a plot area this way:

1. Create an instance of the `Presentation` class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data based on your preferred type (in the example below, we used `ChartType.CLUSTERED_COLUMN`).
1. Access the chart series and set the fill color to invert.
1. Save the presentation to a PPTX file.

This Python code demonstrates the operation:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Adds new series and categories
    chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Category 3"))

    # Takes the first chart series and populates its series data.
    series = chart.chart_data.series[0]
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))
    seriesColor = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = seriesColor
    series.inverted_solid_fill_color.color = draw.Color.red
    pres.save("SetInvertFillColorChart_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Set Series to Invert When Value is Negative**
Aspose.Slides allows you to set inverts through the `ChartDataPoint.invert_if_negative` properties. When an invert is set using the properties, the data point inverts its colors when it gets a negative value. 

This Python code demonstrates the operation:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400, True)
	series = chart.chart_data.series
	chart.chart_data.series.clear()

	series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)
	series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -2))
	series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series[0].invert_if_negative = False

	series[0].data_points[2].invert_if_negative = True

	pres.save("out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clear Specific Data Points' Data**
Aspose.Slides for Python via .NET allows you to clear the `data_points` data for a specific chart series this way:

1. Create an instance of the `Presentation` class.
2. Obtain the reference of a slide through its index.
3. Obtain the reference of a chart through its index.
4. Iterate through all the chart `data_points` and set `x_value` and `y_value` to null.
5. Clear all`data_points` for specific chart series.
6. Write the modified presentation to a PPTX file.

This Python code demonstrates the operation:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "TestChart.pptx") as pres:
    sl = pres.slides[0]
    chart = sl.shapes[0]

    for dataPoint in chart.chart_data.series[0].data_points:
        dataPoint.x_value.as_cell.value = None
        dataPoint.y_value.as_cell.value = None

    chart.chart_data.series[0].data_points.clear()

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Series Gap Width**
Aspose.Slides for Python via .NET allows you to set a series' Gap Width through the **`gap_width`** property this way:

1. Create an instance of the `Presentation` class.
1. Access first slide.
1. Add chart with default data.
1. Access any chart series.
1. Set the `gap_width` property.
1. Write the modified presentation to a PPTX file.

This code in Python shows you how to set a series' Gap Width:

```py
# Creates empty presentation 
with slides.Presentation() as presentation:

    # Accesses the presentation's first slide
    slide = presentation.slides[0]

    # Adds a chart with default data
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 0, 0, 500, 500)

    # Sets the index of the chart data sheet
    defaultWorksheetIndex = 0

    # Gets the chart data worksheet
    fact = chart.chart_data.chart_data_workbook

    # Adds series
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # Adds Categories
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # Takes the second chart series
    series = chart.chart_data.series[1]

    # Populates the series data
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Sets GapWidth value
    series.parent_series_group.gap_width = 50

    # Saves presentation to disk
    presentation.save("GapWidth_out.pptx", slides.export.SaveFormat.PPTX)
```