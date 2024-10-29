---
title: API Public et Changements Incompatibles avec les Versions Précédentes dans Aspose.Slides pour Java 15.8.0
type: docs
weight: 160
url: /fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les [ajoutées](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) ou [supprimées](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) classes, méthodes, propriétés, etc., et d'autres changements introduits avec l'API Aspose.Slides pour Java 15.8.0.

{{% /alert %}} 
## **Changements de l'API publique**
#### **Les méthodes getDoughnutHoleSize(), setDoughnutHoleSize(byte) ont été ajoutées à IChartSeries et ChartSeries**
Spécifie la taille du trou dans un graphique à beignet.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```