---
title: C++ Kullanarak Handout Modunda PowerPoint Sunumlarını Dönüştürme
linktitle: Handout Modu
type: docs
weight: 150
url: /tr/cpp/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- handout modu
- el kitapçığı
- PPT
- PPTX
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "C++ ile sunumları el kitapçıklarına dönüştürün. Sayfa başına slayt sayısını ayarlayın, notları koruyun, Aspose.Slides ile PDF ya da görüntülere dışa aktarın, örnek kodla. Ücretsiz deneyin."
---
## **Giriş**

Aspose.Slides, sunumları çeşitli formatlara dönüştürme yeteneği sağlar, Handout modunda yazdırma için el kitapçıkları oluşturmayı da içerir. Bu mod, bir sayfada birden fazla slaydın nasıl görüneceğini yapılandırmanıza olanak tanır ve konferanslar, seminerler ve diğer etkinlikler için kullanışlıdır. Bu modu, `set_SlidesLayoutOptions` metodunu [IPdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/ihtmloptions/), ve [ITiffOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/itiffoptions/) arayüzlerinde çağırarak etkinleştirebilirsiniz.

İhracattan önce el kitapçığı sayfa boyutlarını ve yönelimini ayarlamak için, [Not Sayfası Boyutu](/slides/tr/cpp/notes-size/) bölümüne bakın.

## **El İzi Modu Dışa Aktarma**

Handout modunu yapılandırmak için, bir sayfada kaç slayd yer alacağını ve diğer görüntüleme parametrelerini belirleyen [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/handoutlayoutingoptions/) nesnesini kullanın.

Aşağıda, bir sunumu Handout modunda PDF'ye dönüştürmeyi gösteren bir kod örneği bulunmaktadır.

```cpp
#include <DOM/Presentation.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Bir sunumu yükle.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Dışa aktarım seçeneklerini ayarla.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // Yatay olarak bir sayfada 4 slayt
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // slayt numaralarını yazdır
slidesLayoutOptions->set_PrintFrameSlide(true);                      // slaytların etrafına bir çerçeve yazdır
slidesLayoutOptions->set_PrintComments(false);                       // yorum yok

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
`set_SlidesLayoutOptions` metodunun yalnızca PDF, HTML, TIFF gibi belirli çıktı formatları ve görüntü olarak render edildiğinde mevcut olduğunu unutmayın.
{{% /alert %}} 

## **SSS**

### Handout modunda sayfa başına maksimum slayt küçük resmi sayısı nedir?

Aspose.Slides, sayfa başına yatay veya dikey sıralama ile 9'a kadar küçük resim içeren [ön ayarlar](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/handouttype/) destekler: 1, 2, 3, 4 (yatay/dikey), 6 (yatay/dikey) ve 9 (yatay/dikey).

### 5 veya 8 slayt gibi özel bir ızgara tanımlayabilir miyim?

Hayır. Küçük resimlerin sayısı ve sıralaması, [HandoutType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/handouttype/) enumarasyonu tarafından sıkı bir şekilde kontrol edilir; rastgele düzenler desteklenmez.

### Gizli slaytları Handout çıktısına ekleyebilir miyim?

Evet. Hedef format için dışa aktarma ayarlarında `set_ShowHiddenSlides` metodunu kullanın, örneğin [PdfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/htmloptions/), veya [TiffOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/).