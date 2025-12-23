---
title: Administrar llamados en gráficos de presentación usando PHP
linktitle: Llamado
type: docs
url: /es/php-java/callout/
keywords:
- llamado de gráfico
- usar llamado
- etiqueta de datos
- formato de etiqueta
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Crear y dar estilo a los llamados en Aspose.Slides para PHP a través de Java con ejemplos de código concisos, compatibles con PPT y PPTX para automatizar flujos de trabajo de presentaciones."
---

## **Uso de llamados**
Se han añadido nuevos métodos [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/php-java/aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) y [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/php-java/aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) a la clase [DataLabelFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat) y a la interfaz [IDataLabelFormat](https://reference.aspose.com/slides/php-java/aspose.slides/idatalabelformat). Estos métodos determinan si la etiqueta de datos del gráfico especificado se mostrará como llamado de datos o como etiqueta de datos.
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


## **Establecer una llamada para un gráfico de rosquilla**
Aspose.Slides para PHP a través de Java brinda soporte para establecer la forma de llamado de la etiqueta de datos de la serie en un gráfico de rosquilla. A continuación se muestra un ejemplo de código.
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


## **Preguntas frecuentes**

**¿Se conservan los llamados al convertir una presentación a PDF, HTML5, SVG o imágenes?**

Sí. Los llamados forman parte del renderizado del gráfico, por lo que al exportar a [PDF](/slides/es/php-java/convert-powerpoint-to-pdf/), [HTML5](/slides/es/php-java/export-to-html5/), [SVG](/slides/es/php-java/render-a-slide-as-an-svg-image/), o [imágenes rasterizadas](/slides/es/php-java/convert-powerpoint-to-png/), se conservan junto con el formato de la diapositiva.

**¿Funciona las fuentes personalizadas en los llamados y se puede conservar su apariencia al exportar?**

Sí. Aspose.Slides admite [incorporar fuentes](/slides/es/php-java/embedded-font/) en la presentación y controla la incorporación de fuentes durante exportaciones como [PDF](/slides/es/php-java/convert-powerpoint-to-pdf/), garantizando que los llamados se vean igual en diferentes sistemas.