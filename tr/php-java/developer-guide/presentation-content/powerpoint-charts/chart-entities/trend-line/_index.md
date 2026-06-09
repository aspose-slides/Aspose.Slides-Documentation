---
title: PHP'de Sunum Grafiklerine Trend Çizgileri Ekle
linktitle: Trend Çizgisi
type: docs
url: /tr/php-java/trend-line/
keywords:
- grafik
- trend çizgisi
- üstel trend çizgisi
- doğrusal trend çizgisi
- logaritmik trend çizgisi
- hareketli ortalama trend çizgisi
- polinom trend çizgisi
- güç trend çizgisi
- özel trend çizgisi
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint grafiklerine trend çizgilerini hızlı bir şekilde ekleyin ve özelleştirin — izleyicilerinizi etkilemek için pratik bir rehber."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerine trend çizgileri eklemeyi açıklar. Bir grafik oluşturmayı, grafik serilerine trend çizgileri eklemeyi ve üstel, doğrusal, logaritmik, hareketli ortalama, polinom ve güç gibi çeşitli trend çizgisi türleriyle çalışmayı gösterir.

Ayrıca, bir çizgi şekli ekleyerek grafik üzerine özel bir çizgi ekleme yöntemini açıklar ve ileri ve geri trend çizgisi projeksiyon değerleri ile trend çizgilerinin PDF veya SVG'ye dışa aktarım sırasında ve grafiklerin görüntülere dönüştürülmesi sırasında korunup korunmadığına dair kısa bir SSS içerir.

## **Trend Çizgisi Ekle**

Aspose.Slides for PHP via Java, farklı grafik Trend Çizgilerini yönetmek için basit bir API sağlar:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. Slaytın referansını indeksine göre alın.
1. İstediğiniz türde (bu örnek ChartType::ClusteredColumn kullanır) varsayılan verilerle bir grafik ekleyin.
1. Grafik serisi 1 için üstel trend çizgisi ekleyin.
1. Grafik serisi 1 için doğrusal trend çizgisi ekleyin.
1. Grafik serisi 2 için logaritmik trend çizgisi ekleyin.
1. Grafik serisi 2 için hareketli ortalama trend çizgisi ekleyin.
1. Grafik serisi 3 için polinom trend çizgisi ekleyin.
1. Grafik serisi 3 için güç trend çizgisi ekleyin.
1. Değiştirilmiş sunumu bir PPTX dosyasına kaydedin.

Aşağıdaki kod, Trend Çizgileriyle bir grafik oluşturmak için kullanılır.

```php
  # Presentation sınıfının bir örneğini oluştur
  $pres = new Presentation();
  try {
    # Kümeleme sütun grafiği oluşturma
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # Grafik serisi 1 için üstel trend çizgisi ekleme
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # Grafik serisi 1 için doğrusal trend çizgisi ekleme
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Grafik serisi 2 için logaritmik trend çizgisi ekleme
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("New log trend line");
    # Grafik serisi 2 için hareketli ortalama trend çizgisi ekleme
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("New TrendLine Name");
    # Grafik serisi 3 için polinom trend çizgisi ekleme
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # Grafik serisi 3 için güç trend çizgisi ekleme
    $tredLinePower = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Power);
    $tredLinePower->setTrendlineType(TrendlineType::Power);
    $tredLinePower->setBackward(1);
    # Sunumu kaydetme
    $pres->save("ChartTrendLines_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Özel Çizgi Ekle**

Aspose.Slides for PHP via Java, bir grafiğe özel çizgiler eklemek için basit bir API sağlar. Sunumun seçili slaytına basit bir düz çizgi eklemek için aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun.
- Slaytın referansını Index kullanarak alın.
- Shapes nesnesinin sunduğu AddChart yöntemiyle yeni bir grafik oluşturun.
- Shapes nesnesinin sunduğu AddAutoShape yöntemiyle Çizgi tipinde bir AutoShape ekleyin.
- Şekil çizgilerinin rengini ayarlayın.
- Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Aşağıdaki kod, Özel Çizgilerle bir grafik oluşturmak için kullanılır.

```php
  # Presentation sınıfının bir örneğini oluştur
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $shape = $chart->getUserShapes()->getShapes()->addAutoShape(ShapeType::Line, 0, $chart->getHeight() / 2, $chart->getWidth(), 0);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("Presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Trend çizgisi için 'ileri' ve 'geri' ne anlama geliyor?**

Bunlar, trend çizgisinin ileri/geri yönüne doğru projekte edilen uzunluklarıdır: dağılım (XY) grafiklerinde eksen birimlerinde; dağılım olmayan grafiklerde kategori sayısı olarak ölçülür. Sadece negatif olmayan değerler kabul edilir.

**Sunum PDF veya SVG olarak dışa aktarıldığında veya bir slayt görüntüye dönüştürüldüğünde trend çizgisi korunur mu?**

Evet. Aspose.Slides sunumları [PDF](/slides/tr/php-java/convert-powerpoint-to-pdf/)/[SVG](/slides/tr/php-java/render-a-slide-as-an-svg-image/) formatına dönüştürür ve grafikleri görüntülere render eder; trend çizgileri, grafiğin bir parçası olarak bu işlemler sırasında korunur. Ayrıca grafiğin kendisinin bir görüntüsünü [dışa aktarmak](/slides/tr/php-java/create-shape-thumbnails/) için bir yöntem de mevcuttur.