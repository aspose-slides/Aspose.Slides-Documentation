---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for .NET 15.2.0
type: docs
weight: 140
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) or [removed](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for .NET 15.2.0 API.

{{% /alert %}} 
## **Public API Changes**
#### **AddDataPointForDoughnutSeries methods have been added**
The two overloads of IChartDataPointCollection.AddDataPointForDoughnutSeries() method have been added for adding data points into series of Doughnut chart type.
#### **Aspose.Slides.SmartArt.SmartArtShape class has been inherited from Aspose.Slides.GeometryShape class**
Aspose.Slides.SmartArt.SmartArtShape class has been inherited from Aspose.Slides.GeometryShape class. This change improves Aspose.Slides object model and adds new features to SmartArtShape class.
#### **Methods for removing chart data point and chart category by index has been added**
IChartDataPointCollection.RemoveAt(int index) method has been added for removing chart data point by its index.
IChartCategoryCollection.RemoveAt(int index) method has been added for removing chart category by its index.
#### **PptXPptY value has been added to Aspose.Slides.Animation.PropertyType enumeration**
PptXPptY value has been added to Aspose.Slides.Animation.PropertyType enumeration in the scope of a serialization issue fix.
#### **System.Drawing.Color GetAutomaticSeriesColor() method has been added to Aspose.Slides.Charts.IChartSeries**
GetAutomaticSeriesColor method returns an automatic color of series based on series index and chart style. This color is used by default if FillType equals NotDefined.

``` csharp



using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}

``` 
