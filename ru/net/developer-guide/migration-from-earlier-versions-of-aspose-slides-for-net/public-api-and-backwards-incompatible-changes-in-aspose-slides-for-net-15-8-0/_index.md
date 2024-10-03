---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 15.8.0
type: docs
weight: 190
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) или [удаленных](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) классов, методов, свойств и так далее, а также других изменений, внесенных в API Aspose.Slides для .NET 15.8.0.

{{% /alert %}} 
## **Изменения в публичном API**
#### **Свойство DoughnutHoleSize добавлено в IChartSeries и ChartSeries**
Указывает размер отверстия в кольцевой диаграмме.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```