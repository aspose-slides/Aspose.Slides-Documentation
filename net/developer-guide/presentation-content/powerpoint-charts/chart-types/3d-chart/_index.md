---
title: 3D Chart
type: docs
url: /net/3d-chart/
keywords: "3d chart, rotationX, rotationY, depthpercent, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Set rotationX, rotationY, and depthpercents for 3D chart in PowerPoint presentation in C# or .NET"
---

## **Set RotationX, RotationY and DepthPercents properties of 3D Chart**
Aspose.Slides for .NET provides a simple API for setting these properties. This following article will help you how set different properties like X,Y Rotation , **DepthPercents** etc. The sample code applies setting the above said properties.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Set Rotation3D properties.
1. Write the modified presentation to a PPTX file.

```c#
// Create an instance of Presentation class
Presentation presentation = new Presentation();
           
// Access first slide
ISlide slide = presentation.Slides[0];

// Add chart with default data
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

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

// Set Rotation3D properties
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// Take second chart series
IChartSeries series = chart.ChartData.Series[1];

// Now populating series data
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Set OverLap value
series.ParentSeriesGroup.Overlap = 100;         

// Write presentation to disk
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

