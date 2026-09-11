---
title: PowerPoint-vormen opmaken in Python via Java
linktitle: Vorm-opmaak
type: docs
weight: 20
url: /nl/python-java/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schets effect
- schets vormlijn
- join-stijl opmaken
- gradiëntvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- zwart-wit weergave van vormen
- grijswaarden weergave van vormen
- vorm roteren
- 3D insnijdingseffect
- 3D rotatie-effect
- opmaak resetten
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint-vormen kunt opmaken in Python via Java met Aspose.Slides—stel vul-, lijn- en effectstijlen in voor PPT-, PPTX- en ODP‑bestanden met precisie en volledige controle."
---
## **Inleiding**

In PowerPoint kunt u vormen aan dia’s toevoegen. Omdat vormen bestaan uit lijnen, kunt u ze opmaken door de omlijning te bewerken of er effecten op toe te passen. Daarnaast kunt u vormen opmaken door instellingen te specificeren die bepalen hoe hun binnenkant wordt ingevuld.

![vorm-opmaak-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java biedt klassen en methoden waarmee u vormen kunt opmaken met dezelfde opties als in PowerPoint.

## **Lijnen opmaken**

Met Aspose.Slides kunt u een aangepast lijntype voor een vorm opgeven. De volgende stappen beschrijven de procedure:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel het [line style](https://reference.aspose.com/slides/nl/python-java/aspose.slides/linestyle/) van de vorm in.
1. Stel de lijndikte in.
1. Stel de [dash style](https://reference.aspose.com/slides/nl/python-java/aspose.slides/linedashstyle/) van de lijn in.
1. Stel de lijnkleur voor de vorm in.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende code laat zien hoe u een rechthoek‑[AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) kunt opmaken:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Voeg een AutoShape van het type Rectangle toe.
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

    # Sla het PPTX-bestand op naar schijf.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De opgemaakte lijnen in de presentatie](formatted-lines.png)

## **Schets‑effecten toepassen op vormlijnen**

Een schets‑effect geeft een vormlijn een handgetekende uitstraling. Gebruik [Shape.getLineFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getLineFormat) om de lijninstellingen te benaderen, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/lineformat/#getSketchFormat) om de schetsinstellingen te benaderen, en [SketchFormat.setSketchType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sketchformat/#setSketchType) om een waarde uit de [LineSketchType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/linesketchtype/)‑enumeratie te selecteren.

De volgende Python‑code toont hoe u een [LineSketchType.Curved](https://reference.aspose.com/slides/nl/python-java/aspose.slides/linesketchtype/#Curved)‑effect toepast, de expliciet toegewezen waarde uitleest en het effect verwijdert met [LineSketchType.None_](https://reference.aspose.com/slides/nl/python-java/aspose.slides/linesketchtype/#None):

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

    # Toegang tot de lijnopmaak van de vorm en zijn schetsformaat.
    sketch_format = shape.getLineFormat().getSketchFormat()

    # Een schets‑effect toepassen.
    sketch_format.setSketchType(LineSketchType.Curved)

    # Het schets‑effect lezen dat direct aan de vorm is toegewezen.
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Het schets‑effect verwijderen.
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

De waarde die wordt geretourneerd door [SketchFormat.getSketchType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sketchformat/#getSketchType) vertegenwoordigt de instelling die direct aan de vorm is toegewezen. Als de lijnopmaak kan worden geërfd van een thema, masterslide of layout‑slide, gebruik dan [LineFormat.getEffective](https://reference.aspose.com/slides/nl/python-java/aspose.slides/lineformat/#getEffective), benader `LineFormatEffectiveData.getSketchFormat` en lees `SketchFormatEffectiveData.getSketchType`. De effectieve waarde weerspiegelt de opmaak die daadwerkelijk wordt toegepast nadat de overerving is opgelost:

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

## **Samenvoegstijlen opmaken**

Hier zijn de drie mogelijke join‑type opties:

* Round
* Miter
* Bevel

Standaard, wanneer PowerPoint twee lijnen onder een hoek (bijvoorbeeld bij een hoek van een vorm) verbindt, wordt de **Round**‑instelling gebruikt. Als u echter een vorm met scherpe hoeken tekent, kunt u de voorkeur geven aan de **Miter**‑optie.

![De join‑stijl in de presentatie](join-style-powerpoint.png)

De volgende Python‑code laat zien hoe drie rechthoeken (zoals te zien op de afbeelding hierboven) werden gemaakt met de Miter‑, Bevel‑ en Round‑join‑type instellingen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Voeg drie auto shapes van het type Rectangle toe.
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

    # Stel de join‑stijl in.
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # Voeg tekst toe aan elke rechthoek.
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # Sla het PPTX‑bestand op naar schijf.
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gradiëntenvulling**

In PowerPoint is Gradiëntenvulling een opmaakoptie waarmee u een continu kleurverloop op een vorm kunt toepassen. Bijvoorbeeld: u kunt twee of meer kleuren toepassen zodat de ene geleidelijk in de andere overloopt.

Zo past u een gradiëntenvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de vorm‑[FillType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/filltype/) in op `Gradient`.
1. Voeg uw twee voorkeurskleuren met gedefinieerde posities toe via de [addPresetColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/gradientstopcollection/#addPresetColor)‑methode van de gradient‑stop‑collectie die wordt blootgesteld door de [GradientFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/gradientformat/)‑klasse.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende Python‑code laat zien hoe u een gradiëntenvulling toepast op een ellips:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Voeg een auto shape van het type Ellipse toe.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # Pas gradiëntenopmaak toe op de ellips.
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # Stel de richting van de gradiënt in.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # Voeg twee gradiëntstops toe.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # Sla het PPTX-bestand op naar schijf.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De ellips met gradiëntenvulling](gradient-fill.png)

## **Patroonvulling**

In PowerPoint is Patroonvulling een opmaakoptie waarmee u een tweekleurig ontwerp – bijvoorbeeld stippen, strepen, kruissteek of geruite patronen – op een vorm kunt toepassen. U kunt aangepaste kleuren kiezen voor de voor‑ en achtergrond van het patroon.

Aspose.Slides biedt meer dan 45 vooraf gedefinieerde patroonstijlen die u op vormen kunt toepassen om de visuele aantrekkingskracht van uw presentaties te verhogen. Zelfs na het kiezen van een vooringesteld patroon kunt u de exacte kleuren specificeren die gebruikt moeten worden.

Zo past u een patroonvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de vorm‑[FillType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/filltype/) in op `Pattern`.
1. Kies een patroonstijl uit de vooraf gedefinieerde opties.
1. Stel de [Background Color](https://reference.aspose.com/slides/nl/python-java/aspose.slides/patternformat/#getBackColor) van het patroon in.
1. Stel de [Foreground Color](https://reference.aspose.com/slides/nl/python-java/aspose.slides/patternformat/#getForeColor) van het patroon in.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende Python‑code toont hoe u een patroonvulling toepast op een rechthoek:

```python
import jpype
import asposeslides

if not jpase.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Voeg een auto shape van het type Rectangle toe.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Stel het vultype in op Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern)

    # Stel de patroonstijl in.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # Stel de achtergrond- en voorgrondkleuren van het patroon in.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # Sla het PPTX-bestand op naar schijf.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De rechthoek met patroonvulling](pattern-fill.png)

## **Afbeeldingsvulling**

In PowerPoint is Afbeeldingsvulling een opmaakoptie waarmee u een afbeelding in een vorm kunt invoegen – de afbeelding fungeert dan als achtergrond van de vorm.

Zo gebruikt u Aspose.Slides om een afbeeldingsvulling op een vorm toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de vorm‑[FillType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/filltype/) in op `Picture`.
1. Stel de afbeeldingsvullingsmodus in op `Tile` (of een andere gewenste modus).
1. Maak een [PPImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/ppimage/)‑object aan van de afbeelding die u wilt gebruiken.
1. Geef de afbeelding door aan de `SlidesPicture.setImage`‑methode.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Stel dat we een bestand *lotus.png* hebben met de volgende afbeelding:

![De lotus‑afbeelding](lotus.png)

De volgende Python‑code laat zien hoe u een vorm met de afbeelding vult:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Voeg een auto shape van het type Rectangle toe.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # Stel het vultype in op Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Stel de picture fill-modus in.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # Laad een afbeelding en voeg deze toe aan de presentatie‑bronnen.
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # Stel de afbeelding in.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Sla het PPTX‑bestand op naar schijf.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De vorm met afbeeldingsvulling](picture-fill.png)

### **Afbeelding tegel als textuur**

Wilt u een getegelde afbeelding als textuur gebruiken en het tegel‑gedrag aanpassen, dan kunt u de volgende methoden van de [PictureFillFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/picturefillformat/)‑klasse gebruiken:

- [setPictureFillMode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/picturefillformat/#setPictureFillMode): stelt de afbeeldingsvullingsmodus in – `Tile` of `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nl/python-java/aspose.slides/picturefillformat/#setTileAlignment): specificeert de uitlijning van de tegels binnen de vorm.
- [setTileFlip](https://reference.aspose.com/slides/nl/python-java/aspose.slides/picturefillformat/#setTileFlip): bepaalt of de tegel horizontaal, verticaal of beide kanten wordt gespiegeld.
- [setTileOffsetX](https://reference.aspose.com/slides/nl/python-java/aspose.slides/picturefillformat/#setTileOffsetX): stelt de horizontale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [setTileOffsetY](https://reference.aspose.com/slides/nl/python-java/aspose.slides/picturefillformat/#setTileOffsetY): stelt de verticale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [setTileScaleX](https://reference.aspose.com/slides/nl/python-java/aspose.slides/picturefillformat/#setTileScaleX): definieert de horizontale schaal van de tegel als percentage.
- [setTileScaleY](https://reference.aspose.com/slides/nl/python-java/aspose.slides/picturefillformat/#setTileScaleY): definieert de verticale schaal van de tegel als percentage.

De volgende code‑voorbeeld toont hoe u een rechthoekige vorm met een getegelde afbeeldingsvulling toevoegt en de tegelopties configureert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    first_slide = presentation.getSlides().get_Item(0)

    # Voeg een rechthoekige auto shape toe.
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # Stel het vultype van de vorm in op Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Laad de afbeelding en voeg deze toe aan de presentatieresources.
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # Ken de afbeelding toe aan de vorm.
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # Configureer de picture fill-modus en tegel‑eigenschappen.
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # Sla het PPTX‑bestand op naar schijf.
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De tegelopties](tile-options.png)

## **Effen kleurvulling**

In PowerPoint is Effen kleurvulling een opmaakoptie die een vorm met één uniforme kleur vult. Deze egale achtergrondkleur wordt toegepast zonder gradiënten, texturen of patronen.

Om een effen kleurvulling op een vorm toe te passen met Aspose.Slides, volgt u deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de vorm‑[FillType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/filltype/) in op `Solid`.
1. Ken uw gewenste vulkleur toe aan de vorm.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende Python‑code laat zien hoe u een effen kleurvulling toepast op een rechthoek in een PowerPoint‑dia:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

    # Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
    presentation = Presentation()
    try:
        # Haal de eerste dia op.
        slide = presentation.getSlides().get_Item(0)

        # Voeg een auto shape van het type Rectangle toe.
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

        # Stel het vultype in op Solid.
        shape.getFillFormat().setFillType(FillType.Solid)

        # Stel de vulkleur in.
        shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

        # Sla het PPTX-bestand op naar schijf.
        presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Het resultaat:

![De vorm met effen kleurvulling](solid-color-fill.png)

## **Transparantie instellen**

In PowerPoint kunt u, naast een effen kleur, een gradiënt, afbeelding of textuur, een transparantieniveau instellen om de dekkingsgraad van de vulling te regelen. Een hogere transparantiewaarde maakt de vorm doorzichtiger, zodat de achtergrond of onderliggende objecten gedeeltelijk zichtbaar worden.

Aspose.Slides stelt u in staat de transparantiewaarde te bepalen door de alfa‑waarde van de gebruikte kleur aan te passen. Zo gaat u te werk:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/filltype/) in op `Solid`.
1. Gebruik [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) om een kleur met transparantie te definiëren (het `alpha`‑component regelt de transparantie).
1. Sla de presentatie op.

De volgende Python‑code toont hoe u een transparante vulkleur toepast op een rechthoek:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Voeg een solide rechthoekige auto shape toe.
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Voeg een doorzichtige rechthoekige auto shape toe boven de solide vorm.
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # Sla het PPTX-bestand op naar schijf.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De transparante vorm](shape-transparency.png)

## **Vormen roteren**

Aspose.Slides maakt het mogelijk om vormen in PowerPoint‑presentaties te roteren. Dit kan handig zijn bij het positioneren van visuele elementen met specifieke uitlijnings‑ of ontwerpeisen.

Om een vorm op een dia te roteren, volgt u deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe aan de dia.
1. Stel de rotatie‑eigenschap van de vorm in op de gewenste hoek.
1. Sla de presentatie op.

De volgende Python‑code demonstreert hoe u een vorm met 5 graden roteert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Voeg een auto shape van het type Rectangle toe.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Roteer de vorm met 5 graden.
    shape.setRotation(5)

    # Sla het PPTX-bestand op naar schijf.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De rotatie van de vorm](shape-rotation.png)

## **3D‑Insnijdingseffecten toevoegen**

Aspose.Slides maakt het mogelijk 3D‑insnijdingseffecten op vormen toe te passen door de eigenschappen van hun [ThreeDFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/) te configureren.

Om 3D‑insnijdingseffecten aan een vorm toe te voegen, volgt u deze stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe aan de dia.
1. Configureer de vorm‑[ThreeDFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/) om de insnijdingsinstellingen te definiëren.
1. Sla de presentatie op.

De volgende Python‑code toont hoe u 3D‑insnijdingseffecten op een vorm toepast:

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

Het resultaat:

![Het 3D‑insnijdingseffect](3D-bevel-effect.png)

## **3D‑Rotatie‑effecten toevoegen**

Aspose.Slides maakt het mogelijk 3D‑rotatie‑effecten op vormen toe te passen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/) eigenschappen te configureren.

Om een 3D‑rotatie op een vorm toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) toe aan de dia.
1. Gebruik de methoden [setCameraType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/camera/#setCameraType) en [setLightType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/lightrig/#setLightType) om de 3D‑rotatie te definiëren.
1. Sla de presentatie op.

De volgende Python‑code demonstreert hoe u 3D‑rotatie‑effecten op een vorm toepast:

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

Het resultaat:

![Het 3D‑rotatie‑effect](3D-rotation-effect.png)

## **Zwart‑wit weergave van vormen regelen**

De methode [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#setBlackWhiteMode) bepaalt hoe een individuele vorm wordt gerenderd wanneer een presentatie in zwart‑wit‑modus wordt bekeken of verwerkt. Deze methode activeert niet zelf de zwart‑wit‑weergave en wijzigt de vul‑, lijn‑ of andere opmaak van de vorm niet in de normale kleurenmodus.

Gebruik een waarde uit de [BlackWhiteMode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/blackwhitemode/)‑klasse om het gewenste gedrag te selecteren. Bijvoorbeeld, `Automatic` laat de weergave‑applicatie de conversie kiezen, `Gray` en `LightGray` gebruiken grijstinten, `BlackWhite` gebruikt uitsluitend zwart en wit, `Black` en `White` forceren één kleur, `Color` behoudt de normale kleur, en `Hidden` laat de vorm weg in zwart‑wit‑modus. `NotDefined` betekent dat er geen vorm‑specifieke modus is toegewezen.

De volgende Python‑code maakt een gekleurde vorm aan en laat deze grijs verschijnen in de zwart‑wit‑weergavemodus:

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

    # Houd de oranje vulling in kleurenmodus, maar render de vorm met grijstinten in zwart-wit modus.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

In normale kleurenmodus behoudt de rechthoek zijn oranje vulling. In een zwart‑wit‑workflow wordt grijstint gebruikt omdat de modus is ingesteld op `Gray`. Zo kunt u een volledig‑kleurige dia behouden terwijl u een aparte weergave definieert voor afdrukken, preview‑of andere workflows die de zwart‑wit‑instellingen van de presentatie respecteren.

## **Opmaak resetten**

De volgende Python‑code toont hoe u de opmaak van een dia reset en de positie, grootte en opmaak van alle vormen met placeholders op de [LayoutSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutslide/) terugzet naar hun standaardinstellingen:

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

**Beïnvloedt vormopmaak de uiteindelijke bestandsgrootte van de presentatie?**

Alleen minimaal. Ingevoegde afbeeldingen en media nemen het grootste deel van de bestandsruimte in, terwijl vormparameters zoals kleuren, effecten en gradiënten als metadata worden opgeslagen en vrijwel geen extra omvang toevoegen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak hebben zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm – vul, lijn en effectinstellingen. Als alle overeenkomstige waarden gelijk zijn, beschouw dan hun stijlen als identiek en groepeer die vormen logisch; dit vereenvoudigt later stijlbeheer.

**Kan ik een set aangepaste vormstijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Sla voorbeeldvormen met de gewenste stijlen op in een sjabloondia‑set of een .POTX‑sjabloonbestand. Bij het maken van een nieuwe presentatie opent u het sjabloon, kloont u de benodigde gestileerde vormen en past u hun opmaak toe waar nodig.