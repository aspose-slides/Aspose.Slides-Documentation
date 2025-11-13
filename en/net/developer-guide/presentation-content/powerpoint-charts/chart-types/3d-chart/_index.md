---
title: Customize 3D Charts in Presentations in .NET
linktitle: 3D Chart
type: docs
url: /net/3d-chart/
keywords:
- 3D chart
- rotation
- depth
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Learn how to create and customize 3-D charts in Aspose.Slides for .NET, with support for PPT and PPTX files—boost your presentations today."
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

## **FAQ**

**Which chart types support 3D mode in Aspose.Slides?**

Aspose.Slides supports 3D variants of column charts, including Column 3D, Clustered Column 3D, Stacked Column 3D, and 100% Stacked Column 3D, along with related 3D types exposed through the [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) enumeration. For an exact, up-to-date list, check the [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) members in the API reference of your installed version.

**Can I get a raster image of a 3D chart for a report or the web?**

Yes. You can export a chart to an image via the [chart API](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) or [render the entire slide](/slides/net/convert-powerpoint-to-png/) to formats like PNG or JPEG. This is useful when you need a pixel-perfect preview or want to embed the chart into documents, dashboards, or web pages without requiring PowerPoint.

**How performant is building and rendering large 3D charts?**

Performance depends on data volume and visual complexity. For best results, keep 3D effects minimal, avoid heavy textures on walls and plot areas, limit the number of data points per series when possible, and render to an appropriately sized output (resolution and dimensions) to match the target display or print needs.
