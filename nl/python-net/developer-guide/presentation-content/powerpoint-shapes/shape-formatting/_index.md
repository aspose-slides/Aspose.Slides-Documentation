---
title: Opmaak van PowerPoint-vormen in Python
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/python-net/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schets-effect
- schets vormlijn
- knooppuntstijl opmaken
- verloopvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- egene kleurvulling
- vormtransparantie
- zwart-wit vormweergave
- grijstintvormweergave
- vorm roteren
- 3D-schuineffect
- 3D-rotatie-effect
- opmaak resetten
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u PowerPoint-vormen opmaakt in Python met Aspose.Slides—stel vullings-, lijn- en effectstijlen in voor PPT-, PPTX- en ODP‑bestanden met precisie en volledige controle."
---
## **Introductie**

In PowerPoint kun je vormen aan dia's toevoegen. Aangezien vormen uit lijnen bestaan, kun je hun opmaak aanpassen door de lijncontouren te wijzigen of effecten toe te passen. Daarnaast kun je vormen opmaken door instellingen te specificeren die bepalen hoe hun binnengebied wordt gevuld.

![Vorm opmaken in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python biedt klassen en eigenschappen die je toestaan vormen op te maken met dezelfde opties als in PowerPoint.

## **Lijnen opmaken**

Met Aspose.Slides kun je een aangepast lijnstijl voor een vorm specificeren. De volgende stappen beschrijven de procedure:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse aan.
2. Verkrijg een referentie naar een dia op basis van de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
4. Stel de [lijnstijl](https://reference.aspose.com/slides/nl/python-net/aspose.slides/linestyle/) van de vorm in.
5. Stel de lijndikte in.
6. Stel de [dash style](https://reference.aspose.com/slides/nl/python-net/aspose.slides/linedashstyle/) van de vorm in.
7. Stel de lijnkleur voor de vorm in.
8. Sla de aangepaste presentatie op als een PPTX‑bestand.

De volgende Python‑code toont hoe je een rechthoekige `AutoShape` kunt opmaken:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een automatisch vorm van het type Rechthoek toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Verwijder de vulling van de rechthoekvorm zodat alleen de lijnen zichtbaar zijn.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Pas de opmaak toe op de lijnen van de rechthoek.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Stel de kleur in voor de lijn van de rechthoek.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Sla het PPTX-bestand op naar schijf.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De opgemaakte lijnen in de presentatie](formatted-lines.png)

## **Schets‑effecten toepassen op vormlijnen**

Een schets‑effect laat de lijn van een vorm handgetekend lijken. Gebruik [Shape.line_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/line_format/) om de lijninstellingen te benaderen, [LineFormat.sketch_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/lineformat/sketch_format/) om de schetinstellingen te benaderen, en [SketchFormat.sketch_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sketchformat/sketch_type/) om een waarde te selecteren uit de enumeratie [LineSketchType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/linesketchtype/).

De volgende Python‑code toont hoe je een [LineSketchType.CURVED](https://reference.aspose.com/slides/nl/python-net/aspose.slides/linesketchtype/) effect toepast, de expliciet toegewezen waarde uitleest, en het effect verwijdert met [LineSketchType.NONE](https://reference.aspose.com/slides/nl/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Toegang tot het lijnformaat van de vorm en het bijbehorende schetsformaat.
    sketch_format = shape.line_format.sketch_format

    # Pas een schets‑effect toe.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Lees het schets‑effect dat rechtstreeks aan de vorm is toegewezen.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Verwijder het schets‑effect.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

De waarde die wordt geretourneerd door `SketchFormat.sketch_type` vertegenwoordigt de instelling die rechtstreeks op de vorm is toegewezen. Als de lijnopmaak kan worden geërfd van een thema, master‑dia of lay‑outdia, gebruik dan [LineFormat.get_effective](https://reference.aspose.com/slides/nl/python-net/aspose.slides/lineformat/get_effective/), benader de geretourneerde object's `sketch_format`‑eigenschap, en lees zijn `sketch_type`‑eigenschap. De effectieve waarde weerspiegelt de opmaak die daadwerkelijk wordt toegepast nadat de overerving is opgelost:

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

## **Knooppuntstijlen opmaken**

Hier zijn de drie knooppunt‑type‑opties:

* Round
* Miter
* Bevel

Standaard gebruikt PowerPoint bij het samenvoegen van twee lijnen onder een hoek (bijvoorbeeld bij een hoek van een vorm) de instelling **Round**. Als je echter een vorm met scherpe hoeken tekent, kun je de **Miter**‑optie verkiezen.

![De knooppuntstijl in de presentatie](join-style-powerpoint.png)

De volgende Python‑code toont hoe drie rechthoeken (zoals afgebeeld in de afbeelding hierboven) werden gemaakt met de Miter‑, Bevel‑ en Round‑knooppuntinstellingen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

	# Haal de eerste dia op.
	slide = presentation.slides[0]

	# Voeg drie auto-vormen van het type Rechthoek toe.
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

	# Stel de knooppuntstijl in.
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

In PowerPoint is Verloopvulling een opmaakoptie die je toestaat een continue kleurovergang op een vorm toe te passen. Bijvoorbeeld kun je twee of meer kleuren gebruiken zodat de ene geleidelijk in de andere overloopt.

Hieronder vind je hoe je een verloopvulling op een vorm toepast met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse aan.
2. Verkrijg een referentie naar een dia op basis van de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/) van de vorm in op `GRADIENT`.
5. Voeg je twee gewenste kleuren toe met gedefinieerde posities via de `add`‑methoden van de `gradient_stops`‑collectie die wordt blootgesteld door de [GradientFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/gradientformat/) klasse.
6. Sla de aangepaste presentatie op als een PPTX‑bestand.

De volgende Python‑code toont hoe je een verloopvulling op een ellips toepast:

```python
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een auto-vorm van het type Ellips toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Pas verloopopmaak toe op de ellips.
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

Het resultaat:

![De ellips met verloopvulling](gradient-fill.png)

## **Patroonvulling**

In PowerPoint is Patroonvulling een opmaakoptie die je toestaat een tweekleurig ontwerp—zoals stippen, strepen, kruisraster of schaakpatroon—op een vorm toe te passen. Je kunt aangepaste kleuren kiezen voor de voor‑ en achtergrond van het patroon.

Aspose.Slides biedt meer dan 45 vooraf gedefinieerde patroonstijlen die je op vormen kunt toepassen om de visuele aantrekkingskracht van je presentaties te vergroten. Zelfs nadat je een voorgedefinieerd patroon hebt geselecteerd, kun je nog steeds de exacte kleuren opgeven die het moet gebruiken.

Hieronder vind je hoe je een patroonvulling op een vorm toepast met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse aan.
2. Verkrijg een referentie naar een dia op basis van de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/) van de vorm in op `PATTERN`.
5. Kies een patroonstijl uit de vooraf gedefinieerde opties.
6. Stel de [back_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides/patternformat/back_color/) van het patroon in.
7. Stel de [fore_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides/patternformat/fore_color/) van het patroon in.
8. Sla de aangepaste presentatie op als een PPTX‑bestand.

De volgende Python‑code toont hoe je een patroonvulling op een rechthoek toepast:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een auto-vorm van het type Rechthoek toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Stel het vultype in op Patroon.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Stel de patroonstijl in.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Stel de achtergrond- en voorgrondkleuren van het patroon in.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Sla het PPTX-bestand op naar schijf.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De rechthoek met patroonvulling](pattern-fill.png)

## **Afbeeldingsvulling**

In PowerPoint is Afbeeldingsvulling een opmaakoptie die je toestaat een afbeelding in een vorm in te voegen—effectief de afbeelding als achtergrond van de vorm te gebruiken.

Hieronder vind je hoe je een afbeeldingsvulling op een vorm toepast met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse aan.
2. Verkrijg een referentie naar een dia op basis van de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/) van de vorm in op `PICTURE`.
5. Stel de afbeeldingsvullingsmodus in op `TILE` (of een andere gewenste modus).
6. Maak een [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/)‑object aan vanuit de afbeelding die je wilt gebruiken.
7. Ken deze afbeelding toe aan de `picture.image`‑eigenschap van de vorm's `picture_fill_format`.
8. Sla de aangepaste presentatie op als een PPTX‑bestand.

Laten we zeggen dat we een bestand "lotus.png" hebben met de volgende afbeelding:

![De lotusafbeelding](lotus.png)

De volgende Python‑code toont hoe je een vorm met afbeelding vult:

```python
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een auto-vorm van het type Rechthoek toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Stel het vultype in op Afbeelding.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Stel de afbeeldingsvullingsmodus in.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Laad een afbeelding en voeg deze toe aan de presentatieresources.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Stel de afbeelding in.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Sla het PPTX-bestand op naar schijf.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De vorm met afbeeldingsvulling](picture-fill.png)

### **Afbeelding betegelen als textuur**

Als je een getegelde afbeelding als textuur wilt instellen en het tegelgedrag wilt aanpassen, kun je de volgende eigenschappen van de klasse [PictureFillFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/) gebruiken:

- [picture_fill_mode](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Stelt de afbeeldingsvullingsmodus in—`TILE` of `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/tile_alignment/): Bepaalt de uitlijning van de tegels binnen de vorm.
- [tile_flip](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/tile_flip/): Regelt of de tegel horizontaal, verticaal of beide keren wordt gespiegeld.
- [tile_offset_x](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/tile_offset_x/): Stelt de horizontale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [tile_offset_y](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/tile_offset_y/): Stelt de verticale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [tile_scale_x](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/tile_scale_x/): Definieert de horizontale schaal van de tegel als percentage.
- [tile_scale_y](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/tile_scale_y/): Definieert de verticale schaal van de tegel als percentage.

De volgende code geeft een rechthoek met getegelde afbeeldingsvulling weer en configureert de tegelopties:

```py
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    first_slide = presentation.slides[0]

    # Voeg een automatische rechthoek-vorm toe.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Stel het vultype van de vorm in op Afbeelding.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Laad de afbeelding en voeg deze toe aan de presentatieresources.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Koppel de afbeelding aan de vorm.
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

    # Sla het PPTX-bestand op naar schijf.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De tegelopties](tile-options.png)

## **Effen kleurvulling**

In PowerPoint is Effen kleurvulling een opmaakoptie die een vorm vult met één uniforme kleur. Deze egale achtergrondkleur wordt toegepast zonder verloop, texturen of patronen.

Om een egene kleurvulling op een vorm toe te passen met Aspose.Slides, volg deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse aan.
2. Verkrijg een referentie naar een dia op basis van de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
4. Stel de [FillType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/) van de vorm in op `SOLID`.
5. Wijs de gewenste vullingskleur toe aan de vorm.
6. Sla de aangepaste presentatie op als een PPTX‑bestand.

De volgende Python‑code toont hoe je een egene kleurvulling op een rechthoek in een PowerPoint‑dia toepast:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een auto-vorm van het type Rechthoek toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Stel het vultype in op Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Stel de vulkleur in.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Sla het PPTX-bestand op naar schijf.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De vorm met egane kleurvulling](solid-color-fill.png)

## **Transparantie instellen**

In PowerPoint kun je bij het toepassen van een egene kleur, verloop, afbeelding of textuur op een vorm ook een transparantieniveau instellen om de dekking van de vulling te regelen. Een hogere transparantiewaarde maakt de vorm meer doorschijnend, waardoor de achtergrond of onderliggende objecten gedeeltelijk zichtbaar worden.

Aspose.Slides laat je de transparantiewaarde aanpassen door de alfa‑waarde in de gebruikte kleur te wijzigen. Zo doe je dat:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse aan.
2. Verkrijg een referentie naar een dia op basis van de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
4. Stel het vullingstype in op `SOLID`.
5. Gebruik `Color.from_argb` om een kleur met transparantie te definiëren (de `alpha`‑component regelt de transparantie).
6. Sla de presentatie op.

De volgende Python‑code toont hoe je een transparante vullingskleur op een rechthoek toepast:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]
    
    # Voeg een egene rechthoek-auto-vorm toe.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Voeg een transparante rechthoek-auto-vorm toe boven de egene vorm.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De transparante vorm](shape-transparency.png)

## **Vormen roteren**

Aspose.Slides laat je vormen roteren in PowerPoint‑presentaties. Dit kan handig zijn bij het positioneren van visuele elementen met specifieke uitlijning of ontwerpeisen.

Om een vorm op een dia te roteren, volg deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse aan.
2. Verkrijg een referentie naar een dia op basis van de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
4. Stel de `rotation`‑eigenschap van de vorm in op de gewenste hoek.
5. Sla de presentatie op.

De volgende Python‑code toont hoe je een vorm met 5 graden roteert:

```python
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een auto-vorm van het type Rechthoek toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Roteer de vorm met 5 graden.
    shape.rotation = 5

    # Sla het PPTX-bestand op naar schijf.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De vormrotatie](shape-rotation.png)

## **3D‑schuineffecten toevoegen**

Aspose.Slides laat je 3D‑schuineffecten op vormen toepassen door de [ThreeDFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/)‑eigenschappen te configureren.

Om 3D‑schuineffecten aan een vorm toe te voegen, volg deze stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
2. Verkrijg een referentie naar een dia op basis van de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
4. Configureer de [ThreeDFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/) van de vorm om de schuineffecten te definiëren.
5. Sla de presentatie op.

De volgende Python‑code toont hoe je 3D‑schuineffecten op een vorm toepast:

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

    # Stel de ThreeDFormat-eigenschappen van de vorm in.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Sla de presentatie op als een PPTX-bestand.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![Het 3D‑schuineffect](3D-bevel-effect.png)

## **3D‑rotatie‑effecten toevoegen**

Aspose.Slides laat je 3D‑rotatie‑effecten op vormen toepassen door de [ThreeDFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/)‑eigenschappen te configureren.

Om 3D‑rotatie op een vorm toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
2. Verkrijg een referentie naar een dia op basis van de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe aan de dia.
4. Stel het [camera_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/camera/camera_type/) en [light_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/lightrig/light_type/) van de vorm in om de 3D‑rotatie te definiëren.
5. Sla de presentatie op.

De volgende Python‑code toont hoe je 3D‑rotatie‑effecten op een vorm toepast:

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

## **Zwart‑wit weergave voor vormen beheren**

De eigenschap [Shape.black_white_mode](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/black_white_mode/) specificeert hoe een individuele vorm wordt weergegeven wanneer een presentatie wordt bekeken of verwerkt in zwart‑wit modus. Het activeert niet automatisch zwart‑wit weergave en verandert de vulling, lijn of andere opmaak van de vorm niet in de normale kleurmodus.

Gebruik een waarde uit de enumeratie [BlackWhiteMode](https://reference.aspose.com/slides/nl/python-net/aspose.slides/blackwhitemode/) om het gewenste gedrag te selecteren. Bijvoorbeeld, `AUTOMATIC` laat de weergave‑applicatie de conversie kiezen, `GRAY` en `LIGHT_GRAY` gebruiken grijstinten, `BLACK_WHITE` gebruikt uitsluitend zwart en wit, `BLACK` en `WHITE` forceren één kleur, `COLOR` behoudt normale kleur, en `HIDDEN` laat de vorm weg in zwart‑wit modus. `NOT_DEFINED` betekent dat er geen vorm‑specifieke modus is toegewezen.

De volgende Python‑code maakt een gekleurde vorm en laat deze grijs verschijnen in zwart‑wit weergavemodus:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # Houd de oranje vulling in kleurmodus, maar render de vorm met grijze kleur in zwart-wit modus.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

In de normale kleurmodus behoudt de rechthoek zijn oranje vulling. In een zwart‑wit weergave‑workflow wordt grijze kleur gebruikt omdat de modus is ingesteld op `GRAY`. Dit stelt je in staat een volledige‑kleur dia te behouden terwijl je een aparte weergave definieert voor afdrukken, voorvertonen of andere workflows die de zwart‑wit weergave‑instellingen van de presentatie respecteren.

## **Opmaak resetten**

De volgende Python‑code toont hoe je de opmaak van een dia reset en de positie, grootte en opmaak van alle vormen met tijdelijke aanduidingen op de [LayoutSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutslide/) terugzet naar hun standaardinstellingen:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Reset elke vorm op de dia die een placeholder op de lay-out heeft.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Veelgestelde vragen**

**Beïnvloedt het opmaken van vormen de uiteindelijke bestandsgrootte van de presentatie?**

Alleen minimaal. Ingebedde afbeeldingen en media nemen het grootste deel van de bestandsgrootte in beslag, terwijl vormparameters zoals kleuren, effecten en vervagingen als metadata worden opgeslagen en vrijwel geen extra ruimte toevoegen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak delen zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm—vulling, lijn en effectinstellingen. Als alle overeenkomstige waarden gelijk zijn, beschouw je de stijlen als identiek en groepeer je logisch die vormen, wat later het beheer van stijlen vereenvoudigt.

**Kan ik een set aangepaste vormstijlen opslaan in een apart bestand om ze in andere presentaties te hergebruiken?**

Ja. Sla voorbeeldvormen met de gewenste stijlen op in een sjabloondia‑set of een .POTX‑sjabloonbestand. Wanneer je een nieuwe presentatie maakt, open je het sjabloon, kloon je de gestylede vormen die je nodig hebt, en pas je hun opmaak opnieuw toe waar nodig.