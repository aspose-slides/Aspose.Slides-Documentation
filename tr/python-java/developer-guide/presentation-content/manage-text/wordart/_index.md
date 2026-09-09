---
title: Python üzerinden Java ile WordArt Efektleri Oluşturma ve Uygulama
linktitle: WordArt
type: docs
weight: 110
url: /tr/python-java/wordart/
keywords:
- WordArt
- WordArt Oluşturma
- WordArt Şablonu
- WordArt Efekti
- Gölge Efekti
- Yansıma Efekti
- Parıltı Efekti
- WordArt Dönüşümü
- 3D Efekti
- Dış Gölge Efekti
- İç Gölge Efekti
- PowerPoint
- Sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java'da WordArt efektlerini oluşturun ve özelleştirin. Bu adım adım kılavuz, geliştiricilerin Python üzerinden Java ile sunumlarını profesyonel metinle geliştirmelerine yardımcı olur."
---
## **Genel Bakış**

WordArt efektleri, PowerPoint sunumlarınıza görsel açıdan çekici, stilize metin eklemenizi sağlar. Aspose.Slides ile geliştiriciler, Microsoft PowerPoint’te olduğu gibi WordArt’ı programlı olarak oluşturabilir, özelleştirebilir ve yönetebilir—Office yüklü olmasına gerek kalmadan. Bu makale, WordArt ile çalışmanın genel bir özetini sunar; metin dönüşümleri, dolgu stilleri, kenarlıklar, gölgeler ve diğer biçimlendirme seçeneklerini uygulayarak sunum içeriğinizi daha ifade edici ve çekici hale getirmeyi açıklar. WordArt, metni bir grafik nesnesi gibi ele almanızı sağlar. Metni daha çekici veya dikkat çekici kılmak için uygulanan efektler veya özel değişiklikler bütünüdür.

## **Basit Bir WordArt Şablonu Oluşturun ve Metne Uygulayın**

**Aspose.Slides Kullanarak**

İlk olarak, bu Python kodu ile basit bir metin oluşturuyoruz:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```
Ardından, efekti daha belirgin hâle getirmek için yazı tipinin boyutunu artırın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    font_data = FontData("Arial Black")
    portion_format = portion.getPortionFormat()
    portion_format.setLatinFont(font_data)
    portion_format.setFontHeight(36)
finally:
    presentation.dispose()
```

**Microsoft PowerPoint Kullanarak**

Microsoft PowerPoint’te WordArt efektleri menüsüne gidin:

![PowerPoint’te WordArt efektleri menüsü](image-20200930113926-1.png)

Sağdaki menüden önceden tanımlanmış bir WordArt efekti seçebilirsiniz. Soldaki menüden yeni WordArt için ayarları belirleyebilirsiniz.

Kullanılabilir bazı parametreler veya seçenekler şunlardır:

![WordArt biçimlendirme seçenekleri](image-20200930114015-3.png)

**Aspose.Slides Kullanarak**

Burada, metne [PatternStyle.SmallGrid](https://reference.aspose.com/slides/tr/python-java/aspose.slides/patternstyle/#SmallGrid) desen dolgusunu uygular ve bu kodla siyah bir metin kenarlığı ekleriz:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getFillFormat().setFillType(FillType.Pattern)
    pattern_format = portion_format.getFillFormat().getPatternFormat()
    pattern_format.getForeColor().setColor(Color.ORANGE)
    pattern_format.getBackColor().setColor(Color.WHITE)
    pattern_format.setPatternStyle(PatternStyle.SmallGrid)

    line_format = portion_format.getLineFormat()
    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

Oluşan metin:

![Desen dolgu ve siyah kenarlıklı metin](image-20200930114108-4.png)

## **Diğer WordArt Efektlerini Uygulama**

**Microsoft PowerPoint Kullanarak**

Program arayüzünden bu efektleri metne, metin bloğuna, şekle veya benzer bir öğeye uygulayabilirsiniz:

![PowerPoint’te metin ve şekil efektleri](image-20200930114129-5.png)

Örneğin, Gölge, Yansıma ve Parıltı efektleri metne; 3D Biçim ve 3D Döndürme efektleri bir metin bloğuna; Yumuşak Kenarlar efekti ise bir şekle (3D Biçim efekti ayarlanmamışsa da etkili olur) uygulanabilir.

### **Gölge Efektleri Uygulama**

Aşağıdaki Python kodu yalnızca metne gölge efekti uygular:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableOuterShadowEffect()
    outer_shadow = portion_format.getEffectFormat().getOuterShadowEffect()
    outer_shadow.getShadowColor().setColor(Color.BLACK)
    outer_shadow.setScaleHorizontal(100)
    outer_shadow.setScaleVertical(65)
    outer_shadow.setBlurRadius(4.73)
    outer_shadow.setDirection(230)
    outer_shadow.setDistance(2)
    outer_shadow.setSkewHorizontal(30)
    outer_shadow.setSkewVertical(0)
    outer_shadow.getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

Aspose.Slides API, üç tür gölgeyi destekler: [OuterShadow](https://reference.aspose.com/slides/tr/python-java/aspose.slides/outershadow/), [InnerShadow](https://reference.aspose.com/slides/tr/python-java/aspose.slides/innershadow/) ve [PresetShadow](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presetshadow/).

[PresetShadow](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presetshadow/) ile önceden tanımlı değerleri kullanarak metne gölge ekleyebilirsiniz.

**Microsoft PowerPoint Kullanarak**

PowerPoint’te yalnızca bir tür gölge kullanılabilir. İşte bir örnek:

![PowerPoint’te gölge ayarları](image-20200930114225-6.png)

**Aspose.Slides Kullanarak**

Aspose.Slides, aynı anda iki tür gölge uygulamanıza izin verir: [InnerShadow](https://reference.aspose.com/slides/tr/python-java/aspose.slides/innershadow/) ve [PresetShadow](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presetshadow/).

**Notlar:**

- [OuterShadow](https://reference.aspose.com/slides/tr/python-java/aspose.slides/outershadow/) ve [PresetShadow](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presetshadow/) birlikte kullanıldığında yalnızca [OuterShadow](https://reference.aspose.com/slides/tr/python-java/aspose.slides/outershadow/) efekti uygulanır.
- [OuterShadow](https://reference.aspose.com/slides/tr/python-java/aspose.slides/outershadow/) ve [InnerShadow](https://reference.aspose.com/slides/tr/python-java/aspose.slides/innershadow/) aynı anda kullanıldığında, uygulanacak efekt PowerPoint sürümüne bağlıdır. Örneğin PowerPoint 2013’te efekt iki kat olur. PowerPoint 2007’de ise yalnızca [OuterShadow](https://reference.aspose.com/slides/tr/python-java/aspose.slides/outershadow/) efekti uygulanır.

### **Metne Yansıma Uygulama**

Bu Python (Java üzerinden) kod örneği ile metne yansıma ekliyoruz:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableReflectionEffect()
    reflection = portion_format.getEffectFormat().getReflectionEffect()
    reflection.setBlurRadius(0.5)
    reflection.setDistance(4.72)
    reflection.setStartPosAlpha(0)
    reflection.setEndPosAlpha(60)
    reflection.setDirection(90)
    reflection.setScaleHorizontal(100)
    reflection.setScaleVertical(-100)
    reflection.setStartReflectionOpacity(60)
    reflection.setEndReflectionOpacity(0.9)
    reflection.setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

### **Metne Parıltı Efekti Uygulama**

Metni parlak veya öne çıkarmak için aşağıdaki kodla parıltı efektini uyguluyoruz:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableGlowEffect()
    glow = portion_format.getEffectFormat().getGlowEffect()
    glow.getColor().setR(jpype.JByte(-1))
    glow.getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    glow.setRadius(7)
finally:
    presentation.dispose()
```

İşlemin sonucu:

![Parıltı efekti eklenmiş metin](image-20200930114621-7.png)

{{% alert color="info" title="Not" %}}
Gölge, yansıma ve parıltı parametrelerini değiştirebilirsiniz. Efekt özellikleri, metnin her bölümü için ayrı ayrı ayarlanır.
{{% /alert %}}

### **WordArt’ta Dönüşümler Kullanma**

Tüm metin bloğunu dönüştürmek için [TextFrameFormat.setTransform](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setTransform) yöntemini kullanın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

Sonuç:

![Yay şeklinde dönüşüm uygulanmış metin](image-20200930114712-8.png)

{{% alert color="info" title="Not" %}}
Microsoft PowerPoint ve Aspose.Slides for Python via Java, belirli sayıda ön tanımlı dönüşüm tipini sunar.
{{% /alert %}}

**PowerPoint Kullanarak**

Ön tanımlı dönüşüm tiplerine ulaşmak için: **Format** → **TextEffect** → **Transform** menüsüne gidin.

**Aspose.Slides Kullanarak**

Bir dönüşüm tipi seçmek için [TextShapeType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textshapetype/) enum’ını kullanın.

### **Metin ve Şekillere 3D Efektleri Uygulama**

Bu örnek kodla bir metin şekline 3D efekti uyguluyoruz:

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
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    three_d_format = auto_shape.getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(10.5)
    three_d_format.getBevelBottom().setWidth(10.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(12.5)
    three_d_format.getBevelTop().setWidth(11)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Oluşan metin ve şekli:

![3D efektli metin şekli](image-20200930114816-9.png)

Bu Python kodu ile metne 3D efekti ekliyoruz:

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
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    three_d_format = text_frame.getTextFrameFormat().getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(3.5)
    three_d_format.getBevelBottom().setWidth(3.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(4)
    three_d_format.getBevelTop().setWidth(4)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

İşlemin sonucu:

![3D efektli metin](image-20200930114905-10.png)

{{% alert color="info" title="Not" %}}
Metne veya şekline 3D efektlerinin uygulanması ve efektler arasındaki etkileşimler belirli kurallara dayanır.

Metin ve metni içeren şekil için bir sahne düşünün. 3D efekt, bir 3D nesne temsili ve nesnenin yerleştirildiği sahneyi içerir.

- Sahne hem şekil hem de metin için ayarlandıysa, şekil sahnesi önceliklidir; metin sahnesi yoksayılır.
- Şeklin kendi sahnesi yoksa ancak bir 3D temsili varsa, metin sahnesi kullanılır.
- Aksi takdirde—şeklin baştan bir 3D efekti yoksa—şekil düz kalır ve 3D efekt yalnızca metne uygulanır.

Bu kurallar, [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getLightRig) ve [ThreeDFormat.getCamera](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getCamera) yöntemleriyle ilgilidir.
{{% /alert %}}

## **Metne Dış Gölge Efektleri Uygulama**

Aspose.Slides for Python via Java, [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) içinde metne gölge efektleri uygulamanızı sağlayan [OuterShadow](https://reference.aspose.com/slides/tr/python-java/aspose.slides/outershadow/) ve [InnerShadow](https://reference.aspose.com/slides/tr/python-java/aspose.slides/innershadow/) sınıflarını sunar. Aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksini kullanarak bir slayta referans alın.  
3. Slayta dikdörtgen bir şekil ekleyin.  
4. Şekille ilişkili metin çerçevesine erişin.  
5. Şekil dolgusunu devre dışı bırakın.  
6. Dış gölge efektini etkinleştirin.  
7. Gölgenin bulanık yarıçapını ayarlayın.  
8. Gölgenin yönünü belirleyin.  
9. Gölgenin mesafesini ayarlayın.  
10. Gölgeyi sol üst köşeye hizalayın.  
11. Gölge rengini siyah olarak belirleyin.  
12. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak kaydedin.

Bu adımları Python (Java üzerinden) ile gerçekleştiren örnek kod, dış gölge efektini metne nasıl uygulayacağınızı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Slayt referansını al
    slide = presentation.getSlides().get_Item(0)

    # Dikdörtgen tipinde bir AutoShape ekle
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50)

    # Dikdörtgene TextFrame ekle
    auto_shape.addTextFrame("Aspose TextBox")

    # Metnin gölgesini alabilmek için şekil dolgusunu devre dışı bırak
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Dış gölge ekle ve tüm gerekli parametreleri ayarla
    auto_shape.getEffectFormat().enableOuterShadowEffect()
    shadow = auto_shape.getEffectFormat().getOuterShadowEffect()
    shadow.setBlurRadius(4.0)
    shadow.setDirection(45)
    shadow.setDistance(3)
    shadow.setRectangleAlign(RectangleAlignment.TopLeft)
    shadow.getShadowColor().setPresetColor(PresetColor.Black)

    # Sunumu diske kaydet
    presentation.save("pres_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Şekillere İç Gölge Efekti Uygulama**

Aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Slayta referans alın.  
3. Dikdörtgen bir şekil ekleyin.  
4. İç gölge efektini etkinleştirin.  
5. Gerekli tüm parametreleri ayarlayın.  
6. Gölge renk tipini bir tema rengi olarak belirtin.  
7. Tema rengini seçin.  
8. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak kaydedin.

Bu adımlara dayalı örnek kod, bir şeklin içindeki metne iç gölge efektini Python (Java üzerinden) nasıl uygulayacağınızı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorType, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    # Slayt referansını al
    slide = presentation.getSlides().get_Item(0)

    # Dikdörtgen tipinde bir AutoShape ekle
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300)
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Dikdörtgene TextFrame ekle
    auto_shape.addTextFrame("Aspose TextBox")
    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion_format = portion.getPortionFormat()
    portion_format.setFontHeight(50)

    # InnerShadowEffect'i etkinleştir
    effect_format = portion_format.getEffectFormat()
    effect_format.enableInnerShadowEffect()

    # Tüm gerekli parametreleri ayarla
    inner_shadow = effect_format.getInnerShadowEffect()
    inner_shadow.setBlurRadius(8.0)
    inner_shadow.setDirection(90.0)
    inner_shadow.setDistance(6.0)
    inner_shadow.getShadowColor().setB(jpype.JByte(-67))

    # ColorType'ı Scheme olarak ayarla
    inner_shadow.getShadowColor().setColorType(ColorType.Scheme)

    # Scheme rengini ayarla
    inner_shadow.getShadowColor().setSchemeColor(SchemeColor.Accent1)

    # Sunumu kaydet
    presentation.save("WordArt_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**WordArt efektlerini farklı yazı tipleri veya betikler (ör. Arapça, Çince) ile kullanabilir miyim?**  
Evet, Aspose.Slides Unicode desteği sunar ve tüm büyük yazı tipleri ve betiklerle çalışır. Gölge, dolgu ve kenarlık gibi WordArt efektleri dili ne olursa olsun uygulanabilir; ancak yazı tipi kullanılabilirliği ve render’lama sistem yazı tiplerine bağlıdır.

**WordArt efektlerini slayt ana tasarım öğelerine uygulayabilir miyim?**  
Evet, ana slaytlardaki şekillere, başlık yer tutucularına, altbilgilere veya arka plan metnine WordArt efektleri ekleyebilirsiniz. Ana tasarımda yapılan değişiklikler, ilişkili tüm slaytlara yansır.

**WordArt efektleri sunum dosya boyutunu etkiler mi?**  
Bir miktar etkiler. Gölge, parıltı ve degrade dolgu gibi efektler, ek biçimlendirme meta verisi oluşturduğu için dosya boyutunu hafifçe artırabilir; ancak fark genellikle önemsizdir.

**Sunumu kaydetmeden WordArt efektlerinin sonucunu ön izleyebilir miyim?**  
Evet, WordArt içeren slaytları [Shape.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getImage) veya [Slide.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) metodlarıyla görüntülere (PNG, JPEG vb.) dönüştürebilir ve tamamını kaydetmeden ya da dışa aktarım yapmadan ekranda ön izleyebilirsiniz.