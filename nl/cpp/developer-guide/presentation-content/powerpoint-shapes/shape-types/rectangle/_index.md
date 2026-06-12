---
title: Voeg rechthoeken toe aan presentaties in C++
linktitle: Rechthoek
type: docs
weight: 80
url: /nl/cpp/rectangle/
keywords:
- rechthoek toevoegen
- rechthoek maken
- rechthoekvorm
- eenvoudige rechthoek
- opgemaakte rechthoek
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Verbeter uw PowerPoint-presentaties door rechthoeken toe te voegen met Aspose.Slides for C++ - ontwerp en wijzig vormen eenvoudig programmeringsmatig."
---
## **Overzicht**

Dit artikel laat zien hoe u rechthoekvormen aan PowerPoint‑dia’s kunt toevoegen met Aspose.Slides. Het behandelt het maken van een eenvoudige rechthoek, het maken van een opgemaakte rechthoek en het opslaan van de bijgewerkte presentatie als een PPTX‑bestand.

## **Eenvoudige rechthoek maken**
Net als bij eerdere onderwerpen gaat het hier om het toevoegen van een vorm, en dit keer is dat een Rectangle. In dit onderwerp hebben we beschreven hoe ontwikkelaars eenvoudige of opgemaakte rechthoeken aan hun dia’s kunnen toevoegen met Aspose.Slides for C++. Om een eenvoudige rechthoek toe te voegen aan een geselecteerde dia van de presentatie, volgt u de onderstaande stappen:

1. Maak een instantie van [Presentation class](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/).
1. Verkrijg de referentie van een dia via de Index.
1. Voeg een IAutoShape van het type Rectangle toe met de AddAutoShape‑methode van het IShapes‑object.
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een eenvoudige rechthoek toegevoegd aan de eerste dia van de presentatie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **Opgemaakte rechthoek maken**
Om een opgemaakte rechthoek aan een dia toe te voegen, volgt u de onderstaande stappen:

1. Maak een instantie van [Presentation class](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/).
1. Verkrijg de referentie van een dia via de Index.
1. Voeg een IAutoShape van het type Rectangle toe met de AddAutoShape‑methode van het IShapes‑object.
1. Stel het vultype van de Rectangle in op Solid.
1. Stel de kleur van de Rectangle in via de SolidFillColor.Color‑eigenschap van het FillFormat‑object dat aan het IShape‑object is gekoppeld.
1. Stel de kleur van de lijnen van de Rectangle in.
1. Stel de breedte van de lijnen van de Rectangle in.
1. Schrijf de gewijzigde presentatie weg als PPTX‑bestand.  
   De bovenstaande stappen zijn geïmplementeerd in het voorbeeld hieronder.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}

## **FAQ**

**Hoe voeg ik een rechthoek met afgeronde hoeken toe?**

Gebruik het afgeronde‑hoek‑[shape type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shapetype/) en pas de hoekstraal aan in de eigenschappen van de vorm; afronding kan ook per hoek worden toegepast via geometrie‑aanpassingen.

**Hoe vul ik een rechthoek met een afbeelding (textuur)?**

Selecteer het foto‑[fill type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/filltype/), geef de beeldbron op en configureer de [stretching/tiling‑modi](https://reference.aspose.com/slides/nl/cpp/aspose.slides/picturefillmode/).

**Kan een rechthoek schaduw en gloed hebben?**

Ja. [Outer/inner shadow, glow, and soft edges](/slides/nl/cpp/shape-effect/) zijn beschikbaar met aanpasbare parameters.

**Kan ik van een rechthoek een knop maken met een hyperlink?**

Ja. [Assign a hyperlink](/slides/nl/cpp/manage-hyperlinks/) aan het klik‑event van de vorm (naar een dia, bestand, webadres of e‑mail).

**Hoe kan ik een rechthoek beschermen tegen verplaatsing en wijzigingen?**

[Use shape locks](/slides/nl/cpp/applying-protection-to-presentation/): u kunt verplaatsen, de grootte wijzigen, selectie of tekstbewerking verbieden om de lay‑out te behouden.

**Kan ik een rechthoek omzetten naar een raster‑afbeelding of SVG?**

Ja. U kunt de vorm [render the shape](http://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/getimage/) naar een afbeelding met een opgegeven grootte/schaal of deze [export it as SVG](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/writeassvg/) voor vectorgebruik.

**Hoe krijg ik snel de werkelijke (effectieve) eigenschappen van een rechthoek, rekening houdend met thema en overerving?**

[Use the shape’s effective properties](/slides/nl/cpp/shape-effective-properties/): de API geeft berekende waarden terug die thema‑stijlen, lay‑out en lokale instellingen meenemen, waardoor formatteeranalyse eenvoudiger wordt.