---
title: Python üzerinden Java ile Sunum Slaytlarını SVG Görüntüleri Olarak Render Et
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
description: "PowerPoint slaytlarını Python üzerinden Java ile SVG görüntüleri olarak dışa aktarın ve Aspose.Slides ile yazı tiplerini, metni, görüntüleri, kimlikleri ve olayları kontrol edin."
---
## **Genel Bakış**

SVG, web yayıncılığı, slayt görüntüleyicileri, erişilebilirlik iş akışları ve otomatik son işleme için iyi çalışan ölçeklenebilir XML tabanlı bir görüntü formatıdır. Aspose.Slides, her slaytı ayrı bir SVG dosyasına dışa aktarır ve metin, yazı tipleri, resimler ve SVG öğelerinin nasıl yazılacağını kontrol etmenizi sağlar.

Dışa aktarılan SVG'nin sıkı, tarayıcılar arasında öngörülebilir veya etkileşimli kullanım için hazır olması gerektiğinde [SVGOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgoptions/) kullanın.

## **Bir Slaytı SVG Olarak Dışa Aktarın**

Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) oluşturun, bir slayt seçin ve [Slide.writeAsSvg](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/) ile bir akışa yazın. Örnekler mevcut bir `presentation.pptx` dosyası gerektirir. Her örnek gerektiğinde JVM'yi başlatır ve çıktı akışlarını kapatır. Aşağıdaki örnek, bir sunumdaki tüm slaytları ayrı ayrı SVG dosyalarına dışa aktarır.

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

Dosya adı, döngü indeksine yerine [Slide.getSlideNumber](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getSlideNumber) kullanır. Bir slayt görüntüleyicisinin veya web sayfasının yalnızca o şekle ihtiyacı olduğunda bir şekli [Shape.writeAsSvg](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/) ile de dışa aktarabilirsiniz.

## **SVG Çıktısını Yapılandırma**

[SVGOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgoptions/) SVG oluşturmayı kontrol eder. Metin çerçeveleri için, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgoptions/#setUseFrameSize) render alanına metin çerçevesini dahil eder ve [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgoptions/#setUseFrameRotation) çerçeve dönüşünün uygulanıp uygulanmayacağını belirler. Metnin ligatürsüz render edilmesi gerektiğinde [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) değerini `True` olarak ayarlayın.

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

### **Tüm Metni Vektörleştir**

Tüm slayt metnini vektör grafiği olarak yazmak için [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgoptions/#setVectorizeText) değerini `True` olarak ayarlayın. Bu, yazı tipi bağımlılıklarını ortadan kaldırır ve görsel sonucu tarayıcılar arasında daha tutarlı hâle getirir, ancak metin artık SVG metni olarak seçilebilir veya aranabilir değildir.

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

### **Harici Yazı Tiplerinin Nasıl İşleneceğini Seçin**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) dışarıdan yüklenen yazı tipleri için bir [SvgExternalFontsHandling](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgexternalfontshandling/) değeri kullanır. Ayrı yazı tipi dosyalarına referans vermek için `AddLinksToFontFiles`, SVG'ye yazı tipi verisini eklemek için `Embed` veya dış yazı tiplerini kullanan metinleri grafik olarak render etmek için `Vectorize` seçeneğini seçin. Yazı tiplerini gömmeden önce lisanslamayı doğrulayın.

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

Gömülü resimlerin çözünürlüğünü azaltmak için [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgoptions/#setPicturesCompression), kırpılmış kaynak alanlarını dışarıda bırakmak için [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) ve JPEG kodlama kalitesini kontrol etmek için [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgoptions/#setJpegQuality) kullanın. Bu ayarlar, dosya boyutunu azaltırken görüntü doğruluğu veya tutulan görüntü verisi pahasına olur.

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

## **Şekillere ve Metne Kararlı Kimlikler Atama**

`jpype.JProxy` aracılığıyla kaydedilen bir Python biçimlendirme denetleyicisini kullanarak şekillere [SvgShape.setId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgshape/#setId) değerlerini ve metin `tspan` öğelerine [SvgTSpan.setId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgtspan/#setId) değerlerini atayın. Vekili [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgoptions/#setShapeFormattingController) ile atayın.

Aşağıdaki denetleyici, şeklin ömrü boyunca kararlı olan [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getOfficeInteropShapeId) ve metin span'ları için tekrarlanabilir bir sayacı kullanır. Bu, üretilen kimliklerin değişmemiş bir sunumun son işleminde kullanılabilir olmasını sağlar.

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

Python biçimlendirme denetleyicisinde, dışa aktarılan bir şekle JavaScript olay işleyicisi eklemek için bir [SvgEvent](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgevent/) değeriyle [SvgShape.setEventHandler](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgshape/#setEventHandler) çağırın. Denetleyiciyi `jpype.JProxy` aracılığıyla kaydedin ve [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgoptions/#setShapeFormattingController) ile atayın. Sonucu barındıran sayfada veya SVG belgesinde JavaScript işlevini tanımlayın.

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

Barındırıcı sayfa, işleyici tarafından referans verilen JavaScript işlevini tanımlayabilir. Kimliklerin ve olay işleyicilerin atanması, slayt görüntüleyicileri, erişilebilirlik iyileştirmeleri ve diğer etkileşimli SVG iş akışlarını mümkün kılar.

## **SSS**

**[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgoptions/#setVectorizeText) yerine [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) ne zaman kullanılmalı?**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgoptions/#setVectorizeText) tüm metnin yazı tiplerinden bağımsız olması gerektiğinde kullanılmalıdır. [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) yalnızca dış yazı tipleri kullanan metinlerin grafiklere dönüştürülmesi gerektiğinde kullanılmalıdır.

**Bir SVG'yi küçültmenin en iyi yolu nedir?**

Öncelikle gömülü resimleri sıkıştırın, kırpılmış görüntü alanlarını silin ve hedef ortam bunları sunabiliyorsa bağlantılı yazı tipi dosyalarını seçin. Sonucu test edin çünkü düşük görüntü çözünürlüğü, düşük JPEG kalitesi ve vektörleştirilmiş metin her biri farklı kalite ve boyut dengelemesi sunar.

**Dışa aktarılan SVG öğelerini dışa aktarımdan sonra değiştirebilir miyim?**

Evet. Bir biçimlendirme denetleyicisi aracılığıyla kimlikler atayın, ardından eşleşen SVG öğelerini son işleme aracınızda veya tarayıcı betiğinizde seçin.