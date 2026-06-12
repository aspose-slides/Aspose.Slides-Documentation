---
title: SmartArt-afbeeldingen beheren in presentaties met Python
linktitle: SmartArt-afbeeldingen
type: docs
weight: 20
url: /nl/python-net/manage-smartart-shape/
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
description: "Automatiseer het maken, bewerken en stijlen van PowerPoint SmartArt in Python via .NET met Aspose.Slides, met beknopte codevoorbeelden en prestatiegerichte begeleiding."
---
## **Overzicht**

Aspose.Slides stelt u in staat om SmartArt-afbeeldingen programmatically te maken en beheren in PowerPoint‑presentaties. Dit artikel legt uit hoe u een SmartArt‑vorm aan een dia toevoegt, bestaande SmartArt‑vormen benadert, SmartArt vindt op basis van een specifiek lay-outtype, en het uiterlijk bijwerkt door de SmartArt‑stijl of kleurstijl te wijzigen.

De voorbeelden laten zien hoe u met SmartArt‑vormen werkt via de vormcollectie van de presentatiedia, controleert of een vorm SmartArt is en vervolgens de eigenschappen wijzigt of inspecteert.

## **SmartArt‑vormen maken**

Aspose.Slides for Python via .NET stelt u in staat om aangepaste SmartArt‑vormen vanaf nul aan dia's toe te voegen. De API maakt dit eenvoudig. Om een SmartArt‑vorm aan een dia toe te voegen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
1. Haal de doel-dia op op basis van de index.
1. Voeg een SmartArt‑vorm toe en geef het lay-outtype op.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Maak een instantie van de Presentation-klasse.
with slides.Presentation() as presentation:
    # Toegang tot de presentatiedia.
    slide = presentation.slides[0]
    # Voeg een SmartArt-vorm toe.
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # Sla de presentatie op schijf.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt‑vormen op dia's benaderen**

De onderstaande code toont hoe u SmartArt‑vormen op een dia benadert. Het voorbeeld loopt door elke vorm op de dia en controleert of het een [SmartArt](https://reference.aspose.com/slides/nl/python-net/aspose.slides.smartart/smartart/) object is.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Laad een presentatiebestand.
with slides.Presentation("SmartArt.pptx") as presentation:
    # Itereer door elke vorm op de eerste dia.
    for shape in presentation.slides[0].shapes:
        # Controleer of de vorm een SmartArt-vorm is.
        if isinstance(shape, smartart.SmartArt):
            # Print de vormnaam.
            print("Shape name:", shape.name)
```

## **SmartArt‑vormen benaderen met een opgegeven lay-outtype**

Het volgende voorbeeld laat zien hoe u een SmartArt‑vorm met een opgegeven lay-outtype benadert. Merk op dat u het lay-outtype van een SmartArt niet kunt wijzigen – het is alleen‑lezen en wordt ingesteld wanneer de vorm wordt aangemaakt.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) instantie en laad de presentatie die de SmartArt‑vorm bevat.
1. Haal een verwijzing naar de eerste dia op op basis van de index.
1. Itereer over elke vorm op de eerste dia.
1. Controleer of de vorm een [SmartArt](https://reference.aspose.com/slides/nl/python-net/aspose.slides.smartart/smartart/) object is.
1. Als het lay-outtype van de SmartArt‑vorm overeenkomt met het gewenste type, voer dan de vereiste acties uit.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Itereer door elke vorm op de eerste dia.
    for shape in presentation.slides[0].shapes:
        # Controleer of de vorm een SmartArt-vorm is.
        if isinstance(shape, smartart.SmartArt):
            # Controleer het SmartArt-indelingstype.
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```

## **De stijl van de SmartArt‑vorm wijzigen**

Het volgende voorbeeld laat zien hoe u SmartArt‑vormen vindt en hun stijl wijzigt:

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) en laad het bestand dat de SmartArt‑vorm(en) bevat.
1. Haal een verwijzing naar de eerste dia op op basis van de index.
1. Itereer over elke vorm op de eerste dia.
1. Zoek de SmartArt‑vorm met de opgegeven stijl.
1. Ken de nieuwe stijl toe aan de SmartArt‑vorm.
1. Sla de presentatie op.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Itereer door elke vorm op de eerste dia.
    for shape in presentation.slides[0].shapes:
        # Controleer of de vorm een SmartArt-vorm is.
        if isinstance(shape, smartart.SmartArt):
            # Controleer de SmartArt-stijl.
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # Wijzig de SmartArt-stijl.
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # Sla de presentatie op.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **De kleurstijl van SmartArt‑vormen wijzigen**

Dit voorbeeld laat zien hoe u de kleurstijl van een SmartArt‑vorm wijzigt. De voorbeeldcode zoekt een SmartArt‑vorm met een opgegeven kleurstijl en werkt deze bij.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse en laad de presentatie die de SmartArt‑vorm(en) bevat.
1. Haal een verwijzing naar de eerste dia op op basis van de index.
1. Itereer over elke vorm op de eerste dia.
1. Controleer of de vorm een [SmartArt](https://reference.aspose.com/slides/nl/python-net/aspose.slides.smartart/smartart/) object is.
1. Zoek de SmartArt‑vorm met de opgegeven kleurstijl.
1. Stel de nieuwe kleurstijl in voor die SmartArt‑vorm.
1. Sla de presentatie op.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Itereer door elke vorm op de eerste dia.
    for shape in presentation.slides[0].shapes:
        # Controleer of de vorm een SmartArt-vorm is.
        if isinstance(shape, smartart.SmartArt):
            # Controleer het kleurtype.
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # Wijzig het kleurtype.
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # Sla de presentatie op.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan ik SmartArt als één object animeren?**

Ja. SmartArt is een vorm, dus u kunt [standaardanimaties](/slides/nl/python-net/powerpoint-animation/) toepassen via de animaties‑API (invoer, uitgang, nadruk, bewegingspaden) net zoals bij andere vormen.

**Hoe kan ik een specifieke SmartArt op een dia vinden als ik de interne ID niet ken?**

Stel de alternatieve tekst (AltText) in en gebruik deze om naar de vorm te zoeken—dit is een aanbevolen manier om de gewenste vorm te lokaliseren.

**Kan ik SmartArt groeperen met andere vormen?**

Ja. U kunt SmartArt groeperen met andere vormen (afbeeldingen, tabellen, enz.) en vervolgens de [groep manipuleren](/slides/nl/python-net/group/).

**Hoe krijg ik een afbeelding van een specifieke SmartArt (bijv. voor een voorbeeld of rapport)?**

Exporteer een miniatuur/afbeelding van de vorm; de bibliotheek kan [individuele vormen renderen](/slides/nl/python-net/create-shape-thumbnails/) naar rasterbestanden (PNG/JPG/TIFF).

**Wordt het uiterlijk van SmartArt behouden bij het converteren van de hele presentatie naar PDF?**

Ja. De rendering‑engine streeft naar hoge getrouwheid voor [PDF-export](/slides/nl/python-net/convert-powerpoint-to-pdf/), met een reeks kwaliteits‑ en compatibiliteitsopties.