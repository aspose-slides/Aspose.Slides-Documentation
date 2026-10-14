---
title: PowerPoint alakzatok formázása Pythonon keresztül Java-val
linktitle: Alakzat formázása
type: docs
weight: 20
url: /hu/python-java/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- vázlat effektus
- alakzat vonal vázlat
- csatlakozási stílus formázása
- színátmenetes kitöltés
- minta kitöltés
- kép kitöltés
- textúra kitöltés
- egyszínű kitöltés
- alakzat átlátszósága
- fekete-fehér alakzat megjelenítés
- szürkeárnyalatos alakzat megjelenítés
- alakzat forgatása
- 3D vágás effektus
- 3D forgatás effektus
- formázás visszaállítása
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan formázhatja a PowerPoint alakzatokat Pythonon keresztül Java-val az Aspose.Slides használatával—állítson be kitöltés, vonal és effektus stílusokat PPT, PPTX és ODP fájlokhoz precízen és teljes kontrollal."
---
## **Bevezetés**

A PowerPointban alakzatokat adhat a diákhoz. Mivel az alakzatok vonalakból állnak, formázhatja őket a körvonalak módosításával vagy effektusok alkalmazásával. Ezenkívül az alakzatokat olyan beállítások megadásával formázhatja, amelyek szabályozzák, hogyan töltődnek ki a belsejük.

![alakzat_formázása_powerpoint](format-shape-powerpoint.png)

Az Aspose.Slides for Python via Java osztályokat és metódusokat biztosít, amelyek lehetővé teszik az alakzatok formázását a PowerPointban elérhető ugyanazokkal a beállításokkal.

## **Vonalak formázása**

Az Aspose.Slides használatával egy alakzatra egyéni vonalstílust adhat meg. Az alábbi lépések ismertetik az eljárást:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára az indexe alapján.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) elemet a diához.
4. Állítsa be az alakzat [vonalstílus](https://reference.aspose.com/slides/python-java/aspose.slides/linestyle/) tulajdonságát.
5. Állítsa be a vonal vastagságát.
6. Állítsa be a vonal [szaggatott stílus](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) tulajdonságát.
7. Állítsa be a vonal színét az alakzatra.
8. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi kód bemutatja, hogyan formázhat egy téglalap [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)-t:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
presentation = Presentation()
try:
    # Szerezze meg az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Adjon hozzá egy téglalap típusú automatikus alakzatot.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # Állítsa be a téglalap alakzat kitöltő színét.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Alkalmazzon formázást a téglalap vonalaira.
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # Állítsa be a téglalap vonalának színét.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Mentse a PPTX fájlt a lemezen.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A formázott vonalak a prezentációban](formatted-lines.png)

## **Vázlatolási effektusok alkalmazása az alakzat vonalaira**

A vázlatolási effektus azt az eredményt adja, hogy az alakzat vonala kézzel rajzoltként jelenik meg. Használja a [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) metódust a vonalbeállítások eléréséhez, a [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) metódust a vázlat beállítások eléréséhez, és a [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) metódust a [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) felsorolásból egy érték kiválasztásához.

Az alábbi Python kód azt mutatja, hogyan alkalmazhat egy [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#Curved) effektust, hogyan olvasható ki a kifejezetten hozzárendelt érték, és hogyan távolítható el az effektus a [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#None) használatával.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    # Hozzáférés az alakzat vonalformátumához és annak vázlatformátumához.
    sketch_format = shape.getLineFormat().getSketchFormat()

    # Vázlat effektus alkalmazása.
    sketch_format.setSketchType(LineSketchType.Curved)

    # A forma közvetlenül hozzárendelt vázlat effektusának olvasása.
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Vázlat effektus eltávolítása.
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

A [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) által visszaadott érték a közvetlenül az alakzatra beállított formázást jelenti. Ha a vonalformázás öröklődik egy témából, mester diából vagy elrendezési diából, használja a [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) metódust, érje el a `LineFormatEffectiveData.getSketchFormat`-ot, és olvassa ki a `SketchFormatEffectiveData.getSketchType`-ot. A hatékony érték azt a formázást tükrözi, amely ténylegesen alkalmazásra kerül az öröklődés feloldása után:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    line_format = shape.getLineFormat()

    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
finally:
    presentation.dispose()
```

## **Csatlakozási stílusok formázása**

Az alábbiak a három csatlakozási típus opciója:

* Kerek
* Éles
* Vágott

Alapértelmezés szerint, amikor a PowerPoint két vonalat összekapcsol szögnél (például egy alakzat sarkán), a **Kerek** beállítást használja. Ha azonban éles szögekkel rendelkező alakzatot rajzol, előnyben részesítheti a **Éles** opciót.

![A csatlakozási stílus a prezentációban](join-style-powerpoint.png)

Az alábbi Python kód bemutatja, hogyan hoztak létre három téglalapot (amint a fenti képen látható) a Miter, Bevel és Round csatlakozási típus beállítások használatával:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
presentation = Presentation()
try:
    # Szerezze meg az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Adjon hozzá három téglalap típusú automatikus alakzatot.
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # Állítsa be minden téglalap alakzat kitöltő színét.
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Állítsa be a vonal vastagságát.
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # Állítsa be minden téglalap vonalának színét.
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Állítsa be a csatlakozási stílust.
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # Adjon szöveget minden téglalaphoz.
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # Mentse a PPTX fájlt a lemezen.
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Színátmenetes kitöltés**

A PowerPointban a Színátmenetes kitöltés egy formázási lehetőség, amely lehetővé teszi, hogy folyamatos színkeverést alkalmazzon egy alakzatra. Például két vagy több színt alkalmazhat úgy, hogy az egyik fokozatosan elhalványul a másikba.

Az alábbiakban bemutatjuk, hogyan alkalmazzon színátmenetes kitöltést egy alakzatra az Aspose.Slides használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára az indexe alapján.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) elemet a diához.
4. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) értékét `Gradient`-re.
5. Adja hozzá a két kívánt színt a meghatározott pozíciókkal a [addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) metódussal, amely a [GradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/) osztály által biztosított színátmenet‑állomás-gyűjteményben érhető el.
6. Mentse a módosított prezentációt PPTX fájlként.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
presentation = Presentation()
try:
    # Szerezze meg az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Adjon hozzá egy Ellipse típusú automatikus alakzatot.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # Alkalmazzon színátmenetes formázást az ellipszisre.
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # Állítsa be a színátmenet irányát.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # Adjon hozzá két színátmenet‑állomást.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # Mentse a PPTX fájlt a lemezen.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Az ellipszis színátmenetes kitöltéssel](gradient-fill.png)

Ha egy színátmenet másként jelenik meg egy exportált képen, mint a PowerPointban, lásd a [Choose a Gradient Rendering Style](/slides/hu/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) oldalt. Kiválaszthat egy renderelési stílust anélkül, hogy megváltoztatná a prezentációban tárolt színátmenetes kitöltést.

## **Minta kitöltés**

A PowerPointban a Minta kitöltés egy formázási lehetőség, amely lehetővé teszi, hogy egy két színű mintát – például pöttyöket, csíkokat, keresztvonalakat vagy sakktáblát – alkalmazzon egy alakzatra. A minta elő- és háttérszínére egyéni színeket választhat.

Az Aspose.Slides több mint 45 előre definiált minta stílust kínál, amelyeket alakzatokra alkalmazhat a prezentációk vizuális vonzerejének növelésére. Még előre definiált minta kiválasztása után is megadhatja a pontos színeket, amelyeket használni kell.

Az alábbiakban bemutatjuk, hogyan alkalmazzon minta kitöltést egy alakzatra az Aspose.Slides használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára az indexe alapján.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) elemet a diához.
4. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) értékét `Pattern`-re.
5. Válasszon egy minta stílust az előre definiált lehetőségek közül.
6. Állítsa be a minta [Background Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) értékét.
7. Állítsa be a minta [Foreground Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) értékét.
8. Mentse a módosított prezentációt PPTX fájlként.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
presentation = Presentation()
try:
    # Szerezze meg az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Állítsa be a kitöltés típusát Pattern-re.
    shape.getFillFormat().setFillType(FillType.Pattern)

    # Állítsa be a minta stílusát.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # Állítsa be a minta háttér- és előtérszíneit.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # Mentse a PPTX fájlt a lemezen.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![A téglalap minta kitöltéssel](pattern-fill.png)

## **Kép kitöltés**

A PowerPointban a Kép kitöltés egy formázási lehetőség, amely lehetővé teszi, hogy egy képet helyezzen el egy alakzat belsejében – hatékonyan a képet az alakzat háttérként használva.

Az alábbiakban bemutatjuk, hogyan használhatja az Aspose.Slides-t kép kitöltés alkalmazásához egy alakzatra:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára az indexe alapján.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) elemet a diához.
4. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) értékét `Picture`-re.
5. Állítsa be a kép kitöltési módot `Tile`-re (vagy egy másik preferált módra).
6. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) objektumot a használni kívánt képből.
7. Adja át a képet a `SlidesPicture.setImage` metódusnak.
8. Mentse a módosított prezentációt PPTX fájlként.

Tegyük fel, hogy van egy "lotus.png" fájl a következő képpel:

![A lotus kép](lotus.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
presentation = Presentation()
try:
    # Szerezze meg az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # Állítsa be a kitöltés típusát Picture-re.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Állítsa be a kép kitöltési módot.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # Töltsön be egy képet, és adja hozzá a prezentáció erőforrásaihoz.
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # Állítsa be a képet.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Mentse a PPTX fájlt a lemezen.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![A forma kép kitöltéssel](picture-fill.png)

### **Képet csempeként textúrához**

Ha csempézett képet szeretne beállítani textúrának és testre szabni a csempézés viselkedését, a [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) osztály következő metódusait használhatja:

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Beállítja a képkitöltési módot – `Tile` vagy `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): Meghatározza a csempék igazítását az alakzaton belül.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): Ellenőrzi, hogy a csempe vízszintesen, függőlegesen vagy mindkettőre legyen-e tükrözve.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Beállítja a csempe vízszintes eltolását (pontban) az alakzat kiindulási pontjától.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Beállítja a csempe függőleges eltolását (pontban) az alakzat kiindulási pontjától.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): Meghatározza a csempe vízszintes méretezését százalékban.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): Meghatározza a csempe függőleges méretezését százalékban.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
presentation = Presentation()
try:
    # Szerezze meg az első diát.
    first_slide = presentation.getSlides().get_Item(0)

    # Adjon hozzá egy téglalap automatikus alakzatot.
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # Állítsa be az alakzat kitöltés típusát Picture-re.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Töltsön be egy képet, és adja hozzá a prezentáció erőforrásaihoz.
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # Rendelje hozzá a képet az alakzathoz.
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # Állítsa be a kép kitöltési módot és a csempézés tulajdonságait.
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # Mentse a PPTX fájlt a lemezen.
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![A csempe beállítások](tile-options.png)

## **Egyszínű kitöltés**

A PowerPointban az Egyszínű kitöltés egy formázási lehetőség, amely egyetlen, egységes színnel tölti ki az alakzatot. Ez az egyszerű háttérszín gradient, textúra vagy minta nélkül kerül alkalmazásra.

Az egyszínű kitöltés alkalmazásához egy alakzatra az Aspose.Slides segítségével, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára az indexe alapján.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) elemet a diához.
4. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) értékét `Solid`-ra.
5. Rendelje hozzá a kívánt kitöltő színt az alakzathoz.
6. Mentse a módosított prezentációt PPTX fájlként.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
presentation = Presentation()
try:
    # Szerezze meg az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Állítsa be a kitöltés típusát Solid-re.
    shape.getFillFormat().setFillType(FillType.Solid)

    # Állítsa be a kitöltő színt.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # Mentse a PPTX fájlt a lemezen.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![A forma egyszínű kitöltéssel](solid-color-fill.png)

## **Átlátszóság beállítása**

A PowerPointban, amikor egyszínű, színátmenetes, képes vagy textúrás kitöltést alkalmaz a alakzatokra, beállíthatja az átlátszósági szintet is a kitöltés átlátszóságának szabályozásához. A magasabb átlátszósági érték átlátszóbbá teszi az alakzatot, lehetővé téve, hogy a háttér vagy a mögöttes objektumok részben láthatóak legyenek.

Az Aspose.Slides lehetővé teszi az átlátszósági szint beállítását a kitöltéshez használt szín alfa értékének módosításával. Íme, hogyan tehető ez:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára az indexe alapján.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) elemet a diához.
4. Állítsa be a [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) értékét `Solid`-ra.
5. Használja a [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) osztályt egy átlátszó szín definiálásához (az `alpha` komponens szabályozza az átlátszóságot).
6. Mentse a prezentációt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
presentation = Presentation()
try:
    # Szerezze meg az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Adjon hozzá egy szilárd téglalap automatikus alakzatot.
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Adjon hozzá egy átlátszó téglalap automatikus alakzatot a szilárd alakzat fölé.
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # Mentse a PPTX fájlt a lemezen.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Az átlátszó alakzat](shape-transparency.png)

## **Alakzatok forgatása**

Az Aspose.Slides lehetővé teszi az alakzatok forgatását a PowerPoint prezentációkban. Ez hasznos lehet a vizuális elemek meghatározott igazítási vagy tervezési igényeinek elhelyezésénél.

Az alakzat forgatásához egy dián, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára az indexe alapján.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) elemet a diához.
4. Állítsa be az alakzat forgatási tulajdonságát a kívánt szögre.
5. Mentse a prezentációt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
presentation = Presentation()
try:
    # Szerezze meg az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Forgassa el az alakzatot 5 fokkal.
    shape.setRotation(5)

    # Mentse a PPTX fájlt a lemezen.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Az alakzat forgatása](shape-rotation.png)

## **3D vágás effektusok hozzáadása**

Az Aspose.Slides lehetővé teszi 3D vágás (bevel) effektusok alkalmazását az alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

3D vágás effektusok hozzáadásához egy alakzatra, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára az indexe alapján.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) elemet a diához.
4. Állítsa be az alakzat [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) paramétereit a vágás beállításához.
5. Mentse a prezentációt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Hozzon létre egy példányt a Presentation osztályból.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Add a shape to the slide.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # Set the shape's ThreeDFormat properties.
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # Save the presentation as a PPTX file.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![A 3D vágás effektus](3D-bevel-effect.png)

## **3D forgatási effektusok hozzáadása**

Az Aspose.Slides lehetővé teszi 3D forgatási effektusok alkalmazását az alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

3D forgatás alkalmazásához egy alakzatra:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára az indexe alapján.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) elemet a diához.
4. Használja a [setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) és a [setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType) metódusokat a 3D forgatás meghatározásához.
5. Mentse a prezentációt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# Hozzon létre egy példányt a Presentation osztályból.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # Mentse a prezentációt PPTX fájlként.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![A 3D forgatási effektus](3D-rotation-effect.png)

## **Fekete-fehér megjelenítés vezérlése az alakzatoknál**

A [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) metódus meghatározza, hogyan jelenik meg egy adott alakzat, amikor a prezentáció fekete-fehér módban kerül megtekintésre vagy feldolgozásra. Ez önmagában nem kapcsol be fekete-fehér megjelenítést, és nem változtatja meg az alakzat kitöltését, vonalát vagy egyéb formázását normál színmódban.

Használjon egy értéket a [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) osztályból a kívánt viselkedés kiválasztásához. Például a `Automatic` a renderelő alkalmazásnak hagyja a konverziót, a `Gray` és `LightGray` szürke színezést alkalmaz, a `BlackWhite` csak feketét és fehéret használ, a `Black` és `White` egyetlen színt kényszerít, a `Color` megőrzi a normál színezést, a `Hidden` elrejti az alakzatot fekete-fehér módban. A `NotDefined` azt jelenti, hogy nincs alakzatszintű mód beállítva.

Az alábbi Python kód létrehoz egy színes alakzatot, és fekete-fehér megjelenítési módban szürke színűvé teszi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    # Tartsa meg a narancssárga kitöltést szín módban, de a alakzatot szürke színnel jelenítse meg fekete-fehér módban.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Normál színmódban a téglalap megtartja narancssárga kitöltését. Egy fekete-fehér megjelenítési munkafolyamatban szürke színnel jelenik meg, mert a módja `Gray`-re van állítva. Ez lehetővé teszi, hogy megőrizze a teljes színű diát, miközben meghatároz egy eltérő megjelenést a nyomtatáshoz, előnézethez vagy egyéb munkafolyamatokhoz, amelyek a prezentáció fekete-fehér beállításait tiszteletben tartják.

## **Formázás visszaállítása**

Az alábbi Python kód bemutatja, hogyan állítható vissza egy dia formázása, és hogyan állítható vissza az összes placeholderrel rendelkező alakzat pozíciója, mérete és formázása a [LayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/) alapértelmezett beállításaira:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # Visszaállítja a dián lévő minden alakzatot, amelynek a layouton helyőrzője van.
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**A formázás befolyásolja a végleges prezentáció fájlméretét?**

Csak minimálisan. A beágyazott képek és médiafájlok foglalják a fájl helyének a legtöbb részét, míg az alakzatparaméterek, mint a színek, effektusok és színátmenetek metaadatként tárolódnak, és gyakorlatilag nem növelik a méretet.

**Hogyan tudok azonos formázású alakzatokat egy dián felderíteni, hogy csoportosíthassam őket?**

Hasonlítsa össze minden alakzat kulcsfontosságú formázási tulajdonságait – kitöltés, vonal és effektus beállítások. Ha minden megfelelő érték megegyezik, tekintse a stílusokat azonosnak, és logikailag csoportosítsa ezeket az alakzatokat, ami megkönnyíti a későbbi stíluskezelést.

**Menthetek egy egyéni alakzatstílus-készletet egy külön fájlba, hogy más prezentációkban is felhasználhassam?**

Igen. Tároljon például alakzatokat a kívánt stílusokkal egy sablon diakészletben vagy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és alkalmazza újra a formázásukat a szükséges helyeken.