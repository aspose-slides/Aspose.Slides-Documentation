---
title: Python ile El Kitapçığı Modunda Sunumları Dönüştür
linktitle: El Kitapçığı Modu
type: docs
weight: 150
url: /tr/python-net/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- el kitapçığı modu
- el kitapçığı
- PowerPoint
- sunum
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Python’da sunumları el kitapçıklarına dönüştürün. Sayfa başına slayt sayısını ayarlayın, notları koruyun, Aspose.Slides ile PDF veya görüntülere aktarın, örnek kodla. Ücretsiz deneyin."
---
## **Giriş**

Aspose.Slides, sunumları çeşitli formatlara dönüştürme yeteneği sağlar; bunlar arasında El Kitapçığı modunda yazdırma için el kitapçıkları oluşturma da bulunur. Bu mod, bir sayfada birden çok slaytın nasıl görüneceğini yapılandırmanıza imkan tanır ve konferanslar, seminerler ve diğer etkinlikler için faydalıdır. Bu modu, [PdfOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/htmloptions/), ve [TiffOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/) sınıflarında `slides_layout_options` özelliğini ayarlayarak etkinleştirebilirsiniz.

Dışa aktarmadan önce el kitapçığı sayfa boyutlarını ve yönünü ayarlamak için [Notes Page Size](/slides/tr/python-net/notes-size/) bölümüne bakın.

## **El Kitapçığı Modu Dışa Aktarma**

El kitapçığı modunu yapılandırmak için, bir sayfada kaç slayt yerleştirileceğini ve diğer görüntüleme parametrelerini belirleyen [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/handoutlayoutingoptions/) nesnesini kullanın.

Aşağıda, bir sunumu El Kitapçığı modunda PDF'ye dönüştürmeyi gösteren bir kod örneği bulunmaktadır.

```py
import aspose.slides as slides

# Bir sunumu yükle.
with slides.Presentation("sample.pptx") as presentation:

    # Dışa aktarma seçeneklerini ayarla.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # Sayfada yatay olarak 4 slayt
    slides_layout_options.print_slide_numbers = True                                 # slayt numaralarını yazdır
    slides_layout_options.print_frame_slide = True                                   # slaytların etrafına çerçeve yazdır
    slides_layout_options.print_comments = False                                     # yorum yok

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Sunumu seçilen düzenle PDF olarak dışa aktar.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" title="Uyarı" %}}
`slides_layout_options` özelliğinin yalnızca PDF, HTML, TIFF gibi belirli çıktı formatları ve görüntü olarak render edilirken mevcut olduğunu unutmayın.
{{% /alert %}} 

## **SSS**

**El kitapçığı modunda bir sayfada bulunan azami slayt küçük resmi sayısı nedir?**

Aspose.Slides, yatay veya dikey sıralama ile sayfa başına 9 küçük resme kadar destekleyen [presets](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/handouttype/) sunar: 1, 2, 3, 4 (yatay/dikey), 6 (yatay/dikey) ve 9 (yatay/dikey).

**5 veya 8 slayt gibi özel bir ızgara tanımlayabilir miyim?**

Hayır. Küçük resim sayısı ve sıralaması yalnızca [HandoutType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/handouttype/) enumu tarafından kontrol edilir; keyfi düzenler desteklenmez.

**El kitapçığı çıktısına gizli slaytları ekleyebilir miyim?**

Evet. Hedef format için dışa aktarma ayarlarında `show_hidden_slides` seçeneğini etkinleştirin; örneğin [PdfOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/htmloptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/).