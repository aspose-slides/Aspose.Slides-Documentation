---
title: Personnaliser les graphiques à bulles dans les présentations avec PHP
linktitle: Graphique à bulles
type: docs
url: /fr/php-java/bubble-chart/
keywords:
- graphique à bulles
- taille de la bulle
- mise à l'échelle de la taille
- représentation de la taille
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Créez et personnalisez des graphiques à bulles puissants dans PowerPoint avec Aspose.Slides for PHP via Java pour améliorer facilement votre visualisation de données."
---

## **Mise à l'échelle de la taille du graphique à bulles**
Aspose.Slides for PHP via Java fournit une prise en charge de la mise à l'échelle de la taille du graphique à bulles. Dans Aspose.Slides for PHP via Java les méthodes [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) et [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) ont été ajoutées. Un exemple de code est donné ci‑dessous.
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
Les méthodes [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) et [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) ont été ajoutées aux interfaces [IChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup) ainsi qu'aux classes associées. **BubbleSizeRepresentation** indique comment les valeurs de taille des bulles sont représentées dans le graphique à bulles. Les valeurs possibles sont : [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Area) et [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Width). En conséquence, l’énumération [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType) a été ajoutée pour spécifier les différentes manières de représenter les données comme tailles de graphique à bulles. Un exemple de code est fourni ci‑dessous.
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

**Un « graphique à bulles avec effet 3D » est‑il pris en charge, et en quoi diffère‑t‑il d’un graphique standard ?**

Oui. Il existe un type de graphique distinct, « Bubble with 3-D ». Il applique un style 3‑D aux bulles mais n’ajoute pas d’axe supplémentaire ; les données restent X‑Y‑S (taille). Ce type est disponible dans la classe [chart type](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/).

**Existe‑t‑il une limite au nombre de séries et de points dans un graphique à bulles ?**

Il n’y a pas de limite stricte au niveau de l’API ; les contraintes sont déterminées par les performances et la version cible de PowerPoint. Il est recommandé de garder le nombre de points raisonnable pour la lisibilité et la vitesse de rendu.

**Comment l’exportation affecte‑t‑elle l’apparence d’un graphique à bulles (PDF, images) ?**

L’exportation vers les formats pris en charge conserve l’apparence du graphique ; le rendu est effectué par le moteur Aspose.Slides. Pour les formats raster/vectoriels, les règles générales de rendu des graphiques s’appliquent (résolution, anti‑aliasing), il faut donc choisir un DPI suffisant pour l’impression.