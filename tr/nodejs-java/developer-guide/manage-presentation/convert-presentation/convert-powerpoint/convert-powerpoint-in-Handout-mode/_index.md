---
title: JavaScript Kullanarak El Kitapçığı Modunda PowerPoint Sunumlarını Dönüştürme
linktitle: El Kitapçığı Modu
type: docs
weight: 150
url: /tr/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint Dönüştür
- Sunumu Dönüştür
- El Kitapçığı Modu
- El Kitapçığı
- PPT
- PPTX
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Sunumları el kitapçıklarına dönüştürün. Sayfa başına slayt sayısını ayarlayın, notları koruyun, Aspose.Slides for Node.js ile PDF veya görüntülere dışa aktarın, örnek kodla. Ücretsiz deneyin."
---
## **Giriş**

Aspose.Slides, sunumları çeşitli formatlara dönüştürme yeteneği sağlar, ayrıca Handout modunda yazdırma için el kitapçıkları oluşturmayı da içerir. Bu mod, bir sayfada birden çok slaytın nasıl görüneceğini yapılandırmanıza olanak tanır ve konferanslar, seminerler ve diğer etkinlikler için faydalıdır. Bu modu, `setSlidesLayoutOptions` yöntemini [PdfOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/htmloptions/) ve [TiffOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/) sınıflarında ayarlayarak etkinleştirebilirsiniz.

## **El Kitapçığı Modu Dışa Aktarma**

El kitapçığı modunu yapılandırmak için, tek bir sayfada kaç slayt yerleştirileceğini ve diğer görüntüleme parametrelerini belirleyen [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/handoutlayoutingoptions/) nesnesini kullanın.

Aşağıda, bir sunumu El kitapçığı modunda PDF'ye dönüştürmeyi gösteren bir kod örneği bulunmaktadır.

```js
// Bir sunumu yükle.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Dışa aktarım seçeneklerini ayarla.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // Bir sayfada yatay olarak 4 slayt
slidesLayoutOptions.setPrintSlideNumbers(true);                                // slayt numaralarını yazdır
slidesLayoutOptions.setPrintFrameSlide(true);                                  // slaytların etrafına çerçeve yazdır
slidesLayoutOptions.setPrintComments(false);                                   // yorum yok

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Seçilen düzenle sunumu PDF'ye dışa aktar.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
`setSlidesLayoutOptions` yönteminin yalnızca PDF, HTML, TIFF gibi belirli çıktı formatları için ve görüntüler olarak render edildiğinde kullanılabildiğini unutmayın.
{{% /alert %}} 

## **SSS**

**El kitapçığı modunda bir sayfadaki maksimum slayt küçük resmi sayısı nedir?**

Aspose.Slides, sayfa başına en fazla 9 küçük resim destekleyen [presets](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/handouttype/) (yatay veya dikey sıralama) sunar: 1, 2, 3, 4 (yatay/dikey), 6 (yatay/dikey) ve 9 (yatay/dikey).

**5 veya 8 slayt gibi özel bir ızgara tanımlayabilir miyim?**

Hayır. Küçük resim sayısı ve sıralaması, yalnızca [HandoutType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/handouttype/) enum değerleriyle sıkı bir şekilde kontrol edilir; isteğe bağlı düzenler desteklenmez.

**El kitapçığı çıktısına gizli slaytları ekleyebilir miyim?**

Evet. Hedef format için dışa aktarma ayarlarında, örneğin [PdfOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/htmloptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/) gibi, `setShowHiddenSlides` yöntemini kullanın.