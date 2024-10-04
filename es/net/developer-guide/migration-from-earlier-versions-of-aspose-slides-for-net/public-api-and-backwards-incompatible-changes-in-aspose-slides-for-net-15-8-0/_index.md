---
title: API pública y cambios incompatibles con versiones anteriores en Aspose.Slides para .NET 15.8.0
type: docs
weight: 190
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
---

{{% alert color="primary" %}} 

Esta página enumera todas las clases [agregadas](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) o [eliminadas](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/), métodos, propiedades, etc., y otros cambios introducidos con la API de Aspose.Slides para .NET 15.8.0.

{{% /alert %}} 
## **Cambios en la API pública**
#### **Se ha agregado la propiedad DoughnutHoleSize a IChartSeries y ChartSeries**
Especifica el tamaño del agujero en un gráfico de dona.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

``` 