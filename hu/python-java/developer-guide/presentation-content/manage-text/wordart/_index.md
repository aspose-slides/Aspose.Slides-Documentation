---
title: WordArt hatások létrehozása és alkalmazása Pythonon keresztül Java-val
linktitle: WordArt
type: docs
weight: 110
url: /hu/python-java/wordart/
keywords:
- WordArt
- WordArt létrehozása
- WordArt sablon
- WordArt hatás
- árnyékhatás
- reflexióhatás
- fényhatás
- WordArt transzformáció
- 3D hatás
- külső árnyékhatás
- belső árnyékhatás
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "WordArt hatások létrehozása és testreszabása az Aspose.Slides Pythonra Java‑on keresztül. Ez a lépésről‑lépésre útmutató segít a fejlesztőknek a prezentációk professzionális szöveggel való gazdagításában Pythonon keresztül Java‑val."
---
## **Áttekintés**

WordArt hatások lehetővé teszik, hogy vizuálisan vonzó, stilizált szöveget adjunk hozzá PowerPoint előadásaihoz. Az Aspose.Slides segítségével a fejlesztők programozottan létrehozhatják, testre szabhatják és kezelhetik a WordArt-ot, akárcsak a Microsoft PowerPoint-ban—az Office telepítése nélkül. Ez a cikk áttekintést nyújt a WordArt használatáról, beleértve a szövegalakzat-transzformációk, kitöltési stílusok, körvonalak, árnyékok és egyéb formázási lehetőségek alkalmazását, hogy az előadás tartalma kifejezőbb és vonzóbb legyen. A WordArt lehetővé teszi, hogy a szöveget grafikai objektumként kezeljük. Olyan hatásokból vagy speciális módosításokból áll, amelyeket a szövegre alkalmaznak, hogy az vonzóbb vagy feltűnőbb legyen.

## **Egyszerű WordArt sablon létrehozása és alkalmazása szövegre**

**Aspose.Slides használata**

Először egyszerű szöveget hozunk létre ezzel a Python kóddal:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```
Ezután növeljük a betűméretet, hogy a hatás jobban látható legyen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    font_data = FontData("Arial Black")
    portion_format = portion.getPortionFormat()
    portion_format.setLatinFont(font_data)
    portion_format.setFontHeight(36)
finally:
    presentation.dispose()
```

**Microsoft PowerPoint használata**

Navigáljon a WordArt hatások menüjéhez a Microsoft PowerPoint-ban:

![WordArt hatások menüje a PowerPoint-ban](image-20200930113926-1.png)

A jobb oldali menüből választhat egy előre definiált WordArt hatást. A bal oldali menüből adhatja meg az új WordArt beállításait.

Ezek a rendelkezésre álló paraméterek vagy beállítások egy részei:

![WordArt formázási beállítások](image-20200930114015-3.png)

**Aspose.Slides használata**

Itt a [PatternStyle.SmallGrid](https://reference.aspose.com/slides/hu/python-java/aspose.slides/patternstyle/#SmallGrid) mintakitöltést alkalmazzuk a szövegre, és egy fekete szövegkeretet adunk hozzá ezzel a kóddal:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getFillFormat().setFillType(FillType.Pattern)
    pattern_format = portion_format.getFillFormat().getPatternFormat()
    pattern_format.getForeColor().setColor(Color.ORANGE)
    pattern_format.getBackColor().setColor(Color.WHITE)
    pattern_format.setPatternStyle(PatternStyle.SmallGrid)

    line_format = portion_format.getLineFormat()
    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

Az eredményül kapott szöveg:

![Minta kitöltésű és fekete szegélyű szöveg](image-20200930114108-4.png)

## **Más WordArt hatások alkalmazása**

**Microsoft PowerPoint használata**

A program felületéről ezeket a hatásokat alkalmazhatja szövegre, szövegblokkra, alakzatra vagy hasonló elemre:

![Szöveg- és alakzat hatások a PowerPoint-ban](image-20200930114129-5.png)

Például az Árnyék, Reflexió és Fény (Glow) hatásokat szövegre lehet alkalmazni; a 3D Formátum és 3D Forgatás hatásokat szövegblokkra; a Lágy Élek hatást alakzatra (még akkor is hat, ha nincs 3D Formátum hatás beállítva).

### **Árnyék hatások alkalmazása**

A következő Python kód csak szövegre alkalmaz árnyékhatást:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableOuterShadowEffect()
    outer_shadow = portion_format.getEffectFormat().getOuterShadowEffect()
    outer_shadow.getShadowColor().setColor(Color.BLACK)
    outer_shadow.setScaleHorizontal(100)
    outer_shadow.setScaleVertical(65)
    outer_shadow.setBlurRadius(4.73)
    outer_shadow.setDirection(230)
    outer_shadow.setDistance(2)
    outer_shadow.setSkewHorizontal(30)
    outer_shadow.setSkewVertical(0)
    outer_shadow.getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

Az Aspose.Slides API három típusú árnyékot támogat: [OuterShadow](https://reference.aspose.com/slides/hu/python-java/aspose.slides/outershadow/), [InnerShadow](https://reference.aspose.com/slides/hu/python-java/aspose.slides/innershadow/), és [PresetShadow](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presetshadow/).

A [PresetShadow](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presetshadow/) segítségével előre beállított értékekkel alkalmazhat árnyékot szövegre.

**Microsoft PowerPoint használata**

PowerPointban egyetlen árnyéktípust használhat. Íme egy példa:

![Árnyék beállítások PowerPointban](image-20200930114225-6.png)

**Aspose.Slides használata**

Az Aspose.Slides valójában egyszerre kétféle árnyékot engedélyez: [InnerShadow](https://reference.aspose.com/slides/hu/python-java/aspose.slides/innershadow/) és [PresetShadow](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presetshadow/).

**Megjegyzések:**
- Amikor a [OuterShadow](https://reference.aspose.com/slides/hu/python-java/aspose.slides/outershadow/) és a [PresetShadow](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presetshadow/) együtt van használva, csak a [OuterShadow](https://reference.aspose.com/slides/hu/python-java/aspose.slides/outershadow/) hatás lesz alkalmazva.
- Ha a [OuterShadow](https://reference.aspose.com/slides/hu/python-java/aspose.slides/outershadow/) és az [InnerShadow](https://reference.aspose.com/slides/hu/python-java/aspose.slides/innershadow/) egyszerre van használva, a létrejött vagy alkalmazott hatás a PowerPoint verziójától függ. Például PowerPoint 2013‑ban a hatás duplázódik, míg PowerPoint 2007‑ben a [OuterShadow](https://reference.aspose.com/slides/hu/python-java/aspose.slides/outershadow/) hatás lesz alkalmazva.

### **Reflexió alkalmazása szövegre**

A szöveghez reflexiót adunk hozzá ezzel a Python‑Java kódmintával:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableReflectionEffect()
    reflection = portion_format.getEffectFormat().getReflectionEffect()
    reflection.setBlurRadius(0.5)
    reflection.setDistance(4.72)
    reflection.setStartPosAlpha(0)
    reflection.setEndPosAlpha(60)
    reflection.setDirection(90)
    reflection.setScaleHorizontal(100)
    reflection.setScaleVertical(-100)
    reflection.setStartReflectionOpacity(60)
    reflection.setEndReflectionOpacity(0.9)
    reflection.setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

### **Fényhatású (Glow) alkalmazása szövegre**

A szöveghez fényhatást adunk, hogy ragyogjon vagy kitűnjön ezzel a kóddal:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableGlowEffect()
    glow = portion_format.getEffectFormat().getGlowEffect()
    glow.getColor().setR(jpype.JByte(-1))
    glow.getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    glow.setRadius(7)
finally:
    presentation.dispose()
```

A művelet eredménye:

![Fényhatású szöveg](image-20200930114621-7.png)

{{% alert color="info" title="Note" %}}
Módosíthatja az árnyék, reflexió és fényhatás paramétereit. A hatások tulajdonságai a szöveg egyes részeire külön-külön kerülnek beállításra.
{{% /alert %}}

### **Transzformációk használata a WordArt-ban**

Használja a [TextFrameFormat.setTransform](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setTransform) metódust az egész szövegblokk transzformálásához:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

Az eredmény:

![Ív alakú transzformációval ellátott szöveg](image-20200930114712-8.png)

{{% alert color="info" title="Note" %}}
A Microsoft PowerPoint és az Aspose.Slides for Python via Java egy bizonyos számú előre definiált transzformációtípust biztosít.
{{% /alert %}}

**PowerPoint használata**

Az előre definiált transzformációk eléréséhez lépjen a: **Formátum** -> **Szöveghatás** -> **Transzformálás**

**Aspose.Slides használata**

Transzformáció típus kiválasztásához használja a [TextShapeType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textshapetype/) felsorolást.

### **3D hatások alkalmazása szövegre és alakzatokra**

3D hatást alkalmazunk egy szöveg alakzatra ezzel a mintakóddal:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    three_d_format = auto_shape.getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(10.5)
    three_d_format.getBevelBottom().setWidth(10.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(12.5)
    three_d_format.getBevelTop().setWidth(11)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

A resulting text and its shape:

![3D hatású szöveg alakzat](image-20200930114816-9.png)

A szövegre 3D hatást alkalmazunk ezzel a Python kóddal:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    three_d_format = text_frame.getTextFrameFormat().getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(3.5)
    three_d_format.getBevelBottom().setWidth(3.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(4)
    three_d_format.getBevelTop().setWidth(4)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

A művelet eredménye:

![3D hatású szöveg](image-20200930114905-10.png)

{{% alert color="info" title="Note" %}}
A 3D hatások szövegre vagy annak alakzataira történő alkalmazása, valamint a hatások közötti kölcsönhatások bizonyos szabályokon alapulnak.

Tekintsen egy jelenetet a szöveg és a szöveget tartalmazó alakzat számára. A 3D hatás tartalmaz egy 3D objektumábrázolást és a jelenetet, amelyben az objektum elhelyezkedik.

- Ha a jelenet mind az alakzatra, mind a szövegre be van állítva, az alakzat jelenete elsőbbséget élvez – a szöveg jelenete figyelmen kívül marad.
- Ha az alakzatnak nincs saját jelenete, de van 3D ábrázolása, a szöveg jelenete kerül felhasználásra.
- Ellenkező esetben – ha az alakzat eredetileg nem rendelkezik 3D hatással – az alakzat lapos, és a 3D hatás csak a szövegre kerül alkalmazásra.

Ezek a szabályok a [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getLightRig) és a [ThreeDFormat.getCamera](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getCamera) metódusokra vonatkoznak.
{{% /alert %}}

## **Külső árnyék hatások alkalmazása szövegre**

Az Aspose.Slides for Python via Java biztosítja a [OuterShadow](https://reference.aspose.com/slides/hu/python-java/aspose.slides/outershadow/) és [InnerShadow](https://reference.aspose.com/slides/hu/python-java/aspose.slides/innershadow/) osztályokat, amelyek lehetővé teszik árnyékhatások alkalmazását egy [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) szövegre. Kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Szerezze meg a diára a hivatkozást az index segítségével.
3. Adjon hozzá egy téglalap alakzatot a diára.
4. Érje el a alakzathoz tartozó szövegkeretet.
5. Tiltsa le az alakzat kitöltését.
6. Engedélyezze a külső árnyék hatást.
7. Állítsa be az árnyék elmosódási sugarát.
8. Állítsa be az árnyék irányát.
9. Állítsa be az árnyék távolságát.
10. Igazítsa az árnyékot a bal felső sarokhoz.
11. Állítsa be az árnyék színét feketére.
12. Írja ki a prezentációt [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként.

Ez a Python‑Java minta kód – a fenti lépések megvalósítása – megmutatja, hogyan alkalmazza a külső árnyék hatást szövegre:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    # A dia referenciájának lekérése
    slide = presentation.getSlides().get_Item(0)

    # Rectangle típusú AutoShape hozzáadása
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50)

    # TextFrame hozzáadása a Rectangle-hez
    auto_shape.addTextFrame("Aspose TextBox")

    # A forma kitöltésének letiltása, ha a szöveg árnyékát szeretnénk
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Külső árnyék hozzáadása és az összes szükséges paraméter beállítása
    auto_shape.getEffectFormat().enableOuterShadowEffect()
    shadow = auto_shape.getEffectFormat().getOuterShadowEffect()
    shadow.setBlurRadius(4.0)
    shadow.setDirection(45)
    shadow.setDistance(3)
    shadow.setRectangleAlign(RectangleAlignment.TopLeft)
    shadow.getShadowColor().setPresetColor(PresetColor.Black)

    # A prezentáció mentése lemezre
    presentation.save("pres_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Belső árnyék hatás alkalmazása alakzatokhoz**

Kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Szerezze meg a dia hivatkozását.
3. Adjon hozzá egy téglalap alakzatot.
4. Engedélyezze a belső árnyék hatást.
5. Állítsa be az összes szükséges paramétert.
6. Állítsa be az árnyék szín típust téma szín használatára.
7. Állítsa be a téma színt.
8. Írja ki a prezentációt [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként.

Ez a minta kód (a fenti lépések alapján) megmutatja, hogyan alkalmazza a belső árnyék hatást egy alakzat szövegére Python‑Java környezetben:

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorType, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    # A dia referenciájának lekérése
    slide = presentation.getSlides().get_Item(0)

    # Rectangle típusú AutoShape hozzáadása
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300)
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # TextFrame hozzáadása a Rectangle-hez
    auto_shape.addTextFrame("Aspose TextBox")
    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion_format = portion.getPortionFormat()
    portion_format.setFontHeight(50)

    # InnerShadowEffect engedélyezése
    effect_format = portion_format.getEffectFormat()
    effect_format.enableInnerShadowEffect()

    # Az összes szükséges paraméter beállítása
    inner_shadow = effect_format.getInnerShadowEffect()
    inner_shadow.setBlurRadius(8.0)
    inner_shadow.setDirection(90.0)
    inner_shadow.setDistance(6.0)
    inner_shadow.getShadowColor().setB(jpype.JByte(-67))

    # ColorType beállítása Scheme-re
    inner_shadow.getShadowColor().setColorType(ColorType.Scheme)

    # Scheme szín beállítása
    inner_shadow.getShadowColor().setSchemeColor(SchemeColor.Accent1)

    # Prezentáció mentése
    presentation.save("WordArt_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Használhatok WordArt hatásokat különböző betűtípusokkal vagy írásrendszerekkel (pl. arab, kínai)?**

Igen, az Aspose.Slides támogatja a Unicode-ot és minden fő betűtípussal és írásrendszerrel működik. A WordArt hatások, mint például az árnyék, kitöltés és körvonal, nyelvtől függetlenül alkalmazhatók, bár a betűtípusok elérhetősége és megjelenítése a rendszer betűtípusaival függhet.

**Alkalmazhatok WordArt hatásokat a diamester elemekre?**

Igen, a WordArt hatásokat a mesterdiák alakzataira is alkalmazhatja, beleértve a címsor helyőrzőket, láblécek vagy háttérszövegeket. A mester elrendezésében végzett módosítások minden kapcsolódó dián megjelennek.

**A WordArt hatások befolyásolják a prezentáció fájlméretét?**

Kissé. A WordArt hatások, mint az árnyékok, fények és gradient kitöltések, kissé növelhetik a fájlméretet a hozzáadott formázási metaadatok miatt, de a különbség általában elhanyagolható.

**Előnézhetem a WordArt hatások eredményét a prezentáció mentése nélkül?**

Igen, a WordArt-ot tartalmazó diákat képekké (pl. PNG, JPEG) renderelheti a [Shape.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getImage) vagy a [Slide.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) használatával. Ez lehetővé teszi a végeredmény előnézetét memóriában vagy a képernyőn a teljes prezentáció mentése vagy exportálása előtt.