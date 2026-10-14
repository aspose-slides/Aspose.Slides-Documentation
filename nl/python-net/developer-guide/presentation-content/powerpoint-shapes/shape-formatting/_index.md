---
title: PowerPoint-vormen opmaken in Python
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/python-net/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schetseffect
- schetsvormlijn
- verbindingstijl opmaken
- verloopvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- zwart-wit vormweergave
- grijstintvormweergave
- vorm roteren
- 3D-afschuiningseffect
- 3D-rotatie-effect
- opmaak resetten
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u PowerPoint-vormen kunt opmaken in Python met Aspose.Slides—stel vullings-, lijn- en effectstijlen in voor PPT-, PPTX- en ODP-bestanden met precisie en volledige controle."
---
## **Inleiding**

In PowerPoint kun je vormen aan dia's toevoegen. Aangezien vormen uit lijnen bestaan, kun je ze opmaken door de contouren aan te passen of er effecten op toe te passen. Daarnaast kun je vormen opmaken door instellingen te specificeren die bepalen hoe hun binnenkant wordt gevuld.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python biedt klassen en eigenschappen waarmee je vormen kunt opmaken met dezelfde opties als in PowerPoint.

## **Lijnen opmaken**

Met Aspose.Slides kun je een aangepaste lijstijl voor een vorm specificeren. De volgende stappen schetsen de procedure:

1. Maak een exemplaar van de [Presentatie](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse aan.  
1. Verkrijg een referentie naar een dia op basis van de index.  
1. Voeg een [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) toe aan de dia.  
1. Stel de [lijnstijl](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) van de vorm in.  
1. Stel de lijndikte in.  
1. Stel de [streepstijl](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) van de vorm in.  
1. Stel de lijnkleur van de vorm in.  
1. Sla de aangepaste presentatie op als PPTX‑bestand.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een auto-vorm van het type Rectangle toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Verwijder de vulling van de rechthoekvorm zodat alleen de lijnen zichtbaar zijn.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Pas opmaak toe op de lijnen van de rechthoek.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Stel de kleur in voor de lijn van de rechthoek.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Sla het PPTX-bestand op schijf.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De opgemaakte lijnen in de presentatie](formatted-lines.png)

## **Schets‑effecten toepassen op vormlijnen**

Een schets‑effect maakt een vormlijn handgetekend. Gebruik [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) om de lijneigenschappen te benaderen, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) om de schetseigenschappen te benaderen, en [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) om een waarde uit de [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/)‑enumeratie te selecteren.

De volgende Python‑code toont hoe een [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) effect toe te passen, de expliciet toegewezen waarde te lezen en het effect te verwijderen met [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Toegang tot het lijnformaat van de vorm en het schetsformaat.
    sketch_format = shape.line_format.sketch_format

    # Pas een schetseffect toe.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Lees het schetseffect dat rechtstreeks aan de vorm is toegewezen.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Verwijder het schetseffect.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

De waarde die door `SketchFormat.sketch_type` wordt geretourneerd, vertegenwoordigt de instelling die rechtstreeks aan de vorm is toegewezen. Als de lijnafwerking kan worden geërfd van een thema, masterslide of lay‑outsdia, gebruik dan [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/), benader de `sketch_format`‑eigenschap van het geretourneerde object en lees de `sketch_type`‑eigenschap. De effectieve waarde weerspiegelt de opmaak die daadwerkelijk wordt toegepast nadat erfelijkheid is opgelost:

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

## **Opmaak van verbindingsstijlen**

Hier zijn de drie opties voor verbindings‑type:

* Round  
* Miter  
* Bevel  

Standaard gebruikt PowerPoint, wanneer twee lijnen onder een hoek worden verbonden (bijvoorbeeld op een hoek van een vorm), de **Round**‑instelling. Als je echter een vorm met scherpe hoeken tekent, kun je de **Miter**‑optie verkiezen.

![De verbindingsstijl in de presentatie](join-style-powerpoint.png)

De volgende Python‑code toont hoe drie rechthoeken (zoals weergegeven op de afbeelding hierboven) zijn gemaakt met de Miter‑, Bevel‑ en Round‑instellingen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

	# Haal de eerste dia op.
	slide = presentation.slides[0]

	# Voeg drie auto-vormen van het type Rectangle toe.
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

	# Stel de verbindingsstijl in.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Voeg tekst toe aan elke rechthoek.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Sla het PPTX-bestand op schijf.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Verloopvulling**

In PowerPoint is Verloopvulling een opmaakoptie die je toelaat een continue kleurovergang op een vorm toe te passen. Bijvoorbeeld, je kunt twee of meer kleuren gebruiken zodat de ene geleidelijk in de andere overloopt.

Zo pas je een verloopvulling toe op een vorm met Aspose.Slides:

1. Maak een exemplaar van de [Presentatie](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse aan.  
1. Verkrijg een referentie naar een dia op basis van de index.  
1. Voeg een [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) toe aan de dia.  
1. Stel de [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) van de vorm in op `GRADIENT`.  
1. Voeg je twee gewenste kleuren toe met gedefinieerde posities via de `add`‑methoden van de `gradient_stops`‑collectie die wordt blootgesteld door de [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/) klasse.  
1. Sla de aangepaste presentatie op als PPTX‑bestand.

```python
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een auto-vorm van het type Ellipse toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Pas een verloopopmaak toe op de ellips.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Stel de richting van het verloop in.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Voeg twee verloopstops toe.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Sla het PPTX-bestand op schijf.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De ellips met verloopvulling](gradient-fill.png)

Als een verloop er anders uitziet in een geëxporteerde afbeelding dan in PowerPoint, zie dan [Choose a Gradient Rendering Style](/slides/nl/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Je kunt een weergavestijl kiezen zonder de opgeslagen verloopvulling in de presentatie te wijzigen.

## **Patroonvulling**

In PowerPoint is Patroonvulling een opmaakoptie waarmee je een tweekleurig ontwerp—zoals stippen, strepen, kruisende lijnen of geruite patronen—op een vorm kunt toepassen. Je kunt zelf kleuren kiezen voor de voor‑ en achtergrond van het patroon.

Aspose.Slides biedt meer dan 45 vooraf gedefinieerde patroonstijlen die je op vormen kunt toepassen om de visuele aantrekkingskracht van je presentaties te verhogen. Zelfs nadat je een vooraf gedefinieerd patroon hebt gekozen, kun je de exacte kleuren die het moet gebruiken nog steeds specificeren.

Zo pas je een patroonvulling toe op een vorm met Aspose.Slides:

1. Maak een exemplaar van de [Presentatie](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse aan.  
1. Verkrijg een referentie naar een dia op basis van de index.  
1. Voeg een [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) toe aan de dia.  
1. Stel de [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) van de vorm in op `PATTERN`.  
1. Kies een patroonstijl uit de vooraf gedefinieerde opties.  
1. Stel de [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) van het patroon in.  
1. Stel de [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) van het patroon in.  
1. Sla de aangepaste presentatie op als PPTX‑bestand.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een auto-vorm van het type Rectangle toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Stel het vullertype in op Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Stel de patroonstijl in.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Stel de patroonachtergrond- en -voorgrondkleuren in.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Sla het PPTX-bestand op schijf.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De rechthoek met patroonvulling](pattern-fill.png)

## **Afbeeldingsvulling**

In PowerPoint is Afbeeldingsvulling een opmaakoptie die je toelaat een afbeelding binnen een vorm te plaatsen—effectief de afbeelding te gebruiken als achtergrond van de vorm.

Zo gebruik je Aspose.Slides om een afbeeldingvulling toe te passen op een vorm:

1. Maak een exemplaar van de [Presentatie](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse aan.  
1. Verkrijg een referentie naar een dia op basis van de index.  
1. Voeg een [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) toe aan de dia.  
1. Stel de [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) van de vorm in op `PICTURE`.  
1. Stel de afbeeldingsvullingsmodus in op `TILE` (of een andere gewenste modus).  
1. Maak een [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) object van de afbeelding die je wilt gebruiken.  
1. Ken deze afbeelding toe aan de `picture.image`‑eigenschap van de `picture_fill_format` van de vorm.  
1. Sla de aangepaste presentatie op als PPTX‑bestand.

![De lotus‑afbeelding](lotus.png)

```python
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een auto-vorm van het type Rectangle toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Stel het vullertype in op Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Stel de afbeeldingsvullingsmodus in.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Laad een afbeelding en voeg die toe aan de presentatie-bronnen.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Stel de afbeelding in.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Sla het PPTX-bestand op schijf.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De vorm met afbeeldingsvulling](picture-fill.png)

### **Afbeelding tegel als textuur**

Als je een getegelde afbeelding als textuur wilt instellen en het tegelgedrag wilt aanpassen, kun je de volgende eigenschappen van de [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) klasse gebruiken:

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Stelt de afbeeldingsvullingsmodus in—`TILE` of `STRETCH`.  
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): Bepaalt de uitlijning van de tegels binnen de vorm.  
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): Regelt of de tegel horizontaal, verticaal of beide keren wordt gedraaid.  
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): Stelt de horizontale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.  
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): Stelt de verticale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.  
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): Definieert de horizontale schaal van de tegel als percentage.  
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): Definieert de verticale schaal van de tegel als percentage.

```py
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    first_slide = presentation.slides[0]

    # Voeg een rechthoekige auto-vorm toe.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Stel het vullertype van de vorm in op Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Laad de afbeelding en voeg deze toe aan de presentatie-bronnen.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Wijs de afbeelding toe aan de vorm.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Configureer de afbeeldingsvullingsmodus en tegel-eigenschappen.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Sla het PPTX-bestand op schijf.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De tegelopties](tile-options.png)

## **Effen kleurvulling**

In PowerPoint is Effen kleurvulling een opmaakoptie die een vorm vult met één enkele, uniforme kleur. Deze eenvoudige achtergrondkleur wordt toegepast zonder verloop, textuur of patroon.

Om een effen kleurvulling op een vorm toe te passen met Aspose.Slides, volg je deze stappen:

1. Maak een exemplaar van de [Presentatie](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse aan.  
1. Verkrijg een referentie naar een dia op basis van de index.  
1. Voeg een [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) toe aan de dia.  
1. Stel de [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) van de vorm in op `SOLID`.  
1. Wijs je gewenste vullingskleur toe aan de vorm.  
1. Sla de aangepaste presentatie op als PPTX‑bestand.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een auto-vorm van het type Rectangle toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Stel het vullertype in op Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Stel de vulkleur in.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Sla het PPTX-bestand op schijf.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De vorm met effen kleurvulling](solid-color-fill.png)

## **Transparantie instellen**

In PowerPoint kun je, wanneer je een effen kleur, verloop, afbeelding of textuurvulling op vormen toepast, ook een transparantieniveau instellen om de doorzichtigheid van de vulling te regelen. Een hogere transparantiewaarde maakt de vorm meer doorschijnend, waardoor de achtergrond of onderliggende objecten deels zichtbaar worden.

Aspose.Slides laat je het transparantieniveau instellen door de alfa‑waarde in de kleur die voor de vulling wordt gebruikt aan te passen. Zo doe je dat:

1. Maak een exemplaar van de [Presentatie](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse aan.  
1. Verkrijg een referentie naar een dia op basis van de index.  
1. Voeg een [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) toe aan de dia.  
1. Stel de vulling in op `SOLID`.  
1. Gebruik `Color.from_argb` om een kleur met transparantie te definiëren (de `alpha`‑component regelt de transparantie).  
1. Sla de presentatie op.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]
    
    # Voeg een solide rechthoekige auto-vorm toe.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Voeg een transparante rechthoekige auto-vorm toe bovenop de solide vorm.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De transparante vorm](shape-transparency.png)

## **Vormen roteren**

Aspose.Slides laat je vormen roteren in PowerPoint‑presentaties. Dit kan handig zijn bij het positioneren van visuele elementen met specifieke uitlijning of ontwerpeisen.

Om een vorm op een dia te roteren, volg je deze stappen:

1. Maak een exemplaar van de [Presentatie](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse aan.  
1. Verkrijg een referentie naar een dia op basis van de index.  
1. Voeg een [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) toe aan de dia.  
1. Stel de `rotation`‑eigenschap van de vorm in op de gewenste hoek.  
1. Sla de presentatie op.

```python
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een auto-vorm van het type Rectangle toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Roteer de vorm met 5 graden.
    shape.rotation = 5

    # Sla het PPTX-bestand op schijf.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De vormrotatie](shape-rotation.png)

## **3D-afschuiningseffecten toevoegen**

Aspose.Slides stelt je in staat 3D‑afschuiningseffecten op vormen toe te passen door de eigenschappen van hun [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) te configureren.

Om 3D‑afschuiningseffecten aan een vorm toe te voegen, volg je deze stappen:

1. Instantieer de [Presentatie](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse.  
1. Verkrijg een referentie naar een dia op basis van de index.  
1. Voeg een [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) toe aan de dia.  
1. Configureer de [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) van de vorm om afschuining in te stellen.  
1. Sla de presentatie op.

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

    # Sla de presentatie op als PPTX‑bestand.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![Het 3D-afschuiningseffect](3D-bevel-effect.png)

## **3D-rotatieeffecten toevoegen**

Aspose.Slides laat je 3D‑rotatie‑effecten op vormen toepassen door de eigenschappen van hun [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) te configureren.

Om een 3D‑rotatie op een vorm toe te passen:

1. Maak een exemplaar van de [Presentatie](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse aan.  
1. Verkrijg een referentie naar een dia op basis van de index.  
1. Voeg een [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) toe aan de dia.  
1. Stel het [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) en [light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) van de vorm in om de 3D‑rotatie te definiëren.  
1. Sla de presentatie op.

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

    # Sla de presentatie op als PPTX‑bestand.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![Het 3D-rotatie‑effect](3D-rotation-effect.png)

## **Zwart-witweergave voor vormen beheren**

De eigenschap [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) geeft aan hoe een individuele vorm wordt weergegeven wanneer een presentatie wordt bekeken of verwerkt in zwart-witmodus. Het activeert niet zelf een zwart‑witweergave en verandert de vulling, lijn of andere opmaak van de vorm niet in de normale kleermodus.

Gebruik een waarde uit de [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/)‑enumeratie om het gewenste gedrag te selecteren. Bijvoorbeeld, `AUTOMATIC` laat de renderapplicatie de conversie kiezen, `GRAY` en `LIGHT_GRAY` gebruiken grijstinten, `BLACK_WHITE` gebruikt uitsluitend zwart en wit, `BLACK` en `WHITE` forceren één kleur, `COLOR` behoudt de normale kleuren, en `HIDDEN` laat de vorm weg in zwart‑witmodus. `NOT_DEFINED` betekent dat er geen vorm‑specifieke modus is toegewezen.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # Houd de oranje vulling in kleurmodus, maar render de vorm met grijze kleur in zwart-witmodus.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

In de normale kleermodus behoudt de rechthoek zijn oranje vulling. In een zwart‑wit weergave‑workflow wordt grijstint gebruikt omdat de modus is ingesteld op `GRAY`. Dit maakt het mogelijk een volledige‑kleur dia te behouden terwijl je een aparte weergave voor afdrukken, voorbeeld of andere workflows definieert die de zwart‑witinstellingen van de presentatie respecteren.

## **Opmaak resetten**

De volgende Python‑code toont hoe je de opmaak van een dia kunt resetten en de positie, grootte en opmaak van alle vormen met placeholders op de [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) terugzet naar de standaardinstellingen:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Reset elke vorm op de dia die een placeholder heeft op de lay-out.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Heeft het opmaken van vormen invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Alleen minimaal. Ingebedde afbeeldingen en media nemen het grootste deel van de bestandsgrootte in beslag, terwijl vormparameters zoals kleuren, effecten en verlopen als metadata worden opgeslagen en vrijwel geen extra grootte toevoegen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak hebben zodat ik ze kan groeperen?**

Vergelijk de sleuteleigenschappen van de opmaak van elke vorm—vulling, lijn en effectinstellingen. Als alle overeenkomende waarden gelijk zijn, behandel je hun stijlen als identiek en groepeer je die vormen logisch, wat later stijlbeheer vereenvoudigt.

**Kan ik een set aangepaste vormstijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Sla voorbeeldvormen met de gewenste stijlen op in een sjabloondia‑set of een .POTX‑sjabloonbestand. Bij het maken van een nieuwe presentatie open je het sjabloon, kloont je de gestileerde vormen die je nodig hebt, en pas je hun opmaak opnieuw toe waar nodig.