---
title: Gérer les étiquettes de données du graphique dans les présentations avec PHP
linktitle: Étiquette de données
type: docs
url: /fr/php-java/chart-data-label/
keywords:
- graphique
- étiquette de données
- précision des données
- pourcentage
- distance de l'étiquette
- emplacement de l'étiquette
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à ajouter et à formater les étiquettes de données du graphique dans les présentations PowerPoint en utilisant Aspose.Slides pour PHP via Java pour des diapositives plus attrayantes."
---

Les étiquettes de données sur un graphique affichent des détails sur les séries de données du graphique ou sur des points de données individuels. Elles permettent aux lecteurs d’identifier rapidement les séries de données et facilitent également la compréhension des graphiques.

## **Définir la précision des données dans les étiquettes de données du graphique**

Ce code PHP vous montre comment définir la précision des données dans une étiquette de données de graphique :
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);
    $chart->setDataTable(true);
    $chart->getChartData()->getSeries()->get_Item(0)->setNumberFormatOfValues("#,##0.00");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Afficher le pourcentage sous forme d’étiquettes**

Aspose.Slides for PHP via Java vous permet de définir des étiquettes de pourcentage sur les graphiques affichés. Ce code PHP montre le fonctionnement :
```php
  # Crée une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Obtient la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 400, 400);
    $series;
    $total_for_Cat = new double[$chart->getChartData()->getCategories()->size()];
    for($k = 0; $k < java_values($chart->getChartData()->getCategories()->size()) ; $k++) {
      $cat = $chart->getChartData()->getCategories()->get_Item($k);
      for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
        $total_for_Cat[$k] = $total_for_Cat[$k] + $chart->getChartData()->getSeries()->get_Item($i)->getDataPoints()->get_Item($k)->getValue()->getData();
      }
    }
    $dataPontPercent = 0.0;
    for($x = 0; $x < java_values($chart->getChartData()->getSeries()->size()) ; $x++) {
      $series = $chart->getChartData()->getSeries()->get_Item($x);
      $series->getLabels()->getDefaultDataLabelFormat()->setShowLegendKey(false);
      for($j = 0; $j < java_values($series->getDataPoints()->size()) ; $j++) {
        $lbl = $series->getDataPoints()->get_Item($j)->getLabel();
        $dataPontPercent = $series->getDataPoints()->get_Item($j)->getValue()->getData() / $total_for_Cat[$j] * 100;
        $port = new Portion();
        $port->setText(sprintf("{0:F2} %.2f", $dataPontPercent));
        $port->getPortionFormat()->setFontHeight(8.0);
        $lbl->getTextFrameForOverriding()->setText("");
        $para = $lbl->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
        $para->getPortions()->add($port);
        $lbl->getDataLabelFormat()->setShowSeriesName(false);
        $lbl->getDataLabelFormat()->setShowPercentage(false);
        $lbl->getDataLabelFormat()->setShowLegendKey(false);
        $lbl->getDataLabelFormat()->setShowCategoryName(false);
        $lbl->getDataLabelFormat()->setShowBubbleSize(false);
      }
    }
    # Enregistre la présentation contenant le graphique
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Définir le symbole de pourcentage avec les étiquettes de données du graphique**

Ce code PHP vous montre comment définir le symbole de pourcentage pour une étiquette de données de graphique :
```php
  # Crée une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Obtient la référence d'une diapositive via son index
    $slide = $pres->getSlides()->get_Item(0);
    # Crée le graphique PercentsStackedColumn sur une diapositive
    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);
    # Définit NumberFormatLinkedToSource à false
    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");
    $chart->getChartData()->getSeries()->clear();
    $defaultWorksheetIndex = 0;
    # Obtient la feuille de calcul des données du graphique
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # Ajoute une nouvelle série
    $series = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 1, "Reds"), $chart->getType());
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 1, 0.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 1, 0.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 1, 0.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 1, 0.65));
    # Définit la couleur de remplissage de la série
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Définit les propriétés du LabelFormat
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Ajoute une nouvelle série
    $series2 = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 2, "Blues"), $chart->getType());
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 2, 0.7));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 2, 0.5));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 2, 0.2));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 2, 0.35));
    # Définit le type de remplissage et la couleur
    $series2->getFormat()->getFill()->setFillType(FillType::Solid);
    $series2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $series2->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    # Enregistre la présentation sur le disque
    $pres->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Définir la distance de l’étiquette par rapport à un axe**

Ce code PHP vous montre comment définir la distance de l’étiquette par rapport à un axe de catégorie lorsque vous travaillez avec un graphique tracé à partir d’axes :
```php
  # Crée une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Obtient la référence d'une diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Crée un graphique sur la diapositive
    $ch = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    # Définit la distance de l'étiquette par rapport à un axe
    $ch->getAxes()->getHorizontalAxis()->setLabelOffset(500);
    # Enregistre la présentation sur le disque
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Ajuster l’emplacement de l’étiquette**

Lorsque vous créez un graphique qui ne dépend d’aucun axe, comme un diagramme circulaire, les étiquettes de données du graphique peuvent se retrouver trop proches du bord. Dans ce cas, vous devez ajuster l’emplacement de l’étiquette de données afin que les lignes de liaison soient clairement visibles.

Ce code PHP vous montre comment ajuster l’emplacement de l’étiquette sur un diagramme circulaire :
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 200, 200);
    $series = $chart->getChartData()->getSeries();
    $label = $series->get_Item(0)->getLabels()->get_Item(0);
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setPosition(LegendDataLabelPosition->OutsideEnd);
    $label->setX(0.71);
    $label->setY(0.04);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **FAQ**

**Comment éviter que les étiquettes de données ne se chevauchent sur des graphiques denses ?**

Combinez le placement automatique des étiquettes, les lignes de liaison et une taille de police réduite ; si nécessaire, masquez certains champs (par exemple la catégorie) ou affichez les étiquettes uniquement pour les points extrêmes/clés.

**Comment désactiver les étiquettes uniquement pour les valeurs zéro, négatives ou vides ?**

Filtrez les points de données avant d’activer les étiquettes et désactivez l’affichage pour les valeurs égales à 0, les valeurs négatives ou les valeurs manquantes selon une règle définie.

**Comment garantir un style d’étiquette cohérent lors de l’exportation vers PDF/images ?**

Définissez explicitement les polices (famille, taille) et vérifiez que la police est disponible du côté du rendu afin d’éviter le recours à une police de remplacement.