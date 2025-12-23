---
title: Optimiser les calculs de graphiques pour les présentations en PHP
linktitle: Calculs de graphiques
type: docs
weight: 50
url: /fr/php-java/chart-calculations/
keywords:
- calculs de graphiques
- éléments de graphique
- position de l'élément
- position réelle
- élément enfant
- élément parent
- valeurs de graphique
- valeur réelle
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Comprenez les calculs de graphiques, les mises à jour de données et le contrôle de la précision dans Aspose.Slides pour PHP via Java pour PPT et PPTX, avec des exemples de code pratiques."
---

## **Calculer les valeurs réelles des éléments du graphique**
Aspose.Slides for PHP via Java fournit une API simple pour obtenir ces propriétés. Les propriétés de l’interface [IAxis](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis) fournissent des informations sur la position réelle de l’élément d’axe du graphique ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinorUnitScale--)). Il est nécessaire d’appeler la méthode [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) au préalable pour remplir les propriétés avec les valeurs réelles.
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Calculer la position réelle des éléments parent du graphique**
Aspose.Slides for PHP via Java fournit une API simple pour obtenir ces propriétés. Les propriétés de l’interface [IActualLayout](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout) fournissent des informations sur la position réelle de l’élément parent du graphique ([IActualLayout.getActualX](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualHeight--)). Il est nécessaire d’appeler la méthode [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) au préalable pour remplir les propriétés avec les valeurs réelles.
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Masquer les éléments du graphique**
Ce sujet vous aide à comprendre comment masquer des informations du graphique. Avec Aspose.Slides for PHP via Java, vous pouvez masquer **Titre, Axe vertical, Axe horizontal** et **Lignes de la grille** du graphique. L’exemple de code ci‑dessous montre comment utiliser ces propriétés.
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # Masquage du titre du graphique
    $chart->setTitle(false);
    # /Masquage de l'axe des valeurs
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # Visibilité de l'axe des catégories
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # Masquage de la légende
    $chart->setLegend(false);
    # Masquage des lignes de grille majeures
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # Définition de la couleur de ligne de la série
    $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $series->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
    $pres->save("HideInformationFromChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Les classeurs Excel externes fonctionnent-ils comme source de données, et comment cela affecte-t-il le recalcul ?**

Oui. Un graphique peut référencer un classeur externe : lorsque vous vous connectez ou actualisez la source externe, les formules et les valeurs sont prises depuis ce classeur, et le graphique reflète les mises à jour lors des opérations d’ouverture/édition. L’API vous permet de [spécifier le classeur externe](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) ainsi que de gérer les données liées.

**Puis-je calculer et afficher des lignes de tendance sans implémenter moi‑même la régression ?**

Oui. Les [Lignes de tendance](/slides/fr/php-java/trend-line/) (linéaires, exponentielles et autres) sont ajoutées et mises à jour par Aspose.Slides ; leurs paramètres sont recalculés automatiquement à partir des données de la série, vous n’avez donc pas besoin d’implémenter vos propres calculs.

**Si une présentation contient plusieurs graphiques avec des liens externes, puis‑je contrôler quel classeur chaque graphique utilise pour les valeurs calculées ?**

Oui. Chaque graphique peut pointer vers son propre [classeur externe](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/), ou vous pouvez créer/remplacer un classeur externe par graphique de façon indépendante des autres.