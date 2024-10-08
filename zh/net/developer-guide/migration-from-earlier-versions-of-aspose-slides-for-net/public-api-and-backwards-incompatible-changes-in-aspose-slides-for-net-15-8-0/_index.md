---
title: Aspose.Slides for .NET 15.8.0 的公共 API 和向后不兼容的更改
type: docs
weight: 190
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
---

{{% alert color="primary" %}} 

此页面列出了与 Aspose.Slides for .NET 15.8.0 API 一起引入的所有 [添加](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) 或 [移除](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) 的类、方法、属性等，以及其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **属性 DoughnutHoleSize 已添加到 IChartSeries 和 ChartSeries**
指定甜甜圈图中孔的大小。

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

``` 