---
title: PowerPoint Sunum Grafiklerini PHP'de Oluşturma veya Güncelleme
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
- dağılımlı grafik
- pasta grafik
- çizgi grafik
- ağaç haritası grafik
- hisse senedi grafik
- kutu ve bıyık grafik
- huni grafik
- güneş patlaması grafik
- histogram grafik
- radar grafik
- çok kategori grafik
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint sunumlarında grafik oluşturun ve özelleştirin. Pratik kod örnekleriyle grafik ekleyin, biçimlendirin ve düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak grafik oluşturma ve özelleştirme üzerine kapsamlı bir kılavuz sunar. Bir grafiği slayta programlı olarak nasıl ekleyeceğinizi, verileri nasıl dolduracağınızı ve belirli tasarım gereksinimlerinize uygun biçimlendirme seçeneklerini nasıl uygulayacağınızı öğreneceksiniz. Makale boyunca, sunumu ve grafik nesnesini başlatmaktan seriler, eksenler ve lejandları yapılandırmaya kadar her adımı gösteren ayrıntılı kod örnekleri bulunur. Bu kılavuzu takip ederek, dinamik grafik üretimini uygulamalarınıza entegre etme konusunda sağlam bir anlayış kazanacak ve veri odaklı sunumlar oluşturma sürecini kolaylaştıracaksınız.

## **Grafik Oluşturma**

Grafikler, verileri hızla görselleştirerek içgörüler elde etmeyi sağlar; bu, bir tablo ya da elektronik tabloda hemen görülmeyebilir.

**Grafik Oluşturmanın Nedenleri**

Grafikler sayesinde

* büyük miktarda veriyi tek bir slaytta toplar, özetler veya sıkıştırırsınız
* veri içinde desen ve eğilimleri ortaya çıkarırsınız
* zaman içinde ya da belirli bir ölçü birimi bağlamında verinin yönünü ve ivmesini tahmin edersiniz
* aykırı değerleri, sapmaları, hataları, mantıksız verileri vb. tespit edersiniz
* karmaşık verileri iletişim kurmak ya da sunmak için kullanırsınız

PowerPoint’te, birçok grafik türünü tasarlamak için şablonlar sağlayan ekle işleviyle grafik oluşturabilirsiniz. Aspose.Slides ile popüler grafik türlerine dayalı normal grafikler ve özel grafikler oluşturabilirsiniz.

{{% alert color="primary" %}} 

Grafik oluşturmanıza olanak sağlamak için Aspose.Slides, [ChartType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ChartType) sınıfını sunar. Bu sınıfın alanları farklı grafik türlerine karşılık gelir.

{{% /alert %}} 

### **Normal Grafikler Oluşturma**

_Adımlar: Grafik Oluştur_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Adımlar:</em> PowerPoint Grafik Oluştur </strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Adımlar:</em> Sunum Grafiği Oluştur </strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Adımlar:</em> PowerPoint Sunum Grafiği Oluştur </strong></a>

_Kod Adımları:_

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slaydın referansını indeks üzerinden alın.
3. Veri ekleyerek ve tercih ettiğiniz grafik türünü belirterek bir grafik ekleyin. 
4. Grafik için bir başlık ekleyin. 
5. Grafik veri çalışma sayfasına erişin.
6. Varsayılan tüm serileri ve kategorileri temizleyin.
7. Yeni seriler ve kategoriler ekleyin.
8. Grafik serileri için yeni veri ekleyin.
9. Grafik serileri için dolgu rengi ekleyin.
10. Grafik serileri için etiketler ekleyin. 
11. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Bu PHP kodu, normal bir grafik oluşturmayı gösterir:

```php
  # PPTX dosyasını temsil eden bir sunum sınıfını örnekler
  $pres = new Presentation();
  try {
    # İlk slayta erişir
    $sld = $pres->getSlides()->get_Item(0);
    # Varsayılan verileriyle bir grafik ekler
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # Grafiğin başlığını ayarlar
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # İlk seriyi değerleri gösterecek şekilde ayarlar
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Grafik veri sayfası için indeksi ayarlar
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
    # Seri için dolgu rengi ayarlar
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # İkinci grafik serisini alır
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Seri verilerini doldurur
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Seri için dolgu rengi ayarlar
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

### **Dağılımlı Grafikler Oluşturma**
Dağılımlı grafikler (scatter plot ya da x‑y grafiği olarak da bilinir) genellikle iki değişken arasındaki desenleri kontrol etmek veya korelasyonları göstermek için kullanılır.

Aşağıdaki durumlarda dağılımlı grafik kullanmak isteyebilirsiniz

* eşleştirilmiş sayısal verileriniz varsa
* birlikte iyi eşleşen iki değişkeniniz varsa
* iki değişkenin ilişkili olup olmadığını belirlemek istiyorsanız
* bağımsız bir değişkenin bağımlı bir değişken için birden çok değeri varsa

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Adımlar:</em> Dağılımlı Grafik Oluştur </strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Adımlar:</em> PowerPoint Dağılımlı Grafik Oluştur </strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Adımlar:</em> PowerPoint Sunum Dağılımlı Grafik Oluştur </strong></a>

1. Yukarıda **[Normal Grafikler Oluşturma](#creating-normal-charts)** bölümünde verilen adımları izleyin
2. Üçüncü adımda, bir grafik ekleyin ve grafik türünü aşağıdakilerden biri olarak belirleyin
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _Dağılımlı Grafiği Temsil eder._
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Eğrilerle bağlanan ve veri işaretçileri içeren Dağılımlı Grafiği Temsil eder._
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Eğrilerle bağlanan, veri işaretçileri olmayan Dağılımlı Grafiği Temsil eder._
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Çizgilerle bağlanan ve veri işaretçileri içeren Dağılımlı Grafiği Temsil eder._
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Çizgilerle bağlanan, veri işaretçileri olmayan Dağılımlı Grafiği Temsil eder._

Bu PHP kodu, farklı işaretçi serileriyle bir dağılımlı grafik oluşturmayı gösterir:

```php
  # PPTX dosyasını temsil eden bir sunum sınıfını örnekler
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
    # Grafik serisi işaretçisini değiştirir
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # İkinci grafik serisini alır
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Orada yeni bir nokta (5:2) ekler
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # Yeni bir nokta (3:1) ekler
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # Yeni bir nokta (2:2) ekler
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # Yeni bir nokta (5:1) ekler
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # Grafik serisi işaretçisini değiştirir
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Pasta Grafikler Oluşturma**

Pasta grafikler, özellikle veri kategorik etiketler ve sayısal değerler içerdiğinde, parçanın bütünle ilişkisini göstermek için en uygunudur. Ancak veriniz çok sayıda parça ya da etiket içeriyorsa, bunun yerine çubuk grafik kullanmayı düşünebilirsiniz.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Adımlar:</em> Pasta Grafik Oluştur </strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Adımlar:</em> PowerPoint Pasta Grafik Oluştur </strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Adımlar:</em> PowerPoint Sunum Pasta Grafik Oluştur </strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slaydın referansını indeks üzerinden alın.
3. İstenen tür (bu durumda [ChartType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ChartType).Pie) ile varsayılan veri ekleyerek bir grafik ekleyin.
4. [ChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/) nesnesine erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni veri ekleyin.
8. Pasta dilimlerine özel renkler ekleyerek yeni noktalar ekleyin.
9. Seriler için etiketler ayarlayın.
10. Seri etiketleri için lider çizgileri ayarlayın.
11. Pasta grafik slaytları için döndürme açısını ayarlayın.
12. Değiştirilmiş sunumu PPTX dosyasına yazın.

Bu PHP kodu, bir pasta grafik oluşturmayı gösterir:

```php
  # PPTX dosyasını temsil eden bir sunum sınıfını örnekler
  $pres = new Presentation();
  try {
    # İlk slayta erişir
    $slides = $pres->getSlides()->get_Item(0);
    # Varsayılan veri ile bir grafik ekler
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Grafiğin başlığını ayarlar
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
    # Yeni seri ekler
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Seri verilerini doldurur
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Yeni sürümde çalışmıyor
    # Yeni noktalar ekleyerek dilim rengini ayarlar
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
    # Grafik için lider çizgileri gösterir
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # Pasta grafik dilimleri için döndürme açısını ayarlar
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # Grafikli sunumu kaydeder
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Çizgi Grafikler Oluşturma**

Çizgi grafikler (çizgi grafiği olarak da bilinir), değerlerin zaman içindeki değişimini göstermek istediğiniz durumlarda en uygunudur. Çizgi grafiği kullanarak çok sayıda veriyi aynı anda karşılaştırabilir, zaman içinde değişim ve eğilimleri izleyebilir, veri serilerindeki anormallikleri vurgulayabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. Bir slaydın referansını indeks üzerinden alın.
1. İstenen tür (`ChartType::Line`) ile varsayılan veri ekleyerek bir grafik ekleyin.
1. IChartDataWorkbook nesnesine erişin.
1. Varsayılan serileri ve kategorileri temizleyin.
1. Yeni seriler ve kategoriler ekleyin.
1. Grafik serileri için yeni veri ekleyin.
1. Değiştirilmiş sunumu PPTX dosyasına yazın

Bu PHP kodu, bir çizgi grafik oluşturmayı gösterir:

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

Varsayılan olarak, çizgi grafik üzerindeki noktalar düz sürekli çizgilerle bağlanır. Noktaların kesikli çizgilerle bağlanmasını istiyorsanız, tercih ettiğiniz kesik tipi aşağıdaki şekilde belirtebilirsiniz:

```php
  $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
  foreach($lineChart->getChartData()->getSeries() as $series) {
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Dash);
  }
```

### **Ağaç Haritası Grafikler Oluşturma**

Ağaç haritası grafikler, her bir kategori içindeki büyük katkı sağlayan öğelere hızlıca dikkat çekmek ve veri kategorilerinin göreceli boyutlarını göstermek istediğiniz satış verileri için en uygundur. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Adımlar:</em> Ağaç Haritası Grafik Oluştur </strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Adımlar:</em> PowerPoint Ağaç Haritası Grafik Oluştur </strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Adımlar:</em> PowerPoint Sunum Ağaç Haritası Grafik Oluştur </strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slaydın referansını indeks üzerinden alın.
3. İstenen tür (bu durumda [ChartType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ChartType).TreeMap) ile varsayılan veri ekleyerek bir grafik ekleyin.
4. [ChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/) nesnesine erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni veri ekleyin.
8. Değiştirilmiş sunumu PPTX dosyasına yazın

Bu PHP kodu, bir ağaç haritası grafik oluşturmayı gösterir:

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

### **Hisse Senedi Grafikleri Oluşturma**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Adımlar:</em> Hisse Senedi Grafik Oluştur </strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Adımlar:</em> PowerPoint Hisse Senedi Grafik Oluştur </strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Adımlar:</em> PowerPoint Sunum Hisse Senedi Grafik Oluştur </strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slaydın referansını indeks üzerinden alın.
3. İstenen tür ([ChartType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ChartType).OpenHighLowClose) ile varsayılan veri ekleyerek bir grafik ekleyin.
4. [ChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/) nesnesine erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni veri ekleyin.
8. HiLowLines biçimini belirleyin.
9. Değiştirilmiş sunumu PPTX dosyasına yazın

Bir hisse senedi grafik oluşturmak için kullanılan örnek PHP kodu:

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
    foreach($chart->getChartData()->getSeries() as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Kutu ve Bıyık Grafikleri Oluşturma**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Adımlar:</em> Kutu ve Bıyık Grafik Oluştur </strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Adımlar:</em> PowerPoint Kutu ve Bıyık Grafik Oluştur </strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Adımlar:</em> PowerPoint Sunum Kutu ve Bıyık Grafik Oluştur </strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slaydın referansını indeks üzerinden alın.
3. İstenen tür ([ChartType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ChartType).BoxAndWhisker) ile varsayılan veri ekleyerek bir grafik ekleyin.
4. [ChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/) nesnesine erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni veri ekleyin.
8. Değiştirilmiş sunumu PPTX dosyasına yazın

Bu PHP kodu, bir kutu ve bıyık grafik oluşturmayı gösterir:

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

### **Huni Grafikleri Oluşturma**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Adımlar:</em> Huni Grafik Oluştur </strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Adımlar:</em> PowerPoint Huni Grafik Oluştur </strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Adımlar:</em> PowerPoint Sunum Huni Grafik Oluştur </strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slaydın referansını indeks üzerinden alın.
3. İstenen tür ([ChartType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ChartType).Funnel) ile varsayılan veri ekleyerek bir grafik ekleyin.
4. Değiştirilmiş sunumu PPTX dosyasına yazın

PHP kodu, bir huni grafik oluşturmayı gösterir:

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

### **Güneş Patlaması Grafikleri Oluşturma**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Adımlar:</em> Güneş Patlaması Grafik Oluştur </strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Adımlar:</em> PowerPoint Güneş Patlaması Grafik Oluştur </strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Adımlar:</em> PowerPoint Sunum Güneş Patlaması Grafik Oluştur </strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slaydın referansını indeks üzerinden alın.
3. İstenen tür (bu durumda [ChartType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ChartType).sunburst) ile varsayılan veri ekleyerek bir grafik ekleyin.
4. Değiştirilmiş sunumu PPTX dosyasına yazın

Bu PHP kodu, bir güneş patlaması grafik oluşturmayı gösterir:

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

### **Histogram Grafikleri Oluşturma**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Adımlar:</em> Histogram Grafik Oluştur </strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Adımlar:</em> PowerPoint Histogram Grafik Oluştur </strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Adımlar:</em> PowerPoint Sunum Histogram Grafik Oluştur </strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slaydın referansını indeks üzerinden alın.
3. İstenen tür ([ChartType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ChartType).Histogram) ile varsayılan veri ekleyerek bir grafik ekleyin.
4. [ChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/) nesnesine erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Değiştirilmiş sunumu PPTX dosyasına yazın

Bu PHP kodu, bir histogram grafik oluşturmayı gösterir:

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

### **Radar Grafikleri Oluşturma**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Adımlar:</em> Radar Grafik Oluştur </strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Adımlar:</em> PowerPoint Radar Grafik Oluştur </strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Adımlar:</em> PowerPoint Sunum Radar Grafik Oluştur </strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slaydın referansını indeks üzerinden alın. 
3. Bir grafik ekleyin ve tercih ettiğiniz grafik türünü (`ChartType::Radar`) belirtin.
4. Değiştirilmiş sunumu PPTX dosyasına yazın

Bu PHP kodu, bir radar grafik oluşturmayı gösterir:

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

### **Çok Kategori Grafikler Oluşturma**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Adımlar:</em> Çok Kategori Grafik Oluştur </strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Adımlar:</em> PowerPoint Çok Kategori Grafik Oluştur </strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Adımlar:</em> PowerPoint Sunum Çok Kategori Grafik Oluştur </strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slaydın referansını indeks üzerinden alın. 
3. İstenen tür ([ChartType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ChartType).ClusteredColumn) ile varsayılan veri ekleyerek bir grafik ekleyin.
4. [ChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/) nesnesine erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni veri ekleyin.
8. Değiştirilmiş sunumu PPTX dosyasına yazın.

Bu PHP kodu, bir çok kategori grafik oluşturmayı gösterir:

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

### **Harita Grafikler Oluşturma**

Harita grafiği, veri içeren bir alanın görselleştirilmesidir. Harita grafikler, coğrafi bölgeler arasında veri veya değerleri karşılaştırmak için en uygunudur.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Adımlar:</em> Harita Grafik Oluştur </strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Adımlar:</em> PowerPoint Harita Grafik Oluştur </strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Adımlar:</em> PowerPoint Sunum Harita Grafik Oluştur </strong></a>

Bu PHP kodu, bir harita grafik oluşturmayı gösterir:

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

### **Kombinasyon Grafikler Oluşturma**

Kombinasyon grafiği (veya combo grafiği), tek bir grafikte iki veya daha fazla grafik türünü birleştirir. Bu grafik, iki ya da daha fazla veri kümesi arasındaki farkları vurgulamanıza, karşılaştırmanıza veya incelemenize olanak tanır ve bunlar arasındaki ilişkileri tanımlamanıza yardımcı olur.

![The combination chart](combination_chart.png)

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

    // Grafiğin başlığını ayarla.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // Grafiğin lejandını ayarla.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // Varsayılan oluşturulan serileri ve kategorileri sil.
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // Yeni kategoriler ekle.
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // İlk seriyi ekle.
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
    // Yatay ekseni ayarla.
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // Dikey ekseni ayarla.
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // Dikey ana ızgara çizgileri rengini ayarla.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // İkincil yatay ekseni ayarla.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // İkincil dikey ekseni ayarla.
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

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Adımlar:</em> PowerPoint Grafiğini Güncelle </strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Adımlar:</em> Sunum Grafiğini Güncelle </strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Adımlar:</em> PowerPoint Sunum Grafiğini Güncelle </strong></a>

1. Güncellemek istediğiniz grafiği içeren sunumu temsil eden bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfı örneği oluşturun.
2. Index kullanarak bir slaydın referansını alın.
3. Tüm şekilleri dolaşarak istenen grafiği bulun.
4. Grafik veri çalışma sayfasına erişin.
5. Seri değerlerini değiştirerek grafik veri serisini düzenleyin.
6. Yeni bir seri ekleyin ve verileri doldurun.
7. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Bu PHP kodu, bir grafiği nasıl güncelleyeceğinizi gösterir:

```php
  $pres = new Presentation();
  try {
    # İlk slayt işaretçisine eriş
    $sld = $pres->getSlides()->get_Item(0);
    # Varsayılan verilerle grafiği al
    $chart = $sld->getShapes()->get_Item(0);
    # Grafik veri sayfasının indeksini ayarlama
    $defaultWorksheetIndex = 0;
    # Grafik veri çalışma sayfasını alıyor
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Grafik kategori adını değiştir
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # İlk grafik serisini al
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Şimdi seri verilerini güncelliyor
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// Seri adını değiştiriyor

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # İkinci grafik serisini al
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Şimdi seri verilerini güncelliyor
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// Seri adını değiştiriyor

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # Şimdi yeni bir seri ekliyor
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # Üçüncü grafik serisini al
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # Şimdi seri verilerini dolduruyor
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

## **Bir Grafik için Veri Aralığını Ayarlama**

Bir grafik için veri aralığını ayarlamak için şu adımları izleyin:

1. Grafiği içeren bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfı örneği oluşturun.
2. Bir slaydın referansını indeks üzerinden alın.
3. Tüm şekilleri dolaşarak istenen grafiği bulun.
4. Grafik verisine erişin ve aralığı ayarlayın.
5. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu PHP kodu, bir grafik için veri aralığını nasıl ayarlayacağınızı gösterir:

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
Grafiklerde varsayılan bir işaretçi kullandığınızda, her grafik serisi otomatik olarak farklı varsayılan işaretçi sembolleri alır.

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
    # Şimdi seri verileri dolduruluyor
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

**Aspose.Slides hangi grafik türlerini destekliyor?**

Aspose.Slides, çubuk, çizgi, pasta, alan, dağılım, histogram, radar ve daha birçok [grafik türü](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/) destekler. Bu esneklik, veri görselleştirme ihtiyaçlarınıza en uygun grafik türünü seçmenizi sağlar.

**Bir slayta yeni bir grafik nasıl eklenir?**

Yeni bir grafik eklemek için önce bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı örneği oluşturur, indeksini kullanarak istenen slaytı alır ve ardından grafik türü ve başlangıç verilerini belirterek grafiği ekleme yöntemini çağırırsınız. Bu işlem, grafiği doğrudan sunumunuza entegre eder.

**Grafikte gösterilen veriler nasıl güncellenir?**

Grafiğin verilerini, veri çalışma kitabına ([ChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/)) erişerek, varsayılan serileri ve kategorileri temizleyip kendi özel verilerinizi ekleyerek güncelleyebilirsiniz. Bu sayede grafik, en son verilere göre yenilenir.

**Grafiğin görünümü özelleştirilebilir mi?**

Evet, Aspose.Slides kapsamlı özelleştirme seçenekleri sunar. Renkleri, yazı tiplerini, etiketleri, lejandları ve diğer [biçimlendirme öğelerini](/slides/tr/php-java/chart-entities/) projenizin belirli tasarım gereksinimlerine göre değiştirebilirsiniz.