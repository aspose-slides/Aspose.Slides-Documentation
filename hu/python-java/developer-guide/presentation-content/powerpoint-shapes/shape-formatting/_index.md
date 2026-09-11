---
title: PowerPoint alakzatok formázása Pythonban Java-n keresztül
linktitle: Alakzat formázása
type: docs
weight: 20
url: /hu/python-java/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- vázlat hatás
- vázlatos alakzatvonal
- csatlózási stílus formázása
- színátmenetes kitöltés
- mintás kitöltés
- képkitetés
- textúrakitöltés
- egyszínű kitöltés
- alakzat átlátszósága
- fekete-fehér alakzat renderelés
- szürkeárnyalatos alakzat renderelés
- alakzat forgatása
- 3D rézsút hatás
- 3D forgatási hatás
- formázás visszaállítása
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan formázhatja a PowerPoint alakzatokat Pythonban Java-n keresztül az Aspose.Slides segítségével—állítsa be a kitöltés, vonal és effektus stílusait PPT, PPTX és ODP fájlokhoz pontosan és teljes kontrollal."
---
## **Bevezetés**

A PowerPointban alakzatokat adhat hozzá a diákhoz. Mivel az alakzatok vonalakból állnak, formázhatja őket a körvonalak módosításával vagy hatások alkalmazásával. Továbbá beállíthatja az alakzatok kitöltését úgy, hogy meghatározza, hogyan legyenek kitöltve a belső részek.

![format-shape-powerpoint](format-shape-powerpoint.png)

Az Aspose.Slides for Python via Java osztályokat és metódusokat biztosít, amelyekkel a PowerPointban elérhető ugyanazokkal a lehetőségekkel formázhatja az alakzatokat.

## **Vonalak formázása**

Az Aspose.Slides segítségével egyedi vonalstílust adhat meg egy alakzathoz. Az alábbi lépések ismertetik a folyamatot:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [vonalstílus](https://reference.aspose.com/slides/hu/python-java/aspose.slides/linestyle/) értékét.
1. Állítsa be a vonal vastagságát.
1. Állítsa be a vonal [szaggatott stílus](https://reference.aspose.com/slides/hu/python-java/aspose.slides/linedashstyle/) értékét.
1. Állítsa be az alakzat vonalszínét.
1. Mentse a módosított bemutatót PPTX fájlként.

Az alábbi kód bemutatja, hogyan formázhat egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Hozza létre a Presentation osztályt, amely egy prezentáció fájlt képvisel.
presentation = Presentation()
try:
    # Szerezze meg az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Adjon hozzá egy Rectangle típusú automatikus alakzatot.
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

    # Mentse a PPTX fájlt a lemezre.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![The formatted lines in the presentation](formatted-lines.png)

## **Vázlatos hatások alkalmazása alakzatvonalakra**

A vázlat hatás úgy jeleníti meg a vonalat, mintha kézzel rajzolták volna. Használja a [Shape.getLineFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getLineFormat) metódust a vonal beállításainak eléréséhez, a [LineFormat.getSketchFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/lineformat/#getSketchFormat) metódust a vázlat beállításainak eléréséhez, és a [SketchFormat.setSketchType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sketchformat/#setSketchType) metódust a [LineSketchType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/linesketchtype/) felsorolásból való érték kiválasztásához.

Az alábbi Python kód megmutatja, hogyan alkalmazzon egy [LineSketchType.Curved](https://reference.aspose.com/slides/hu/python-java/aspose.slides/linesketchtype/#Curved) hatást, hogyan olvassa ki a kifejezetten hozzárendelt értéket, és hogyan távolítsa el a hatást a [LineSketchType.None_](https://reference.aspose.com/slides/hu/python-java/aspose.slides/linesketchtype/#None) használatával:

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

    # Vázlat hatás alkalmazása.
    sketch_format.setSketchType(LineSketchType.Curved)

    # A alakzatra közvetlenül hozzárendelt vázlat hatás kiolvasása.
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # A vázlat hatás eltávolítása.
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

A [SketchFormat.getSketchType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sketchformat/#getSketchType) által visszaadott érték azt a beállítást képviseli, amely közvetlenül az alakzatra van alkalmazva. Ha a vonal formázása öröklődik egy témából, mester-diából vagy elrendezés-diából, használja a [LineFormat.getEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/lineformat/#getEffective) metódust, érje el a `LineFormatEffectiveData.getSketchFormat` értéket, és olvassa ki a `SketchFormatEffectiveData.getSketchType` értéket. Az effektív érték azt a formázást tükrözi, amely ténylegesen alkalmazásra kerül az öröklődés feloldása után:

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

## **Csatlózási stílusok formázása**

A három csatlózási típus lehetősége:

* Kerek
* Vágott
* Levágott

Alapértelmezés szerint, amikor a PowerPoint két vonalat csatlakoztat szögnél (például egy alakzat sarkán), a **Kerek** beállítást használja. Ha azonban éles szögekkel rendelkező alakzatot rajzol, a **Vágott** opció előnyösebb lehet.

![The join style in the presentation](join-style-powerpoint.png)

Az alábbi Python kód bemutatja, hogyan hoztak létre három téglalapot (az előző képen látható módon) a Vágott, Levágott és Kerek csatlózási típus beállításokkal:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Példányosítsa a Presentation osztályt, amely egy prezentáció fájlt képvisel.
presentation = Presentation()
try:
    # Szerezze meg az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Adjon hozzá három automatikus alakzatot Rectangle típusban.
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # Állítsa be a kitöltő színt minden téglalap alakzatra.
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Állítsa be a vonalvastagságot.
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # Állítsa be a vonal színét minden téglalaphoz.
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Állítsa be a csatlózási stílust.
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # Adjon szöveget minden téglalaphoz.
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # Mentse a PPTX fájlt a lemezre.
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Színátmenetes kitöltés**

A PowerPointban a Színátmenetes kitöltés egy olyan formázási lehetőség, amely lehetővé teszi, hogy egy alakzatra folyamatos színátmenetet alkalmazzon. Például két vagy több színt alkalmazhat úgy, hogy az egyik fokozatosan átlékonyan átmenjen a másikba.

Az alábbi lépések mutatják be, hogyan alkalmazzon színátmenetes kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/filltype/) értékét `Gradient`‑re.
1. A [GradientFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/gradientformat/) osztály által kiírt gradient‑stop kollekció [addPresetColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/gradientstopcollection/#addPresetColor) metódusával adja hozzá a kívánt két színt meghatározott pozíciókkal.
1. Mentse a módosított bemutatót PPTX fájlként.

Az alábbi Python kód egy ellipszist mutat be, amelyre színátmenetes kitöltést alkalmaz:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

    # Példányosítja a Presentation osztályt, amely egy prezentáció fájlt képvisel.
    presentation = Presentation()
    try:
        # Beszerzi az első diát.
        slide = presentation.getSlides().get_Item(0)

        # Hozzáad egy automatikus alakzatot Ellipse típusban.
        shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

        # Alkalmazza a színátmenet formázást az ellipszisre.
        shape.getFillFormat().setFillType(FillType.Gradient)
        shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

        # Beállítja a színátmenet irányát.
        shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

        # Két színátmeneti pontot ad hozzá.
        shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
        shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

        # Mentse a PPTX fájlt a lemezre.
        presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Az eredmény:

![The ellipse with gradient fill](gradient-fill.png)

## **Minta kitöltés**

A PowerPointban a Minta kitöltés egy olyan formázási lehetőség, amely lehetővé teszi, hogy két‑színű mintát – például pontokat, csíkokat, keresztmintákat vagy négyzeteket – alkalmazzon egy alakzatra. A minta előtér‑ és háttérszínét egyedi színekre állíthatja be.

Az Aspose.Slides több mint 45 előre definiált mintastílust biztosít, amelyeket alakzatokra alkalmazhat a prezentációk vizuális hatásának fokozására. Még előre definiált mintát választva is megadhatja a pontos színeket, amelyeket a minta használjon.

Az alábbiakban bemutatjuk, hogyan alkalmazzon minta kitöltést egy alakzatra az Aspose.Slides használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/filltype/) értékét `Pattern`‑re.
1. Válasszon egy mintastílust az előre definiált lehetőségek közül.
1. Állítsa be a minta [Background Color](https://reference.aspose.com/slides/hu/python-java/aspose.slides/patternformat/#getBackColor) értékét.
1. Állítsa be a minta [Foreground Color](https://reference.aspose.com/slides/hu/python-java/aspose.slides/patternformat/#getForeColor) értékét.
1. Mentse a módosított bemutatót PPTX fájlként.

Az alábbi Python kód bemutatja, hogyan alkalmazzon minta kitöltést egy téglalapra:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Példányosítja a Presentation osztályt, amely egy prezentáció fájlt képvisel.
presentation = Presentation()
try:
    # Lekéri az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Hozzáad egy Rectangle típusú automatikus alakzatot.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Beállítja a kitöltés típusát Pattern-re.
    shape.getFillFormat().setFillType(FillType.Pattern)

    # Beállítja a minta stílusát.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # Beállítja a minta háttér- és előtérszíneit.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # Mentse a PPTX fájlt a lemezre.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![The rectangle with pattern fill](pattern-fill.png)

## **Kép kitöltés**

A PowerPointban a Kép kitöltés olyan formázási lehetőség, amely lehetővé teszi, hogy egy képet helyezzen el egy alakzat belsejében – a képet hatékonyan az alakzat háttérként használva.

Az alábbiakban bemutatjuk, hogyan alkalmazzon képkitetést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/filltype/) értékét `Picture`‑re.
1. Állítsa be a képkitetés módját `Tile`‑ra (vagy más kívánt módra).
1. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/) objektumot a használni kívánt képből.
1. Adja át a képet a `SlidesPicture.setImage` metódusnak.
1. Mentse a módosított bemutatót PPTX fájlként.

Tegyük fel, hogy van egy **lotus.png** nevű fájlunk a következő képpel:

![The lotus picture](lotus.png)

Az alábbi Python kód bemutatja, hogyan töltsön ki egy alakzatot a képpel:

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# Példányosítja a Presentation osztályt, amely egy prezentáció fájlt képvisel.
presentation = Presentation()
try:
    # Lekéri az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Hozzáad egy Rectangle típusú automatikus alakzatot.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # Beállítja a kitöltés típusát Picture-re.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Beállítja a kép kitöltési módot.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # Betölt egy képet és hozzáadja a prezentáció erőforrásaihoz.
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # Beállítja a képet.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Mentse a PPTX fájlt a lemezre.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![The shape with picture fill](picture-fill.png)

### **Kép téglalapokként textúra**

Ha téglalapozott képet szeretne textúraként beállítani, és testreszabni a csempe‑viselkedést, használhatja a [PictureFillFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/) osztály következő metódusait:

- [setPictureFillMode](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Beállítja a képkitetés módját – `Tile` vagy `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/#setTileAlignment): Megadja a csempék igazítását az alakzaton belül.
- [setTileFlip](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/#setTileFlip): Meghatározza, hogy a csempe vízszintesen, függőlegesen vagy mindkettőre legyen tükrözve.
- [setTileOffsetX](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Beállítja a csempe vízszintes eltolását (pontban) az alakzat origójától.
- [setTileOffsetY](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Beállítja a csempe függőleges eltolását (pontban) az alakzat origójától.
- [setTileScaleX](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/#setTileScaleX): Meghatározza a csempe vízszintes méretezését százalékban.
- [setTileScaleY](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/#setTileScaleY): Meghatározza a csempe függőleges méretezését százalékban.

Az alábbi kódrészlet bemutatja, hogyan adjon hozzá egy téglalap alakzatot csempézett képkitetéssel, és hogyan állítsa be a csempe‑opciókat:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# Példányosítja a Presentation osztályt, amely egy prezentáció fájlt képvisel.
presentation = Presentation()
try:
    # Lekéri az első diát.
    first_slide = presentation.getSlides().get_Item(0)

    # Hozzáad egy téglalap automatikus alakzatot.
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # Beállítja az alakzat kitöltés típusát Picture-re.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Betölti a képet és hozzáadja a prezentáció erőforrásaihoz.
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # Hozzáadja a képet az alakzathoz.
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # Beállítja a kép kitöltési módot és a csempe tulajdonságait.
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # Mentse a PPTX fájlt a lemezre.
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![The tile options](tile-options.png)

## **Egyszínű kitöltés**

A PowerPointban az Egyszínű kitöltés egy olyan formázási lehetőség, amely egyetlen, egységes színnel tölti ki az alakzatot. Ez a egyszerű háttérszín gradiensek, textúrák vagy minták nélkül kerül alkalmazásra.

Az egyszínű kitöltés alkalmazásához a következő lépéseket kövesse:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/filltype/) értékét `Solid`‑ra.
1. Rendelje hozzá a kívánt kitöltőszínt az alakzathoz.
1. Mentse a módosított bemutatót PPTX fájlként.

Az alábbi Python kód bemutatja, hogyan alkalmazzon egyszínű kitöltést egy téglalapra egy PowerPoint dián:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Példányosítja a Presentation osztályt, amely egy prezentáció fájlt képvisel.
presentation = Presentation()
try:
    # Lekéri az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Hozzáad egy Rectangle típusú automatikus alakzatot.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Beállítja a kitöltés típusát Solid-ra.
    shape.getFillFormat().setFillType(FillType.Solid)

    # Beállítja a kitöltő színt.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # Mentse a PPTX fájlt a lemezre.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![The shape with solid color fill](solid-color-fill.png)

## **Átlátszóság beállítása**

A PowerPointban, ha egyszínű, színátmenetes, kép‑ vagy textúrakitetést alkalmaz egy alakzatra, beállíthatja az átlátszóság szintjét is, amely a kitöltés átlátszatlanságát szabályozza. A magasabb átlátszósági érték átlátszóbbá teszi az alakzatot, így a háttér vagy az alatta lévő objektumok részben láthatóvá válnak.

Az Aspose.Slides lehetővé teszi az átlátszóság szintjének beállítását a kitöltéshez használt szín alfa komponensének módosításával. Így teheti:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be a [FillType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/filltype/) értékét `Solid`‑ra.
1. Használja a [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) osztályt olyan szín meghatározására, amely átlátszósággal rendelkezik (az `alpha` komponens vezérli az átlátszóságot).
1. Mentse a bemutatót.

Az alábbi Python kód megmutatja, hogyan alkalmazzon átlátszó kitöltőszínt egy téglalapra:

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Példányosítja a Presentation osztályt, amely egy prezentáció fájlt képvisel.
presentation = Presentation()
try:
    # Beszerzi az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Hozzáad egy szilárd téglalap automatikus alakzatot.
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Hozzáad egy átlátszó téglalap automatikus alakzatot a szilárd alakzat felett.
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # Mentse a PPTX fájlt a lemezre.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![The transparent shape](shape-transparency.png)

## **Alakzatok forgatása**

Az Aspose.Slides lehetővé teszi alakzatok forgatását PowerPoint‑prezentációkban. Ez hasznos lehet a vizuális elemek meghatározott igazítású vagy tervezési igényű elhelyezésénél.

Egy alakzat forgatásához a dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat forgatási tulajdonságát a kívánt szögre.
1. Mentse a bemutatót.

Az alábbi Python kód bemutatja, hogyan forgasson egy alakzatot 5 fokkal:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

    # Példányosítja a Presentation osztályt, amely egy prezentáció fájlt képvisel.
    presentation = Presentation()
    try:
        # Lekéri az első diát.
        slide = presentation.getSlides().get_Item(0)

        # Hozzáad egy Rectangle típusú automatikus alakzatot.
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

        # Forgatja az alakzatot 5 fokkal.
        shape.setRotation(5)

        # Mentse a PPTX fájlt a lemezre.
        presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Az eredmény:

![The shape rotation](shape-rotation.png)

## **3D rézsút hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D rézsút hatások alkalmazását alakzatokra, a [ThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

Egy 3D rézsút hatás hozzáadásához egy alakzathoz kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [ThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/) tulajdonságait a rézsút beállításainak meghatározásához.
1. Mentse a bemutatót.

Az alábbi Python kód bemutatja, hogyan alkalmazzon 3D rézsút hatásokat egy alakzatra:

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

    # Adjunk hozzá egy alakzatot a diához.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # Állítsa be az alakzat ThreeDFormat tulajdonságait.
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # Mentse a prezentációt PPTX fájlként.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![The 3D bevel effect](3D-bevel-effect.png)

## **3D forgatási hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D forgatási hatások alkalmazását alakzatokra, a [ThreeDFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

3D forgatás alkalmazásához egy alakzatra:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet a diához.
1. A [setCameraType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/camera/#setCameraType) és a [setLightType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/lightrig/#setLightType) metódusok használatával határozza meg a 3D forgatást.
1. Mentse a bemutatót.

Az alábbi Python kód bemutatja, hogyan alkalmazzon 3D forgatási hatásokat egy alakzatra:

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

Az eredmény:

![The 3D rotation effect](3D-rotation-effect.png)

## **Fekete-fehér megjelenítés vezérlése alakzatoknál**

A [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#setBlackWhiteMode) metódus határozza meg, hogyan legyen egy adott alakzat renderelve, amikor a bemutatót fekete‑fehér módban tekintik vagy dolgozzák fel. A metódus önmagában nem kapcsol be fekete‑fehér megjelenítést, és nem változtatja meg az alakzat kitöltését, vonalát vagy egyéb formázását normál színmódban.

A [BlackWhiteMode](https://reference.aspose.com/slides/hu/python-java/aspose.slides/blackwhitemode/) osztály értékét használva válassza ki a kívánt viselkedést. Például az `Automatic` lehetővé teszi a megjelenítő alkalmazásnak a konverzió kiválasztását, a `Gray` és a `LightGray` szürke árnyalatot alkalmaz, a `BlackWhite` csak feketét és fehéret használ, a `Black` és a `White` egyetlen színt kényszerít ki, a `Color` megőrzi a normál színezést, a `Hidden` elrejti az alakzatot fekete‑fehér módban, a `NotDefined` pedig azt jelenti, hogy nincs hozzárendelt alakzat‑szintű mód.

Az alábbi Python kód létrehoz egy színes alakzatot, és szürkévé teszi azt a fekete‑fehér megjelenítési mód során:

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

    # Tartsa a narancssárga kitöltést színes módban, de jelenítse meg az alakzatot szürke színnel fekete-fehér módban.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Normál színmódban a téglalap megtartja narancssárga kitöltését. Fekete‑fehér megjelenítés esetén a mód `Gray`‑re van állítva, ezért a téglalap szürke színnel jelenik meg, ami lehetővé teszi, hogy a teljes színű diát megtartsa, miközben a nyomtatáshoz, előnézethez vagy egyéb, a fekete‑fehér beállításokat tiszteletben tartó munkafolyamatokhoz külön megjelenítést definiáljon.

## **Formázás visszaállítása**

Az alábbi Python kód bemutatja, hogyan állítsa vissza egy dia formázását, és hogyan állítsa alaphelyzetbe a [LayoutSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layoutslide/) helyőrzőkkel rendelkező összes alakzat pozícióját, méretét és formázását:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # Állítsa vissza a dián lévő minden alakzatot, amelynek helyőrzője van az elrendezésben.
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Érint-e az alakzat formázása a végleges bemutató fájlméretét?**

Csak minimálisan. A beágyazott képek és média foglalja a fájl legtöbb helyét, míg a színek, effektusok és színátmenetek paraméterei metaadata‑ként tárolódnak, és gyakorlatilag nem növelik a méretet.

**Hogyan tudok olyan alakzatokat észlelni egy dián, amelyek azonos formázást használnak, hogy csoportosíthassam őket?**

Hasonlítsa össze az egyes alakzatok kulcsfontosságú formázási tulajdonságait – a kitöltés, vonal és effektus beállításait. Ha minden megfelelő érték megegyezik, tekintse a stílusokat azonosnak, és logikailag csoportosítsa az alakzatokat, ami megkönnyíti a későbbi stíluskezelést.

**Menthetek‑e egy egyedi alakzat‑stíluskészletet egy külön fájlba, hogy más prezentációkban újra felhasználjam?**

Igen. Tárolja a kívánt stílusokkal ellátott mintaalakzatokat egy sablon‑diakészletben vagy egy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és alkalmazza a formázásukat a szükséges helyeken.