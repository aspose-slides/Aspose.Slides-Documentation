---
title: Python'da Sunum Slaytlarını SVG Görüntülerine Dönüştür
linktitle: Slaytı SVG'ye
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
description: "PowerPoint slaytlarını Python'da SVG görüntüleri olarak dışa aktarın ve Aspose.Slides ile yazı tiplerini, metni ve görüntüleri kontrol edin."
---
## **Genel Bakış**

SVG, web yayıncılığı, slayt görüntüleyicileri, erişilebilirlik iş akışları ve otomatik sonrası işleme için iyi çalışan ölçeklenebilir bir XML tabanlı görüntü formatıdır. Aspose.Slides, her slaytı ayrı bir SVG dosyasına dışa aktarır ve metin, yazı tipleri, resimler ve SVG öğelerinin nasıl yazılacağını kontrol etmenizi sağlar.

Use [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) when the exported SVG must be compact, predictable across browsers, or ready for interactive use.

## **Slaytı SVG Olarak Dışa Aktarma**

Create a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), select a slide, and write it to a stream. The following example exports every slide in a presentation as a separate SVG file.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

The filename uses [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) rather than the loop index. You can also export an individual shape with [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) when a slide viewer or web page needs only that shape.

## **SVG Çıktısını Yapılandırma**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) controls SVG rendering. For text frames, [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) includes the text frame in the rendering area, and [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) determines whether the frame rotation is applied. Set [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) to `True` when text must be rendered without ligatures.

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

## **Ok Uçlarında Çizgi Sonu Kırpmasını Kontrol Etme**

SVG 1.1, bir çizginin ok ucunun altında nerede durması gerektiğini belirtmek için bir işaretçi içi ayarı sağlamaz. Varsayılan olarak, Aspose.Slides dışa aktarılan çizgiyi, çizgi boyasının işaretçiye çıkıntı yapmaması için kısaltır. Set [SVGOptions.disable_line_end_cropping](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_line_end_cropping/) to `True` to draw the stroke all the way to the line's original endpoint. This setting affects only the SVG output. The line keeps its position and length on the slide.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    y = 40

    for style in (slides.LineArrowheadStyle.TRIANGLE, slides.LineArrowheadStyle.DIAMOND):
        for width in (2, 10):
            line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 40, y, 200, 0)
            line_format = line.line_format
            line_format.fill_format.fill_type = slides.FillType.SOLID
            line_format.fill_format.solid_fill_color.color = drawing.Color.dark_blue
            line_format.width = width
            line_format.end_arrowhead_style = style
            y += 50

    options = slides.export.SVGOptions()
    options.disable_line_end_cropping = False
    with open("cropped.svg", "wb") as cropped:
        slide.write_as_svg(cropped, options)

    options.disable_line_end_cropping = True
    with open("uncropped.svg", "wb") as uncropped:
        slide.write_as_svg(uncropped, options)
```

The comparison shows the triangular arrowhead on the 10-point line. With cropping enabled, the tip is sharp. With cropping disabled, the stroke protrudes through the sloping sides of the marker and leaves a flat end.

![Kırpma etkinleştirildiğinde keskin uçlu, kırpma devre dışı bırakıldığında düz uçlu büyütülmüş 10 puanlık üçgen](line-end-cropping.png)

In the other lines from the example, the protruding stroke is less visible on the 2-point triangle. The filled diamond covers the end of the stroke at both widths.

## **Metin ve Yazı Tiplerini Kontrol Etme**

When exporting slides to SVG, you can control whether text remains as text or is converted to vector graphics, and how external fonts are included or referenced. The following options help you balance visual consistency, text selection, and font dependencies in the exported SVG.

### **Tüm Metni Vektörleştir**

Set [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) to `True` to write all slide text as vector graphics. This eliminates font dependencies and makes the visual result more consistent across browsers, but the text is no longer selectable or searchable as SVG text.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Harici Yazı Tiplerinin Nasıl Ele Alındığını Seçin**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) uses a [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) value for fonts that are loaded externally. Choose `ADD_LINKS_TO_FONT_FILES` to reference separate font files, `EMBED` to include font data in the SVG, or `VECTORIZE` to render only text that uses external fonts as graphics. Verify font licensing before embedding fonts.

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

## **Gömülü Görüntü Boyutunu Küçültme**

Use [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) to reduce the resolution of embedded pictures, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) to omit cropped source areas, and [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) to control JPEG encoding quality. These settings reduce file size at the cost of image fidelity or retained image data.

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

## **Metafile Rasterizasyon Çözünürlüğünü Kontrol Etme**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) sets the lower resolution limit for rasterizing metafiles during SVG export. Use it to balance detail and file size when an EMF or WMF image is rasterized. It does not define a global DPI for the SVG or force every object on the slide to become a raster image.

Download [metafile-rasterization.pptx](metafile-rasterization.pptx), which contains an EMF image with closely spaced diagonal lines. The following example exports its first slide at three rasterization resolutions through [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). All other export settings remain identical so that the results can be compared.

```py
import aspose.slides as slides

with slides.Presentation("metafile-rasterization.pptx") as presentation:
    for dpi in (72, 150, 300):
        svg_options = slides.export.SVGOptions()
        svg_options.metafile_rasterization_dpi = dpi
        svg_options.pictures_compression = slides.export.PicturesCompression.DPI330
        svg_options.jpeg_quality = 90

        with open("slide-{}.svg".format(dpi), "wb") as svg_stream:
            presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

In the output, the EMF became one embedded PNG in each SVG. The following measurements are for the supplied presentation; they are not a general formula for converting DPI to pixel dimensions.

| Metafile rasterizasyon DPI | Gömülü PNG boyutları | SVG dosya boyutu (bayt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

The comparison below shows the same area of the embedded raster at the same enlarged display size. The diagonal lines show visible pixelation at 72 DPI and smoother edges at higher resolutions, while the SVG file grows. Increasing the value does not necessarily improve every detail or change every exported image.

![72, 150 ve 300 DPI'de büyütülmüş çapraz hat detayları](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) controls image resolution reduction and can mask the effect of changing the metafile rasterization resolution. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) controls JPEG encoding quality, not metafile rasterization resolution.

## **SSS**

**When should I use [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) instead of [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Use [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) when all text must be independent of fonts. Use [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) when only text that uses external fonts should be converted to graphics.

**What is the best way to make an SVG smaller?**

Start by compressing embedded pictures, deleting cropped image areas, and choosing linked font files when the target environment can serve them. Test the result because lower image resolution, lower JPEG quality, and vectorized text each have different quality and size tradeoffs.