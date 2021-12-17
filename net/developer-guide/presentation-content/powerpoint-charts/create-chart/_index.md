---
title: Create Chart
type: docs
weight: 10
url: /net/create-chart/
keywords: "Create chart, scattered chart, pie chart, tree map chart, stock chart, box and whisker chart, histogram chart, funnel chart, sunburst chart, multicategory chart, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Create chart in PowerPoint presentation in C# or .NET"
---

## **Create Chart**
Aspose.Slides for .NET allows developers to create custom charts from slides. Aspose.Slides for .NET creates charts independently of Aspose.Cells. 

Aspose.Slides for .Net has simple APIs that allow you to create different types of charts, update charts, and perform other tasks involving charts. 



## **Creating Normal Charts**
1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain the reference of a slide by index.
1. Add a chart with default data along with the desired type.
1. Add a chart title.
1. Access the chart data worksheet.
1. Clear all the default series and categories.
1. Add new series and categories.
1. Add new chart data for chart series.
1. Add fill color for chart series.
1. Add chart series labels.
1. Write the modified presentation as a PPTX file.

Sample code used to create a normal chart:

```c#
// Instantiate Presentation class that represents PPTX file
Presentation pres = new Presentation();

// Access first slide
ISlide sld = pres.Slides[0];

// Add chart with default data
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

// Setting chart Title
// Chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
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
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

// Adding new series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// Adding new categories
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// Take first chart series
IChartSeries series = chart.ChartData.Series[0];

// Now populating series data

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

// Setting fill color for series
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


// Take second chart series
series = chart.ChartData.Series[1];

// Now populating series data
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Setting fill color for series
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;

// First label will be show Category name
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

// Show value for third label
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";
            
// Save presentation with chart
pres.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
```


## **Creating Scattered Charts**
Sample code used to create a scatter chart with different series of markers:

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

// Creating the default chart
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

// Getting the default chart data worksheet index
int defaultWorksheetIndex = 0;

// Getting the chart data worksheet
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Delete demo series
chart.ChartData.Series.Clear();

// Add new series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

// Take first chart series
IChartSeries series = chart.ChartData.Series[0];

// Add new point (1:3) there.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

// Add new point (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

// Edit the type of series
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

// Changing the chart series marker
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

// Take second chart series
series = chart.ChartData.Series[1];

// Add new point (5:2) there.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

// Add new point (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

// Add new point (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

// Add new point (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

// Changing the chart series marker
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
```


## **Creating Pie Charts**
1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.Pie).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Add new points for charts and add custom colors for the pie chart's sectors.
1. Set labels for series.
1. Set leader lines for series labels.
1. Set the rotation angle for pie chart slides.
1. Write the modified presentation to a PPTX file

Sample code used to create a pie chart:

```c#
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

// Not working in new version
// Adding new points and setting sector color
// series.IsColorVaried = true;
chart.ChartData.SeriesGroups[0].IsColorVaried = true;

IChartDataPoint point = series.DataPoints[0];
point.Format.Fill.FillType = FillType.Solid;
point.Format.Fill.SolidFillColor.Color = Color.Cyan;
// Setting Sector border
point.Format.Line.FillFormat.FillType = FillType.Solid;
point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
point.Format.Line.Width = 3.0;
point.Format.Line.Style = LineStyle.ThinThick;
point.Format.Line.DashStyle = LineDashStyle.DashDot;

IChartDataPoint point1 = series.DataPoints[1];
point1.Format.Fill.FillType = FillType.Solid;
point1.Format.Fill.SolidFillColor.Color = Color.Brown;

// Setting Sector border
point1.Format.Line.FillFormat.FillType = FillType.Solid;
point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
point1.Format.Line.Width = 3.0;
point1.Format.Line.Style = LineStyle.Single;
point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

IChartDataPoint point2 = series.DataPoints[2];
point2.Format.Fill.FillType = FillType.Solid;
point2.Format.Fill.SolidFillColor.Color = Color.Coral;

// Setting Sector border
point2.Format.Line.FillFormat.FillType = FillType.Solid;
point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
point2.Format.Line.Width = 2.0;
point2.Format.Line.Style = LineStyle.ThinThin;
point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

// Create custom labels for each of categories for new series
IDataLabel lbl1 = series.DataPoints[0].Label;

// lbl.ShowCategoryName = true;
lbl1.DataLabelFormat.ShowValue = true;

IDataLabel lbl2 = series.DataPoints[1].Label;
lbl2.DataLabelFormat.ShowValue = true;
lbl2.DataLabelFormat.ShowLegendKey = true;
lbl2.DataLabelFormat.ShowPercentage = true;

IDataLabel lbl3 = series.DataPoints[2].Label;
lbl3.DataLabelFormat.ShowSeriesName = true;
lbl3.DataLabelFormat.ShowPercentage = true;

// Showing Leader Lines for Chart
series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

// Setting Rotation Angle for Pie Chart Sectors
chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

// Save presentation with chart
presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
```


## **Creating Tree Map Charts**
1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.TreeMap).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Write the modified presentation to a PPTX file

Sample code used to create a chart:

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.Treemap, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		//branch 1
		IChartCategory leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C1", "Leaf1"));
		leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
		leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "Leaf2"));

		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "Leaf3"));
		leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "Leaf4"));


		//branch 2
		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "Leaf5"));
		leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
		leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C6", "Leaf6"));

		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C7", "Leaf7"));
		leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C8", "Leaf8"));

		IChartSeries series = chart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Treemap);
		series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
		series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D1", 4));
		series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D2", 5));
		series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D3", 3));
		series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D4", 6));
		series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D5", 9));
		series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D6", 9));
		series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D7", 4));
		series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D8", 3));

		series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

		pres.Save("Treemap.pptx", SaveFormat.Pptx);
	}
}
```


## **Creating Stock Charts**
1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.OpenHighLowClose).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Specify HiLowLines format.
1. Write the modified presentation to a PPTX file

Sample code used to create a chart:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);

	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	chart.ChartData.Categories.Add(wb.GetCell(0, 1, 0, "A"));
	chart.ChartData.Categories.Add(wb.GetCell(0, 2, 0, "B"));
	chart.ChartData.Categories.Add(wb.GetCell(0, 3, 0, "C"));

	chart.ChartData.Series.Add(wb.GetCell(0, 0, 1, "Open"), chart.Type);
	chart.ChartData.Series.Add(wb.GetCell(0, 0, 2, "High"), chart.Type);
	chart.ChartData.Series.Add(wb.GetCell(0, 0, 3, "Low"), chart.Type);
	chart.ChartData.Series.Add(wb.GetCell(0, 0, 4, "Close"), chart.Type);

	IChartSeries series = chart.ChartData.Series[0];

	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 1, 72));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 1, 25));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 1, 38));

	series = chart.ChartData.Series[1];
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 2, 172));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 2, 57));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 2, 57));

	series = chart.ChartData.Series[2];
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 3, 12));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 3, 12));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 3, 13));

	series = chart.ChartData.Series[3];
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 4, 25));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 4, 38));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 4, 50));

	chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
	chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

	foreach (IChartSeries ser in chart.ChartData.Series)
	{
		ser.Format.Line.FillFormat.FillType = FillType.NoFill;
	}

	pres.Save("output.pptx", SaveFormat.Pptx);
}

		}
```


## **Creating Box and Whisker Charts**
1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.BoxAndWhisker).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		chart.ChartData.Categories.Add(wb.GetCell(0, "A1", "Category 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A2", "Category 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A3", "Category 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A4", "Category 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A5", "Category 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A6", "Category 1"));

		IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

		series.QuartileMethod = QuartileMethodType.Exclusive;
		series.ShowMeanLine = true;
		series.ShowMeanMarkers = true;
		series.ShowInnerPoints = true;
		series.ShowOutlierPoints = true;

		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B1", 15));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B2", 41));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B3", 16));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B4", 10));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B5", 23));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B6", 16));


		pres.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
	}
}
```


## **Creating Funnel Charts**
1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.Funnel).
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		chart.ChartData.Categories.Add(wb.GetCell(0, "A1", "Category 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A2", "Category 2"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A3", "Category 3"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A4", "Category 4"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A5", "Category 5"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A6", "Category 6"));

		IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B1", 50));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B2", 100));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B3", 200));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B4", 300));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B5", 400));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B6", 500));

		pres.Save("Funnel.pptx", SaveFormat.Pptx);
	}
}
```



## **Creating Sunburst Charts**
1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.sunburst).
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		//branch 1
		IChartCategory leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C1", "Leaf1"));
		leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
		leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "Leaf2"));

		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "Leaf3"));
		leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "Leaf4"));

		//branch 2
		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "Leaf5"));
		leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
		leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C6", "Leaf6"));

		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C7", "Leaf7"));
		leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C8", "Leaf8"));

		IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
		series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D1", 4));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D2", 5));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D3", 3));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D4", 6));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D5", 9));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D6", 9));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D7", 4));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D8", 3));

		pres.Save("Sunburst.pptx", SaveFormat.Pptx);
	}
}
```


## **Creating Histogram Charts**
1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.Histogram).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Histogram, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A1", 15));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A2", -41));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A3", 16));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A4", 10));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A5", -23));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A6", 16));

		chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

		pres.Save("Histogram.pptx", SaveFormat.Pptx);
	}
}
```


## **Creating Multi Category Charts**
1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.ClusteredColumn).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Write the modified presentation to a PPTX file.

The following code is used to create a chart.

```c#
Presentation pres = new Presentation();
ISlide slide = pres.Slides[0];

IChart ch = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
ch.ChartData.Series.Clear();
ch.ChartData.Categories.Clear();


IChartDataWorkbook fact = ch.ChartData.ChartDataWorkbook;
fact.Clear(0);
int defaultWorksheetIndex = 0;

IChartCategory category = ch.ChartData.Categories.Add(fact.GetCell(0, "c2", "A"));
category.GroupingLevels.SetGroupingItem(1, "Group1");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c3", "B"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c4", "C"));
category.GroupingLevels.SetGroupingItem(1, "Group2");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c5", "D"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c6", "E"));
category.GroupingLevels.SetGroupingItem(1, "Group3");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c7", "F"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c8", "G"));
category.GroupingLevels.SetGroupingItem(1, "Group4");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c9", "H"));

//            Adding Series
IChartSeries series = ch.ChartData.Series.Add(fact.GetCell(0, "D1", "Series 1"),
    ChartType.ClusteredColumn);

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D2", 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D3", 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D4", 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D5", 40));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D6", 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D7", 60));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D8", 70));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D9", 80));
// Save presentation with chart
pres.Save("AsposeChart_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Updating Charts**
To update a chart, do this:

- Open an instance of the [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class containing the chart.
- Obtain the reference of a slide by using its Index.
- Traverse through all shapes to find the desired chart.
- Access the chart data worksheet.
- Modify the chart data series data by changing series values.
- Add a new series and populate the data in it.
- Write the modified presentation as a PPTX file.

Code sample used to update a chart:

```c#
// Instantiate Presentation class that represents PPTX file// Instantiate Presentation class that represents PPTX file
Presentation pres = new Presentation("ExistingChart.pptx");

// Access first slideMarker
ISlide sld = pres.Slides[0];

// Add chart with default data
IChart chart = (IChart)sld.Shapes[0];

// Setting the index of chart data sheet
int defaultWorksheetIndex = 0;

// Getting the chart data worksheet
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;


// Changing chart Category Name
fact.GetCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
fact.GetCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");


// Take first chart series
IChartSeries series = chart.ChartData.Series[0];

// Now updating series data
fact.GetCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Modifying series name
series.DataPoints[0].Value.Data = 90;
series.DataPoints[1].Value.Data = 123;
series.DataPoints[2].Value.Data = 44;

// Take Second chart series
series = chart.ChartData.Series[1];

// Now updating series data
fact.GetCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Modifying series name
series.DataPoints[0].Value.Data = 23;
series.DataPoints[1].Value.Data = 67;
series.DataPoints[2].Value.Data = 99;


// Now, Adding a new series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.Type);

// Take 3rd chart series
series = chart.ChartData.Series[2];

// Now populating series data
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 3, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 30));

chart.Type = ChartType.ClusteredCylinder;

// Save presentation with chart
pres.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
```



## **Setting Data Range for Charts**

To set the data range for a chart, do this:

- Open an instance of the [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class containing the chart.
- Obtain the reference of a slide by using its Index.
- Traverse through all shapes to find the desired chart.
- Access the chart data and set the range.
- Save the modified presentation as a PPTX file.

Code sample used to set data range for a chart:

```c#
// Instantiate Presentation class that represents PPTX file
Presentation presentation = new Presentation("ExistingChart.pptx");

// Access first slideMarker and add chart with default data
ISlide slide = presentation.Slides[0];
IChart chart = (IChart)slide.Shapes[0];
chart.ChartData.SetRange("Sheet1!A1:B4");
presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
```


## **Using Default Markers in Charts**
Aspose.Slides for .NET has a simple API that can help you set the chart series marker automatically. When you use a default marker in charts, each chart series get different default marker symbols automatically.

Code sample used to set a chart series marker automatically:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;
    chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);
    IChartSeries series = chart.ChartData.Series[0];

    chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 1, 1, 24));
    chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 2, 1, 23));
    chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 3, 1, -10));
    chart.ChartData.Categories.Add(fact.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 4, 1, null));

    chart.ChartData.Series.Add(fact.GetCell(0, 0, 2, "Series 2"), chart.Type);
    //Take second chart series
    IChartSeries series2 = chart.ChartData.Series[1];

    //Now populating series data
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    pres.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```









