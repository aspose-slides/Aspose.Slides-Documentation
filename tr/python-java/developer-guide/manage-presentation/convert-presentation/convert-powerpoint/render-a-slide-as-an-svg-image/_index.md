---
title: Python ile Java üzerinden Sunum Slaytlarını SVG Görüntüleri Olarak Render Et
linktitle: Slaytı SVG'ye
type: docs
weight: 50
url: /tr/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint'ten SVG'ye
- sunumdan SVG'ye
- slayttan SVG'ye
- PPT'den SVG'ye
- PPTX'ten SVG'ye
- SVG dışa aktarma seçenekleri
- etkileşimli SVG
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "PowerPoint slaytlarını Python'da Java aracılığıyla SVG görüntüleri olarak dışa aktarın ve Aspose.Slides ile yazı tiplerini, metni, görselleri, kimlikleri ve olayları kontrol edin."
---
## **Genel Bakış**

SVG, web yayıncılığı, slayt görüntüleyicileri, erişilebilirlik iş akışları ve otomatik sonrası işlem için iyi çalışan ölçeklenebilir bir XML tabanlı görüntü formatıdır. Aspose.Slides her slaytı ayrı bir SVG dosyasına dışa aktarır ve metin, yazı tipleri, resimler ve SVG öğelerinin nasıl yazılacağını kontrol etmenizi sağlar.

Dışa aktarılan SVG'nin sıkışık, tarayıcılar arasında öngörülebilir veya etkileşimli kullanım için hazır olması gerektiğinde [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) kullanın.

## **Slaytı SVG Olarak Dışa Aktarma**

Create a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), bir slaytı seçin ve [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) ile bir akıma yazın. Örnekler mevcut bir `presentation.pptx` dosyası gerektirir. Her örnek gerektiğinde JVM'yi başlatır ve çıktı akışlarını kapatır. Aşağıdaki örnek, bir sunumdaki her slaytı ayrı bir SVG dosyası olarak dışa aktarır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        output_file_name = f"slide-{slide.getSlideNumber()}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Dosya adı döngü indeksi yerine [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) kullanır. Bir slayt görüntüleyicisinin veya web sayfasının yalnızca o şekle ihtiyacı olduğunda [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) ile tek bir şekli de dışa aktarabilirsiniz.

## **SVG Çıktısını Yapılandırma**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) SVG renderlemesini kontrol eder. Metin çerçeveleri için [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) metin çerçevesini renderleme alanına dahil eder ve [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) çerçeve dönüşünün uygulanıp uygulanmayacağını belirler. Metnin ligatürsüz renderlenmesi gerektiğinde [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) değerini `True` olarak ayarlayın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setDisableFontLigatures(True)
    svg_options.setUseFrameSize(True)
    svg_options.setUseFrameRotation(False)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-custom-options.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Metin ve Yazı Tiplerini Kontrol Etme**

Slaytları SVG'ye dışa aktarırken, metnin metin olarak kalıp kalmayacağını veya vektör grafiklere dönüştürülüp dönüştürülmeyeceğini ve dış yazı tiplerinin nasıl dahil edileceğini veya başvurulacağını kontrol edebilirsiniz. Aşağıdaki seçenekler, dışa aktarılan SVG'de görsel tutarlılık, metin seçimi ve yazı tipi bağımlılıklarını dengelemenize yardımcı olur.

### **Tüm Metni Vektörleştir**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) değerini `True` olarak ayarlayın; böylece tüm slayt metni vektör grafik olarak yazılır. Bu, yazı tipi bağımlılıklarını ortadan kaldırır ve görsel sonucu tarayıcılar arasında daha tutarlı hâle getirir, ancak metin artık SVG metni olarak seçilemez veya aranamaz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setVectorizeText(True)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-vectorized-text.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

### **Dış Yazı Tiplerinin Nasıl İşleneceğini Seçin**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) harici olarak yüklenen yazı tipleri için bir [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) değeri kullanır. Ayrı yazı tipi dosyalarına başvurmak için `AddLinksToFontFiles`, yazı tipi verisini SVG'ye dahil etmek için `Embed` veya harici yazı tipleri kullanan metni yalnızca grafik olarak renderlemek için `Vectorize` seçin. Yazı tiplerini gömmeden önce lisanslamayı doğrulayın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgExternalFontsHandling
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    font_modes = [
        ("slide-with-font-links.svg", SvgExternalFontsHandling.AddLinksToFontFiles),
        ("slide-with-embedded-fonts.svg", SvgExternalFontsHandling.Embed),
        ("slide-with-vectorized-external-fonts.svg", SvgExternalFontsHandling.Vectorize),
    ]
    for output_file_name, font_mode in font_modes:
        svg_options = SVGOptions()
        svg_options.setExternalFontsHandling(font_mode)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

## **Gömülü Görüntü Boyutunu Azaltma**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) gömülü resimlerin çözünürlüğünü azaltmak için kullanın, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) kırpılmış kaynak alanlarını atlamak için ve [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) JPEG kodlama kalitesini kontrol etmek için kullanın. Bu ayarlar, görüntü doğruluğu veya tutulan görüntü verisi maliyetine karşı dosya boyutunu azaltır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setPicturesCompression(PicturesCompression.Dpi150)
    svg_options.setDeletePicturesCroppedAreas(True)
    svg_options.setJpegQuality(80)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("compressed-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Metafile Rasterizasyon Çözünürlüğünü Kontrol Etme**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) SVG dışa aktarım sırasında metafile'ların rasterleştirilmesi için alt çözünürlük sınırını belirler. Bir EMF veya WMF görüntüsü rasterleştirildiğinde ayrıntı ve dosya boyutunu dengelemek için kullanın. Bu, SVG için küresel bir DPI tanımlamaz veya slayttaki her nesneyi raster görüntüye zorlamaz.

[metafile-rasterization.pptx](metafile-rasterization.pptx) dosyasını indirin; bu dosya sıkışık çapraz çizgilere sahip bir EMF görüntüsü içerir. Aşağıdaki örnek, ilk slaydını [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) aracılığıyla üç rasterleştirme çözünürlüğünde dışa aktarır. Diğer tüm dışa aktarma ayarları aynı kalır, böylece sonuçlar karşılaştırılabilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("metafile-rasterization.pptx")
try:
    for dpi in [72, 150, 300]:
        svg_options = SVGOptions()
        svg_options.setMetafileRasterizationDpi(dpi)
        svg_options.setPicturesCompression(PicturesCompression.Dpi330)
        svg_options.setJpegQuality(90)

        output_file_name = f"slide-{dpi}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            presentation.getSlides().get_Item(0).writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()

```

Çıktıda, EMF her SVG'de bir gömülü PNG'ye dönüştü. Aşağıdaki ölçümler sağlanan sunum içindir; DPI'yi piksel boyutlarına dönüştürmek için genel bir formül değildir.

| Metafile rasterizasyon DPI | Gömülü PNG boyutları | SVG dosya boyutu (bayt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Aşağıdaki karşılaştırma, gömülü rasterin aynı alanını aynı büyütülmüş görüntü boyutunda gösterir. Çapraz çizgiler 72 DPI'de belirgin pikselleşme ve daha yüksek çözünürlüklerde daha pürüzsüz kenarlar gösterirken, SVG dosyası büyür. Değeri artırmak her ayrıntıyı mutlaka iyileştirmez veya her dışa aktarılan görüntüyü değiştirmez.

![72, 150 ve 300 DPI'de büyütülmüş çapraz çizgi detayı](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) görüntü çözünürlüğü düşürmeyi kontrol eder ve metafile rasterleme çözünürlüğündeki değişikliğin etkisini maskeleyebilir. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) JPEG kodlama kalitesini kontrol eder, metafile rasterleme çözünürlüğünü değil.

## **Şekillere ve Metne Kararlı Kimlikler Atama**

`jpype.JProxy` aracılığıyla kaydedilen bir Python biçimlendirme denetleyicisini kullanarak şekillere [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) değerlerini ve metin `tspan` öğelerine [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) değerlerini atayın. Proxy'yi [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) ile atayın.

Aşağıdaki denetleyici, şeklin ömrü boyunca kararlı olan [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId) ve metin arcaları için tekrar edilebilir bir sayaç kullanır. Bu, oluşturulan kimliklerin değişmemiş bir sunumun son işlemine uygun olmasını sağlar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

class StableSvgIdController:
    def __init__(self):
        self.current_shape_id = ""
        self.text_span_index = 0

    def formatShape(self, svg_shape, shape):
        self.current_shape_id = f"shape-{shape.getOfficeInteropShapeId()}"
        self.text_span_index = 0
        svg_shape.setId(self.current_shape_id)

    def formatText(self, svg_tspan, portion, text_frame):
        svg_tspan.setId(f"{self.current_shape_id}-text-{self.text_span_index}")
        self.text_span_index += 1


presentation = Presentation("presentation.pptx")
try:
    controller = StableSvgIdController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeAndTextFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-stable-ids.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **SVG Olay İşleyicileri Ekleme**

Bir Python biçimlendirme denetleyicisinde, dışa aktarılan bir şekle JavaScript olay işleyicisi eklemek için [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) metodunu bir [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) değeriyle çağırın. Denetleyiciyi `jpype.JProxy` aracılığıyla kaydedin ve [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) ile atayın. Sonucu barındıran sayfada veya SVG belgesinde JavaScript fonksiyonunu tanımlayın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgEvent
from java.io import FileOutputStream

class SvgEventController:
    def formatShape(self, svg_shape, shape):
        if shape.getName() == "ActionButton":
            svg_shape.setId("action-button")
            svg_shape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)")


presentation = Presentation("presentation.pptx")
try:
    controller = SvgEventController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("interactive-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

Sunucu sayfa, işleyici tarafından başvurulan JavaScript fonksiyonunu tanımlayabilir. Kimliklerin ve olay işleyicilerin atanması, slayt görüntüleyicileri, erişilebilirlik iyileştirmeleri ve diğer etkileşimli SVG iş akışlarını mümkün kılar.

## **SSS**

**[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) yerine [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) ne zaman kullanılmalı?**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText), tüm metnin yazı tiplerinden bağımsız olması gerektiğinde kullanın. [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize), yalnızca dış yazı tipleri kullanan metnin grafiklere dönüştürülmesi gerektiğinde kullanın.

**SVG'yi daha küçük yapmanın en iyi yolu nedir?**

Önce gömülü resimleri sıkıştırın, kırpılmış görüntü alanlarını silin ve hedef ortam bunları sunabiliyorsa bağlanmış yazı tipi dosyalarını seçin. Sonucu test edin; çünkü düşük görüntü çözünürlüğü, düşük JPEG kalitesi ve vektörleştirilmiş metin her biri farklı kalite ve boyut dengeleri sunar.

**Dışa aktarılmış SVG öğelerini dışa aktarımdan sonra değiştirebilir miyim?**

Evet. Bir biçimlendirme denetleyicisi aracılığıyla kimlikler atayın, ardından eşleşen SVG öğelerini sonrası işlem aracınızda veya tarayıcı betiğinizde seçin.