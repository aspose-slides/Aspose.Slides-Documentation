---
title: Vytvoření 3D efektů v prezentacích pomocí Pythonu
linktitle: 3D Prezentace
type: docs
weight: 232
url: /cs/python-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentace
- 3D otáčení
- 3D hloubka
- 3D extruze
- 3D přechod
- 3D text
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Použijte a vykreslete 3D efekty pro tvary a text v PowerPointu v Pythonu přes Java pomocí Aspose.Slides. Nakonfigurujte kameru, osvětlení, materiál, extruzi, výplně a 3D text."
---
## **Přehled**

Aspose.Slides for Python via Java může vytvářet, upravovat, zachovávat a vykreslovat 3D formátování ve stylu PowerPointu pro tvary a text. Tento článek se zabývá 3D efekty, jako jsou otáčení, extruze, zkosení, osvětlení, materiál, přechodové nebo obrázkové výplně a 3D text.

{{% alert color="info" title="Note" %}}
Tento článek se zabývá 3D formátovacími efekty na tvarech a textu v PowerPointu. Nejedná se o vkládání nebo úpravu samostatných 3D modelových souborů. Když exportujete snímek do obrázku, PDF nebo HTML, Aspose.Slides vykreslí tyto 3D efekty do exportovaného 2D výstupu.
{{% /alert %}}

## **Základy 3D formátování**

K aplikaci 3D formátování na tvar použijte metodu [Shape.getThreeDFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getThreeDFormat). Tato metoda vrací [ThreeDFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/), který řídí 3D scénu pro daný tvar.

Pro text použijte metodu [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#getThreeDFormat). Tato metoda aplikuje 3D formátování na textový rámec místo těla tvaru.

Nejdůležitější členové API jsou:

| Člen API | Co ovládá | Kdy použít |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getCamera) | Bod pohledu, přednastavený typ kamery, rotace, zoom a perspektiva. | Otočit objekt ve 3D prostoru nebo odpovídat přednastavenému 3D otáčení v PowerPointu. |
| [getLightRig](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getLightRig) | Přednastavení světla, směr a rotace světla. | Změnit, jak se na 3D povrchu objevují světla a stíny. |
| [getMaterial](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getMaterial) a [setMaterial](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#setMaterial) | Materiál povrchu, např. plochý, matný, plastový nebo kovový. | Způsobit, aby stejná geometrie vypadala plochěji, měkčeji, leskleji nebo kovově. |
| [getExtrusionHeight](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getExtrusionHeight) a [setExtrusionHeight](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Jak daleko se tvar prodlužuje zpět od své přední strany. | Přeměnit plochý tvar na viditelně tlustý 3D objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getExtrusionColor) | Barva extrudovaných stran. | Zobrazit hloubku nebo sladit barvu stran s výplní přední strany. |
| [getDepth](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getDepth) a [setDepth](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#setDepth) | Další 3D hloubka používaná formátováním 3D v PowerPointu. | Upravit hloubku tvarů nebo textu, zejména spolu s nastavením zkosení a materiálu. |
| [getBevelTop](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getBevelTop) a [getBevelBottom](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getBevelBottom) | Vyvýšené nebo zaoblené hrany na přední a zadní straně. | Přidat zjemněný nebo tvarovaný okraj místo ostré ploché strany. |
| [getContourColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getContourColor) a [getContourWidth](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getContourWidth) a [setContourWidth](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#setContourWidth) | Obrys kolem 3D objektu. | Zdůraznit hranice objektu ve vykresleném výstupu. |

## **Vytvořit 3D tvar**

- Nastavení kamery, protože výchozí přední pohled může skrýt extruzi.
- Nastavení osvětlení, protože osvětlení dělá povrchy a strany čitelné.
- Nastavení materiálu, protože povrch ovlivňuje, jak se světlo vykresluje.
- Nastavení extruze nebo hloubky, protože plochý tvar potřebuje tloušťku.

Následující příklad vytvoří obdélník, přidá text na jeho přední stranu a použije 3D formátování. Hodnoty rotace kamery jsou ve stupních a výška extruze je 100 bodů. Příklad vykreslí snímek do PNG obrázku dvojnásobně většího než výchozí rozměry a uloží prezentaci jako PPTX.

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

Vykreslený obrázek snímku ukazuje obdélník jako tlustý 3D blok:

![Vykreslený modrý 3D obdélník s bílým 3D textem na přední straně](img_01_01.png)

## **Otočit tvar pomocí kamery**

V PowerPointu se 3D rotace nastavuje v panelu 3‑D Rotace. Hodnoty rotace X, Y a Z odpovídají rotaci nastavené pomocí API kamery.

![Panel PowerPointu 3‑D Rotace se zvýrazněnými hodnotami rotace X, Y a Z](img_02_01.png)

V Aspose.Slides přistupujete ke kameře pomocí [ThreeDFormat.getCamera](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getCamera). Tento příklad vytvoří obdélník, vybere ortografický přední pohled a nastaví jeho rotace X, Y a Z na 20, 30 a 40 stupňů. Nastavuje tvar v paměti bez uložení souboru:

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

Použijte kameru, když potřebujete změnit, jak divák vidí objekt. Nemění geometrii 2D tvaru na snímku. Mění 3D pohled, který používá PowerPoint a Aspose.Slides při vykreslování.

## **Přidat extruzi a hloubku**

Extruze způsobí, že tvar vypadá tlustě tím, že se prodlouží za přední stranu. V PowerPointu nastavení hloubky určuje tuto viditelnou tloušťku a nastavení barvy určuje barvu bočních stran.

![Ovládání hloubky v PowerPointu přiřazené k vlastnostem barvy extruze a výšky extruze](img_02_02.png)

Použijte [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#setExtrusionHeight), abyste nastavili tloušťku, a [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getExtrusionColor), abyste získali barvu stran. Tento příklad přidá obdélníku 100‑bodovou extruzi s fialovými stranami a otočí kameru, aby odhalila jeho tloušťku. Nastavuje tvar v paměti bez uložení souboru:

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

Metoda [ThreeDFormat.setDepth](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#setDepth) nastavuje hloubku 3D tvaru. Metoda [setExtrusionHeight](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#setExtrusionHeight) řídí výšku efektu extruze, jak je ukázáno v tomto příkladu.

## **Použít gradientové nebo obrázkové výplně s 3D efekty**

3D formátování je nezávislé na výplni tvaru. Můžete aplikovat plnou barvu, gradient, vzor nebo obrázkovou výplň na přední stranu a stále používat stejné nastavení kamery, světla, materiálu a extruze.

Tento příklad použije gradient od modré po oranžovou na přední stranu a tmavě oranžovou barvu pro 150‑bodovou extruzi. Zastavení gradientu na 0 a 100 označují začátek a konec gradientu. Hodnoty rotace kamery jsou ve stupních. Snímek je vykreslen do PNG obrázku dvojnásobně většího než výchozí rozměry:

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

Vykreslený výstup zachová gradient na přední straně a extruzi vykreslí samostatně:

![Vykreslený 3D obdélník s gradientní výplní od modré po oranžovou a oranžovou extruzí](img_02_03.png)

Pro použití obrázkové výplně místo toho přidejte obrázek do prezentace a přiřaďte jej k výplni tvaru. Tento příklad vyžaduje existující soubor s názvem "image.jpg" v pracovním adresáři. Roztáhne obrázek tak, aby vyplnil obdélník, aplikuje 150‑bodovou extruzi a nastaví rotaci kamery ve stupních. Nastavuje tvar v paměti bez uložení nebo vykreslení souboru:

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

![Vykreslený 3D obdélník s fotografickou výplní na přední straně a oranžovou extruzí](img_02_04.png)

## **Použít 3D formátování na text**

3D formátování tvaru ovlivňuje tělo tvaru. 3D formátování textu ovlivňuje textový rámec. To je užitečné pro efekty podobné WordArt, kde samotná písmena potřebují extruzi, materiál, osvětlení a nastavení kamery.

Následující příklad vytvoří text s oranžovo‑bílým mřížkovým vzorem, aplikuje horní oblouk a nakonfiguruje 3D nastavení pomocí [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#getThreeDFormat). Výška a hloubka extruze jsou v bodech a rotace světla ve stupních. Výplň a obrys tvaru jsou skryté, aby byl viditelný pouze text. Příklad vykreslí PNG obrázek dvojnásobně větší než výchozí rozměry snímku a uloží prezentaci jako PPTX:

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

![Vykreslený 3D text s obloukovou WordArt transformací, oranžovou výplní vzoru a tmavou extruzí](img_02_05.png)

## **Udržet text plochý na 3D tvaru**

Aby byl text čitelný a zároveň se zachoval 3D vzhled tvaru, zavolejte [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setKeepTextFlat). Když je hodnota `True`, text zůstává mimo 3D scénu. Když je `False`, text se zapojí do scény a následuje její 3D orientaci.

Toto nastavení neodstraňuje 3D formátování tvaru: jeho kamera, osvětlení, materiál a extruze zůstávají nastaveny pomocí [Shape.getThreeDFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getThreeDFormat). Je to také odlišné od běžné rotace. [Shape.setRotation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#setRotation) otáčí tvar v rovině snímku, zatímco [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setRotationAngle) řídí vlastní rotaci textu v rámci jeho ohraničujícího rámečku. Udržení textu mimo 3D scénu neresetuje žádný z těchto úhlů.

Následující samostatný příklad vytvoří modrý obdélník s textem a zkopíruje jej vedle originálu. Oba tvary mají stejné 3D formátování; liší se pouze nastavení textu: `False` vlevo a `True` vpravo. Úhly kamery jsou ve stupních a výška extruze je 40 bodů. Příklad uloží prezentaci jako PPTX a vykreslí srovnávací snímek do PNG dvojnásobně většího než výchozí rozměry.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

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

![Postranně umístěné 3D obdélníky: text následuje 3D orientaci vlevo a zůstává plochý vpravo](keep_text_flat.png)

## **Export a chování vykreslování**

Aspose.Slides zachovává 3D formátování při ukládání do formátů PowerPointu, jako je PPTX. Při vykreslování nebo exportu do formátů s pevnou stránkou je 3D scéna rastrována nebo vložena do výstupu jako 2D výsledek. To platí, když vykreslujete snímky do [PNG](/slides/cs/python-java/convert-powerpoint-to-png/), exportujete do [PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/), exportujete do [HTML](/slides/cs/python-java/convert-powerpoint-to-html/), nebo generujete snímky pro [video conversion](/slides/cs/python-java/convert-powerpoint-to-video/).

Mějte na paměti následující body:

- Exportované obrázky a PDF nejsou interaktivní. Objekt nelze po exportu otáčet.
- Konečný vzhled závisí na kombinaci kamery, světelného zařízení, materiálu, extruze, výplně a měřítka snímku.
- Pokud potřebujete zkontrolovat zděděné nebo tématem podmíněné hodnoty formátování, přečtěte si [efektivní vlastnosti tvaru](/slides/cs/python-java/shape-effective-properties/).
- Některé výstupní formáty nemohou uložit editovatelné 3D formátování PowerPointu. V těchto formátech je vizuální výsledek vykreslen místo toho, aby byl zachován jako editovatelné 3D nastavení.

## **FAQ**

**Může Aspose.Slides vytvářet interaktivní 3D prezentace?**

Aspose.Slides vytváří a vykresluje PowerPoint 3D efekty pro tvary a text. Nevytváří interaktivní 3D scény v exportovaných obrázcích, PDF nebo HTML stránkách, které by divák mohl otáčet. V PPTX zůstává 3D formátování editovatelné v PowerPointu, pokud formát podporuje.

**Jaký je rozdíl mezi 3D modelem a 3D efektem?**

3D model je samostatný 3D objekt vložený do prezentace. 3D efekt je formátování aplikované na běžný tvar nebo text v PowerPointu, jako je rotace, extruze, zkosení, osvětlení a materiál. Tento článek se zabývá 3D efekty.

**Jaká nastavení jsou potřebná pro viditelný 3D tvar?**

Minimálně nastavte rotaci kamery a buď extruzi nebo hloubku. V praxi také nastavte světelné zařízení a materiál, aby měly vykreslené plochy jasné světelné odrazy a stíny.

**Mohu aplikovat 3D efekty na tvary i text?**

Ano. Použijte [Shape.getThreeDFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getThreeDFormat) pro tělo tvaru a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#getThreeDFormat) pro text.

**Zobrazí se 3D efekty při exportu do obrázků, PDF, HTML nebo video snímků?**

Ano. Aspose.Slides vykresluje 3D efekty při vytváření obrázků snímků, PDF výstupu, HTML výstupu a snímcích používaných pro konverzi videa. Exportovaný výstup obsahuje vykreslený vzhled, nikoli editovatelný 3D objekt.

**Mohu přečíst konečné 3D hodnoty po aplikaci dědičnosti a nastavení tématu?**

Ano. Použijte API pro efektivní formátování popsané v [efektivních vlastnostech tvaru](/slides/cs/python-java/shape-effective-properties/), abyste přečetli konečné hodnoty kamery, světelného zařízení, zkosení a souvisejících 3D hodnot.