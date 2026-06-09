---
title: PHP Kullanarak Handout Modunda PowerPoint Sunumlarını Dönüştürme
linktitle: Handout Modu
type: docs
weight: 150
url: /tr/php-java/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- handout modu
- handout
- PPT
- PPTX
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "PHP'de sunumları handout'lara dönüştürün. Sayfa başına slayt sayısını ayarlayın, notları koruyun, Aspose.Slides for PHP ile PDF ya da görüntü olarak dışa aktarın, örnek kodla. Ücretsiz deneyin."
---
## **Giriş**

Aspose.Slides, sunumları çeşitli formatlara dönüştürme yeteneği sağlar; buna Handout (Dağıtım) modunda yazdırma için el ilanları oluşturma da dahil. Bu mod, bir sayfada birden fazla slaytın nasıl görünmesini yapılandırmanıza olanak tanır ve konferanslar, seminerler ve diğer etkinlikler için faydalıdır. Bu modu, sınıflarındaki `setSlidesLayoutOptions` metodunu ayarlayarak etkinleştirebilirsiniz: [PdfOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/htmloptions/), ve [TiffOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/) sınıflarında.

## **El İlanı Modu Dışa Aktarma**

Handout modunu yapılandırmak için, bir sayfada kaç slayt yerleştirileceğini ve diğer görüntüleme parametrelerini belirleyen [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/handoutlayoutingoptions/) nesnesini kullanın.

Aşağıda, bir sunumu Handout modunda PDF'ye dönüştürmeyi gösteren bir kod örneği bulunmaktadır.

```php
// Bir sunumu yükle.
$presentation = new Presentation("sample.pptx");

// Dışa aktarma seçeneklerini ayarla.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // Yatay olarak bir sayfada 4 slayt
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // slayt numaralarını yazdır
$slidesLayoutOptions->setPrintFrameSlide(true);                      // slaytların etrafına bir çerçeve yazdır
$slidesLayoutOptions->setPrintComments(false);                       // yorum yok

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Seçilen düzenle sunumu PDF olarak dışa aktar.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 
Unutmayın ki `setSlidesLayoutOptions` metodu yalnızca PDF, HTML, TIFF gibi belirli çıktı formatları için ve görüntü olarak oluşturulurken kullanılabilir.
{{% /alert %}} 

## **SSS**

**Handout modunda sayfa başına maksimum slayt küçük resmi sayısı nedir?**

Aspose.Slides, yatay veya dikey sıralama ile sayfa başına en fazla 9 küçük resim destekleyen [presets](https://reference.aspose.com/slides/tr/php-java/aspose.slides/handouttype/) sunar: 1, 2, 3, 4 (yatay/dikey), 6 (yatay/dikey) ve 9 (yatay/dikey).

**Sayfa başına 5 veya 8 slayt gibi özel bir ızgara tanımlayabilir miyim?**

Hayır. Küçük resimlerin sayısı ve sırası yalnızca [HandoutType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/handouttype/) sınıfı tarafından belirlenir; rastgele düzenler desteklenmez.

**El ilanı çıktısına gizli slaytları ekleyebilir miyim?**

Evet. Hedef format için dışa aktarma ayarlarında `setShowHiddenSlides` metodunu kullanarak gizli slaytları etkinleştirebilirsiniz; örneğin [PdfOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/htmloptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/).