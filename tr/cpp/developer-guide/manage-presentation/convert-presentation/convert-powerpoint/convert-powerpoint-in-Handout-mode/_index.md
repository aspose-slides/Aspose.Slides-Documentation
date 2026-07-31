---
title: C++ Kullanarak El Broşür Modunda PowerPoint Sunumlarını Dönüştürme
linktitle: El Broşür Modu
type: docs
weight: 150
url: /tr/cpp/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- el broşür modu
- el broşürü
- PPT
- PPTX
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "C++ ile sunumları el broşürlerine dönüştürün. Sayfa başına slayt sayısını ayarlayın, notları koruyun, Aspose.Slides ile PDF veya görüntülere dışa aktarın, örnek kodla. Ücretsiz deneyin."
---
## **Giriş**

Aspose.Slides, sunumları çeşitli formatlarda dönüştürme yeteneği sağlar; bunlar arasında Handout modunda yazdırma için el broşürleri oluşturma da bulunur. Bu mod, bir sayfada birden çok slaytın nasıl görüneceğini yapılandırmanıza olanak tanır ve konferanslar, seminerler ve diğer etkinlikler için faydalıdır. Bu modu, `set_SlidesLayoutOptions` yöntemini [IPdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/ihtmloptions/), ve [ITiffOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/itiffoptions/) arabirimlerinde ayarlayarak etkinleştirebilirsiniz.

## **El Broşür Modu Dışa Aktarımı**

El broşür modunu yapılandırmak için, bir sayfaya kaç slayt yerleştirileceğini ve diğer görüntüleme parametrelerini belirleyen [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/handoutlayoutingoptions/) nesnesini kullanın.

Aşağıda, bir sunumu El broşür modunda PDF'ye dönüştürmeyi gösteren bir kod örneği bulunmaktadır.

```cpp
// Bir sunumu yükle.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Set the export options.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // Bir sayfada yatay olarak 4 slayt
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // slayt numaralarını yazdır
slidesLayoutOptions->set_PrintFrameSlide(true);                      // slaytların etrafına çerçeve yazdır
slidesLayoutOptions->set_PrintComments(false);                       // yorum yok

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
`set_SlidesLayoutOptions` yönteminin yalnızca PDF, HTML, TIFF gibi belirli çıktı formatları için ve görüntü olarak işlenirken kullanılabileceğini aklınızda bulundurun.
{{% /alert %}} 

## **SSS**

**El broşür modunda bir sayfa başına maksimum slayt küçük resmi sayısı nedir?**

Aspose.Slides, sayfa başına en fazla 9 küçük resim destekleyen [preset'ler](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/handouttype/) yatay veya dikey sıralama seçenekleriyle: 1, 2, 3, 4 (yatay/dikey), 6 (yatay/dikey) ve 9 (yatay/dikey) sunar.

**Sayfa başına 5 veya 8 slayt gibi özel bir ızgara tanımlayabilir miyim?**

Hayır. Küçük resim sayısı ve sıralaması, [HandoutType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/handouttype/) enum'ı tarafından kesin olarak kontrol edilir; keyfi düzenler desteklenmez.

**El broşür çıktısına gizli slaytları dahil edebilir miyim?**

Evet. Hedef format için dışa aktarma ayarlarında `set_ShowHiddenSlides` yöntemini kullanın; örneğin [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/htmloptions/), veya [TiffOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/).