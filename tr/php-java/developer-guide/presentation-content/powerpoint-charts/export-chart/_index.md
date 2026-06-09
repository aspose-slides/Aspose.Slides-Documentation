---
title: Sunum Grafiklerini PHP ile Dışa Aktarma
linktitle: Grafik Dışa Aktar
type: docs
weight: 90
url: /tr/php-java/export-chart/
keywords:
- grafik
- grafiği görüntüye
- grafik görüntüsü olarak
- grafik görüntüsü çıkarma
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak sunum grafiklerini dışa aktarmayı öğrenin, PPT ve PPTX formatlarını destekler ve raporlamayı herhangi bir iş akışına sorunsuz entegre eder."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdan grafiği görüntü olarak dışa aktarmanızı sağlar. Bu makale, bir grafikten görüntü alıp kaydetmenin nasıl yapılacağını gösterir; bu, grafik görsellerini PowerPoint dışındaki yerlerde yeniden kullanmanız gerektiğinde faydalıdır.

## **Grafik Görüntüsü Al**
Aspose.Slides for PHP via Java, belirli bir grafiğin görüntüsünü çıkarmayı destekler. Aşağıda örnek bir kod verilmiştir.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Bir grafiği raster görüntü yerine vektör (SVG) olarak dışa aktarabilir miyim?**

Evet. Bir grafik bir şekildir ve içeriği, [shape-to-SVG kaydetme yöntemi](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/writeassvg/) kullanılarak SVG olarak kaydedilebilir.

**Dışa aktarılan grafiğin piksel cinsinden tam boyutunu nasıl ayarlayabilirim?**

Boyut veya ölçeği belirlemenizi sağlayan image-rendering aşırı yüklemelerini kullanın—kütüphane, verilen boyut/ölçekle nesneleri renderlemeyi destekler.

**Etiketlerde ve lejendeki yazı tipleri dışa aktardıktan sonra yanlış görünüyorsa ne yapmalıyım?**

Grafik renderı metrikleri ve metin görünümünü koruması için gerekli yazı tiplerini [Gerekli yazı tiplerini yükleyin](/slides/tr/php-java/custom-font/) üzerinden [FontsLoader](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsloader/) kullanın.

**Dışa aktarma, PowerPoint teması, stilleri ve efektleri korur mu?**

Evet. Aspose.Slides render'ı sunumun biçimlendirmesini (temalar, stiller, doldurmalar, efektler) izler, böylece grafiğin görünümü korunur.

**Grafik görüntülerinin ötesinde mevcut renderleme/dışa aktarma yeteneklerini nerede bulabilirim?**

Çıktı hedefleri ([PDF](/slides/tr/php-java/convert-powerpoint-to-pdf/), [SVG](/slides/tr/php-java/render-a-slide-as-an-svg-image/), [XPS](/slides/tr/php-java/convert-powerpoint-to-xps/), [HTML](/slides/tr/php-java/convert-powerpoint-to-html/), vb.) ve ilgili renderleme seçenekleri için [API](https://reference.aspose.com/slides/tr/php-java/aspose.slides/)/[dökümantasyon](/slides/tr/php-java/convert-powerpoint/) bakın.