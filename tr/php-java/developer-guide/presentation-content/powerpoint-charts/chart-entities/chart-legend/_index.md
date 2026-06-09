---
title: PHP Kullanarak Sunumlarda Grafik Açıklamalarını Özelleştirme
linktitle: Grafik Açıklaması
type: docs
url: /tr/php-java/chart-legend/
keywords:
- grafik açıklaması
- açıklama konumu
- yazı tipi boyutu
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile grafik açıklamalarını özelleştirerek, PowerPoint sunumlarını özel açıklama biçimlendirmesiyle optimize edin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarındaki grafik açıklamalarını özelleştirmek için seçenekler sunar. Bu makale, bir açıklamanın konumunu ve boyutunu nasıl ayarlayacağınızı, tüm açıklama için yazı tipi boyutunu nasıl belirleyeceğinizi ve tek bir açıklama girişine nasıl biçimlendirme uygulayacağınızı gösterir.

Ayrıca SSS bölümünde, çizim alanının açıklamaya yer açması için örtüşme dışı modu kullanma, uzun açıklama etiketlerinin satır içi kaydırılmasına veya satır sonu karakteri kullanmasına izin verme ve açıklama biçimlendirmesinin, açık metin ve dolgu ayarları uygulanmadığında sunum temasından devralınmasını kapsayan birkaç ilgili davranışı ele alır.

## **Açıklama Konumlandırma**
Açıklama özelliklerini ayarlamak için aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Slaytın referansını alın.
- Slayta bir grafik ekleyin.
- Açıklama özelliklerini ayarlayın.
- Sunumu bir PPTX dosyası olarak yazın.

Aşağıda verilen örnekte, Grafik açıklamasının konumunu ve boyutunu ayarladık.

```php
  # Presentation sınıfının bir örneğini oluştur
  $pres = new Presentation();
  try {
    # Slaytın referansını al
    $slide = $pres->getSlides()->get_Item(0);
    # Slayta bir gruplanmış sütun grafiği ekle
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);
    # Açıklama Özelliklerini Ayarla
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    # Sunumu diske kaydet
    $pres->save("Legend_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Açıklamanın Yazı Tipi Boyutunu Ayarlama**
Aspose.Slides for PHP via Java, geliştiricilerin açıklama yazı tipi boyutunu ayarlamasına olanak tanır. Lütfen aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Varsayılan grafiği oluşturun.
- Yazı tipi boyutunu ayarlayın.
- Minimum eksen değerini ayarlayın.
- Maksimum eksen değerini ayarlayın.
- Sunumu diske yazın.

```php
  # Presentation sınıfının bir örneğini oluştur
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bireysel Açıklamanın Yazı Tipi Boyutunu Ayarlama**
Aspose.Slides for PHP via Java, geliştiricilerin bireysel açıklama girişlerinin yazı tipi boyutunu ayarlamasına olanak tanır. Lütfen aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Varsayılan grafiği oluşturun.
- Açıklama girişine erişin.
- Yazı tipi boyutunu ayarlayın.
- Minimum eksen değerini ayarlayın.
- Maksimum eksen değerini ayarlayın.
- Sunumu diske yazın.

```php
  # Presentation sınıfının bir örneğini oluştur
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $tf = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();
    $tf->getPortionFormat()->setFontBold(NullableBool::True);
    $tf->getPortionFormat()->setFontHeight(20);
    $tf->getPortionFormat()->setFontItalic(NullableBool::True);
    $tf->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $tf->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Grafiğin açıklamayı otomatik olarak yer ayıracak şekilde, üzerine bindirmek yerine etkinleştirebilir miyim?**

Evet. Örtüşme dışı modu ([setOverlay(false)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/legend/setoverlay/)) kullanın; bu durumda, çizim alanı açıklamaya yer açmak için küçülecektir.

**Birden çok satırdan oluşan açıklama etiketleri oluşturabilir miyim?**

Evet. Uzun etiketler, alan yetersiz olduğunda otomatik olarak kaydırılır; zorunlu satır sonları, serinin adındaki yeni satır karakterleriyle desteklenir.

**Açıklamanın sunum temasının renk şemasını izlemesini nasıl sağlarım?**

Açıklama veya metni için açık renkler/dolgular/yazı tipleri ayarlamayın. Böylece tema üzerinden devralınır ve tasarım değiştiğinde doğru şekilde güncellenir.