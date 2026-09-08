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
description: "Aspose.Slides ile Java üzerinden Python'da PowerPoint şekilleri ve metni için 3D efektler uygulayın ve renderlayın. Kamera, aydınlatma, malzeme, ekstrüzyon, dolgular ve 3D metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, şekiller ve metinler için PowerPoint‑stili 3D biçimlendirme oluşturabilir, düzenleyebilir, koruyabilir ve işleyebilir. Bu makale, döndürme, ekstrüzyon, köşe yumuşatma, aydınlatma, malzeme, degrade veya resim dolguları ve 3D metin gibi 3D efektleri kapsar.

{{% alert color="info" title="Not" %}}
Bu makale, PowerPoint şekilleri ve metni üzerindeki 3D biçimlendirme efektleriyle ilgilidir. Ayrı 3D model dosyalarını ekleme veya düzenleme ile ilgili değildir. Bir slaytı resim, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3D efektlerini dışa aktarılmış 2D çıktıya işler.
{{% /alert %}}

Paketi, [Installation](/slides/tr/python-java/installation/) bölümünde açıklandığı gibi kurun. Her örnek `asposeslides`ı içe aktarır, gerekiyorsa JVM’i başlatır ve ardından API’yi içe aktarır. Resim dolgu örneği, çalışma dizininde bir `image.jpg` dosyası gerektirir.

## **3D Biçimlendirme Kavramları**

Bir şekle 3D biçimlendirme uygulamak için [Shape.getThreeDFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getThreeDFormat) kullanın. Döndürülen format nesnesi, o şekil için 3D sahneyi kontrol eder.

Metin için, [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#getThreeDFormat) kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3D biçimlendirme uygular.

En önemli API üyeleri şunlardır:

| API üyesi | Ne kontrol eder | Ne zaman kullanılır |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getCamera) | Görüş noktası, önceden tanımlı kamera türü, döndürme, yakınlaştırma ve perspektif. | Nesneyi 3D uzayda döndürmek veya PowerPoint 3D döndürme ön ayarını eşleştirmek için. |
| [getLightRig](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getLightRig) | Işık ön ayarı, yön ve ışık döndürmesi. | 3D yüzeydeki vurguların ve gölgelerin nasıl göründüğünü değiştirmek için. |
| [getMaterial](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getMaterial) ve [setMaterial](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#setMaterial) | Düz, mat, plastik veya metal gibi yüzey malzemesi. | Aynı geometriyi daha düz, daha yumuşak, parlak veya metalik göstermek için. |
| [getExtrusionHeight](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getExtrusionHeight) ve [setExtrusionHeight](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Şeklin ön yüzünden geriye doğru ne kadar uzandığı. | Düz bir şekli gözle görülür kalın bir 3D nesneye dönüştürmek için. |
| [getExtrusionColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getExtrusionColor) | Ekstrüde edilmiş yan yüzlerin rengi. | Derinliği görünür kılmak veya yan rengi ön dolgu ile eşleştirmek için. |
| [getDepth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getDepth) ve [setDepth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D biçimlendirmesinde kullanılan ek 3D derinlik. | Şekiller veya metin için derinliği ince ayarlamak, özellikle köşe yumuşatma ve malzeme ayarlarıyla birlikte. |
| [getBevelTop](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getBevelTop) ve [getBevelBottom](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getBevelBottom) | Ön ve arka yüzlerdeki yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüz yerine yumuşatılmış veya kalıplanmış bir kenar eklemek için. |
| [getContourColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getContourWidth) ve [setContourWidth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#setContourWidth) | 3D nesnenin etrafındaki kontur. | İşlenmiş çıktıda nesne sınırını vurgulamak için. |

## **3D Şekil Oluşturma**

Bir şeklin inandırıcı bir 3D görünüm alabilmesi için genellikle dört tür ayar gerekir:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Işık ayarları, çünkü aydınlatma yüzeylerin ve yanların okunabilir olmasını sağlar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl işlendiğini etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler, 3D biçimlendirme uygular, sunumu PPTX olarak kaydeder ve slaytı PNG resim olarak işler.

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

İşlenmiş slayt resmi, dikdörtgeni kalın bir 3D blok olarak gösterir:

![Ön yüzünde beyaz 3D metinli mavi 3D dikdörtgenin işlenmiş görüntüsü](img_01_01.png)

## **Kamerayla Şekli Döndürme**

PowerPoint’te 3D döndürme, 3‑D Rotation bölmesinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API’si üzerinden ayarladığınız döndürmeye karşılık gelir.

![X, Y ve Z döndürme değerleri vurgulanmış PowerPoint 3‑D Rotation bölmesi](img_02_01.png)

Aspose.Slides’da, [Shape.getThreeDFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getThreeDFormat) tarafından döndürülen 3D format üzerinden kamera türünü ve döndürmeyi ayarlayın:

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

Kamera, izleyicinin nesneyi nasıl gördüğünü değiştirmek istediğinizde kullanılır. Slayttaki 2D şekil geometrisini değiştirmez; PowerPoint ve Aspose.Slides tarafından render edildiğinde kullanılan 3D bakış noktasını değiştirir.

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, bir şekli ön yüzünün arkasına uzatarak kalın gösterir. PowerPoint’te derinlik kontrolü bu görünür kalınlığı ayarlar, renk kontrolü ise yan yüzlerin rengini belirler.

![PowerPoint derinlik kontrolleri, ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlenmiştir](img_02_02.png)

Kalınlık için ekstrüzyon yüksekliğini, yan renk için ekstrüzyon rengini ayarlayın:

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

Derinlik ayarı, PowerPoint’in derinlik değerini doğrudan kullanmanız veya derinliği köşe yumuşatma, malzeme ve metin efektleriyle birleştirmeniz gerektiğinde kullanılır. Çoğu şekil senaryosunda, ekstrüzyon yüksekliği doğrudan görünür ekstrüzyonu ifade ettiği için daha net bir ayardır.

## **3D Efektlerle Degrade veya Resim Dolguları Kullanma**

3D biçimlendirme, şekil dolgusundan bağımsızdır. Ön yüze katı bir renk, degrade, desen veya resim dolgu uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını kullanabilirsiniz.

Bu örnek, şekle bir degrade dolgu uygular ve yanlara daha koyu bir ekstrüzyon rengi verir:

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

İşlenmiş çıktı, ön yüze degradeyi korur ve ekstrüzyonu ayrı olarak render eder:

![Mavi‑turuncu degrade dolgu ve turuncu ekstrüzyonlu işlenmiş 3D dikdörtgen](img_02_03.png)

Resim dolgu kullanmak için, resmi sunuma ekleyin ve şekil dolgusuna atayın:

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

Resim ön yüze işlenir, ekstrüzyon ise 3D yan yüz olarak render olur:

![Ön yüze fotoğraf dolgu ve turuncu ekstrüzyonlu işlenmiş 3D dikdörtgen](img_02_04.png)

## **Metne 3D Biçimlendirme Uygulama**

Şekil 3D biçimlendirmesi şekil gövdesini etkiler. Metin 3D biçimlendirmesi metin çerçevesini etkiler. Harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarlarına ihtiyaç duyduğu WordArt benzeri efektler için faydalıdır.

Aşağıdaki örnek, desen dolgu ile metin oluşturur, bir WordArt dönüşümü uygular ve [TextFrameFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/) üzerinde 3D ayarları yapılandırır:

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

Metin, kavisli, ekstrüde 3D harfler olarak render edilir:

![Kavisli WordArt dönüşümü, turuncu desen dolgu ve koyu ekstrüzyonlu işlenmiş 3D metin](img_02_05.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarında 3D biçimlendirmeyi korur. Sabit‑sayfa formatlarına render ederken veya dışa aktarırken, 3D sahne rasterleştirilir veya 2D sonuç olarak çıktıya çizilir. Bu, slaytları PNG’ye render ederken, PDF, HTML dışa aktarırken veya video dönüşümü için çerçeveler üretirken geçerlidir.

Şunlara dikkat edin:

- Dışa aktarılan resimler ve PDF’ler etkileşimli değildir. Nesne dışa aktarıldıktan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık rig’i, malzeme, ekstrüzyon, dolgu ve slayt ölçeklendirmesinin birleşimine bağlıdır.
- Kalıtılmış veya tema‑bazlı biçimlendirme değerlerini incelemeniz gerektiğinde, etkin biçimlendirme API’sini kullanın.
- Bazı çıktı formatları düzenlenebilir PowerPoint 3D biçimlendirmesini saklayamaz. Bu formatlarda görsel sonuç render edilir, düzenlenebilir 3D ayarları olarak korunmaz.

## **SSS**

**Aspose.Slides etkileşimli 3D sunumlar oluşturabilir mi?**

Aspose.Slides, şekiller ve metinler için PowerPoint 3D efektlerini oluşturur ve render eder. Dışa aktarılan resimler, PDF’ler veya HTML sayfalarını izleyicinin döndürebileceği etkileşimli 3D sahneler haline getirmez. PPTX içinde, format destekliyorsa 3D biçimlendirme PowerPoint’te düzenlenebilir kalır.

**3D model ile 3D efekt arasındaki fark nedir?**

3D model, bir sunuma eklenen ayrı bir 3D nesnedir. 3D efekt, bir PowerPoint şekli veya metnine uygulanan döndürme, ekstrüzyon, köşe yumuşatma, aydınlatma ve malzeme gibi biçimlendirmedir. Bu makale 3D efektleri ele alır.

**Görünür bir 3D şekil için hangi ayarlar gerekir?**

En azından bir kamera döndürmesi ve ekstrüzyon ya da derinlik ayarı yapılmalıdır. Pratikte, yüzeylerin net vurgular ve gölgeler alması için bir ışık rig’i ve malzeme de ayarlanması önerilir.

**Hem şekillere hem de metne 3D efekt uygulayabilir miyim?**

Evet. Şekil gövdesi için [Shape.getThreeDFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getThreeDFormat), metin için ise [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#getThreeDFormat) kullanın.

**3D efektler, resimler, PDF, HTML veya video çerçevelerine dışa aktarılırken görünür mü?**

Evet. Aspose.Slides, slayt resimleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan çerçeveler üretildiğinde 3D efektleri render eder. Dışa aktarılan çıktı, render edilmiş görünümü içerir; düzenlenebilir bir 3D nesne içermez.

**Kalıtım ve tema ayarları uygulandıktan sonra nihai 3D değerlerini okuyabilir miyim?**

Evet. Son kamera, ışık rig’i, köşe yumuşatma ve ilgili 3D değerlerini okumak için [ThreeDFormat.getEffective](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getEffective) kullanın.