---
title: Vytvořit 3D efekty v prezentacích pomocí Pythonu
linktitle: 3D prezentace
type: docs
weight: 232
url: /cs/python-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentace
- 3D rotace
- 3D hloubka
- 3D extruze
- 3D přechod
- 3D text
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Použít a vykreslit 3D efekty pro tvary a text v PowerPointu v Pythonu přes Java s Aspose.Slides. Nastavit kameru, osvětlení, materiál, extruzi, výplně a 3D text."
---
## **Přehled**

Aspose.Slides for Python via Java může vytvářet, upravovat, zachovávat a vykreslovat 3D formátování podobné PowerPointu pro tvary a text. Tento článek popisuje 3D efekty jako rotaci, extruzi, zkosení, osvětlení, materiál, gradient nebo obrázkové výplně a 3D text.

{{% alert color="info" title="Note" %}}

Tento článek se týká 3D formátovacích efektů na tvary a text v PowerPointu. Nejedná se o vkládání nebo úpravu samostatných souborů 3D modelů. Když exportujete snímek jako obrázek, PDF nebo HTML, Aspose.Slides vykreslí tyto 3D efekty do exportovaného 2D výstupu.

{{% /alert %}}

## **Koncepty 3D formátování**

Použijte metodu [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) pro aplikaci 3D formátování na tvar. Metoda vrací [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/), který řídí 3D scénu pro daný tvar.

Pro text použijte metodu [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat). Tím se 3D formátování použije na textový rámeček místo těla tvaru.

Nejdůležitější členové API jsou:

| Člen API | Co řídí | Kdy použít |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) | Pohled, přednastavený typ kamery, rotace, zoom a perspektiva. | Rotovat objekt ve 3D prostoru nebo použít přednastavenou 3D rotaci PowerPointu. |
| [getLightRig](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getLightRig) | Přednastavení světla, směr a rotace světla. | Změnit, jak se zvýraznění a stíny zobrazují na 3D povrchu. |
| [getMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getMaterial) a [setMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setMaterial) | Materiál povrchu, např. plochý, matný, plastový nebo kovový. | Způsobit, aby stejná geometrie vypadala plochěji, měkče, leskleji nebo kovově. |
| [getExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionHeight) a [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Jak daleko tvar vyčnívá dozadu od své přední plochy. | Přeměnit plochý tvar na viditelně tlustý 3D objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) | Barva extrudovaných stran. | Zviditelnit hloubku nebo sladit barvu stran s přední výplní. |
| [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getDepth) a [setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) | Další 3D hloubka používaná PowerPoint 3D formátováním. | Doladit hloubku pro tvary nebo text, zejména spolu s nastavením zkosení a materiálu. |
| [getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) a [getBevelBottom](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelBottom) | Zvednuté nebo zaoblené hrany na přední a zadní ploše. | Přidat změkčený nebo tvarovaný okraj místo ostré ploché plochy. |
| [getContourColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourColor) a [getContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourWidth) a [setContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setContourWidth) | Obrys kolem 3D objektu. | Zvýraznit hranice objektu ve vykresleném výstupu. |

## **Vytvoření 3D tvaru**

Tvar obvykle potřebuje čtyři typy nastavení, než bude vypadat věrohodně 3D:

- Nastavení kamery, protože výchozí přední pohled může skrýt extruzi.
- Nastavení světla, protože osvětlení umožňuje rozpoznat plochy a strany.
- Nastavení materiálu, protože povrch ovlivňuje, jak se světlo vykresluje.
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje tloušťku.

Níže uvedený příklad vytvoří obdélník, přidá text na jeho přední plochu a použije 3D formátování. Hodnoty rotace kamery jsou ve stupních a výška extruze je 100 bodů. Příklad vykreslí snímek do PNG obrázku ve dvojnásobném výchozím rozměru a uloží prezentaci jako PPTX.

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

Vykreslený snímek ukazuje obdélník jako tlustý 3D blok:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Otočení tvaru pomocí kamery**

V PowerPointu se 3D rotace nastavuje v panelu 3‑D Rotation. Hodnoty rotace X, Y a Z odpovídají rotaci, kterou nastavíte prostřednictvím API kamery.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

V Aspose.Slides získáte kameru pomocí [ThreeDFormat.getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera). Tento příklad vytvoří obdélník, vybere ortografický přední pohled a nastaví jeho rotace X, Y a Z na 20, 30 a 40 stupňů. Konfiguruje tvar v paměti bez ukládání souboru:

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

Použijte kameru, když potřebujete změnit, jak divák objekt vidí. Nemění 2D geometrii tvaru na snímku. Mění 3D pohled, který používá PowerPoint a Aspose.Slides při vykreslování.

### **Zkopírování orientace kamery ze šablonového tvaru**

Pro shodu orientace šablonového tvaru načtěte jeho přednastavení kamery pomocí [Camera.getCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getCameraType) a úhly rotace pomocí [Camera.getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getRotation). Příklad otevře `template.pptx` a zkopíruje orientaci kamery z prvního tvaru na první snímku do druhého tvaru. Oba tvary již mají 3D osvětlení a druhý tvar nemá explicitní rotaci kamery.

Úhly jsou ve stupních. Index `0` je zeměpisná šířka, index `1` je délka a index `2` je revoluce. Předávejte je do [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) v tomto pořadí. Pokud zdroj vrátí `None`, nemá explicitní rotaci, takže ponechte úhly druhého tvaru nenastavené. Explicitní rotace `(0, 0, 0)` vrací tři nuly a měla by být zkopírována.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("template.pptx")
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    source_camera = shapes.get_Item(0).getThreeDFormat().getCamera()
    destination_camera = shapes.get_Item(1).getThreeDFormat().getCamera()

    destination_camera.setCameraType(source_camera.getCameraType())
    angles = source_camera.getRotation()
    if angles is not None:
        destination_camera.setRotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Když znovu otevřete `camera-copy.pptx` v PowerPointu, šipka napravo má stejné přednastavení kamery a rotaci jako obdélník vlevo. Oba tvary používají stejné osvětlení a hloubku extruze.

![A blue 3D rectangle and a right arrow with matching camera orientation, viewed from above and to the right](camera-orientation.png)

## **Přidání extruze a hloubky**

Extruze způsobí, že tvar vypadá tlustě tím, že se prodlužuje za přední plochu. V PowerPointu kontrola hloubky nastavuje tuto viditelnou tloušťku a kontrola barvy nastavuje barvu bočních ploch.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Použijte [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) k nastavení tloušťky a [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) k přístupu k barvě stran. Tento příklad dává obdélníku 100‑bodovou extruzi s fialovými stranami a otáčí kameru, aby odhalila jeho tloušťku. Konfiguruje tvar v paměti bez ukládání souboru:

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

Metoda [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) nastavuje hloubku 3D tvaru. Metoda [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) řídí výšku efektu extruze, jak je ukázáno v tomto příkladu.

## **Použití gradientových nebo obrázkových výplní s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Můžete použít plnou barvu, gradient, vzor nebo obrázkovou výplň na přední plochu a stále používat stejnou kameru, světlo, materiál a nastavení extruze.

Tento příklad aplikuje gradient od modré k oranžové na přední plochu a tmavě oranžovou barvu na 150‑bodovou extruzi. Zastávky gradientu při 0 a 100 označují začátek a konec gradientu. Hodnoty rotace kamery jsou ve stupních. Snímek je vykreslen do PNG obrázku ve dvojnásobném výchozím rozměru:

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

Vykreslený výstup zachovává gradient na přední ploše a extruzi vykresluje samostatně:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

Pro použití obrázkové výplně přidejte obrázek do prezentace a přiřaďte jej výplni tvaru. Tento příklad vyžaduje existující soubor s názvem „image.jpg“ v pracovním adresáři. Obrázek se roztáhne tak, aby vyplnil obdélník, aplikuje 150‑bodovou extruzi a nastaví rotaci kamery ve stupních. Konfiguruje tvar v paměti bez ukládání nebo vykreslování souboru:

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

Obrázek je vykreslen na přední ploše, zatímco extruze je vykreslena jako 3D boční povrch:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **Aplikace 3D formátování na text**

3D formátování tvaru ovlivňuje tělo tvaru. 3D formátování textu ovlivňuje textový rámec. To je užitečné pro efekty podobné WordArt, kde samotná písmena potřebují extruzi, materiál, osvětlení a nastavení kamery.

Následující příklad vytvoří text s oranžovo‑bílým vzorem mřížky, aplikuje klenutý oblouk a nastaví 3D parametry pomocí [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat). Výška a hloubka extruze jsou v bodech, rotace světla ve stupních. Výplň a obrys tvaru jsou skryty, aby byl viditelný pouze text. Příklad vykreslí PNG obrázek ve dvojnásobném výchozím rozměru snímku a uloží prezentaci jako PPTX:

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

Text je vykreslen jako zakřivené, extrudované 3D písmo:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Udržet text plochý na 3D tvaru**

Aby byl text čitelný při zachování 3D vzhledu tvaru, zavolejte [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setKeepTextFlat) přes [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getTextFrameFormat). Když je hodnota `True`, text zůstává mimo 3D scénu. Když je `False`, text se podílí na scéně a následuje její 3D orientaci.

Toto nastavení neodstraňuje 3D formátování tvaru: jeho kamera, osvětlení, materiál a extruze zůstávají nastaveny přes [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat). Je to také odlišné od běžné rotace. [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) otáčí tvar v rovině snímku, zatímco [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) řídí vlastní rotaci textu v jeho ohraničujícím rámečku. Udržení textu mimo 3D scénu nerese žádný z těchto úhlů.

Následující samostatný příklad vytvoří modrý obdélník s textem a zkopíruje jej vedle originálu. Oba tvary mají stejné 3D formátování; liší se pouze nastavením textu: `False` vlevo a `True` vpravo. Úhly kamery jsou ve stupních a výška extruze je 40 bodů. Příklad uloží prezentaci jako PPTX a vykreslí srovnávací snímek do PNG ve dvojnásobném výchozím rozměru.

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

Vlevo text následuje 3D orientaci. Vpravo zůstává plochý a snadněji čitelný. Oba obdélníky zachovávají stejnou viditelnou extruzi a 3D orientaci.

![Side-by-side 3D rectangles: text follows the 3D orientation on the left and stays flat on the right](keep_text_flat.png)

## **Export a chování při vykreslování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při vykreslování nebo exportu do formátů s pevnou stránkou se 3D scéna rasterizuje nebo vloží do výstupu jako 2D výsledek. To platí, když renderujete snímky do [PNG](/slides/cs/python-java/convert-powerpoint-to-png/), exportujete do [PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/), exportujete do [HTML](/slides/cs/python-java/convert-powerpoint-to-html/), nebo vytváříte snímky pro [konverzi videa](/slides/cs/python-java/convert-powerpoint-to-video/).

Mějte na paměti následující body:

- Exportované obrázky a PDF nejsou interaktivní. Objekt nelze po exportu otáčet.
- Konečný vzhled závisí na kombinaci kamery, osvětlení, materiálu, extruze, výplně a měřítka snímku.
- Pokud potřebujete zkontrolovat zděděné nebo tématem definované hodnoty formátování, přečtěte [efektivní vlastnosti tvaru](/slides/cs/python-java/shape-effective-properties/).
- Některé výstupní formáty nemohou uložit editovatelné 3D formátování PowerPointu. V těchto formátech je vizuální výsledek vykreslen spíše než zachován jako editovatelné 3D nastavení.

## **Často kladené dotazy**

**Může Aspose.Slides vytvořit interaktivní 3D prezentace?**

Aspose.Slides vytváří a vykresluje PowerPoint 3D efekty pro tvary a text. Nevytváří interaktivní 3D scény v exportovaných obrázcích, PDF nebo HTML, které by uživatel mohl otáčet. V PPTX zůstává 3D formátování editovatelné v PowerPointu, kde formát podporuje úpravy.

** Jaký je rozdíl mezi 3D modelem a 3D efektem?**

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný PowerPoint tvar nebo text, jako je rotace, extruze, zkosení, osvětlení a materiál. Tento článek se věnuje 3D efektům.

** Jaká nastavení jsou vyžadována pro viditelný 3D tvar?**

Minimálně nastavit rotaci kamery a buď extruzi, nebo hloubku. V praxi také nastavte osvětlení a materiál, aby renderované plochy měly jasné zvýraznění a stíny.

** Mohu aplikovat 3D efekty na tvary i text?**

Ano. Použijte [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) pro tělo tvaru a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) pro text.

** Zobrazí se 3D efekty při exportu do obrázků, PDF, HTML nebo video snímků?**

Ano. Aspose.Slides vykresluje 3D efekty při tvorbě obrázků snímků, PDF výstupu, HTML výstupu a snímcích používaných pro konverzi videa. Exportovaný výstup obsahuje vykreslený vzhled, nikoli editovatelný 3D objekt.

** Mohu přečíst konečné 3D hodnoty po aplikaci dědičnosti a nastavení tématu?**

Ano. Použijte API pro efektivní formátování popsané v [Shape Effective Properties](/slides/cs/python-java/shape-effective-properties/) k přečtení finálních hodnot kamery, osvětlení, zkosení a souvisejících 3D parametrů.