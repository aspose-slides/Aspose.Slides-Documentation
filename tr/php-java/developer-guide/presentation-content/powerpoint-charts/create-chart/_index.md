---
title: PHP'de PowerPoint Sunum Grafiklerini Oluşturma veya Güncelleme
linktitle: Grafik Oluşturma veya Güncelleme
type: docs
weight: 10
url: /tr/php-java/create-chart/
keywords:
- grafik ekle
- grafik oluştur
- grafik düzenle
- grafik değiştir
- grafik güncelle
- dağılım grafiği
- pasta grafiği
- çizgi grafiği
- ağaç haritası grafiği
- hisse senedi grafiği
- kutu ve bıyık grafiği
- huni grafiği
- güneş patlaması grafiği
- histogram grafiği
- radar grafiği
- çok kategorili grafik
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint sunumlarında grafikler oluşturun ve özelleştirin. Grafik ekleyin, biçimlendirin ve pratik kod örnekleriyle düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak grafik oluşturma ve özelleştirme konusunda kapsamlı bir rehber sunar. Programatik olarak bir slayta grafik eklemeyi, verilerle doldurmayı ve belirli tasarım gereksinimlerinize uygun çeşitli biçimlendirme seçeneklerini uygulamayı öğreneceksiniz. Makale boyunca, sunumu ve grafik nesnesini başlatmaktan seriler, eksenler ve açıklamalar yapılandırmaya kadar her adımı gösteren ayrıntılı kod örnekleri bulunur. Bu rehberi izleyerek, dinamik grafik üretimini uygulamalarınıza entegre etme konusunda sağlam bir anlayış kazanacak ve veri odaklı sunumlar oluşturma sürecini kolaylaştıracaksınız.

## **Grafik Oluşturma**

Grafikler, verileri hızlı bir şekilde görselleştirerek, bir tablo veya elektronik tablodan hemen anlaşılmayan içgörüler elde etmeye yardımcı olur.

**Neden Grafik Oluşturulur?**

* büyük miktarda veriyi tek bir slaytta toplamak, sıkıştırmak veya özetlemek  
* verideki desenleri ve eğilimleri ortaya çıkarmak  
* verinin zaman içindeki yönünü ve ivmesini veya belirli bir ölçüm birimine göre tahmin etmek  
* aykırı değerleri, sapmaları, hataları, mantıksız verileri vb. tespit etmek  
* karmaşık verileri iletmek veya sunmak  

PowerPoint'te, *Insert* (Ekle) işleviyle birçok grafik türü için şablonlar sunan grafikler oluşturabilirsiniz. Aspose.Slides kullanarak hem standart grafikler (popüler grafik türlerine dayalı) hem de özel grafikler oluşturabilirsiniz.

{{% alert color="info" title="Note" %}}
Grafik oluşturmak için [ChartType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/) sınıfını kullanın. Bu sınıftaki alanlar farklı grafik türlerine karşılık gelir.
{{% /alert %}}

### **Kümelenmiş Sütun Grafikleri Oluşturma**

Bu bölüm, Aspose.Slides kullanarak kümelenmiş sütun grafikleri oluşturmayı açıklar. Bir sunumu başlatmayı, bir grafik eklemeyi ve başlık, veri, seri, kategoriler ve stil gibi öğeleri özelleştirmeyi öğreneceksiniz. Aşağıdaki adımları izleyerek standart bir kümelenmiş sütun grafiğinin nasıl oluşturulduğunu görebilirsiniz:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfı örneği oluşturun.  
2. İndeksini kullanarak bir slayta referans alın.  
3. Biraz veri içeren bir grafik ekleyin ve `ChartType::ClusteredColumn` türünü belirtin.  
4. Grafiğe bir başlık ekleyin.  
5. Grafiğin veri çalışma sayfasına erişin.  
6. Varsayılan tüm serileri ve kategorileri temizleyin.  
7. Yeni seriler ve kategoriler ekleyin.  
8. Grafik serileri için yeni veri ekleyin.  
9. Grafik serisine dolgu rengi uygulayın.  
10. Grafik serisine etiketler ekleyin.  
11. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu C# kodu, bir kümelenmiş sütun grafiği oluşturmayı gösterir:

```php
  # Bir PPTX dosyasını temsil eden sunum sınıfını örnekler
  $pres = new Presentation();
  try {
    # İlk slayta erişir
    $sld = $pres->getSlides()->get_Item(0);
    # Varsayılan verileriyle bir grafik ekler
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # Grafik başlığını ayarlar
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # İlk seriyi değerleri gösterecek şekilde ayarlar
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Grafik veri sayfası için indeks ayarlar
    $defaultWorksheetIndex = 0;
    # Grafik veri çalışma sayfasını alır
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Varsayılan oluşturulan serileri ve kategorileri siler
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # Yeni seriler ekler
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Yeni kategoriler ekler
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # İlk grafik serisini alır
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Şimdi seri verilerini doldurur
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Seri için dolgu rengini ayarlar
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # İkinci grafik serisini alır
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Seri verilerini doldurur
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Seri için dolgu rengini ayarlar
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Yeni seri için her kategoriye özel etiketler oluşturur
    # İlk etiketi kategori adını gösterecek şekilde ayarlar
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # Üçüncü etiket için değeri gösterir
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # Grafikli sunumu kaydeder
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Dağılım Grafikleri Oluşturma**

Dağılım grafikleri (dağılım çizimleri veya x-y grafikleri olarak da bilinir) genellikle iki değişken arasındaki desenleri kontrol etmek veya korelasyonları göstermek için kullanılır.

Dağılım grafiği aşağıdaki durumlarda kullanılır:

* eşleşmiş sayısal verileriniz varsa  
* birlikte iyi eşleşen iki değişkeniniz varsa  
* iki değişkenin ilişkili olup olmadığını belirlemek istiyorsanız  
* bağımlı bir değişken için birden fazla değere sahip bağımsız bir değişkeniniz varsa  

1. [Create Clustered Column Charts](#create-clustered-column-charts) bölümündeki adımları izleyin.  
2. Üçüncü adım için, bazı veriler içeren bir grafik ekleyin ve grafik türünüzü aşağıdakilerden biri olarak belirtin:  
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _Dağılım grafiğini temsil eder._  
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Veri işaretçileriyle eğimli çizgilerle bağlanmış bir dağılım grafiğini temsil eder._  
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Veri işaretçileri olmadan eğimli çizgilerle bağlanmış bir dağılım grafiğini temsil eder._  
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Veri işaretçileriyle düz çizgilerle bağlanmış bir dağılım grafiğini temsil eder._  
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Veri işaretçileri olmadan düz çizgilerle bağlanmış bir dağılım grafiğini temsil eder._

Bu PHP kodu, her seri için farklı işaretçilerle bir dağılım grafiği oluşturmayı gösterir:

```php
  # Bir PPTX dosyasını temsil eden sunum sınıfını örnekler
  $pres = new Presentation();
  try {
    # İlk slayta erişir
    $slide = $pres->getSlides()->get_Item(0);
    # Varsayılan grafiği oluşturur
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # Varsayılan grafik veri çalışma sayfası indeksini alır
    $defaultWorksheetIndex = 0;
    # Grafik veri çalışma sayfasını alır
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Demo serisini siler
    $chart->getChartData()->getSeries()->clear();
    # Yeni seriler ekler
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # İlk grafik serisini alır
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Seriye yeni bir nokta (1:3) ekler
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # Yeni bir nokta (2:10) ekler
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # Seri tipini değiştirir
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # Grafik seri işaretçisini değiştirir
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # İkinci grafik serisini alır
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Oraya yeni bir nokta (5:2) ekler
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # Yeni bir nokta (3:1) ekler
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # Yeni bir nokta (2:2) ekler
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # Yeni bir nokta (5:1) ekler
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # Grafik seri işaretçisini değiştirir
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Pasta Grafiklerini Oluşturma**

Pasta grafikleri, özellikle sayısal değerlere sahip kategorik etiketler içeren verilerde, parça‑bütün ilişkisini göstermek için en iyisidir. Ancak verinizde çok sayıda parça veya etiket varsa, bir çubuk grafik kullanmayı düşünebilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı örneği oluşturun.  
2. İndeksini kullanarak bir slayta referans alın.  
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType::Pie](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/#Pie) türünü belirtin.  
4. Grafik veri çalışma kitabına [ChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/) erişin.  
5. Varsayılan serileri ve kategorileri temizleyin.  
6. Yeni seriler ve kategoriler ekleyin.  
7. Grafik serileri için yeni veri ekleyin.  
8. Grafiğe yeni noktalar ekleyin ve pasta dilimlerine özel renkler uygulayın.  
9. Seriler için etiketler ayarlayın.  
10. Seri etiketleri için gösterge hatlarını etkinleştirin.  
11. Pasta dilimlerinin dönüş açısını ayarlayın.  
12. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu PHP kodu, bir pasta grafiği oluşturmayı gösterir:

```php
  # Bir PPTX dosyasını temsil eden sunum sınıfını örnekler
  $pres = new Presentation();
  try {
    # İlk slayta erişir
    $slides = $pres->getSlides()->get_Item(0);
    # Varsayılan verilerle bir grafik ekler
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Grafik başlığını ayarlar
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # İlk seriyi değerleri gösterecek şekilde ayarlar
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Grafik veri sayfası için indeksi ayarlar
    $defaultWorksheetIndex = 0;
    # Grafik veri çalışma sayfasını alır
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Varsayılan oluşturulan serileri ve kategorileri siler
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Yeni kategoriler ekler
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Yeni seriler ekler
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Seri verilerini doldurur
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Yeni sürümde çalışmıyor
    # Yeni noktalar ekliyor ve dilim renklerini ayarlıyor
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # Dilim kenarlığını ayarlar
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # Dilim kenarlığını ayarlar
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # Dilim kenarlığını ayarlar
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # Yeni seri için her kategoriye özel etiketler oluşturur
    $lbl1 = $series->getDataPoints()->get_Item(0)->getLabel();
    # lbl.ShowCategoryName = true;
    $lbl1->getDataLabelFormat()->setShowValue(true);
    $lbl2 = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl2->getDataLabelFormat()->setShowValue(true);
    $lbl2->getDataLabelFormat()->setShowLegendKey(true);
    $lbl2->getDataLabelFormat()->setShowPercentage(true);
    $lbl3 = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl3->getDataLabelFormat()->setShowSeriesName(true);
    $lbl3->getDataLabelFormat()->setShowPercentage(true);
    # Grafik için Lider Çizgileri gösterir
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # Pasta Grafik Dilimlerinin Döndürme Açısını ayarlar
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # Grafikli sunumu kaydeder
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Çizgi Grafiklerini Oluşturma**

Çizgi grafikleri (çizgi grafikleri olarak da bilinir), zaman içinde değer değişikliklerini göstermek istediğiniz durumlarda en iyisidir. Bir çizgi grafiği kullanarak, büyük miktarda veriyi bir arada karşılaştırabilir, zaman içindeki değişimleri ve trendleri izleyebilir, veri serilerindeki anormallikleri vurgulayabilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı örneği oluşturun.  
1. İndeksini kullanarak bir slayta referans alın.  
1. Varsayılan verilerle bir grafik ekleyin ve [ChartType::Line](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/#Line) türünü belirtin.  
1. Grafik veri çalışma kitabına ([ChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/)) erişin.  
1. Varsayılan serileri ve kategorileri temizleyin.  
1. Yeni seriler ve kategoriler ekleyin.  
1. Grafik serileri için yeni veri ekleyin.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu PHP kodu, bir çizgi grafiği oluşturmayı gösterir:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Varsayılan olarak, bir çizgi grafiğindeki noktalar düz kesintisiz çizgilerle birleştirilir. Noktaların tireli çizgilerle birleştirilmesini isterseniz, tercih ettiğiniz tire türünü aşağıdaki gibi belirtebilirsiniz:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $seriesCollection = $lineChart->getChartData()->getSeries();
    foreach ($seriesCollection as $series) {
      $series->getFormat()->getLine()->setDashStyle(LineDashStyle::Dash);
    }
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Ağaç Haritası Grafiklerini Oluşturma**

Ağaç haritası grafikleri, her kategori içinde büyük katkı sağlayan öğelere hızlıca dikkat çekmek istediğiniz satış verileri için en uygunudur.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı örneği oluşturun.  
2. İndeksini kullanarak bir slayta referans alın.  
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType::Treemap](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/#Treemap) türünü belirtin.  
4. Grafik veri çalışma kitabına [ChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/) erişin.  
5. Varsayılan serileri ve kategorileri temizleyin.  
6. Yeni seriler ve kategoriler ekleyin.  
7. Grafik serileri için yeni veri ekleyin.  
8. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu PHP kodu, bir ağaç haritası grafiği oluşturmayı gösterir:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Treemap, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # dal 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # dal 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Treemap);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D8", 3));
    $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
    $pres->save("Treemap.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Hisse Senedi Grafiklerini Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı örneği oluşturun.  
2. İndeksini kullanarak bir slayta referans alın.  
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType::OpenHighLowClose](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/#OpenHighLowClose) türünü belirtin.  
4. Grafik veri çalışma kitabına [ChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/) erişin.  
5. Varsayılan serileri ve kategorileri temizleyin.  
6. Yeni seriler ve kategoriler ekleyin.  
7. Grafik serileri için yeni veri ekleyin.  
8. Yüksek-düşük çizgi biçimini belirtin.  
9. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu PHP kodu, bir hisse senedi grafiği oluşturmayı gösterir:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::OpenHighLowClose, 50, 50, 600, 400, false);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 1, 0, "A"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 2, 0, "B"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 3, 0, "C"));
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 1, "Open"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 2, "High"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 3, "Low"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 4, "Close"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 1, 72));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 1, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 1, 38));
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 2, 172));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 2, 57));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 2, 57));
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 3, 13));
    $series = $chart->getChartData()->getSeries()->get_Item(3);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 4, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 4, 38));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 4, 50));
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars()->setUpDownBars(true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getHiLowLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $seriesCollection = $chart->getChartData()->getSeries();
    foreach ($seriesCollection as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Kutu ve Bıyık Grafiklerini Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı örneği oluşturun.  
2. İndeksini kullanarak bir slayta referans alın.  
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType::BoxAndWhisker](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/#BoxAndWhisker) türünü belirtin.  
4. Grafik veri çalışma kitabına [ChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/) erişin.  
5. Varsayılan serileri ve kategorileri temizleyin.  
6. Yeni seriler ve kategoriler ekleyin.  
7. Grafik serileri için yeni veri ekleyin.  
8. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu PHP kodu, bir kutu ve bıyık grafiği oluşturmayı gösterir:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::BoxAndWhisker, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 1"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::BoxAndWhisker);
    $series->setQuartileMethod(QuartileMethodType::Exclusive);
    $series->setShowMeanLine(true);
    $series->setShowMeanMarkers(true);
    $series->setShowInnerPoints(true);
    $series->setShowOutlierPoints(true);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B1", 15));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B2", 41));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B3", 16));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B4", 10));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B5", 23));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B6", 16));
    $pres->save("BoxAndWhisker.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Huni Grafiklerini Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı örneği oluşturun.  
2. İndeksini kullanarak bir slayta referans alın.  
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType::Funnel](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/#Funnel) türünü belirtin.  
4. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu PHP kodu, bir huni grafiği oluşturmayı gösterir:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 2"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 3"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 4"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 5"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 6"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Funnel);
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B1", 50));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B2", 100));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B3", 200));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B4", 300));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B5", 400));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B6", 500));
    $pres->save("Funnel.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Güneş Patlaması Grafiklerini Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı örneği oluşturun.  
2. İndeksini kullanarak bir slayta referans alın.  
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType::Sunburst](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/#Sunburst) türünü belirtin.  
4. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu PHP kodu, bir güneş patlaması grafiği oluşturmayı gösterir:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # dal 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # dal 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Sunburst);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D8", 3));
    $pres->save("Sunburst.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Histogram Grafiklerini Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı örneği oluşturun.  
2. İndeksini kullanarak bir slayta referans alın.  
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType::Histogram](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/#Histogram) türünü belirtin.  
4. Grafik veri çalışma kitabına [ChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/) erişin.  
5. Varsayılan serileri ve kategorileri temizleyin.  
6. Yeni seriler ve kategoriler ekleyin.  
7. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu PHP kodu, bir histogram grafiği oluşturmayı gösterir:

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Histogram, 50, 50, 500, 400);
  $chart->getChartData()->getCategories()->clear();
  $chart->getChartData()->getSeries()->clear();
  $wb = $chart->getChartData()->getChartDataWorkbook();
  $wb->clear(0);
  $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A1", 15));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A2", -41));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A3", 16));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A4", 10));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A5", -23));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A6", 16));
  $chart->getAxes()->getHorizontalAxis()->setAggregationType(AxisAggregationType::Automatic);
```

### **Radar Grafiklerini Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı örneği oluşturun.  
2. İndeksini kullanarak bir slayta referans alın.  
3. Bazı verilerle bir grafik ekleyin ve bu durumda tercih ettiğiniz grafik türünü [ChartType::Radar](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/#Radar) olarak belirtin.  
4. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu PHP kodu, bir radar grafiği oluşturmayı gösterir:

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Radar, 20, 20, 400, 300);
    $pres->save("Radar-chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Çok Kategorili Grafikler Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı örneği oluşturun.  
2. İndeksini kullanarak bir slayta referans alın.  
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType::ClusteredColumn](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/#ClusteredColumn) türünü belirtin.  
4. Grafik veri çalışma kitabına [ChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/) erişin.  
5. Varsayılan serileri ve kategorileri temizleyin.  
6. Yeni seriler ve kategoriler ekleyin.  
7. Grafik serileri için yeni veri ekleyin.  
8. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu PHP kodu, çok kategorili bir grafik oluşturmayı gösterir:

```php
  $pres = new Presentation();
  try {
    $ch = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 600, 450);
    $ch->getChartData()->getSeries()->clear();
    $ch->getChartData()->getCategories()->clear();
    $fact = $ch->getChartData()->getChartDataWorkbook();
    $fact->clear(0);
    $defaultWorksheetIndex = 0;
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c2", "A"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group1");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c3", "B"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c4", "C"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group2");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c5", "D"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c6", "E"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group3");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c7", "F"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c8", "G"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group4");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c9", "H"));
    # Seri ekleme
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "Series 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # Grafikli sunumu kaydet
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Harita Grafiklerini Oluşturma**

Harita grafikleri coğrafi verileri görselleştirir ve bölgeler arasındaki değerleri karşılaştırmaya yardımcı olur.

Bu PHP kodu, bir harita grafiği oluşturmayı gösterir:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Map, 50, 50, 500, 400);
    $pres->save("mapChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Kombinasyon Grafiklerini Oluşturma**

Kombinasyon grafiği (veya combo grafiği), tek bir grafikte iki veya daha fazla grafik türünü birleştirir. Bu grafik, iki veya daha fazla veri kümesi arasındaki farkları vurgulamanıza, karşılaştırmanıza veya incelemenize olanak tanır ve ilişkileri tanımlamanıza yardımcı olur.

![Kombinasyon grafiği](combination_chart.png)

Aşağıdaki PHP kodu, yukarıda gösterilen kombinasyon grafiğini bir PowerPoint sunumunda oluşturmayı gösterir:

```php
function createComboChart() {
    $presentation = new Presentation();
    $slide = $presentation->getSlides()->get_Item(0);
    try {
        $chart = createChartWithFirstSeries($slide);

        addSecondSeriesToChart($chart);
        addThirdSeriesToChart($chart);

        setPrimaryAxesFormat($chart);
        setSecondaryAxesFormat($chart);

        $presentation->save("combo-chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}

function createChartWithFirstSeries($slide) {
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // Grafik başlığını ayarlar.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // Grafik açıklamasını ayarlar.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // Varsayılan oluşturulan serileri ve kategorileri siler.
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // Yeni kategoriler ekler.
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // İlk seriyi ekler.
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 1, 4.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 1, 2.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 1, 3.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 1, 4.5));

    return $chart;
}

function addSecondSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 2, 2.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 2, 4.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 2, 1.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Line);

    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 1, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 2, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 3, 3, 3.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 4, 3, 5.0));

    $series->setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat($chart) {
    // Yatay ekseni ayarlar.
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // Dikey ekseni ayarlar.
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // Dikey ana ızgara çizgilerinin rengini ayarlar.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // İkincil yatay ekseni ayarlar.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // İkincil dikey ekseni ayarlar.
    $secondaryVerticalAxis = $chart->getAxes()->getSecondaryVerticalAxis();
    $secondaryVerticalAxis->setPosition(AxisPositionType::Right);
    $secondaryVerticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $secondaryVerticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle($axis, $axisTitle) {
    $axis->setTitle(true);
    $axis->getTitle()->setOverlay(false);
    $titleParagraph = $axis->getTitle()->addTextFrameForOverriding($axisTitle)->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(12);
}
```

## **Grafikleri Güncelleme**

1. Grafik içeren sunumu temsil eden bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneği oluşturun.  
2. İndeksini kullanarak bir slayta referans alın.  
3. İstenen grafiği bulmak için tüm şekillerde dolaşın.  
4. Grafik veri çalışma sayfasına erişin.  
5. Seri değerlerini değiştirerek grafik veri serisini düzenleyin.  
6. Yeni bir seri ekleyin ve verilerini doldurun.  
7. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu PHP kodu, bir grafiği güncellemeyi gösterir:

```php
  $pres = new Presentation();
  try {
    # İlk slayt işaretçisine eriş
    $sld = $pres->getSlides()->get_Item(0);
    # Varsayılan verilerle grafiği al
    $chart = $sld->getShapes()->get_Item(0);
    # Grafik veri sayfasının indeksini ayarla
    $defaultWorksheetIndex = 0;
    # Grafik veri çalışma sayfasını al
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Grafik kategori adını değiştir
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # İlk grafik serisini al
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Şimdi seri verilerini güncelle
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// Serinin adını değiştiriyor

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # İkinci grafik serisini al
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Şimdi seri verilerini güncelle
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// Serinin adını değiştiriyor

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # Şimdi yeni bir seri ekle
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # Üçüncü grafik serisini al
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # Şimdi seri verilerini doldur
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # Grafikli sunumu kaydet
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bir Grafik İçin Veri Aralığını Ayarlama**

Bir grafik için veri aralığını ayarlamak için şu adımları izleyin:

1. Grafik içeren sunumu temsil eden bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneği oluşturun.  
2. İndeksini kullanarak bir slayta referans alın.  
3. İstenen grafiği bulmak için tüm şekillerde dolaşın.  
4. Grafiğin verilerine erişin ve aralığı ayarlayın.  
5. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu PHP kodu, bir grafik için veri aralığını ayarlamayı gösterir:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->get_Item(0);
    $chart->getChartData()->setRange("Sheet1!A1:B4");
    $pres->save("SetDataRange_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Grafiklerde Varsayılan İşaretçileri Kullanma**

Grafiklerde varsayılan işaretçileri kullandığınızda, her grafik serisi otomatik olarak farklı bir işaretçi sembolü alır.

Bu PHP kodu, bir grafik serisi işaretçisini otomatik olarak ayarlamayı gösterir:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 10, 10, 400, 400);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $fact = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "C1"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 1, 24));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "C2"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 1, 23));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "C3"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 1, -10));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 4, 0, "C4"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 1, null));
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 2, "Series 2"), $chart->getType());
    # İkinci grafik serisini al
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # Şimdi seri verilerini dolduruyor
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 2, 30));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 2, 10));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 2, 60));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 2, 40));
    $chart->setLegend(true);
    $chart->getLegend()->setOverlay(false);
    $pres->save("DefaultMarkersInChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Aspose.Slides tarafından hangi grafik türleri desteklenir?**

Aspose.Slides, çubuk, çizgi, pasta, alan, dağılım, histogram, radar ve daha birçok [grafik türünü](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/) destekler. Bu esneklik, veri görselleştirme ihtiyaçlarınız için en uygun grafik türünü seçmenizi sağlar.

**Bir slayta yeni bir grafik nasıl eklenir?**

Yeni bir grafik eklemek için önce bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı örneği oluşturur, istenen slaytı indeksle elde eder ve ardından grafik ekleme metodunu çağırarak grafik türünü ve başlangıç verilerini belirtirsiniz. Bu işlem, grafiği doğrudan sunumunuza entegre eder.

**Bir grafikte gösterilen veriler nasıl güncellenir?**

Grafiğin verilerini, veri çalışma kitabına ([ChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/)) erişerek, varsayılan serileri ve kategorileri temizleyip, kendi özel verilerinizi ekleyerek güncelleyebilirsiniz. Böylece grafik, en yeni verileri yansıtacak şekilde yenilenir.

**Grafiğin görünümü özelleştirilebilir mi?**

Evet, Aspose.Slides kapsamlı özelleştirme seçenekleri sunar. Renkler, yazı tipleri, etiketler, açıklamalar ve diğer [biçimlendirme öğeleri](/slides/tr/php-java/chart-entities/) değiştirilerek grafik, belirli tasarım gereksinimlerinize göre şekillendirilebilir.