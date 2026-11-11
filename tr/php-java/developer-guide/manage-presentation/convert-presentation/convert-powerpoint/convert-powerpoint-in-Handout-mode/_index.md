---
title: PHP Kullanarak El İlanı Modunda PowerPoint Sunumlarını Dönüştürme
linktitle: El İlanı Modu
type: docs
weight: 150
url: /tr/php-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- el ilanı modu
- el ilanı
- PPT
- PPTX
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "PHP'de sunumları el ilanına dönüştürün. Sayfa başına slayt sayısını ayarlayın, notları koruyun, Aspose.Slides for PHP ile PDF ya da görüntülere aktarın, örnek kodla. Ücretsiz deneyin."
---
## **Giriş**

Aspose.Slides, sunumları çeşitli formatlara dönüştürme yeteneği sağlar; bunlar arasında Handout modunda yazdırma için el ilanları oluşturma da bulunur. Bu mod, bir sayfada birden çok slaytın nasıl görüneceğini yapılandırmanıza olanak tanır ve konferanslar, seminerler ve diğer etkinlikler için faydalıdır. Bu modu, `setSlidesLayoutOptions` yöntemini [PdfOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/htmloptions/) ve [TiffOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/) sınıflarında ayarlayarak etkinleştirebilirsiniz.

Dışa aktarmadan önce el ilanı sayfasının boyutlarını ve yönünü ayarlamak için, [Not Sayfası Boyutu](/slides/tr/php-java/notes-size/) sayfasına bakın.

## **El İlanı Modu Dışa Aktarma**

Handout modunu yapılandırmak için, bir sayfada kaç slayt yerleştirileceğini ve diğer görüntüleme parametrelerini belirleyen [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/handoutlayoutingoptions/) nesnesini kullanın.

Aşağıda, bir sunumu Handout modunda PDF'ye dönüştürmeyi gösteren bir kod örneği bulunmaktadır.

```php
// Sunumu yükle.
$presentation = new Presentation("sample.pptx");

// Dışa aktarım seçeneklerini ayarla.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // Bir sayfada 4 slayt yatay olarak
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // slayt numaralarını yazdır
$slidesLayoutOptions->setPrintFrameSlide(true);                      // slaytların etrafına çerçeve yazdır
$slidesLayoutOptions->setPrintComments(false);                       // yorum yok

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Seçilen düzenle sunumu PDF'ye dışa aktar.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" title="Warning" %}}
`setSlidesLayoutOptions` yönteminin yalnızca PDF, HTML, TIFF gibi belirli çıktı formatları ve görüntü olarak render edildiğinde mevcut olduğunu unutmayın.
{{% /alert %}} 

## **SSS**

**Handout modunda sayfa başına maksimum slayt küçük görsel sayısı nedir?**

Aspose.Slides, sayfa başına 9 adede kadar yatay veya dikey sıralama ile küçük görsel destekleyen [presets](https://reference.aspose.com/slides/tr/php-java/aspose.slides/handouttype/) sunar: 1, 2, 3, 4 (yatay/dikey), 6 (yatay/dikey) ve 9 (yatay/dikey).

**5 veya 8 slayt gibi özel bir ızgara tanımlayabilir miyim?**

Hayır. Küçük görsellerin sayısı ve sıralaması tamamen [HandoutType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/handouttype/) sınıfı tarafından kontrol edilir; rastgele düzenler desteklenmez.

**Handout çıktısına gizli slaytları ekleyebilir miyim?**

Evet. Hedef format için dışa aktarma ayarlarında, örneğin [PdfOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/htmloptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/), `setShowHiddenSlides` metodunu kullanarak gizli slaytları etkinleştirebilirsiniz.