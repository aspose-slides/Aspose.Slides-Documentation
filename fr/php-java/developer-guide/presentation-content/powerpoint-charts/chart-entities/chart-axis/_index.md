---
title: Personnaliser les axes de graphique dans les présentations avec PHP
linktitle: Axe du graphique
type: docs
url: /fr/php-java/chart-axis/
keywords:
- axe du graphique
- axe vertical
- axe horizontal
- personnaliser l'axe
- manipuler l'axe
- gérer l'axe
- propriétés de l'axe
- valeur maximale
- valeur minimale
- ligne d'axe
- format de date
- titre de l'axe
- position de l'axe
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Découvrez comment utiliser Aspose.Slides pour PHP via Java pour personnaliser les axes de graphique dans les présentations PowerPoint destinées aux rapports et aux visualisations."
---

## **Obtenir les valeurs maximales sur l'axe vertical des graphiques**
Aspose.Slides for PHP via Java vous permet d'obtenir les valeurs minimale et maximale sur un axe vertical. Suivez les étapes suivantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Obtenez la valeur maximale réelle sur l'axe.
1. Obtenez la valeur minimale réelle sur l'axe.
1. Obtenez l'unité majeure réelle de l'axe.
1. Obtenez l'unité mineure réelle de l'axe.
1. Obtenez l'échelle de l'unité majeure réelle de l'axe.
1. Obtenez l'échelle de l'unité mineure réelle de l'axe.

Ce code d'exemple — une implémentation des étapes ci‑dessus — montre comment obtenir les valeurs requises :
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
    # Enregistre la présentation
    $pres->save("MaxValuesVerticalAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Échanger les données entre les axes**
Aspose.Slides vous permet d'échanger rapidement les données entre les axes — les données représentées sur l'axe vertical (axe y) sont déplacées vers l'axe horizontal (axe x) et inversement.

Ce code PHP montre comment effectuer l'échange de données entre les axes d'un graphique :
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # Échange les lignes et les colonnes
    $chart->getChartData()->switchRowColumn();
    # Enregistre la présentation
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Désactiver l'axe vertical pour les graphiques en courbes**

Ce code PHP montre comment masquer l'axe vertical d'un graphique en courbes :
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Désactiver l'axe horizontal pour les graphiques en courbes**

Ce code montre comment masquer l'axe horizontal d'un graphique en courbes :
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Modifier l'axe des catégories**

À l'aide de la propriété **CategoryAxisType**, vous pouvez spécifier le type d'axe des catégories souhaité (**date** ou **text**). Ce code démontre l'opération :
```php
  $presentation = new Presentation("ExistingChart.pptx");
  try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);
    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Définir le format de date pour les valeurs de l'axe des catégories**
Aspose.Slides for PHP via Java vous permet de définir le format de date pour une valeur de l'axe des catégories. L'opération est illustrée dans ce code PHP :
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 50, 50, 450, 300);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B2", 1));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B3", 2));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B4", 3));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B5", 4));
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```


## **Définir l'angle de rotation pour le titre d'un axe de graphique**
Aspose.Slides for PHP via Java vous permet de définir l'angle de rotation pour le titre d'un axe de graphique. Ce code PHP démontre l'opération :
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Définir la position de l'axe sur un axe de catégorie ou de valeur**
Aspose.Slides for PHP via Java vous permet de définir la position de l'axe dans un axe de catégorie ou de valeur. Ce code PHP montre comment réaliser la tâche :
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Activer l'étiquette d'unité d'affichage sur l'axe de valeur du graphique**
Aspose.Slides for PHP via Java vous permet de configurer un graphique afin d'afficher une étiquette d'unité sur son axe de valeur. Ce code PHP démontre l'opération :
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Comment définir la valeur à laquelle un axe croise l'autre (croisement d'axes) ?**

Les axes offrent un [paramètre de croisement](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) : vous pouvez choisir de croiser à zéro, au maximum de la catégorie/valeur, ou à une valeur numérique spécifique. Cela est utile pour déplacer l'axe X vers le haut ou le bas ou pour mettre en évidence une ligne de base.

**Comment positionner les étiquettes des graduations par rapport à l'axe (à côté, à l'extérieur, à l'intérieur) ?**

Définissez la [position de l'étiquette](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) sur « cross », « outside » ou « inside ». Cela influence la lisibilité et permet d'économiser de l'espace, notamment sur les petits graphiques.