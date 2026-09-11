---
title: Beheer SmartArt-grafieken in presentaties met Python
linktitle: SmartArt-grafieken
type: docs
weight: 20
url: /nl/python-java/manage-smartart-shape/
keywords:
- SmartArt-object
- SmartArt-afbeelding
- SmartArt-stijl
- SmartArt-kleur
- SmartArt maken
- SmartArt toevoegen
- SmartArt bewerken
- SmartArt wijzigen
- SmartArt benaderen
- SmartArt-indelingstype
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Automatiseer het maken, bewerken en stylen van PowerPoint SmartArt in Python met Aspose.Slides, met beknopte codevoorbeelden en prestatiegerichte richtlijnen."
---
## **Overzicht**

Aspose.Slides stelt u in staat om programmatically SmartArt‑grafieken te maken en te beheren in PowerPoint‑presentaties. Dit artikel legt uit hoe u een SmartArt‑vorm aan een dia toevoegt, bestaande SmartArt‑vormen benadert, SmartArt vindt op basis van een specifiek lay-outtype, en het uiterlijk bijwerkt door de SmartArt‑stijl of kleurstijl te wijzigen.

De voorbeelden laten zien hoe u met SmartArt‑vormen werkt via de vormcollectie van de presentatiedia, controleert of een vorm SmartArt is en daarna de eigenschappen wijzigt of inspecteert.

## **Een SmartArt‑vorm maken**
Aspose.Slides voor Python via Java biedt een API om SmartArt‑vormen te maken. Om een SmartArt‑vorm in een dia te maken, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.
1. Haal een dia op op basis van zijn index.
1. [Voeg een SmartArt‑vorm toe](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addSmartArt) door een [SmartArtLayoutType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartlayouttype/) op te geven.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Voeg een SmartArt‑vorm toe.
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # Sla de presentatie op.
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figuur: SmartArt‑vorm toegevoegd aan de dia**|

## **Een SmartArt‑vorm op een dia benaderen**
Het onderstaande voorbeeld benadert SmartArt‑vormen op een presentatiedia. Het doorloopt elke vorm op de dia en controleert of de vorm een [SmartArt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartart/)‑instantie is.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Doorloop elke vorm op de eerste dia.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **Een SmartArt‑vorm met een specifiek lay-outtype benaderen**
Het onderstaande voorbeeld benadert een [SmartArt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartart/)‑vorm met een specifiek lay-outtype, verkregen via [SmartArt.getLayout](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartart/#getLayout).

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse en laad de presentatie die een SmartArt‑vorm bevat.
1. Haal de eerste dia op op basis van zijn index.
1. Loop door elke vorm op de eerste dia.
1. Controleer of de vorm een [SmartArt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartart/)‑instantie is.
1. Controleer of de SmartArt‑vorm het opgegeven lay-outtype heeft en voer de vereiste bewerking uit.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Doorloop elke vorm op de eerste dia.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Controleer de SmartArt-indeling.
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **De stijl van een SmartArt‑vorm wijzigen**
Dit voorbeeld laat zien hoe u de snellestijl van een SmartArt‑vorm wijzigt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse en laad de presentatie die een SmartArt‑vorm bevat.
1. Haal de eerste dia op op basis van zijn index.
1. Loop door elke vorm op de eerste dia.
1. Controleer of de vorm een [SmartArt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartart/)‑instantie is.
1. Zoek de SmartArt‑vorm met de opgegeven stijl.
1. Stel de nieuwe stijl in voor de SmartArt‑vorm.
1. Sla de presentatie op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Doorloop elke vorm op de eerste dia.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Controleer en wijzig de SmartArt-stijl.
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figuur: SmartArt‑vorm met gewijzigde stijl**|

## **De kleurstijl van een SmartArt‑vorm wijzigen**
Dit voorbeeld benadert een SmartArt‑vorm met een specifieke kleurstijl en wijzigt die stijl.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse en laad de presentatie die een SmartArt‑vorm bevat.
1. Haal de eerste dia op op basis van zijn index.
1. Loop door elke vorm op de eerste dia.
1. Controleer of de vorm een [SmartArt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartart/)‑instantie is.
1. Zoek de SmartArt‑vorm met de opgegeven kleurstijl.
1. Stel de nieuwe kleurstijl in voor de SmartArt‑vorm.
1. Sla de presentatie op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Doorloop elke vorm op de eerste dia.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Controleer en wijzig de SmartArt-stijl.
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figuur: SmartArt‑vorm met gewijzigde kleurstijl**|

## **FAQ**

**Kan ik SmartArt als één enkel object animeren?**

Ja. SmartArt is een vorm, dus u kunt [standaardanimaties](/slides/nl/python-java/powerpoint-animation/) toepassen via de animaties‑API (invoer, uitgang, nadruk, bewegingspaden), net als bij andere vormen.

**Hoe kan ik een specifieke SmartArt op een dia vinden als ik de interne ID niet ken?**

Stel de [alternatieve tekst](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#setAlternativeText) in en gebruik deze om te zoeken naar de vorm op basis van die waarde — dit is een aanbevolen methode om de doelvorm te vinden.

**Kan ik SmartArt groeperen met andere vormen?**

Ja. U kunt SmartArt groeperen met andere vormen (afbeeldingen, tabellen, enz.) en vervolgens de [groep manipuleren](/slides/nl/python-java/group/).

**Hoe krijg ik een afbeelding van een specifieke SmartArt (bijv. voor een voorbeeld of rapport)?**

Exporteer een miniatuur/afbeelding van de vorm; de bibliotheek kan [individuele vormen renderen](/slides/nl/python-java/create-shape-thumbnails/) naar rasterbestanden (PNG/JPG/TIFF).

**Wordt het uiterlijk van SmartArt behouden bij het converteren van de volledige presentatie naar PDF?**

Ja. De renderengine streeft naar hoge getrouwheid bij [PDF‑export](/slides/nl/python-java/convert-powerpoint-to-pdf/), met een reeks kwaliteits‑ en compatibiliteitsopties.