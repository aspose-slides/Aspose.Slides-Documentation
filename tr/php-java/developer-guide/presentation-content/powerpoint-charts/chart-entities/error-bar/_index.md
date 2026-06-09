---
title: "PHP Kullanarak Sunum Grafiklerinde Hata Çubuklarını Özelleştirme"
linktitle: "Hata Çubuğu"
type: docs
url: /tr/php-java/error-bar/
keywords:
  - "hata çubuğu"
  - "özel değer"
  - "PowerPoint"
  - "sunum"
  - "PHP"
  - "Aspose.Slides"
description: "Aspose.Slides for PHP via Java ile grafiklere hata çubukları eklemeyi ve özelleştirmeyi öğrenin — PowerPoint sunumlarında veri görselleştirmesini optimize edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerinde hata çubuklarıyla nasıl çalışılacağını açıklar. Bir grafik serisine hata çubukları eklemeyi, X ve Y hata çubuğu ayarlarını yapılandırmayı ve sabit, yüzde ve özel değerler gibi farklı değer türlerini uygulamayı gösterir. Ayrıca, ilgili veri noktası koleksiyonunu kullanarak bir serideki bireysel veri noktalarına özel hata çubuğu değerleri atamanın nasıl yapılacağını da gösterir. Buna ek olarak, makalede hata çubuklarının dışa aktarım sırasında nasıl davrandığına, işaretçiler ve veri etiketleriyle uyumluluğuna ve ilgili API referans sınıfları ve enum'larının nerede bulunacağına dair kısa notlar yer alır.

## **Hata Çubukları Ekle**
Aspose.Slides for PHP via Java, hata çubuğu değerlerini yönetmek için basit bir API sağlar. Örnek kod, özel bir değer türü kullanıldığında geçerlidir. Bir değeri belirtmek için, serinin [**veri noktaları**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseriescollection/) koleksiyonundaki belirli bir veri noktasının **ErrorBarCustomValues** özelliğini kullanın:

1. Serinin [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. İstediğiniz slayta bir balon grafik ekleyin.
3. İlk grafik serisine erişin ve hata çubuğu X biçimini ayarlayın.
4. İlk grafik serisine erişin ve hata çubuğu Y biçimini ayarlayın.
5. Çubuk değerlerini ve biçimini ayarlama.
6. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```php
  # Presentation sınıfının bir örneğini oluştur
  $pres = new Presentation();
  try {
    # Bir balon grafik oluşturma
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Hata çubuklarını ekleme ve biçimini ayarlama
    $errBarX = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsXFormat();
    $errBarY = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Fixed);
    $errBarX->setValue(0.1);
    $errBarY->setValueType(ErrorBarValueType::Percentage);
    $errBarY->setValue(5);
    $errBarX->setType(ErrorBarType::Plus);
    $errBarY->getFormat()->getLine()->setWidth(2.0);
    $errBarX->hasEndCap();
    # Sunumu kaydetme
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Özel Hata Çubuğu Değerleri Ekle**
Aspose.Slides for PHP via Java, özel hata çubuğu değerlerini yönetmek için basit bir API sağlar. Örnek kod, [**ErrorBarsFormat::getValueType**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/errorbarsformat/#getValueType) yöntemi **Custom** döndürdüğünde uygulanır. Bir değeri belirtmek için, serinin [**veri noktaları**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseriescollection/) koleksiyonundaki belirli bir veri noktasının **ErrorBarCustomValues** özelliğini kullanın:

1. Serinin [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. İstediğiniz slayta bir balon grafik ekleyin.
3. İlk grafik serisine erişin ve hata çubuğu X biçimini ayarlayın.
4. İlk grafik serisine erişin ve hata çubuğu Y biçimini ayarlayın.
5. Grafik serisinin bireysel veri noktalarına erişin ve her bir seri veri noktası için Error Bar değerlerini ayarlayın.
6. Çubuk değerlerini ve biçimini ayarlama.
7. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```php
  # Presentation sınıfının bir örneğini oluştur
  $pres = new Presentation();
  try {
    # Bir balon grafik oluşturma
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Özel Hata çubuklarını ekleme ve biçimini ayarlama
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # Grafik serisi veri noktasına erişme ve hata çubuğu değerlerini ayarlama
    # bireysel nokta için
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # Grafik serisi noktaları için hata çubuklarını ayarlama
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # Sunumu kaydetme
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Sunum PDF ya da görüntülere dışa aktarıldığında hata çubuklarıyla ne olur?**

Grafiğin bir parçası olarak işlenir ve uyumlu bir sürüm veya renderleyici varsayıldığında, dönüşüm sırasında diğer grafik biçimlendirmeleriyle birlikte korunur.

**Hata çubukları işaretçiler ve veri etiketleriyle birleştirilebilir mi?**

Evet. Hata çubukları ayrı bir öğedir ve işaretçiler ve veri etiketleriyle uyumludur; öğeler üst üste gelirse, biçimlendirmeyi ayarlamanız gerekebilir.

**API'de hata çubuklarıyla çalışmak için özellik ve sınıf listesini nerede bulabilirim?**

API referansında: [ErrorBarsFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/errorbarsformat/) sınıfı ve ilgili sınıflar [ErrorBarType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/errorbartype/) ve [ErrorBarValueType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/errorbarvaluetype/).