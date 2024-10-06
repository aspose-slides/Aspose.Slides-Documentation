---
title: API Public et Changements Incompatibles dans Aspose.Slides pour PHP via Java 15.8.0
type: docs
weight: 160
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés, etc., [ajoutées](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) ou [supprimées](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/), ainsi que d'autres changements introduits avec l'API Aspose.Slides pour PHP via Java 15.8.0.

{{% /alert %}} 
## **Changements de l'API Public**
#### **Les méthodes getDoughnutHoleSize(), setDoughnutHoleSize(byte) ont été ajoutées à IChartSeries et ChartSeries**
Spécifie la taille du trou dans un graphique en anneau.

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
  $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
  $pres->save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat::Pptx);

```