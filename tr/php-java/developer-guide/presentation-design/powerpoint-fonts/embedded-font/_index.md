---
title: PHP Kullanarak Sunumlarda Yazı Tipi Gömme
linktitle: Yazı Tipi Gömme
type: docs
weight: 40
url: /tr/php-java/embedded-font/
keywords:
- yazı tipi ekle
- yazı tipi gömme
- yazı tipi gömme
- gömülü yazı tipini al
- gömülü yazı tipi ekle
- gömülü yazı tipini kaldır
- gömülü yazı tipini sıkıştır
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "TrueType yazı tiplerini PowerPoint ve OpenDocument sunumlarına Aspose.Slides for PHP via Java ile gömerek, tüm platformlarda doğru renderlemeyi sağlamak."
---
## **Giriş**

**PowerPoint'ta gömülü yazı tipleri**, sunumunuzun herhangi bir sistem veya cihazda açıldığında doğru görünmesini istediğinizde kullanışlıdır. Çalışmanızda yaratıcı olduğunuz için üçüncü taraf veya standart dışı bir yazı tipi kullandıysanız, yazı tipinizi gömmek için daha da fazla nedeniniz vardır. Aksi takdirde (gömülü yazı tipleri olmadan), slaytlarınızdaki metin veya sayılar, düzen, stil vb. değişebilir veya karışık dikdörtgenlere dönüşebilir.  

[FontsManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FontsManager) sınıfı, [FontData](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontdata/) sınıfı ve [Compress](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/) sınıfı, PowerPoint sunumlarında gömülü yazı tipleriyle çalışmak için ihtiyaç duyduğunuz yöntemlerin çoğunu içerir.

## **Gömülü Yazı Tiplerini Al ve Kaldır**

Aspose.Slides, bir sunumda gömülü olan yazı tiplerini almanıza (veya öğrenmenize) olanak sağlamak için [getEmbeddedFonts](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) yöntemini ([FontsManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FontsManager) sınıfı tarafından sunulur) sağlar. Yazı tiplerini kaldırmak için aynı sınıfın [removeEmbeddedFont](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) yöntemi kullanılır.

Bu PHP kodu, bir sunumdan gömülü yazı tiplerini nasıl alıp kaldıracağınızı gösterir:

```php
  # Bir sunum dosyasını temsil eden Presentation nesnesini örnekler
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # Gömülü "FunSized" kullanan bir metin çerçevesi içeren slaytı render eder
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Görüntüyü JPEG formatında diske kaydeder
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # Tüm gömülü yazı tiplerini alır
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # "Calibri" yazı tipini bulur
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # "Calibri" yazı tipini kaldırır
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # Sunumu render eder; "Calibri" yazı tipi mevcut bir yazı tipiyle değiştirilir
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Görüntüyü JPEG formatında diske kaydeder
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Gömülü "Calibri" yazı tipi olmadan sunumu diske kaydeder
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Gömülü Yazı Tipi Ekle**

[EmbedFontCharacters](https://reference.aspose.com/slides/tr/php-java/aspose.slides/embedfontcharacters/) sınıfını ve [addEmbeddedFont](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) yönteminin iki aşırı yüklemesini kullanarak, bir sunuma yazı tiplerini gömmek için tercih ettiğiniz (gömme) kuralını seçebilirsiniz. Bu PHP kodu, bir sunuma yazı tiplerini nasıl gömeceğinizi ve ekleyeceğinizi gösterir:

```php
  # Sunumu yükler
  $pres = new Presentation("Fonts.pptx");
  try {
    $allFonts = $pres->getFontsManager()->getFonts();
    $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
    $Array = new java_class("java.lang.reflect.Array");
    foreach($allFonts as $font) {
      $embeddedFontsContainsFont = false;
      for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
        if ($embeddedFonts[$i]->equals($font)) {
          $embeddedFontsContainsFont = true;
          break;
        }
      }
      if (!$embeddedFontsContainsFont) {
        $pres->getFontsManager()->addEmbeddedFont($font, EmbedFontCharacters->All);
        $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
      }
    }
    # Sunumu diske kaydeder
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Gömülü Yazı Tiplerini Sıkıştır**

Bir sunumda gömülü yazı tiplerini sıkıştırarak dosya boyutunu azaltmanıza olanak tanımak için Aspose.Slides, [compressEmbeddedFonts](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/#compressEmbeddedFonts) yöntemini ([Compress](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/) sınıfı tarafından sunulur) sağlar.

Bu PHP kodu, gömülü PowerPoint yazı tiplerini nasıl sıkıştıracağınızı gösterir:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->compressEmbeddedFonts($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Sunumdaki belirli bir yazı tipinin gömülmüş olmasına rağmen yine de işleme sırasında değiştirileceğini nasıl anlayabilirim?**

Yazı tipi yöneticisindeki [substitution information](/slides/tr/php-java/font-substitution/) ve [fallback/substitution rules](/slides/tr/php-java/fallback-font/) kontrol edin: yazı tipi kullanılamıyorsa veya kısıtlıysa, bir yedek (fallback) kullanılacaktır.

**Arial/Calibri gibi “sistem” yazı tiplerini gömmek mantıklı mı?**

Genellikle hayır—bu yazı tipleri neredeyse her zaman mevcuttur. Ancak “ince” ortamlarda (Docker, önceden yüklü yazı tipleri olmayan bir Linux sunucusu) tam taşınabilirlik için sistem yazı tiplerini gömmek, beklenmedik değişim riskini ortadan kaldırabilir.