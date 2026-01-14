---
title: Personnaliser les graphiques à bulles dans les présentations avec PHP
linktitle: Graphique à bulles
type: docs
url: /fr/php-java/bubble-chart/
keywords:
- graphique à bulles
- taille de bulle
- mise à l'echelle de la taille
- representation de la taille
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Creez et personnalisez des graphiques à bulles puissants dans PowerPoint avec Aspose.Slides pour PHP via Java afin d'améliorer facilement votre visualisation de données."
---

## **Mise à l'échelle de la taille du graphique à bulles**
Aspose.Slides for PHP via Java prend en charge la mise à l'échelle de la taille du graphique à bulles. Dans Aspose.Slides for PHP via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbubblesizescale/), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/) et [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/) ont été ajoutées. Un exemple est donné ci‑dessous. 
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 100, 100, 400, 300);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);
    $pres->save("Result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Représenter les données comme tailles de graphique à bulles**
Des méthodes [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) et [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/) ont été ajoutées aux classes [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/), [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) et aux classes associées. **BubbleSizeRepresentation** spécifie la façon dont les valeurs de taille de bulles sont représentées dans le graphique à bulles. Les valeurs possibles sont [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Area) et [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Width). En conséquence, l’énumération [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType) a été ajoutée pour spécifier les manières possibles de représenter les données comme tailles de graphique à bulles. Le code d’exemple est donné ci‑dessous.
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(BubbleSizeRepresentationType::Width);
    $pres->save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Une « graphique à bulles avec effet 3‑D » est‑elle prise en charge, et en quoi diffère‑t‑elle d’une graphique ordinaire ?**

Oui. Il existe un type de graphique distinct, « Bubble with 3‑D ». Il applique un style 3‑D aux bulles mais n’ajoute pas d’axe supplémentaire ; les données restent X‑Y‑S (taille). Le type est disponible dans la classe [chart type](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/).

**Existe‑t‑il une limite au nombre de séries et de points dans un graphique à bulles ?**

Il n’y a pas de limite stricte au niveau de l’API ; les contraintes sont déterminées par les performances et la version cible de PowerPoint. Il est recommandé de garder le nombre de points raisonnable pour la lisibilité et la vitesse de rendu.

**Comment l’exportation affecte‑t‑elle l’apparence d’un graphique à bulles (PDF, images) ?**

L’exportation vers les formats pris en charge conserve l’apparence du graphique ; le rendu est effectué par le moteur Aspose.Slides. Pour les formats raster/vectoriels, les règles générales de rendu des graphiques (résolution, anti‑aliasing) s’appliquent, il faut donc choisir une DPI suffisante pour l’impression.