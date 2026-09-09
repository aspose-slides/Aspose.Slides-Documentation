---
title: 3D hatások létrehozása prezentációkban Python használatával
linktitle: 3D prezentáció
type: docs
weight: 232
url: /hu/python-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentáció
- 3D forgatás
- 3D mélység
- 3D extrudálás
- 3D fokozat
- 3D szöveg
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Alkalmazza és renderelje a 3D hatásokat PowerPoint alakzatokra és szövegre Pythonon keresztül Java-val az Aspose.Slides segítségével. Konfigurálja a kamerát, a megvilágítást, az anyagot, az extrudálást, a kitöltéseket és a 3D szöveget."
---
## **Áttekintés**

Aspose.Slides for Python via Java képes létrehozni, szerkeszteni, megőrizni és megjeleníteni a PowerPoint‑szerű 3D formázást alakzatokra és szövegre. Ez a cikk az olyan 3D hatásokat tárgyalja, mint a forgatás, extrudálás, rézsút, megvilágítás, anyag, fokozatos vagy képpel kitöltés, valamint a 3D szöveg.

{{% alert color="info" title="Megjegyzés" %}}
Ez a cikk a PowerPoint alakzatok és szöveg 3D formázási hatásairól szól. Nem a különálló 3D modellfájlok beszúrásáról vagy szerkesztéséről szól. Amikor egy diát képre, PDF‑re vagy HTML‑re exportálsz, az Aspose.Slides ezeket a 3D hatásokat a exportált 2D kimenetbe rendereli.
{{% /alert %}}

Telepítsd a csomagot a [Telepítés](/slides/hu/python-java/installation/) leírása szerint. Minden példa importálja a `asposeslides`‑t, ha szükséges elindítja a JVM‑et, majd importálja az API‑t. A kép‑kitöltéses példa egy `image.jpg` fájlt igényel a munkakönyvtárban.

## **3D formázási koncepciók**

Használd a [Shape.getThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getThreeDFormat) metódust, hogy 3D formázást alkalmazz egy alakzatra. A visszaadott formátumobjektum vezérli az adott alakzat 3D jelenetét.

Szöveg esetén használd a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#getThreeDFormat) metódust. Ez a szövegdobozra alkalmaz 3D formázást, nem az alakzat testére.

A legfontosabb API tagok:

| API tag | Mit vezérel | Mikor kell használni |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getCamera) | Nézőpont, előre beállított kamera típus, forgatás, zoom és perspektíva. | Alakzat forgatása 3D térben vagy PowerPoint 3D forgatás előbeállításának egyezése. |
| [getLightRig](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getLightRig) | Világítási előbeállítás, irány és fényforgatás. | A kiemelések és árnyékok megjelenésének módosítása a 3D felületen. |
| [getMaterial](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getMaterial) és [setMaterial](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#setMaterial) | Felületi anyag, például sík, matt, műanyag vagy fém. | Ugyanazon geometria laposabbá, puhábbá, fényesebbé vagy fémesebbé tétele. |
| [getExtrusionHeight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getExtrusionHeight) és [setExtrusionHeight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Mennyi a forma hátra nyúló része a frontális felületétől. | Lapos alakzatot láthatóan vastag 3D objektummá alakítani. |
| [getExtrusionColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getExtrusionColor) | Az extrudált oldalak színe. | Mélység láthatóvá tétele vagy az oldal színének egyeztetése a frontális kitöltéssel. |
| [getDepth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getDepth) és [setDepth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#setDepth) | További 3D mélység, amelyet a PowerPoint 3D formázás használ. | Mélység finomhangolása alakzatok vagy szöveg esetén, különösen rézsút és anyag beállításokkal együtt. |
| [getBevelTop](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getBevelTop) és [getBevelBottom](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getBevelBottom) | Emelt vagy lekerekített élek a frontális és hátsó felületeken. | Lágy vagy öntött él hozzáadása éles, lapos felület helyett. |
| [getContourColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getContourWidth) és [setContourWidth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#setContourWidth) | Körvonal a 3D objektum körül. | Az objektum határának kiemelése a megjelenített kimenetben. |

## **3D alakzat létrehozása**

Egy alakzathoz általában négyféle beállításra van szükség, hogy meggyőzően 3D‑szerű legyen:

- Kamera beállítások, mert az alapértelmezett frontális nézet elrejtheti az extrudálást.
- Világítás beállítások, mert a fények teszik olvashatóvá a felületeket és oldalakat.
- Anyag beállítások, mert a felület befolyásolja a fény ábrázolását.
- Extrudálás vagy mélység beállítások, mert egy lapos alakzatnak vastagságra van szüksége.

Az alábbi példa egy téglalapot hoz létre, szöveget ad hozzá a frontális felülethez, alkalmaz 3D formázást, PPTX‑ként menti a prezentációt, és a diát PNG képre rendereli.

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

A renderelt dia kép a téglalapot egy vastag 3D blokként mutatja:

![Renderelt kék 3D téglalap fehér 3D szöveggel a frontális felületen](img_01_01.png)

## **Alakzat forgatása a kamerával**

PowerPoint‑ban a 3D forgatás a 3‑D Rotation panelből állítható. Az X, Y és Z forgatási értékek a kamera API‑n keresztül beállított forgatásnak felelnek meg.

![PowerPoint 3‑D Rotation panel X, Y és Z forgatási értékek kiemelve](img_02_01.png)

Az Aspose.Slides‑ben a kamera típusát és forgatását a [Shape.getThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getThreeDFormat) által visszaadott 3D formátummal állíthatod be:

```python
import jpime
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

Használd a kamerát, amikor meg akarod változtatni, hogyan látja a néző az objektumot. Ez nem változtatja meg a 2D alakzat geometriáját a dián. A PowerPoint és az Aspose.Slides által a rendereléskor használt 3D nézőpontot módosítja.

## **Extrudálás és mélység hozzáadása**

Az extrudálás egy alakzatot vastagnak mutat azzal, hogy kiterjeszti a frontális felület mögé. PowerPoint‑ban a mélység vezérlő állítja be ezt a látható vastagságot, a szín vezérlő pedig az oldalfelületek színét.

![PowerPoint mélység vezérlők leképezve az extrudálás szín és extrudálás magasság tulajdonságokra](img_02_02.png)

Állítsd be az extrudálás magasságát a vastagsághoz és az extrudálás színét az oldal színéhez:

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

Használd a mélység beállítást, amikor közvetlenül a PowerPoint mélység értékével kell dolgoznod, vagy a mélységet rézsúttal, anyaggal és szövegeffektusokkal szeretnéd kombinálni. Sok alakzat esetén az extrudálás magassága egyértelműbb beállítás, mert közvetlenül kifejezi a látható extrudálást.

## **Gradient vagy képpel kitöltés használata 3D hatásokkal**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhatsz egy szilárd színt, fokozatot, mintázatot vagy képpel kitöltést a frontális felületre, és ugyanazt a kamera, fény, anyag és extrudálás beállításokat használhatod.

Ez a példa egy fokozatú kitöltést alkalmaz az alakzatra és egy sötétebb extrudálás színt az oldalakra:

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

A renderelt kimenet megtartja a fokozatot a frontális felületen, az extrudálást pedig külön rendereli:

![Renderelt 3D téglalap kék‑narancssárga fokozatú kitöltéssel és narancssárga extrudálással](img_02_03.png)

Képpel kitöltés használatához add hozzá a képet a prezentációhoz, és rendeld hozzá az alakzat kitöltéséhez:

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

A kép a frontális felületen jelenik meg, míg az extrudálás a 3D oldal felületként jelenik meg:

![Renderelt 3D téglalap fotó kitöltéssel a frontális felületen és narancssárga extrudálással](img_02_04.png)

## **3D formázás alkalmazása szövegre**

Az alakzat 3D formázása az alakzat testére hat. A szöveg 3D formázása a szövegdobozra. Ez hasznos WordArt‑szerű hatásokhoz, ahol maguk a betűknek kell extrudálás, anyag, megvilágítás és kamera beállítások.

Az alábbi példa szöveget hoz létre mintázatú kitöltéssel, WordArt transzformációt alkalmaz, és a [TextFrameFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/) 3D beállításait konfigurálja:

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

A szöveg ívelt, extrudált 3D betűképként jelenik meg:

![Renderelt 3D szöveg ívelt WordArt transzformációval, narancssárga mintázatú kitöltéssel és sötét extrudálással](img_02_05.png)

## **Exportálás és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást, amikor PowerPoint formátumokba, például PPTX‑be menti. Amikor rögzített elrendezésű formátumokba renderelsz vagy exportálsz, a 3D jelenet raszterizálódik vagy a kimenetben 2D‑ként kerül megjelenítésre. Ez akkor érvényes, amikor diát PNG‑re renderelsz, PDF‑be exportálsz, HTML‑be exportálsz, vagy videó átalakításhoz kereteket generálsz.

Tartsd szem előtt a következőket:

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot a néző export után nem tudja elforgatni.
- A végső megjelenés a kamera, light rig, anyag, extrudálás, kitöltés és dia skálázás kombinációjától függ.
- Ha öröklött vagy téma‑alapú formázási értékeket szeretnél megtekinteni, használd a hatékony formázási API‑t.
- Egyes kimeneti formátumok nem tárolhatják a szerkeszthető PowerPoint 3D formázást. Ezekben a formátumokban a vizuális eredmény renderelődik, nem marad szerkeszthető 3D beállítás.

## **GYIK**

**Képes‑e az Aspose.Slides interaktív 3D prezentációkat létrehozni?**  
Az Aspose.Slides PowerPoint 3D hatásokat hoz létre és renderel alakzatokra és szövegre. Nem tesz interaktív 3D jeleneteket exportált képekből, PDF‑ekből vagy HTML‑oldalakból, amelyeket a néző elfordíthat. PPTX‑ben a 3D formázás szerkeszthető marad PowerPoint‑ban, ahol a formátum támogatja.

**Mi a különbség a 3D modell és a 3D effektus között?**  
A 3D modell egy különálló 3D objektum, amelyet a prezentációba szúrnak be. A 3D effektus egy szabályos PowerPoint alakzatra vagy szövegre alkalmazott formázás, például forgatás, extrudálás, rézsút, megvilágítás és anyag. Ez a cikk a 3D effektusokat tárgyalja.

**Milyen beállítások szükségesek egy látható 3D alakzathoz?**  
Legalább egy kamera forgatást és vagy extrudálást vagy mélységet kell beállítani. Gyakorlati szempontból javasolt továbbá a light rig és anyag beállítása is, hogy a renderelt felületeknek egyértelmű kiemelései és árnyékai legyenek.

**Alkalmazhatok‑e 3D effektusokat alakzatokra és szövegre egyaránt?**  
Igen. Használd a [Shape.getThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getThreeDFormat)‑t az alakzat testére és a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#getThreeDFormat)‑t a szövegre.

**Megjelennek‑e a 3D effektusok, amikor képekre, PDF‑re, HTML‑re vagy videó keretekre exportálok?**  
Igen. Az Aspose.Slides 3D effektusokat renderel a dia képek, PDF kimenet, HTML kimenet és a videó konvertáláshoz használt keretek esetén. Az exportált kimenet a renderelt megjelenést tartalmazza, nem szerkeszthető 3D objektumot.

**Kiolvasom‑e a végső 3D értékeket öröklődés és téma beállítások után?**  
Igen. Használd a [ThreeDFormat.getEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getEffective)‑t a végső kamera, light rig, rézsút és kapcsolódó 3D értékek olvasásához.