---
title: Python üzerinden Java ile Sunum Slaytlarını SVG Görselleri Olarak İşleyin
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
- SVG dışa aktarım seçenekleri
- etkileşimli SVG
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "PowerPoint slaytlarını Python üzerinden Java aracılığıyla SVG görüntüleri olarak dışa aktarın ve Aspose.Slides ile yazı tiplerini, metni, görüntüleri, kimlikleri ve olayları kontrol edin."
---
## **Genel Bakış**

SVG, web yayıncılığı, slayt görüntüleyicileri, erişilebilirlik iş akışları ve otomatik son işleme için iyi çalışan ölçeklenebilir XML tabanlı bir görüntü formatıdır. Aspose.Slides her slaytı ayrı bir SVG dosyasına dışa aktarır ve metin, yazı tipleri, resimler ve SVG öğelerinin nasıl yazılacağını kontrol etmenizi sağlar.

Dışa aktarılan SVG'nin kompakt, tarayıcılar arasında öngörülebilir veya etkileşimli kullanım için hazır olması gerektiğinde [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) kullanın.

## **Bir Slaytı SVG Olarak Dışa Aktarma**

Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), oluşturun, bir slayt seçin ve onu bir akışa [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) ile yazın. Örnekler mevcut bir `presentation.pptx` dosyası gerektirir. Her örnek gerekirse JVM'yi başlatır ve çıktı akışlarını kapatır. Aşağıdaki örnek, bir sunumdaki her slaytı ayrı bir SVG dosyası olarak dışa aktarır.

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

Dosya adı, döngü indeksine göre değil [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) kullanır. Bir slayt görüntüleyicisinin veya web sayfasının yalnızca o şekle ihtiyacı olduğunda, [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) ile tek bir şekli de dışa aktarabilirsiniz.

## **SVG Çıktısını Yapılandırma**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) SVG renderini kontrol eder. Metin çerçeveleri için, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) metin çerçevesini render alanına dahil eder ve [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) çerçeve dönüşünün uygulanıp uygulanmayacağını belirler. Metin ligandları olmadan render edilmesi gerektiğinde [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) öğesini `True` olarak ayarlayın.

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

## **Ok Uçlarında Çizgi Ucu Kırpmasını Kontrol Et**

SVG 1.1, bir çizginin ok ucunun altında nerede durması gerektiğini belirten bir işaretçi iç içe ayarı içermez. Varsayılan olarak, Aspose.Slides dışa aktarılan çizgiyi kısaltır, böylece hattı işaretçinin üzerinden çıkmaz. [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableLineEndCropping) öğesini `True` ile çağırarak, hattı çizginin orijinal son noktasına kadar çizin. Bu ayar yalnızca SVG çıktısını etkiler. Çizgi, slayttaki konum ve uzunluğunu korur.

Örnek, 2 ve 10 puan genişliğindeki çizgilere üçgen ve elmas ok uçları çizer. Aynı slaytı yalnızca kırpma seçeneğini değiştirerek iki kez dışa aktarır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, Presentation, ShapeType, SVGOptions
from java.awt import Color
from java.io import FileOutputStream

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    y = 40

    for style in [LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond]:
        for width in [2, 10]:
            line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0)
            line_format = line.getLineFormat()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
            line_format.setWidth(width)
            line_format.setEndArrowheadStyle(style)
            y += 50

    svg_options = SVGOptions()
    for disable_cropping, output_file_name in [(False, "cropped.svg"), (True, "uncropped.svg")]:
        svg_options.setDisableLineEndCropping(disable_cropping)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Karşılaştırma, 10 puanlık çizgideki üçgen ok ucunu gösterir. Kırpma etkinleştirildiğinde, uç keskindir. Kırpma devre dışı bırakıldığında, hat işaretçinin eğimli kenarlarından dışarı çıkar ve düz bir uç bırakır.

![Kırpma etkin olduğunda keskin uca sahip büyütülmüş 10 puanlık üçgen ve kırpma devre dışı olduğunda düz uç](line-end-cropping.png)

Örnekteki diğer çizgilerde, çıkıntılı hat 2 puanlık üçgende daha az görülür. Dolu elmas, her iki genişlikte de hattın ucunu kapatır.

## **Metin ve Yazı Tiplerini Kontrol Et**

Slaytları SVG'ye dışa aktarırken, metnin metin olarak kalıp kalmayacağını veya vektör grafiğe dönüştürülüp dönüştürülmeyeceğini ve harici yazı tiplerinin nasıl dahil edilip başvurulacağını kontrol edebilirsiniz. Aşağıdaki seçenekler, dışa aktarılan SVG'de görsel tutarlılık, metin seçimi ve yazı tipi bağımlılıkları arasında denge kurmanıza yardımcı olur.

### **Tüm Metni Vektörleştir**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) öğesini `True` olarak ayarlayın, böylece tüm slayt metni vektör grafiği olarak yazılır. Bu, yazı tipi bağımlılıklarını ortadan kaldırır ve görsel sonucu tarayıcılar arasında daha tutarlı hâle getirir, ancak metin artık SVG metni olarak seçilemez veya aranamaz.

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

### **Harici Yazı Tiplerinin Nasıl Ele Alınacağını Seçin**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) dışarıdan yüklü yazı tipleri için bir [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) değerini kullanır. Ayrı font dosyalarına referans vermek için `AddLinksToFontFiles`, font verilerini SVG'ye eklemek için `Embed` veya dış yazı tiplerini kullanan metni yalnızca grafik olarak işlemek için `Vectorize` seçeneğini seçin. Fontları gömmeden önce lisanslamayı doğrulayın.

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

## **Gömülü Görüntü Boyutunu Azalt**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) ile gömülü resimlerin çözünürlüğünü azaltın, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) ile kırpılmış kaynak alanlarını atlayın ve [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) ile JPEG kodlama kalitesini kontrol edin. Bu ayarlar, görüntü doğruluğu veya tutulan görüntü verisi pahasına dosya boyutunu küçültür.

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

## **Metafile Tarama Çözünürlüğünü Kontrol Et**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) SVG dışa aktarımı sırasında metafile'ların taranması için alt çözünürlük sınırını belirler. Bir EMF veya WMF görüntüsü tarandığında detay ve dosya boyutunu dengelemek için kullanın. Bu, SVG için küresel DPI tanımlamaz veya slayttaki her nesnenin raster görüntü olmasını zorlamaz.

[metafile-rasterization.pptx](metafile-rasterization.pptx) dosyasını indirin; bu dosya yakın aralıklı diyagonal çizgileri olan bir EMF görüntüsü içerir. Aşağıdaki örnek, ilk slaydını üç tarama çözünürlüğünde [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) aracılığıyla dışa aktarır. Diğer tüm dışa aktarım ayarları aynı kalır, böylece sonuçlar karşılaştırılabilir.

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

Çıktıda, EMF her SVG'de bir gömülü PNG'ye dönüştüldü. Aşağıdaki ölçümler sağlanan sunum içindir; DPI'yi piksel boyutlarına dönüştürmek için genel bir formül değildir.

| Metafile tarama DPI | Gömülü PNG boyutları | SVG dosya boyutu (bayt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Aşağıdaki karşılaştırma, aynı alanın büyütülmüş görüntüsünü aynı artırılmış gösterim boyutunda gösterir. Diyagonal çizgiler, 72 DPI'de belirgin pikselleşme ve daha yüksek çözünürlüklerde daha yumuşak kenarlar gösterirken, SVG dosyası büyür. Değeri artırmak, her detayı mutlaka iyileştirmez veya her dışa aktarılan görüntüyü değiştirmez.

![72, 150 ve 300 DPI'de büyütülmüş diyagonal çizgi detayı](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) görüntü çözünürlüğü azaltmayı kontrol eder ve metafile tarama çözünürlüğünü değiştirme etkisini maskeleyebilir. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) JPEG kodlama kalitesini kontrol eder, metafile tarama çözünürlüğünü değil.

## **Şekillere ve Metne Kararlı Kimlikler Atama**

`jpype.JProxy` aracılığıyla kaydedilen bir Python biçimlendirme denetleyicisini, şekillere [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) ve metin `tspan` öğelerine [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) değerleri atamak için kullanın. Proxy'i [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) ile atayın.

Aşağıdaki denetleyici, şeklin ömrü boyunca kararlı olan [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId) ve metin `tspan`'leri için tekrarlanabilir bir sayacı kullanır. Bu, oluşturulan kimliklerin değişmemiş bir sunumu sonradan işlemek için uygun olmasını sağlar.

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

## **SVG Olay İşleyicileri Ekle**

Bir Python biçimlendirme denetleyicisinde, dışa aktarılan bir şekle JavaScript olay işleyicisi eklemek için [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) öğesini bir [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) değeriyle çağırın. Denetleyiciyi `jpype.JProxy` aracılığıyla kaydedin ve [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) ile atayın. Sonucu barındıran sayfada veya SVG belgesinde JavaScript fonksiyonunu tanımlayın.

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

Barındırıcı sayfa, işleyici tarafından başvurulan JavaScript fonksiyonunu tanımlayabilir. Kimliklerin ve olay işleyicilerin atanması, slayt görüntüleyicileri, erişilebilirlik iyileştirmeleri ve diğer etkileşimli SVG iş akışlarını etkinleştirir.

## **SSS**

**Ne zaman [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) yerine [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) kullanmalıyım?**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) tüm metnin yazı tiplerinden bağımsız olmasını istediğinizde kullanın. [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) yalnızca dış yazı tiplerini kullanan metnin grafiklere dönüştürülmesini istediğinizde kullanın.

**Bir SVG'yi daha küçük yapmak için en iyi yol nedir?**

İlk olarak gömülü resimleri sıkıştırın, kırpılmış görüntü alanlarını silin ve hedef ortam bu dosyaları sağlayabiliyorsa bağlantılı font dosyalarını seçin. Sonucu test edin; çünkü daha düşük görüntü çözünürlüğü, düşük JPEG kalitesi ve vektörleştirilmiş metin farklı kalite ve boyut dengelerine sahiptir.

**Dışa aktarılan SVG öğelerini dışa aktarma sonrası değiştirebilir miyim?**

Evet. Bir biçimlendirme denetleyicisi aracılığıyla kimlikleri atayın, ardından bu kimlikleri kullanarak post‑işleme aracınızda veya tarayıcı betiğinizde eşleşen SVG öğelerini seçin.