---
title: API Pública y Cambios Incompatibles hacia Atrás en Aspose.Slides para Java 15.8.0
type: docs
weight: 160
url: /es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las clases, métodos, propiedades, etc., [agregados](/slides/es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) o [eliminados](/slides/es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/), y otros cambios introducidos con la API de Aspose.Slides para Java 15.8.0.

{{% /alert %}} 
## **Cambios en la API Pública**
#### **Métodos getDoughnutHoleSize(), setDoughnutHoleSize(byte) han sido agregados a IChartSeries y ChartSeries**
Especifica el tamaño del hueco en un gráfico de dona.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```