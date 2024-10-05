---
title: Aspose.Slides for .NET 15.8.0における公開APIと後方互換性のない変更
type: docs
weight: 190
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 15.8.0 APIで追加されたすべての[class](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/)または[削除された](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/)クラス、メソッド、プロパティなど、およびその他の変更を一覧表示します。

{{% /alert %}} 
## **公開APIの変更**
#### **プロパティDoughnutHoleSizeがIChartSeriesおよびChartSeriesに追加されました**
ドーナツチャートの穴のサイズを指定します。

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

``` 