---
title: Error Bar
type: docs
url: /python-net/error-bar/
keywords: "Error bar, error bar values PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Add error bar to PowerPoint presentations in Python"
---

## **Add Error Bar**
Aspose.Slides for Python via .NET provides a simple API for managing error bar values. The sample code applies when using a custom value type. To specify a value, use the **ErrorBarCustomValues** property of a specific data point in the **DataPoints** collection of series:

1. Create an instance of the [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class.
1. Add a bubble chart on desired slide.
1. Access the first chart series and set the error bar X format.
1. Access the first chart series and set the error bar Y format.
1. Setting bars values and format.
1. Write the modified presentation to a PPTX file.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Creating empty presentation
with slides.Presentation() as presentation:
    # Creating a bubble chart
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Adding Error bars and setting its format
    errBarX = chart.chart_data.series[0].error_bars_xformat
    errBarY = chart.chart_data.series[0].error_bars_yformat
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.FIXED
    errBarX.value = 0.1
    errBarY.value_type = charts.ErrorBarValueType.PERCENTAGE
    errBarY.value = 5
    errBarX.type = charts.ErrorBarType.PLUS
    errBarY.format.line.width = 2
    errBarX.has_end_cap = True

    # Saving presentation
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Add Custom Error Bar Value**
Aspose.Slides for Python via .NET provides a simple API for managing custom error bar values. The sample code applies when the **IErrorBarsFormat.ValueType** property is equal to **Custom**. To specify a value, use the **ErrorBarCustomValues** property of a specific data point in the **DataPoints** collection of series:

1. Create an instance of the [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class.
1. Add a bubble chart on desired slide.
1. Access the first chart series and set the error bar X format.
1. Access the first chart series and set the error bar Y format.
1. Access the chart series individual data points and setting the Error Bar values for individual series data point.
1. Setting bars values and format.
1. Write the modified presentation to a PPTX file.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Creating empty presentation
with slides.Presentation() as presentation:
    # Creating a bubble chart
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Adding custom Error bars and setting its format
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_xformat
    errBarY = series.error_bars_yformat
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # Accessing chart series data point and setting error bars values for individual point
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_xplus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_xminus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_yplus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_yminus_values = charts.DataSourceType.DOUBLE_LITERALS

    # Setting error bars for chart series points
    for i in range(len(points)):
        points[i].error_bars_custom_values.xminus.as_literal_double = i + 1
        points[i].error_bars_custom_values.xplus.as_literal_double = i + 1
        points[i].error_bars_custom_values.yminus.as_literal_double = i + 1
        points[i].error_bars_custom_values.yplus.as_literal_double = i + 1

    # Saving presentation
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```

