---
title: Vormgeving van PowerPoint-vormen in Python
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/python-net/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schets-effect
- schetslijn van vorm
- stijl van verbindingen opmaken
- verloopvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- vorm roteren
- 3D-schuineffect
- 3D-rotatie-effect
- opmaak opnieuw instellen
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe je PowerPoint-vormen kunt opmaken in Python met Aspose.Slides—stel vul-, lijn- en effectstijlen in voor PPT-, PPTX- en ODP-bestanden met precisie en volledige controle."
---
## **Introductie**

In PowerPoint kun je vormen aan dia’s toevoegen. Omdat vormen uit lijnen bestaan, kun je ze opmaken door de omlijning te wijzigen of effecten toe te passen. Daarnaast kun je vormen opmaken door instellingen te specificeren die bepalen hoe hun binnenkant wordt gevuld.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python biedt klassen en eigenschappen die het mogelijk maken om vormen op te maken met dezelfde opties die beschikbaar zijn in PowerPoint.

## **Lijnen opmaken**

Met Aspose.Slides kun je een aangepaste lijnstijl voor een vorm opgeven. De volgende stappen beschrijven de werkwijze:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [line style](https://reference.aspose.com/slides/nl/python-net/aspose.slides/linestyle/) van de vorm in.
1. Stel de lijndikte in.
1. Stel de [dash style](https://reference.aspose.com/slides/nl/python-net/aspose.slides/linedashstyle/) van de vorm in.
1. Stel de lijnkleur van de vorm in.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

De volgende Python‑code laat zien hoe je een rechthoekige `AutoShape` kunt opmaken:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantieer de Presentation‑klasse die een presentatiebestand representeert.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een autoshape van het type Rectangle toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Stel de vulkleur in voor de rechthoekige vorm.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Pas de opmaak toe op de lijnen van de rechthoek.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Stel de kleur in voor de lijn van de rechthoek.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Sla het PPTX‑bestand op naar schijf.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Resultaat:

![The formatted lines in the presentation](formatted-lines.png)

## **Schets‑effecten toepassen op vlaklijnen**

Een schets‑effect laat een vormlijn eruitzien alsof hij met de hand is getekend. Gebruik [Shape.line_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/line_format/) om de lijnafspraken te benaderen, [LineFormat.sketch_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/lineformat/sketch_format/) om de schetseigenschappen te benaderen, en [SketchFormat.sketch_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sketchformat/sketch_type/) om een waarde uit de enumeratie [LineSketchType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/linesketchtype/) te selecteren.

De volgende Python‑code toont hoe je een [LineSketchType.CURVED](https://reference.aspose.com/slides/nl/python-net/aspose.slides/linesketchtype/)‑effect toepast, de expliciet toegewezen waarde uitleest en het effect verwijdert met [LineSketchType.NONE](https://reference.aspose.com/slides/nl/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Toegang tot het lijnformaat van de vorm en het schetsformaat.
    sketch_format = shape.line_format.sketch_format

    # Een schets‑effect toepassen.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Lees het schets‑effect dat rechtstreeks aan de vorm is toegewezen.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Verwijder het schets‑effect.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

De waarde die door `SketchFormat.sketch_type` wordt geretourneerd, vertegenwoordigt de instelling die rechtstreeks aan de vorm is toegewezen. Als de lijnopmaak kan worden geërfd van een thema, masterslide of lay‑outslide, gebruik dan [LineFormat.get_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides/lineformat/get_effective/), benader de `sketch_format`‑eigenschap van het geretourneerde object en lees de `sketch_type`‑eigenschap. De effectieve waarde weerspiegelt de opmaak die daadwerkelijk wordt toegepast nadat de erfenis is opgelost:

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

## **Opmaken van verbindingstype**

Hier zijn de drie opties voor verbindings­type:

* Round
* Miter
* Bevel

Standaard gebruikt PowerPoint **Round** wanneer twee lijnen onder een hoek (bijvoorbeeld bij een hoek van een vorm) worden samengevoegd. Als je echter een vorm met scherpe hoeken tekent, kun je de voorkeur geven aan **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

De volgende Python‑code laat zien hoe drie rechthoeken (zoals in de bovenstaande afbeelding) zijn gemaakt met de verbindings­type‑instellingen Miter, Bevel en Round:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantieer de Presentation-klasse die een presentatiebestand representeert.
with slides.Presentation() as presentation:

	# Haal de eerste dia op.
	slide = presentation.slides[0]

	# Voeg drie autoshapes van het type Rectangle toe.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Stel de vulkleur in voor elke rechthoekige vorm.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Stel de lijndikte in.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Stel de kleur in voor de lijn van elke rechthoek.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Stel de verbindingsstijl in.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Voeg tekst toe aan elke rechthoek.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Sla het PPTX-bestand op naar schijf.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Verloopvulling**

In PowerPoint is Verloopvulling een opmaakoptie waarmee je een geleidelijke mengeling van kleuren op een vorm kunt toepassen. Je kunt bijvoorbeeld twee of meer kleuren gebruiken zodat de ene geleidelijk in de andere overloopt.

Zo pas je een verloopvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/) van de vorm in op `GRADIENT`.
1. Voeg je twee voorkeurs­kleuren met gedefinieerde posities toe via de `add`‑methoden van de `gradient_stops`‑collectie die wordt blootgesteld door de [GradientFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/gradientformat/)‑klasse.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

De volgende Python‑code toont hoe je een verloopvulling op een ellips toepast:

```python
import aspose.slides as slides

# Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een autoshape van het type Ellipse toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Pas een verloopopmaak toe op de ellips.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Stel de richting van het verloop in.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Voeg twee verloopstops toe.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Sla het PPTX-bestand op naar schijf.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Resultaat:

![The ellipse with gradient fill](gradient-fill.png)

## **Patroonvulling**

In PowerPoint is Patroonvulling een opmaakoptie waarmee je een tweekleurig ontwerp—zoals stippen, strepen, kruislijnen of ruiten—op een vorm kunt toepassen. Je kunt aangepaste kleuren kiezen voor de voorgrond en de achtergrond van het patroon.

Aspose.Slides biedt meer dan 45 voorgedefinieerde patroonstijlen die je op vormen kunt toepassen om de visuele aantrekkingskracht van je presentaties te verhogen. Zelfs na het kiezen van een voorgedefinieerd patroon kun je de exacte kleuren specificeren die moeten worden gebruikt.

Zo pas je een patroonvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/) van de vorm in op `PATTERN`.
1. Kies een patroonstijl uit de voorgedefinieerde opties.
1. Stel de [back_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides/patternformat/back_color/) van het patroon in.
1. Stel de [fore_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides/patternformat/fore_color/) van het patroon in.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

De volgende Python‑code laat zien hoe je een patroonvulling op een rechthoek toepast:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een autoshape van het type Rectangle toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Stel het vultype in op Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Stel de patroonstijl in.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Stel de achtergrond- en voorgrondkleuren van het patroon in.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Sla het PPTX-bestand op naar schijf.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Resultaat:

![The rectangle with pattern fill](pattern-fill.png)

## **Afbeeldingsvulling**

In PowerPoint is Afbeeldingsvulling een opmaakoptie waarmee je een afbeelding in een vorm kunt opnemen—effectief de afbeelding als achtergrond van de vorm gebruiken.

Zo gebruik je Aspose.Slides om een afbeeldingvulling op een vorm toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/) van de vorm in op `PICTURE`.
1. Stel de afbeeldingsvullingsmodus in op `TILE` (of een andere gewenste modus).
1. Maak een [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/)‑object aan van de afbeelding die je wilt gebruiken.
1. Wijs deze afbeelding toe aan de `picture.image`‑eigenschap van de `picture_fill_format` van de vorm.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

Stel dat we een bestand “lotus.png” hebben met de volgende afbeelding:

![The lotus picture](lotus.png)

De volgende Python‑code toont hoe je een vorm met een afbeeldingvulling vult:

```python
import aspose.slides as slides

# Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een autoshape van het type Rectangle toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Stel het vultype in op Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Stel de afbeeldingvullingsmodus in.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Laad een afbeelding en voeg deze toe aan de presentatie-resources.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Stel de afbeelding in.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Sla het PPTX-bestand op naar schijf.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Resultaat:

![The shape with picture fill](picture-fill.png)

### **Afbeelding als tegeltextuur**

Wil je een getegelde afbeelding als textuur instellen en het tegelgedrag aanpassen, gebruik dan de volgende eigenschappen van de [PictureFillFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/)‑klasse:

- [picture_fill_mode](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Stelt de afbeeldingsvullingsmodus in—`TILE` of `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/tile_alignment/): Bepaalt de uitlijning van de tegels binnen de vorm.
- [tile_flip](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/tile_flip/): Bepaalt of de tegel horizontaal, verticaal of beide keren wordt gespiegeld.
- [tile_offset_x](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/tile_offset_x/): Stelt de horizontale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [tile_offset_y](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/tile_offset_y/): Stelt de verticale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [tile_scale_x](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/tile_scale_x/): Definieert de horizontale schaal van de tegel als een percentage.
- [tile_scale_y](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/tile_scale_y/): Definieert de verticale schaal van de tegel als een percentage.

De volgende code‑voorbeeld laat zien hoe je een rechthoekige vorm met een getegelde afbeeldingvulling toevoegt en de tegelopties configureert:

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    first_slide = presentation.slides[0]

    # Voeg een rechthoekige autoshape toe.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Stel het vultype van de vorm in op Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Laad de afbeelding en voeg deze toe aan de presentatie-resources.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Wijs de afbeelding toe aan de vorm.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Configureer de afbeeldingvullingsmodus en tegel-eigenschappen.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Sla het PPTX-bestand op naar schijf.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Resultaat:

![The tile options](tile-options.png)

## **Effen kleurvulling**

In PowerPoint is Effen kleurvulling een opmaakoptie die een vorm vult met één uniforme kleur. Deze egale achtergrondkleur wordt toegepast zonder verloop, textuur of patroon.

Volg deze stappen om een effen kleurvulling op een vorm toe te passen met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/) van de vorm in op `SOLID`.
1. Ken de gewenste vulkleur toe aan de vorm.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

De volgende Python‑code toont hoe je een effen kleurvulling op een rechthoek in een PowerPoint‑dia toepast:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een autoshape van het type Rectangle toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Stel het vultype in op Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Stel de vulkleur in.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Sla het PPTX-bestand op naar schijf.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Resultaat:

![The shape with solid color fill](solid-color-fill.png)

## **Transparantie instellen**

In PowerPoint kun je bij een effen kleur, verloop, afbeelding of textuur vulling voor vormen ook een transparantieniveau instellen om de dekking van de vulling te regelen. Een hogere transparantiewaarde maakt de vorm meer doorschijnend, zodat de achtergrond of onderliggende objecten gedeeltelijk zichtbaar worden.

Aspose.Slides maakt het mogelijk om het transparantieniveau in te stellen door de alfa‑waarde van de kleur die voor de vulling wordt gebruikt aan te passen. Zo doe je dat:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
1. Stel de vullingstype in op `SOLID`.
1. Gebruik `Color.from_argb` om een kleur met transparantie te definiëren (de `alpha`‑component bepaalt de transparantie).
1. Sla de presentatie op.

De volgende Python‑code toont hoe je een transparante vulkleur op een rechthoek toepast:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]
    
    # Voeg een solide rechthoekige autoshape toe.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Voeg een doorzichtige rechthoekige autoshape toe boven de solide vorm.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Resultaat:

![The transparent shape](shape-transparency.png)

## **Vormen roteren**

Aspose.Slides maakt het mogelijk om vormen in PowerPoint‑presentaties te roteren. Dit kan handig zijn bij het positioneren van visuele elementen met specifieke uitlijning‑ of ontwerpbehoeften.

Volg deze stappen om een vorm op een dia te roteren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
1. Stel de `rotation`‑eigenschap van de vorm in op de gewenste hoek.
1. Sla de presentatie op.

De volgende Python‑code rotert een vorm met 5 graden:

```python
import aspose.slides as slides

# Instantieer de Presentation-klasse die een presentatiebestand representeert.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een autoshape van het type Rectangle toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Roteer de vorm met 5 graden.
    shape.rotation = 5

    # Sla het PPTX-bestand op naar schijf.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Resultaat:

![The shape rotation](shape-rotation.png)

## **3D‑schuineffekte toevoegen**

Aspose.Slides stelt je in staat om 3D‑schuineffekten op vormen toe te passen door de [ThreeDFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/)‑eigenschappen te configureren.

Volg deze stappen om 3D‑schuineffekten aan een vorm toe te voegen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
1. Configureer de [ThreeDFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/) van de vorm om de schuine instellingen te definiëren.
1. Sla de presentatie op.

De volgende Python‑code toont hoe je 3D‑schuineffekten op een vorm toepast:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een instantie van de Presentation-klasse.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Voeg een vorm toe aan de dia.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Stel de ThreeDFormat‑eigenschappen van de vorm in.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Sla de presentatie op als een PPTX‑bestand.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Resultaat:

![The 3D bevel effect](3D-bevel-effect.png)

## **3D‑rotatie‑effecten toevoegen**

Aspose.Slides maakt het mogelijk om 3D‑rotatie‑effecten op vormen toe te passen door de [ThreeDFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/)‑eigenschappen te configureren.

Om 3D‑rotatie op een vorm toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [camera_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/camera/camera_type/) en [light_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/lightrig/light_type/) van de vorm in om de 3D‑rotatie te definiëren.
1. Sla de presentatie op.

De volgende Python‑code laat zien hoe je 3D‑rotatie‑effecten op een vorm toepast:

```python
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Sla de presentatie op als een PPTX-bestand.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Resultaat:

![The 3D rotation effect](3D-rotation-effect.png)

## **Opmaak opnieuw instellen**

De volgende Python‑code toont hoe je de opmaak van een dia opnieuw kunt instellen en de positie, grootte en opmaak van alle vormen met placeholders op de [LayoutSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutslide/) terugzet naar de standaardinstellingen:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Reset elke vorm op de dia die een placeholder op de layout heeft.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Heeft de opmaak van vormen invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Alleen minimaal. Ingesloten afbeeldingen en media vormen het grootste deel van de bestandsgrootte, terwijl vormparameters zoals kleuren, effecten en verlopen als metadata worden opgeslagen en vrijwel geen extra ruimte innemen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak hebben, zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm—vulling, lijn en effectinstellingen. Als alle corresponderende waarden overeenkomen, beschouw je de stijlen als identiek en groepeer je die vormen logisch, wat later beheer van stijlen vereenvoudigt.

**Kan ik een set aangepaste vormstijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Sla voorbeeldvormen met de gewenste stijlen op in een sjabloondia‑bestand of een .POTX‑sjabloon. Bij het maken van een nieuwe presentatie open je het sjabloon, kloon je de stijlvormen die je nodig hebt en pas je hun opmaak toe waar nodig.