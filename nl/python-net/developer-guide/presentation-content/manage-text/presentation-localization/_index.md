---
title: Automatiseer presentatie-lokalisatie met Python
linktitle: Presentatie-lokalisatie
type: docs
weight: 100
url: /nl/python-net/presentation-localization/
keywords:
- taal wijzigen
- spellingcontrole
- taal-id
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Automatiseer lokalisatie van PowerPoint- en OpenDocument-dia's in Python met Aspose.Slides, met praktische code-voorbeelden en tips voor een snellere wereldwijde uitrol."
---
## **Overzicht**

Dit artikel legt uit hoe u de `language_id` voor tekst in een presentatie kunt instellen met behulp van Aspose.Slides. Het laat zien hoe u een presentatie opent, een vorm met tekst toevoegt, een taalidentificatie toewijst aan een tekstgedeelte, en het resultaat opslaat als een PPTX‑bestand.

## **Taal wijzigen voor presentatie en tekst van vorm**
- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
- Verkrijg de referentie van een dia door gebruik te maken van de Index.
- Voeg een AutoShape van het type Rectangle toe aan de dia.
- Voeg wat tekst toe aan de TextFrame.
- Stel de Language Id in voor de tekst.
- Schrijf de presentatie weg als een PPTX‑bestand.

De implementatie van de bovenstaande stappen wordt hieronder in een voorbeeld getoond.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```

## **Veelgestelde vragen**

**Veroorzaakt de language ID automatische tekstvertaling?**

Nee. [language_id](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/language_id/) in Aspose.Slides slaat de taal op voor spellingscontrole en grammatica‑controle, maar vertaalt of wijzigt de tekstinhoud niet. Het is metadata die PowerPoint begrijpt voor proofing.

**Heeft de language ID invloed op afbreken en regeleinden tijdens het renderen?**

In Aspose.Slides is [language_id](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/language_id/) bedoeld voor proofing. De kwaliteit van afbreken en de regelafbreking hangen voornamelijk af van de beschikbaarheid van [geschikte lettertypen](/slides/nl/python-net/powerpoint-fonts/) en de lay‑out/regeleinde‑instellingen voor het schrijfsysteem. Zorg ervoor dat de benodigde lettertypen beschikbaar zijn, configureer de [lettertype‑vervangingsregels](/slides/nl/python-net/font-substitution/), en/of [ingesloten lettertypen](/slides/nl/python-net/embedded-font/) in de presentatie.

**Kan ik verschillende talen instellen binnen één alinea?**

Ja. [language_id](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/language_id/) wordt toegepast op het niveau van tekstgedeelten, zodat één alinea meerdere talen kan combineren met verschillende proofing‑instellingen.