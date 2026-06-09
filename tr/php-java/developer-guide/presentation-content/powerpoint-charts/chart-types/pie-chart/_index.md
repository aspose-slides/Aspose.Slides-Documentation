---
title: PHP Kullanarak Sunumlarda Pasta Grafiklerini Özelleştirme
linktitle: Pasta Grafiği
type: docs
url: /tr/php-java/pie-chart/
keywords:
- pasta grafiği
- grafik yönetimi
- grafik özelleştirme
- grafik seçenekleri
- grafik ayarları
- çizim seçenekleri
- dilim rengi
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile pasta grafiklerini nasıl oluşturup özelleştireceğinizi, PowerPoint'e aktarılabilir şekilde öğrenin ve saniyeler içinde veri hikâye anlatımınızı güçlendirin."
---
## **Genel Bakış**

Bu makale Aspose.Slides'te pasta grafikleri ile nasıl çalışılacağını açıklar. Pie of Pie ve Bar of Pie grafikleri için ikinci grafik seçeneklerini nasıl yapılandıracağınızı ve standart bir pasta grafiği için otomatik dilim renklemeyi nasıl etkinleştireceğinizi gösterir.

Örnekler, bir slayta grafik ekleme, seri ve etiket ayarlarını düzenleme, varsayılan grafik verilerini özel kategoriler ve değerlerle değiştirme ve güncellenen sunumu kaydetme gibi pratik grafik özelleştirme adımlarına odaklanır.

## **Pie of Pie ve Bar of Pie Grafikleri için İkinci Grafik Seçenekleri**
Aspose.Slides for PHP via Java artık Pie of Pie veya Bar of Pie grafiği için ikinci grafik seçeneklerini destekliyor. Bu konuda, bu seçenekleri Aspose.Slides kullanarak nasıl belirteceğinizi göstereceğiz. Özellikleri belirlemek için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfı nesnesi oluşturun.
1. Slayta bir grafik ekleyin.
1. Grafiğin ikinci grafik seçeneklerini belirtin.
1. Sunumu diske yazın.

Aşağıdaki örnekte, Pie of Pie grafiğinin çeşitli özelliklerini ayarladık.

```php
  # Presentation sınıfının bir örneğini oluştur
  $pres = new Presentation();
  try {
    # Slayta grafik ekle
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # Farklı özellikleri ayarla
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # Sunumu diske yaz
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Otomatik Pasta Grafik Dilim Renklerini Ayarlama**
Aspose.Slides for PHP via Java, otomatik pasta grafik dilim renklerini ayarlamak için basit bir API sağlar. Örnek kod, yukarıda belirtilen özelliklerin ayarlanmasını uygular.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İlk slayta erişin.
1. Varsayılan veriyle bir grafik ekleyin.
1. Grafik başlığını ayarlayın.
1. İlk seriyi Değerleri Göster olarak ayarlayın.
1. Grafik veri sayfasının indeksini ayarlayın.
1. Grafik veri çalışma sayfasını alıyor.
1. Varsayılan oluşturulan serileri ve kategorileri silin.
1. Yeni kategoriler ekleyin.
1. Yeni seriler ekleyin.

Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```php
  # Presentation sınıfının bir örneğini oluştur
  $pres = new Presentation();
  try {
    # Varsayılan veriyle grafik ekle
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Grafik başlığını ayarla
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # İlk seriyi Değerleri Göster olarak ayarla
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Grafik veri sayfasının indeksini ayarla
    $defaultWorksheetIndex = 0;
    # Grafik veri çalışma sayfasını al
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Varsayılan oluşturulan serileri ve kategorileri sil
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Yeni kategoriler ekle
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Yeni seriler ekle
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Şimdi seri verilerini doldur
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getParentSeriesGroup()->setColorVaried(true);
    $pres->save("Pie.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**'Pie of Pie' ve 'Bar of Pie' varyasyonları destekleniyor mu?**

Evet, kütüphane [destekliyor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/) pie grafikler için ikinci bir grafik, 'Pie of Pie' ve 'Bar of Pie' türleri dahil.

**Grafiği yalnızca bir görüntü olarak (örneğin PNG) dışa aktarabilir miyim?**

Evet, [grafiği doğrudan bir görüntü olarak dışa aktarabilirsiniz](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getImage) (örneğin PNG) tüm sunumu dışarı almadan.