---
title: Öffentliches API und nicht rückwärtskompatible Änderungen in Aspose.Slides für Java 15.8.0
type: docs
weight: 160
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) oder [entfernten](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) Klassen, Methoden, Eigenschaften usw. auf und andere Änderungen, die mit der Aspose.Slides für Java 15.8.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen an der öffentlichen API**
#### **Methoden getDoughnutHoleSize(), setDoughnutHoleSize(byte) wurden zu IChartSeries und ChartSeries hinzugefügt**
Bestimmt die Größe des Lochs in einem Donut-Diagramm.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```