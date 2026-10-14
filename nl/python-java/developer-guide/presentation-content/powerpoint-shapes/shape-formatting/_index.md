---
title: PowerPoint-vormen opmaken in Python via Java
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/python-java/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schetseffect
- schets vormlijn
- aansluitstijl opmaken
- verloopvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- zwart-wit vormweergave
- grijstint vormweergave
- vorm roteren
- 3D-schuineffect
- 3D-rotatie-effect
- opmaak resetten
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint-vormen kunt opmaken in Python via Java met Aspose.Slides—stel vullings-, lijn- en effectstijlen in voor PPT-, PPTX- en ODP-bestanden met precisie en volledige controle."
---
## **Inleiding**

In PowerPoint kun je vormen toevoegen aan dia's. Aangezien vormen uit lijnen bestaan, kun je ze opmaken door de contouren te wijzigen of er effecten op toe te passen. Daarnaast kun je vormen opmaken door instellingen te specificeren die bepalen hoe hun binnenkant wordt gevuld.

![Vorm opmaken in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java provides classes and methods that allow you to format shapes using the same options available in PowerPoint.

## **Lijnen opmaken**

Using Aspose.Slides, you can specify a custom line style for a shape. The following steps outline the procedure:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)-klasse.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [line style](https://reference.aspose.com/slides/python-java/aspose.slides/linestyle/) van de vorm in.
1. Stel de lijndikte in.
1. Stel de [dash style](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) van de lijn in.
1. Stel de lijnkleur voor de vorm in.
1. Sla de gewijzigde presentatie op als een PPTX-bestand.

The following code demonstrates how to format a rectangle [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Voeg een auto shape van het type Rechthoek toe.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # Stel de vulkleur in voor de rechthoekige vorm.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Pas opmaak toe op de lijnen van de rechthoek.
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # Stel de kleur in voor de lijn van de rechthoek.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Sla het PPTX-bestand op schijf.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The result:

![De opgemaakte lijnen in de presentatie](formatted-lines.png)

## **Schets-effecten toepassen op vormlijnen**

Een schetseffect laat een vormlijn eruitzien alsof deze met de hand is getekend. Gebruik [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) om de lijninstellingen te benaderen, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) om de schetstinstellingen te benaderen, en [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) om een waarde uit de enumeratie [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) te selecteren.

De volgende Python-code laat zien hoe je een [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#Curved)-effect toepast, de expliciet toegewezen waarde leest, en het effect verwijdert met [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#None):

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

    # Toegang tot de lijnopmaak van de vorm en de schetsopmaak.
    sketch_format = shape.getLineFormat().getSketchFormat()

    # Een schetseffect toepassen.
    sketch_format.setSketchType(LineSketchType.Curved)

    # Lees het schetseffect dat rechtstreeks aan de vorm is toegewezen.
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Verwijder het schetseffect.
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

De waarde die wordt geretourneerd door [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) vertegenwoordigt de instelling die rechtstreeks aan de vorm is toegewezen. Als de lijnopmaak kan worden geërfd van een thema, master-dia of layout-dia, gebruik dan [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective), benader `LineFormatEffectiveData.getSketchFormat` en lees `SketchFormatEffectiveData.getSketchType`. De effectieve waarde weerspiegelt de opmaak die daadwerkelijk wordt toegepast nadat de erfenis is opgelost:

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

## **Aansluit-stijlen opmaken**

Hier zijn de drie opties voor aansluit-type:

* Rond
* Miter
* Afschuin

Standaard gebruikt PowerPoint bij het verbinden van twee lijnen onder een hoek (zoals bij een hoek van een vorm) de instelling **Rond**. Als je echter een vorm met scherpe hoeken tekent, kun je de **Miter**-optie verkiezen.

![De aansluit-stijl in de presentatie](join-style-powerpoint.png)

The following Python code demonstrates how three rectangles (as shown in the image above) were created using the Miter, Bevel, and Round join type settings:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Voeg drie auto shapes van het type Rechthoek toe.
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # Stel de vulkleur in voor elke rechthoekige vorm.
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Stel de lijndikte in.
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # Stel de kleur in voor de lijn van elke rechthoek.
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Stel de aansluit-stijl in.
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # Voeg tekst toe aan elke rechthoek.
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # Sla het PPTX-bestand op schijf.
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Verloopvulling**

In PowerPoint is Verloopvulling een opmaakoptie waarmee je een continue mengeling van kleuren op een vorm kunt toepassen. Je kunt bijvoorbeeld twee of meer kleuren gebruiken zodat de ene geleidelijk in de andere vervaagt.

Zo pas je een verloopvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)-klasse.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) van de vorm in op `Gradient`.
1. Voeg je twee gewenste kleuren met gedefinieerde posities toe via de [addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor)-methode van de gradient-stop-collectie die beschikbaar is via de [GradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/)-klasse.
1. Sla de gewijzigde presentatie op als een PPTX-bestand.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Voeg een auto shape van het type Ellipse toe.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # Pas verlopen opmaak toe op de ellips.
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # Stel de richting van het verloop in.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # Voeg twee verloopstops toe.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # Sla het PPTX-bestand op schijf.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![De ellips met verloopvulling](gradient-fill.png)

Als een verloop er anders uitziet in een geëxporteerde afbeelding dan in PowerPoint, zie dan [Choose a Gradient Rendering Style](/slides/nl/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Je kunt een render-stijl kiezen zonder de verloopvulling in de presentatie te wijzigen.

## **Patroonvulling**

In PowerPoint is Patroonvulling een opmaakoptie waarmee je een tweekleurig ontwerp—zoals stippen, strepen, kruisende lijnen of schaakpatroon—op een vorm kunt toepassen. Je kunt aangepaste kleuren kiezen voor de voor- en achtergrond van het patroon.

Aspose.Slides biedt meer dan 45 vooraf gedefinieerde patroonstijlen die je op vormen kunt toepassen om de visuele aantrekkingskracht van je presentaties te vergroten. Zelfs nadat je een vooraf gedefinieerd patroon hebt gekozen, kun je nog steeds de exacte kleuren opgeven die moeten worden gebruikt.

Zo pas je een patroonvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)-klasse.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) van de vorm in op `Pattern`.
1. Kies een patroonstijl uit de vooraf gedefinieerde opties.
1. Stel de [Background Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) van het patroon in.
1. Stel de [Foreground Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) van het patroon in.
1. Sla de gewijzigde presentatie op als een PPTX-bestand.

```python
import jpype
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Voeg een auto shape van het type Rechthoek toe.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Stel het vultype in op Patroon.
    shape.getFillFormat().setFillType(FillType.Pattern)

    # Stel de patroonstijl in.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # Stel de achtergrond- en voorgrondkleur van het patroon in.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # Sla het PPTX-bestand op schijf.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![De rechthoek met patroonvulling](pattern-fill.png)

## **Afbeeldingsvulling**

In PowerPoint is Afbeeldingsvulling een opmaakoptie waarmee je een afbeelding in een vorm kunt plaatsen—effectief de afbeelding gebruikt als achtergrond van de vorm.

Zo gebruik je Aspose.Slides om een afbeeldingsvulling op een vorm toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)-klasse.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) van de vorm in op `Picture`.
1. Stel de afbeeldingsvullingsmodus in op `Tile` (of een andere gewenste modus).
1. Maak een [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/)‑object aan van de afbeelding die je wilt gebruiken.
1. Geef de afbeelding door aan de methode `SlidesPicture.setImage`.
1. Sla de gewijzigde presentatie op als een PPTX-bestand.

Stel dat we een bestand "lotus.png" hebben met de volgende afbeelding:

![De lotus-afbeelding](lotus.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Voeg een auto shape van het type Rechthoek toe.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # Stel het vultype in op Afbeelding.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Stel de afbeeldingsvullingsmodus in.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # Laad een afbeelding en voeg deze toe aan de presentatieresources.
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # Stel de afbeelding in.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Sla het PPTX-bestand op schijf.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![De vorm met afbeeldingsvulling](picture-fill.png)

### **Afbeelding tegel als textuur**

Wil je een getegelde afbeelding als textuur instellen en het tegelgedrag aanpassen, dan kun je de volgende methoden van de [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/)‑klasse gebruiken:

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Stelt de afbeeldingsvullingsmodus in - `Tile` of `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): Bepaalt de uitlijning van de tegels binnen de vorm.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): Regelt of de tegel horizontaal, verticaal of beide kanten wordt gespiegeld.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Stelt de horizontale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Stelt de verticale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): Definieert de horizontale schaal van de tegel als percentage.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): Definieert de verticale schaal van de tegel als percentage.

```python
import jpype
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    first_slide = presentation.getSlides().get_Item(0)

    # Voeg een rechthoekige auto shape toe.
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # Stel het vultype van de vorm in op Afbeelding.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Laad de afbeelding en voeg deze toe aan de presentatieresources.
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # Wijs de afbeelding toe aan de vorm.
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # Configureer de afbeeldingsvullingsmodus en tegel-eigenschappen.
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # Sla het PPTX-bestand op schijf.
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![De tegelopties](tile-options.png)

## **Effen kleurvulling**

In PowerPoint is Effen kleurvulling een opmaakoptie die een vorm vult met één enkele, uniforme kleur. Deze eenvoudige achtergrondkleur wordt toegepast zonder verloop, textuur of patroon.

Om een ​​effen kleurvulling op een vorm toe te passen met Aspose.Slides, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)-klasse.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) van de vorm in op `Solid`.
1. Ken de gewenste vulkleur toe aan de vorm.
1. Sla de gewijzigde presentatie op als een PPTX-bestand.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Voeg een auto shape van het type Rechthoek toe.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Stel het vultype in op Solid.
    shape.getFillFormat().setFillType(FillType.Solid)

    # Stel de vulkleur in.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # Sla het PPTX-bestand op schijf.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![De vorm met effen kleurvulling](solid-color-fill.png)

## **Transparantie instellen**

In PowerPoint kun je, wanneer je een effen kleur, verloop, afbeelding of textuurvulling op vormen toepast, ook een transparantieniveau instellen om de dekking van de vulling te regelen. Een hogere transparantiewaarde maakt de vorm doorzichtiger, waardoor de achtergrond of onderliggende objecten gedeeltelijk zichtbaar worden.

Aspose.Slides laat je het transparantieniveau instellen door de alfa-waarde van de kleur die voor de vulling wordt gebruikt aan te passen. Zo doe je dat:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)-klasse.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) in op `Solid`.
1. Gebruik [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) om een kleur met transparantie te definiëren (de `alpha`-component regelt de transparantie).
1. Sla de presentatie op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Voeg een solide rechthoekige auto shape toe.
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Voeg een transparante rechthoekige auto shape toe boven de solide vorm.
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # Sla het PPTX-bestand op schijf.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![De transparante vorm](shape-transparency.png)

## **Vormen roteren**

Aspose.Slides laat je vormen roteren in PowerPoint-presentaties. Dit kan nuttig zijn bij het positioneren van visuele elementen met specifieke uitlijning- of ontwerpeisen.

Om een vorm op een dia te roteren, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)-klasse.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de rotatie-eigenschap van de vorm in op de gewenste hoek.
1. Sla de presentatie op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Voeg een auto shape van het type Rechthoek toe.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Roteer de vorm met 5 graden.
    shape.setRotation(5)

    # Sla het PPTX-bestand op schijf.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![De vormrotatie](shape-rotation.png)

## **3D-schuineffecten toevoegen**

Aspose.Slides maakt het mogelijk om 3D-schuineffecten op vormen toe te passen door hun [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/)-eigenschappen te configureren.

Om 3D-schuineffecten aan een vorm toe te voegen, volg je deze stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)-klasse.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) toe aan de dia.
1. Configureer de [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) van de vorm om de schuine instellingen te definiëren.
1. Sla de presentatie op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Maak een instantie van de Presentation-klasse.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Voeg een vorm toe aan de dia.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # Stel de ThreeDFormat-eigenschappen van de vorm in.
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # Sla de presentatie op als een PPTX-bestand.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Het 3D-schuineffect](3D-bevel-effect.png)

## **3D-rotatie-effecten toevoegen**

Aspose.Slides maakt het mogelijk om 3D-rotatie-effecten op vormen toe te passen door hun [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/)-eigenschappen te configureren.

Om 3D-rotatie op een vorm toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)-klasse.
1. Haal een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) toe aan de dia.
1. Gebruik de methoden [setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) en [setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType) om de 3D-rotatie te definiëren.
1. Sla de presentatie op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# Maak een instantie van de Presentation-klasse.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # Sla de presentatie op als een PPTX-bestand.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Het 3D-rotatie-effect](3D-rotation-effect.png)

## **Zwart-wit rendering voor vormen beheren**

De methode [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) geeft aan hoe een individuele vorm wordt gerenderd wanneer een presentatie wordt bekeken of verwerkt in zwart-wit-modus. Het activeert niet automatisch zwart-wit-weergave en wijzigt de vul-, lijn- of andere opmaak van de vorm niet in de normale kleurenmodus.

Gebruik een waarde uit de klasse [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) om het gewenste gedrag te selecteren. Bijvoorbeeld, `Automatic` laat de rendering-applicatie de conversie kiezen, `Gray` en `LightGray` gebruiken grijze kleuren, `BlackWhite` gebruikt alleen zwart en wit, `Black` en `White` dwingen één kleur, `Color` behoudt de normale kleuren, en `Hidden` laat de vorm weg in zwart-wit-modus. `NotDefined` betekent dat er geen vorm-specifieke modus is toegewezen.

De volgende Python-code maakt een gekleurde vorm en laat deze grijs verschijnen in de zwart-wit-weergavemodus:

```python
import jpade
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    # Behoud de oranje vulling in kleermodus, maar geef de vorm weer met grijze kleur in zwart-witmodus.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

In de normale kleurenmodus behoudt de rechthoek zijn oranje vulling. In een zwart-wit-weergave-workflow gebruikt hij een grijze kleur omdat de modus is ingesteld op `Gray`. Hierdoor kun je een full-color dia behouden terwijl je een aparte weergave definieert voor afdrukken, voorvertoning of andere workflows die de zwart-wit-weergave-instellingen van de presentatie respecteren.

## **Opmaak resetten**

De volgende Python-code laat zien hoe je de opmaak van een dia reset en de positie, grootte en opmaak van alle vormen met placeholders op de [LayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/) terugzet naar hun standaardinstellingen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # Reset elke vorm op de dia die een placeholder op de lay-out heeft.
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Heeft de vormopmaak invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Alleen minimaal. Ingesloten afbeeldingen en media nemen het grootste deel van de bestandsgrootte in beslag, terwijl vormparameters zoals kleuren, effecten en verlopen als metadata worden opgeslagen en vrijwel geen extra grootte toevoegen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak delen zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak-eigenschappen van elke vorm - vul-, lijn- en effectinstellingen. Als alle overeenkomende waarden gelijk zijn, beschouw dan hun stijlen als identiek en groepeer die vormen logisch, wat het later beheren van stijlen vereenvoudigt.

**Kan ik een reeks aangepaste vormstijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Sla voorbeeldvormen met de gewenste stijlen op in een sjabloon-diavoorstelling of een .POTX-sjabloonbestand. Bij het maken van een nieuwe presentatie open je het sjabloon, kloon je de benodigde gestileerde vormen, en pas je hun opmaak opnieuw toe waar nodig.