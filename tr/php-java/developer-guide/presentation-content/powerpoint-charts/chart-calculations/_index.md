---
title: Sunumlarda PHP için Grafik Hesaplamalarını Optimize Et
linktitle: Grafik Hesaplamaları
type: docs
weight: 50
url: /tr/php-java/chart-calculations/
keywords:
- grafik hesaplamaları
- grafik öğeleri
- öğe konumu
- gerçek konum
- alt öğe
- üst öğe
- grafik değerleri
- gerçek değer
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'da PPT ve PPTX için grafik hesaplamalarını, veri güncellemelerini ve hassasiyet kontrolünü, pratik kod örnekleriyle anlayın."
---
## **Genel Bakış**

Aspose.Slides, sunumlarda grafik hesaplamaları ve yerleşim verileriyle çalışmak için API'ler sağlar. Bu makale, grafik öğelerinin gerçek konum ve boyutları ile grafik eksenlerinin gerçek değerleri dahil olmak üzere gerçek değerlerini nasıl alacağınızı gösterir. Ayrıca bu değerlerin grafik yerleşimi doğrulamasından sonra doldurulduğunu açıklar.

Ayrıca, makale ebeveyn grafik öğelerinin gerçek konumunu nasıl alacağınızı ve başlık, eksenler, lejand ve ızgara çizgileri gibi grafik bileşenlerini nasıl gizleyeceğinizi gösterir. Bu örnekler, grafik yerleşim bilgilerini incelemenize ve PowerPoint sunumlarında grafik öğelerinin görünürlüğünü programlı olarak kontrol etmenize yardımcı olur.

## **Grafik Öğelerinin Gerçek Değerlerini Hesapla**
Aspose.Slides for PHP via Java, bu özellikleri almak için basit bir API sağlar. [Axis] sınıfının metodları, eksen grafik öğesinin gerçek konumu hakkında bilgi verir ([getActualMaxValue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/axis/getactualmaxvalue/), [getActualMinValue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/axis/getactualminvalue/), [getActualMajorUnit](https://reference.aspose.com/slides/tr/php-java/aspose.slides/axis/getactualmajorunit/), [getActualMinorUnit](https://reference.aspose.com/slides/tr/php-java/aspose.slides/axis/getactualminorunit/), [getActualMajorUnitScale](https://reference.aspose.com/slides/tr/php-java/aspose.slides/axis/getactualmajorunitscale/), [getActualMinorUnitScale](https://reference.aspose.com/slides/tr/php-java/aspose.slides/axis/getactualminorunitscale/)). Özelliklerin gerçek değerlerle doldurulması için önce [Chart.validateChartLayout] metodunun çağrılması gerekir.

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

## **Ebeveyn Grafik Öğelerinin Gerçek Konumunu Hesapla**
Aspose.Slides for PHP via Java, bu özellikleri almak için basit bir API sağlar. `ActualLayout` sınıfının metodları, ebeveyn grafik öğesinin gerçek konumu hakkında bilgi verir (`getActualX`, `getActualY`, `getActualWidth`, `getActualHeight`). Özelliklerin gerçek değerlerle doldurulması için önce [Chart.validateChartLayout] metodunun çağrılması gerekir.

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

## **Grafik Öğelerini Gizle**
Bu konu, grafikten bilgileri nasıl gizleyeceğinizi anlamanıza yardımcı olur. Aspose.Slides for PHP via Java kullanarak grafikten **Başlık, Dikey Ekseni, Yatay Ekseni** ve **Izgara Çizgilerini** gizleyebilirsiniz. Aşağıdaki kod örneği bu özelliklerin nasıl kullanılacağını gösterir.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # Grafiğin Başlığını Gizleme
    $chart->setTitle(false);
    # /Değer Ekseni Gizleme
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # Kategori Ekseni Görünürlüğü
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # Lejandı Gizleme
    $chart->setLegend(false);
    # Ana Izgara Çizgilerini Gizleme
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # Serinin çizgi rengini ayarlama
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

## **SSS**

**Harici Excel çalışma kitapları veri kaynağı olarak çalışıyor mu ve bu yeniden hesaplamayı nasıl etkiler?**

Evet. Bir grafik, harici bir çalışma kitabına başvurabilir: harici kaynağa bağlandığınızda veya yenilediğinizde, formüller ve değerler o çalışma kitabından alınır ve grafik, açma/düzenleme işlemleri sırasında güncellemeleri yansıtır. API, [harici çalışma kitabını belirt] (https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/setexternalworkbook/) yolu belirlemenizi ve bağlı verileri yönetmenizi sağlar.

**Regresyonu kendim uygulamadan trend çizgilerini hesaplayıp görüntüleyebilir miyim?**

Evet. [Trendlines](/slides/tr/php-java/trend-line/) (lineer, üstel ve diğerleri) Aspose.Slides tarafından eklenir ve güncellenir; parametreleri seri verilerinden otomatik olarak yeniden hesaplanır, böylece kendi hesaplamalarınızı uygulamanıza gerek kalmaz.

**Bir sunumda dış bağlantılı birden fazla grafik varsa, her grafiğin hesaplanan değerler için hangi çalışma kitabını kullandığını kontrol edebilir miyim?**

Evet. Her grafik, kendi [harici çalışma kitabı](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/setexternalworkbook/) adresine işaret edebilir ya da her grafik için diğerlerinden bağımsız olarak bir harici çalışma kitabı oluşturabilir/değiştirebilirsiniz.