---
title: API Público y Cambios Incompatibles con Versiones Anteriores en Aspose.Slides para Java 15.8.0
type: docs
weight: 160
url: /es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las [clases añadidas](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) o [eliminadas](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/), métodos, propiedades, etc., y otros cambios introducidos con la API de Aspose.Slides para Java 15.8.0.

{{% /alert %}} 
## **Cambios en la API Pública**
#### **Se han agregado los métodos getDoughnutHoleSize(), setDoughnutHoleSize(byte) a IChartSeries y ChartSeries**
Especifica el tamaño del agujero en un gráfico de anillo.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```