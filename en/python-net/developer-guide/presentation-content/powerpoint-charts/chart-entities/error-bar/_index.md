---
title: Customize Error Bars in Presentation Charts with Python
linktitle: Error Bar
type: docs
url: /python-net/error-bar/
keywords:
- error bar
- custom value
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn how to add and customize error bars in charts with Aspose.Slides for Python via .NET—optimize data visuals in PowerPoint and OpenDocument presentations."
---

## **Add Error Bar**
Aspose.Slides for Python via .NET provides a simple API for managing error bar values. The sample code applies when using a custom value type. To specify a value, use the **ErrorBarCustomValues** property of a specific data point in the **DataPoints** collection of series:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
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
    errBarX = chart.chart_data.series[0].error_bars_x_format
    errBarY = chart.chart_data.series[0].error_bars_y_format
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

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
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
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # Accessing chart series data point and setting error bars values for individual point
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # Setting error bars for chart series points
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # Saving presentation
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**What happens to error bars when exporting a presentation to PDF or images?**

They are rendered as part of the chart and preserved during conversion along with the rest of the chart formatting, assuming a compatible version or renderer.

**Can error bars be combined with markers and data labels?**

Yes. Error bars are a separate element and are compatible with markers and data labels; if elements overlap, you may need to adjust formatting.

**Where can I find the list of properties and enums for working with error bars in the API?**

In the API reference: the [ErrorBarsFormat](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbarsformat/) class and the related enums [ErrorBarType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbartype/) and [ErrorBarValueType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbarvaluetype/).
