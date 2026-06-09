---
title: Handout Modunda PowerPoint Sunumlarını C++ Kullanarak Dönüştürme
linktitle: Handout Modu
type: docs
weight: 150
url: /tr/cpp/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- handout modu
- el kitabı
- PPT
- PPTX
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Sunumları C++ ile el kitapçığına dönüştürün. Sayfa başına slayt sayısını ayarlayın, notları koruyun, Aspose.Slides ile PDF veya görüntü olarak dışa aktarın, örnek kodla. Ücretsiz deneyin."
---
## **Introduction**

Aspose.Slides, sunumları çeşitli formatlara dönüştürme imkanı sunar; bunlar arasında Handout modunda yazdırma için el kitapçıkları oluşturma da bulunur. Bu mod, bir sayfada birden fazla slaytın nasıl görüneceğini yapılandırmanıza olanak tanır ve konferanslar, seminerler ve diğer etkinlikler için faydalıdır. Bu modu, [IPdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/ihtmloptions/) ve [ITiffOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/itiffoptions/) arabirimlerinde `set_SlidesLayoutOptions` metodunu ayarlayarak etkinleştirebilirsiniz.

## **Handout Mode Export**

Handout modunu yapılandırmak için, bir sayfada kaç slayt yer alacağını ve diğer görüntüleme parametrelerini belirleyen [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/handoutlayoutingoptions/) nesnesini kullanın.

Aşağıda, bir sunumu Handout modunda PDF'ye dönüştürmeyi gösteren bir kod örneği bulunmaktadır.

```cpp
// Sunumu yükle.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Dışa aktarım seçeneklerini ayarla.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // Yatay olarak bir sayfada 4 slayt
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // slayt numaralarını yazdır
slidesLayoutOptions->set_PrintFrameSlide(true);                      // slaytların etrafına çerçeve ekle
slidesLayoutOptions->set_PrintComments(false);                       // yorum yok

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Seçilen düzenle sunumu PDF olarak dışa aktar.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
`set_SlidesLayoutOptions` metodunun yalnızca PDF, HTML, TIFF gibi belirli çıktı formatları ve görüntü olarak render edildiğinde kullanılabilir olduğunu aklınızda bulundurun.
{{% /alert %}} 

## **FAQ**

**What is the maximum number of slide thumbnails per page in Handout mode?**

Aspose.Slides, sayfa başına en fazla 9 küçük resme kadar olan [presets](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/handouttype/) (ön ayarlar) destekler; yatay veya dikey sıralama seçenekleri: 1, 2, 3, 4 (yatay/dikey), 6 (yatay/dikey) ve 9 (yatay/dikey).

**Can I define a custom grid, such as 5 or 8 slides per page?**

Hayır. Küçük resimlerin sayısı ve sıralaması, sadece [HandoutType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/handouttype/) enumu tarafından belirlenir; rastgele düzenler desteklenmez.

**Can I include hidden slides in the Handout output?**

Evet. Hedef format için dışa aktarma ayarlarında `set_ShowHiddenSlides` metodunu kullanın; örneğin [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/htmloptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/).