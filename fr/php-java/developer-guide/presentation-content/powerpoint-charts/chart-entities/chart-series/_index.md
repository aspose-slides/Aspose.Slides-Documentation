---
title: Séries de Graphiques
type: docs
url: /php-java/chart-series/
keywords: "Séries de graphiques, couleur des séries, présentation PowerPoint, Java, Aspose.Slides pour PHP via Java"
description: "Séries de graphiques dans les présentations PowerPoint"
---

Une série est une ligne ou colonne de nombres tracés dans un graphique.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Définir le Chevauchement des Séries de Graphiques**

Avec la propriété [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap), vous pouvez spécifier à quel point les barres et les colonnes doivent se chevaucher sur un graphique 2D (plage : -100 à 100). Cette propriété s'applique à toutes les séries du groupe de séries parente : il s'agit d'une projection de la propriété appropriée du groupe. Par conséquent, cette propriété est en lecture seule. 

Utilisez la propriété en lecture/écriture `ParentSeriesGroup.Overlap` pour définir votre valeur préférée pour `Overlap`. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Ajoutez un graphique à colonnes groupées sur une diapositive.
1. Accédez à la première série de graphiques.
1. Accédez au `ParentSeriesGroup` de la série de graphiques et définissez votre valeur de chevauchement préférée pour la série. 
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code PHP vous montre comment définir le chevauchement d'une série de graphiques :

```php
  $pres = new Presentation();
  try {
    # Ajoute un graphique
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # Définit le chevauchement de la série
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # Écrit le fichier de présentation sur le disque
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Changer la Couleur de la Série**
Aspose.Slides pour PHP via Java vous permet de changer la couleur d'une série de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Ajoutez un graphique sur la diapositive.
1. Accédez à la série dont vous souhaitez changer la couleur. 
1. Définissez votre type de remplissage et votre couleur de remplissage préférés.
1. Enregistrez la présentation modifiée.

Ce code PHP vous montre comment changer la couleur d'une série :

```php
  $pres = new Presentation("test.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(1);
    $point->setExplosion(30);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Changer la Couleur de la Catégorie de la Série**
Aspose.Slides pour PHP via Java vous permet de changer la couleur de la catégorie d'une série de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Ajoutez un graphique sur la diapositive.
1. Accédez à la catégorie de la série dont vous souhaitez changer la couleur.
1. Définissez votre type de remplissage et votre couleur de remplissage préférés.
1. Enregistrez la présentation modifiée.

Ce code vous montre comment changer la couleur de la catégorie d'une série :

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Changer le Nom de la Série** 

Par défaut, les noms de légende pour un graphique sont le contenu des cellules au-dessus de chaque colonne ou ligne de données. 

Dans notre exemple (image d'échantillon), 

* les colonnes sont *Série 1, Série 2,* et *Série 3*;
* les lignes sont *Catégorie 1, Catégorie 2, Catégorie 3,* et *Catégorie 4.* 

Aspose.Slides pour PHP via Java vous permet de mettre à jour ou de changer le nom d'une série dans ses données de graphique et sa légende.

Ce code PHP vous montre comment changer le nom d'une série dans ses données de graphique `ChartDataWorkbook` :

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("Nouveau nom");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ce code PHP vous montre comment changer le nom d'une série dans sa légende via `Series` :

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("Nouveau nom");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir la Couleur de Remplissage de la Série de Graphiques**

Aspose.Slides pour PHP via Java vous permet de définir la couleur de remplissage automatique pour les séries de graphiques à l'intérieur d'une zone de tracé de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un graphique avec des données par défaut basé sur votre type préféré (dans l'exemple ci-dessous, nous avons utilisé `ChartType::ClusteredColumn`).
1. Accédez aux séries de graphiques et définissez la couleur de remplissage sur Automatique.
1. Enregistrez la présentation dans un fichier PPTX.

Ce code PHP vous montre comment définir la couleur de remplissage automatique pour une série de graphiques :

```php
  $pres = new Presentation();
  try {
    # Crée un graphique à colonnes groupées
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # Définit le format de remplissage des séries sur automatique
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # Écrit le fichier de présentation sur le disque
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir les Couleurs de Remplissage Inversées pour les Séries de Graphiques**
Aspose.Slides vous permet de définir la couleur de remplissage inversée pour les séries de graphiques à l'intérieur d'une zone de tracé de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un graphique avec des données par défaut basé sur votre type préféré (dans l'exemple ci-dessous, nous avons utilisé `ChartType::ClusteredColumn`).
1. Accédez aux séries de graphiques et définissez la couleur de remplissage sur inversée.
1. Enregistrez la présentation dans un fichier PPTX.

Ce code PHP démontre l'opération :

```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Ajoute de nouvelles séries et catégories
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Série 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Catégorie 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Catégorie 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Catégorie 3"));
    # Prend la première série de graphiques et peuple ses données de série.
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 1, 1, -20));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 3, 1, -30));
    $seriesColor = $series->getAutomaticSeriesColor();
    $series->setInvertIfNegative(true);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColor);
    $series->getInvertedSolidFillColor()->setColor($inverColor);
    $pres->save("SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir les Séries pour Inverser Lorsqu'une Valeur est Négative**
Aspose.Slides vous permet de définir des inversions via les propriétés `IChartDataPoint.InvertIfNegative` et `ChartDataPoint.InvertIfNegative`. Lorsqu'une inversion est définie à l'aide des propriétés, le point de données inverse ses couleurs lorsqu'il reçoit une valeur négative. 

Ce code PHP démontre l'opération :

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $chart->getChartData()->getSeries()->clear();
    $chartSeries = $series->add($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1"), $chart->getType());
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B2", -5));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B3", 3));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B4", -2));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B5", 1));
    $chartSeries->setInvertIfNegative(false);
    $chartSeries->getDataPoints()->get_Item(2)->setInvertIfNegative(true);
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Effacer les Données de Points de Données Spécifiques**
Aspose.Slides pour PHP via Java vous permet d'effacer les données `DataPoints` pour une série de graphiques spécifique de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive par son index.
3. Obtenez la référence d'un graphique par son index.
4. Itérez à travers tous les `DataPoints` du graphique et définissez `XValue` et `YValue` sur null.
5. Effacez tous les `DataPoints` pour la série de graphiques spécifique.
6. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code PHP démontre l'opération :

```php
  $pres = new Presentation("TestChart.pptx");
  try {
    $sl = $pres->getSlides()->get_Item(0);
    $chart = $sl->getShapes()->get_Item(0);
    foreach($chart->getChartData()->getSeries()->get_Item(0)->getDataPoints() as $dataPoint) {
      $dataPoint->getXValue()->getAsCell()->setValue(null);
      $dataPoint->getYValue()->getAsCell()->setValue(null);
    }
    $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->clear();
    $pres->save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir la Largeur d'Espace entre Séries**
Aspose.Slides pour PHP via Java vous permet de définir la largeur d'espace d'une série à l'aide de la propriété **`GapWidth`** de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Accédez à n'importe quelle série de graphiques.
1. Définissez la propriété `GapWidth`.
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code montre comment définir la largeur d'espace d'une série :

```php
  # Crée une présentation vide
  $pres = new Presentation();
  try {
    # Accède à la première diapositive de la présentation
    $slide = $pres->getSlides()->get_Item(0);
    # Ajoute un graphique avec des données par défaut
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # Définit l'index de la feuille de données du graphique
    $defaultWorksheetIndex = 0;
    # Obtient la feuille de calcul des données du graphique
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Ajoute des séries
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Série 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Série 2"), $chart->getType());
    # Ajoute des Catégories
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Catégorie 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Catégorie 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Catégorie 3"));
    # Prend la deuxième série du graphique
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Peuple les données de la série
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Définit la valeur de GapWidth
    $series->getParentSeriesGroup()->setGapWidth(50);
    # Enregistre la présentation sur le disque
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```