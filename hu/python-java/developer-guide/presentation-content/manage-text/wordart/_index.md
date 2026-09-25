---
title: WordArt hatások létrehozása és alkalmazása Python alatt Java-n keresztül
linktitle: WordArt
type: docs
weight: 110
url: /hu/python-java/wordart/
keywords:
  - WordArt
  - WordArt létrehozása
  - WordArt sablon
  - WordArt hatás
  - árnyék hatás
  - tükrözés hatás
  - ragyogás hatás
  - WordArt átalakítás
  - 3D hatás
  - külső árnyék hatás
  - belső árnyék hatás
  - PowerPoint
  - prezentáció
  - Python
  - Java
  - Aspose.Slides
description: "WordArt hatások létrehozása és testreszabása az Aspose.Slides for Python via Java segítségével. Ez a lépésről‑lépésre útmutató segít a fejlesztőknek professzionális szöveggel gazdagítani a prezentációkat Python‑ban Java‑on keresztül."
---
## **Áttekintés**

A WordArt hatások lehetővé teszik, hogy szöveget töltsön ki, körvonalazzon, árnyékoljon, tükrözzön, ragyogóvá tegyen, átalakítson és 3D formázással lásson el. Ez a cikk bemutatja, hogyan hozhatók létre és testreszabhatók ezek a hatások PowerPoint‑prezentációkban az Aspose.Slides for Python via Java segítségével, Microsoft Office telepítése nélkül.

## **Egyszerű WordArt sablon létrehozása és alkalmazása szövegre**

Az alábbi példák egyszerű WordArt stílust építenek fel a szöveg, a betűtípus, a minta kitöltés és a körvonal beállításával.

Minden példa új prezentációt hoz létre, és egy téglalapot ad hozzá az első diára; bemeneti fájl nem szükséges. Az első példa a szöveget „Aspose.Slides”‑re állítja. A shape pozíciója és méretei pontban vannak megadva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```

Állítsa be a betűtípust Arial Black‑re 36 pontban, hogy a formázás feltűnőbb legyen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)
finally:
    presentation.dispose()
```

Alkalmazzon egy [SmallGrid](https://reference.aspose.com/slides/hu/python-java/aspose.slides/patternstyle/#SmallGrid) mintát sötét narancssárga előtérrel és fehér háttérrel, majd adjon hozzá egy fekete szöveg körvonalat 1 pont szélességgel:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    dark_orange = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(dark_orange)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid)

    portion.getPortionFormat().getLineFormat().setWidth(1)
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

Az eredményül kapott szöveg:

![Az egyszerű WordArt sablon](WordArt_template.png)

## **Egyéb WordArt hatások alkalmazása**

Az alábbi példák bemutatják, hogyan alkalmazhatók árnyékok, tükrözések, ragyogás, átalakítások és 3D hatások a szövegre.

### **Külső árnyék hatások alkalmazása**

A külső árnyék mélységet ad, ha a szöveg mögé helyezünk árnyékot. Színét, irányát, távolságát, elmosási sugarát, méretezését és nyíltását testreszabhatja.

Ez a példa meghívja a [enableOuterShadowEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effectformat/#enableOuterShadowEffect) metódust, és fekete árnyékot állít be 4 pont elmosási sugárral, 230 fokos iránnyal és 30 pont távolsággal. A 100‑as méretezés megőrzi az árnyék méretét, míg a vízszintes nyíltás 20 fokos ferdezettséget okoz. Az alfa transzformáció az átlátszatlanságot 32 %-ra állítja:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect()
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

Az eredményül kapott szöveg:

![A külső árnyék hatás](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Ha külső és előre definiált árnyékokat használnak együtt, csak a külső árnyék kerül alkalmazásra.
- Ha külső és belső árnyékokat használ egyidejűleg, a kapott hatás a PowerPoint verziójától függ. Például a PowerPoint 2013‑ban a hatás duplázódik, míg a PowerPoint 2007‑ben csak a külső árnyék jelenik meg.
{{% /alert %}}

### **Tükrözés hatások alkalmazása**

A tükrözés a szöveg tükrözött másolatát hozza létre. Pozícióját, méretezését, elmosását és átlátszatlanságát állíthatja a megjelenés szabályozásához.

Ez a példa meghívja a [enableReflectionEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effectformat/#enableReflectionEffect) metódust, és vertikálisan fordítja meg a tükrözést –100 %-os méretezéssel. 0,5 pont elmosási sugarat és 4,72 pont távolságot használ. Az átlátszatlanság 60 %-ról 0,9 %-ra csökken a 0 % és 60 % közötti pozíciókban a tükrözés mentén:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect()
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

Az eredményül kapott szöveg:

![A visszaverés hatása](reflection_effect.png)

### **Ragyogás hatások alkalmazása**

A ragyogás puha színes körvonalat ad a szöveg köré. Színét, átlátszatlanságát és sugarát állíthatja a hatás szabályozásához.

Ez a példa meghívja a [enableGlowEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effectformat/#enableGlowEffect) metódust, és piros ragyogást alkalmaz 54 %-os átlátszatlansággal és 7 pont sugarral:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableGlowEffect()
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7)
finally:
    presentation.dispose()
```

Az eredményül kapott szöveg:

![A ragyogás hatása](glow_effect.png)

### **WordArt átalakítások alkalmazása**

A WordArt átalakítások hajlítják, nyújtják vagy torzítják a szövegtömböt.

Állítsa a [setTransform](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setTransform) értékét [ArchUpPour](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textshapetype/#ArchUpPour)‑ra, hogy az egész szövegkeretet felfelé ívbe hajlítsa:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")
    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

Az eredményül kapott szöveg:

![A WordArt átalakítás](transform_effect.png)

{{% alert color="info" title="Note" %}}
Az Aspose.Slides for Python via Java egy kész előre definiált [átalakítási típus](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textshapetype/) halmazt biztosít.
{{% /alert %}}

### **3D hatások alkalmazása alakzatokra és szövegre**

3D hatásokat alkalmazhat egy alakzatra vagy annak szövegére. A rézsútok, kihúzások, világítás és kamera beállítások szabályozzák a végeredményt.

Az alábbi példa a [ThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/)‑t használja körkörös rézsútok, narancssárga kihúzás és sötétvörös kontúr hozzáadásához a téglalaphoz. A rézsút méretei, a kihúzás magassága, a kontúr szélessége és a mélység pontban vannak megadva. Egy műanyag anyag, egyensúlyozott világítás, amely 40 °‑kal a Z tengely körül forog, és egy perspektív kamera definiálja a megjelenést:

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

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    auto_shape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelBottom().setHeight(10.5)
    auto_shape.getThreeDFormat().getBevelBottom().setWidth(10.5)

    auto_shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelTop().setHeight(12.5)
    auto_shape.getThreeDFormat().getBevelTop().setWidth(11)

    orange = Color(255, 165, 0)
    auto_shape.getThreeDFormat().getExtrusionColor().setColor(orange)
    auto_shape.getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    auto_shape.getThreeDFormat().getContourColor().setColor(dark_red)
    auto_shape.getThreeDFormat().setContourWidth(1.5)

    auto_shape.getThreeDFormat().setDepth(3)

    auto_shape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    auto_shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    auto_shape.getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Az eredményül kapott alakzat:

![A forma 3D hatása](shape_3D_effect.png)

Ez a példa hasonló 3D formázást alkalmaz a szövegre a [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#getThreeDFormat) segítségével. Kisebb rézsútok alakítják a betűk széleit, míg a kihúzás és a világítás mélységet ad a szövegnek:

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

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5)

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4)

    orange = Color(255, 165, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange)
    text_frame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(dark_red)
    text_frame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5)

    text_frame.getTextFrameFormat().getThreeDFormat().setDepth(3)

    text_frame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    text_frame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Az eredményül kapott szöveg:

![A szöveg 3D hatása](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
A 3D hatások alkalmazása szövegre vagy annak alakzatára – valamint ezek kölcsönhatása – meghatározott szabályok szerint történik. Tekintsen egy szituációra, amely magában foglalja a szöveget és a rá vonatkozó alakzatot. Egy 3D hatás magában foglalja az objektum 3D reprezentációját és a környezetet, amelyben elhelyezkedik.

- Ha a szituáció mind a forma, mind a szöveg esetén be van állítva, a forma szituációja előnyben részesül, a szöveg szituációja figyelmen kívül marad.
- Ha a formának nincs saját szituációja, de van 3D reprezentációja, a szöveg szituációja kerül felhasználásra.
- Ha a formának egyáltalán nincs 3D hatása, laposnak tekintik, és a 3D hatás csak a szövegre kerül alkalmazásra.

Ezek a viselkedések a [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getLightRig) és a [ThreeDFormat.getCamera](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/#getCamera) metódusokra vonatkoznak.
{{% /alert %}}

A szöveg lapos és olvasható megtartásához, miközben az alakzat 3D formázását is megőrzi, tekintse meg a [Keep Text Flat on a 3D Shape](/slides/hu/python-java/3d-presentation/) oldalt a két beállítás összehasonlításáért és egy teljes Python példáért.

## **GYIK**

**Használhatok WordArt hatásokat különböző betűtípusokkal vagy írásrendszerekkel (pl. arab, kínai)?**

Igen, az Aspose.Slides for Python via Java támogatja az Unicode‑ot, és működik minden főbb betűtípussal és írásrendszerrel. A WordArt hatások, mint az árnyék, kitöltés és körvonal, nyelvtől függetlenül alkalmazhatók, bár a betűtípus elérhetősége és megjelenítése a rendszer betűtípusaiktól függhet.

**Alkalmazhatok WordArt hatásokat a diamester elemeire?**

Igen, a WordArt hatásokat alkalmazhatja a mesterdiák alakzataira, beleértve a címhelyőrzőket, láblécet vagy háttérszöveget. A mesterelrendezésen végzett módosítások minden kapcsolódó diára kihatnak.

**A WordArt hatások befolyásolják a prezentáció fájlméretét?**

Enyhén. A árnyékok, ragyogások és színátmenetes kitöltések kisebb növekedést okozhatnak a fájlméretben a hozzáadott formázási metaadatok miatt, de a különbség általában elhanyagolható.

**Előnézhetem a WordArt hatások eredményét a prezentáció mentése nélkül?**

Igen, a WordArt‑ot tartalmazó diákat képekké (például PNG, JPEG) renderelheti a [Slide.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getImage) vagy az egyes alakzatok a [Shape.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getImage) segítségével. Ez lehetővé teszi az eredmény előnézetét memóriában vagy a képernyőn, mielőtt mentené vagy exportálná a teljes prezentációt.