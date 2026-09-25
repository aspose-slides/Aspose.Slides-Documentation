---
title: "3D effektusok létrehozása prezentációkban Python használatával"
linktitle: "3D prezentáció"
type: docs
weight: 232
url: /hu/python-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentáció
- 3D forgatás
- 3D mélység
- 3D extrudálás
- 3D színátmenet
- 3D szöveg
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Alkalmazza és renderelje a 3D effektusokat PowerPoint alakzatokra és szövegre Pythonon keresztül Java-val az Aspose.Slides használatával. Állítsa be a kamerát, a világítást, az anyagot, az extrudálást, a kitöltéseket és a 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for Python via Java képes létrehozni, szerkeszteni, megőrizni és megjeleníteni a PowerPoint-szerű 3D formázást alakzatok és szöveg esetén. Ez a cikk olyan 3D effektusokat fed le, mint a forgatás, extrudálás, peremek, világítás, anyag, színátmenetes vagy képi kitöltések, valamint a 3D szöveg.

{{% alert color="info" title="Megjegyzés" %}}
Ez a cikk a PowerPoint alakzatok és szöveg 3D formázási effektusairól szól. Nem a önálló 3D modellfájlok beszúrásáról vagy szerkesztéséről szól. Amikor egy diát képre, PDF‑re vagy HTML‑re exportál, az Aspose.Slides a 3D effektusokat a exportált 2D kimenetbe rendereli.
{{% /alert %}}

## **3D formázási koncepciók**

Használja a [Shape.getThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getThreeDFormat) metódust 3D formázás alkalmazásához egy alakzatra. A metódus egy [ThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/) objektumot ad vissza, amely az adott alakzat 3D jelenetét vezérli.

Szöveg esetén használja a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#getThreeDFormat) metódust. Ez a szövegkeretre alkalmaz 3D formázást a forma test helyett.

A legfontosabb API tagok:

| API tag | Mit vezérel | Mikor kell használni |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getCamera) | Nézőpont, előre beállított kamera típusa, forgatás, zoom és perspektíva. | Forgassa el a tárgyat 3D térben, vagy egyeztesse a PowerPoint 3D forgatási előbeállítással. |
| [getLightRig](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getLightRig) | Fény előbeállítás, irány és fény forgatás. | Megváltoztatja, hogyan jelennek meg a fényes kiemelések és árnyékok a 3D felületen. |
| [getMaterial](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getMaterial) és [setMaterial](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#setMaterial) | Felület anyaga, például lapos, matt, műanyag vagy fém. | Azt a geometriai formát laposabbá, puhábbá, fényesebbé vagy fémesebbé teszi. |
| [getExtrusionHeight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getExtrusionHeight) és [setExtrusionHeight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Mennyire nyúlik a forma hátra a frontál felületétől. | Lapos formát láthatóan vastag 3D objektummá alakít. |
| [getExtrusionColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getExtrusionColor) | Az extrudált oldalak színe. | A mélységet láthatóvá teszi, vagy összehangolja az oldal színét a frontális kitöltéssel. |
| [getDepth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getDepth) és [setDepth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#setDepth) | A PowerPoint 3D formázás által használt további 3D mélység. | Finomhangolja a mélységet alakzatok vagy szöveg esetén, különösen a bevel és anyag beállításokkal együtt. |
| [getBevelTop](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getBevelTop) és [getBevelBottom](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getBevelBottom) | Emelt vagy lekerekített szélek a frontális és hátsó felületeken. | Puhább vagy formázott él hozzáadása egy éles, lapos felület helyett. |
| [getContourColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getContourColor) és [getContourWidth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getContourWidth) és [setContourWidth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#setContourWidth) | Körvonal a 3D objektum körül. | Kiemeli az objektum határvonalát a renderelt kimenetben. |

## **3D alakzat létrehozása**

- Kamera beállítások, mivel az alapértelmezett frontális nézet elrejtheti az extrudálást.
- Világítási beállítások, mivel a fények teszik olvashatóvá a felületeket és az oldalakat.
- Anyag beállítások, mivel a felület befolyásolja, hogyan jelenik meg a fény.
- Extrudálás vagy mélység beállítások, mivel egy lapos forma vastagságra van szüksége.

A következő példa egy téglalapot hoz létre, szöveget ad a frontális felülethez, és alkalmaz 3D formázást. A kamera forgatási értékek fokban vannak megadva, az extrudálás magassága 100 pont. A példa a diát PNG képre rendereli a kétszeres alapméretben, és PPTX‑ként menti a prezentációt.

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

![Megjelenített kék 3D téglalap fehér 3D szöveggel a frontális felületen](img_01_01.png)

## **Alakzat forgatása a kamerával**

A PowerPointban a 3D forgatás a 3‑D Rotation ablaktábláról állítható be. Az X, Y és Z forgatási értékek megfelelnek a kamera API‑n keresztül beállított forgatásnak.

![PowerPoint 3D forgatás panel X, Y és Z forgatás értékek kiemelve](img_02_01.png)

Az Aspose.Slides‑ben a kamerához a [ThreeDFormat.getCamera](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getCamera) segítségével férhet hozzá. Ez a példa egy téglalapot hoz létre, ortográfiai frontális nézetet választ, és X, Y, Z forgatásait 20, 30, 40 fokra állítja. A forma memóriában van konfigurálva fájl mentése nélkül:

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

Használja a kamerát, ha meg akarja változtatni, hogyan látja a néző az objektumot. Ez nem változtatja meg a 2D forma geometriáját a dián. A PowerPoint és az Aspose.Slides által a rendereléskor használt 3D nézőpontot módosítja.

## **Extrudálás és mélység hozzáadása**

Az extrudálás egy alakzatot vastagnak mutat azzal, hogy a frontális felület mögé nyúlik. PowerPointban a mélység szabályozó a látható vastagságot állítja be, a szín szabályozó pedig az oldal felületek színét.

![PowerPoint mélység vezérlők hozzárendelve az extrudálás színhez és magasság tulajdonságokhoz](img_02_02.png)

Használja a [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#setExtrusionHeight) metódust a vastagság beállításához, és a [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getExtrusionColor) metódust az oldal színének lekéréséhez. Ez a példa egy 100‑pont extrudálást ad a téglalaphoz lila oldalakkal, és a kamerát elforgatja, hogy látható legyen a vastagság. A forma memóriában van konfigurálva fájl mentése nélkül:

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

A [ThreeDFormat.setDepth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#setDepth) metódus egy 3D alakzat mélységét állítja be. A [setExtrusionHeight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#setExtrusionHeight) metódus az extrudálási hatás magasságát szabályozza, ahogy a példában látható.

## **Színátmenetes vagy képes kitöltések használata 3D effektekkel**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhat egyszínű, színátmenetes, mintás vagy képes kitöltést a frontális felületre, és ugyanazokat a kamera-, fény-, anyag- és extrudálási beállításokat használhatja.

Ez a példa kék‑narancssárga színátmenetet alkalmaz a frontális felületre, és sötét narancssárga színt a 150‑pont extrudálásra. A színátmenet állomásai 0‑nál és 100‑nál jelölik a kezdetet és a végét. A kamera forgatási értékek fokban vannak megadva. A dia PNG képre renderelődik a kétszeres alapméretben:

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

![Megjelenített 3D téglalap kék‑narancssárga színátmenetes kitöltéssel és narancssárga extrudálással](img_02_03.png)

Képes kitöltés használatához adja a képet a prezentációhoz, és rendelje az alakzat kitöltéséhez. Ez a példa egy „image.jpg” nevű létező fájlt igényel a munkakönyvtárban. A kép a téglalap kitöltésére nyúlik, 150‑pont extrudálást alkalmaz, és fokban állítja be a kamera forgatását. A forma memóriában van konfigurálva fájl mentése vagy renderelése nélkül:

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

![Megjelenített 3D téglalap fotó kitöltéssel a frontális felületen és narancssárga extrudálással](img_02_04.png)

## **3D formázás alkalmazása szövegre**

A forma 3D formázása a forma testét érinti. A szöveg 3D formázása a szövegkeretet. Ez hasznos WordArt‑szerű effektusokhoz, ahol a betűknek maguknak is szükségük van extrudálásra, anyagra, világításra és kamera beállításokra.

Ez a példa narancssárga‑fehér rácsmintát használó szöveget hoz létre, felfelé ívelt ívet ad hozzá, és a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#getThreeDFormat) segítségével konfigurálja a 3D beállításokat. Az extrudálás magassága és a mélység pontban van megadva, a fény forgatása fokban. A forma kitöltése és körvonala rejtve van, hogy csak a szöveg legyen látható. A példa PNG képet renderel a diák kétszeres alapméretében, és PPTX‑ként menti a prezentációt:

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

![Megjelenített 3D szöveg ívelt WordArt átalakítással, narancssárga mintás kitöltéssel és sötét extrudálással](img_02_05.png)

## **Szöveg lapos tartása 3D alakzaton**

A szöveg olvashatóságának megőrzéséhez egy 3D alakzat megjelenése mellett hívja meg a [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setKeepTextFlat) metódust a [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/#getTextFrameFormat) útján. Ha az érték `True`, a szöveg kívül marad a 3D színen. Ha `False`, a szöveg részt vesz a színen és követi annak 3D orientációját.

Ez a beállítás nem távolítja el az alakzat 3D formázását: a kamera, a világítás, az anyag és az extrudálás továbbra is a [Shape.getThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getThreeDFormat) által van konfigurálva. Emellett eltér a szokásos forgatástól. A [Shape.setRotation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#setRotation) a formát a dia síkjában forgatja, míg a [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setRotationAngle) a szöveg egyéni forgatását szabályozza a keretén belül. A szöveg 3D színen kívül tartása nem állítja vissza ezeket a szögeket sem.

Ez a komplett példa egy kék téglalapot hoz létre szöveggel, majd egy példányt készít mellette. Mindkét alakzat ugyanazzal a 3D formázással rendelkezik; csak a szöveg beállítása különbözik: bal oldalon `False`, jobb oldalon `True`. A kamera szögek fokban vannak megadva, az extrudálás magassága 40 pont. A példa PPTX‑ként menti a prezentációt, és a összehasonlító diát PNG‑re rendereli a kétszeres alapméretben.

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

![Egymás mellé helyezett 3D téglalapok: a szöveg követi a 3D orientációt a bal oldalon és lapos marad a jobb oldalon](keep_text_flat.png)

## **Exportálási és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást, amikor PowerPoint formátumokba, például PPTX‑be ment. Renderelés vagy exportálás során rögzített elrendezésű formátumokba a 3D színt raszterizálja vagy 2D eredményként rajzolja a kimenetbe. Ez akkor is érvényes, amikor a diákat [PNG](/slides/hu/python-java/convert-powerpoint-to-png/)-re rendereli, [PDF](/slides/hu/python-java/convert-powerpoint-to-pdf/)-re exportál, [HTML](/slides/hu/python-java/convert-powerpoint-to-html/)-re exportál, vagy [videókonverzió](/slides/hu/python-java/convert-powerpoint-to-video/) kereteket generál.

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot a néző az exportálás után nem tudja elforgatni.
- A végső megjelenés a kamera, világítás, anyag, extrudálás, kitöltés és diák nagyításának kombinációjától függ.
- Ha meg kell vizsgálnia az örökölt vagy téma‑alapú formázási értékeket, olvassa el a [effective shape properties](/slides/hu/python-java/shape-effective-properties/) szakaszt.
- Néhány kimeneti formátum nem tárolhat szerkeszthető PowerPoint 3D formázást. Az ilyen formátumokban a vizuális eredmény renderelve van, nem pedig szerkeszthető 3D beállításként tárolva.

## **GYIK**

**Készíthet‑e az Aspose.Slides interaktív 3D bemutatókat?**

Az Aspose.Slides PowerPoint 3D effektusokat hoz létre és renderel alakzatokra és szövegre. Nem tesz exportált képeket, PDF‑ket vagy HTML‑oldalakat interaktív 3D színné, amelyet a néző elforgathat. PPTX‑ben a 3D formázás szerkeszthető marad a PowerPointben, ahol a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D effektus között?**

A 3D modell egy külön 3D objektum, amely a prezentációba van beszúrva. A 3D effektus egy szabványos PowerPoint alakzatra vagy szövegre alkalmazott formázás, mint a forgatás, extrudálás, bevel, világítás és anyag. Ez a cikk a 3D effektusokat tárgyalja.

**Milyen beállítások szükségesek egy látható 3D alakzathoz?**

Legalább egy kamera forgatás és vagy extrudálás vagy mélység szükséges. Gyakran a fény riget és anyagot is beállítják, hogy a renderelt felületeknek legyenek egyértelmű kiemelései és árnyékai.

**Alkalmazhat‑ok‑e 3D effektusokat alakzatokra és szövegre egyaránt?**

Igen. Használja a [Shape.getThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getThreeDFormat) metódust a forma testhez és a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#getThreeDFormat) metódust a szöveghez.

**Megjelennek‑e a 3D effektusok, amikor képekre, PDF‑re, HTML‑re vagy videókeretekre exportálok?**

Igen. Az Aspose.Slides a 3D effektusokat rendereli diaképek, PDF‑kimenet, HTML‑kimenet és videókonverzióhoz használt keretek előállításakor. Az exportált kimenet a renderelt megjelenést tartalmazza, nem szerkeszthető 3D objektumot.  

**Ki tudom‑e olvasni a végső 3D értékeket az öröklődés és a téma beállításai után?**

Igen. Használja a [Shape Effective Properties](/slides/hu/python-java/shape-effective-properties/) leírt hatékony formázási API‑kat a végső kamera, fény rig, bevel és kapcsolódó 3D értékek lekéréséhez.