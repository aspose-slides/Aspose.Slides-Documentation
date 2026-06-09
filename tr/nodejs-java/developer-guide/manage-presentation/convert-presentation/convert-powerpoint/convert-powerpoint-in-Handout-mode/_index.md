---
title: PowerPoint Sunumlarını El İlanı Modunda JavaScript Kullanarak Dönüştürün
linktitle: El İlanı Modu
type: docs
weight: 150
url: /tr/nodejs-java/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- el ilanı modu
- el ilanı
- PPT
- PPTX
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Sunumları el ilanına dönüştürün. Sayfa başına slayt sayısını ayarlayın, notları koruyun, Aspose.Slides for Node.js ile PDF ya da görüntülere dışa aktarın, örnek kodla. Ücretsiz deneyin."
---
## **Giriş**

Aspose.Slides, sunumları çeşitli formatlara dönüştürme yeteneği sağlar; bu, Handout modunda yazdırma için el ilanları oluşturmayı da içerir. Bu mod, bir sayfada birden çok slaytın nasıl görüneceğini yapılandırmanıza olanak tanır ve konferanslar, seminerler ve diğer etkinlikler için faydalıdır. Bu modu, sınıflarındaki `setSlidesLayoutOptions` metodunu ayarlayarak etkinleştirebilirsiniz: [PdfOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/htmloptions/), ve [TiffOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/) sınıflarında.

## **El İlanı Modu Dışa Aktarma**

Handout modunu yapılandırmak için [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/handoutlayoutingoptions/) nesnesini kullanın; bu nesne, tek bir sayfada kaç slayt yerleştirileceğini ve diğer görüntüleme parametrelerini belirler.

Aşağıda, bir sunumu Handout modunda PDF'ye dönüştüren bir kod örneği yer almaktadır.

```js
// Bir sunum yükle.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Dışa aktarma seçeneklerini ayarla.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // Bir sayfada yatay olarak 4 slayt
slidesLayoutOptions.setPrintSlideNumbers(true);                                // slayt numaralarını yazdır
slidesLayoutOptions.setPrintFrameSlide(true);                                  // slaytların etrafına çerçeve ekle
slidesLayoutOptions.setPrintComments(false);                                   // yorum yok

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Seçilen düzenle sunumu PDF olarak dışa aktar.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
`setSlidesLayoutOptions` metodunun yalnızca PDF, HTML, TIFF gibi belirli çıkış formatları ve görüntü olarak render edildiğinde mevcut olduğunu unutmayın.
{{% /alert %}} 

## **SSS**

**Handout modunda sayfa başına maksimum slayt küçük resmi sayısı nedir?**

Aspose.Slides, sayfa başına yatay veya dikey sıralama ile 9'a kadar küçük resim [presets](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/handouttype/) destekler: 1, 2, 3, 4 (yatay/dikey), 6 (yatay/dikey) ve 9 (yatay/dikey).

**5 veya 8 slayt gibi özel bir ızgara tanımlayabilir miyim?**

Hayır. Küçük resimlerin sayısı ve sırası, [HandoutType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/handouttype/) enumu tarafından kesin olarak kontrol edilir; rastgele düzenler desteklenmez.

**Handout çıktısına gizli slaytları ekleyebilir miyim?**

Evet. Hedef format için dışa aktarma ayarlarında `setShowHiddenSlides` metodunu kullanın; örneğin [PdfOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/htmloptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/) gibi.