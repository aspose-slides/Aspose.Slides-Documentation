---
title: API pública y cambios incompatibles con versiones anteriores en Aspose.Slides para Java 15.8.0
linktitle: Aspose.Slides para Java 15.8.0
type: docs
weight: 160
url: /es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Revise las actualizaciones de la API pública y los cambios incompatibles con versiones anteriores en Aspose.Slides para Java para migrar sin problemas sus soluciones de presentación PowerPoint PPT, PPTX y ODP."
---
{{% alert color="info" %}} 

Esta página enumera todas las [añadidas](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) o [eliminadas](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) clases, métodos, propiedades, etc., y otros cambios introducidos con la API de Aspose.Slides for Java 15.8.0.

{{% /alert %}} 
## **Cambios de la API pública**
#### **Métodos getDoughnutHoleSize(), setDoughnutHoleSize(byte) se han añadido a IChartSeries y ChartSeries**
Especifica el tamaño del agujero en un gráfico de rosquilla.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```