---
title: JavaScript Kullanarak Handout Modunda PowerPoint Sunumlarını Dönüştürme
linktitle: Handout Modu
type: docs
weight: 150
url: /tr/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- el ilanı modu
- el ilanı
- PPT
- PPTX
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Sunumları el ilanına dönüştürün. Sayfa başına slayt sayısını ayarlayın, notları koruyun, Aspose.Slides for Node.js ile PDF veya görüntülere dışa aktarın, örnek kodla. Ücretsiz deneyin."
---
## **Giriş**

Aspose.Slides sunumları çeşitli biçimlere dönüştürme yeteneği sağlar; bunlar arasında Handout modunda baskı için el ilanları oluşturma da bulunur. Bu mod, bir sayfada birden fazla slaydın nasıl görüneceğini yapılandırmanıza olanak tanır ve konferanslar, seminerler ve diğer etkinlikler için faydalıdır. Bu modu, `setSlidesLayoutOptions` metodunu [PdfOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/htmloptions/) ve [TiffOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/) sınıflarında ayarlayarak etkinleştirebilirsiniz.

El ilanı sayfası boyutlarını ve yönünü dışa aktarmadan önce ayarlamak için, [Not Sayfası Boyutu](/slides/tr/nodejs-java/notes-size/) bölümüne bakın.

## **El İlanı Modu Dışa Aktarma**

Handout modunu yapılandırmak için, bir sayfaya yerleştirilen slayt sayısını ve diğer görüntüleme parametrelerini belirleyen [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/handoutlayoutingoptions/) nesnesini kullanın.

Aşağıda, bir sunumu Handout modunda PDF'ye dönüştürmeyi gösteren bir kod örneği bulunmaktadır.

```js
const asposeSlides = require("aspose.slides.via.java");

// Sunumu yükle.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Set the export options.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // Sayfa başına yatay olarak 4 slayt
slidesLayoutOptions.setPrintSlideNumbers(true);                                // slayt numaralarını yazdır
slidesLayoutOptions.setPrintFrameSlide(true);                                  // slaytların etrafına bir çerçeve yazdır
slidesLayoutOptions.setPrintComments(false);                                   // yorum yok

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" title="Warning" %}}
`setSlidesLayoutOptions` metodunun yalnızca PDF, HTML, TIFF gibi belirli çıktı formatları ve görüntü olarak render edilirken kullanılabilir olduğunu unutmayın.
{{% /alert %}} 

## **SSS**

**Handout modunda bir sayfadaki maksimum slayt küçük resmi sayısı nedir?**

Aspose.Slides, yatay veya dikey sıralama ile sayfa başına en fazla 9 küçük resim sağlayan [presets](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/handouttype/) destekler: 1, 2, 3, 4 (yatay/dikey), 6 (yatay/dikey) ve 9 (yatay/dikey).

**Sayfa başına 5 veya 8 slayt gibi özel bir ızgara tanımlayabilir miyim?**

Hayır. Küçük resimlerin sayısı ve sıralaması, [HandoutType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/handouttype/) enumu tarafından kesin olarak kontrol edilir; rastgele düzenler desteklenmez.

**El İlanı çıktılarına gizli slaytları ekleyebilir miyim?**

Evet. Hedef format için dışa aktarma ayarlarında, örneğin [PdfOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/htmloptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/) gibi, `setShowHiddenSlides` metodunu kullanın.