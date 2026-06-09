---
title: PHP Kullanarak Sunumlarda Grafik Ekseni Özelleştirme
linktitle: Grafik Ekseni
type: docs
url: /tr/php-java/chart-axis/
keywords:
- grafik ekseni
- dikey eksen
- yatay eksen
- eksen özelleştirme
- eksen manipülasyonu
- eksen yönetimi
- eksen özellikleri
- maksimum değer
- minimum değer
- eksen çizgisi
- tarih formatı
- eksen başlığı
- eksen konumu
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Raporlar ve görselleştirmeler için PowerPoint sunumlarında grafik eksenlerini özelleştirmek amacıyla Aspose.Slides for PHP via Java kullanımını keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'de grafik eksenlerini nasıl özelleştireceğinizi açıklar. Gerçek eksen değerlerini almayı, eksenler arasında verileri değiştirmeyi, çizgi grafiklerde dikey veya yatay ekseni gizlemeyi, kategori eksen tipini değiştirmeyi, kategori eksen değerleri için tarih formatını ayarlamayı, bir eksen başlığını döndürmeyi, eksen konumunu ayarlamayı ve değer ekseninde bir birim etiketi görüntülemeyi gösterir.

## **Grafiklerde Dikey Eksenin En Büyük Değerlerini Alın**
Aspose.Slides for PHP via Java, dikey eksende minimum ve maksimum değerleri elde etmenizi sağlar. Aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. İlk slayta erişin.  
3. Varsayılan verilerle bir grafik ekleyin.  
4. Eksen üzerindeki gerçek maksimum değeri alın.  
5. Eksen üzerindeki gerçek minimum değeri alın.  
6. Eksenin gerçek ana birimini alın.  
7. Eksenin gerçek yan birimini alın.  
8. Eksenin gerçek ana birim ölçeğini alın.  
9. Eksenin gerçek yan birim ölçeğini alın.  

Bu örnek kod—yukarıdaki adımların bir uygulaması—gerekli değerleri nasıl alacağınızı gösterir :

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
    # Sunumu kaydeder
    $pres->save("MaxValuesVerticalAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Eksenler Arasındaki Verileri Değiştir**
Aspose.Slides, eksenler arasındaki verileri hızlıca değiştirmenizi sağlar—dikey eksende (y-eksen) temsil edilen veri, yatay eksene (x-eksen) ve tersine geçer.  

Bu PHP kodu, bir grafikte eksenler arasındaki veri değişim görevini nasıl gerçekleştireceğinizi gösterir:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # Satırları ve sütunları değiştirir
    $chart->getChartData()->switchRowColumn();
    # Sunumu kaydeder
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Çizgi Grafiklerde Dikey Eksen'i Devre Dışı Bırak**

Bu PHP kodu, bir çizgi grafiği için dikey ekseni nasıl gizleyeceğinizi gösterir:

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

## **Çizgi Grafiklerde Yatay Eksen'i Devre Dışı Bırak**

Bu kod, bir çizgi grafiği için yatay ekseni nasıl gizleyeceğinizi gösterir:

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

## **Kategori Eksenini Değiştir**

**CategoryAxisType** özelliğini kullanarak, tercih ettiğiniz kategori eksen tipini (**date** veya **text**) belirtebilirsiniz. Bu kod işlemi gösterir:

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

## **Kategori Eksen Değerleri İçin Tarih Biçimini Ayarla**
Aspose.Slides for PHP via Java, bir kategori eksen değeri için tarih biçimini ayarlamanızı sağlar. Bu PHP kodunda işlem gösterilmiştir:

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

## **Grafik Eksen Başlığı İçin Döndürme Açısını Ayarla**
Aspose.Slides for PHP via Java, bir grafik eksen başlığı için döndürme açısını ayarlamanızı sağlar. Bu PHP kodu işlemi gösterir:

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

## **Kategori veya Değer Ekseninde Eksen Konumunu Ayarla**
Aspose.Slides for PHP via Java, bir kategori veya değer ekseninde eksen konumunu ayarlamanızı sağlar. Bu PHP kodu görevi nasıl gerçekleştireceğinizi gösterir:

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

## **Grafik Değer Ekseninde Birim Etiketinin Görüntülenmesini Etkinleştir**
Aspose.Slides for PHP via Java, bir grafik değer ekseninde birim etiketinin görüntülenmesini yapılandırmanızı sağlar. Bu PHP kodu işlemi gösterir:

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

## **SSS**

**Bir eksenin diğerini kestiği değeri (ekseni kesişim) nasıl ayarlarım?**

Eksenler, bir [kesişme ayarı](https://reference.aspose.com/slides/tr/php-java/aspose.slides/axis/setcrosstype/) sağlar: sıfırda, maksimum kategori/değerde veya belirli bir sayısal değerde kesişmeyi seçebilirsiniz. Bu, X-eksenini yukarı ya da aşağı kaydırmak ya da bir temel çizgiyi vurgulamak için kullanışlıdır.

**Tick etiketlerini eksene göre (yan yana, dışarı, içeri) nasıl konumlandırabilirim?**

Eksen etiket konumunu [label position](https://reference.aspose.com/slides/tr/php-java/aspose.slides/axis/setmajortickmark/) "cross", "outside" veya "inside" olarak ayarlayın. Bu, okunabilirliği etkiler ve özellikle küçük grafiklerde alan tasarrufu sağlar.