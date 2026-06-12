---
title: Rechthoeken toevoegen aan presentaties in Python
linktitle: Rechthoek
type: docs
weight: 80
url: /nl/python-net/rectangle/
keywords:
- rechthoek toevoegen
- rechthoek aanmaken
- rechthoekvorm
- eenvoudige rechthoek
- geformatteerde rechthoek
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Verbeter uw PowerPoint‑ en OpenDocument‑presentaties door rechthoeken toe te voegen met Aspose.Slides for Python via .NET—ontwerp en wijzig vormen eenvoudig via code."
---
## **Overzicht**

Dit artikel toont hoe je rechthoekvormen aan PowerPoint‑dia’s kunt toevoegen met Aspose.Slides. Het behandelt het maken van een eenvoudige rechthoek, een geformatteerde rechthoek, en het opslaan van de bijgewerkte presentatie als een PPTX‑bestand.

Je ziet ook hoe je basale rechthoek‑opmaak kunt toepassen, zoals een effen vulkleur, lijnkleur en lijndikte. Bovendien verwijst de FAQ van het artikel naar gerelateerde rechthoek‑taken, waaronder afgeronde hoeken, afbeeldingsvullingen, visuele effecten, hyperlinks, vormvergrendelingen, exportopties en effectieve eigenschappen.

## **Eenvoudige rechthoek maken**
Net als eerdere onderwerpen gaat het hier ook om het toevoegen van een vorm, en dit keer bespreken we de rechthoek. In dit onderwerp hebben we beschreven hoe ontwikkelaars eenvoudige of geformatteerde rechthoeken aan hun dia’s kunnen toevoegen met Aspose.Slides for Python via .NET. Om een eenvoudige rechthoek aan een geselecteerde dia van de presentatie toe te voegen, volg je de onderstaande stappen:

1. Maak een instantie van de [Presentation ](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)klasse.
1. Verkrijg de referentie van een dia door zijn Index te gebruiken.
1. Voeg een IAutoShape van het type Rectangle toe met de AddAutoShape‑methode die door het IShapes‑object wordt aangeboden.
1. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een eenvoudige rechthoek toegevoegd aan de eerste dia van de presentatie.

```py
import aspose.slides as slides

# Instantatie van de Presentation-klasse die de PPTX representeert
with slides.Presentation() as pres:
    # Haal de eerste dia op
    sld = pres.slides[0]

    # Voeg een autoshape van het type rechthoek toe
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    #Schrijf het PPTX‑bestand naar schijf
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Geformatteerde rechthoek maken**
Om een geformatteerde rechthoek aan een dia toe te voegen, volg je de onderstaande stappen:

1. Maak een instantie van de [Presentation ](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)klasse.
1. Verkrijg de referentie van een dia door zijn Index te gebruiken.
1. Voeg een IAutoShape van het type Rectangle toe met de AddAutoShape‑methode die door het IShapes‑object wordt aangeboden.
1. Stel het vultype van de rechthoek in op Solid.
1. Stel de kleur van de rechthoek in via de SolidFillColor.Color‑eigenschap die door het FillFormat‑object van het IShape‑object wordt aangeboden.
1. Stel de kleur van de lijnen van de rechthoek in.
1. Stel de breedte van de lijnen van de rechthoek in.
1. Schrijf de aangepaste presentatie weg als PPTX‑bestand.  
   De bovenstaande stappen zijn geïmplementeerd in het onderstaande voorbeeld.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantatie van de Presentation-klasse die de PPTX representeert
with slides.Presentation() as pres:
    # Haal de eerste dia op
    sld = pres.slides[0]

    # Voeg een autoshape van het type rechthoek toe
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Pas enige opmaak toe op de rechthoekvorm
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Pas enige opmaak toe op de lijn van de rechthoek
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Schrijf het PPTX-bestand naar schijf
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Hoe voeg ik een rechthoek met afgeronde hoeken toe?**

Gebruik het [shape type]([https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapetype/](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapetype/)) met afgeronde hoeken en pas de hoekradius aan in de eigenschappen van de vorm; afronding kan ook per hoek worden toegepast via geometrie‑aanpassingen.

**Hoe vul ik een rechthoek met een afbeelding (tekstuur)?**

Selecteer het [fill type]([https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/](https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/)), geef de afbeeldingsbron op en configureer de [stretching/tiling‑modi]([https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillmode/](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillmode/)).

**Kan een rechthoek schaduw en gloed hebben?**

Ja. [Outer/inner shadow, glow, and soft edges](/slides/nl/python-net/shape-effect/) zijn beschikbaar met aanpasbare parameters.

**Kan ik een rechthoek omzetten in een knop met een hyperlink?**

Ja. [Assign a hyperlink](/slides/nl/python-net/manage-hyperlinks/) aan de klik van de vorm (naar een dia, bestand, webadres of e‑mail).

**Hoe kan ik een rechthoek beschermen tegen verplaatsen en wijzigen?**

[Use shape locks](/slides/nl/python-net/applying-protection-to-presentation/): je kunt verplaatsen, formaat wijzigen, selecteren of tekstbewerking verbieden om de lay‑out te behouden.

**Kan ik een rechthoek converteren naar een rasterafbeelding of SVG?**

Ja. Je kunt de vorm [render the shape]([http://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/get_image/](http://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/get_image/)) naar een afbeelding met een opgegeven grootte/schaal of [export it as SVG]([https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/write_as_svg/](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/write_as_svg/)) exporteren voor vectorgebruik.

**Hoe krijg ik snel de daadwerkelijke (effectieve) eigenschappen van een rechthoek met inachtneming van thema en overerving?**

[Use the shape’s effective properties](/slides/nl/python-net/shape-effective-properties/): de API retourneert berekende waarden die rekening houden met themastijlen, lay‑out en lokale instellingen, waardoor analyse van opmaak wordt vereenvoudigd.