---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for .NET 15.8.0
type: docs
weight: 190
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) or [removed](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for .NET 15.8.0 API.

{{% /alert %}} 
## **Public API Changes**
#### **Property DoughnutHoleSize has been added to IChartSeries and ChartSeries**
Specifies the size of the hole in a doughnut chart.

{{< highlight java >}}

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

{{< /highlight >}}
