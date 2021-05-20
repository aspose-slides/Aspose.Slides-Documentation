---
title: Chart Axis
type: docs
url: /net/chart-axis/
---


## **Get Actual Max Value of Vertical Axis on Chart**
Aspose.Slides for .NET provides a simple API for getting value of vertical axis. 

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Get actual maximum value on the axis.
1. Get actual minimum value on the axis.
1. Get actual major unit of the axis.
1. Get actual minor unit of the axis.
1. Get actual major unit scale of the axis.
1. Get actual minor unit scale of the axis.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Charts();

using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// Saving presentation
	presentation.Save(dataDir + "ErrorBars_out.pptx", SaveFormat.Pptx);
}
```




## **Switch Data Over Axis**
A new property has been added which Swap the data over the axis. Data being charted on the X axis will move to the Y axis and vice versa. Below sample example is given.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Charts();

// Creating empty presentation
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Switching rows and columns
	chart.ChartData.SwitchRowColumn();
		   
	// Saving presentation
	 pres.Save(dataDir + "SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```


## **Change Category Axis**
**CategoryAxisType** can be changed to Date or Text.However, **CategoryAxisType.Auto** is not supported at the moment. New property **CategoryAxisType** has been added to **IAxis** and Axis classes which specifies type of category axis.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Charts();

using (Presentation presentation = new Presentation(dataDir + "ExistingChart.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes[0] as IChart;
    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;
    presentation.Save(dataDir + "ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
}
```



## **Set Date Format for Category Axis Value**
Aspose.Slides for .NET provides a simple API for setting date format for category axis value. Below sample example is given. 

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Charts();
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Area, 50, 50, 450, 300);

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Add(wb.GetCell(0, "A2", new DateTime(2015, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A3", new DateTime(2016, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A4", new DateTime(2017, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A5", new DateTime(2018, 1, 1).ToOADate()));

	IChartSeries series = chart.ChartData.Series.Add(ChartType.Line);
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 1));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 2));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 3));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 4));
	chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
	chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
	chart.Axes.HorizontalAxis.NumberFormat = "yyyy";
	pres.Save(dataDir+"test.pptx", SaveFormat.Pptx);
}
```



## **Set Rotation Angle for Chart Axis Title**
Aspose.Slides for .NET provides a simple API for setting rotation angle for chart axis title. Below sample example is given. 

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Charts();
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save(dataDir + "test.pptx", SaveFormat.Pptx);
}
```



## **Set Position Axis in Category or Value Axis**
Aspose.Slides for .NET provides a simple API for setting Position axis in category or Value axis. Below sample example is given. 

```c#
string dataDir = RunExamples.GetDataDir_Charts();
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save(dataDir + "AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```



## **Show Display Unit label on Chart Value Axis**
Aspose.Slides for .NET provides support for showing Display unit label on chart value axis. Below sample example is given. 

```c#
string dataDir = RunExamples.GetDataDir_Charts();
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save(dataDir + "Result.pptx", SaveFormat.Pptx);
}
```

