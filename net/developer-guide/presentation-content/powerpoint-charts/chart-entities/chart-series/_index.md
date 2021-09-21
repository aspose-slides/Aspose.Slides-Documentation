---
title: Chart Series
type: docs
url: /net/chart-series/
---

## **Set Chart Series Overlap**
Aspose.Slides for .NET provides a simple API interface to set chart series overlap. The **Aspose.Slides.Charts.IChartSeries.Overlap** property specifies how much bars and columns should overlap on 2D charts (in a range from -100 to 100). This property is not only for the referred series but for all series of the parent series group: this is projection of the appropriate group property. Therefore, this property is read-only. Use the **ParentSeriesGroup** property to access the parent series group, and then access the **ParentSeriesGroup.Overlap** read/write property to change the value.

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Add a clustered column chart on a slide.
1. Access the first chart series.
1. Access the selected serie's **ParentSeriesGroup** and set the chart series overlap value.
1. Write the modified presentation to a PPTX file.

```c#
using (Presentation presentation = new Presentation())
{
    // Adding chart
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.ChartData.Series;
    if (series[0].Overlap == 0)
    {
        // Setting series overlap
        series[0].ParentSeriesGroup.Overlap = -30;
    }

    // Write the presentation file to disk
    presentation.Save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
}
```



## **Change Series Color**
Aspose.Slides for .NET provides support for changing series color. 

1. Instantiate [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class object.
1. Add chart on the slide.
1. Access specific series of chart.
1. Set fill type and fill color.
1. Save modified presentation.

Below sample example is given. 

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 600, 400);
	IChartDataPoint point = chart.ChartData.Series[0].DataPoints[1];
	
	point.Explosion = 30;
	point.Format.Fill.FillType = FillType.Solid;
	point.Format.Fill.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```



## **Change Color of Categories in Series**
Aspose.Slides for .NET provides support for changing color of categories in a series color. 

1. Instantiate [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class object.
1. Add chart on the slide.
1. Access specific series of chart.
1. Set fill type and fill color.
1. Save modified presentation.

Below sample example is given. 

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartDataPoint point = chart.ChartData.Series[0].DataPoints[0];
	
	point.Format.Fill.FillType = FillType.Solid;
	point.Format.Fill.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```




## **Set Chart Series Fill Colors**
Aspose.Slides for .NET provides a simple API for setting automatic fill color for chart series inside plot area:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (this example uses **ChartType.ClusteredColumn**).
1. Accessing the chart series and setting the fill color to Automatic.
1. Save the presentation to a PPTX file.

```c#
using (Presentation presentation = new Presentation())
{
    // Creating a clustered column chart
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Setting series fill format to automatic
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series[i].GetAutomaticSeriesColor();
    }

    // Write the presentation file to disk
    presentation.Save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
}
```



## **Set Chart Series Invert Fill Colors**
Aspose.Slides for .NET provides a simple API for setting invert fill color for chart series inside plot area:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (this example uses **ChartType.ClusteredColumn**).
1. Accessing the chart series and setting the fill color to invert.
1. Save the presentation to a PPTX file.

```c#
Color inverColor = Color.Red;
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Adding new series and categories
    chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // Take first chart series and populating series data.
    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;
    pres.Save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);               
}
```




## **Set Invert If Negative Property for Individual Series**
The Aspose.Slides for .NET lets developers allow to set inverts. **IChartDataPoint.InvertIfNegative** and **ChartDataPoint.InvertIfNegative** properties have been added. This Specifies the data point shall invert its colors if the value is negative. Sample code is given below.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
	IChartSeriesCollection series = chart.ChartData.Series;
	chart.ChartData.Series.Clear();

	series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -2));
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

	series[0].InvertIfNegative = false;

	series[0].DataPoints[2].InvertIfNegative = true;

	pres.Save("out.pptx", SaveFormat.Pptx);
}
```



## **Clear Specific Chart Series Data Points Data**
Aspose.Slides for .NET provides a simple API to clear specific chart series **DataPoints** data. To clear specific chart series **DataPoints** data, please follow the steps below:

- Create an instance of Presentation class and load the desired presentation.
- Obtain the reference of a slide by using its Index
- Obtain the reference of a chart by using its Index
- Iterate through all the **DataPoints** of chart and set **XValue** and **YValue** to null.
- Remove all **DataPoints** of specific chart series
- Write the modified presentation to a PPTX file

Sample code is given below.

```c#
using (Presentation pres = new Presentation("TestChart.pptx"))
{
	ISlide sl = pres.Slides[0];

	IChart chart = (IChart)sl.Shapes[0];

	foreach (IChartDataPoint dataPoint in chart.ChartData.Series[0].DataPoints)
	{
		dataPoint.XValue.AsCell.Value = null;
		dataPoint.YValue.AsCell.Value = null;
	}

	chart.ChartData.Series[0].DataPoints.Clear();

	pres.Save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
}
```



## **Set GapWidth Property of Chart Series**
Aspose.Slides for .NET provides a simple API for setting **GapWidth** property. The sample code applies setting the **GapWidth** property.

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Access any chart series.
1. Set GapWidth property.
1. Write the modified presentation to a PPTX file.

```c#
// Creating empty presentation 
Presentation presentation = new Presentation();

// Access first slide
ISlide slide = presentation.Slides[0];

// Add chart with default data
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 0, 0, 500, 500);

// Setting the index of chart data sheet
int defaultWorksheetIndex = 0;

// Getting the chart data worksheet
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Add series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// Add Catrgories
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// Take second chart series
IChartSeries series = chart.ChartData.Series[1];

// Now populating series data
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Set GapWidth value
series.ParentSeriesGroup.GapWidth = 50;

// Save presentation with chart
presentation.Save("GapWidth_out.pptx", SaveFormat.Pptx);
```

