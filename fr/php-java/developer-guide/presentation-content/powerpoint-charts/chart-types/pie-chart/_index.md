---
title: Graphique en Secteurs
type: docs
url: /fr/php-java/pie-chart/
---

## **Options de Second Plot pour Graphique en Secteurs**
Aspose.Slides pour PHP via Java prend désormais en charge les options de second plot pour les graphiques en secteurs. Dans ce sujet, nous allons vous montrer comment spécifier ces options en utilisant Aspose.Slides. Pour spécifier les propriétés, faites ceci :

1. Instancier un objet de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Ajouter un graphique sur la diapositive.
1. Spécifier les options de second plot du graphique.
1. Écrire la présentation sur le disque.

Dans l'exemple donné ci-dessous, nous avons défini différentes propriétés du graphique en secteurs.

```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Ajouter un graphique sur la diapositive
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # Définir différentes propriétés
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # Écrire la présentation sur le disque
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir les Couleurs des Tranches de Graphique en Secteurs Automatiques**
Aspose.Slides pour PHP via Java fournit une API simple pour définir les couleurs des tranches de graphique en secteurs automatiques. Le code exemple applique les paramètres des propriétés mentionnées ci-dessus.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Accéder à la première diapositive.
1. Ajouter un graphique avec des données par défaut.
1. Définir le titre du graphique.
1. Définir la première série pour afficher les valeurs.
1. Définir l'index de la feuille de données du graphique.
1. Obtenir la feuille de données du graphique.
1. Supprimer les séries et catégories générées par défaut.
1. Ajouter de nouvelles catégories.
1. Ajouter de nouvelles séries.

Écrire la présentation modifiée dans un fichier PPTX.

```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Ajouter un graphique avec des données par défaut
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Définir le titre du graphique
    $chart->getChartTitle()->addTextFrameForOverriding("Titre d'Échantillon");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Définir la première série pour afficher les valeurs
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Définir l'index de la feuille de données du graphique
    $defaultWorksheetIndex = 0;
    # Obtenir la feuille de données du graphique
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Supprimer les séries et catégories générées par défaut
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Ajouter de nouvelles catégories
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "1er Trimestre"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2ème Trimestre"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3ème Trimestre"));
    # Ajouter de nouvelles séries
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Série 1"), $chart->getType());
    # Maintenant, peupler les données de la série
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getParentSeriesGroup()->setColorVaried(true);
    $pres->save("Pie.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```