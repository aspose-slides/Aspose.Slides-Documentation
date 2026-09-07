---
title: Python ile Sunumlarda 3B Efektler Oluşturma
linktitle: 3B Sunum
type: docs
weight: 232
url: /tr/python-java/3d-presentation/
keywords:
- 3B PowerPoint
- 3B sunum
- 3B döndürme
- 3B derinlik
- 3B ekstrüzyon
- 3B degrade
- 3B metin
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides ile Java üzerinden Python’da PowerPoint şekilleri ve metni için 3B etkileri uygulayın ve renderlayın. Kamera, aydınlatma, malzeme, ekstrüzyon, doldurmalar ve 3B metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, şekiller ve metin için PowerPoint tarzı 3B biçimlendirme oluşturabilir, düzenleyebilir, koruyabilir ve renderlayabilir. Bu makale, döndürme, ekstrüzyon, kenar yumuşatma, aydınlatma, malzeme, degrade veya resim doldurma ve 3B metin gibi 3B efektleri kapsar.

{{% alert color="info" title="Not" %}}
Bu makale, PowerPoint şekilleri ve metni üzerindeki 3B biçimlendirme efektleriyle ilgilidir. Ayrı 3B model dosyalarını ekleme veya düzenleme ile ilgili değildir. Bir slaytı resim, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3B efektleri dışa aktarılan 2B çıktı içine yansıtır.
{{% /alert %}}

Paketi, [Installation](/slides/tr/python-java/installation/) bölümünde açıklandığı gibi kurun. Her örnek `asposeslides` paketini içe aktarır, gerekirse JVM'i başlatır ve ardından API'yi içe aktarır. Resim doldurma örneği, çalışma dizininde bir `image.jpg` dosyası gerektirir.

## **3B Biçimlendirme Kavramları**

Bir şekle 3B biçimlendirme uygulamak için [Shape.getThreeDFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getThreeDFormat) adresini kullanın. Döndürülen format nesnesi, o şeklin 3B sahnesini kontrol eder.

Metin için, [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#getThreeDFormat) adresini kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3B biçimlendirme uygular.

En önemli API üyeleri şunlardır:

| API üyesi | Ne kontrol eder | Ne zaman kullanılır |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getCamera) | Görüş noktası, önceden ayarlanmış kamera türü, döndürme, yakınlaştırma ve perspektif. | Nesneyi 3B uzayda döndürmek ya da PowerPoint 3B döndürme ön ayarına uymak istediğinizde. |
| [getLightRig](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getLightRig) | Işık ön ayarı, yön ve ışık döndürmesi. | 3B yüzey üzerindeki vurguların ve gölgelerin nasıl görüneceğini değiştirmek için. |
| [getMaterial](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getMaterial) ve [setMaterial](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#setMaterial) | Düz, mat, plastik veya metal gibi yüzey malzemesi. | Aynı geometrinin daha düz, daha yumuşak, parlak veya metalik görünmesini sağlamak için. |
| [getExtrusionHeight](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getExtrusionHeight) ve [setExtrusionHeight](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Şeklin ön yüzünden geriye ne kadar uzandığı. | Düz bir şekli görünür kalın bir 3B nesneye dönüştürmek için. |
| [getExtrusionColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getExtrusionColor) | Ekstrüde edilen yan yüzlerin rengi. | Derinliği görünür kılmak ya da yan rengi ön doldurma ile eşleştirmek için. |
| [getDepth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getDepth) ve [setDepth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3B biçimlendirmesinde kullanılan ek 3B derinlik. | Şekil veya metin için derinliği ince ayarlamak, özellikle kenar yumuşatma ve malzeme ayarlarıyla birlikte. |
| [getBevelTop](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getBevelTop) ve [getBevelBottom](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getBevelBottom) | Ön ve arka yüzlerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüz yerine yumuşak ya da kalıplanmış bir kenar eklemek için. |
| [getContourColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getContourWidth) ve [setContourWidth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#setContourWidth) | 3B nesnenin etrafındaki kontur. | Renderlanmış çıktıda nesne sınırını vurgulamak için. |

## **3B Şekil Oluşturma**

Bir şekil genellikle ikna edici bir 3B görünüm elde etmek için dört tür ayara ihtiyaç duyar:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Aydınlatma ayarları, çünkü ışık yüzeylerin ve kenarların okunabilir olmasını sağlar.
- Malzeme ayarları, çünkü yüzey, ışığın nasıl yansıtıldığını etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler, 3B biçimlendirme uygular, sunumu PPTX olarak kaydeder ve slaytı PNG resim olarak renderlar.

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

![Ön yüzünde beyaz 3B metin bulunan mavi 3B dikdörtgenin renderlanmış görüntüsü](img_01_01.png)

## **Kamera ile Şekli Döndürme**

PowerPoint'te 3B döndürme, 3‑D Rotation bölmesinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API'si aracılığıyla ayarladığınız döndürmeye karşılık gelir.

![X, Y ve Z döndürme değerlerinin vurgulandığı PowerPoint 3‑B Döndürme bölmesi](img_02_01.png)

Aspose.Slides'te kamera türünü ve döndürmeyi, [Shape.getThreeDFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getThreeDFormat) tarafından döndürülen 3B format üzerinden ayarlayın:

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

İzleyicinin nesneyi nasıl gördüğünü değiştirmek istediğinizde kamerayı kullanın. Bu, slayttaki 2B şekil geometrisini değiştirmez; PowerPoint ve Aspose.Slides tarafından renderlarken kullanılan 3B bakış noktasını değiştirir.

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, bir şekli ön yüzünden geriye uzatarak kalın gösterir. PowerPoint'te derinlik kontrolü bu görünür kalınlığı ayarlar, renk kontrolü ise yan yüzlerin rengini ayarlar.

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

Derinlik ayarını, PowerPoint'in derinlik değerini doğrudan kullanmanız veya derinliği kenar yumuşatma, malzeme ve metin efektleriyle birleştirmeniz gerektiğinde kullanın. Çoğu şekil senaryosunda, ekstrüzyon yüksekliği doğrudan görünür ekstrüzyonu ifade ettiği için daha net bir ayardır.

## **3B Efektlerle Degrade veya Resim Doldurmaları Kullanma**

3B biçimlendirme, şekil doldurmadan bağımsızdır. Ön yüze katı renk, degrade, desen veya resim doldurması uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını kullanabilirsiniz.

Bu örnek, şekle degrade doldurma uygular ve yanlara daha koyu bir ekstrüzyon rengi verir:

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

![Mavi- Turuncu degrade doldurma ve turuncu ekstrüzyonlu renderlanmış 3B dikdörtgen](img_02_03.png)

Resim doldurma kullanmak isterseniz, resmi sunuma ekleyin ve şekil doldurmasına atayın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path
from java.nio.file import Files, Paths

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    file_path = str(Path("image.jpg").resolve())
    image_path = Paths.get(file_path)
    image_data = Files.readAllBytes(image_path)
    image = presentation.getImages().addImage(image_data)

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

Resim ön yüzünde renderlanırken, ekstrüzyon 3B yan yüz olarak renderlanır:

![Ön yüzünde fotoğraf doldurma ve turuncu ekstrüzyonlu renderlanmış 3B dikdörtgen](img_02_04.png)

## **Metne 3B Biçimlendirme Uygulama**

Şekil 3B biçimlendirmesi şekil gövdesini etkiler. Metin 3B biçimlendirmesi metin çerçevesini etkiler. Bu, harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarlarına ihtiyaç duyduğu WordArt benzeri efektler için faydalıdır.

Aşağıdaki örnek bir desen doldurmalı metin oluşturur, WordArt dönüşümü uygular ve [TextFrameFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/) üzerinde 3B ayarları yapılandırır:

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

![Kemerli WordArt dönüşümü, turuncu desen doldurma ve koyu ekstrüzyonlu renderlanmış 3B metin](img_02_05.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydederken 3B biçimlendirmeyi korur. Sabit‑düzen formatlarına renderlarken veya dışa aktarırken 3B sahne rasterleştirilir ve 2B sonuç olarak çıktıya çizilir. Bu, slaytları PNG’ye renderlarken, PDF’ye, HTML’ye dışa aktarırken veya video dönüşümü için kareler üretirken geçerlidir.

Şunları aklınızda bulundurun:

- Dışa aktarılan görüntüler ve PDF'ler etkileşimli değildir. Nesne dışa aktarımdan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık düzeni, malzeme, ekstrüzyon, doldurma ve slayt ölçeklemesinin birleşimine bağlıdır.
- Miras alınan veya tema tabanlı biçimlendirme değerlerini incelemeniz gerekiyorsa, etkili biçimlendirme API'sini kullanın.
- Bazı çıktı formatları düzenlenebilir PowerPoint 3B biçimlendirmesini depolayamaz. Bu formatlarda görsel sonuç renderlanır ve düzenlenebilir 3B ayar olarak korunmaz.

## **SSS**

**Aspose.Slides, etkileşimli 3B sunumlar oluşturabilir mi?**

Aspose.Slides, şekiller ve metin için PowerPoint 3B efektlerini oluşturur ve renderlar. Dışa aktarılan görüntüler, PDF'ler veya HTML sayfaları, izleyicinin döndürebileceği etkileşimli 3B sahneler haline getirmez. PPTX içinde, format destekliyorsa 3B biçimlendirme PowerPoint'te düzenlenebilir olarak kalır.

**Bir 3B model ile bir 3B efekt arasındaki fark nedir?**

3B model, sunuma eklenen ayrı bir 3B nesnedir. 3B efekt ise normal bir PowerPoint şekline veya metne uygulanan biçimlendirmedir; döndürme, ekstrüzyon, kenar yumuşatma, aydınlatma ve malzeme gibi. Bu makale 3B efektleri ele alır.

**Görünür bir 3B şekil için hangi ayarlar gereklidir?**

En az bir kamera döndürmesi ve ya ekstrüzyon ya da derinlik ayarı gerekir. Pratikte, yüzeylerin net vurgular ve gölgeler alması için bir ışık düzeni ve malzeme de ayarlanır.

**Hem şekillere hem de metne 3B efektler uygulayabilir miyim?**

Evet. Şekil gövdesi için [Shape.getThreeDFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getThreeDFormat), metin için ise [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#getThreeDFormat) kullanın.

**3B efektler, görüntülere, PDF'ye, HTML'ye veya video karelerine dışa aktarıldığında görünecek mi?**

Evet. Aspose.Slides, slayt resimleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan kareler üretildiğinde 3B efektleri renderlar. Dışa aktarılan çıktı renderlanmış görünümü içerir, düzenlenebilir bir 3B nesne içermez.

**Miras ve tema ayarları uygulandıktan sonra son 3B değerleri okuyabilir miyim?**

Evet. Son kamera, ışık düzeni, kenar yumuşatma ve ilgili 3B değerlerini okumak için [ThreeDFormat.getEffective](https://reference.aspose.com/slides/tr/python-java/aspose.slides/threedformat/#getEffective) yöntemini kullanın.