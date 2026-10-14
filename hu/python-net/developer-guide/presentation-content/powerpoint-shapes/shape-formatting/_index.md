---
title: PowerPoint alakzatok formázása Pythonban
linktitle: Alakzat formázás
type: docs
weight: 20
url: /hu/python-net/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- vázlat hatás
- alakzat vonal vázlat
- csatlakozási stílus formázása
- színátmenetes kitöltés
- mintás kitöltés
- képes kitöltés
- textúra kitöltés
- egyszínű kitöltés
- alakzat átlátszóság
- fekete-fehér alakzat renderelés
- szürkeárnyalatos alakzat renderelés
- alakzat forgatása
- 3D élsimítási hatás
- 3D forgatási hatás
- formázás visszaállítása
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Tanulja meg, hogyan formázhatja a PowerPoint alakzatokat Pythonban az Aspose.Slides segítségével—állítsa be a kitöltés, vonal és hatás stílusokat PPT, PPTX és ODP fájlokhoz precíz és teljes ellenőrzéssel."
---
## **Bevezetés**

A PowerPointban alakzatokat adhat hozzá a diákhoz. Mivel az alakzatok vonalakból állnak, formázhatja őket a körvonalak módosításával vagy hatások alkalmazásával. Emellett az alakzatokat olyan beállítások megadásával is formázhatja, amelyek szabályozzák, hogyan töltik ki a belsejüket.

![formázott-alakzat-powerpoint](format-shape-powerpoint.png)

Az Aspose.Slides for Python osztályokat és tulajdonságokat biztosít, amelyek lehetővé teszik az alakzatok formázását a PowerPointban elérhető ugyanazokkal a lehetőségekkel.

## **Vonalak formázása**

Az Aspose.Slides használatával egy alakzat egyedi vonalstílusát is megadhatja. Az alábbi lépések mutatják a eljárást:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be a alakzat [vonalstílusát](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/).
1. Állítsa be a vonal szélességét.
1. Állítsa be a alakzat [szaggatott stílusát](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/).
1. Állítsa be az alakzat vonalszínét.
1. Mentse a módosított prezentációt PPTX fájlként.

A következő Python kód bemutatja, hogyan formázhat egy téglalap `AutoShape`-t:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Létrehozza a Presentation osztályt, amely egy prezentációs fájlt képvisel.
with slides.Presentation() as presentation:

    # Lekéri az első diát.
    slide = presentation.slides[0]

    # Hozzáad egy Rectangle típusú automatikus alakzatot.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Eltávolítja a kitöltést a téglalap alakzatról, hogy csak a vonalai láthatók legyenek.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Alkalmazza a formázást a téglalap vonalaira.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Beállítja a téglalap vonalának színét.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Mentse a PPTX fájlt a lemezre.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:
![A formázott vonalak a prezentációban](formatted-lines.png)

## **Sketch hatások alkalmazása az alakzat vonalaira**

A sketch hatás egy alakzat vonalát kézzel rajzoltként mutatja. Használja a [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) metódust a vonalbeállítások eléréséhez, a [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) metódust a sketch beállításokhoz, és a [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/)‑ot a [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) felsorolásból érték kiválasztásához.

A következő Python kód bemutatja, hogyan alkalmazzon egy [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) hatást, hogyan olvassa ki a kifejezetten hozzárendelt értéket, és hogyan távolítsa el a hatást a [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) használatával:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Eléri az alakzat vonalformátumát és annak vázlatformátumát.
    sketch_format = shape.line_format.sketch_format

    # Alkalmaz egy vázlat hatást.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Kiolvassa a alakzatra közvetlenül hozzárendelt vázlat hatást.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Eltávolítja a vázlat hatást.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

A `SketchFormat.sketch_type` által visszaadott érték a közvetlenül az alakzatra beállított beállítást képviseli. Ha a vonalformázás egy sablonból, mesterdiából vagy elrendezésdíából örökölhető, használja a [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/)‑t, érje el a visszaadott objektum `sketch_format` tulajdonságát, és olvassa ki annak `sketch_type` tulajdonságát. A hatékony érték azt a formázást tükrözi, amely az öröklődés feloldása után valójában alkalmazásra kerül:
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

Itt vannak a három csatlakozási típus opciói:

* Kerek
* Vágott
* Lekerekített

Alapértelmezés szerint, amikor a PowerPoint két vonalat egy szögben (például egy alakzat sarkán) összekapcsol, a **Kerek** beállítást használja. Azonban ha éles szögekkel rendelkező alakzatot rajzol, előnyben részesítheti a **Vágott** opciót.

![A csatlakozási stílus a prezentációban](join-style-powerpoint.png)

A következő Python kód bemutatja, hogyan hoztak létre három téglalapot (az előző képen látható módon) a Miter, Bevel és Round csatlakozási típus beállításokkal:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Létrehozza a Presentation osztályt, amely egy prezentációs fájlt jelöl.
with slides.Presentation() as presentation:

	# Lekéri az első diát.
	slide = presentation.slides[0]

	# Hozzáad három Rectangle típusú automatikus alakzatot.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Beállítja minden téglalap alakzat kitöltőszínét.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Beállítja a vonalvastagságot.
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

	# Szöveget ad hozzá minden téglalaphoz.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Mentse a PPTX fájlt a lemezre.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Színátmenetes kitöltés**

A PowerPointban a Gradient Fill egy formázási opció, amely lehetővé teszi, hogy folyamatos színátmenetet alkalmazzon egy alakzatra. Például két vagy több színt alkalmazhat úgy, hogy az egyik fokozatosan elhalványul a másikba.

Íme, hogyan alkalmazzon színátmenetes kitöltést egy alakzatra az Aspose.Slides használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) értékét `GRADIENT`-ra.
1. Adja hozzá a két kívánt színt meghatározott pozíciókkal a `gradient_stops` gyűjtemény `add` metódusait használva, amelyet a [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/) osztály tesz elérhetővé.
1. Mentse a módosított prezentációt PPTX fájlként.

A következő Python kód bemutatja, hogyan alkalmazzon színátmenetes kitöltési hatást egy ellipszisre:
```python
import aspose.slides as slides

# Létrehozza a Presentation osztályt, amely egy prezentációs fájlt képvisel.
with slides.Presentation() as presentation:

    # Lekéri az első diát.
    slide = presentation.slides[0]

    # Hozzáad egy Ellipse típusú automatikus alakzatot.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Alkalmaz színátmenetes formázást az ellipszisre.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Beállítja a színátmenet irányát.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Két színátmenet állomást ad hozzá.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Mentse a PPTX fájlt a lemezre.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:
![Az ellipszis színátmenetes kitöltéssel](gradient-fill.png)

Ha egy színátmenet az exportált képen másként néz ki, mint a PowerPointban, lásd a [Choose a Gradient Rendering Style](/slides/hu/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) oldalt. Kiválaszthat egy renderelési stílust anélkül, hogy a prezentációban tárolt színátmenetes kitöltést megváltoztatná.

## **Minta kitöltés**

A PowerPointban a Pattern Fill egy formázási opció, amely lehetővé teszi, hogy kéttónás mintát – például pontokat, csíkokat, kereszteket vagy négyzethálót – alkalmazzon egy alakzatra. A minta előtér- és háttérszínéhez egyéni színeket választhat.

Az Aspose.Slides több mint 45 előre definiált mintastílust kínál, amelyeket alakzatokra alkalmazhat a prezentációk vizuális vonzerejének növelése érdekében. Még egy előre definiált minta kiválasztása után is megadhatja a pontos színeket, amelyeket használni kell.

Íme, hogyan alkalmazzon mintás kitöltést egy alakzatra az Aspose.Slides használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) értékét `PATTERN`-ra.
1. Válasszon egy mintastílust az előre definiált lehetőségek közül.
1. Állítsa be a minta [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) értékét.
1. Állítsa be a minta [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) értékét.
1. Mentse a módosított prezentációt PPTX fájlként.

A következő Python kód bemutatja, hogyan alkalmazzon mintás kitöltést egy téglalapra:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Létrehozza a Presentation osztályt, amely egy prezentációs fájlt képvisel.
with slides.Presentation() as presentation:

    # Lekéri az első diát.
    slide = presentation.slides[0]

    # Hozzáad egy Rectangle típusú automatikus alakzatot.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Beállítja a kitöltés típusát Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Beállítja a mintastílust.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Beállítja a minta háttér- és előtérszínét.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Mentse a PPTX fájlt a lemezre.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:
![A téglalap mintával kitöltve](pattern-fill.png)

## **Kép kitöltés**

A PowerPointban a Picture Fill egy formázási opció, amely lehetővé teszi, hogy egy képet illesszen be egy alakzatba – így a kép az alakzat háttérként szolgál.

Íme, hogyan használja az Aspose.Slides‑et képpel történő kitöltés alkalmazásához egy alakzaton:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) értékét `PICTURE`-ra.
1. Állítsa be a kép kitöltés módját `TILE`‑re (vagy egy másik kívánt módra).
1. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) objektumot a használni kívánt képből.
1. Rendelje hozzá ezt a képet a `picture.image` tulajdonsághoz az alakzat `picture_fill_format`‑jában.
1. Mentse a módosított prezentációt PPTX fájlként.

Tegyük fel, hogy van egy „lotus.png” fájlunk a következő képpel:
![A lótusz kép](lotus.png)

A következő Python kód bemutatja, hogyan töltsön ki egy alakzatot a képpel:
```python
import aspose.slides as slides

# Létrehozza a Presentation osztályt, amely egy prezentációs fájlt képvisel.
with slides.Presentation() as presentation:

    # Lekéri az első diát.
    slide = presentation.slides[0]

    # Hozzáad egy Rectangle típusú automatikus alakzatot.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Beállítja a kitöltés típusát Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Beállítja a kép kitöltés módját.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Betölti a képet és hozzáadja a prezentáció erőforrásaihoz.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Beállítja a képet.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Mentse a PPTX fájlt a lemezre.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:
![Az alakzat képpel kitöltve](picture-fill.png)

### **Kép csempézés mint textúra**

Ha csempézett képet szeretne textúraként beállítani, és testreszabni a csempézés viselkedését, a [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) osztály következő tulajdonságait használhatja:

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Beállítja a kép kitöltés módját—`TILE` vagy `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): Megadja a csempék alakzaton belüli igazítását.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): Szabályozza, hogy a csempe vízszintesen, függőlegesen vagy mindkettőre tükröződik-e.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): Beállítja a csempe vízszintes eltolását (pontokban) az alakzat kiindulópontjától.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): Beállítja a csempe függőleges eltolását (pontokban) az alakzat kiindulópontjától.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): Meghatározza a csempe vízszintes méretezését százalékban.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): Meghatározza a csempe függőleges méretezését százalékban.

A következő kódrészlet bemutatja, hogyan adjon hozzá egy téglalap alakzatot csempézett képkitöltéssel, és hogyan konfigurálja a csempe beállításait:
```py
import aspose.slides as slides

# Létrehozza a Presentation osztályt, amely egy prezentációs fájlt képvisel.
with slides.Presentation() as presentation:

    # Lekéri az első diát.
    first_slide = presentation.slides[0]

    # Hozzáad egy Rectangle típusú automatikus alakzatot.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Beállítja az alakzat kitöltés típusát Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Betölti a képet és hozzáadja a prezentáció erőforrásaihoz.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Hozzáadja a képet az alakzathoz.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Beállítja a kép kitöltés módját és a csempézés tulajdonságait.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Mentse a PPTX fájlt a lemezre.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:
![A csempe beállításai](tile-options.png)

## **Egyszínű kitöltés**

A PowerPointban a Solid Color Fill egy formázási opció, amely egy alakzatot egyetlen, egységes színnel tölti ki. Ez a tiszta háttérszín nem tartalmaz gradienseket, textúrákat vagy mintákat.

Az Aspose.Slides használatával az alábbi lépésekkel alkalmazhat egyszínű kitöltést egy alakzatra:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) értékét `SOLID`-ra.
1. Rendelje hozzá a kívánt kitöltőszínt az alakzathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

A következő Python kód bemutatja, hogyan alkalmazzon egyszínű kitöltést egy téglalapra egy PowerPoint dián:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Létrehozza a Presentation osztályt, amely egy prezentációs fájlt képvisel.
with slides.Presentation() as presentation:

    # Lekéri az első diát.
    slide = presentation.slides[0]

    # Hozzáad egy Rectangle típusú automatikus alakzatot.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Beállítja a kitöltés típusát Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Beállítja a kitöltő színt.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Mentse a PPTX fájlt a lemezre.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:
![Az alakzat egyszínű kitöltéssel](solid-color-fill.png)

## **Átlátszóság beállítása**

A PowerPointban, amikor egyszínű, színátmenetes, képes vagy textúras kitöltést alkalmaz a alakzatokra, beállíthat egy átlátszósági szintet is, hogy szabályozza a kitöltés átlátszóságát. Magasabb átlátszóság érték esetén az alakzat áttetszőbb lesz, így a háttér vagy az alatta lévő objektumok részben láthatóvá válnak.

Az Aspose.Slides lehetővé teszi az átlátszósági szint beállítását a kitöltéshez használt szín alfa értékének módosításával. Íme, hogyan:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be a kitöltés típusát `SOLID`‑ra.
1. Használja a `Color.from_argb`‑t egy átlátszó szín definiálásához (az `alpha` komponens szabályozza az átlátszóságot).
1. Mentse a prezentációt.

A következő Python kód bemutatja, hogyan alkalmazzon átlátszó kitöltőszínt egy téglalapra:
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Létrehozza a Presentation osztályt, amely egy prezentációs fájlt képvisel.
with slides.Presentation() as presentation:

    # Lekéri az első diát.
    slide = presentation.slides[0]
    
    # Hozzáad egy szilárd téglalap automatikus alakzatot.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Átlátszó téglalap automatikus alakzatot ad hozzá a szilárd alakzat fölé.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:
![Az átlátszó alakzat](shape-transparency.png)

## **Alakzatok forgatása**

Az Aspose.Slides lehetővé teszi az alakzatok forgatását PowerPoint-prezentációkban. Ez hasznos lehet a vizuális elemek elhelyezésekor, ha bizonyos igazítási vagy tervezési igények vannak.

Az alakzat egy dián való forgatásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat `rotation` tulajdonságát a kívánt szögre.
1. Mentse a prezentációt.

A következő Python kód bemutatja, hogyan forgasson egy alakzatot 5 fokkal:
```python
import aspose.slides as slides

# Létrehozza a Presentation osztályt, amely egy prezentációs fájlt képvisel.
with slides.Presentation() as presentation:

    # Lekéri az első diát.
    slide = presentation.slides[0]

    # Hozzáad egy Rectangle típusú automatikus alakzatot.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Forgatja az alakzatot 5 fokkal.
    shape.rotation = 5

    # Mentse a PPTX fájlt a lemezre.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:
![Az alakzat forgatása](shape-rotation.png)

## **3D élsimítási hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D élsimítási hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

3D élsimítási hatások hozzáadásához egy alakzathoz kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) elemet a diához.
1. Konfigurálja az alakzat [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) tulajdonságait az élsimítási beállítások meghatározásához.
1. Mentse a prezentációt.

A következő Python kód bemutatja, hogyan alkalmazzon 3D élsimítási hatásokat egy alakzatra:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Létrehozza a Presentation osztály példányát.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Alakzat hozzáadása a diára.
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

    # Mentse a prezentációt PPTX fájlként.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:
![A 3D élsimítási hatás](3D-bevel-effect.png)

## **3D forgatási hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D forgatási hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

3D forgatási hatás alkalmazásához egy alakzaton:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) és [light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) tulajdonságait a 3D forgatás meghatározásához.
1. Mentse a prezentációt.

A következő Python kód bemutatja, hogyan alkalmazzon 3D forgatási hatásokat egy alakzatra:
```python
import aspose.slides as slides

# Létrehozza a Presentation osztály példányát.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Mentse a prezentációt PPTX fájlként.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:
![A 3D forgatási hatás](3D-rotation-effect.png)

## **Fekete-fehér megjelenítés vezérlése alakzatoknál**

A [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) tulajdonság meghatározza, hogy egy egyedi alakzat hogyan jelenik meg, amikor a prezentációt fekete-fehér módban tekintik vagy dolgozzák fel. Ez önmagában nem aktiválja a fekete-fehér megjelenítést, és nem módosítja az alakzat kitöltését, vonalát vagy egyéb formázását a normál színmódban.

Válasszon egy értéket a [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) felsorolásból a kívánt viselkedéshez. Például az `AUTOMATIC` lehetővé teszi, hogy a renderelő alkalmazás válassza a konverziót, a `GRAY` és a `LIGHT_GRAY` szürke színezést használ, a `BLACK_WHITE` csak feketét és fehér színt alkalmaz, a `BLACK` és a `WHITE` egyetlen színt kényszerít, a `COLOR` megőrzi a normál színezést, a `HIDDEN` kihagyja az alakzatot a fekete-fehér módban, míg a `NOT_DEFINED` azt jelenti, hogy nincs hozzárendelt alakzatszintű mód.

A következő Python kód egy színes alakzatot hoz létre, amely a fekete-fehér megjelenítési módban szürke színűnek jelenik meg:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # Tartsa meg a narancssárga kitöltést színmódban, de a fekete-fehér módban szürke színnel jelenítse meg az alakzatot.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

Normál színmódban a téglalap megtartja narancssárga kitöltését. Fekete-fehér megjelenítési munkafolyamatban szürke színt használ, mivel a módja `GRAY`‑ra van állítva. Ez lehetővé teszi, hogy a teljes színű diát megőrizze, miközben külön megjelenést definiál nyomtatáshoz, előnézethez vagy más olyan munkafolyamatokhoz, amelyek tiszteletben tartják a prezentáció fekete-fehér megjelenítési beállításait.

## **Formázás visszaállítása**

A következő Python kód bemutatja, hogyan állítsa vissza egy dia formázását, és hogyan állítsa vissza az összes helyőrzővel rendelkező alakzat pozícióját, méretét és formázását a [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) alapértelmezett beállításaival:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Állítsa vissza a dián lévő minden alakzatot, amelynek helyőrzője van a layouton.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Befolyásolja az alakzat formázása a végleges prezentáció fájlméretét?**

Csak minimálisan. A beágyazott képek és médiafájlok foglalják a legtöbb helyet, míg az alakzatparaméterek, mint a színek, hatások és színátmenetek metaadatként tárolódnak, és gyakorlatilag nem növelik a méretet.

**Hogyan tudom felismerni az azonos formázást megosztó alakzatokat egy dián, hogy csoportosíthassam őket?**

Hasonlítsa össze minden alakzat kulcsfontosságú formázási tulajdonságait – kitöltés, vonal és hatás beállításait. Ha minden megfelelő érték megegyezik, tekintse a stílusokat azonosnak, és logikailag csoportosítsa az alakzatokat, ami leegyszerűsíti a későbbi stíluskezelést.

**Menthetek egy egyéni alakzatstílusok halmazát egy külön fájlba, hogy más prezentációkban is felhasználhassam?**

Igen. Tároljon mintaalakzatokat a kívánt stílusokkal egy sablon-diakönyvtárban vagy egy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és alkalmazza újra a formázásukat a szükséges helyeken.