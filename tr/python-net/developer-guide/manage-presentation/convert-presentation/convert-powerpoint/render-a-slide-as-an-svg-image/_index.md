---
title: Python'da Sunum Slaytlarını SVG Görüntüleri Olarak Render Et
linktitle: Slayttan SVG'ye
type: docs
weight: 50
url: /tr/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint'ten SVG'ye
- sunumdan SVG'ye
- slayttan SVG'ye
- PPT'den SVG'ye
- PPTX'ten SVG'ye
- SVG dışa aktarma seçenekleri
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Python'da PowerPoint slaytlarını SVG görüntüleri olarak dışa aktarın ve Aspose.Slides ile yazı tiplerini, metni ve görüntüleri kontrol edin."
---
## **Overview**

SVG, web yayıncılığı, slayt görüntüleyicileri, erişilebilirlik iş akışları ve otomatik sonrası işleme için iyi çalışan ölçeklenebilir XML tabanlı bir görüntü formatıdır. Aspose.Slides, her slaytı ayrı bir SVG dosyasına dışa aktarır ve metin, yazı tipleri, resimler ve SVG öğelerinin nasıl yazılacağını kontrol etmenizi sağlar.

Dışa aktarılan SVG'nin kompakt, tarayıcılar arasında öngörülebilir veya etkileşimli kullanım için hazır olması gerektiğinde [SVGOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/svgoptions/) kullanın.

## **Export a Slide as SVG**

Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) oluşturun, bir slaytı seçin ve bir akıma yazın. Aşağıdaki örnek, bir sunumdaki her slaytı ayrı bir SVG dosyası olarak dışa aktarır.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Dosya adı, döngü indeksinin yerine [Slide.slide_number](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/slide_number/) kullanır. Bir slayt görüntüleyicisinin veya web sayfasının yalnızca o şekle ihtiyacı olduğunda, [Shape.write_as_svg](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/write_as_svg/) ile tek bir şekli de dışa aktarabilirsiniz.

## **Configure SVG Output**

[SVGOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/svgoptions/) SVG oluşturmayı kontrol eder. Metin çerçeveleri için, [SVGOptions.use_frame_size](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/svgoptions/use_frame_size/) metin çerçevesini oluşturma alanına dahil eder ve [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) çerçeve dönüşünün uygulanıp uygulanmayacağını belirler. Metnin ligatürsüz render edilmesi gerektiğinde [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) değerini `True` olarak ayarlayın.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.disable_font_ligatures = True
    svg_options.use_frame_size = True
    svg_options.use_frame_rotation = False

    with open("slide-with-custom-options.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **Control Text and Fonts**

### **Vectorize All Text**

[SVGOptions.vectorize_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/svgoptions/vectorize_text/) değerini `True` olarak ayarlayarak tüm slayt metnini vektör grafik olarak yazın. Bu, yazı tipi bağımlılıklarını ortadan kaldırır ve görsel sonucu tarayıcılar arasında daha tutarlı yapar, ancak metin artık SVG metni olarak seçilemez veya aranamaz.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Choose How External Fonts Are Handled**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) dışarıdan yüklü yazı tipleri için bir [SvgExternalFontsHandling](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/svgexternalfontshandling/) değeri kullanır. Ayrı font dosyalarına referans vermek için `ADD_LINKS_TO_FONT_FILES`, font verisini SVG'ye dahil etmek için `EMBED` veya dış yazı tipleri kullanan metni grafik olarak render etmek için `VECTORIZE` seçeneğini seçin. Fontları gömmeden önce lisanslamayı doğrulayın.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    linked_fonts_options = slides.export.SVGOptions()
    linked_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.ADD_LINKS_TO_FONT_FILES

    with open("slide-with-font-links.svg", "wb") as linked_fonts_stream:
        presentation.slides[0].write_as_svg(linked_fonts_stream, linked_fonts_options)

    embedded_fonts_options = slides.export.SVGOptions()
    embedded_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.EMBED

    with open("slide-with-embedded-fonts.svg", "wb") as embedded_fonts_stream:
        presentation.slides[0].write_as_svg(embedded_fonts_stream, embedded_fonts_options)

    vectorized_external_fonts_options = slides.export.SVGOptions()
    vectorized_external_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.VECTORIZE

    with open("slide-with-vectorized-external-fonts.svg", "wb") as vectorized_external_fonts_stream:
        presentation.slides[0].write_as_svg(vectorized_external_fonts_stream, vectorized_external_fonts_options)
```

## **Reduce Embedded Image Size**

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/svgoptions/pictures_compression/) kullanarak gömülü resimlerin çözünürlüğünü düşürün, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) ile kırpılmış kaynak alanlarını atlayın ve [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/svgoptions/jpeg_quality/) ile JPEG kodlama kalitesini kontrol edin. Bu ayarlar, dosya boyutunu azaltır ancak görüntü doğruluğu veya tutulan görüntü verisi karşılığında.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.pictures_compression = slides.export.PicturesCompression.DPI150
    svg_options.delete_pictures_cropped_areas = True
    svg_options.jpeg_quality = 80

    with open("compressed-slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **FAQ**

**[SVGOptions.vectorize_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/svgoptions/vectorize_text/) yerine [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/svgexternalfontshandling/) ne zaman kullanılmalıdır?**

[SVGOptions.vectorize_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/svgoptions/vectorize_text/) tüm metnin yazı tiplerinden bağımsız olması gerektiğinde kullanın. [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/svgexternalfontshandling/) sadece dış yazı tipleri kullanan metnin grafiklere dönüştürülmesi gerektiğinde kullanın.

**Bir SVG'yi daha küçük yapmak için en iyi yöntem nedir?**

İlk olarak gömülü resimleri sıkıştırın, kırpılmış görüntü alanlarını silin ve hedef ortam bu dosyaları sunabiliyorsa bağlanmış font dosyalarını seçin. Sonucu test edin; çünkü daha düşük görüntü çözünürlüğü, daha düşük JPEG kalitesi ve vektörleştirilmiş metin her biri farklı kalite ve boyut dengelerine sahiptir.