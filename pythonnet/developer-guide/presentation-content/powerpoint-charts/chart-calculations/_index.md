---
title: Chart Calculations
type: docs
weight: 50
url: /pythonnet/chart-calculations/
keywords: "Chart calculations, chart elements, element position, chart values Python, Aspose.Slides for Python via .NET"
description: "PowerPoint chart calculations and values in Python"
---

## **Calculate Actual Values of Chart Elements**
Aspose.Slides for Python via .NET provides a simple API for getting these properties. This will help you to Calculates actual values of chart elements. The actual values include position of elements that implement IActualLayout interface (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) and actual axes values (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```py
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Saving presentation
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```



## **Calculate Actual Position of Parent Chart Elements**
Aspose.Slides for Python via .NET provides a simple API for getting these properties. Properties of IActualLayout provide information about actual position of parent chart element. It is necessary to call method IChart.ValidateChartLayout() previously to fill properties with actual values.

```py
// Creating empty presentation
using (Presentation pres = new Presentation())
{
   Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
   chart.ValidateChartLayout();

   double x = chart.PlotArea.ActualX;
   double y = chart.PlotArea.ActualY;
   double w = chart.PlotArea.ActualWidth;
   double h = chart.PlotArea.ActualHeight;
}
```



## **Hide Information from Chart**
This topic helps you to understand how to hide information from chart. Using Aspose.Slides for Python via .NET you can hide **Title, Vertical Axis, Horizontal Axis** and **Grid Lines** from chart. Below code example shows how to use these properties.

```py
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Hiding chart Title
    chart.HasTitle = false;

    ///Hiding Values axis
    chart.Axes.VerticalAxis.IsVisible = false;

    //Category Axis visibility
    chart.Axes.HorizontalAxis.IsVisible = false;

    //Hiding Legend
    chart.HasLegend = false;

    //Hiding MajorGridLines
    chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series.RemoveAt(i);
    }

    IChartSeries series = chart.ChartData.Series[0];

    series.Marker.Symbol = MarkerStyleType.Circle;
    series.Labels.DefaultDataLabelFormat.ShowValue = true;
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Top;
    series.Marker.Size = 15;

    //Setting series line color
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```

