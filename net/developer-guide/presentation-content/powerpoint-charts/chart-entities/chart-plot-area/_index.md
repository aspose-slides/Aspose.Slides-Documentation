---
title: Chart Plot Area
type: docs
url: /net/chart-plot-area/
---

## **Get Width, Height of Chart Plot Area**
Aspose.Slides for .NET provides a simple API for . 

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Call method IChart.ValidateChartLayout() before to get actual values.
1. Gets actual X location (left) of the chart element relative to the left top corner of the chart.
1. Gets actual top of the chart element relative to the left top corner of the chart.
1. Gets actual width of the chart element.
1. Gets actual height of the chart element.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Charts();

using (Presentation pres = new Presentation(dataDir+"test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Save presentation with chart
	pres.Save(dataDir + "Chart_out.pptx", SaveFormat.Pptx);
}
```




## **Set Layout Mode of Chart Plot Area**
Aspose.Slides for .NET provides a simple API to set the layout mode of the chart plot area. Property **LayoutTargetType** has been added to **ChartPlotArea** and **IChartPlotArea** classes. If the layout of the plot area defined manually this property specifies whether to layout the plot area by its inside (not including axis and axis labels) or outside (including axis and axis labels). There are two possible values which are defined in **LayoutTargetType** enum.

- **LayoutTargetType.Inner** - specifies that the plot area size shall determine the size of the plot area, not including the tick marks and axis labels.
- **LayoutTargetType.Outer** - specifies that the plot area size shall determine the size of the plot area, the tick marks, and the axis labels.

Sample code is given below.

```c#
string dataDir = RunExamples.GetDataDir_Charts();
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save(dataDir + "SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```

