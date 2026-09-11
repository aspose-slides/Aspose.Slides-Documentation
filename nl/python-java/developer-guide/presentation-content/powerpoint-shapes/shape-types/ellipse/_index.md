---
title: Ellipsen toevoegen aan presentaties in Python via Java
linktitle: Ellips
type: docs
weight: 30
url: /nl/python-java/ellipse/
keywords:
- ellips
- vorm
- ellips toevoegen
- ellips maken
- ellips tekenen
- opgemaakte ellips
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u ellipsvormen kunt maken, opmaken en manipuleren in Aspose.Slides voor Python via Java in zowel PPT- als PPTX‑presentaties—Python‑code‑voorbeelden inbegrepen."
---
## **Overzicht**

Dit artikel laat zien hoe u ellipsvormen kunt toevoegen aan PowerPoint‑dia’s met behulp van Aspose.Slides. Het behandelt het maken van een eenvoudige ellips, het maken van een opgemaakte ellips en het opslaan van de bijgewerkte presentatie als een PPTX‑bestand. Het raakt ook aan verwante vragen zoals het werken met de positie en grootte van een ellips, het regelen van de stapelvolgorde en het toepassen van animatie‑effecten.

## **Maak een ellips**

Om een eenvoudige ellips aan een geselecteerde dia van de presentatie toe te voegen, volg de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.
- Haal een referentie naar een dia op basis van de index.
- Voeg een ellips toe met de [addAutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addAutoShape) methode van het [ShapeCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/) object.
- Schrijf de aangepaste presentatie naar een PPTX‑bestand.

Het volgende voorbeeld voegt een ellips toe aan de eerste dia:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Instantieer de Presentation-klasse die het PPTX-bestand vertegenwoordigt.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Voeg een ellipsvorm toe.
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Schrijf het PPTX-bestand naar schijf.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Maak een opgemaakte ellips**

Om een opgemaakte ellips aan een dia toe te voegen, volg de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.
- Haal een referentie naar een dia op basis van de index.
- Voeg een ellips toe met de [addAutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addAutoShape) methode van het [ShapeCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/) object.
- Stel het opvultype van de ellips in op solid.
- Stel de opvulkleur van de ellips in via [getSolidFillColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fillformat/#getSolidFillColor) op het [FillFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fillformat/) object dat is gekoppeld aan het [Shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/) object.
- Stel de kleur van de omlijning van de ellips in.
- Stel de dikte van de omlijning van de ellips in.
- Schrijf de aangepaste presentatie naar een PPTX‑bestand.

Het volgende voorbeeld voegt een opgemaakte ellips toe aan de eerste dia van de presentatie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Instantieer de Presentation-klasse die het PPTX-bestand vertegenwoordigt.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Voeg een ellipsvorm toe.
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Formatteer de opvulling van de ellips.
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # Formatteer de omlijning van de ellips.
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # Schrijf het PPTX-bestand naar schijf.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Veelgestelde vragen**

**Hoe kan ik de exacte positie en grootte van een ellips instellen ten opzichte van de eenheden van de dia?**

Coördinaten en afmetingen worden doorgaans **in points** opgegeven. Voor voorspelbare resultaten baseert u uw berekeningen op de dia‑grootte en zet u vereiste millimeters of inches om naar points voordat u waarden toekent.

**Hoe kan ik een ellips boven of onder andere objecten plaatsen (stapelvolgorde regelen)?**

Pas de tekenvolgorde van het object aan door het naar voren te brengen of naar achteren te sturen. Hiermee kan de ellips andere objecten overlappen of de objecten eronder zichtbaar maken.

**Hoe kan ik de verschijning of nadruk van een ellips animeren?**

[Apply](/slides/nl/python-java/shape-animation/) ingang-, nadruk‑ of afsluit‑effecten op de vorm, en configureer triggers en timing om te bepalen wanneer en hoe de animatie wordt afgespeeld.