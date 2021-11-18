---
title: Error Bar
type: docs
url: /pythonnet/error-bar/
keywords: "Error bar, error bar values PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Add error bar to PowerPoint presentations in Python"
---

## **Add Error Bar**
Aspose.Slides for Python via .NET provides a simple API for managing error bar values. The sample code applies when using a custom value type. To specify a value, use the **ErrorBarCustomValues** property of a specific data point in the **DataPoints** collection of series:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class.
1. Add a bubble chart on desired slide.
1. Access the first chart series and set the error bar X format.
1. Access the first chart series and set the error bar Y format.
1. Setting bars values and format.
1. Write the modified presentation to a PPTX file.

```py
// Creating empty presentation
using (Presentation presentation = new Presentation())
{
    // Creating a bubble chart
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Adding Error bars and setting its format
    IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;
    IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Fixed;
    errBarX.Value = 0.1f;
    errBarY.ValueType = ErrorBarValueType.Percentage;
    errBarY.Value = 5;
    errBarX.Type = ErrorBarType.Plus;
    errBarY.Format.Line.Width = 2;
    errBarX.HasEndCap = true;

    // Saving presentation
    presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```



## **Add Custom Error Bar Value**
Aspose.Slides for Python via .NET provides a simple API for managing custom error bar values. The sample code applies when the **IErrorBarsFormat.ValueType** property is equal to **Custom**. To specify a value, use the **ErrorBarCustomValues** property of a specific data point in the **DataPoints** collection of series:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class.
1. Add a bubble chart on desired slide.
1. Access the first chart series and set the error bar X format.
1. Access the first chart series and set the error bar Y format.
1. Access the chart series individual data points and setting the Error Bar values for individual series data point.
1. Setting bars values and format.
1. Write the modified presentation to a PPTX file.

```py
// Creating empty presentation
using (Presentation presentation = new Presentation())
{
    // Creating a bubble chart
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Adding custom Error bars and setting its format
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // Accessing chart series data point and setting error bars values for individual point
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // Setting error bars for chart series points
    for (int i = 0; i < points.Count; i++)
    {
        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
    }

    // Saving presentation
    presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
}
```

