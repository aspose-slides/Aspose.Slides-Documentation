---
title: Pie Chart
type: docs
url: /net/pie-chart/
---

## **Second Plot Options for Pie of Pie and Bar of Pie Chart**
Aspose.Slides for .NET now supports, second plot options for Pie of Pie or Bar of Pie chart. In this topic, we will see with example how to Specify these options using Aspose.Slides. In order to specify the properties. Please follow the steps below:

1. Instantiate [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class object.
1. Add chart on the slide.
1. Specify the second plot options of chart.
1. Write presentation to disk.

In the example given below, we have set different properties of Pie of Pie chart.

```c#
// Create an instance of Presentation class
Presentation presentation = new Presentation();

// Add chart on slide
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// Set different properties
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// Write presentation to disk
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```




## **Set Automatic Pie Chart Slice Colors**
Aspose.Slides for .NET provides a simple API for setting automatic pie chart slide colors. The sample code applies setting the above said properties.

1. Create an instance of the Presentation class.
1. Access first slide.
1. Add chart with default data.
1. Set chart Title.
1. Set first series to Show Values.
1. Set the index of chart data sheet.
1. Getting the chart data worksheet.
1. Delete default generated series and categories.
1. Add new categories.
1. Add new series.

Write the modified presentation to a PPTX file.

```c#
// Instantiate Presentation class that represents PPTX file
using (Presentation presentation = new Presentation())
{
	// Instantiate Presentation class that represents PPTX file
	Presentation presentation = new Presentation();

	// Access first slide
	ISlide slides = presentation.Slides[0];

	// Add chart with default data
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// Setting chart Title
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// Set first series to Show Values
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// Setting the index of chart data sheet
	int defaultWorksheetIndex = 0;

	// Getting the chart data worksheet
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// Delete default generated series and categories
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// Adding new categories
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// Adding new series
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// Now populating series data
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

