---
title: PHP'de PPT ve PPTX'i JPG'ye Dönüştür
linktitle: PowerPoint'ten JPG'ye
type: docs
weight: 60
url: /tr/php-java/convert-powerpoint-to-jpg/
keywords:
- PowerPoint'i dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPTX'i dönüştür
- PowerPoint'ten JPG'ye
- sunumu JPG'ye
- slaytı JPG'ye
- PPT'den JPG'ye
- PPTX'ten JPG'ye
- PowerPoint'i JPG olarak kaydet
- sunumu JPG olarak kaydet
- slaytı JPG olarak kaydet
- PPT'yi JPG olarak kaydet
- PPTX'i JPG olarak kaydet
- PPT'yi JPG'ye aktar
- PPTX'i JPG'ye aktar
- PHP
- Aspose.Slides
description: "PHP'de Aspose.Slides for PHP kullanarak hızlı ve güvenilir kod örnekleriyle PowerPoint (PPT, PPTX) slaytlarını yüksek kaliteli JPG görüntülerine dönüştürün."
---
## **Giriş**

PowerPoint ve OpenDocument sunumlarını JPG görüntülere dönüştürmek, slaytları paylaşmayı, performansı optimize etmeyi ve içerikleri web sitelerine veya uygulamalara gömmeyi kolaylaştırır. Aspose.Slides, PPTX, PPT ve ODP dosyalarını yüksek kaliteli JPEG görüntülere dönüştürmenizi sağlar. Bu kılavuz dönüşüm için farklı yöntemleri açıklar.

Bu özelliklerle, kendi sunum görüntüleyicinizi uygulamak ve her slayt için bir küçük resim oluşturmak kolaydır. Bu, sunum slaytlarını kopyalamaya karşı korumak veya sunumu yalnızca okunabilir modda göstermek istediğinizde faydalı olabilir. Aspose.Slides, tüm sunumu veya belirli bir slaytı görüntü formatlarına dönüştürmenize olanak tanır.

## **PowerPoint PPT/PPTX'yi JPG'ye Dönüştür**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) tipinin örneğini oluşturun.  
2. [Presentation::getSlides()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation#getSlides--) koleksiyonundan [Slide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/) tipinin slayt nesnesini alın.  
3. Her slaytın küçük resmini oluşturun ve ardından JPG'ye dönüştürün. [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#getImage) yöntemi bir slaytın küçük resmini almak için kullanılır. [getImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#getImage) yöntemi, gereken [Slide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/) tipinin slaytından çağrılmalı, ortaya çıkan küçük resmin ölçekleri metoda geçirilir.  
4. Slayt küçük resmini aldıktan sonra, küçük resim nesnesinden [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) metodunu çağırın. Oluşan dosya adını ve görüntü formatını ona aktarın.  

{{% alert color="primary" %}}
**Not**: PPT/PPTX'yi JPG'ye dönüştürme, Aspose.Slides API'sindeki diğer türlere dönüştürmeden farklıdır. Diğer türler için genellikle [**Presentation::Save(String fname, int format, SaveOptions options)**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/save/) metodunu kullanırsınız, ancak burada [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) metoduna ihtiyacınız vardır.  
{{% /alert %}} 

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # Tam ölçekli bir görüntü oluşturur
      $slideImage = $sld->getImage(1.0, 1.0);
      # Görüntüyü JPEG formatında diske kaydeder
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
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

## **PowerPoint PPT/PPTX'yi Özelleştirilmiş Boyutlarla JPG'ye Dönüştür**

Ortaya çıkan küçük resim ve JPG görüntüsünün boyutunu değiştirmek için, *ScaleX* ve *ScaleY* değerlerini [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#getImage) metoduna geçirerek ayarlayabilirsiniz:  

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # Boyutları tanımlar
    $desiredX = 1200;
    $desiredY = 800;
    # X ve Y'nin ölçekli değerlerini alır
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # Tam ölçekli bir görüntü oluşturur
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # Görüntüyü JPEG formatında diske kaydeder
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
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

## **Slaytları Görüntü Olarak Kaydederken Yorumları İşleme Al**

Aspose.Slides for PHP via Java, slaytları görüntülere dönüştürürken sunum slaytlarındaki yorumları işleme almanızı sağlayan bir özellik sunar. Bu PHP kodu işlemi göstermektedir:  

```php
  $pres = new Presentation("presentation.pptx");
  try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomTruncated);
    $opts = new RenderingOptions();
    $opts->setSlidesLayoutOptions($notesOptions);
    foreach($pres->getSlides() as $sld) {
      $slideImage = $sld->getImage($opts, new Java("java.awt.Dimension", 740, 960));
      try {
        $slideImage->save(String->format("Slide_%d.png", $sld->getSlideNumber()));
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

{{% alert title="Tip" color="primary" %}}
Aspose, bir [ÜCRETSİZ Collage web uygulaması](https://products.aspose.app/slides/tr/collage) sağlar. Bu çevrimiçi hizmeti kullanarak [JPG to JPG](https://products.aspose.app/slides/tr/collage/jpg) veya PNG to PNG görüntülerini birleştirebilir, [fotoğraf ızgaraları](https://products.aspose.app/slides/tr/collage/photo-grid) oluşturabilir ve benzeri işlemler yapabilirsiniz.  

Bu makalede açıklanan aynı prensipleri kullanarak, görüntüleri bir formattan diğerine dönüştürebilirsiniz. Daha fazla bilgi için şu sayfalara bakın: dönüştür [image to JPG](https://products.aspose.com/slides/tr/php-java/conversion/image-to-jpg/); dönüştür [JPG to image](https://products.aspose.com/slides/tr/php-java/conversion/jpg-to-image/); dönüştür [JPG to PNG](https://products.aspose.com/slides/tr/php-java/conversion/jpg-to-png/), dönüştür [PNG to JPG](https://products.aspose.com/slides/tr/php-java/conversion/png-to-jpg/); dönüştür [PNG to SVG](https://products.aspose.com/slides/tr/php-java/conversion/png-to-svg/), dönüştür [SVG to PNG](https://products.aspose.com/slides/tr/php-java/conversion/svg-to-png/).  
{{% /alert %}}

## **SSS**

**Bu yöntem toplu dönüşüm destekliyor mu?**  
Evet, Aspose.Slides bir tek işlemde birden fazla slaytı JPG'ye toplu olarak dönüştürmeye olanak tanır.

**Dönüşüm SmartArt, grafikler ve diğer karmaşık nesneleri destekliyor mu?**  
Evet, Aspose.Slides SmartArt, grafikler, tablolar, şekiller ve daha fazlası dahil olmak üzere tüm içeriği işler. Ancak, özellikle özel veya eksik yazı tipleri kullanıldığında, işleme doğruluğu PowerPoint'e göre biraz değişebilir.

**İşlenebilecek slayt sayısı üzerinde herhangi bir sınırlama var mı?**  
Aspose.Slides, işleyebileceğiniz slayt sayısı üzerinde katı bir sınırlama getirmez. Ancak, büyük sunumlarla veya yüksek çözünürlüklü görüntülerle çalışırken bellek dışı hatası alabilirsiniz.

## **İlgili Bağlantılar**

PPT/PPTX'i görüntüye dönüştürmek için diğer seçeneklere bakın:

- [PPT/PPTX'den SVG dönüşümü](/slides/tr/php-java/render-a-slide-as-an-svg-image/).