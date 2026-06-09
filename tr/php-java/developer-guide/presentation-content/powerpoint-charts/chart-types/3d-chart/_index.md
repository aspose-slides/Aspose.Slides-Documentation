---
title: Sunumlarda PHP Kullanarak 3D Grafikler Özelleştirme
linktitle: 3D Grafik
type: docs
url: /tr/php-java/3d-chart/
keywords:
- 3D grafik
- dönüş
- derinlik
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'da 3‑B boyutlu grafikler oluşturmayı ve özelleştirmeyi öğrenin, PPT ve PPTX dosyalarını destekler — sunumlarınızı bugün geliştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde `Rotation3D` ayarlarını `RotationX`, `RotationY`, `DepthPercents` ve `RightAngleAxes` gibi yapılandırarak 3D grafiği nasıl özelleştireceğinizi açıklar. Bir sunum oluşturma, varsayılan veri ile bir 3D grafik ekleme, gerekli 3D görünüm ayarlarını uygulama ve değiştirilen sunumu PPTX dosyası olarak kaydetme adımlarını içerir.

## **3D Grafiğin RotationX, RotationY ve DepthPercents Özelliklerini Ayarlama**
Aspose.Slides for PHP via Java, bu özellikleri ayarlamak için basit bir API sağlar. Aşağıdaki makale, **X,Y Rotation, DepthPercents** gibi farklı özellikleri nasıl ayarlayacağınızı gösterir. Örnek kod, yukarıda belirtilen özelliklerin ayarlanmasını uygular.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İlk slayta erişin.
1. Varsayılan veri ile grafik ekleyin.
1. Rotation3D özelliklerini ayarlayın.
1. Değiştirilen sunumu bir PPTX dosyasına yazın.

```php
  $pres = new Presentation();
  try {
    # İlk slayta eriş
    $slide = $pres->getSlides()->get_Item(0);
    # Varsayılan veri ile grafik ekle
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);
    # Grafik veri sayfasının dizinini ayarlama
    $defaultWorksheetIndex = 0;
    # Grafik veri çalışma sayfasını alma
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Seri ekle
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Kategorileri ekle
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Rotation3D özelliklerini ayarla
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);
    # İkinci grafik serisini al
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Şimdi seri verilerini dolduruyoruz
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Overlap değerini ayarla
    $series->getParentSeriesGroup()->setOverlap(100);
    # Sunumu diske kaydet
    $pres->save("Rotation3D_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Aspose.Slides içinde hangi grafik türleri 3D modunu destekler?**

Aspose.Slides, Column 3D, Clustered Column 3D, Stacked Column 3D ve %100 Stacked Column 3D dahil olmak üzere sütun grafiklerinin 3D varyantlarını ve [ChartType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/) sınıfı aracılığıyla sunulan ilgili 3D türlerini destekler. Kesin ve güncel bir liste için, kurulu sürümünüzün API referansındaki [ChartType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/) üyelerine bakın.

**Bir rapor veya web için 3D grafiğin raster görüntüsünü alabilir miyim?**

Evet. Grafiği, [chart API](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getImage) aracılığıyla bir görüntüye dışa aktarabilir veya [render the entire slide](/slides/tr/php-java/convert-powerpoint-to-png/) ile PNG veya JPEG gibi formatlarda dışa aktarabilirsiniz. Bu, pikselli mükemmel bir önizleme gerektiğinde veya PowerPoint gerektirmeden grafiği belgeler, gösterge panelleri veya web sayfalarına yerleştirmek istediğinizde faydalıdır.

**Büyük 3D grafikler oluşturma ve render etme performansı nasıldır?**

Performans, veri hacmi ve görsel karmaşıklığa bağlıdır. En iyi sonuçlar için 3D efektlerini minimumda tutun, duvar ve grafik alanlarında ağır dokulardan kaçının, mümkün olduğunda seri başına veri noktası sayısını sınırlayın ve hedef görüntüleme veya baskı ihtiyaçlarına uygun çözünürlük ve boyutlarda bir çıktı oluşturun.