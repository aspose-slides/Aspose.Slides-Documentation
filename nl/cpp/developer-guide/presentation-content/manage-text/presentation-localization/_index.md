---
title: Automatiseer presentatie‑lokalisatie in C++
linktitle: Presentatie‑lokalisatie
type: docs
weight: 100
url: /nl/cpp/presentation-localization/
keywords:
- taal wijzigen
- spellingcontrole
- taal-id
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Automatiseer de lokalisatie van PowerPoint- en OpenDocument‑dia's in C++ met Aspose.Slides, met praktische code‑voorbeelden en tips voor een snellere wereldwijde uitrol."
---
## **Overzicht**

Dit artikel legt uit hoe u de `LanguageId` voor tekst in een presentatie kunt instellen met behulp van Aspose.Slides. Het laat zien hoe u een presentatie opent, een vorm met tekst toevoegt, een taalidentificatie toewijst aan een tekstgedeelte, en het resultaat opslaat als een PPTX-bestand.

## **Taal wijzigen voor een presentatie en vormtekst**
- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
- Verkrijg de referentie van een dia door gebruik te maken van de Index.
- Voeg een AutoShape van het type Rechthoek toe aan de dia.
- Voeg wat tekst toe aan het TextFrame.
- Stel de Language Id in voor de tekst.
- Schrijf de presentatie weg als een PPTX-bestand.

De implementatie van de bovenstaande stappen wordt hieronder in een voorbeeld getoond.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **FAQ**

**Veroorzaakt Language ID automatische tekstvertaling?**

Nee. [Language ID](https://reference.aspose.com/slides/nl/cpp/aspose.slides/baseportionformat/set_languageid/) in Aspose.Slides slaat de taal op voor spelling- en grammaticacontrole, maar het vertaalt of wijzigt de tekstinhoud niet. Het is metadata die PowerPoint begrijpt voor proeflezen.

**Heeft Language ID invloed op afbreking en regeleinden tijdens het renderen?**

In Aspose.Slides is [Language ID](https://reference.aspose.com/slides/nl/cpp/aspose.slides/baseportionformat/set_languageid/) bedoeld voor proeflezen. De kwaliteit van afbreking en regelafbreking hangt voornamelijk af van de beschikbaarheid van [juiste lettertypen](/slides/nl/cpp/powerpoint-fonts/) en van de layout-/regeleinde-instellingen voor het schrijfsysteem. Zorg ervoor dat de benodigde lettertypen beschikbaar zijn, configureer [lettertype-substitutieregels](/slides/nl/cpp/font-substitution/), en/of [ingesloten lettertypen](/slides/nl/cpp/embedded-font/) in de presentatie.

**Kan ik verschillende talen binnen één alinea instellen?**

Ja. [Language ID](https://reference.aspose.com/slides/nl/cpp/aspose.slides/baseportionformat/set_languageid/) wordt toegepast op het niveau van het tekstgedeelte, zodat één alinea meerdere talen kan combineren met verschillende proefleesinstellingen.