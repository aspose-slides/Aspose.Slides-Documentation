---
title: Handout Modunda Sunumları Python ile Dönüştürme
linktitle: Handout Modu
type: docs
weight: 150
url: /tr/python-net/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- handout modu
- el ilanı
- PowerPoint
- sunum
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Sunumları Python'da el ilanlarına dönüştürün. Sayfa başına slayt sayısını ayarlayın, notları koruyun, Aspose.Slides ile PDF veya görüntülere dışa aktarın, örnek kodla. Ücretsiz deneyin."
---
## **Giriş**

Aspose.Slides, sunumları çeşitli formatlara dönüştürme yeteneği sağlar; bunlar arasında Handout modunda baskı için el ilanları oluşturma da bulunur. Bu mod, bir sayfada birden fazla slaytın nasıl görüneceğini yapılandırmanıza olanak tanır ve konferanslar, seminerler ve diğer etkinlikler için faydalıdır. Bu modu, `slides_layout_options` özelliğini [PdfOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/htmloptions/) ve [TiffOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/) sınıflarında ayarlayarak etkinleştirebilirsiniz.

## **Handout Modu Dışa Aktarma**

Handout modunu yapılandırmak için, bir sayfada kaç slayt yer alacağını ve diğer görüntüleme parametrelerini belirleyen [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/handoutlayoutingoptions/) nesnesini kullanın.

Aşağıda Handout modunda bir sunumu PDF’ye dönüştüren bir kod örneği bulunmaktadır.

```py
# Bir sunum yükle.
with slides.Presentation("sample.pptx") as presentation:

    # Dışa aktarma seçeneklerini ayarla.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # Sayfada yatay olarak 4 slayt
    slides_layout_options.print_slide_numbers = True                                 # slayt numaralarını yazdır
    slides_layout_options.print_frame_slide = True                                   # slaytların etrafına bir çerçeve yazdır
    slides_layout_options.print_comments = False                                     # yorum yok

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Sunumu seçilen yerleşimle PDF olarak dışa aktar.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
`slides_layout_options` özelliğinin yalnızca PDF, HTML, TIFF gibi belirli çıktı formatları ve görüntü olarak render edilirken mevcut olduğunu unutmayın.
{{% /alert %}} 

## **SSS**

**Handout modunda bir sayfada maksimum kaç slayt küçük resmi bulunabilir?**

Aspose.Slides, yatay veya dikey sıralama ile sayfa başına 9’a kadar küçük resim içeren [presets](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/handouttype/) destekler: 1, 2, 3, 4 (yatay/dikey), 6 (yatay/dikey) ve 9 (yatay/dikey).

**5 veya 8 slayt gibi özel bir ızgara tanımlayabilir miyim?**

Hayır. Küçük resimların sayısı ve sırası, [HandoutType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/handouttype/) enumu tarafından katı olarak kontrol edilir; keyfi düzenlemeler desteklenmez.

**Gizli slaytları Handout çıktısına dahil edebilir miyim?**

Evet. Hedef format için dışa aktarım ayarlarında `show_hidden_slides` seçeneğini etkinleştirin; örneğin [PdfOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/htmloptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/).