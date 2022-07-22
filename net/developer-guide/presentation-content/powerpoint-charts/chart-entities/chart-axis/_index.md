---
title: Chart Axis
type: docs
url: /net/chart-axis/
keywords: "PowerPoint Chart Axis, Presentation Charts, C#, .NET, Manipulate Chart Axis, Chart data"
description: "Edit PowerPoint chart axis in C# or .NET"
---


## **Getting the Max Values on the Vertical Axis on Charts**
Aspose.Slides for .NET allows you to obtain the minimum and maximum values on a vertical axis. Go through these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Access the first slide.
1. Add a chart with default data.
1. Get the actual maximum value on the axis.
1. Get the actual minimum value on the axis.
1. Get the actual major unit of the axis.
1. Get the actual minor unit of the axis.
1. Get the actual major unit scale of the axis.
1. Get the actual minor unit scale of the axis.

This sample code—an implementation of the steps above—shows you how to get the required values in C#:

```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// Saves the presentation
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```


## **Swapping the Data between Axes**
Aspose.Slides allows you to quickly swap the data between axes—the data represented on the vertical axis (y-axis) moves to the horizontal axis (x-axis) and vice versa. 

This C# code shows you how to perform the data swap task between axes on a chart:

```c#
// Creates empty presentation
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Switches rows and columns
	chart.ChartData.SwitchRowColumn();
		   
	// Saves presentation
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```

## **Disabling the Vertical Axis for Line Charts**

This C# code shows you how to hide the vertical axis for a line chart:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Disabling the Horizontal Axis for Line Charts**

This code shows you how to hide the horizontal axis for a line chart:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Changing Category Axis**

Using the **CategoryAxisType** property, you can specify your preferred category axis type (**date** or **text**). This code in C# demonstrates the operation: 

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes[0] as IChart;
    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;
    presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
}
```

## **Setting the Date Format for Category Axis Value**
Aspose.Slides for .NET allows you to set the date format for a category axis value. The operation is demonstrated in this C# code:

```c#
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
	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Setting the Rotation Angle for Chart Axis Title**
Aspose.Slides for .NET allows you to set the rotation angle for a chart axis title. This C# code demonstrates the operation:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Setting the Position Axis in a Category or Value Axis**
Aspose.Slides for .NET allows you to set the position axis in a category or value axis. This C# code shows how to perform the task:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **Enabling the Display Unit label on Chart Value Axis**
Aspose.Slides for .NET allows you to configure a chart to show a unit label on its chart value axis. This C# code demonstrates the operation:

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```