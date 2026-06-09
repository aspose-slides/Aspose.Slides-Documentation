---
title: "PowerPoint Slaytlarını PHP'de PNG'ye Dönüştür"
linktitle: "PowerPoint'ten PNG'ye"
type: docs
weight: 30
url: /tr/php-java/convert-powerpoint-to-png/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten PNG'ye
- sunumdan PNG'ye
- slayttan PNG'ye
- PPT'den PNG'ye
- PPTX'den PNG'ye
- PPT'yi PNG olarak kaydet
- PPTX'i PNG olarak kaydet
- PPT'yi PNG'ye dışa aktar
- PPTX'i PNG'ye dışa aktar
- PHP
- Aspose.Slides
description: "Java üzerinden PHP için Aspose.Slides ile PowerPoint sunumlarını hızlı bir şekilde yüksek kaliteli PNG görüntülerine dönüştürerek, kesin ve otomatik sonuçlar sağlar."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını PNG görüntülerine nasıl dönüştüreceğinizi açıklar. PPT, PPTX ve ODP gibi formatlarda sunum dosyalarını nasıl yükleyeceğinizi, slaytları görüntü olarak nasıl işleteceğinizi ve sonuçları PNG formatında nasıl kaydedeceğinizi gösterir.

Makale ayrıca, ölçek değerleri ayarlayarak veya istenen genişlik ve yüksekliği belirterek oluşturulan PNG görüntülerinin nasıl özelleştirileceğini de göstermektedir.

## **PowerPoint'i PNG'ye Dönüştür**

Bu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. [Slide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/) sınıfı altında [Presentation.getSlides()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getSlides) koleksiyonundan slayt nesnesini alın.
3. Her slayt için küçük resmi elde etmek üzere [Slide.getImage()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#getImage) metodunu kullanın.
4. Slayt küçük resmini PNG formatına kaydetmek için [IImage.save(String formatName, int imageFormat)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/#save) metodunu kullanın.

Bu PHP kodu, bir PowerPoint sunumunu PNG'ye nasıl dönüştüreceğinizi gösterir:

```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage();
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **PowerPoint'i Özel Boyutlarla PNG'ye Dönüştür**

Belirli bir ölçek etrafında PNG dosyaları elde etmek istiyorsanız, sonuç küçük resminin boyutlarını belirleyen `desiredX` ve `desiredY` değerlerini ayarlayabilirsiniz.

Bu kod, açıklanan işlemi gösterir:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $scaleX = 2.0;
    $scaleY = 2.0;
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($scaleX, $scaleY);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **PowerPoint'i Özel Boyutla PNG'ye Dönüştür**

Belirli bir boyutta PNG dosyaları elde etmek istiyorsanız, `ImageSize` için tercih ettiğiniz `width` ve `height` argümanlarını geçebilirsiniz.

Bu kod, görüntülerin boyutunu belirterek bir PowerPoint'i PNG'ye nasıl dönüştüreceğinizi gösterir:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $size = new Java("java.awt.Dimension", 960, 720);
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($size);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Yalnızca belirli bir şekli (ör. grafik veya resim) tüm slayt yerine nasıl dışa aktarabilirim?**

Aspose.Slides, [generating thumbnails for individual shapes](/slides/tr/php-java/create-shape-thumbnails/) özelliğini destekler; bir şekli PNG görüntüsü olarak işletebilirsiniz.

**Sunucuda paralel dönüştürme destekleniyor mu?**

Evet, ancak tek bir sunum örneğini iş parçacıkları arasında [don’t share](/slides/tr/php-java/multithreading/) paylaşmayın. Her iş parçacığı veya süreç için ayrı bir örnek kullanın.

**PNG'ye dışa aktarırken deneme sürümü sınırlamaları nelerdir?**

Değerlendirme modu, çıktı görüntülerine bir filigran ekler ve lisans uygulanana kadar [other restrictions](/slides/tr/php-java/licensing/) uygular.