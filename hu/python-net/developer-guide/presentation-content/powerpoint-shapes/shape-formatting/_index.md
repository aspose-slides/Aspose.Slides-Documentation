---
title: PowerPoint alakzatok formázása Pythonban
linktitle: Alakzatformázás
type: docs
weight: 20
url: /hu/python-net/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- vázlat hatás
- alakzatvonal vázlat
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
- 3D ferdítés hatás
- 3D forgatás hatás
- formázás visszaállítása
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan formázhatja a PowerPoint alakzatokat Pythonban az Aspose.Slides használatával—állítsa be a kitöltés, vonal és hatás stílusait PPT, PPTX és ODP fájlokhoz precízen és teljes ellenőrzéssel."
---
## **Bevezetés**

A PowerPointban alakzatokat adhat a diákhoz. Mivel az alakzatok vonalakból állnak, formázhatja őket a körvonalak módosításával vagy hatások alkalmazásával. Továbbá megadhatja az alakzatok kitöltését szabályozó beállításokkal, amelyek meghatározzák, hogyan legyen kitöltve a belsejük.

![format-shape-powerpoint](format-shape-powerpoint.png)

Az Aspose.Slides for Python osztályokat és tulajdonságokat biztosít, amelyek lehetővé teszik az alakzatok formázását a PowerPointban elérhető ugyanazokkal a beállításokkal.

## **Vonalak formázása**

Az Aspose.Slides segítségével megadhat egy egyéni vonalstílust egy alakzathoz. Az alábbi lépések vázolják a folyamatot:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) alakzatot a diához.
1. Állítsa be az alakzat [vonalstílus](https://reference.aspose.com/slides/hu/python-net/aspose.slides/linestyle/) tulajdonságát.
1. Állítsa be a vonal vastagságát.
1. Állítsa be az alakzat [szaggatott stílus](https://reference.aspose.com/slides/hu/python-net/aspose.slides/linedashstyle/) tulajdonságát.
1. Állítsa be az alakzat vonalszínét.
1. Mentse a módosított bemutatót PPTX fájlként.

Az alábbi Python kód bemutatja, hogyan formázhat egy téglalap `AutoShape` elemet:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
with slides.Presentation() as presentation:

    # Lekéri az első diát.
    slide = presentation.slides[0]

    # Hozzáad egy Rectangle típusú automatikus alakzatot.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Eltávolítja a kitöltést a téglalap alakzatról, így csak a vonalai láthatók.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Alkalmaz formázást a téglalap vonalaira.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Beállítja a téglalap vonalának színét.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Elmenti a PPTX fájlt a lemezre.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A bemutatóban formázott vonalak](formatted-lines.png)

## **Vázlat hatások alkalmazása az alakzat vonalaira**

A vázlat hatás úgy teszi a vonalat, mintha kézzel rajzolták volna. Használja a [Shape.line_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/line_format/) elemet a vonalbeállítások eléréséhez, a [LineFormat.sketch_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/lineformat/sketch_format/) elemet a vázlat beállításokhoz, és a [SketchFormat.sketch_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sketchformat/sketch_type/) elemet a [LineSketchType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/linesketchtype/) felsorolásból való érték kiválasztásához.

Az alábbi Python kód bemutatja, hogyan alkalmazzon egy [LineSketchType.CURVED](https://reference.aspose.com/slides/hu/python-net/aspose.slides/linesketchtype/) hatást, hogyan olvassa ki a kifejezetten beállított értéket, és hogyan távolítsa el a hatást a [LineSketchType.NONE](https://reference.aspose.com/slides/hu/python-net/aspose.slides/linesketchtype/) segítségével:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Hozzáfér az alakzat vonalformátumához és annak vázlatformátumához.
    sketch_format = shape.line_format.sketch_format

    # Vázlat hatást alkalmaz.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Kiolvassa a közvetlenül az alakzatra rendelt vázlat hatást.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Eltávolítja a vázlat hatást.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Az `SketchFormat.sketch_type` által visszaadott érték az alakzatra közvetlenül beállított beállítást jelenti. Ha a vonalformázás öröklődik egy témától, mester diától vagy elrendezési diától, használja a [LineFormat.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/lineformat/get_effective/) metódust, érje el a visszakapott objektum `sketch_format` tulajdonságát, és olvassa ki annak `sketch_type` értékét. A hatékony érték a ténylegesen alkalmazott formázást tükrözi az öröklődés feloldása után:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    line_format = shape.line_format

    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **Csatlakozási stílusok formázása**

Az alábbiak a három csatlakozási típus opciója:

* Kerek
* Metsző
* Ferde

Alapértelmezés szerint, amikor a PowerPoint két vonalat szögben (például egy alakzat sarkán) csatlakoztat, a **Kerek** beállítást használja. Ha azonban éles szögekkel rendelkező alakzatot rajzol, előnyben részesítheti a **Metsző** opciót.

![A csatlakozási stílus a bemutatóban](join-style-powerpoint.png)

Az alábbi Python kód bemutatja, hogyan hoztak létre három téglalapot (ahogy a fenti képen látható) a Metsző, Ferde és Kerek csatlakozási típus beállításokkal:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
with slides.Presentation() as presentation:

	# Lekéri az első diát.
	slide = presentation.slides[0]

	# Hozzáad három Rectangle típusú automatikus alakzatot.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Beállítja a kitöltési színt minden téglalap alakzatra.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Beállítja a vonal vastagságát.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Beállítja minden téglalap vonalának színét.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Beállítja a csatlakozási stílust.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Szöveget ad minden téglalaphoz.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Elmenti a PPTX fájlt a lemezre.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Színátmenetes kitöltés**

A PowerPointban a Színátmenetes kitöltés egy formázási lehetőség, amely lehetővé teszi, hogy folytonos színátmenetet alkalmazzon egy alakzatra. Például két vagy több színt alkalmazhat úgy, hogy az egyik fokozatosan elhalványul a másikba.

Az alábbiakban bemutatjuk, hogyan alkalmazzon színátmenetes kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) alakzatot a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/filltype/) értékét `GRADIENT`-re.
1. Adja hozzá a két kívánt színt a meghatározott pozíciókkal a `gradient_stops` gyűjtemény `add` metódusaival, amelyet a [GradientFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/gradientformat/) osztály biztosít.
1. Mentse a módosított bemutatót PPTX fájlként.

```python
import aspose.slides as slides

# Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
with slides.Presentation() as presentation:

    # Lekéri az első diát.
    slide = presentation.slides[0]

    # Hozzáad egy Ellipse típusú automatikus alakzatot.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Alkalmaz gradient formázást az ellipszisre.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Beállítja a gradient irányát.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Hozzáad két gradient stopot.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Elmenti a PPTX fájlt a lemezre.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

![Az ellipszis színátmenetes kitöltéssel](gradient-fill.png)

## **Minta kitöltés**

A PowerPointban a Minta kitöltés egy formázási lehetőség, amely lehetővé teszi egy kétszínű minta – például pontok, csíkok, keresztcsíkolás vagy négyzethálók – alkalmazását egy alakzatra. Egyéni színeket választhat a minta előtér és háttér részéhez.

Az Aspose.Slides több mint 45 előre definiált minta stílust biztosít, amelyeket alakzatokra alkalmazhat a bemutatók vizuális vonzerejének növelésére. Az előre definiált minta kiválasztása után is megadhatja a pontos színeket, amelyeket használni kell.

Az alábbiakban bemutatjuk, hogyan alkalmazzon minta kitöltést egy alakzatra az Aspose.Slides használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) alakzatot a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/filltype/) értékét `PATTERN`-re.
1. Válasszon egy minta stílust az előre definiált lehetőségek közül.
1. Állítsa be a minta [back_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides/patternformat/back_color/) értékét.
1. Állítsa be a minta [fore_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides/patternformat/fore_color/) értékét.
1. Mentse a módosított bemutatót PPTX fájlként.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
with slides.Presentation() as presentation:

    # Lekéri az első diát.
    slide = presentation.slides[0]

    # Hozzáad egy Rectangle típusú automatikus alakzatot.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Beállítja a kitöltés típusát Mintára.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Beállítja a minta stílusát.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Beállítja a minta háttér- és előtérszíneit.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Elmenti a PPTX fájlt a lemezre.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

![A téglalap minta kitöltéssel](pattern-fill.png)

## **Kép kitöltés**

A PowerPointban a Kép kitöltés egy formázási lehetőség, amely lehetővé teszi, hogy egy képet helyezzen be egy alakzatba – lényegében a képet a forma háttérként használva.

Az alábbiakban bemutatjuk, hogyan használhatja az Aspose.Slides-t kép kitöltés alkalmazásához egy alakzaton:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) alakzatot a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/filltype/) értékét `PICTURE`-re.
1. Állítsa be a kép kitöltés módját `TILE`-re (vagy egy másik kívánt módra).
1. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) objektumot a használni kívánt képből.
1. Rendelje hozzá ezt a képet a `picture.image` tulajdonsághoz az alakzat `picture_fill_format` részén.
1. Mentse a módosított bemutatót PPTX fájlként.

Tegyük fel, hogy van egy "lotus.png" fájl a következő képpel:

![A lotus kép](lotus.png)

```python
import aspose.slides as slides

# Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
with slides.Presentation() as presentation:

    # Lekéri az első diát.
    slide = presentation.slides[0]

    # Hozzáad egy Rectangle típusú automatikus alakzatot.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Beállítja a kitöltés típusát Képre.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Beállítja a kép kitöltés módját.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Betölti a képet és hozzáadja a prezentáció erőforrásaihoz.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Beállítja a képet.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Elmenti a PPTX fájlt a lemezre.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

![Az alakzat kép kitöltéssel](picture-fill.png)

### **Kép csempézése textúraként**

Ha csempézett képet szeretne beállítani textúraként, és testreszabni a csempézés viselkedését, a [PictureFillFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/) osztály következő tulajdonságait használhatja:

- [picture_fill_mode](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Beállítja a kép kitöltés módját – `TILE` vagy `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/tile_alignment/): Megadja a csempék elrendezését az alakzaton belül.
- [tile_flip](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/tile_flip/): Szabályozza, hogy a csempe vízszintesen, függőlegesen vagy mindkettőnél tükröződjön.
- [tile_offset_x](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/tile_offset_x/): Beállítja a csempe vízszintes eltolását (pontban) az alakzat origójától.
- [tile_offset_y](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/tile_offset_y/): Beállítja a csempe függőleges eltolását (pontban) az alakzat origójától.
- [tile_scale_x](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/tile_scale_x/): Meghatározza a csempe vízszintes méretezését százalékban.
- [tile_scale_y](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/tile_scale_y/): Meghatározza a csempe függőleges méretezését százalékban.

Az alábbi kódrészlet bemutatja, hogyan adjon hozzá egy téglalap alakzatot csempézett kép kitöltéssel, és állítsa be a csempe opciókat:

```py
import aspose.slides as slides

# Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
with slides.Presentation() as presentation:

    # Lekéri az első diát.
    first_slide = presentation.slides[0]

    # Hozzáad egy rectangle automatikus alakzatot.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Beállítja az alakzat kitöltés típusát Képre.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Betölti a képet és hozzáadja a prezentáció erőforrásaihoz.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Hozzáadja a képet az alakzathoz.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Konfigurálja a kép kitöltés módját és a csempézési tulajdonságokat.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Elmenti a PPTX fájlt a lemezre.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

![A csempe beállítások](tile-options.png)

## **Egyszínű kitöltés**

A PowerPointban az Egyszínű kitöltés egy formázási lehetőség, amely egyetlen, egységes színnel tölti ki az alakzatot. Ez az egyszerű háttérszín alkalmazásakor nincsenek színátmenetek, textúrák vagy minták.

Az Egyszínű kitöltés alkalmazásához egy alakzatra az Aspose.Slides segítségével, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) alakzatot a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/filltype/) értékét `SOLID`-ra.
1. Rendelje hozzá a kívánt kitöltési színt az alakzathoz.
1. Mentse a módosított bemutatót PPTX fájlként.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
with slides.Presentation() as presentation:

    # Lekéri az első diát.
    slide = presentation.slides[0]

    # Hozzáad egy Rectangle típusú automatikus alakzatot.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Beállítja a kitöltés típusát Szilárdra.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Beállítja a kitöltés színét.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Elmenti a PPTX fájlt a lemezre.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

![Az alakzat egyszínű kitöltéssel](solid-color-fill.png)

## **Átlátszóság beállítása**

A PowerPointban, amikor egyszínű, színátmenetes, kép vagy textúra kitöltést alkalmaz a alakzatokra, beállíthat átlátszósági szintet is, amely szabályozza a kitöltés átlátszatlanságát. Magasabb átlátszósági érték esetén az alakzat áttetszőbb, és a háttér vagy alatta lévő objektumok részben láthatóvá válnak.

Az Aspose.Slides lehetővé teszi az átlátszósági szint beállítását a kitöltés színének alfa értékének módosításával. Íme, hogyan:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) alakzatot a diához.
1. Állítsa be a kitöltés típusát `SOLID`-ra.
1. Használja a `Color.from_argb` metódust, hogy átlátszóságot tartalmazó színt definiáljon (az alfa komponens szabályozza az átlátszóságot).
1. Mentse a prezentációt.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
with slides.Presentation() as presentation:

    # Lekéri az első diát.
    slide = presentation.slides[0]
    
    # Hozzáad egy szilárd téglalap automatikus alakzatot.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Hozzáad egy átlátszó téglalap automatikus alakzatot a szilárd alakzat fölé.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

![Az átlátszó alakzat](shape-transparency.png)

## **Alakzatok forgatása**

Az Aspose.Slides lehetővé teszi az alakzatok forgatását a PowerPoint‑prezentációkban. Ez hasznos lehet a vizuális elemek elhelyezésekor, ha meghatározott igazításra vagy tervezési igényekre van szükség.

Az egy alakzat forgatásához a dián, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) alakzatot a diához.
1. Állítsa be az alakzat `rotation` tulajdonságát a kívánt szögre.
1. Mentse a prezentációt.

```python
import aspose.slides as slides

# Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
with slides.Presentation() as presentation:

    # Lekéri az első diát.
    slide = presentation.slides[0]

    # Hozzáad egy Rectangle típusú automatikus alakzatot.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Forgatja az alakzatot 5 fokkal.
    shape.rotation = 5

    # Elmenti a PPTX fájlt a lemezre.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

![Az alakzat forgatása](shape-rotation.png)

## **3D ferdítés hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D ferdítés hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/) tulajdonságok konfigurálásával.

3D ferdítés hatások hozzáadásához egy alakzatra, kövesse az alábbi lépéseket:

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályt.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) alakzatot a diához.
1. Állítsa be az alakzat [ThreeDFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/) tulajdonságát a ferdítés beállításainak meghatározásához.
1. Mentse a prezentációt.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Példányosítja a Presentation osztályt.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Alakzatot ad hozzá a diához.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Beállítja az alakzat ThreeDFormat tulajdonságait.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Elmenti a PPTX fájlt a lemezre.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

![A 3D ferdítés hatás](3D-bevel-effect.png)

## **3D forgatás hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D forgatás hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/) tulajdonságok konfigurálásával.

3D forgatás alkalmazásához egy alakzatra:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) alakzatot a diához.
1. Állítsa be az alakzat [camera_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/camera/camera_type/) és [light_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/lightrig/light_type/) tulajdonságait a 3D forgatás meghatározásához.
1. Mentse a prezentációt.

```python
import aspose.slides as slides

# Példányosítja a Presentation osztályt.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Elmenti a prezentációt PPTX fájlként.
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

![A 3D forgatás hatás](3D-rotation-effect.png)

## **Fekete-fehér megjelenítés szabályozása alakzatoknál**

A [Shape.black_white_mode](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/black_white_mode/) tulajdonság meghatározza, hogy egy adott alakzat hogyan jelenik meg, amikor egy bemutatót fekete-fehér módban tekintik vagy dolgozzák fel. Nem aktiválja magát a fekete-fehér megjelenítést, és nem változtatja meg az alakzat kitöltését, vonalát vagy egyéb formázását normál színmódban.

A kívánt viselkedés kiválasztásához használjon egy értéket a [BlackWhiteMode](https://reference.aspose.com/slides/hu/python-net/aspose.slides/blackwhitemode/) felsorolásból. Például az `AUTOMATIC` a megjelenítő alkalmazásnak hagyja a konverzió kiválasztását, a `GRAY` és `LIGHT_GRAY` szürke színezést alkalmaz, a `BLACK_WHITE` csak fekete-fehért használ, a `BLACK` és `WHITE` egyetlen színt kényszerít, a `COLOR` megőrzi a normál színezést, a `HIDDEN` elrejti az alakzatot fekete-fehér módban. A `NOT_DEFINED` azt jelenti, hogy nincs alakzatszintű mód beállítva.

Az alábbi Python kód létrehoz egy színes alakzatot, és a fekete-fehér megjelenítési módban szürkévé teszi:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # A narancssárga kitöltést színmódban megtartja, de fekete-fehér módban szürke színnel jeleníti meg az alakzatot.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

Normál színmódban a téglalap megtartja narancssárga kitöltését. Egy fekete-fehér megjelenítési folyamat során szürke színt használ, mivel módja `GRAY`‑re van állítva. Ez lehetővé teszi, hogy a teljes színű diát megőrizze, miközben egyedi megjelenést határoz meg nyomtatáshoz, előnézethez vagy más olyan munkafolyamatokhoz, amelyek tiszteletben tartják a bemutató fekete-fehér megjelenítési beállításait.

## **Formázás visszaállítása**

Az alábbi Python kód bemutatja, hogyan állítható vissza egy dia formázása, és hogyan állítható vissza az összes alakzat pozíciója, mérete és formázása a helyőrzőkkel a [LayoutSlide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/) alapértelmezett beállításaiba:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Visszaállítja a dián lévő minden alakzatot, amelyiknek helyőrzője van az elrendezésben.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Gyakran Ismételt Kérdések**

**A alakzat formázása befolyásolja a végső prezentáció fájlméretét?**

Csak minimálisan. A beágyazott képek és médiafájlok teszik ki a fájlméret legnagyobb részét, míg az alakzat paraméterei, mint a színek, hatások és színátmenetek metaadatként vannak tárolva, és gyakorlatilag nem növelik a méretet.

**Hogyan tudom felismerni a dián azon alakzatokat, amelyek azonos formázással rendelkeznek, hogy csoportosíthassam őket?**

Hasonlítsa össze az egyes alakzatok kulcsfontosságú formázási tulajdonságait – a kitöltés, vonal és hatás beállításait. Ha minden megfelelő érték megegyezik, tekintse a stílusokat azonosnak, és logikailag csoportosítsa az alakzatokat, ami megkönnyíti a későbbi stíluskezelést.

**Menthetek egy egyéni alakzastílus-készletet egy külön fájlba, hogy más prezentációkban újra felhasználjam?**

Igen. Tároljon mintaalakzatokat a kívánt stílusokkal egy sablon-diakönyvtárban vagy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és ahol szükséges, alkalmazza újra a formázásukat.