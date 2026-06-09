---
title: Sunumlarda PHP Kullanarak Grafik Veri Serilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/php-java/chart-series/
keywords:
- grafik serileri
- seri çakışması
- seri rengi
- kategori rengi
- seri adı
- veri noktası
- seri boşluğu
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) için PHP’de grafik veri serilerini nasıl yöneteceğinizi, pratik kod örnekleri ve en iyi uygulamalarla öğrenerek veri sunumlarınızı geliştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde [ChartSeries](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/) rolünü, verilerin sunumlarda nasıl yapılandırıldığını ve görselleştirildiğini odaklanarak açıklar. Bu nesneler, bir grafikteki bireysel veri noktaları, kategoriler ve görünüm parametrelerini tanımlayan temel öğeleri sağlar. [ChartSeries](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/) ile çalışarak geliştiriciler, temel veri kaynaklarını sorunsuz bir şekilde entegre edebilir ve bilgilerin nasıl gösterileceği üzerinde tam kontrol sağlayabilir, böylece içgörüleri ve analizleri net bir şekilde ileten dinamik, veri odaklı sunumlar oluşturabilir.

Bir seri, bir grafikte çizilen sayıların bir satırı veya sütunudur.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Çakışmasını Ayarlama**

Bu [getParentSeriesGroup](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/#getParentSeriesGroup) yöntemiyle, 2B bir grafikte çubukların ve sütunların ne kadar çakışacağını belirleyebilirsiniz (aralık: -100 ile 100). Bu özellik, üst seri grubunun tüm serilerine uygulanır: bu, ilgili grup özelliğinin bir yansımasıdır. Bu nedenle, bu özellik yalnızca okunabilir.

`ChartSeriesGroup::setOverlap` metodunu kullanarak `Overlap` için tercih ettiğiniz değeri ayarlayın.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. Bir slayda bir gruplanmış sütun grafiği ekleyin.  
1. İlk grafik serisine erişin.  
1. Grafik serisinin `ParentSeriesGroup` özelliğine erişin ve seri için tercih ettiğiniz çakışma değerini ayarlayın.  
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.  

Bu PHP kodu, bir grafik serisi için çakışmayı nasıl ayarlayacağınızı gösterir:

```php
  $pres = new Presentation();
  try {
    # Grafik ekler
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # Seri çakışmasını ayarlar
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # Sunum dosyasını diske yazar
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Seri Rengini Değiştirme**

Aspose.Slides for PHP via Java, bir serinin rengini şu şekilde değiştirmenizi sağlar:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. Slayda bir grafik ekleyin.  
1. Rengini değiştirmek istediğiniz seriye erişin.  
1. Tercih ettiğiniz dolgu tipini ve dolgu rengini ayarlayın.  
1. Değiştirilmiş sunumu kaydedin.  

Bu PHP kodu, bir serinin rengini nasıl değiştireceğinizi gösterir:

```php
  $pres = new Presentation("test.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(1);
    $point->setExplosion(30);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Seri Kategori Rengini Değiştirme**

Aspose.Slides for PHP via Java, bir serinin kategori rengini şu şekilde değiştirmenizi sağlar:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. Slayda bir grafik ekleyin.  
1. Rengini değiştirmek istediğiniz seri kategorisine erişin.  
1. Tercih ettiğiniz dolgu tipini ve dolgu rengini ayarlayın.  
1. Değiştirilmiş sunumu kaydedin.  

Bu kod  shows you how to change a series category's color:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Seri Adını Değiştirme** 

Varsayılan olarak, bir grafiğin efsane adları, her sütun veya satırın üzerindeki hücrelerin içeriğidir. 

Örneğimizde (örnek görüntü), 

* sütunlar *Series 1, Series 2,* ve *Series 3*;  
* satırlar *Category 1, Category 2, Category 3,* ve *Category 4.*  

Aspose.Slides for PHP via Java, bir serinin adını grafik verilerinde ve efsanede güncellemenize veya değiştirmenize olanak tanır.

Bu PHP kodu, grafik verisi `ChartDataWorkbook` içinde bir serinin adını nasıl değiştirileceğini gösterir:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("New name");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Bu PHP kodu, `Series` aracılığıyla bir serinin adını efsanede nasıl değiştireceğinizi gösterir:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("New name");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Grafik Serisi Dolgu Rengini Ayarlama**

Aspose.Slides for PHP via Java, bir grafik serisi için otomatik dolgu rengini şu şekilde ayarlamanızı sağlar:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. Bir slaydın referansını indeksine göre alın.  
1. Tercih ettiğiniz türe göre (aşağıdaki örnekte `ChartType::ClusteredColumn` kullandık) varsayılan verilerle bir grafik ekleyin.  
1. Grafik serisine erişin ve dolgu rengini Automatic olarak ayarlayın.  
1. Sunumu bir PPTX dosyasına kaydedin.  

Bu PHP kodu, bir grafik serisi için otomatik dolgu rengini nasıl ayarlayacağınızı gösterir:

```php
  $pres = new Presentation();
  try {
    # Gruplanmış sütun grafiği oluşturur
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # Seri dolgu formatını otomatik olarak ayarlar
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # Sunum dosyasını diske yazar
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Grafik Serisi için Ters Dolgu Rengini Ayarlama**

Aspose.Slides, bir grafik serisi için ters dolgu rengini şu şekilde ayarlamanıza olanak tanır:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. Bir slaydın referansını indeksine göre alın.  
1. Tercih ettiğiniz türe göre (aşağıdaki örnekte `ChartType::ClusteredColumn` kullandık) varsayılan verilerle bir grafik ekleyin.  
1. Grafik serisine erişin ve dolgu rengini invert olarak ayarlayın.  
1. Sunumu bir PPTX dosyasına kaydedin.  

Bu PHP kodu işlemi gösterir:

```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Yeni seri ve kategoriler ekler
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Category 3"));
    # İlk grafik serisini alır ve seri verilerini doldurur.
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 1, 1, -20));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 3, 1, -30));
    $seriesColor = $series->getAutomaticSeriesColor();
    $series->setInvertIfNegative(true);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColor);
    $series->getInvertedSolidFillColor()->setColor($inverColor);
    $pres->save("SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Negatif Değerlerde Seriyi Ters Çevir** 

Aspose.Slides, ters çevirme işlemini `IChartDataPoint.InvertIfNegative` ve `ChartDataPoint.InvertIfNegative` özellikleri aracılığıyla ayarlamanıza olanak tanır. Bu özellikler kullanılarak ters çevirme ayarlandığında, veri noktası negatif bir değer aldığında renklerini tersine çevirir. 

Bu PHP kodu işlemi gösterir:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $chart->getChartData()->getSeries()->clear();
    $chartSeries = $series->add($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1"), $chart->getType());
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B2", -5));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B3", 3));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B4", -2));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B5", 1));
    $chartSeries->setInvertIfNegative(false);
    $chartSeries->getDataPoints()->get_Item(2)->setInvertIfNegative(true);
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Belirli Nokta Verilerini Temizleme**

Aspose.Slides for PHP via Java, belirli bir grafik serisi için `DataPoints` verilerini şu şekilde temizlemenizi sağlar:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeksine göre alın.  
3. Grafiğin referansını indeksine göre alın.  
4. Tüm grafik `DataPoints` öğeleri üzerinde döngü yapın ve `XValue` ve `YValue` değerlerini null olarak ayarlayın.  
5. Belirli grafik serisi için tüm`DataPoints` öğelerini temizleyin.  
6. Değiştirilmiş sunumu bir PPTX dosyasına yazın.  

Bu PHP kodu işlemi gösterir:

```php
  $pres = new Presentation("TestChart.pptx");
  try {
    $sl = $pres->getSlides()->get_Item(0);
    $chart = $sl->getShapes()->get_Item(0);
    foreach($chart->getChartData()->getSeries()->get_Item(0)->getDataPoints() as $dataPoint) {
      $dataPoint->getXValue()->getAsCell()->setValue(null);
      $dataPoint->getYValue()->getAsCell()->setValue(null);
    }
    $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->clear();
    $pres->save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Seri Boşluk Genişliğini Ayarlama**

Aspose.Slides for PHP via Java, **`GapWidth`** özelliği aracılığıyla bir serinin Boşluk Genişliğini şu şekilde ayarlamanızı sağlar:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. İlk slayta erişin.  
1. Varsayılan verilerle bir grafik ekleyin.  
1. Herhangi bir grafik serisine erişin.  
1. `GapWidth` özelliğini ayarlayın.  
1. Sunumu bir PPTX dosyasına yazın.  

Bu kod bir serinin Boşluk Genişliğini nasıl ayarlayacağınızı gösterir:

```php
  # Boş bir sunum oluşturur
  $pres = new Presentation();
  try {
    # Sunumun ilk slaytına erişir
    $slide = $pres->getSlides()->get_Item(0);
    # Varsayılan verilerle bir grafik ekler
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # Grafik veri sayfasının indeksini ayarlar
    $defaultWorksheetIndex = 0;
    # Grafik veri çalışma sayfasını alır
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Seriler ekler
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Kategoriler ekler
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # İkinci grafik serisini alır
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Seri verilerini doldurur
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # GapWidth değerini ayarlar
    $series->getParentSeriesGroup()->setGapWidth(50);
    # Sunumu diske kaydeder
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Tek bir grafiğin içerebileceği seri sayısı için bir limit var mı?**

Aspose.Slides, eklediğiniz seri sayısı için sabit bir sınırlama getirmez. Pratikteki üst sınır, grafiğin okunabilirliği ve uygulamanızın kullandığı bellek miktarı tarafından belirlenir.

**Küme içindeki sütunlar çok yakın mı yoksa çok mu uzak?**

`GapWidth` ayarını ilgili seri (veya üst seri grubu) için ayarlayın. Değeri artırmak sütunlar arasındaki boşluğu genişletir, değeri azaltmak ise onları birbirine daha yakın yapar.