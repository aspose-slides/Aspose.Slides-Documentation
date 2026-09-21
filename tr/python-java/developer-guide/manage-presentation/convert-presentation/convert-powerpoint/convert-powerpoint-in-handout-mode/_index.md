---
title: Python Kullanarak El İlanı Modunda PowerPoint Sunumlarını Dönüştür
linktitle: El İlanı Modu
type: docs
weight: 150
url: /tr/python-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- el ilanı modu
- el ilanı
- PPT
- PPTX
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Python üzerinden Java ile PowerPoint sunumlarını el ilanına dönüştürün. Bir sayfada birden çok slaytı düzenleyin ve Aspose.Slides ile PDF olarak dışa aktarın."
---
## **Giriş**

Aspose.Slides for Python via Java, sunumları el ilanı modunda dışa aktarmanıza, bir sayfada birden çok slaytı düzenlemenize olanak tanır. Bu, konferanslar, seminerler ve benzeri etkinlikler için sunum materyallerini yazdırmakta kullanışlıdır.

Düzeni, [setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) yöntemiyle yapılandırın. El ilanı düzenleri [PdfOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/) ve [TiffOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tiffoptions/) tarafından desteklenir. Düzeni ve görüntü ayarlarını belirlemek için bir [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/handoutlayoutingoptions/) nesnesi kullanın.

Dışa aktarmadan önce el ilanı sayfa boyutlarını ve yönelimini ayarlamak için [Notes Page Size](/slides/tr/python-java/notes-size/) sayfasına bakın.

## **El İlanı Modunda Dışa Aktarma**

El ilanı modunda bir sunumu dışa aktarmak için bir [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/handoutlayoutingoptions/) örneği oluşturun ve hedef dışa aktarma seçeneklerine [setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) ile atayın.

Aşağıdaki örnek `sample.pptx` dosyasını yükler ve dört slaytı sayfa başına yatay sırayla PDF olarak dışa aktarır. Slayt numaralarını ve slaytların etrafındaki çerçeveleri içerir ve yorumları dışarı bırakır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# Sunumu yükle.
presentation = Presentation("sample.pptx")
try:
    # El ilanı düzenini yapılandır.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # Sunumu seçilen düzenle PDF olarak dışa aktar.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}

El ilanı düzen ayarları, PDF, HTML, TIFF ve oluşturulmuş görüntüler gibi desteklenen çıktı formatlarına uygulanır. Kaynak sunumdaki slaytları yeniden düzenlemez.

{{% /alert %}}

## **SSS**

**El ilanı modunda sayfa başına en fazla kaç slayt küçük resmi olabilir?**

Aspose.Slides sayfa başına en fazla dokuz küçük resim destekler. [HandoutType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/handouttype/) ön ayarları bir, iki, üç, dört, altı veya dokuz slayt sayfa başına sağlar. Dört, altı ve dokuz slayt ön ayarları yatay ve dikey sıralamayı sunar.

**Beş veya sekiz slayt gibi özel bir ızgara tanımlayabilir miyim?**

Hayır. Küçük resimlerin sayısı ve sırası önceden tanımlanmış [HandoutType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/handouttype/) değerleriyle kontrol edilir. Bu el ilanı düzen ayarlarıyla keyfi ızgaralar desteklenmez.

**El ilanı çıktısına gizli slaytları dahil edebilir miyim?**

Evet. Hedef format için dışa aktarma ayarlarında gizli slaytları etkinleştirin. PDF için, sunumu kaydetmeden önce `True` ile [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) çağırın.