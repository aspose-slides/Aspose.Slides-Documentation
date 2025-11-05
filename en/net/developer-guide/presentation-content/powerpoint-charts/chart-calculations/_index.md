---
title: Chart Calculations
type: docs
weight: 50
url: /net/chart-calculations/
keywords: "Chart calculations, chart elements, element position, chart values C#, Csharp, Aspose.Slides for .NET"
description: "PowerPoint chart calculations and values in C# or .NET"
---

## **Calculate Actual Values of Chart Elements**
Aspose.Slides for .NET provides a simple API for getting these properties. This will help you to Calculates actual values of chart elements. The actual values include position of elements that implement IActualLayout interface (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) and actual axes values (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```c#
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
Aspose.Slides for .NET provides a simple API for getting these properties. Properties of IActualLayout provide information about actual position of parent chart element. It is necessary to call method IChart.ValidateChartLayout() previously to fill properties with actual values.

```c#
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
This topic helps you to understand how to hide information from chart. Using Aspose.Slides for .NET you can hide **Title, Vertical Axis, Horizontal Axis** and **Grid Lines** from chart. Below code example shows how to use these properties.

```c#
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

## **FAQ**

**Do external Excel workbooks work as a data source, and how does that affect recalculation?**

Yes. A chart can reference an external workbook: when you connect or refresh the external source, formulas and values are taken from that workbook, and the chart reflects the updates during open/edit operations. The API lets you [specify the external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setexternalworkbook/) path and manage the linked data.

**Can I compute and display trendlines without implementing regression myself?**

Yes. [Trendlines](/slides/net/trend-line/) (linear, exponential, and others) are added and updated by Aspose.Slides; their parameters are recalculated from the series data automatically, so you don’t need to implement your own calculations.

**If a presentation has multiple charts with external links, can I control which workbook each chart uses for computed values?**

Yes. Each chart can point to its own [external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setexternalworkbook/), or you can create/replace an external workbook per chart independently of the others.
