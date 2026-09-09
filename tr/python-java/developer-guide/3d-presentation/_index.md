---
title: Python Kullanarak Sunumlarda 3D Efektler Oluşturma
linktitle: 3D Sunum
type: docs
weight: 232
url: /tr/python-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D sunum
- 3D döndürme
- 3D derinlik
- 3D ekstrüzyon
- 3D degrade
- 3D metin
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides ile Java üzerinden Python'da PowerPoint şekilleri ve metni için 3D efektler uygulayın ve renderlayın. Kamera, aydınlatma, malzeme, ekstrüzyon, doldurmalar ve 3D metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, şekil ve metinler için PowerPoint benzeri 3D biçimlendirme oluşturabilir, düzenleyebilir, koruyabilir ve render edebilir. Bu makale, döndürme, ekstrüzyon, keskinlikler, aydınlatma, malzeme, degrade veya resim doldurmaları ve 3D metin gibi 3D efektleri kapsar.

{{% alert color="info" title="Note" %}}
Bu makale, PowerPoint şekilleri ve metinleri üzerindeki 3D biçimlendirme efektleriyle ilgilidir. Ayrı 3D model dosyalarının eklenmesi veya düzenlenmesiyle ilgili değildir. Bir slaytı görüntüye, PDF'e veya HTML'e dışa aktardığınızda, Aspose.Slides bu 3D efektlerini dışa aktarılan 2D çıktıya render eder.
{{% /alert %}}

Paketi, [Installation](/slides/tr/python-java/installation/) bölümünde açıklandığı gibi kurun. Her örnek `asposeslides` paketini içe aktarır, gerekirse JVM'i başlatır ve ardından API'yi içe aktarır. Resim‑doldurma örneği, çalışma dizininde bir `image.jpg` dosyası gerektirir.

## **3D Biçimlendirme Kavramları**

Bir şekle 3D biçimlendirme uygulamak için [Shape.getThreeDFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getThreeDFormat) kullanın. Döndürülen format nesnesi, o şekil için 3D sahneyi kontrol eder.

Metin için, [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#getThreeDFormat) kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3D biçimlendirme uygular.

En önemli API üyeleri şunlardır:

| API üyesi | Ne kontrol eder | Ne zaman kullanılır |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getCamera) | Görüş noktası, ön ayarlı kamera türü, dönme, yakınlaştırma ve perspektif. | Nesneyi 3D uzayda döndürmek veya bir PowerPoint 3D döndürme ön ayarıyla eşleştirmek. |
| [getLightRig](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getLightRig) | Işık ön ayarı, yön ve ışık rotasyonu. | 3D yüzeydeki vurguların ve gölgelerin nasıl göründüğünü değiştirmek. |
| [getMaterial](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getMaterial) ve [setMaterial](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#setMaterial) | Düz, mat, plastik veya metal gibi yüzey malzemesi. | Aynı geometrinin daha düz, daha yumuşak, parlak veya metalik görünmesini sağlamak. |
| [getExtrusionHeight](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getExtrusionHeight) ve [setExtrusionHeight](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Şeklin ön yüzünden geriye ne kadar uzandığı. | Düz bir şekli gözle görülür kalın bir 3D nesneye dönüştürmek. |
| [getExtrusionColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getExtrusionColor) | Ekstrüde edilmiş kenarların rengi. | Derinliği görünür kılmak veya kenar rengini ön doldurma ile koordine etmek. |
| [getDepth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getDepth) ve [setDepth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D biçimlendirmesinde kullanılan ek 3D derinlik. | Şekiller veya metinler için derinliği ince ayarlamak, özellikle keskinlik ve malzeme ayarlarıyla birlikte. |
| [getBevelTop](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getBevelTop) ve [getBevelBottom](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getBevelBottom) | Ön ve arka yüzeylerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüzey yerine yumuşatılmış veya kalıplanmış bir kenar eklemek. |
| [getContourColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getContourWidth) ve [setContourWidth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#setContourWidth) | 3D nesnenin etrafındaki kontur. | Render edilen çıktıda nesne sınırını vurgulamak. |

## **3D Şekil Oluşturma**

Bir şeklin inandırıcı bir 3D görünüm elde edebilmesi için genellikle dört tür ayar gerekir:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Işık ayarları, çünkü aydınlatma yüzeyleri ve kenarları okunabilir kılar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl yansıdığını etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler, 3D biçimlendirme uygular, sunumu PPTX olarak kaydeder ve slaytı PNG görüntüsü olarak render eder.

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
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

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

Render edilen slayt resmi, dikdörtgeni kalın bir 3D blok olarak gösterir:

![Ön yüzünde beyaz 3D metin bulunan, mavi renkte render edilmiş 3D dikdörtgen](img_01_01.png)

## **Kamera ile Şekli Döndürme**

PowerPoint'te 3D döndürme, 3-D Rotation bölmesinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API'si aracılığıyla ayarladığınız dönüşe karşılık gelir.

![X, Y ve Z döndürme değerlerinin vurgulandığı PowerPoint 3-D Rotation bölmesi](img_02_01.png)

Aspose.Slides'ta, kamera tipini ve dönüşü [Shape.getThreeDFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getThreeDFormat) tarafından döndürülen 3D formatı aracılığıyla ayarlayın:

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

Görüntüleyicinin nesneyi nasıl gördüğünü değiştirmeniz gerektiğinde kamerayı kullanın. Bu, slayttaki 2D şekil geometrisini değiştirmez. Render sırasında PowerPoint ve Aspose.Slides tarafından kullanılan 3D bakış noktasını değiştirir.

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, şekli ön yüzünün arkasına uzatarak kalın gösterir. PowerPoint'te, derinlik kontrolü bu görünür kalınlığı ayarlar ve renk kontrolü yan yüzlerin rengini belirler.

![Ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlenen PowerPoint derinlik kontrolleri](img_02_02.png)

Kalınlık için ekstrüzyon yüksekliğini ve yan renk için ekstrüzyon rengini ayarlayın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

PowerPoint'in derinlik değerini doğrudan kullanmanız gerektiğinde veya derinliği keskinlik, malzeme ve metin efektleriyle birleştirmek istediğinizde derinlik ayarını kullanın. Çoğu şekil senaryosunda, ekstrüzyon yüksekliği, görünür ekstrüzyonu doğrudan ifade ettiği için daha net bir ayardır.

## **3D Efektlerle Degrade veya Resim Doldurmaları Kullanma**

3D biçimlendirme, şekil doldurmasından bağımsızdır. Ön yüze katı renk, degrade, desen veya fotoğraf doldurması uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını kullanabilirsiniz.

Bu örnek, şekle degrade doldurma ve yanlara daha koyu bir ekstrüzyon rengi uygular:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE)

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

Render edilen çıktı, ön yüzde degrade ve ekstrüzyonu ayrı olarak render eder:

![Mavi‑turuncu degrade doldurması ve turuncu ekstrüzyonlu render edilmiş 3D dikdörtgen](img_02_03.png)

Bunun yerine fotoğraf doldurma kullanmak için, görüntüyü sunuma ekleyin ve şekil doldurmasına atayın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
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
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Resim, ön yüzde render edilirken ekstrüzyon 3D yan yüzey olarak render edilir:

![Ön yüzünde fotoğraf doldurması ve turuncu ekstrüzyonlu render edilmiş 3D dikdörtgen](img_02_04.png)

## **Metne 3D Biçimlendirme Uygulama**

Şekil 3D biçimlendirme şeklin gövdesini etkiler. Metin 3D biçimlendirme metin çerçevesini etkiler. Harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarlarına ihtiyaç duyduğu WordArt benzeri efektler için faydalıdır.

Aşağıdaki örnek, desen doldurmalı metin oluşturur, WordArt dönüşümü uygular ve [TextFrameFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/) üzerinde 3D ayarlarını yapılandırır:

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

Render edilen metin, kavisli WordArt dönüşümü, turuncu desen doldurma ve koyu ekstrüzyonlu 3D harfler olarak gösterilir:

![Eğik WordArt dönüşümü, turuncu desen doldurma ve koyu ekstrüzyonlu render edilmiş 3D metin](img_02_05.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydederken 3D biçimlendirmeyi korur. Sabit düzen formatlarına render ederken veya dışa aktarırken 3D sahne rasterleştirilir veya 2D sonuç olarak çıktıya çizilir. Bu, slaytları PNG'ye render ederken, PDF'ye dışa aktarırken, HTML'ye dışa aktarırken veya video dönüşümü için kareler oluştururken geçerlidir.

- Dışa aktarılan görüntüler ve PDF'ler etkileşimli değildir. Nesne, dışa aktarıldıktan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık sistemi, malzeme, ekstrüzyon, doldurma ve slayt ölçeklendirmesinin kombinasyonuna bağlıdır.
- Kalıtılmış veya tema tabanlı biçimlendirme değerlerini incelemeniz gerekiyorsa, etkili biçimlendirme API'sini kullanın.
- Bazı çıktı formatları düzenlenebilir PowerPoint 3D biçimlendirmesini saklayamaz. Bu formatlarda görsel sonuç, düzenlenebilir 3D ayarları olarak korunmak yerine render edilir.

## **SSS**

**Aspose.Slides interaktif 3D sunumlar oluşturabilir mi?**

Aspose.Slides şekiller ve metinler için PowerPoint 3D efektlerini oluşturur ve render eder. Dışa aktarılan görüntüler, PDF'ler veya HTML sayfaları, izleyicinin döndürebileceği interaktif 3D sahneler haline getirmez. PPTX'te, format destekliyorsa 3D biçimlendirme PowerPoint içinde düzenlenebilir olarak kalır.

**3D model ile 3D efekt arasındaki fark nedir?**

3D model, sunuma eklenen ayrı bir 3D nesnedir. 3D efekt, düzenli bir PowerPoint şekline veya metne uygulanan, döndürme, ekstrüzyon, keskinlik, aydınlatma ve malzeme gibi biçimlendirmedir. Bu makale 3D efektleri kapsar.

**Görünür bir 3D şekil için hangi ayarlar gereklidir?**

En azından bir kamera dönüşü ve ya ekstrüzyon ya da derinlik ayarlamalısınız. Pratikte, render edilen yüzlerin belirgin vurgular ve gölgeler alması için bir ışık sistemi ve malzeme de ayarlamak gerekir.

**3D efektleri hem şekillere hem de metne uygulayabilir miyim?**

Evet. Şekil gövdesi için [Shape.getThreeDFormat] ve metin için [TextFrameFormat.getThreeDFormat] kullanın.

**3D efektler, görüntülere, PDF'e, HTML'e veya video karelerine dışa aktarıldığında görünecek mi?**

Evet. Aspose.Slides slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan kareler üretirken 3D efektleri render eder. Dışa aktarılan çıktı render edilmiş görünümü içerir, düzenlenebilir bir 3D nesne değil.

**Kalıtım ve tema ayarları uygulandıktan sonra nihai 3D değerlerini okuyabilir miyim?**

Evet. Son kamera, ışık sistemi, keskinlik ve ilgili 3D değerlerini okumak için [ThreeDFormat.getEffective] kullanın.