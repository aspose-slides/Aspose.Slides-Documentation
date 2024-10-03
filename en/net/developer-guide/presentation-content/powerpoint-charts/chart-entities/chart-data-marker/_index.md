---
title: Chart Data Marker
type: docs
url: /net/chart-data-marker/
keywords:
- chart marker options
- PowerPoint
- presentation
- C#
- Csharp
- Aspose.Slides for .NET
description: "Set chart marker options in PowerPoint presentations in C# or .NET"
---

## **Set Chart Marker Options**
The markers can be set on chart data points inside particular series. In order to set chart marker options. Please follow the steps below:

- Instantiate [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
- Creating the default chart.
- Set the picture.
- Take first chart series.
- Add new data point.
- Write presentation to disk.

In the example given below, we have set the chart marker options on data points level.

```c#
// Create an instance of Presentation class
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Creating the default chart
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// Getting the default chart data worksheet index
int defaultWorksheetIndex = 0;

// Getting the chart data worksheet
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Delete demo series
chart.ChartData.Series.Clear();

// Add new series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// Set the picture
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Set the picture
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// Take first chart series
IChartSeries series = chart.ChartData.Series[0];

// Add new point (1:3) there.
IChartDataPoint point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, (double)2.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, (double)3.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

// Changing the chart series marker
series.Marker.Size = 15;

// Write presentation to disk
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```

