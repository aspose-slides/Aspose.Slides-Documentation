---
title: Python üzerinden Java ile WordArt Efektlerini Oluşturma ve Uygulama
linktitle: WordArt
type: docs
weight: 110
url: /tr/python-java/wordart/
keywords:
- WordArt
- WordArt Oluştur
- WordArt Şablonu
- WordArt Efekti
- Gölge Efekti
- Yansıma Efekti
- Parıltı Efekti
- WordArt Dönüşümü
- 3B Efekti
- Dış Gölge Efekti
- İç Gölge Efekti
- PowerPoint
- Sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java içinde WordArt efektlerini oluşturun ve özelleştirin. Bu adım adım rehber, geliştiricilerin Python üzerinden Java ile sunumları profesyonel metinle zenginleştirmesine yardımcı olur."
---
## **Genel Bakış**

WordArt efektleri, metni dolgu, kontur, gölge, yansıma, parıltı, dönüşüm ve 3D biçimlendirme ile stillendirmenizi sağlar. Bu makale, Microsoft Office yüklü olmadan Aspose.Slides for Python via Java kullanarak PowerPoint sunumlarında bu efektleri nasıl oluşturup özelleştireceğinizi açıklar.

## **Basit bir WordArt Şablonu Oluşturun ve Metne Uygulayın**

Şu aşağıdaki örnekler, metin, yazı tipi, desen dolgusu ve konturu ayarlayarak basit bir WordArt stili oluşturur.

Her örnek yeni bir sunum oluşturur ve ilk slaytına bir dikdörtgen ekler; giriş dosyasına gerek yoktur. İlk örnek metni "Aspose.Slides" olarak ayarlar. Şekil konumu ve boyutları puan cinsindendir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```

Biçimlendirmeyi daha belirgin hale getirmek için yazı tipini 36 puan Arial Black olarak ayarlayın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)
finally:
    presentation.dispose()
```

Arka planı beyaz ve ön planı koyu turuncu bir [SmallGrid](https://reference.aspose.com/slides/tr/python-java/aspose.slides/patternstyle/#SmallGrid) deseni uygulayın, ardından 1 puan genişliğinde siyah bir metin konturu ekleyin:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    dark_orange = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(dark_orange)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid)

    portion.getPortionFormat().getLineFormat().setWidth(1)
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

Elde edilen metin:

![Basit WordArt şablonu](WordArt_template.png)

## **Diğer WordArt Efektlerini Uygulayın**

Aşağıdaki örnekler, gölgeler, yansımalar, parıltılar, dönüşümler ve 3B efektlerin metne nasıl uygulanacağını gösterir.

### **Dış Gölge Efektlerini Uygula**

Bir dış gölge, metnin arkasına gölge ekleyerek derinlik kazandırır. Rengini, yönünü, mesafesini, bulanıklık yarıçapını, ölçeğini ve eğimini özelleştirebilirsiniz.

Bu örnek [enableOuterShadowEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effectformat/#enableOuterShadowEffect) metodunu çağırır ve 4 puan bulanıklık yarıçapına, 230 derece yöne ve 30 puan mesafeye sahip siyah bir gölge ayarlar. 100 ölçek değeri gölgenin boyutunu korur, yatay eğim ise 20 dereceyle eğilir. Alfa dönüşümü opaklığını %32 olarak belirler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect()
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

Elde edilen metin:

![Dış Gölge efekti](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Dış ve ön tanımlı gölgeler birlikte kullanıldığında yalnızca dış gölge uygulanır.
- Dış ve iç gölgeler aynı anda kullanılırsa, oluşan etki PowerPoint sürümüne bağlıdır. Örneğin PowerPoint 2013'te efekt iki katına çıkar, PowerPoint 2007'de ise yalnızca dış gölge uygulanır.
{{% /alert %}}

### **Yansıma Efektlerini Uygula**

Yansıma, metnin ayna gibi bir kopyasını oluşturur. Konumunu, ölçeğini, bulanıklığını ve opaklığını ayarlayarak görünümünü kontrol edebilirsiniz.

Bu örnek [enableReflectionEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effectformat/#enableReflectionEffect) metodunu çağırır ve yansımayı -100% ölçekle dikey olarak ters çevirir. 0,5 puan bulanıklık yarıçapı ve 4,72 puan mesafe kullanır. Opaklık, yansıma boyunca %60 ile %0,9 arasında konum 0% ile 60% arasında azalır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect()
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

Elde edilen metin:

![Yansıma efekti](reflection_effect.png)

### **Parıltı Efektlerini Uygula**

Parıltı, metnin etrafına yumuşak renkli bir kontur ekler. Rengini, opaklığını ve yarıçapını ayarlayarak efekti kontrol edebilirsiniz.

Bu örnek [enableGlowEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effectformat/#enableGlowEffect) metodunu çağırır ve %54 opaklıkla 7 puan yarıçapına sahip kırmızı bir parıltı uygular:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableGlowEffect()
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7)
finally:
    presentation.dispose()
```

Elde edilen metin:

![Parıltı etkisi](glow_effect.png)

### **WordArt Dönüşümlerini Uygula**

WordArt dönüşümleri, bir metin bloğunu bükebilir, uzatabilir veya eğebilir.

Metin çerçevesini tamamen yukarı doğru eğmek için [setTransform](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setTransform) metodunu [ArchUpPour](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textshapetype/#ArchUpPour) ile ayarlayın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")
    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

Elde edilen metin:

![WordArt dönüşümü](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java, önceden tanımlı bir dizi [dönüşüm türü](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textshapetype/) sunar.
{{% /alert %}}

### **Şekillere ve Metne 3B Efektler Uygula**

Bir şekle veya metnine 3B efektler uygulayabilirsiniz. Kavisler, ekstrüzyon, aydınlatma ve kamera ayarları, ortaya çıkan görünümü kontrol eder.

Aşağıdaki örnek, dikdörtgene dairesel köşeler, turuncu ekstrüzyon ve koyu kırmızı kontur eklemek için [ThreeDFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/) kullanır. Köşe ölçüleri, ekstrüzyon yüksekliği, kontur genişliği ve derinlik puan cinsindedir. Plastik bir malzeme, Z ekseni etrafında 40 derece döndürülmüş dengeli aydınlatma ve perspektif kamera görünümünü tanımlar:

```python
import jpype
import asposeslides

if not jpame.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    auto_shape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelBottom().setHeight(10.5)
    auto_shape.getThreeDFormat().getBevelBottom().setWidth(10.5)

    auto_shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelTop().setHeight(12.5)
    auto_shape.getThreeDFormat().getBevelTop().setWidth(11)

    orange = Color(255, 165, 0)
    auto_shape.getThreeDFormat().getExtrusionColor().setColor(orange)
    auto_shape.getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    auto_shape.getThreeDFormat().getContourColor().setColor(dark_red)
    auto_shape.getThreeDFormat().setContourWidth(1.5)

    auto_shape.getThreeDFormat().setDepth(3)

    auto_shape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    auto_shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    auto_shape.getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Elde edilen şekil:

![Şekil 3B efekti](shape_3D_effect.png)

Bu örnek, [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#getThreeDFormat) aracılığıyla metne benzer 3B biçimlendirme uygular. Daha küçük köşeler harf kenarlarını şekillendirirken, ekstrüzyon ve aydınlatma metne derinlik kazandırır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5)

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4)

    orange = Color(255, 165, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange)
    text_frame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(dark_red)
    text_frame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5)

    text_frame.getTextFrameFormat().getThreeDFormat().setDepth(3)

    text_frame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    text_frame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Elde edilen metin:

![Metin 3B efekti](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Metne veya şekline 3B efektlerin uygulanması—ve bu efektler arasındaki etkileşim—belirli kurallara göre düzenlenir. Metin ve onu içeren şekli içeren bir sahneyi düşünün. Bir 3B efekt, nesnenin 3B temsilini ve içinde bulunduğu sahneyi içerir.

- Eğer sahne hem şekil hem de metin için ayarlanmışsa, şeklin sahnesi öncelik kazanır ve metnin sahnesi yok sayılır.
- Şeklin kendi sahnesi yoksa ancak bir 3B temsili varsa, metnin sahnesi kullanılır.
- Şeklin hiç 3B efekti yoksa, düz kabul edilir ve 3B efekt yalnızca metne uygulanır.

Bu davranışlar, [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getLightRig) ve [ThreeDFormat.getCamera](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getCamera) metodlarıyla ilgilidir.
{{% /alert %}}

Metni düz ve okunabilir tutarken şeklin 3B biçimlendirmesini korumak için, her iki ayarın karşılaştırması ve tam bir Python örneği için [Keep Text Flat on a 3D Shape](/slides/tr/python-java/3d-presentation/) sayfasına bakın.

## **SSS**

**Farklı yazı tipleri veya betikler (örn. Arapça, Çince) ile WordArt efektleri kullanabilir miyim?**

Evet, Aspose.Slides for Python via Java Unicode destekler ve tüm büyük yazı tipleri ve betiklerle çalışır. WordArt efektleri gölge, dolgu ve kontur gibi dilden bağımsız olarak uygulanabilir, ancak yazı tipi bulunabilirliği ve işleme sistemi yüklü yazı tiplerine bağlı olabilir.

**WordArt efektlerini slayt ana tasarım öğelerine uygulayabilir miyim?**

Evet, WordArt efektlerini ana slaytlardaki şekillere, başlık yer tutucularına, altbilgilere veya arka plan metnine uygulayabilirsiniz. Ana tasarımda yapılan değişiklikler, ilişkili tüm slaytlara yansıtılır.

**WordArt efektleri sunum dosya boyutunu etkiler mi?**

Biraz. Gölge, parıltı ve degrade dolgu gibi WordArt efektleri, ek biçimlendirme metadatası nedeniyle dosya boyutunu hafifçe artırabilir, fakat fark genellikle ihmal edilebilir düzeydedir.

**WordArt efektlerinin sonucunu sunumu kaydetmeden önizleyebilir miyim?**

Evet, WordArt içeren slaytları [Slide.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) ile görüntülere (ör. PNG, JPEG) renderleyebilir veya bireysel şekilleri [Shape.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getImage) ile renderleyebilirsiniz. Böylece sunumu kaydetmeden veya dışa aktarmadan önce sonucu hafızada veya ekranda önizleyebilirsiniz.