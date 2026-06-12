---
title: Automatiseer presentatie lokalisatie in JavaScript
linktitle: Presentatielokalisatie
type: docs
weight: 100
url: /nl/nodejs-java/presentation-localization/
keywords:
- wijzig taal
- spellingscontrole
- taal-id
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatiseer PowerPoint- en OpenDocument-dia-lokalisatie in JavaScript met Aspose.Slides, met praktische codevoorbeelden en tips voor een snellere wereldwijde uitrol."
---
## **Overzicht**

Dit artikel legt uit hoe je de `LanguageId` voor tekst in een presentatie instelt met Aspose.Slides. Het toont hoe je een presentatie opent, een vorm met tekst toevoegt, een taal‑identifier toewijst aan een tekstdel en het resultaat opslaat als een PPTX‑bestand.

## **Taal wijzigen voor presentatie en vormtekst**

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.  
- Haal de referentie van een dia op met behulp van de Index.  
- Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AutoShape) van het type [Rectangle](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeType#Rectangle) toe aan de dia.  
- Voeg wat tekst toe aan het TextFrame.  
- [Taal‑ID instellen](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/BasePortionFormat#setLanguageId-java.lang.String-) voor tekst.  
- Sla de presentatie op als een PPTX‑bestand.

De implementatie van de bovenstaande stappen wordt hieronder geïllustreerd in een voorbeeld.

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");
    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Veelgestelde vragen**

**Activeert de taal‑ID automatische tekstvertaling?**

Nee. [setLanguageId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) in Aspose.Slides slaat de taal op voor spelling‑ en grammaticacontrole, maar vertaalt of wijzigt de tekst niet. Het is metadata die PowerPoint begrijpt voor proeflezen.

**Heeft de taal‑ID invloed op woordafbreking en regeleinden tijdens het renderen?**

In Aspose.Slides is [setLanguageId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) bedoeld voor proeflezen. De kwaliteit van woordafbreking en het afbreken van regels hangt voornamelijk af van de beschikbaarheid van [juiste lettertypen](/slides/nl/nodejs-java/powerpoint-fonts/) en de lay‑out/afbreekinstellingen voor het schrijfsysteem. Zorg ervoor dat de benodigde lettertypen beschikbaar zijn, configureer [lettertype‑vervangingsregels](/slides/nl/nodejs-java/font-substitution/) en/of [lettertypen insluiten](/slides/nl/nodejs-java/embedded-font/) in de presentatie om een correcte weergave te garanderen.

**Kan ik verschillende talen instellen binnen één alinea?**

Ja. [setLanguageId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) wordt toegepast op het niveau van een tekstdel, zodat één alinea meerdere talen kan combineren met verschillende proeflezen‑instellingen.