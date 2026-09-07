---
title: "PowerPoint Sunumlarını Python'da TIFF'e Dönüştür"
linktitle: "PowerPoint'ten TIFF'e"
type: docs
weight: 90
url: /tr/python-java/convert-powerpoint-to-tiff/
keywords:
- "PowerPoint dönüştür"
- "OpenDocument dönüştür"
- "sunumu dönüştür"
- "slaytı dönüştür"
- "PPT dönüştür"
- "PPTX dönüştür"
- "PowerPoint'ten TIFF'e"
- "sunumu TIFF'e"
- "slaytı TIFF'e"
- "PPT'ten TIFF'e"
- "PPTX'ten TIFF'e"
- "PPT'yi TIFF olarak kaydet"
- "PPTX'i TIFF olarak kaydet"
- "PPT'yi TIFF'e aktar"
- "PPTX'i TIFF'e aktar"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Python via Java kullanarak PowerPoint (PPT, PPTX) sunumlarını yüksek kaliteli TIFF görüntülerine kolayca nasıl dönüştüreceğinizi, kod örnekleriyle öğrenin."
---
## **Giriş**

TIFF (**Tagged Image File Format**) raster görüntü formatıdır ve birden fazla sayfa ve kayıpsız sıkıştırma destekler. Tek bir görüntü dosyasında işlenmiş slaytları saklamak için faydalıdır.

Java üzerinden Python için Aspose.Slides kullanarak PowerPoint (PPT, PPTX) ve OpenDocument (ODP) sunumlarını TIFF’e dönüştürebilirsiniz. Aşağıdaki her örnek gerektiğinde Java sanal makinesini başlatır ve kullanım sonrası sunumu serbest bırakır. 

## **Sunumu TIFF’e Dönüştür**

[save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) yöntemi, [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfı tarafından sağlanır ve tüm PowerPoint sunumunu hızlı bir şekilde TIFF’e dönüştürmenizi sağlar. Oluşturulan çok sayfalı TIFF, varsayılan boyutta her slaytın render edilmiş görüntüsünü içerir.

Bu kod, bir PowerPoint sunumunu TIFF’e dönüştürmeyi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Tüm slaytları çok sayfalı bir TIFF dosyasına kaydedin.
    presentation.save("output.tiff", SaveFormat.Tiff)
finally:
    presentation.dispose()
```

## **Sunumu Siyah-Beyaz TIFF’e Dönüştür**

[setBwConversionMode](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tiffoptions/#setBwConversionMode) yöntemi, [TiffOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tiffoptions/) sınıfında renkli bir slaytı veya görüntüyü siyah-beyaz TIFF’e dönüştürürken kullanılan algoritmayı belirtmenizi sağlar. Bu ayarın yalnızca [setCompressionType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tiffoptions/#setCompressionType) yöntemi [TiffCompressionTypes.CCITT4](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tiffcompressiontypes/#CCITT4) veya [TiffCompressionTypes.CCITT3](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tiffcompressiontypes/#CCITT3) olarak ayarlandığında geçerli olduğuna dikkat edin.

{{% alert color="info" title="Not" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tiffoptions/#setBwConversionMode) bir dışa aktarma seviyesi ayarıdır ve tam TIFF görüntüsü için piksel dönüşüm algoritmasını seçer. Bireysel bir şeklin siyah-beyaz görünüm modunda nasıl görüneceğini tanımlamak için [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#setBlackWhiteMode) yöntemini kullanın. Örnekler için [Control Black-and-White Rendering for Shapes](/slides/tr/python-java/shape-formatting/#control-black-and-white-rendering-for-shapes) sayfasına bakın.
{{% /alert %}}

Diyelim ki aşağıdaki slaytı içeren bir "sample.pptx" dosyamız var:

![Bir sunum slaytı](slide_black_and_white.png)

Bu kod, renkli slaytı siyah-beyaz TIFF’e dönüştürmeyi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteConversionMode, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions

tiff_options = TiffOptions()
tiff_options.setCompressionType(TiffCompressionTypes.CCITT4)
tiff_options.setBwConversionMode(BlackWhiteConversionMode.Dithering)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

Sonuç:

![Siyah-Beyaz TIFF](TIFF_black_and_white.png)

## **Özel Boyutlu TIFF’e Sunumu Dönüştür**

Eğer belirli boyutlarda bir TIFF görüntüsü istiyorsanız, [TiffOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tiffoptions/) sınıfında bulunan yöntemlerle istediğiniz değerleri ayarlayabilirsiniz. Örneğin, [setImageSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tiffoptions/#setImageSize) yöntemi elde edilecek görüntünün boyutunu tanımlamanızı sağlar.

Bu kod, bir PowerPoint sunumunu özel boyutlu TIFF görüntülerine dönüştürmeyi gösterir:

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setCompressionType(TiffCompressionTypes.Default)

    # Yatay ve dikey çözünürlüğü ayarlayın.
    tiff_options.setDpiX(200)
    tiff_options.setDpiY(200)

    # Çıktı boyutlarını piksel olarak ayarlayın.
    image_size = Dimension(1728, 1078)
    tiff_options.setImageSize(image_size)

    # Her slaytın altına tam konuşmacı notlarını ekleyin.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    tiff_options.setSlidesLayoutOptions(notes_options)

    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

## **Özel Görüntü Piksel Biçimiyle TIFF’e Sunumu Dönüştür**

[setPixelFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tiffoptions/#setPixelFormat) yöntemini kullanarak, elde edilecek TIFF görüntüsü için tercih ettiğiniz piksel biçimini belirtebilirsiniz.

Bu kod, bir PowerPoint sunumunu özel piksel biçimli TIFF görüntüsüne dönüştürmeyi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImagePixelFormat, Presentation, SaveFormat, TiffOptions

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setPixelFormat(ImagePixelFormat.Format8bppIndexed)

    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

{{% alert title="İpucu" color="success" %}}
Aspose'un [ÜCRETSİZ PowerPoint'ten Poster dönüştürücüsü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) hizmetine göz atın.
{{% /alert %}}

## **SSS**

**Bir sunumu tamamen değil, tek bir slaytı TIFF’e dönüştürebilir miyim?**

Evet. Aspose.Slides, PowerPoint ve OpenDocument sunumlarından tek tek slaytları ayrı ayrı TIFF görüntülerine dönüştürmenize olanak tanır.

**Sunumu TIFF’e dönüştürürken slayt sayısında bir limit var mı?**

TIFF dışa aktarma için sabit bir slayt sayısı limiti yoktur. Kullanılabilir bellek, slayt karmaşıklığı ve çıktı boyutları işleyebileceğiniz sunumların büyüklüğünü etkiler.

**PowerPoint animasyonları ve geçiş efektleri slaytlar TIFF’e dönüştürüldüğünde korunur mu?**

Hayır, TIFF statik bir görüntü formatıdır. Bu nedenle animasyonlar ve geçiş efektleri korunmaz; sadece slaytların statik anlık görüntüleri dışa aktarılır.