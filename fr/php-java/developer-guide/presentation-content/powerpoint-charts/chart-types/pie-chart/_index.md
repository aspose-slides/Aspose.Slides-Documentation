---
title: Personnaliser les graphiques en secteurs dans les présentations avec PHP
linktitle: Graphique en secteur
type: docs
url: /fr/php-java/pie-chart/
keywords:
- graphique en secteur
- gérer le graphique
- personnaliser le graphique
- options du graphique
- paramètres du graphique
- options de tracé
- couleur de la part
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à créer et personnaliser des graphiques en secteurs avec Aspose.Slides pour PHP via Java, exportables vers PowerPoint, pour renforcer votre narration de données en quelques secondes."
---

## **Options du deuxième tracé pour les graphiques Pie of Pie et Bar of Pie**
Aspose.Slides for PHP via Java prend désormais en charge les options du deuxième tracé pour les graphiques Pie of Pie ou Bar of Pie. Dans ce sujet, nous vous montrerons comment spécifier ces options à l'aide d'Aspose.Slides. Pour spécifier les propriétés, procédez ainsi :

1. Instanciez l'objet de classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Ajoutez un graphique sur la diapositive.
3. Spécifiez les options du deuxième tracé du graphique.
4. Enregistrez la présentation sur le disque.

Dans l'exemple ci-dessous, nous avons défini différentes propriétés du graphique Pie of Pie.
```php
  # Créez une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Ajoutez un graphique sur la diapositive
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # Définissez différentes propriétés
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # Enregistrez la présentation sur le disque
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Définir les couleurs automatiques des parts de graphique secteur**
Aspose.Slides for PHP via Java fournit une API simple pour définir les couleurs automatiques des parts de graphique secteur. Le code d'exemple applique la configuration des propriétés susmentionnées.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Accédez à la première diapositive.
3. Ajoutez un graphique avec les données par défaut.
4. Définissez le titre du graphique.
5. Configurez la première série pour afficher les valeurs.
6. Définissez l'index de la feuille de données du graphique.
7. Récupérez la feuille de calcul des données du graphique.
8. Supprimez les séries et catégories générées par défaut.
9. Ajoutez de nouvelles catégories.
10. Ajoutez une nouvelle série.

Enregistrez la présentation modifiée dans un fichier PPTX.
```php
  # Créez une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Ajouter un graphique avec les données par défaut
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Définir le titre du graphique
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Définir la première série pour afficher les valeurs
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Définir l'index de la feuille de données du graphique
    $defaultWorksheetIndex = 0;
    # Récupérer la feuille de calcul des données du graphique
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Supprimer les séries et catégories générées par défaut
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Ajouter de nouvelles catégories
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Ajouter une nouvelle série
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Remplir maintenant les données de la série
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


## **FAQ**

**Les variantes 'Pie of Pie' et 'Bar of Pie' sont-elles prises en charge ?**

Oui, la bibliothèque [prend en charge](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) un tracé secondaire pour les graphiques secteur, y compris les types 'Pie of Pie' et 'Bar of Pie'.

**Puis-je exporter uniquement le graphique en tant qu'image (par exemple, PNG) ?**

Oui, vous pouvez [exporter le graphique lui‑même en tant qu'image](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) (comme PNG) sans toute la présentation.