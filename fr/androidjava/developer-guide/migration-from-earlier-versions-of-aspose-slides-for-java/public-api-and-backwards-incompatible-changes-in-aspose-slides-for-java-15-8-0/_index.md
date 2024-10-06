---
title: API public et changements incompatibles en arrière dans Aspose.Slides pour Java 15.8.0
type: docs
weight: 160
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés, et autres éléments [ajoutés](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) ou [supprimés](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) ainsi que d'autres changements introduits avec l'API Aspose.Slides pour Java 15.8.0.

{{% /alert %}} 
## **Changements de l'API publique**
#### **Les méthodes getDoughnutHoleSize(), setDoughnutHoleSize(byte) ont été ajoutées à IChartSeries et ChartSeries**
Spécifie la taille du trou dans un graphique en anneau.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```