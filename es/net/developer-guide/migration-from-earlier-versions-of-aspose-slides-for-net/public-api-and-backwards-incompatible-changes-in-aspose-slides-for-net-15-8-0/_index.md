---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para .NET 15.8.0
linktitle: Aspose.Slides para .NET 15.8.0
type: docs
weight: 190
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- migración
- código legado
- código moderno
- enfoque legado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Revise las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides para .NET para migrar sin problemas sus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---

{{% alert color="primary" %}} 

Esta página enumera todas las [agregadas](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) o [eliminadas](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) clases, métodos, propiedades y demás, y otros cambios introducidos con la API de Aspose.Slides for .NET 15.8.0.

{{% /alert %}} 
## **Cambios de la API pública**
#### **La propiedad DoughnutHoleSize se ha agregado a IChartSeries y ChartSeries**
Especifica el tamaño del agujero en un gráfico de rosquilla.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```