---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para .NET 15.8.0
linktitle: Aspose.Slides para .NET 15.8.0
type: docs
weight: 190
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Revise las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides para .NET para migrar sin problemas sus soluciones de presentación PowerPoint PPT, PPTX y ODP."
---

{{% alert color="primary" %}} 

Esta página enumera todas las clases, métodos, propiedades y demás [añadido](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) o [eliminado](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) y otros cambios introducidos con la API de Aspose.Slides for .NET 15.8.0.

{{% /alert %}} 
## **Cambios de la API pública**
#### **La propiedad DoughnutHoleSize se ha añadido a IChartSeries y ChartSeries**
Especifica el tamaño del agujero en un gráfico de dona.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```