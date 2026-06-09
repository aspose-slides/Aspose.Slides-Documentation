---
title: "PowerPoint Sunumlarını PHP'de Hareketli GIF'lere Dönüştürme"
linktitle: "PowerPoint'ten GIF'e"
type: docs
weight: 65
url: /tr/php-java/convert-powerpoint-to-animated-gif/
keywords:
- animasyonlu GIF
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten GIF'e
- sunumdan GIF'e
- slayttan GIF'e
- PPT'den GIF'e
- PPTX'ten GIF'e
- PPT'yi GIF olarak kaydet
- PPTX'i GIF olarak kaydet
- PPT'yi GIF olarak dışa aktar
- PPTX'i GIF olarak dışa aktar
- varsayılan ayarlar
- özel ayarlar
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint sunumlarını (PPT, PPTX) kolayca animasyonlu GIF'lere dönüştürün. Hızlı, yüksek kaliteli sonuçlar."
---
## **Genel Bakış**

Aspose.Slides, yalnızca birkaç satır kodla PowerPoint sunumlarını hareketli GIF dosyalarına dönüştürmenizi sağlar. Bu, kaydırak içeriğini hafif, geniş çapta desteklenen bir hareketli formatta paylaşıp web sayfalarına, mesajlaşma uygulamalarına veya belgelere yerleştirmeniz gerektiğinde faydalıdır. Bu makale, bir sunumu varsayılan ayarlarla GIF olarak dışa aktarmayı ve çerçeve boyutu, slayt gecikmesi ve geçiş kare hızı gibi seçenekleri [GifOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/gifoptions/) aracılığıyla yapılandırarak çıktıyı özelleştirmeyi açıklar.

## **Varsayılan Ayarları Kullanarak Sunumları Hareketli GIF'e Dönüştürme**

Bu örnek kod, bir sunumu standart ayarlarla hareketli GIF'e nasıl dönüştüreceğinizi gösterir:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.gif", SaveFormat::Gif);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Hareketli GIF, varsayılan parametrelerle oluşturulacak. 

{{%  alert  title="TIP"  color="primary"  %}} 
GIF parametrelerini özelleştirmek isterseniz, [GifOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/GifOptions) sınıfını kullanabilirsiniz. Aşağıdaki örnek koda bakın. 
{{% /alert %}} 

## **Özel Ayarları Kullanarak Sunumları Hareketli GIF'e Dönüştürme**
Bu örnek kod, bir sunumu özel ayarlarla hareketli GIF'e nasıl dönüştüreceğinizi gösterir :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// oluşan GIF'in boyutu

    $gifOptions->setDefaultDelay(2000);// her slaytın bir sonraki slayta geçene kadar gösterileceği süre

    $gifOptions->setTransitionFps(35);// geçiş animasyon kalitesini artırmak için FPS'yi yükselt

    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}
Aspose tarafından geliştirilen BEDAVA bir [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüsüne bir göz atabilirsiniz. 
{{% /alert %}}

## **SSS**

**Sunumda kullanılan yazı tipleri sistemde yüklü değilse ne olur?**

Eksik yazı tiplerini yükleyin veya [fallback yazı tiplerini yapılandırın](/slides/tr/php-java/powerpoint-fonts/). Aspose.Slides ikame yapacaktır, ancak görünüm farklılık gösterebilir. Markalaşma için gerekli tipografilerin kesinlikle mevcut olduğundan emin olun.

**GIF çerçevelerine bir filigran ekleyebilir miyim?**

Evet. Dışa aktarmadan önce ana slayta veya ayrı ayrı slaytlara [yarı saydam bir nesne/logo ekleyin](/slides/tr/php-java/watermark/) — filigran her karede görünecektir.