---
title: PowerPoint Sunumlarını El Kitabı Modunda PHP Kullanarak Dönüştürün
linktitle: El Kitabı Modu
type: docs
weight: 150
url: /tr/php-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- el kitabı modu
- el kitabı
- PPT
- PPTX
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Sunumları PHP'de el kitaplarına dönüştürün. Sayfa başına slayt sayısını ayarlayın, notları koruyun, Aspose.Slides for PHP ile PDF veya görsellere dışa aktarın, örnek kodla. Ücretsiz deneyin."
---
## **Giriş**

Aspose.Slides, sunumları çeşitli formatlara dönüştürme yeteneği sağlar; bu, Handout modunda yazdırmak için el kitapları oluşturmayı da içerir. Bu mod, bir sayfada birden çok slaytın nasıl görüneceğini yapılandırmanıza olanak tanır ve konferanslar, seminerler ve diğer etkinlikler için faydalıdır. Bu modu, `setSlidesLayoutOptions` yöntemini [PdfOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/htmloptions/) ve [TiffOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/) sınıflarında ayarlayarak etkinleştirebilirsiniz.

## **El Kitabı Modu Dışa Aktarımı**

Handout modunu yapılandırmak için, bir sayfaya kaç slayt yerleştirileceğini ve diğer görüntüleme parametrelerini belirleyen [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/handoutlayoutingoptions/) nesnesini kullanın.

Aşağıda, bir sunumu Handout modunda PDF’ye dönüştürmeyi gösteren bir kod örneği bulunmaktadır.

```php
// Sunumu yükle.
$presentation = new Presentation("sample.pptx");

// Dışa aktarım seçeneklerini ayarla.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // bir sayfada yatay olarak 4 slayt
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // slayt numaralarını yazdır
$slidesLayoutOptions->setPrintFrameSlide(true);                      // slaytların etrafına çerçeve yazdır
$slidesLayoutOptions->setPrintComments(false);                       // yorum yok

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Seçilen düzenle sunumu PDF olarak dışa aktar.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 
`setSlidesLayoutOptions` yönteminin yalnızca PDF, HTML, TIFF gibi belirli çıktı formatları için ve görüntü olarak render edildiğinde mevcut olduğunu unutmayın.
{{% /alert %}} 

## **SSS**

**Handout modunda bir sayfada maksimum kaç slayt küçük resmi bulunabilir?**

Aspose.Slides, yatay veya dikey sıralama ile sayfa başına maksimum 9 küçük resim destekleyen [presets](https://reference.aspose.com/slides/tr/php-java/aspose.slides/handouttype/) sağlar: 1, 2, 3, 4 (yatay/dikey), 6 (yatay/dikey) ve 9 (yatay/dikey).

**Sayfa başına 5 veya 8 slayt gibi özel bir ızgara tanımlayabilir miyim?**

Hayır. Küçük resimlerin sayısı ve sıralaması yalnızca [HandoutType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/handouttype/) sınıfı tarafından kontrol edilir; isteğe bağlı düzenler desteklenmez.

**Handout çıktısına gizli slaytları ekleyebilir miyim?**

Evet. Hedef format için dışa aktarım ayarlarında, örneğin [PdfOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/htmloptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/) gibi, gizli slaytları `setShowHiddenSlides` yöntemiyle etkinleştirebilirsiniz.