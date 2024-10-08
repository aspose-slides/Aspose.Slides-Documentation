---
title: Ligne de Tendance
type: docs
url: /fr/php-java/ligne-de-tendance/
---

## **Ajouter une Ligne de Tendance**
Aspose.Slides pour PHP via Java fournit une API simple pour gérer différentes Lignes de Tendance de graphique :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenez la référence d'une diapositive par son index.
1. Ajoutez un graphique avec des données par défaut ainsi qu'un type désiré (cet exemple utilise ChartType::ClusteredColumn).
1. Ajouter une ligne de tendance exponentielle pour la série de graphique 1.
1. Ajouter une ligne de tendance linéaire pour la série de graphique 1.
1. Ajouter une ligne de tendance logarithmique pour la série de graphique 2.
1. Ajouter une ligne de tendance de moyenne mobile pour la série de graphique 2.
1. Ajouter une ligne de tendance polynomiale pour la série de graphique 3.
1. Ajouter une ligne de tendance de puissance pour la série de graphique 3.
1. Écrire la présentation modifiée dans un fichier PPTX.

Le code suivant est utilisé pour créer un graphique avec des Lignes de Tendance.

```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Création d'un graphique en colonnes groupées
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # Ajouter une ligne de tendance exponentielle pour la série de graphique 1
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # Ajouter une ligne de tendance linéaire pour la série de graphique 1
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Ajouter une ligne de tendance logarithmique pour la série de graphique 2
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("Nouvelle ligne de tendance logarithmique");
    # Ajouter une ligne de tendance de moyenne mobile pour la série de graphique 2
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("Nouveau Nom de Ligne de Tendance");
    # Ajouter une ligne de tendance polynomiale pour la série de graphique 3
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # Ajouter une ligne de tendance de puissance pour la série de graphique 3
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

## **Ajouter une Ligne Personnalisée**
Aspose.Slides pour PHP via Java fournit une API simple pour ajouter des lignes personnalisées dans un graphique. Pour ajouter une ligne simple sur une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)
- Obtenez la référence d'une diapositive en utilisant son index
- Créez un nouveau graphique en utilisant la méthode AddChart exposée par l'objet Shapes
- Ajoutez une forme automatique de type Ligne en utilisant la méthode AddAutoShape exposée par l'objet Shapes
- Définissez la couleur des lignes de la forme.
- Écrivez la présentation modifiée sous forme de fichier PPTX

Le code suivant est utilisé pour créer un graphique avec des Lignes Personnalisées.

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