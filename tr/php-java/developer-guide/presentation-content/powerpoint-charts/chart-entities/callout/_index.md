---
title: PHP Kullanarak Sunum Grafiklerinde Açıklama Balonlarını Yönetme
linktitle: Açıklama Balonu
type: docs
url: /tr/php-java/callout/
keywords:
- grafik açıklama balonu
- açıklama balonu kullanımı
- veri etiketi
- etiket biçimi
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java içinde açıklama balonlarını oluşturun ve biçimlendirin, kısa kod örnekleriyle, PPT ve PPTX ile uyumlu olarak sunum iş akışlarını otomatikleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'de grafik veri etiketleri için açıklama balonlarıyla nasıl çalışılacağını açıklar. `setShowLabelAsDataCallout` yöntemini etiketleri açıklama balonları olarak görüntülemek için nasıl kullanılacağını, bir halka grafik için açıklama balonuna ilişkin etiket ayarlarını nasıl yapılandırılacağını ve açıklama balonları ile görünümünün sunumlar PDF, HTML5, SVG ve raster görüntü formatlarına dışa aktarılırken korunduğunu gösterir.

## **Açıklama Balonlarını Kullanma**
Yeni yöntemler [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/datalabelformat/getshowlabelasdatacallout/) ve [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/datalabelformat/setshowlabelasdatacallout/) [DataLabelFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/datalabelformat) sınıfına eklenmiştir. Bu yöntemler, belirtilen grafiğin veri etiketinin veri açıklama balonu olarak mı yoksa veri etiketi olarak mı gösterileceğini belirler.

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

## **Halka Grafik İçin Açıklama Balonu Ayarlama**
Aspose.Slides for PHP via Java, bir Doughnut grafik için seri veri etiketi açıklama balonu şekli ayarlamayı destekler. Aşağıda örnek bir kod verilmiştir.

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

## **SSS**

**Sunum PDF, HTML5, SVG veya görüntülere dönüştürülürken açıklama balonları korunur mu?**

Evet. Açıklama balonları grafik oluşturmanın bir parçasıdır, bu nedenle [PDF](/slides/tr/php-java/convert-powerpoint-to-pdf/), [HTML5](/slides/tr/php-java/export-to-html5/), [SVG](/slides/tr/php-java/render-a-slide-as-an-svg-image/) veya [raster images](&#x2F;slides/php-java/convert-powerpoint-to-png/) gibi formatlara dışa aktardığınızda slaytın biçimlendirmesiyle birlikte korunur.

**Özel yazı tipleri açıklama balonlarında çalışır mı ve dışa aktarımda görünümleri korunabilir mi?**

Evet. Aspose.Slides, sunuma [embedding fonts](/slides/tr/php-java/embedded-font/) eklemeyi destekler ve PDF gibi dışa aktarımlarda yazı tipi gömme kontrolünü sağlar, böylece açıklama balonları farklı sistemlerde aynı şekilde görünür.