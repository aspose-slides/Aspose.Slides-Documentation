---
title: Error Bar
type: docs
url: /nodejs-java/error-bar/
---

## **Add Error Bar**
Aspose.Slides for Node.js via Java provides a simple API for managing error bar values. The sample code applies when using a custom value type. To specify a value, use the **ErrorBarCustomValues** property of a specific data point in the [**DataPoints**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesCollection) collection of series:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
1. Add a bubble chart on desired slide.
1. Access the first chart series and set the error bar X format.
1. Access the first chart series and set the error bar Y format.
1. Setting bars values and format.
1. Write the modified presentation to a PPTX file.

```javascript
    // Create an instance of Presentation class
    var pres = new  aspose.slides.Presentation();
    try {
        // Creating a bubble chart
        var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
        // Adding Error bars and setting its format
        var errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
        var errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();
        errBarX.isVisible();
        errBarY.isVisible();
        errBarX.setValueType(aspose.slides.ErrorBarValueType.Fixed);
        errBarX.setValue(0.1);
        errBarY.setValueType(aspose.slides.ErrorBarValueType.Percentage);
        errBarY.setValue(5);
        errBarX.setType(aspose.slides.ErrorBarType.Plus);
        errBarY.getFormat().getLine().setWidth(2.0);
        errBarX.hasEndCap();
        // Saving presentation
        pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Add Custom Error Bar Value**
Aspose.Slides for Node.js via Java provides a simple API for managing custom error bar values. The sample code applies when the [**ErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) property is equal to **Custom**. To specify a value, use the **ErrorBarCustomValues** property of a specific data point in the [**DataPoints**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesCollection) collection of series:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
1. Add a bubble chart on desired slide.
1. Access the first chart series and set the error bar X format.
1. Access the first chart series and set the error bar Y format.
1. Access the chart series individual data points and setting the Error Bar values for individual series data point.
1. Setting bars values and format.
1. Write the modified presentation to a PPTX file.

```javascript
    // Create an instance of Presentation class
    var pres = new  aspose.slides.Presentation();
    try {
        // Creating a bubble chart
        var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
        // Adding custom Error bars and setting its format
        var series = chart.getChartData().getSeries().get_Item(0);
        var errBarX = series.getErrorBarsXFormat();
        var errBarY = series.getErrorBarsYFormat();
        errBarX.isVisible();
        errBarY.isVisible();
        errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
        errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
        // Accessing chart series data point and setting error bars values for
        // individual point
        var points = series.getDataPoints();
        points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
        points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
        points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
        points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
        // Setting error bars for chart series points
        for (var i = 0; i < points.size(); i++) {
            points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
            points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
            points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
            points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
        }
        // Saving presentation
        pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
