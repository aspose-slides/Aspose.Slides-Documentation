---
title: Bubble Chart
type: docs
url: /net/bubble-chart/
---

## **Bubble Chart Size Scaling**
Aspose.Slides for .NET provides support for Bubble chart size scaling. In Aspose.Slides for .NET **IChartSeries.BubbleSizeScale** and **IChartSeriesGroup.BubbleSizeScale** properties have been added. Below sample example is given. 

```c#
string dataDir = RunExamples.GetDataDir_Charts();
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save(dataDir+"Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```




## **Represent Data as Bubble Chart Sizes**
Property **BubbleSizeRepresentation** has been added to IChartSeries, IChartSeriesGroup interfaces, and related classes. **BubbleSizeRepresentation** specifies how the bubble size values are represented in the bubble chart. Possible values are: **BubbleSizeRepresentationType.Area** and **BubbleSizeRepresentationType.Width**. Accordingly, **BubbleSizeRepresentationType** enum has been added to specify the possible ways to represent data as bubble chart sizes. Sample code is given below.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Charts();

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save(dataDir+ "Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```

