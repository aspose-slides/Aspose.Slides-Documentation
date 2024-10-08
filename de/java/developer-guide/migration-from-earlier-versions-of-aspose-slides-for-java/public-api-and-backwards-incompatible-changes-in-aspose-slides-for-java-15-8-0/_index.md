---
title: Öffentliches API und rückwärtsinkompatible Änderungen in Aspose.Slides für Java 15.8.0
type: docs
weight: 160
url: /de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) oder [entfernten](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) Klassen, Methoden, Eigenschaften usw. sowie andere Änderungen auf, die mit der Aspose.Slides für Java 15.8.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
#### **Methoden getDoughnutHoleSize(), setDoughnutHoleSize(byte) wurden zu IChartSeries und ChartSeries hinzugefügt**
Gibt die Größe des Lochs in einem Donut-Diagramm an.

``` java

 Präsentation pres = new Präsentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```