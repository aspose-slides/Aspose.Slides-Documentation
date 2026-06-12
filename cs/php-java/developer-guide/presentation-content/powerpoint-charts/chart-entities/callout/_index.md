---
title: Správa popisků v grafech prezentací pomocí PHP
linktitle: Popisek
type: docs
url: /cs/php-java/callout/
keywords:
- popisek grafu
- použít popisek
- datový štítek
- formát štítku
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Vytvářejte a stylizujte popisky v Aspose.Slides pro PHP via Java pomocí stručných ukázek kódu, kompatibilních s formáty PPT a PPTX, a automatizujte pracovní postupy prezentací."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s popisky pro datové štítky v grafech v Aspose.Slides. Ukazuje, jak použít metodu `setShowLabelAsDataCallout` k zobrazení štítků jako popisků, jak nakonfigurovat nastavení štítků související s popisky pro prstencový graf a uvádí, že popisky a jejich vzhled jsou zachovány při exportu prezentací do formátů PDF, HTML5, SVG a rastrových obrázků.

## **Používání popisků**
Do třídy [DataLabelFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/datalabelformat) byly přidány nové metody [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/datalabelformat/getshowlabelasdatacallout/) a [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/datalabelformat/setshowlabelasdatacallout/). Tyto metody určují, zda bude datový štítek specifikovaného grafu zobrazen jako popisek nebo jako běžný štítek.

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

## **Nastavení popisku pro prstencový graf**
Aspose.Slides pro PHP via Java poskytuje podporu pro nastavení tvaru popisku datových štítků řady pro prstencový graf. Níže je uveden ukázkový příklad.

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

## **Často kladené otázky**

**Zůstávají popisky zachovány při převodu prezentace do PDF, HTML5, SVG nebo obrázků?**

Ano. Popisky jsou součástí vykreslování grafu, takže při exportu do [PDF](/slides/cs/php-java/convert-powerpoint-to-pdf/), [HTML5](/slides/cs/php-java/export-to-html5/), [SVG](/slides/cs/php-java/render-a-slide-as-an-svg-image/) nebo [rastrových obrázků](/slides/cs/php-java/convert-powerpoint-to-png/) jsou zachovány spolu s formátováním snímku.

**Fungují vlastní fonty v popiscích a lze jejich vzhled zachovat při exportu?**

Ano. Aspose.Slides podporuje [vkládání fontů](/slides/cs/php-java/embedded-font/) do prezentace a řídí vkládání fontů během exportů, jako je [PDF](/slides/cs/php-java/convert-powerpoint-to-pdf/), což zajišťuje, že popisky vypadají stejně napříč různými systémy.