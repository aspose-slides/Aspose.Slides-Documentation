---
title: Beheer presentatie-achtergronden in Python via Java
linktitle: Dia-achtergrond
type: docs
weight: 20
url: /nl/python-java/presentation-background/
keywords:
- presentatie-achtergrond
- dia-achtergrond
- effen kleur
- verloopkleur
- afbeelding-achtergrond
- achtergrondtransparantie
- achtergrond-eigenschappen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u dynamische achtergronden in PowerPoint- en OpenDocument‑bestanden kunt instellen met Aspose.Slides voor Python via Java, met code‑tips om uw presentaties te verbeteren."
---
## **Introductie**

Effen kleuren, verlopen en afbeeldingen worden vaak gebruikt als dia-achtergronden. Je kunt de achtergrond instellen voor een **normale dia** (een enkele dia) of een **masterdia** (van toepassing op meerdere dia's tegelijk).

![PowerPoint background](powerpoint-background.png)

## **Stel een effen kleurachtergrond in voor een normale dia**

Aspose.Slides maakt het mogelijk om een effen kleur in te stellen als achtergrond voor een specifieke dia in een presentatie — zelfs als de presentatie een masterdia gebruikt. De wijziging is alleen van toepassing op de geselecteerde dia.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse aan.
2. Stel het [BackgroundType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel het [FillType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/filltype/) van de dia-achtergrond in op `Solid`.
4. Gebruik de [getSolidFillColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fillformat/#getsolidfillcolor) methode op [FillFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fillformat/) om de effen achtergrondkleur op te geven.
5. Sla de gewijzigde presentatie op.

Het volgende Python‑voorbeeld laat zien hoe je een blauwe effen kleur als achtergrond voor een normale dia kunt instellen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Maak een instantie van de Presentation-klasse.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Stel de achtergrondkleur van de dia in op blauw.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Sla de presentatie op naar schijf.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Stel een effen kleurachtergrond in voor een masterdia**

Aspose.Slides maakt het mogelijk om een effen kleur in te stellen als achtergrond voor de masterdia in een presentatie. De masterdia fungeert als een sjabloon dat de opmaak voor alle dia's beheert, dus wanneer je een effen kleur kiest voor de achtergrond van de masterdia, is die van toepassing op elke dia.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse aan.
2. Stel het [BackgroundType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/backgroundtype/) van de masterdia in (via [getMasters](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getmasters)) op `OwnBackground`.
3. Stel het [FillType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/filltype/) van de masterdia-achtergrond in op `Solid`.
4. Gebruik de [getSolidFillColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fillformat/#getsolidfillcolor) methode om de effen achtergrondkleur op te geven.
5. Sla de gewijzigde presentatie op.

Het volgende Python‑voorbeeld laat zien hoe je een effen kleur (groen) als achtergrond voor een masterdia kunt instellen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Maak een instantie van de Presentation-klasse.
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Stel de achtergrondkleur voor de masterdia in op groen.
    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Sla de presentatie op naar schijf.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Stel een verloopachtergrond in voor een dia**

Een verloop is een grafisch effect dat ontstaat door een geleidelijke kleurovergang. Wanneer het wordt gebruikt als dia‑achtergrond, kunnen verlopen presentaties er kunstzinniger en professioneler uit laten zien. Aspose.Slides maakt het mogelijk om een verloopkleur als achtergrond voor dia's in te stellen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse aan.
2. Stel het [BackgroundType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel het [FillType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/filltype/) van de dia-achtergrond in op `Gradient`.
4. Gebruik de [getGradientFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fillformat/#getgradientformat) methode op [FillFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fillformat/) om je voorkeurverloopinstellingen te configureren.
5. Sla de gewijzigde presentatie op.

Het volgende Python‑voorbeeld laat zien hoe je een verloopkleur als achtergrond voor een dia kunt instellen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, TileFlip
from java.awt import Color

# Maak een instantie van de Presentation-klasse.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Pas een verloop effect toe op de achtergrond.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient)

    gradient_format = slide.getBackground().getFillFormat().getGradientFormat()
    gradient_format.setTileFlip(TileFlip.FlipBoth)

    # Voeg de verloopkleuren toe. Zonder verloopstops valt de achtergrond terug op een standaard zwart-naar-wit verloop.
    gradient_format.getGradientStops().add(0.0, Color.CYAN)
    gradient_format.getGradientStops().add(1.0, Color.BLUE)

    # Sla de presentatie op naar schijf.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Stel een afbeelding in als dia‑achtergrond**

Naast effen en verloopvullingen maakt Aspose.Slides het mogelijk om afbeeldingen als dia‑achtergronden te gebruiken.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse aan.
2. Stel het [BackgroundType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel het [FillType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/filltype/) van de dia-achtergrond in op `Picture`.
4. Laad de afbeelding die je als dia‑achtergrond wilt gebruiken.
5. Voeg de afbeelding toe aan de afbeeldingscollectie van de presentatie.
6. Gebruik de [getPictureFillFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fillformat/#getpicturefillformat) methode op [FillFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fillformat/) om de afbeelding als achtergrond toe te wijzen.
7. Sla de gewijzigde presentatie op.

Het volgende Python‑voorbeeld laat zien hoe je een afbeelding als achtergrond voor een dia kunt instellen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

# Maak een instantie van de Presentation-klasse.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Stel achtergrondafbeeldings-eigenschappen in.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    # Laad de afbeelding.
    image = Images.fromFile("Tulips.jpg")
    # Voeg de afbeelding toe aan de afbeeldingscollectie van de presentatie.
    presentation_image = presentation.getImages().addImage(image)
    image.dispose()

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    # Sla de presentatie op naar schijf.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De volgende code‑voorbeeld laat zien hoe je het achtergrondvultype instelt op een getegelde afbeelding en de tegel‑eigenschappen wijzigt:

```python
import jpase
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    background = first_slide.getBackground()

    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Picture)

    new_image = Images.fromFile("image.png")
    presentation_image = presentation.getImages().addImage(new_image)
    new_image.dispose()

    # Stel de afbeelding in die wordt gebruikt voor de achtergrondvulling.
    background_picture_fill_format = background.getFillFormat().getPictureFillFormat()
    background_picture_fill_format.getPicture().setImage(presentation_image)

    # Stel de vulmodus van de afbeelding in op Tegel en pas de tegel-eigenschappen aan.
    background_picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    background_picture_fill_format.setTileOffsetX(15.0)
    background_picture_fill_format.setTileOffsetY(15.0)
    background_picture_fill_format.setTileScaleX(46.0)
    background_picture_fill_format.setTileScaleY(87.0)
    background_picture_fill_format.setTileAlignment(RectangleAlignment.Center)
    background_picture_fill_format.setTileFlip(TileFlip.FlipY)

    presentation.save("TileBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Lees meer: [Tile Picture as Texture](/slides/nl/python-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Verander de transparantie van de achtergrondafbeelding**

Je wilt misschien de transparantie van de achtergrondafbeelding van een dia aanpassen zodat de inhoud van de dia beter opvalt. De volgende Python‑code laat zien hoe je de transparantie van een dia‑achtergrondafbeelding kunt wijzigen:

```python
import jpype
import asposeslides

if not jpase.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Presentation, SaveFormat

transparency_value = 30  # Bijvoorbeeld.

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Haal de verzameling van afbeeldingstransformeeroperaties op.
    image_transform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform()

    # Zoek een bestaand transparantie‑effect met vaste procentwaarde.
    transparency_operation = None
    for operation in image_transform:
        if isinstance(operation, AlphaModulateFixed):
            transparency_operation = operation
            break

    # Stel de nieuwe transparantiewaarde in.
    if transparency_operation is None:
        image_transform.addAlphaModulateFixedEffect(100 - transparency_value)
    else:
        transparency_operation.setAmount(100 - transparency_value)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Haal de waarde van de dia‑achtergrond op**

Aspose.Slides maakt het mogelijk om de effectieve achtergrondwaarden van een dia op te halen met de [getEffective](https://reference.aspose.com/slides/nl/python-java/aspose.slides/background/#geteffective) methode op [Background](https://reference.aspose.com/slides/nl/python-java/aspose.slides/background/). De geretourneerde gegevens tonen de effectieve vul‑ en effectformaten.

Met de [getBackground](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/#getbackground) methode van de [BaseSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/) klasse kun je de achtergrond van een dia verkrijgen.

Het volgende Python‑voorbeeld laat zien hoe je de effectieve achtergrondwaarde van een dia kunt ophalen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

# Maak een instantie van de Presentation-klasse.
presentation = Presentation("Sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Haal de effectieve achtergrond op, rekening houdend met master, lay-out en thema.
    effective_background = slide.getBackground().getEffective()

    if effective_background.getFillFormat().getFillType() == FillType.Solid:
        print("Fill color:", effective_background.getFillFormat().getSolidFillColor())
    else:
        print("Fill type:", effective_background.getFillFormat().getFillType())
finally:
    presentation.dispose()
```

## **FAQ**

**Kan ik een aangepaste achtergrond resetten en de achtergrond van het thema/lay‑out herstellen?**

Ja. Verwijder de aangepaste vulling van de dia, en de achtergrond wordt opnieuw geërfd van de bijbehorende [layout](/slides/nl/python-java/slide-layout)/[master](/slides/nl/python-java/slide-master) dia (d.w.z. de [thema‑achtergrond](/slides/nl/python-java/presentation-theme/)).

**Wat gebeurt er met de achtergrond als ik later het thema van de presentatie wijzig?**

Als een dia zijn eigen vulling heeft, blijft deze ongewijzigd. Als de achtergrond wordt geërfd van de [layout](/slides/nl/python-java/slide-layout)/[master](/slides/nl/python-java/slide-master), wordt deze bijgewerkt om overeen te komen met het [nieuwe thema](/slides/nl/python-java/presentation-theme/).