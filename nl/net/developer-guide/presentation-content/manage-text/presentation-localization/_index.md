---
title: Automatiseer presentatie‑lokalisatie in .NET
linktitle: Presentatie lokalisatie
type: docs
weight: 100
url: /nl/net/presentation-localization/
keywords:
- taal wijzigen
- spellingscontrole
- taal-id
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Automatiseer PowerPoint- en OpenDocument-dia‑lokalisatie in .NET met Aspose.Slides, met praktische C#‑codevoorbeelden en tips voor een snellere wereldwijde uitrol."
---
## **Overzicht**

Dit artikel legt uit hoe u de `LanguageId` voor tekst in een presentatie instelt met behulp van Aspose.Slides. Het laat zien hoe u een presentatie opent, een vorm met tekst toevoegt, een taal‑identificatie toewijst aan een tekstgedeelte, en het resultaat opslaat als een PPTX-bestand.

## **Taal wijzigen voor een presentatie en vormtekst**
- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.
- Verkrijg de referentie van een dia door de Index te gebruiken.
- Voeg een AutoShape van het type Rechthoek toe aan de dia.
- Voeg wat tekst toe aan het TextFrame.
- Stel de LanguageId in voor de tekst.
- Schrijf de presentatie weg als een PPTX-bestand.

De implementatie van de bovenstaande stappen wordt hieronder geïllustreerd in een voorbeeld.

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**Veroorzaakt de LanguageId automatische tekstvertaling?**

Nee. [LanguageId](https://reference.aspose.com/slides/nl/net/aspose.slides/baseportionformat/languageid/) in Aspose.Slides slaat de taal op voor spellingscontrole en grammaticacontrole, maar vertaalt of wijzigt de tekstinhoud niet. Het is metadata die PowerPoint begrijpt voor controle.

**Heeft LanguageId invloed op afbreekstreepjes en regeleindes tijdens het renderen?**

In Aspose.Slides is [LanguageId] bedoeld voor controle. De kwaliteit van afbreekstreepjes en regelafbreking hangt voornamelijk af van de beschikbaarheid van [juiste lettertypen](/slides/nl/net/powerpoint-fonts/) en van de opmaak-/regeleinde-instellingen voor het betreffende schrift. Zorg ervoor dat de benodigde lettertypen beschikbaar zijn, configureer de [lettertype-vervangingsregels](/slides/nl/net/font-substitution/) en/of [embed lettertypen](/slides/nl/net/embedded-font/) in de presentatie.

**Kan ik verschillende talen instellen binnen één alinea?**

Ja. [LanguageId] wordt toegepast op het niveau van een tekstgedeelte, zodat één alinea meerdere talen kan bevatten met verschillende controle-instellingen.