---
title: PowerPoint-vormen opmaken in Python
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/python-net/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- aansluitstijl opmaken
- verloopvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- vorm draaien
- 3D-schuineffect
- 3D-rotatie-effect
- opmaak resetten
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe je PowerPoint-vormen kunt opmaken in Python met Aspose.Slides—stel vullings-, lijn- en effectstijlen in voor PPT-, PPTX- en ODP-bestanden met precisie en volledige controle."
---
## **Inleiding**

In PowerPoint kun je vormen aan dia’s toevoegen. Omdat vormen bestaan uit lijnen, kun je ze opmaken door de contouren te wijzigen of er effecten op toe te passen. Daarnaast kun je vormen opmaken door instellingen op te geven die bepalen hoe hun binnenkant wordt gevuld.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python biedt klassen en eigenschappen waarmee je vormen kunt opmaken met dezelfde opties die in PowerPoint beschikbaar zijn.

## **Contouren opmaken**

Met Aspose.Slides kun je een aangepaste lijnstijl voor een vorm specificeren. De volgende stappen beschrijven de procedure:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [line style](https://reference.aspose.com/slides/nl/python-net/aspose.slides/linestyle/) van de vorm in.
1. Stel de lijndikte in.
1. Stel de [dash style](https://reference.aspose.com/slides/nl/python-net/aspose.slides/linedashstyle/) van de vorm in.
1. Stel de lijnkleur voor de vorm in.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende Python‑code laat zien hoe je een rechthoek‑`AutoShape` formatteert:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een instantie van de Presentation‑klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een auto‑vorm van het type Rectangle toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Stel de vulkleur in voor de rechthoekvorm.
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

Het resultaat:

![De geformatteerde lijnen in de presentatie](formatted-lines.png)

## **Aansluit‑stijlen opmaken**

Dit zijn de drie opties voor het type aansluiting:

* Round
* Miter
* Bevel

Standaard gebruikt PowerPoint, wanneer twee lijnen onder een hoek (bijvoorbeeld bij een hoek van een vorm) worden samengevoegd, de instelling **Round**. Als je echter een vorm met scherpe hoeken tekent, kun je de optie **Miter** verkiezen.

![De aansluit‑stijl in de presentatie](join-style-powerpoint.png)

De volgende Python‑code laat zien hoe drie rechthoeken (zoals in de afbeelding hierboven) werden aangemaakt met respectievelijk de Miter‑, Bevel‑ en Round‑aansluit‑type‑instellingen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een instantie van de Presentation‑klasse die een presentatiebestand voorstelt.
with slides.Presentation() as presentation:

	# Haal de eerste dia op.
	slide = presentation.slides[0]

	# Voeg drie auto‑vormen van het type Rectangle toe.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Stel de vulkleur in voor elke rechthoekvorm.
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

	# Stel de aansluitstijl in.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Voeg tekst toe aan elke rechthoek.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Sla het PPTX‑bestand op naar schijf.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Verloopvulling**

In PowerPoint is Verloopvulling een opmaakoptie die je toelaat een geleidelijke kleurverloop op een vorm toe te passen. Bijvoorbeeld, je kunt twee of meer kleuren combineren zodat de ene geleidelijk in de andere overloopt.

Zo pas je een verloopvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
1. Stel de vorm‑[FillType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/) in op `GRADIENT`.
1. Voeg je twee gewenste kleuren met gedefinieerde posities toe via de `add`‑methoden van de `gradient_stops`‑collectie die wordt blootgesteld door de [GradientFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/gradientformat/)‑klasse.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende Python‑code toont hoe je een verloopvulling toepast op een ellips:

```python
import aspose.slides as slides

# Maak een instantie van de Presentation‑klasse die een presentatiebestand voorstelt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een auto‑vorm van het type Ellipse toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Pas gradient‑opmaak toe op de ellips.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Stel de richting van de gradient in.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Voeg twee gradientstops toe.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Sla het PPTX‑bestand op naar schijf.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De ellips met verloopvulling](gradient-fill.png)

## **Patroonvulling**

In PowerPoint is Patroonvulling een opmaakoptie die je toelaat een tweekleurig ontwerp—zoals stippen, strepen, kruislings of geruite patronen—op een vorm toe te passen. Je kunt aangepaste kleuren kiezen voor de voor‑ en achtergrond van het patroon.

Aspose.Slides biedt meer dan 45 vooraf gedefinieerde patroonstijlen die je op vormen kunt toepassen om de visuele aantrekkingskracht van je presentaties te verbeteren. Zelfs nadat je een vooraf gedefinieerd patroon hebt gekozen, kun je de exacte kleuren specificeren die gebruikt moeten worden.

Zo pas je een patroonvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
1. Stel de vorm‑[FillType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/) in op `PATTERN`.
1. Kies een patroonstijl uit de vooraf gedefinieerde opties.
1. Stel de [back_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides/patternformat/back_color/) van het patroon in.
1. Stel de [fore_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides/patternformat/fore_color/) van het patroon in.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende Python‑code laat zien hoe je een patroonvulling toepast op een rechthoek:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een instantie van de Presentation‑klasse die een presentatiebestand voorstelt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een auto‑vorm van het type Rectangle toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Stel het vultype in op Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Stel de patroonstijl in.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Stel de patroon‑achtergrond‑ en voorgrondkleuren in.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Sla het PPTX‑bestand op naar schijf.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De rechthoek met patroonvulling](pattern-fill.png)

## **Afbeeldingsvulling**

In PowerPoint is Afbeeldingsvulling een opmaakoptie die je toelaat een afbeelding in een vorm in te voegen—effectief de afbeelding te gebruiken als achtergrond van de vorm.

Zo gebruik je Aspose.Slides om een afbeeldingvulling toe te passen op een vorm:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
1. Stel de vorm‑[FillType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/) in op `PICTURE`.
1. Stel de afbeeldingvullingsmodus in op `TILE` (of een andere gewenste modus).
1. Maak een [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/)‑object aan van de afbeelding die je wilt gebruiken.
1. Wijs deze afbeelding toe aan de `picture.image`‑eigenschap van de `picture_fill_format` van de vorm.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Stel dat we een bestand “lotus.png” hebben met de volgende afbeelding:

![De lotus‑afbeelding](lotus.png)

De volgende Python‑code laat zien hoe je een vorm vult met de afbeelding:

```python
import aspose.slides as slides

# Maak een instantie van de Presentation‑klasse die een presentatiebestand voorstelt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een auto‑vorm van het type Rectangle toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Stel het vultype in op Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Stel de afbeeldingvullingsmodus in.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Laad een afbeelding en voeg deze toe aan de presentatieresources.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Stel de afbeelding in.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Sla het PPTX‑bestand op naar schijf.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De vorm met afbeeldingvulling](picture-fill.png)

### **Afbeelding tegelsen als textuur**

Wil je een getegelde afbeelding als textuur instellen en het tegelgedrag aanpassen, dan kun je de volgende eigenschappen van de [PictureFillFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/)‑klasse gebruiken:

- [picture_fill_mode](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Stelt de afbeeldingvullingsmodus in—`TILE` of `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/tile_alignment/): Bepaalt de uitlijning van de tegels binnen de vorm.
- [tile_flip](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/tile_flip/): Regelt of de tegel horizontaal, verticaal of beide keren wordt gespiegeld.
- [tile_offset_x](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/tile_offset_x/): Stelt de horizontale offset van de tegel (in punten) ten opzichte van de oorsprong van de vorm in.
- [tile_offset_y](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/tile_offset_y/): Stelt de verticale offset van de tegel (in punten) ten opzichte van de oorsprong van de vorm in.
- [tile_scale_x](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/tile_scale_x/): Definieert de horizontale schaal van de tegel als percentage.
- [tile_scale_y](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/tile_scale_y/): Definieert de verticale schaal van de tegel als percentage.

De volgende code‑voorbeeld toont hoe je een rechthoekige vorm met een getegelde afbeeldingvulling toevoegt en de tegelopties configureert:

```py
import aspose.slides as slides

# Maak een instantie van de Presentation‑klasse die een presentatiebestand voorstelt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    first_slide = presentation.slides[0]

    # Voeg een rechthoek‑auto‑vorm toe.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Stel het vultype van de vorm in op Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Laad de afbeelding en voeg deze toe aan de presentatieresources.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Wijs de afbeelding toe aan de vorm.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Configureer de afbeeldingvullingsmodus en tegel‑eigenschappen.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Sla het PPTX‑bestand op naar schijf.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De tegelopties](tile-options.png)

## **Vulling met effen kleur**

In PowerPoint is Vulling met effen kleur een opmaakoptie die een vorm vult met één enkele, uniforme kleur. Deze eenvoudige achtergrondkleur wordt toegepast zonder verlopen, texturen of patronen.

Om een vulling met effen kleur toe te passen op een vorm met Aspose.Slides, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
1. Stel de vorm‑[FillType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/) in op `SOLID`.
1. wijs je gewenste vullingskleur toe aan de vorm.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende Python‑code laat zien hoe je een effen kleurvulling toepast op een rechthoek in een PowerPoint‑dia:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een instantie van de Presentation‑klasse die een presentatiebestand voorstelt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een auto‑vorm van het type Rectangle toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Stel het vultype in op Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Stel de vulkleur in.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Sla het PPTX‑bestand op naar schijf.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De vorm met effen kleurvulling](solid-color-fill.png)

## **Transparantie instellen**

In PowerPoint kun je, wanneer je een effen kleur, verloop, afbeelding of textuur op vormen toepast, ook een transparantieniveau instellen om de opacity van de vulling te regelen. Een hogere transparantiewaarde maakt de vorm meer doorschijnend, waardoor de achtergrond of onderliggende objecten gedeeltelijk zichtbaar worden.

Aspose.Slides laat je het transparantieniveau bepalen door de alfa‑waarde van de kleur die voor de vulling wordt gebruikt aan te passen. Zo doe je dat:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
1. Stel het vullingstype in op `SOLID`.
1. Gebruik `Color.from_argb` om een kleur met transparantie te definiëren (de `alpha`‑component regelt de transparantie).
1. Sla de presentatie op.

De volgende Python‑code toont hoe je een transparante vullingskleur toepast op een rechthoek:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een presentatiebestand voorstelt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]
    
    # Voeg een solide rechthoek-auto-vorm toe.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Voeg een transparante rechthoek-auto-vorm toe boven de solide vorm.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De transparante vorm](shape-transparency.png)

## **Vormen draaien**

Aspose.Slides laat je vormen draaien in PowerPoint‑presentaties. Dit kan handig zijn bij het positioneren van visuele elementen met specifieke uitlijnings‑ of ontwerpbehoeften.

Om een vorm op een dia te draaien, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
1. Stel de eigenschap `rotation` van de vorm in op de gewenste hoek.
1. Sla de presentatie op.

De volgende Python‑code draait een vorm met 5 graden:

```python
import aspose.slides as slides

# Maak een instantie van de Presentation‑klasse die een presentatiebestand voorstelt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een auto‑vorm van het type Rectangle toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Roteer de vorm met 5 graden.
    shape.rotation = 5

    # Sla het PPTX‑bestand op naar schijf.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De vormrotatie](shape-rotation.png)

## **3D‑Schuineffecten toevoegen**

Aspose.Slides maakt het mogelijk om 3D‑schuineffecten op vormen toe te passen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/)‑eigenschappen te configureren.

Om 3D‑schuineffecten toe te voegen aan een vorm, volg je deze stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
1. Configureer de vorm‑[ThreeDFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/) om de schuine‑instellingen te definiëren.
1. Sla de presentatie op.

De volgende Python‑code toont hoe je 3D‑schuineffecten op een vorm toepast:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een instantie van de Presentation‑klasse.
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

Het resultaat:

![Het 3D‑schuineffect](3D-bevel-effect.png)

## **3D‑Rotatie‑effecten toevoegen**

Aspose.Slides maakt het mogelijk om 3D‑rotatie‑effecten op vormen toe te passen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/)‑eigenschappen te configureren.

Om 3D‑rotatie op een vorm toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
1. Stel de vorm‑[camera_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/camera/camera_type/) en [light_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/lightrig/light_type/) in om de 3D‑rotatie te definiëren.
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

Het resultaat:

![Het 3D‑rotatie‑effect](3D-rotation-effect.png)

## **Opmaak resetten**

De volgende Python‑code toont hoe je de opmaak van een dia reset en de positie, grootte en opmaak van alle vormen met placeholders op de [LayoutSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutslide/) terugzet naar de standaardinstellingen:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Reset elke vorm op de dia die een placeholder op de layout heeft.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Heeft vorm‑opmaak invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Alleen minimaal. Ingesloten afbeeldingen en media beslaan het grootste deel van de bestandsgrootte, terwijl vorm‑parameters zoals kleuren, effecten en verlopen als metadata worden opgeslagen en vrijwel geen extra ruimte innemen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak delen, zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm—vulling, lijn en effect‑instellingen. Als alle corresponderende waarden overeenkomen, beschouw je hun stijlen als identiek en groepeer je die vormen logisch, waardoor later beheer van stijlen eenvoudiger wordt.

**Kan ik een set aangepaste vorm‑stijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Bewaar voorbeeldvormen met de gewenste stijlen in een sjabloon‑presentatie of een .POTX‑bestand. Wanneer je een nieuwe presentatie aanmaakt, open je de sjabloon, kloont je de benodigde gestylede vormen en pas je hun opmaak opnieuw toe waar nodig.