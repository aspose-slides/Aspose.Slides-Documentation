---
title: Ajouter des lignes de tendance aux graphiques de présentation en PHP
linktitle: Ligne de tendance
type: docs
url: /fr/php-java/trend-line/
keywords:
- graphique
- ligne de tendance
- ligne de tendance exponentielle
- ligne de tendance linéaire
- ligne de tendance logarithmique
- ligne de tendance moyenne mobile
- ligne de tendance polynomiale
- ligne de tendance puissance
- ligne de tendance personnalisée
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Ajoutez rapidement et personnalisez les lignes de tendance dans les graphiques PowerPoint avec Aspose.Slides for PHP via Java — un guide pratique pour captiver votre audience."
---

## **Ajouter une ligne de tendance**
Aspose.Slides for PHP via Java fournit une API simple pour gérer les différentes lignes de tendance de graphique :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (cet exemple utilise ChartType::ClusteredColumn).
1. Ajoutez une ligne de tendance exponentielle pour la série 1 du graphique.
1. Ajoutez une ligne de tendance linéaire pour la série 1 du graphique.
1. Ajoutez une ligne de tendance logarithmique pour la série 2 du graphique.
1. Ajoutez une ligne de tendance de moyenne mobile pour la série 2 du graphique.
1. Ajoutez une ligne de tendance polynomiale pour la série 3 du graphique.
1. Ajoutez une ligne de tendance de puissance pour la série 3 du graphique.
1. Enregistrez la présentation modifiée dans un fichier PPTX.

Le code suivant est utilisé pour créer un graphique avec des lignes de tendance.
```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Créer un graphique à colonnes groupées
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # Ajouter une ligne de tendance exponentielle pour la série 1 du graphique
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # Ajouter une ligne de tendance linéaire pour la série 1 du graphique
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Ajouter une ligne de tendance logarithmique pour la série 2 du graphique
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("New log trend line");
    # Ajouter une ligne de tendance moyenne mobile pour la série 2 du graphique
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("New TrendLine Name");
    # Ajouter une ligne de tendance polynomiale pour la série 3 du graphique
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # Ajouter une ligne de tendance puissance pour la série 3 du graphique
    $tredLinePower = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Power);
    $tredLinePower->setTrendlineType(TrendlineType::Power);
    $tredLinePower->setBackward(1);
    # Enregistrer la présentation
    $pres->save("ChartTrendLines_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Ajouter une ligne personnalisée**
Aspose.Slides for PHP via Java fournit une API simple pour ajouter des lignes personnalisées dans un graphique. Pour ajouter une simple ligne droite à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)
- Obtenez la référence d'une diapositive en utilisant son Index
- Créez un nouveau graphique à l'aide de la méthode AddChart exposée par l'objet Shapes
- Ajoutez une AutoShape de type Line à l'aide de la méthode AddAutoShape exposée par l'objet Shapes
- Définissez la couleur des lignes de la forme.
- Enregistrez la présentation modifiée en tant que fichier PPTX

Le code suivant est utilisé pour créer un graphique avec des lignes personnalisées.
```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $shape = $chart->getUserShapes()->getShapes()->addAutoShape(ShapeType::Line, 0, $chart->getHeight() / 2, $chart->getWidth(), 0);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("Presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**What do 'forward' and 'backward' mean for a trendline?**

Ce sont les longueurs de la ligne de tendance projetées vers l'avant/l'arrière : pour les graphiques de dispersion (XY) - en unités d'axe ; pour les graphiques non-dispersion - en nombre de catégories. Seules les valeurs non négatives sont autorisées.

**Will the trendline be preserved when exporting the presentation to PDF or SVG, or when rendering a slide to an image?**

Oui. Aspose.Slides convertit les présentations en [PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/)/[SVG](/slides/fr/php-java/render-a-slide-as-an-svg-image/) et rend les graphiques en images ; les lignes de tendance, en tant que partie du graphique, sont conservées lors de ces opérations. Une méthode est également disponible pour [exporter une image du graphique](/slides/fr/php-java/create-shape-thumbnails/) elle-même.