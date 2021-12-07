---
title: Trend Line
type: docs
url: /pythonnet/trend-line/
keywords: "Trend line, custom line PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Add trend line and custom line to PowerPoint presentations in Python"
---

## **Add Trend Line**
Aspose.Slides for Python via .NET provides a simple API for managing different chart Trend Lines:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (this example uses ChartType.CLUSTERED_COLUMN).
1. Adding exponential trend line for chart series 1.
1. Adding linear trend line for chart series 1.
1. Adding logarithmic trend line for chart series 2.
1. Adding moving average trend line for chart series 2.
1. Adding polynomial trend line for chart series 3.
1. Adding power trend line for chart series 3.
1. Write the modified presentation to a PPTX file.

The following code is used to create a chart with Trend Lines.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Creating empty presentation
with slides.Presentation() as pres:

    # Creating a clustered column chart
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # Adding ponential trend line for chart series 1
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_rsquared_value = False

    # Adding Linear trend line for chart series 1
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # Adding Logarithmic trend line for chart series 2
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # Adding MovingAverage trend line for chart series 2
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # Adding Polynomial trend line for chart series 3
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # Adding Power trend line for chart series 3
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # Saving presentation
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Add Custom Line**
Aspose.Slides for Python via .NET provides a simple API to add custom lines in a chart. To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Create an instance of Presentation class
- Obtain the reference of a slide by using its Index
- Create a new chart using AddChart method exposed by Shapes object
- Add an AutoShape of Line type using AddAutoShape method exposed by Shapes object
- Set the Color of the shape lines.
- Write the modified presentation as a PPTX file

The following code is used to create a chart with Custom Lines.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    shape = chart.user_shapes.shapes.add_auto_shape(slides.ShapeType.LINE, 0, chart.height / 2, chart.width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
    pres.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

