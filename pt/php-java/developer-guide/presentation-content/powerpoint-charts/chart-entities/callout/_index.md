---
title: Gerenciar balões de chamada em gráficos de apresentação usando PHP
linktitle: Balão de chamada
type: docs
url: /pt/php-java/callout/
keywords:
- balão de chamada de gráfico
- usar balão de chamada
- rótulo de dados
- formato de rótulo
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Crie e estilize balões de chamada no Aspose.Slides para PHP via Java com exemplos de código concisos, compatíveis com PPT e PPTX para automatizar fluxos de trabalho de apresentações."
---
## **Visão geral**

Este artigo explica como trabalhar com balões de chamada para rótulos de dados de gráficos no Aspose.Slides. Ele mostra como usar o método `setShowLabelAsDataCallout` para exibir rótulos como balões de chamada, como configurar as configurações de rótulo relacionadas a balões de chamada para um gráfico de rosca e observa que os balões de chamada e sua aparência são preservados quando as apresentações são exportadas para PDF, HTML5, SVG e formatos de imagens raster.

## **Usando balões de chamada**
Novos métodos [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/datalabelformat/getshowlabelasdatacallout/) e [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/datalabelformat/setshowlabelasdatacallout/) foram adicionados à classe [DataLabelFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/datalabelformat). Esses métodos determinam se o rótulo de dados do gráfico especificado será exibido como balão de chamada ou como rótulo de dados.

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

## **Definir um balão de chamada para um gráfico de rosca**
O Aspose.Slides for PHP via Java oferece suporte para definir a forma do balão de chamada do rótulo de dados da série para um gráfico de rosca. A seguir, um exemplo de código.

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

## **Perguntas frequentes**

**Os balões de chamada são preservados ao converter uma apresentação para PDF, HTML5, SVG ou imagens?**

Sim. Os balões de chamada fazem parte da renderização do gráfico, portanto, ao exportar para [PDF](/slides/pt/php-java/convert-powerpoint-to-pdf/), [HTML5](/slides/pt/php-java/export-to-html5/), [SVG](/slides/pt/php-java/render-a-slide-as-an-svg-image/) ou [imagens raster](/slides/pt/php-java/convert-powerpoint-to-png/), eles são preservados juntamente com a formatação do slide.

**As fontes personalizadas funcionam nos balões de chamada e sua aparência pode ser preservada na exportação?**

Sim. O Aspose.Slides suporta [incorporação de fontes](/slides/pt/php-java/embedded-font/) na apresentação e controla a incorporação de fontes durante exportações como [PDF](/slides/pt/php-java/convert-powerpoint-to-pdf/), garantindo que os balões de chamada mantenham a mesma aparência em diferentes sistemas.