---
title: Customize Error Bars in Presentation Charts Using Python
linktitle: Error Bar
type: docs
url: /python-java/error-bar/
keywords:
- error bar
- custom value
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Learn how to add and customize error bars in charts with Aspose.Slides for Python via Java—optimize data visuals in PowerPoint presentations."
---

## **Overview**

This article explains how to work with error bars in presentation charts by using Aspose.Slides. It shows how to add error bars to a chart series, configure X and Y error bar settings, and apply different value types such as fixed, percentage, and custom values.

It also demonstrates how to assign custom error bar values for individual data points in a series by using the corresponding data point collection. In addition, the article includes brief notes about how error bars behave during export, their compatibility with markers and data labels, and where to find the related API reference classes and enums.

## **Add Error Bars**

Aspose.Slides for Python via Java provides a simple API for managing error bar values. The following sample code uses fixed and percentage value types.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Add a bubble chart to the desired slide.
1. Access the first chart series and set the error bar X format.
1. Access the first chart series and set the error bar Y format.
1. Set the error bar values and formatting.
1. Write the modified presentation to a PPTX file.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Create an instance of the Presentation class.
presentation = Presentation()
try:
    # Create a bubble chart.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Add error bars and set their formatting.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()

    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Fixed)
    error_bar_x.setValue(0.1)
    error_bar_y.setValueType(ErrorBarValueType.Percentage)
    error_bar_y.setValue(5)
    error_bar_x.setType(ErrorBarType.Plus)
    error_bar_y.getFormat().getLine().setWidth(2.0)
    error_bar_x.setEndCap(True)

    # Save the presentation.
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Add Custom Error Bar Values**

Aspose.Slides for Python via Java provides a simple API for managing custom error bar values. The following sample code applies when [getValueType](https://reference.aspose.com/slides/python-java/aspose.slides/errorbarsformat/#getValueType) returns [ErrorBarValueType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/errorbarvaluetype/#Custom). To specify a value, use [getErrorBarsCustomValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues) for a specific data point in the collection returned by the series method [getDataPoints](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getDataPoints).

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Add a bubble chart to the desired slide.
1. Access the first chart series and set the error bar X format.
1. Access the first chart series and set the error bar Y format.
1. Access the individual data points in the chart series and set their error bar values.
1. Set the error bar values and formatting.
1. Write the modified presentation to a PPTX file.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Create an instance of the Presentation class.
presentation = Presentation()
try:
    # Create a bubble chart.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Add custom error bars and set their formatting.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # Access the chart series data points and configure their error bar value sources.
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # Set error bar values for the chart series data points.
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # Save the presentation.
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**What happens to error bars when exporting a presentation to PDF or images?**

They are rendered as part of the chart and preserved during conversion along with the rest of the chart formatting, assuming a compatible version or renderer.

**Can error bars be combined with markers and data labels?**

Yes. Error bars are a separate element and are compatible with markers and data labels; if elements overlap, you may need to adjust formatting.

**Where can I find the list of properties and classes for working with error bars in the API?**

In the API reference: the [ErrorBarsFormat](https://reference.aspose.com/slides/python-java/aspose.slides/errorbarsformat/) class and the related classes [ErrorBarType](https://reference.aspose.com/slides/python-java/aspose.slides/errorbartype/) and [ErrorBarValueType](https://reference.aspose.com/slides/python-java/aspose.slides/errorbarvaluetype/).
