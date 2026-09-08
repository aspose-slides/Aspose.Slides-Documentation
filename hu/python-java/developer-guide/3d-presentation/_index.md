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
- 3D színátmenet
- 3D szöveg
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Alkalmazzon és rendereljen 3D effektusokat PowerPoint alakzatokra és szövegre Pythonon keresztül Java-val az Aspose.Slides segítségével. Állítsa be a kamerát, megvilágítást, anyagot, extrudálást, kitöltéseket és a 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for Python via Java képes létrehozni, szerkeszteni, megőrizni és renderelni a PowerPoint‑stílusú 3D formázást alakzatokra és szövegre. Ez a cikk a 3D hatásokat tárgyalja, mint például a forgatás, extrudálás, csiszolás, megvilágítás, anyag, színátmenetes vagy képkitöltés, valamint a 3D szöveg.

{{% alert color="info" title="Megjegyzés" %}}
Ez a cikk a PowerPoint alakzatok és szöveg 3D formázási hatásairól szól. Nem az önálló 3D modell fájlok beszúrásáról vagy szerkesztéséről. Ha egy diát képre, PDF‑re vagy HTML‑re exportál, az Aspose.Slides a 3D hatásokat a exportált 2D kimenetbe rendereli.
{{% /alert %}}

Telepítse a csomagot a [Installation](/slides/hu/python-java/installation/) szakaszban leírt módon. Minden példa importálja a `asposeslides`‑t, szükség esetén elindítja a JVM‑et, majd importálja az API‑t. A képkitöltéses példához egy `image.jpg` fájlra van szükség a munkakönyvtárban.

## **3D Formázási Fogalmak**

Használja a [Shape.getThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getThreeDFormat) metódust a 3D formázás alkalmazásához egy alakzatra. A visszaadott formátumobjektum szabályozza a 3D jelenetet az adott alakzathoz.

Szöveghez használja a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#getThreeDFormat) metódust. Ez a szövegkeretre alkalmaz 3D formázást, nem pedig az alakzattörzsre.

A legfontosabb API tagok a következők:

| API tag | Mit vezérel | Mikor használjuk |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getCamera) | Nézetpont, előre beállított kamera típus, forgatás, zoom és perspektíva. | Forgassa el az objektumot 3D térben, vagy illessze a PowerPoint 3D forgatás előbeállításához. |
| [getLightRig](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getLightRig) | Fény előbeállítás, irány és fényforgatás. | Módosítja, hogyan jelennek meg a kiemelések és árnyékok a 3D felületen. |
| [getMaterial](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getMaterial) és [setMaterial](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#setMaterial) | Felületi anyag, például sík, matt, műanyag vagy fém. | Azonos geometria laposabbá, lágyabbá, fényesebbé vagy fémesebbé tétele. |
| [getExtrusionHeight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getExtrusionHeight) és [setExtrusionHeight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Milyen távolságra nyúlik ki az alakzat a frontális felület mögött. | Átalakítja a sík alakzatot láthatóan vastag 3D objektummá. |
| [getExtrusionColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getExtrusionColor) | Az extrudált oldalak színe. | Láthatóvá teszi a mélységet, vagy összehangolja az oldalszínt az elülső kitöltéssel. |
| [getDepth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getDepth) és [setDepth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#setDepth) | További 3D mélység, amelyet a PowerPoint 3D formázás használ. | Finomhangolja a mélységet alakzatok vagy szöveg esetén, különösen a csiszolás és anyag beállításokkal együtt. |
| [getBevelTop](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getBevelTop) és [getBevelBottom](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getBevelBottom) | Emelkedett vagy lekerekített élek az elülső és hátsó felületeken. | Puhább vagy formázott él hozzáadása ahelyett, hogy éles sík felület lenne. |
| [getContourColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getContourWidth), és [setContourWidth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#setContourWidth) | Kontúr a 3D objektum körül. | Kiemeli az objektum határait a renderelt kimenetben. |

## **3D Alakzat Létrehozása**

Az alakzat általában négyféle beállítást igényel, mielőtt meggyőzően 3D‑snek tűnik:

- Kamera beállítások, mert az alapértelmezett elülső nézet elrejtheti az extrudálást.
- Fény beállítások, mert a megvilágítás olvashatóvá teszi a felületeket és oldalakat.
- Anyag beállítások, mert a felület befolyásolja a fény renderelését.
- Extrudálás vagy mélység beállítások, mert a sík alakzatnak vastagságra van szüksége.

A következő példa egy téglalapot hoz létre, szöveget ad hozzá az elülső felülethez, alkalmaz 3D formázást, PPTX formátumban menti a prezentációt, és a diát PNG képpé rendereli.

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

A renderelt diakép a téglalapot vastag 3D blokként mutatja:

![Renderelt kék 3D téglalap fehér 3D szöveggel az elülső felületen](img_01_01.png)

## **Alakzat Forgatása a Kamerával**

PowerPointban a 3‑D Rotation panelből állítható be a 3D forgatás. Az X, Y és Z forgatási értékek megfelelnek a kamera API‑n keresztül beállított forgatásnak.

![PowerPoint 3‑D Rotation panel X, Y és Z forgatási értékek kiemelésével](img_02_01.png)

Az Aspose.Slides‑ben a kamera típusát és forgatását a [Shape.getThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getThreeDFormat) által visszaadott 3D formátumon keresztül állíthatja be:

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

A kamerát akkor használja, ha meg szeretné változtatni, ahogyan a néző látja az objektumot. Nem módosítja a 2D alakzatgeometriát a dián. A PowerPoint és az Aspose.Slides által a renderelés során használt 3D nézőpontot módosítja.

## **Extrudálás és Mélység Hozzáadása**

Az extrudálás egy alakzatot vastagnak mutat azáltal, hogy kiterjeszti a frontális felület mögött. PowerPointban a mélység szabályozó beállítja ezt a látható vastagságot, a szín szabályozó pedig az oldalfelületek színét.

![PowerPoint mélység szabályozók leképezve az extrudálás szín és magasság tulajdonságaira](img_02_02.png)

Állítsa be az extrudálás magasságát a vastagsághoz, és az extrudálás színét az oldal színéhez:

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

A mélység beállítást akkor használja, ha közvetlenül a PowerPoint mélység értékével kell dolgozni, vagy a mélységet kombinálni akarja a csiszolással, anyaggal és szöveghatásokkal. Sok alakzatszituációban az extrudálás magassága egyértelműbb beállítás, mivel közvetlenül kifejezi a látható extrudálást.

## **Színátmenetes vagy Képkitöltés 3D Hatásokkal**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhat egyszínű, színátmenetes, mintás vagy képkitöltést az elülső felületre, miközben ugyanazt a kamera, fény, anyag és extrudálás beállítást használja.

Ez a példa színátmenetes kitöltést alkalmaz az alakzatra, és sötétebb extrudálás színt az oldalakra:

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

![Renderelt 3D téglalap kék‑narancs színátmenetes kitöltéssel és narancssárga extrudálással](img_02_03.png)

A képkitöltés használatához adja hozzá a képet a prezentációhoz, és rendelje hozzá az alakzat kitöltéséhez:

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

![Renderelt 3D téglalap fotó kitöltéssel az elülső felületen és narancssárga extrudálással](img_02_04.png)

## **3D Formázás Alkalmazása Szövegre**

Az alakzat 3D formázása az alakzat testére hat. A szöveg 3D formázása a szövegkeretre. Ez hasznos WordArt‑szerű hatásokhoz, ahol a betűknek maguknak kell extrudálás, anyag, megvilágítás és kamera beállítások.

A következő példa minta kitöltéssel hoz létre szöveget, WordArt transzformációt alkalmaz, és 3D beállításokat konfigurál a [TextFrameFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/) számára:

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

![Renderelt 3D szöveg ívelt WordArt transzformációval, narancssárga minta kitöltéssel és sötét extrudálással](img_02_05.png)

## **Exportálási és Renderelési Viselkedés**

Az Aspose.Slides megőrzi a 3D formázást PowerPoint formátumokba, például PPTX‑be mentéskor. Renderelés vagy export rögzített elrendezésű formátumokba esetén a 3D jelenet raszterizálódik vagy a kimenetbe 2D eredményként kerül. Ez akkor is érvényes, amikor a diákat PNG‑re rendereli, PDF‑re, HTML‑re exportál vagy videókonverzióhoz kereteket generál.

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot a néző export után nem tudja elforgatni.
- A végső megjelenés a kamera, fényrig, anyag, extrudálás, kitöltés és dia méretezés kombinációjától függ.
- Ha örökölt vagy témán alapuló formázási értékeket szeretne megvizsgálni, használja a hatékony formázási API‑t.
- Néhány kimeneti formátum nem képes szerkeszthető PowerPoint 3D formázást tárolni. Ezekben a formátumokban a vizuális eredmény renderelve van, nem szerkeszthető 3D beállításként.

## **GYIK**

**Készíthet az Aspose.Slides interaktív 3D prezentációkat?**

Az Aspose.Slides létrehozza és rendereli a PowerPoint 3D effektusokat alakzatokra és szövegre. Nem teszi interaktívvá a exportált képeket, PDF‑eket vagy HTML‑oldalakat, amelyek forgatható 3D jelenetet biztosítanának. PPTX‑ben a 3D formázás szerkeszthető marad a PowerPointban, ahol a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D effektus között?**

Egy 3D modell egy különálló 3D objektum, amelyet a prezentációba szúrnak be. Egy 3D effektus egy szabványos PowerPoint alakzatra vagy szövegre alkalmazott formázás, mint például forgatás, extrudálás, csiszolás, megvilágítás és anyag. Ez a cikk a 3D effektusokat tárgyalja.

**Milyen beállítások szükségesek egy látható 3D alakzathoz?**

Legalább egy kamera forgatást és vagy extrudálást vagy mélységet kell beállítani. Gyakorlati kontextusban érdemes egy fény riget és anyagot is beállítani, hogy a renderelt felületeknek tiszta kiemelései és árnyékai legyenek.

**Alkalmazhatok 3D effektusokat mind alakzatokra, mind szövegre?**

Igen. Használja a [Shape.getThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getThreeDFormat)‑t az alakzat testére, és a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#getThreeDFormat)‑t a szövegre.

**Megjelennek a 3D effektusok, ha képekre, PDF‑re, HTML‑re vagy videó keretekre exportálok?**

Igen. Az Aspose.Slides rendereli a 3D effektusokat a dia képek, PDF, HTML kimenetek és a videó konverzióhoz használt keretek létrehozásakor. Az exportált kimenet a renderelt megjelenést tartalmazza, nem szerkeszthető 3D objektumot.

**Kiolvasom a végső 3D értékeket az öröklés és a téma beállítások alkalmazása után?**

Igen. Használja a [ThreeDFormat.getEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getEffective) metódust a végső kamera, fény rig, csiszolás és kapcsolódó 3D értékek lekéréséhez.