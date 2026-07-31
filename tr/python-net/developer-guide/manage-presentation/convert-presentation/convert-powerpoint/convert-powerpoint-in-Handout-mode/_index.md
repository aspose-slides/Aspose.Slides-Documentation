---
title: Python ile Handout Modunda Sunumları Dönüştürme
linktitle: Handout Modu
type: docs
weight: 150
url: /tr/python-net/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- el ilanı modu
- el ilanı
- PowerPoint
- sunum
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Python’da sunumları el ilanına dönüştürün. Sayfa başına slayt sayısını ayarlayın, notları koruyun, Aspose.Slides ile PDF veya görüntülere dışa aktarın, örnek kodla. Ücretsiz deneyin."
---
## **Giriş**

Aspose.Slides, sunumları çeşitli biçimlere dönüştürme yeteneği sağlar; bunlar arasında Handout modunda yazdırmak için el ilanları oluşturma da bulunur. Bu mod, bir sayfada birden fazla slaytın nasıl görüneceğini yapılandırmanıza olanak tanır ve konferanslar, seminerler ve diğer etkinlikler için kullanışlıdır. `slides_layout_options` özelliğini [PdfOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/htmloptions/) ve [TiffOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/) sınıflarında ayarlayarak bu modu etkinleştirebilirsiniz.

## **El İlanı Modu Dışa Aktarma**

Handout modunu yapılandırmak için, tek bir sayfada kaç slayt yerleştirileceğini ve diğer görüntüleme parametrelerini belirleyen [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/handoutlayoutingoptions/) nesnesini kullanın.

Aşağıda, bir sunumu Handout modunda PDF'ye dönüştürmeyi gösteren bir kod örneği bulunmaktadır.

```py
# Sunumu yükle.
with slides.Presentation("sample.pptx") as presentation:

    # Dışa aktarım seçeneklerini ayarla.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 slayt bir sayfada yatay olarak
    slides_layout_options.print_slide_numbers = True                                 # slayt numaralarını yazdır
    slides_layout_options.print_frame_slide = True                                   # slaytların etrafına bir çerçeve yazdır
    slides_layout_options.print_comments = False                                     # yorum yok

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Seçilen düzenle sunumu PDF olarak dışa aktar.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
Unutmayın ki `slides_layout_options` özelliği yalnızca PDF, HTML, TIFF gibi belirli çıktı formatları için ve görüntü olarak render edildiğinde kullanılabilir. 
{{% /alert %}} 

## **SSS**

**Handout modunda sayfa başına maksimum slayt küçük resmi sayısı nedir?**

Aspose.Slides, sayfa başına yatay veya dikey sıralama ile 9 küçük resime kadar [presets](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/handouttype/) destekler: 1, 2, 3, 4 (yatay/dikey), 6 (yatay/dikey) ve 9 (yatay/dikey).

**5 veya 8 slayt gibi özel bir ızgara tanımlayabilir miyim?**

Hayır. Küçük resimlerin sayısı ve sıralaması, [HandoutType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/handouttype/) adlı sayım (enumeration) tarafından katı bir şekilde kontrol edilir; rastgele düzenler desteklenmez.

**Handout çıktısına gizli slaytları dahil edebilir miyim?**

Evet. Hedef format için dışa aktarma ayarlarında `show_hidden_slides` seçeneğini etkinleştirin; örneğin [PdfOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/htmloptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/).