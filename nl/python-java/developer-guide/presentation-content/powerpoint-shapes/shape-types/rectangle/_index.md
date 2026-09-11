---
title: Voeg rechthoeken toe aan presentaties in Python via Java
linktitle: Rechthoek
type: docs
weight: 80
url: /nl/python-java/rectangle/
keywords:
- rechthoek toevoegen
- rechthoek maken
- rechthoekvorm
- eenvoudige rechthoek
- opgemaakte rechthoek
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Verbeter uw PowerPoint-presentaties door rechthoeken toe te voegen met Aspose.Slides voor Python via Java - ontwerp en wijzig vormen eenvoudig programmeermatig."
---
## **Overzicht**

Dit artikel laat zien hoe je rechthoekvormen kunt toevoegen aan PowerPoint‑dia's met behulp van Aspose.Slides. Het behandelt het maken van een eenvoudige rechthoek, het maken van een opgemaakte rechthoek en het opslaan van de bijgewerkte presentatie als een PPTX‑bestand.

Je ziet ook hoe je basisopmaak voor een rechthoek toepast, zoals een effen vulkleur, lijmkleur en lijndikte. Bovendien verwijst de FAQ van het artikel naar gerelateerde rechthoek‑taken, waaronder afgeronde hoeken, afbeeldingsvullingen, visuele effecten, hyperlinks, vormvergrendelingen, exportopties en effectieve eigenschappen.

## **Een rechthoek toevoegen aan een dia**

Om een eenvoudige rechthoek toe te voegen aan een geselecteerde dia van de presentatie, volg je de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
- Haal een referentie naar een dia op basis van de index.
- Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) van het type rechthoek toe met behulp van de [addAutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addAutoShape)‑methode die beschikbaar is via het [ShapeCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/)‑object.
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het voorbeeld hieronder hebben we een eenvoudige rechthoek toegevoegd aan de eerste dia van de presentatie.

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

    # Voeg een rechthoekvorm toe.
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Schrijf het PPTX-bestand naar schijf.
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Een opgemaakte rechthoek toevoegen aan een dia**

Om een opgemaakte rechthoek toe te voegen aan een dia, volg je de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
- Haal een referentie naar een dia op basis van de index.
- Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) van het type rechthoek toe met behulp van de [addAutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addAutoShape)‑methode die beschikbaar is via het [ShapeCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/)‑object.
- Stel het [fill type](https://reference.aspose.com/slides/nl/python-java/aspose.slides/filltype/) van de rechthoek in op solid.
- Stel de kleur van de rechthoek in met behulp van de [setColor]‑methode op de effen vulkleur van het [FillFormat]‑object dat gekoppeld is aan het [Shape]‑object.
- Stel de kleur van de omtrek van de rechthoek in.
- Stel de breedte van de omtrek van de rechthoek in.
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

De bovenstaande stappen zijn geïmplementeerd in het voorbeeld hieronder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instantieer de Presentation-klasse die het PPTX-bestand vertegenwoordigt.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Voeg een rechthoekvorm toe.
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Formateer de vulling van de rechthoek.
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # Formateer de omtrek van de rechthoek.
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # Schrijf het PPTX-bestand naar schijf.
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Hoe voeg ik een rechthoek met afgeronde hoeken toe?**

Gebruik het vormtype met afgeronde hoeken en pas de hoekradius aan in de eigenschappen van de vorm; afronding kan ook per hoek worden toegepast via geometrie‑aanpassingen.

**Hoe vul ik een rechthoek met een afbeelding (textuur)?**

Selecteer het [fill type] voor afbeeldingen, geef de afbeeldingsbron op en configureer de [stretching/tiling modes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/picturefillmode/).

**Kan een rechthoek schaduw en gloed hebben?**

Ja. [Outer/inner shadow, glow, and soft edges](/slides/nl/python-java/shape-effect/) zijn beschikbaar met aanpasbare parameters.

**Kan ik een rechthoek omvormen tot een knop met een hyperlink?**

Ja. [Assign a hyperlink](/slides/nl/python-java/manage-hyperlinks/) aan de klik van de vorm (naar een dia, bestand, webadres of e‑mail springen).

**Hoe kan ik een rechthoek beschermen tegen verplaatsen en wijzigingen?**

[Use shape locks](/slides/nl/python-java/applying-protection-to-presentation/): je kunt verplaatsen, grootte wijzigen, selectie of tekstbewerking verbieden om de lay‑out te behouden.

**Kan ik een rechthoek omzetten naar een rasterafbeelding of SVG?**

Ja. Je kunt de vorm [render the shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getImage) naar een afbeelding met een opgegeven grootte/schaal of [export it as SVG](/slides/nl/python-java/create-shape-thumbnails/) voor vectorgebruik.

**Hoe krijg ik snel de daadwerkelijke (effectieve) eigenschappen van een rechthoek met inachtneming van thema en overerving?**

[Use the shape’s effective properties](/slides/nl/python-java/shape-effective-properties/): de API retourneert berekende waarden die rekening houden met themastijlen, lay‑out en lokale instellingen, waardoor analyse van opmaak wordt vereenvoudigd.