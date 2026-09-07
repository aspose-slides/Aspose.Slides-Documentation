---
title: 3D hatások létrehozása prezentációkban Python segítségével
linktitle: 3D Prezentáció
type: docs
weight: 232
url: /hu/python-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D prezentáció
- 3D forgatás
- 3D mélység
- 3D extrúzió
- 3D színátmenet
- 3D szöveg
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Alkalmazzon és rendereljen 3D effektusokat PowerPoint alakzatokhoz és szöveghez Pythonon keresztül Java-val az Aspose.Slides segítségével. Konfigurálja a kamerát, megvilágítást, anyagot, extrúziót, kitöltéseket és 3D szöveget."
---
## **Áttekintés**

Az Aspose.Slides for Python via Java képes létrehozni, szerkeszteni, megőrizni és megjeleníteni a PowerPoint-szerű 3D formázást alakzatok és szövegek számára. Ez a cikk olyan 3D effektusokat fed le, mint a forgatás, extrúzió, körülívek, megvilágítás, anyag, színátmenetes vagy képes kitöltés, valamint a 3D szöveg.

{{% alert color="info" title="Megjegyzés" %}}

Ez a cikk a PowerPoint‑alkalmazások és szövegek 3D formázási effektusairól szól. Nem a különálló 3D modellfájlok beszúrásáról vagy szerkesztéséről. Amikor egy diát képre, PDF‑re vagy HTML‑re exportál, az Aspose.Slides a 3D effektusokat a exportált 2D kimenetbe rendereli.

{{% /alert %}}

Telepítse a csomagot a [Telepítés](/slides/hu/python-java/installation/) leírása szerint. Minden példa importálja a `asposeslides`‑t, szükség esetén elindítja a JVM‑et, majd importálja az API‑t. A kép‑kitöltéses példa egy `image.jpg` fájlt igényel a munkakönyvtárban.

## **3D formázási koncepciók**

Használja a [Shape.getThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getThreeDFormat) metódust a 3D formázás alkalmazásához egy alakzatra. A visszakapott formátumobjektum szabályozza az adott alakzat 3D jelenetét.

Szövegnél a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#getThreeDFormat) használható. Ez a szövegkeretre alkalmazza a 3D formázást, nem pedig az alakzat testére.

A legfontosabb API‑tagok:

| API tag | Mit szabályoz | Mikor használjuk |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getCamera) | Nézőpont, előre beállított kamera típus, forgatás, zoom és perspektíva. | Az objektum 3D térbeli forgatásához vagy PowerPoint 3D forgatási előbeállításának megfeleléséhez. |
| [getLightRig](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getLightRig) | Világítás előbeállítása, iránya és a fény forgatása. | A fény- és árnyékhatások megváltoztatásához a 3D felületen. |
| [getMaterial](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getMaterial) és [setMaterial](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#setMaterial) | Felület anyaga, például lapos, matt, műanyag vagy fém. | Ugyanazon geometria laposabbá, puhábbá, fényesebbé vagy fémesebbé tételéhez. |
| [getExtrusionHeight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getExtrusionHeight) és [setExtrusionHeight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Hány milliméterrel nyúlik ki az alakzat a frontális felület mögül. | Lapos alakzatot láthatóan vastag 3D objektummá alakít. |
| [getExtrusionColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getExtrusionColor) | Az extrudált oldalak színe. | Mélység megjelenítéséhez vagy az oldal színének a frontális kitöltéssel való összehangolásához. |
| [getDepth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getDepth) és [setDepth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#setDepth) | További 3D mélység, amelyet a PowerPoint 3D formázás használ. | A mélység finomhangolásához alakzatok vagy szöveg esetén, különösen a körülívek és anyagbeállításokkal együtt. |
| [getBevelTop](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getBevelTop) és [getBevelBottom](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getBevelBottom) | Emelt vagy lekerekített élek az elülső és hátsó felületeken. | Lágy, vagy formázott él hozzáadása ahelyett, hogy egy éles, lapos felület lenne. |
| [getContourColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getContourWidth) és [setContourWidth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#setContourWidth) | Kontúr a 3D objektum körül. | Az objektum határának kiemelése a renderelt kimenetben. |

## **3D alak létrehozása**

Egy alakzathoz általában négyféle beállítás szükséges, hogy meggyőzően 3D‑nak tűnjön:

- Kamera beállítások, mert az alapértelmezett frontális nézet elrejtheti az extrúziót.
- Világítási beállítások, mert a megvilágítás teszi olvashatóvá az oldalakat és felületeket.
- Anyag beállítások, mert a felület befolyásolja, hogyan jelenik meg a fény.
- Extrúzió vagy mélység beállítások, mert egy lapos alakzatnak vastagságra van szüksége.

Az alábbi példa egy téglalapot hoz létre, szöveget ad az elülső felületéhez, 3D formázást alkalmaz, PPTX‑ként menti a prezentációt, majd a diát PNG képre rendereli.

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

## **Alakzat forgatása kamerával**

PowerPointban a 3D forgatást a **3‑D Rotation** panelről konfigurálják. Az X, Y és Z forgatási értékek megfelelnek a kamera API‑n keresztül beállított forgatásnak.

![PowerPoint 3‑D Rotation panel X, Y és Z forgatási értékek kiemelve](img_02_01.png)

Aspose.Slides‑ben a kamera típusát és forgatását a [Shape.getThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getThreeDFormat) által visszaadott 3D formátummal állíthatja be:

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

Használja a kamerát, ha meg akarja változtatni, hogyan látja a néző az objektumot. Nem módosítja a 2D alakz geometriai adatait a dián, csak a PowerPoint és az Aspose.Slides által a renderelés során használt 3D nézőpontot.

## **Extrúzió és mélység hozzáadása**

Az extrúzió egy alakzatot vastagabbá tesz, a frontális felület mögé nyújtva. PowerPointban a mélység‑szabályozó állítja be ezt a látható vastagságot, a szín‑szabályozó pedig az oldalak színét.

![PowerPoint mélység‑szabályozók leképezve az extrúzió színre és magasságra vonatkozó tulajdonságokra](img_02_02.png)

Állítsa be az extrúzió magasságát a vastagság, és az extrúzió színét az oldal színe számára:

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

Használja a mélység beállítást, ha közvetlenül a PowerPoint mélységértékével kell dolgoznia, vagy a mélységet körülívekkel, anyaggal és szövegeffektusokkal kívánja kombinálni. Sok alakzati esetben az extrúzió magassága egyértelműbb beállítás, mert közvetlenül fejezi ki a látható extrúziót.

## **Gradiens vagy képkitöltés használata 3D hatásokkal**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhat egyszínű, gradiens, minta vagy kép kitöltést a frontális felületre, miközben ugyanazokat a kamera, fény, anyag és extrúzió beállításokat használja.

Ez a példa gradiens kitöltést alkalmaz az alakzaton, és sötétebb extrúzió színt az oldalakhoz:

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

A renderelt kimenet megtartja a gradienset a frontális felületen, és külön rendereli az extrúziót:

![Renderelt 3D téglalap kék‑narancssárga gradiens kitöltéssel és narancssárga extrúzióval](img_02_03.png)

Ha helyette képkitöltést szeretne használni, adja hozzá a képet a prezentációhoz, és rendelje az alakzat kitöltéséhez:

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

A kép a frontális felületen jelenik meg, míg az extrúzió a 3D oldalfelületként renderelődik:

![Renderelt 3D téglalap fotó kitöltéssel az elülső felületen és narancssárga extrúzióval](img_02_04.png)

## **3D formázás alkalmazása szövegre**

Az alakzat 3D formázása az alakzat testét érinti. A szöveg 3D formázása a szövegkeretre hat. Ez a WordArt‑szerű hatásoknál hasznos, ahol maguk a betűk is extrúzióra, anyagra, megvilágításra és kamera‑beállításokra szorulnak.

Az alábbi példa mintakitettséget alkalmaz a szövegre, WordArt transzformációt hajt végre, és 3D beállításokat konfigurál a [TextFrameFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/)‑on:

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

A szöveg görbült, extrudált 3D betűkként jelenik meg:

![Renderelt 3D szöveg ívelt WordArt transzformációval, narancssárga mintakitettséggel és sötét extrúzióval](img_02_05.png)

## **Exportálási és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást, amikor PowerPoint formátumokba, például PPTX‑be ment. Renderelés vagy exportálás esetén rögzített elrendezésű formátumokba a 3D jelenet raszterizálódik vagy be van rajzolva a kimenetbe 2D eredményként. Ez akkor is érvényes, amikor diákat PNG‑re renderel, PDF‑re, HTML‑re exportál, vagy videókonvertáláshoz kereteket generál.

Vegye figyelembe a következő pontokat:

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot az export után a néző nem tudja forgatni.
- A végső megjelenés a kamera, a fényrig, az anyag, az extrúzió, a kitöltés és a dia méretezésének kombinációjától függ.
- Ha örökölt vagy sablon‑alapú formázási értékeket kell megvizsgálnia, használja a hatékony formázás API‑t.
- Egyes kimeneti formátumok nem tudják tárolni a szerkeszthető PowerPoint 3D formázást. Ezekben a formátumokban a vizuális eredményt renderelik, nem pedig szerkeszthető 3D beállításként.

## **FAQ**

**Képes-e az Aspose.Slides interaktív 3D prezentációkat létrehozni?**

Az Aspose.Slides PowerPoint 3D effektusokat hoz létre és renderel alakzatokhoz és szöveghez. Nem tesz exportált képeket, PDF‑eket vagy HTML‑oldalakat interaktív 3D jelenetté, amelyet a néző forgathat. PPTX‑ben a 3D formázás szerkeszthető marad a PowerPointben, ahol a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D effektus között?**

A 3D modell egy különálló 3D objektum, amelyet a prezentációba szúrnak be. A 3D effektus egy szabványos PowerPoint alakzatra vagy szövegre alkalmazott formázás, például forgatás, extrúzió, körülív, megvilágítás és anyag. Ez a cikk a 3D effektusokkal foglalkozik.

**Milyen beállítások szükségesek egy látható 3D alakzathoz?**

Legalább egy kamera forgatást és extrúziót vagy mélységet kell beállítani. Gyakorlati szempontból érdemes még egy fényriget és anyagot is megadni, hogy a renderelt felületeknek legyenek világos kiemelései és árnyékai.

**Alkalmazhatok‑e 3D effektusokat akár alakzatokra, akár szövegre?**

Igen. Használja a [Shape.getThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getThreeDFormat) metódust az alakzat testére, és a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#getThreeDFormat) metódust a szövegre.

**Megjelennek‑e a 3D effektusok képekre, PDF‑re, HTML‑re vagy videókeretekre exportálva?**

Igen. Az Aspose.Slides a 3D effektusokat rendereli, amikor diaképeket, PDF‑kimenetet, HTML‑kimenetet vagy videókonvertáláshoz kereteket hoz létre. Az exportált fájl a renderelt megjelenést tartalmazza, nem szerkeszthető 3D objektumot.

**Ki tudom‑e olvasni a végső 3D értékeket az öröklődés és a sablon beállítások után?**

Igen. Használja a [ThreeDFormat.getEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getEffective) metódust a végső kamera, fényrig, körülív és a kapcsolódó 3D értékek olvasásához.