---
title: PowerPoint alakzatok formázása Pythonban
linktitle: Alakzat formázása
type: docs
weight: 20
url: /hu/python-net/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- vázlat hatás
- vázlat alakzatvonal
- csatlakozási stílus formázása
- gradiens kitöltés
- minta kitöltés
- kép kitöltés
- textúra kitöltés
- egyszínű kitöltés
- alakzat átlátszóság
- alakzat forgatása
- 3D lekerekítési hatás
- 3D forgatási hatás
- formázás visszaállítása
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan formázhatja a PowerPoint alakzatokat Pythonban az Aspose.Slides segítségével – állítson be kitöltési, vonal- és effektusstílusokat PPT, PPTX és ODP fájlokhoz precíz és teljes irányítás mellett."
---
## **Bevezetés**

A PowerPointban alakzatokat adhat hozzá a diákhoz. Mivel az alakzatok vonalakból állnak, formázhatja őket a körvonalak módosításával vagy hatások alkalmazásával. Emellett az alakzatokat úgy is formázhatja, hogy beállításokat ad meg, amelyek szabályozzák, hogyan töltik ki a belsejüket.

![format-shape-powerpoint](format-shape-powerpoint.png)

Az Aspose.Slides for Python osztályokat és tulajdonságokat kínál, amelyek lehetővé teszik, hogy az alakzatokat a PowerPointban elérhető ugyanazon beállításokkal formázza.

## **Vonalak formázása**

Az Aspose.Slides használatával egy alakzat egyéni vonalstílusát adhatja meg. Az alábbi lépések vázolják a folyamatot:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diahoz.
1. Állítsa be az alakzat [vonalstílus](https://reference.aspose.com/slides/hu/python-net/aspose.slides/linestyle/) tulajdonságát.
1. Állítsa be a vonalvastagságot.
1. Állítsa be az alakzat [szaggatott stílus](https://reference.aspose.com/slides/hu/python-net/aspose.slides/linedashstyle/) tulajdonságát.
1. Állítsa be az alakzat vonalszínét.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi Python‑kód bemutatja, hogyan formázzon egy téglalap `AutoShape`‑t:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt reprezentál.
with slides.Presentation() as presentation:

    # Szerezze meg az első diát.
    slide = presentation.slides[0]

    # Adjunk hozzá egy Rectangle típusú automatikus alakzatot.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Állítsa be a téglalap alakzat kitöltő színét.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Alkalmazzon formázást a téglalap vonalaira.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Állítsa be a téglalap vonalának színét.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Mentse a PPTX fájlt a lemezre.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A prezentációban formázott vonalak](formatted-lines.png)

## **Vázlat hatások alkalmazása az alakzat vonalaira**

A vázlat hatás egy alakzat vonalát kézzel rajzoltként jeleníti meg. Használja a [Shape.line_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/line_format/)‑t a vonalbeállítások eléréséhez, a [LineFormat.sketch_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/lineformat/sketch_format/)‑t a vázlat beállításokhoz, valamint a [SketchFormat.sketch_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sketchformat/sketch_type/)‑t a [LineSketchType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/linesketchtype/) felsorolásból egy érték kiválasztásához.

Az alábbi Python‑kód bemutatja, hogyan alkalmazzon egy [LineSketchType.CURVED](https://reference.aspose.com/slides/hu/python-net/aspose.slides/linesketchtype/) hatást, hogyan olvassa ki a kifejezetten hozzárendelt értéket, és hogyan távolítsa el a hatást a [LineSketchType.NONE](https://reference.aspose.com/slides/hu/python-net/aspose.slides/linesketchtype/) használatával:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Hozzáférés az alakzat vonalformátumához és a vázlatformátumához.
    sketch_format = shape.line_format.sketch_format

    # Vázlat hatás alkalmazása.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # A közvetlenül az alakzatra hozzárendelt vázlat hatás beolvasása.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Vázlat hatás eltávolítása.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

A `SketchFormat.sketch_type` által visszaadott érték az alakzatra közvetlenül beállított beállítást jelöli. Ha a vonalformázás öröklődhet egy témából, mesterdiából vagy elrendezésdíából, használja a [LineFormat.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides/lineformat/get_effective/) metódust, érje el a visszaadott objektum `sketch_format` tulajdonságát, és olvassa ki annak `sketch_type` tulajdonságát. A hatékony érték a valójában alkalmazott formázást tükrözi, miután az öröklődés feloldódott:

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

Az alábbiak a három csatlakozási típus lehetősége:

* Kerek
* Vágott
* Sík

Alapértelmezés szerint a PowerPoint két vonalat szögben (például egy alakzat sarkán) összekapcsolva a **Kerek** beállítást használja. Ha azonban éles szögekkel rendelkező alakzatot rajzol, előnyben részesítheti a **Vágott** (Miter) lehetőséget.

![A prezentációban a csatlakozási stílus](join-style-powerpoint.png)

Az alábbi Python‑kód bemutatja, hogyan hoztunk létre három téglalapot (az előző képen látható módon) a Vágott, Sík és Kerek csatlakozási beállítások használatával:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt reprezentál.
with slides.Presentation() as presentation:

	# Szerezze meg az első diát.
	slide = presentation.slides[0]

	# Adjon hozzá három Rectangle típusú automatikus alakzatot.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Állítsa be minden téglalap alakzat kitöltő színét.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Állítsa be a vonal vastagságát.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Állítsa be minden téglalap vonalának színét.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Állítsa be a csatlakozási stílust.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Adjon hozzá szöveget minden téglalaphoz.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Mentse a PPTX fájlt a lemezre.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Gradiens kitöltés**

A PowerPointban a Gradiens kitöltés egy formázási lehetőség, amely lehetővé teszi, hogy folyamatos színátmenetet alkalmazzon egy alakzatra. Például két vagy több színt alkalmazhat úgy, hogy az egyik fokozatosan elhalványul a másikba.

Így alkalmazhat gradiens kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diahoz.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/filltype/) értékét `GRADIENT`‑ra.
1. Adja hozzá a kívánt két színt a meghatározott pozíciókkal a [GradientFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/gradientformat/) osztály által biztosított `gradient_stops` gyűjtemény `add` metódusaival.
1. Mentse a módosított prezentációt PPTX fájlként.

```python
import aspose.slides as slides

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt reprezentál.
with slides.Presentation() as presentation:

    # Szerezze meg az első diát.
    slide = presentation.slides[0]

    # Adjon hozzá egy Ellipse típusú automatikus alakzatot.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Alkalmazzon gradiens formázást az ellipszisre.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Állítsa be a gradiens irányát.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Adjon hozzá két gradiens állomást.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Mentse a PPTX fájlt a lemezre.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az elliptikus alakzaton a gradiens kitöltés](gradient-fill.png)

## **Minta kitöltés**

A PowerPointban a Minta kitöltés egy formázási lehetőség, amely lehetővé teszi, hogy kétszínű mintát – például pontokat, csíkokat, keresztvonalakat vagy sakktáblát – alkalmazzon egy alakzatra. A minta előtér és háttér színeit egyéni színekkel állíthatja be.

Az Aspose.Slides több mint 45 előre definiált minta stílust biztosít, amelyeket alakzatokra alkalmazhat a prezentációk vizuális megjelenésének fokozásához. Még egy előre definiált minta kiválasztása után is megadhatja a pontos színeket, amelyeket használni kíván.

Így alkalmazhat minta kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diahoz.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/filltype/) értékét `PATTERN`‑ra.
1. Válasszon egy minta stílust az előre definiált lehetőségek közül.
1. Állítsa be a minta [back_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides/patternformat/back_color/) értékét.
1. Állítsa be a minta [fore_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides/patternformat/fore_color/) értékét.
1. Mentse a módosított prezentációt PPTX fájlként.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt reprezentál.
with slides.Presentation() as presentation:

    # Szerezze meg az első diát.
    slide = presentation.slides[0]

    # Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Állítsa be a kitöltés típusát Pattern-re.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Állítsa be a minta stílusát.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Állítsa be a minta háttér- és előtérszíneit.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Mentse a PPTX fájlt a lemezre.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A téglalap minta kitöltéssel](pattern-fill.png)

## **Kép kitöltés**

A PowerPointban a Kép kitöltés egy formázási lehetőség, amely lehetővé teszi, hogy egy képet helyezzen el egy alakzaton belül – így a képet az alakzat háttérként használja.

Így használhatja az Aspose.Slides‑t a kép kitöltés alkalmazására egy alakzaton:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diahoz.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/filltype/) értékét `PICTURE`‑ra.
1. Állítsa be a kép kitöltés módját `TILE`‑ra (vagy egy másik kívánt módra).
1. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) objektumot a használni kívánt képből.
1. Rendelje hozzá ezt a képet az alakzat `picture_fill_format` tulajdonságának `picture.image` mezőjéhez.
1. Mentse a módosított prezentációt PPTX fájlként.

![A lotus.png kép](lotus.png)

```python
import aspose.slides as slides

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt reprezentál.
with slides.Presentation() as presentation:

    # Szerezze meg az első diát.
    slide = presentation.slides[0]

    # Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Állítsa be a kitöltés típusát Picture-re.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Állítsa be a kép kitöltés módját.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Töltsön be egy képet, és adja hozzá a prezentáció erőforrásaihoz.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Állítsa be a képet.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Mentse a PPTX fájlt a lemezre.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az alakzat kép kitöltéssel](picture-fill.png)

### **Képet csempeként használni textúraként**

Ha egy csempézett képet szeretne textúraként beállítani, és testre szabni a csempézés viselkedését, használhatja a [PictureFillFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/) osztály következő tulajdonságait:

- [picture_fill_mode](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/picture_fill_mode/): A picture fill mode beállítása – vagy `TILE`, vagy `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/tile_alignment/): Meghatározza a csempék igazítását az alakzaton belül.
- [tile_flip](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/tile_flip/): Szabályozza, hogy a csempe vízszintesen, függőlegesen vagy mindkettő szerint legyen-e tükrözve.
- [tile_offset_x](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/tile_offset_x/): Beállítja a csempe vízszintes eltolását (pontban) az alakzat kiindulási pontjától.
- [tile_offset_y](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/tile_offset_y/): Beállítja a csempe függőleges eltolását (pontban) az alakzat kiindulási pontjától.
- [tile_scale_x](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/tile_scale_x/): Meghatározza a csempe vízszintes méretezését százalékban.
- [tile_scale_y](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/tile_scale_y/): Meghatározza a csempe függőleges méretezését százalékban.

```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt reprezentál.
with slides.Presentation() as presentation:

    # Szerezze meg az első diát.
    first_slide = presentation.slides[0]

    # Adjon hozzá egy téglalap automatikus alakzatot.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Állítsa be az alakzat kitöltés típusát Picture-re.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Töltsön be egy képet, és adja hozzá a prezentáció erőforrásaihoz.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Rendelje hozzá a képet az alakzathoz.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Állítsa be a kép kitöltés módját és a csempézés tulajdonságait.
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

![A csempe beállítások](tile-options.png)

## **Egyszínű kitöltés**

A PowerPointban az Egyszínű kitöltés egy formázási lehetőség, amely egyetlen, egységes színnel tölti ki az alakzatot. Ez az egyszerű háttérszín nem tartalmaz gradiens, textúra vagy minta elemeket.

Egyszínű kitöltés alkalmazásához az Aspose.Slides‑ben kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diahoz.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/filltype/) értékét `SOLID`‑ra.
1. Rendelje hozzá a kívánt kitöltőszínt az alakzathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt reprezentál.
with slides.Presentation() as presentation:

    # Szerezze meg az első diát.
    slide = presentation.slides[0]

    # Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Állítsa be a kitöltés típusát Solid-ra.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Állítsa be a kitöltő színt.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Mentse a PPTX fájlt a lemezre.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az alakzat egyszínű kitöltéssel](solid-color-fill.png)

## **Átlátszóság beállítása**

A PowerPointban, amikor egy alakzatra egyszínű, gradiens, kép vagy textúra kitöltést alkalmaz, beállíthatja az átlátszósági szintet is, hogy szabályozza a kitöltés átlátszóságát. A magasabb átlátszóság érték átlátszóbbá teszi az alakzatot, lehetővé téve a háttér vagy az alatta lévő objektumok részleges láthatóságát.

Az Aspose.Slides a szín alfa komponensének módosításával teszi lehetővé az átlátszóság beállítását. Így teheti ezt:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diahoz.
1. Állítsa be a kitöltés típusát `SOLID`‑ra.
1. Használja a `Color.from_argb` metódust egy átlátszó szín definiálásához (az `alpha` komponens szabályozza az átlátszóságot).
1. Mentse a prezentációt.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt reprezentál.
with slides.Presentation() as presentation:

    # Szerezze meg az első diát.
    slide = presentation.slides[0]
    
    # Adjunk hozzá egy szilárd téglalap automatikus alakzatot.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Adjunk hozzá egy átlátszó téglalap automatikus alakzatot a szilárd alakzat fölé.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az átlátszó alakzat](shape-transparency.png)

## **Alakzatok forgatása**

Az Aspose.Slides lehetővé teszi alakzatok forgatását a PowerPoint‑prezentációkban. Ez hasznos lehet, ha vizuális elemeket meghatározott igazítással vagy dizájnnal kell elhelyezni.

Alakzat forgatásához a dián kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diahoz.
1. Állítsa be az alakzat `rotation` tulajdonságát a kívánt szögre.
1. Mentse a prezentációt.

```python
import aspose.slides as slides

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt reprezentál.
with slides.Presentation() as presentation:

    # Szerezze meg az első diát.
    slide = presentation.slides[0]

    # Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Forgassa el az alakzatot 5 fokkal.
    shape.rotation = 5

    # Mentse a PPTX fájlt a lemezre.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az alakzat forgatása](shape-rotation.png)

## **3D lekerekítési hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D lekerekítési (bevel) hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/) beállításainak konfigurálásával.

3D lekerekítési hatások hozzáadásához egy alakzathoz kövesse ezt:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diahoz.
1. Konfigurálja az alakzat [ThreeDFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/) tulajdonságait a lekerekítési beállítások meghatározásához.
1. Mentse a prezentációt.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Hozzon létre egy példányt a Presentation osztályból.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Adjunk hozzá egy alakzatot a diához.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Állítsa be az alakzat ThreeDFormat tulajdonságait.
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

![A 3D lekerekítési hatás](3D-bevel-effect.png)

## **3D forgatási hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D forgatási hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/) beállításainak konfigurálásával.

3D forgatás alkalmazásához egy alakzaton:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diahoz.
1. Állítsa be az alakzat [camera_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/camera/camera_type/) és [light_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/lightrig/light_type/) értékeit a 3D forgatás meghatározásához.
1. Mentse a prezentációt.

```python
import aspose.slides as slides

# Hozzon létre egy példányt a Presentation osztályból.
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

## **Formázás visszaállítása**

Az alábbi Python‑kód megmutatja, hogyan állítható vissza egy dia formázása, és hogyan állíthatók vissza a helyzet, méret és a helyőrzőkkel rendelkező összes alakzat formázása a [LayoutSlide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/)‑on az alapértelmezett beállításokra:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Állítsa vissza a dián lévő minden alakzatot, amelynek a layouton helyőrzője van.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**A alakzatok formázása befolyásolja a végleges prezentáció fájlméretét?**

Csak minimálisan. A beágyazott képek és média fájlok foglalják a legtöbb helyet, míg az alakzatparaméterek – színek, hatások, gradiens – metaadatként tárolódnak, és gyakorlatilag nem növelik a fájlméretet.

**Hogyan tudok azonos formázású alakzatokat egy dián felismerni, hogy csoportosíthassam őket?**

Hasonlítsa össze az egyes alakzatok kulcsfontosságú formázási tulajdonságait – kitöltés, vonal és effekt beállítások. Ha minden megfelelő érték megegyezik, tekintse a stílusukat azonosnak, és logikailag csoportosítsa ezeket az alakzatokat, ami megkönnyíti a későbbi stíluskezelést.

**Menthetek egy egyedi alakzatformátum‑készletet egy külön fájlba, hogy más prezentációkban újra felhasználjam?**

Igen. Tárolja a kívánt stílusokkal ellátott mintaalakzatokat egy sablon‑diakönyvtárban vagy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stilizált alakzatokat, és alkalmazza újra a formázásukat a kívánt helyeken.