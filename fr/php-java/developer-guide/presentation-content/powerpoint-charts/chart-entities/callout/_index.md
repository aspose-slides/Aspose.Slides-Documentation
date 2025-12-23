---
title: Gestion des repères dans les graphiques de présentation avec PHP
linktitle: Repère
type: docs
url: /fr/php-java/callout/
keywords:
- repère de graphique
- utilisation du repère
- étiquette de données
- format d'étiquette
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Créez et stylisez des repères dans Aspose.Slides pour PHP via Java avec des exemples de code concis, compatibles avec PPT et PPTX, afin d'automatiser les flux de travail de présentation."
---

## **Utilisation des repères**
De nouvelles méthodes [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/php-java/aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) et [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/php-java/aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) ont été ajoutées à la classe [DataLabelFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat) et à l'interface [IDataLabelFormat](https://reference.aspose.com/slides/php-java/aspose.slides/idatalabelformat). Ces méthodes déterminent si l’étiquette de données du graphique spécifié sera affichée comme repère de données ou comme étiquette de données.
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 500, 400);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowLabelAsDataCallout(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->get_Item(2)->getDataLabelFormat()->setShowLabelAsDataCallout(false);
    $pres->save("DisplayCharts.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Définir un repère pour un diagramme en anneau**
Aspose.Slides pour PHP via Java prend en charge la définition de la forme du repère d’étiquette de données de série pour un diagramme en anneau. L’exemple ci‑dessous est fourni. 
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Doughnut, 10, 10, 500, 500, false);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(false);
    $seriesIndex = 0;
    while ($seriesIndex < 15) {
      $series = $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, $seriesIndex + 1, "SERIES " . $seriesIndex), $chart->getType());
      $series->setExplosion(0);
      $series->getParentSeriesGroup()->setDoughnutHoleSize(20);
      $series->getParentSeriesGroup()->setFirstSliceAngle(351);
      $seriesIndex++;
    } 
    $categoryIndex = 0;
    while ($categoryIndex < 15) {
      $chart->getChartData()->getCategories()->add($workBook->getCell(0, $categoryIndex + 1, 0, "CATEGORY " . $categoryIndex));
      $i = 0;
      while ($i < java_values($chart->getChartData()->getSeries()->size())) {
        $iCS = $chart->getChartData()->getSeries()->get_Item($i);
        $dataPoint = $iCS->getDataPoints()->addDataPointForDoughnutSeries($workBook->getCell(0, $categoryIndex + 1, $i + 1, 1));
        $dataPoint->getFormat()->getFill()->setFillType(FillType::Solid);
        $dataPoint->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
        $dataPoint->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
        $dataPoint->getFormat()->getLine()->setWidth(1);
        $dataPoint->getFormat()->getLine()->setStyle(LineStyle->Single);
        $dataPoint->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
        if ($i == java_values($chart->getChartData()->getSeries()->size()) - 1) {
          $lbl = $dataPoint->getLabel();
          $lbl->getTextFormat()->getTextBlockFormat()->setAutofitType(TextAutofitType::Shape);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setLatinFont(new FontData("DINPro-Bold"));
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(12);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
          $lbl->getDataLabelFormat()->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
          $lbl->getDataLabelFormat()->setShowValue(false);
          $lbl->getDataLabelFormat()->setShowCategoryName(true);
          $lbl->getDataLabelFormat()->setShowSeriesName(false);
          $lbl->getDataLabelFormat()->setShowLeaderLines(true);
          $lbl->getDataLabelFormat()->setShowLabelAsDataCallout(false);
          $chart->validateChartLayout();
          $lbl->setX($lbl->getX() + 0.5);
          $lbl->setY($lbl->getY() + 0.5);
        }
        $i++;
      } 
      $categoryIndex++;
    } 
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Les repères sont-ils conservés lors de la conversion d’une présentation en PDF, HTML5, SVG ou images ?**

Oui. Les repères font partie du rendu du graphique, de sorte que lorsque vous exportez vers [PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/), [HTML5](/slides/fr/php-java/export-to-html5/), [SVG](/slides/fr/php-java/render-a-slide-as-an-svg-image/), ou [raster images](/slides/fr/php-java/convert-powerpoint-to-png/), ils sont conservés avec le formatage de la diapositive.

**Les polices personnalisées fonctionnent-elles dans les repères, et leur apparence peut-elle être conservée lors de l’exportation ?**

Oui. Aspose.Slides prend en charge l'[incorporation de polices](/slides/fr/php-java/embedded-font/) dans la présentation et contrôle l’incorporation des polices lors des exportations comme le [PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/), garantissant que les repères conservent le même aspect sur différents systèmes.