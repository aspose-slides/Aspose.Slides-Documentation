---
title: PowerPoint Sunumlarını El İlanı Modunda Python Kullanarak Dönüştür
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
description: "Python via Java ile PowerPoint sunumlarını el ilanına dönüştürün. Bir sayfada birden çok slaytı düzenleyin ve Aspose.Slides ile PDF olarak dışa aktarın."
---
## **Giriş**

Aspose.Slides for Python via Java, birden çok slaytı tek bir sayfada düzenleyerek sunumları el ilanı modunda dışa aktarmanıza olanak tanır. Bu, konferanslar, seminerler ve benzeri etkinlikler için sunum materyallerini yazdırırken kullanışlıdır.

Düzeni, [setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) yöntemiyle yapılandırın. El ilanı düzenleri, [PdfOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/htmloptions/), ve [TiffOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tiffoptions/) tarafından desteklenir. Düzeni ve görüntüleme ayarlarını belirtmek için bir [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/handoutlayoutingoptions/) nesnesi kullanın.

## **El İlanı Modu Dışa Aktarma**

El ilanı modunda bir sunumu dışa aktarmak için bir [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/handoutlayoutingoptions/) örneği oluşturun ve bunu hedef dışa aktarma seçeneklerine [setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) ile atayın.

Aşağıdaki örnek, `sample.pptx` dosyasını yükler ve sayfa başına dört slayt olacak şekilde yatay sırayla PDF olarak dışa aktarır. Slayt numaralarını ve slaytların etrafındaki çerçeveleri içerir, yorumları dışarıda bırakır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# Bir sunumu yükleyin.
presentation = Presentation("sample.pptx")
try:
    # El ilanı düzenini yapılandırın.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # Sunumu seçilen düzenle PDF olarak dışa aktarın.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Uyarı" %}}
El ilanı düzeni ayarları, PDF, HTML, TIFF ve oluşturulan görüntüler gibi desteklenen çıktı biçimlerine uygulanır. Kaynak sunumdaki slaytların sırasını değiştirmez.
{{% /alert %}}

## **SSS**

**El ilanı modunda sayfa başına maksimum kaç slayt küçük resmi bulunabilir?**

Aspose.Slides, sayfa başına en fazla dokuz küçük resmi destekler. [HandoutType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/handouttype/) ön ayarları, sayfa başına bir, iki, üç, dört, altı veya dokuz slayt sağlar. Dört, altı ve dokuz slayt ön ayarları yatay ve dikey sıralamayı sunar.

**Beş veya sekiz slayt gibi özel bir ızgara tanımlayabilir miyim?**

Hayır. Küçük resim sayısı ve sıralaması, önceden tanımlanmış [HandoutType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/handouttype/) değerleri tarafından kontrol edilir. Bu el ilanı düzeni ayarlarıyla keyfi ızgaralar desteklenmez.

**El ilanı çıktısına gizli slaytları dahil edebilir miyim?**

Evet. Hedef format için dışa aktarma ayarlarında gizli slaytları etkinleştirin. PDF için, sunumu kaydetmeden önce [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) yöntemini `True` ile çağırın.