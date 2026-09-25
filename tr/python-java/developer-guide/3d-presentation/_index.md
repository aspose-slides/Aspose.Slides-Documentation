---
title: Python kullanarak Sunumlarda 3B Efektler Oluşturma
linktitle: 3B Sunum
type: docs
weight: 232
url: /tr/python-java/3d-presentation/
keywords:
- 3B PowerPoint
- 3B sunum
- 3B dönüş
- 3B derinlik
- 3B ekstrüzyon
- 3B degrade
- 3B metin
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides ile Java üzerinden Python’da PowerPoint şekilleri ve metni için 3B efektler uygulayın ve renderlayın. Kamera, aydınlatma, materyal, ekstrüzyon, doldurmalar ve 3B metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, şekil ve metinler için PowerPoint tarzı 3B biçimlendirmeyi oluşturabilir, düzenleyebilir, koruyabilir ve işleyebilir. Bu makale, dönüş, ekstrüzyon, köşe yumuşatma, aydınlatma, malzeme, degrade veya resim doldurmaları ve 3B metin gibi 3B etkileri kapsar.

{{% alert color="info" title="Note" %}}
Bu makale, PowerPoint şekilleri ve metinleri üzerindeki 3B biçimlendirme etkileriyle ilgilidir. Bağımsız 3B model dosyalarının eklenmesi veya düzenlenmesiyle ilgili değildir. Bir slaytı görüntü, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3B etkileri dışa aktarılan 2B çıktıya işler.
{{% /alert %}}

## **3B Biçimlendirme Kavramları**

Bir şekle 3B biçimlendirme uygulamak için [Shape.getThreeDFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getThreeDFormat) yöntemini kullanın. Bu yöntem, o şeklin 3B sahnesini kontrol eden [ThreeDFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/) nesnesini döndürür.

Metin için, [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#getThreeDFormat) yöntemini kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3B biçimlendirme uygular.

En önemli API üyeleri şunlardır:

| API üyesi | Ne kontrol eder | Ne zaman kullanılır |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getCamera) | Görüş noktası, ön ayarlı kamera tipi, dönüş, yakınlaştırma ve perspektif. | Nesneyi 3B uzayda döndürmek veya PowerPoint 3B dönüş ön ayarına uymak için. |
| [getLightRig](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getLightRig) | Işık ön ayarı, yön ve ışık dönüşü. | 3B yüzeyde ışık vurguları ve gölgelerin nasıl göründüğünü değiştirmek için. |
| [getMaterial](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getMaterial) ve [setMaterial](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#setMaterial) | Düz, mat, plastik veya metal gibi yüzey materyali. | Aynı geometrinin daha düz, daha yumuşak, parlak veya metalik görünmesini sağlamak için. |
| [getExtrusionHeight](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getExtrusionHeight) ve [setExtrusionHeight](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Şeklin ön yüzünden geriye doğru ne kadar uzandığını. | Düz bir şekli belirgin kalın bir 3B nesneye dönüştürmek için. |
| [getExtrusionColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getExtrusionColor) | Ekstrüde edilmiş yan yüzlerin rengi. | Derinliği görünür kılmak veya yan renkleri ön doldurmayla uyumlu hale getirmek için. |
| [getDepth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getDepth) ve [setDepth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3B biçimlendirmesinde kullanılan ek 3B derinlik. | Şekil veya metin için derinliği ince ayarlamak, özellikle köşe yumuşatma ve materyal ayarlarıyla birlikte. |
| [getBevelTop](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getBevelTop) ve [getBevelBottom](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getBevelBottom) | Ön ve arka yüzlerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüzey yerine yumuşak veya kalıplanmış bir kenar eklemek için. |
| [getContourColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getContourColor) ve [getContourWidth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getContourWidth) ve [setContourWidth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#setContourWidth) | 3B nesnenin etrafındaki kontur. | Oluşturulan çıktıda nesne sınırını vurgulamak için. |

## **3B Şekil Oluşturma**

Bir şeklin ikna edici bir şekilde 3B görünmesi için genellikle dört tür ayar gerekir:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Işık ayarları, çünkü aydınlatma yüzeylerin ve yanların okunabilir olmasını sağlar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl işlendiğini etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler ve 3B biçimlendirme uygular. Kamera dönüş değerleri derecedir ve ekstrüzyon yüksekliği 100 puandır. Örnek, slaytı varsayılan boyutunun iki katı bir PNG görüntüsüne işler ve sunumu PPTX olarak kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)
    shape.getTextFrame().setText("3D")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("shape_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("shape_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

İşlenmiş slayt görüntüsü, dikdörtgeni kalın bir 3B blok olarak gösterir:

![İşlenmiş mavi 3B dikdörtgen, ön yüzünde beyaz 3B metin](img_01_01.png)

## **Kamerayla Şekli Döndürme**

PowerPoint'te 3B dönüş, 3-D Dönüş bölmesinden yapılandırılır. X, Y ve Z dönüş değerleri, kamera API'si aracılığıyla ayarladığınız dönüşe karşılık gelir.

![PowerPoint 3-D Dönüş bölmesi, X, Y ve Z dönüş değerleri vurgulanmış](img_02_01.png)

Aspose.Slides'te kameraya [ThreeDFormat.getCamera](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getCamera) ile erişilir. Bu örnek bir dikdörtgen oluşturur, ortografik ön görünüm seçer ve X, Y, Z dönüşlerini sırasıyla 20, 30 ve 40 derece olarak ayarlar. Şekli dosya kaydetmeden bellekte yapılandırır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
finally:
    presentation.dispose()
```

Kamerayı, izleyicinin nesneyi nasıl gördüğünü değiştirmek istediğinizde kullanın. Bu, slayttaki 2D şekil geometrisini değiştirmez. PowerPoint ve Aspose.Slides'in render alırken kullandığı 3B bakış noktasını değiştirir.

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, şekli ön yüzünün arkasına uzatarak kalın gösterir. PowerPoint'te derinlik kontrolü bu görünür kalınlığı ayarlar ve renk kontrolü yan yüzlerin rengini belirler.

![PowerPoint derinlik kontrolleri, ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlenmiş](img_02_02.png)

Kalınlığı ayarlamak için [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#setExtrusionHeight) kullanın ve yan renk erişimi için [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getExtrusionColor) kullanın. Bu örnek, bir dikdörtgene 100 puanlık ekstrüzyon ve mor yan yüzler verir ve kalınlığını göstermek için kamerayı döndürür. Şekli dosya kaydetmeden bellekte yapılandırır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

[ThreeDFormat.setDepth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#setDepth) yöntemi bir 3B şeklin derinliğini ayarlar. [setExtrusionHeight](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#setExtrusionHeight) yöntemi ekstrüzyon etkisinin yüksekliğini kontrol eder; bu örnekte gösterildiği gibi.

## **3B Efektlerle Degrade veya Resim Doldurmaları Kullanma**

3B biçimlendirme, şekil doldurmasından bağımsızdır. Ön yüze katı renk, degrade, desen veya resim dolgusu uygulayabilir ve aynı kamera, ışık, materyal ve ekstrüzyon ayarlarını kullanabilirsiniz.

Bu örnek, ön yüze mavi‑turuncu bir degrade uygular ve 150 puanlık ekstrüzyona koyu turuncu bir renk verir. Degrade, 0 ve 100 konumlarındaki duraklarla başlangıç ve bitişi işaretler. Kamera dönüş değerleri derecedir. Slayt, varsayılan boyutunun iki katı bir PNG görüntüsüne işlenir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getTextFrame().setText("3D Gradient")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color(255, 165, 0))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("gradient_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()
finally:
    presentation.dispose()
```

![Mavi‑turuncu degrade doldurmalı ve turuncu ekstrüzyonlu işlenmiş 3B dikdörtgen](img_02_03.png)

Resim dolgusu kullanmak için, resmi sunuma ekleyin ve şekil doldurmasına atayın. Bu örnek, çalışma dizininde "image.jpg" adlı bir dosyanın var olmasını gerektirir. Resmi dikdörtgeni dolduracak şekilde yayar, 150 puanlık ekstrüzyon uygular ve kamera dönüşünü derecelerle ayarlar. Şekli dosya kaydetmeden veya render etmeden bellekte yapılandırır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, LightRigPresetType, LightingDirection, MaterialPresetType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    image_data = Path("image.jpg").read_bytes()
    java_image_data = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(java_image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

![Ön yüzünde fotoğraf dolgulu ve turuncu ekstrüzyonlu işlenmiş 3B dikdörtgen](img_02_04.png)

## **Metne 3B Biçimlendirme Uygulama**

Şekil 3B biçimlendirmesi şekil gövdesini etkiler. Metin 3B biçimlendirmesi ise metin çerçevesini etkiler. Bu, harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarlarına ihtiyaç duyduğu WordArt benzeri efektler için kullanışlıdır.

Aşağıdaki örnek, turuncu‑beyaz bir ızgara deseniyle metin oluşturur, yukarı doğru bir kavis uygular ve [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#getThreeDFormat) aracılığıyla 3B ayarları yapılandırır. Ekstrüzyon yüksekliği ve derinlik puan olarak, ışık dönüşü derece olarak belirtilir. Şekil doldurması ve konturu gizlenir, böylece yalnızca metin görünür. Örnek, varsayılan slayt boyutunun iki katı bir PNG görüntüsü oluşturur ve sunumu PPTX olarak kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, PatternStyle, Presentation, SaveFormat, ShapeType, TextShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().setText("3D Text")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    pattern_color = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(pattern_color)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid)

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128)

    text_frame_format = shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setTransform(TextShapeType.ArchUp)
    text_frame_format.getThreeDFormat().setExtrusionHeight(3.5)
    text_frame_format.getThreeDFormat().setDepth(3)
    text_frame_format.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)
    text_frame_format.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame_format.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame_format.getThreeDFormat().getLightRig().setRotation(0, 0, 40)
    text_frame_format.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("text_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("text_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Kavisli WordArt dönüşümü, turuncu desen dolgusu ve koyu ekstrüzyonlu işlenmiş 3B metin](img_02_05.png)

## **Metni 3B Şekilde Düz Tutma**

Bir şeklin 3B görünümünü korurken metni okunabilir tutmak için, [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/#getTextFrameFormat) üzerinden [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setKeepTextFlat) metodunu çağırın. Değer `True` ise metin 3B sahneden dışarıda kalır. Değer `False` ise metin sahneye katılır ve 3B yönelimine uyar.

Bu ayar şeklin 3B biçimlendirmesini (kamera, aydınlatma, materyal ve ekstrüzyon) kaldırmaz. Ayrıca normal dönüşten farklıdır. [Shape.setRotation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#setRotation) şekli slayt düzleminde döndürürken, [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setRotationAngle) metnin çerçevesi içinde özel dönüşünü kontrol eder. Metni 3B sahneden dışarıda tutmak, bu açıları sıfırlamaz.

Aşağıdaki bağımsız örnek, metinli mavi bir dikdörtgen oluşturur ve orijinalin yanına kopyalar. Her iki şekil de aynı 3B biçimlendirmeye sahiptir; sadece metin ayarı farklıdır: solda `False`, sağda `True`. Kamera açıları derecedir ve ekstrüzyon yüksekliği 40 puandır. Örnek, sunumu PPTX olarak kaydeder ve karşılaştırma slaytını varsayılan boyutunun iki katı bir PNG olarak render eder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140)

    shape.getTextFrame().setText("Readable text")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center)
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(40)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color(65, 105, 225))
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(False)

    flat_text_shape = slide.getShapes().addClone(shape, 400, 160)
    flat_text_shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(True)

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx)
    image = slide.getImage(2, 2)
    try:
        image.save("keep_text_flat.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

![Yan yana 3B dikdörtgenler: metin solda 3B yönelime uyar, sağda düz kalır](keep_text_flat.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarında kaydederken 3B biçimlendirmeyi korur. Sabit‑sayfa formatlarına render alırken veya dışa aktarırken, 3B sahne rasterleştirilir ve çıktı içine 2B bir sonuç olarak çizilir. Bu, slaytları [PNG](/slides/tr/python-java/convert-powerpoint-to-png/), [PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/), [HTML](/slides/tr/python-java/convert-powerpoint-to-html/) formatlarına dışa aktarırken veya [video conversion](/slides/tr/python-java/convert-powerpoint-to-video/) için kareler oluştururken geçerlidir.

- Dışa aktarılan görüntüler ve PDF'ler etkileşimli değildir. Nesne, dışa aktarıldıktan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık seti, malzeme, ekstrüzyon, doldurma ve slayt ölçeklemesinin kombinasyonuna bağlıdır.
- Kalıtılan veya tema tabanlı biçimlendirme değerlerini incelemeniz gerekiyorsa, [effective shape properties](/slides/tr/python-java/shape-effective-properties/) sayfasını okuyun.
- Bazı çıktı formatları, düzenlenebilir PowerPoint 3B biçimlendirmesini saklayamaz. Bu formatlarda görsel sonuç, düzenlenebilir 3B ayarlar olarak korunmak yerine render edilir.

## **SSS**

**Aspose.Slides etkileşimli 3B sunumlar oluşturabilir mi?**

Aspose.Slides, şekil ve metinler için PowerPoint 3B efektlerini oluşturur ve render alır. Dışa aktarılan görüntüler, PDF'ler veya HTML sayfaları izleyicinin döndürebileceği etkileşimli 3B sahneler haline getirmez. PPTX formatında, 3B biçimlendirme PowerPoint'te desteklendiği sürece düzenlenebilir olarak kalır.

**3B model ile 3B efekt arasındaki fark nedir?**

3B model, bir sunuma eklenen ayrı bir 3B nesnedir. 3B efekt ise bir PowerPoint şekline veya metnine uygulanan, dönüş, ekstrüzyon, köşe yumuşatma, aydınlatma ve malzeme gibi biçimlendirmedir. Bu makale 3B efektleri ele alır.

**Görünür bir 3B şekil için hangi ayarlar gerekir?**

Minimum olarak bir kamera dönüşü ve ekstrüzyon ya da derinlik ayarı yapılmalıdır. Uygulamada, render edilen yüzlerin net vurgular ve gölgeler alması için bir ışık seti ve materyal de ayarlanır.

**Hem şekillere hem de metne 3B efektler uygulayabilir miyim?**

Evet. Şekil gövdesi için [Shape.getThreeDFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getThreeDFormat) ve metin için [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#getThreeDFormat) yöntemlerini kullanın.

**3B efektler görüntülere, PDF, HTML veya video karelerine dışa aktarıldığında görünür mü?**

Evet. Aspose.Slides, slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan kareler oluşturulurken 3B efektleri render eder. Dışa aktarılan çıktı render edilmiş görünümü içerir, düzenlenebilir bir 3B nesne değildir.

**Kalıtım ve tema ayarları uygulandıktan sonra son 3B değerleri okuyabilir miyim?**

Evet. Son kamera, ışık seti, köşe yumuşatma ve ilgili 3B değerleri okumak için [Shape Effective Properties](/slides/tr/python-java/shape-effective-properties/) sayfasında açıklanan etkili biçimlendirme API'lerini kullanın.