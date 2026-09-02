---
title: Python'da PowerPoint Sunumlarını TIFF'e Dönüştür
titlelink: PowerPoint'ten TIFF'e
type: docs
weight: 90
url: /tr/python-net/convert-powerpoint-to-tiff/
keywords:
- PowerPoint dönüştür
- OpenDocument dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PowerPoint'ten TIFF'e
- OpenDocument'ten TIFF'e
- sunumdan TIFF'e
- slayttan TIFF'e
- PPT'den TIFF'e
- PPTX'den TIFF'e
- ODP'den TIFF'e
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint (PPT, PPTX) ve OpenDocument (ODP) sunumlarını yüksek kaliteli TIFF görüntülerine kolayca nasıl dönüştüreceğinizi öğrenin. Kod örnekleri dahil adım adım rehber."
---
## **Giriş**

TIFF (**Tagged Image File Format**) yaygın olarak kullanılan, kayıpsız bir raster görüntü formatıdır ve olağanüstü kalitesi ve grafiklerin ayrıntılı korunmasıyla bilinir. Tasarımcılar, fotoğrafçılar ve masaüstü yayıncıları genellikle görüntülerinde katmanları, renk doğruluğunu ve orijinal ayarları korumak için TIFF'i seçer.

Aspose.Slides kullanarak, PowerPoint slaytlarınızı (PPT, PPTX) ve OpenDocument slaytlarını (ODP) doğrudan yüksek kaliteli TIFF görüntülerine zahmetsizce dönüştürebilir, sunumlarınızın maksimum görsel doğruluğunu korumasını sağlayabilirsiniz.

## **Bir Sunumu TIFF'e Dönüştür**

Sunum sınıfı tarafından sağlanan [save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/#methods) yöntemini kullanarak, tüm bir PowerPoint sunumunu hızlıca TIFF'e dönüştürebilirsiniz. Oluşan TIFF görüntüleri varsayılan slayt boyutuna karşılık gelir.

Bu Python kodu, bir PowerPoint sunumunu TIFF'e nasıl dönüştüreceğinizi gösterir:

```py
import aspose.slides as slides

# Sunum dosyasını (PPT, PPTX, ODP vb.) temsil eden Presentation sınıfının bir örneğini oluşturur.
with slides.Presentation("presentation.pptx") as presentation:
    # Sunumu TIFF olarak kaydeder.
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF)
```

## **Bir Sunumu Siyah-Beyaz TIFF'e Dönüştür**

[TiffOptions] sınıfındaki [bw_conversion_mode](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) özelliği, renkli bir slaytı veya görüntüyü siyah-beyaz TIFF'e dönüştürürken kullanılacak algoritmayı belirtmenizi sağlar. Bu ayarın yalnızca [compression_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/compression_type/) özelliği `CCITT4` veya `CCITT3` olarak ayarlandığında geçerli olduğunu unutmayın.

{{% alert color="info" title="Not" %}}

[TiffOptions.bw_conversion_mode](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) bir dışa aktarma düzeyi ayarıdır ve tam TIFF görüntüsü için bir piksel dönüşüm algoritması seçer. Bireysel bir şeklin siyah-beyaz görüntüleme modunda nasıl görünmesi gerektiğini belirlemek için [Shape.black_white_mode](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/black_white_mode/) özelliğini kullanın. Örnekler için [Control Black-and-White Rendering for Shapes](/python-net/shape-formatting/#control-black-and-white-rendering-for-shapes) bölümüne bakın.

{{% /alert %}}

Diyelim ki aşağıdaki slaytı içeren bir "sample.pptx" dosyamız var:

![Bir sunum slaytı](slide_black_and_white.png)

Bu Python kodu, renkli slaytı siyah-beyaz TIFF'e nasıl dönüştüreceğinizi gösterir:

```py
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

Sonuç:

![Siyah-Beyaz TIFF](TIFF_black_and_white.png)

## **Bir Sunumu Özel Boyutlu TIFF'e Dönüştür**

Eğer belirli boyutlarda bir TIFF görüntüsü gerekiyorsa, [TiffOptions] sınıfında bulunan özellikleri kullanarak istediğiniz değerleri ayarlayabilirsiniz. Örneğin, [image_size](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/image_size/) özelliği oluşturulan görüntünün boyutunu tanımlamanıza olanak verir.

Bu Python kodu, bir PowerPoint sunumunu özel boyutlu TIFF görüntülerine nasıl dönüştüreceğinizi gösterir:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

# Sunum dosyasını (PPT, PPTX, ODP vb.) temsil eden Presentation sınıfının bir örneğini oluşturur.
with slides.Presentation("sample.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    # Sıkıştırma tipini ayarlar.
    tiff_options.compression_type = slides.export.TiffCompressionTypes.DEFAULT
    """
    Compression types:
        Default - Specifies the default compression scheme (LZW).
        None - Specifies no compression.
        CCITT3
        CCITT4
        LZW
        RLE
    """

    # Görüntü DPI'sını ayarlar.
    tiff_options.dpi_x = 200
    tiff_options.dpi_y = 200

    # Görüntü boyutunu ayarlar.
    tiff_options.image_size = drawing.Size(1728, 1078)

    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL
    tiff_options.slides_layout_options = notes_options

    # Sunumu belirtilen boyutta TIFF olarak kaydeder.
    presentation.save("custom_size.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

## **Bir Sunumu Özel Görüntü Piksel Formatı ile TIFF'e Dönüştür**

[TiffOptions] sınıfındaki [pixel_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/tiffoptions/pixel_format/) özelliğini kullanarak, elde edilen TIFF görüntüsü için tercih ettiğiniz piksel formatını belirtebilirsiniz.

Bu Python kodu, bir PowerPoint sunumunu özel piksel formatlı bir TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir:

```py
import aspose.slides as slides

# Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfının bir örneğini oluşturur.
with slides.Presentation("Presentation.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    tiff_options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED
    """
    ImagePixelFormat aşağıdaki değerleri içerir (belgelendirmede belirtildiği gibi):
        FORMAT_1BPP_INDEXED - piksel başına 1 bit, indeksli.
        FORMAT_4BPP_INDEXED - piksel başına 4 bit, indeksli.
        FORMAT_8BPP_INDEXED - piksel başına 8 bit, indeksli.
        FORMAT_24BPP_RGB    - piksel başına 24 bit, RGB.
        FORMAT_32BPP_ARGB   - piksel başına 32 bit, ARGB.
    """

    # Sunumu belirtilen piksel formatı ile TIFF olarak kaydeder.
    presentation.save("Custom_Image_Pixel_Format.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

{{% alert title="İpucu" color="info" %}}

Aspose'un [ÜCRETSİZ PowerPoint'ten Poster dönüştürücüsü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) ürününe bir göz atın.

{{% /alert %}}

## **SSS**

**Bir PowerPoint sunumunun tamamı yerine tek bir slaytı TIFF'e dönüştürebilir miyim?**

Evet. Aspose.Slides, PowerPoint ve OpenDocument sunumlardan tek tek slaytları ayrı ayrı TIFF görüntülerine dönüştürmenize olanak tanır.

**Sunumu TIFF'e dönüştürürken slayt sayısı için bir limit var mı?**

Hayır, Aspose.Slides slayt sayısı üzerinde herhangi bir kısıtlama getirmez. Herhangi bir boyuttaki sunumları TIFF formatına dönüştürebilirsiniz.

**PowerPoint animasyonları ve geçiş efektleri slaytları TIFF'e dönüştürürken korunur mu?**

Hayır, TIFF statik bir görüntü formatıdır. Bu nedenle animasyonlar ve geçiş efektleri korunmaz; yalnızca slaytların statik anlık görüntüleri dışa aktarılır.