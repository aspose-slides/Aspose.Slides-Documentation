---
title: 3D effektek létrehozása prezentációkban Python használatával
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
description: Alkalmazza és renderelje a 3D effektusokat PowerPoint alakzatokra és szövegre Pythonon keresztül Java-val az Aspose.Slides segítségével. Állítsa be a kamerát, a megvilágítást, az anyagot, az extrudálást, a kitöltéseket és a 3D szöveget.
---
## **Áttekintés**

Az Aspose.Slides for Python via Java képes létrehozni, szerkeszteni, megőrizni és renderelni a PowerPoint‑stílusú 3D formázást alakzatokhoz és szöveghez. Ez a cikk a 3D effektusokat tárgyalja, például forgatást, extrudálást, lekerekítéseket, megvilágítást, anyagot, színátmenetes vagy képes kitöltéseket, és a 3D szöveget.

{{% alert color="info" title="Note" %}}
Ez a cikk a PowerPoint alakzatokra és szövegre vonatkozó 3D formázási effektusokról szól. Nem a különálló 3D modellfájlok beszúrásáról vagy szerkesztéséről szól. Amikor egy diát képre, PDF‑re vagy HTML‑re exportálsz, az Aspose.Slides ezeket a 3D effektusokat a kiexportált 2D kimenetbe rendereli.
{{% /alert %}}

## **3D formázási koncepciók**

Használd a [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) metódust a 3D formázás alkalmazásához egy alakzatra. A metódus egy [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) objektumot ad vissza, amely az adott alakzat 3D jelenetét irányítja.

Szöveg esetén használd a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) metódust. Ez a 3D formázást a szövegdobozra alkalmazza az alakzat teste helyett.

A legfontosabb API tagok a következők:

| API tag | Mit szabályoz | Mikor használjuk |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) | Nézőpont, előre beállított kamera típus, forgatás, nagyítás és perspektíva. | Forgasd el az objektumot 3D térben, vagy illeszd egy PowerPoint 3D forgatási előre beállításhoz. |
| [getLightRig](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getLightRig) | Fény előbeállítás, irány, és fény forgatás. | Módosítsa, hogyan jelennek meg a fények és árnyékok a 3D felületen. |
| [getMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setMaterial) | Felület anyaga, például sík, matt, műanyag vagy fém. | Tedd a geometriai formát síkabbá, puhábbá, fényesebbé vagy fémesebbé. |
| [getExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Milyen messze nyúlik vissza az alakzat a frontális felületétől. | Alakíts egy sík alakzatot láthatóan vastag 3D objektummá. |
| [getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) | Az extrudált oldalak színe. | Tedd a mélységet láthatóvá, vagy egyeztesd az oldalsó színt az elülső kitöltéssel. |
| [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) | További 3D mélység, amelyet a PowerPoint 3D formázás használ. | Finomhangolda a mélységet alakzatok vagy szöveg esetén, különösen a lekerekítés és anyag beállításokkal együtt. |
| [getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelBottom) | Emelt vagy lekerekített élek az elülső és hátoldali felületeken. | Adj hozzá egy lágyabb vagy formázott élt ahelyett, hogy éles sík felület lenne. |
| [getContourColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourColor) and [getContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourWidth) and [setContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setContourWidth) | Körvonal a 3D objektum körül. | Emeld ki az objektum határát a renderelt kimenetben. |

## **3D alakzat létrehozása**

- Kamera beállítások, mert az alapértelmezett frontális nézet elrejtheti az extrudálást.
- Fény beállítások, mert a megvilágítás teszi olvashatóvá az arcokat és oldalakat.
- Anyag beállítások, mert a felület befolyásolja a fény renderelését.
- Extrudálás vagy mélység beállítások, mert egy sík alakzatnak vastagságra van szüksége.

Az alábbi példa egy téglalapot hoz létre, szöveget ad az elülső felületéhez, és alkalmazza a 3D formázást. A kamera forgatási értékek fokban vannak, és az extrudálás magassága 100 pont. A példa a diát PNG képre rendereli a kétszeres alapméretben, és PPTX formátumban menti a prezentációt.

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

A renderelt diakép a téglalapot vastag 3D blokként mutatja:
![Kék 3D téglalap renderelve fehér 3D szöveggel az elülső felületen](img_01_01.png)

## **Alakzat forgatása a kamerával**

PowerPointban a 3D forgatást a 3-D forgatási panelen állítják be. Az X, Y és Z forgatási értékek megfelelnek a kamera API-n keresztül beállított forgatásnak.

![PowerPoint 3-D forgatási panel X, Y és Z forgatási értékek kiemelve](img_02_01.png)

Az Aspose.Slides-ben a kamerához a [ThreeDFormat.getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) metódussal férhetsz hozzá. Ez a példa egy téglalapot hoz létre, ortográfiai frontális nézetet választ, és beállítja az X, Y és Z forgatásait 20, 30 és 40 fokra. A formát memóriában konfigurálja fájl mentése nélkül:

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

Használd a kamerát, amikor meg kell változtatni, hogyan látja a néző az objektumot. Nem változtatja meg a 2D alakzat geometriáját a dián. A 3D nézőpontot változtatja, amelyet a PowerPoint és az Aspose.Slides a rendereléskor használ.

### **Kamera orientáció másolása egy sablon alakzatról**

Az orientáció egyeztetéséhez olvasd ki egy sablon alakzat kamera előbeállítását a [Camera.getCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getCameraType) segítségével, és forgatási szögeit a [Camera.getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getRotation) metódussal. A példa megnyitja a `template.pptx` fájlt, és átmásolja a kamera orientációt az első dia első alakzatáról a második alakzatra. Mindkét alakzat már rendelkezik 3D megvilágítással, a második alakzatnak nincs explicit kamera forgatása.

A szögek fokban vannak. A `0` index a szélességet, az `1` index a hosszúságot, a `2` index a revolúciót jelöli. Add át őket a [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) metódusnak ebben a sorrendben. Ha a forrás `None`‑t ad vissza, nincs explicit forgatás, ezért hagyd a második alakzat szögeit beállítatlanul. A `(0, 0, 0)` explicit forgatás három nullát ad vissza, és másolni kell.

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

Amikor újra megnyitod a `camera-copy.pptx`‑et PowerPointban, a jobb oldali nyíl ugyanazzal a kamera előbeállítással és forgatással rendelkezik, mint a bal oldali téglalap. Mindkét alakzat ugyanazt a megvilágítást és extrudálási mélységet használja.

![Kék 3D téglalap és egy jobb nyíl egyező kamera orientációval, felülről és jobbra nézve](camera-orientation.png)

## **Extrudálás és mélység hozzáadása**

Az extrudálás azt a hatást kelti, hogy az alakzat vastagabbá válik az elülső felület mögé nyúlva. PowerPointban a mélység vezérlő állítja be ezt a látható vastagságot, a szín vezérlő az oldalfelületek színét szabályozza.

![PowerPoint mélység vezérlők leképezve az extrudálás színére és magasság tulajdonságaira](img_02_02.png)

Használd a [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) metódust a vastagság beállításához és a [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) metódust az oldalszín eléréséhez. Ez a példa egy 100 pontos extrudálást ad a téglalapnak lila oldalakkal, és elforgatja a kamerát, hogy látható legyen a vastagsága. A formát memóriában konfigurálja fájl mentése nélkül:

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

A [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) metódus beállítja egy 3D alakzat mélységét. A [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) metódus szabályozza az extrudálás magasságát, ahogy ez a példában látható.

## **Színátmenetes vagy képes kitöltések használata 3D effektusokkal**

A 3D formázás független az alakzat kitöltésétől. Alkalmazhatsz egy egyenletes színt, színátmenetet, mintát vagy képi kitöltést az elülső felületre, miközben ugyanazt a kamera, fény, anyag és extrudálás beállítást használod.

Ez a példa egy kék‑narancssárga színátmenetet alkalmaz az elülső felületre és egy sötét narancssárga színt a 150 pontos extrudáláshoz. A színátmenet megállási pontjai a 0 és 100 jelölik a színátmenet kezdetét és végét. A kamera forgatási értékek fokban vannak. A dia PNG képre renderelődik a kétszeres alapmérettel:

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

![Renderelt 3D téglalap kék‑narancssárga színátmenetes kitöltéssel és narancssárga extrudálással](img_02_03.png)

Képes kitöltés használatához add hozzá a képet a prezentációhoz, és rendeld az alakzat kitöltéséhez. Ez a példa egy "image.jpg" nevű meglévő fájlt igényel a munkakönyvtárban. A képet nyújtja, hogy kitöltse a téglalapot, 150 pontos extrudálást alkalmaz, és fokban állítja be a kamera forgatást. A formát memóriában konfigurálja fájl mentése vagy renderelése nélkül:

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

![Renderelt 3D téglalap fotó kitöltéssel az elülső felületen és narancssárga extrudálással](img_02_04.png)

## **3D formázás alkalmazása szövegre**

Az alakzat 3D formázása az alakzat testére hat. A szöveg 3D formázása a szövegdobozra. Ez hasznos WordArt‑szerű effektusoknál, ahol a betűknek maguknak kell extrudálás, anyag, megvilágítás és kamera beállítások.

Az alábbi példa egy narancssárga‑fehér rácsmintával ellátott szöveget hoz létre, felfelé ívelt ívet alkalmaz, és 3D beállításokat konfigurál a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) használatával. Az extrudálás magassága és mélysége pontban van, a fény forgatás fokban. Az alakzat kitöltése és körvonala el van rejtve, így csak a szöveg látható. A példa PNG képet renderel a diák alapméretének kétszeresével, és PPTX formátumban menti a prezentációt:

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

![Renderelt 3D szöveg ívelt WordArt transzformációval, narancssárga mintás kitöltéssel és sötét extrudálással](img_02_05.png)

## **Szöveg sík tartása 3D alakzaton**

A szöveg olvashatóságának megőrzéséhez egy alakzat 3D megjelenésének fenntartása közben, hívd a [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setKeepTextFlat) metódust a [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getTextFrameFormat) útján. Ha az érték `True`, a szöveg kívül marad a 3D szenén. Ha `False`, a szöveg részt vesz a jelenetben és követi a 3D orientációt.

Ez a beállítás nem távolítja el az alakzat 3D formázását: kamera, megvilágítás, anyag és extrudálás továbbra is a [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) által van beállítva. Emellett különbözik a szokásos forgatástól. A [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) az alakzatot a dia síkjában forgatja, míg a [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) a szöveg egyéni forgatását szabályozza a körülötte lévő keretben. A szöveg 3D szenéből való kivétele nem állítja vissza ezeket a szögeket.

Az alábbi önálló példa egy kék téglalapot hoz létre szöveggel, és klónozza az eredeti mellett. Mindkét alakzat ugyanazt a 3D formázást kapja; csak a szöveg beállítása különbözik: a bal oldalon `False`, a jobb oldalon `True`. A kamera szögek fokban vannak, az extrudálás magassága 40 pont. A példa PPTX‑ként menti a prezentációt, és a összehasonlító diát PNG‑re rendereli a kétszeres alapmérettel.

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

Bal oldalon a szöveg követi a 3D orientációt. Jobb oldalon sík marad és könnyebben olvasható. Mindkét téglalap ugyanazt a látható extrudálást és 3D orientációt tartja meg.

![Egymás mellett lévő 3D téglalapok: a szöveg bal oldalon követi a 3D orientációt, jobb oldalon sík marad](keep_text_flat.png)

## **Exportálás és renderelési viselkedés**

Az Aspose.Slides megőrzi a 3D formázást PowerPoint formátumokba, például PPTX‑be mentéskor. Renderelés vagy exportálás fix elrendezésű formátumokba esetén a 3D jelenet raszterizálódik vagy 2D eredményként kerül a kimenetre. Ez akkor érvényes, amikor a diák [PNG](/slides/hu/python-java/convert-powerpoint-to-png/)-re renderelődik, [PDF](/slides/hu/python-java/convert-powerpoint-to-pdf/)-re exportálódik, [HTML](/slides/hu/python-java/convert-powerpoint-to-html/)-re exportálódik, vagy képkockákat generálsz [videó konvertáláshoz](/slides/hu/python-java/convert-powerpoint-to-video/).

Tartsd szem előtt a következő pontokat:

- Az exportált képek és PDF‑ek nem interaktívak. Az objektumot a néző nem tudja elforgatni export után.
- A végső megjelenés a kamera, fény rig, anyag, extrudálás, kitöltés és dia skálázás kombinációjától függ.
- Ha meg kell vizsgálnod az örökölt vagy témára alapuló formázási értékeket, olvasd el a [hatékony alakzat tulajdonságokat](/slides/hu/python-java/shape-effective-properties/).
- Néhány kimeneti formátum nem képes tárolni a szerkeszthető PowerPoint 3D formázást. Ezekben a formátumokban a vizuális eredmény renderelt, nem szerkeszthető 3D beállításként marad.

## **FAQ**

**Készíthet az Aspose.Slides interaktív 3D prezentációkat?**

Az Aspose.Slides létrehozza és rendereli a PowerPoint 3D effektusokat alakzatokhoz és szöveghez. Nem teszi interaktívvá az exportált képeket, PDF‑ket vagy HTML‑oldalakat olyan 3D jelenetekké, amelyeket a néző el tud forgatni. PPTX‑ben a 3D formázás szerkeszthető marad a PowerPointban, ahol a formátum támogatja.

**Mi a különbség egy 3D modell és egy 3D effektus között?**

A 3D modell egy különálló 3D objektum, amely a prezentációba van beszúrva. A 3D effektus egy formázás, amelyet egy szabályos PowerPoint alakzatra vagy szövegre alkalmazunk, például forgatás, extrudálás, lekerekítés, megvilágítás és anyag. Ez a cikk a 3D effektusokat tárgyalja.

**Milyen beállítások szükségesek egy látható 3D alakzathoz?**

A legalább egy kamera forgatás és egy extrudálás vagy mélység beállítása szükséges. Gyakorlatban érdemes továbbá beállítani egy fény riget és anyagot, hogy a renderelt felületeknek egyértelmű kiemelései és árnyékai legyenek.

**Alkalmazhatok 3D effektusokat alakzatokra és szövegre egyaránt?**

Igen. Használd a [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) metódust az alakzat testére, és a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) metódust a szövegre.

**Megjelennek a 3D effektusok exportáláskor képekre, PDF‑re, HTML‑re vagy videó keretekre?**

Igen. Az Aspose.Slides rendereli a 3D effektusokat, amikor diákat képekké, PDF‑ké, HTML‑ké vagy videó konvertáláshoz használt képkockákká alakít. Az exportált kimenet a renderelt megjelenést tartalmazza, nem szerkeszthető 3D objektumot.

**Olvashatom a végső 3D értékeket öröklődés és téma beállítások után?**

Igen. Használd a hatékony formázási API‑kat, amelyeket a [Shape Effective Properties](/slides/hu/python-java/shape-effective-properties/) leírásban találsz, a végső kamera, fény rig, lekerekítés és kapcsolódó 3D értékek beolvasásához.