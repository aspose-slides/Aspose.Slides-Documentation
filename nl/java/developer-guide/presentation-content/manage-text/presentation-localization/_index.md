---
title: Automatiseer presentatielocalisatie in Java
linktitle: Presentatielocalisatie
type: docs
weight: 100
url: /nl/java/presentation-localization/
keywords:
- taal wijzigen
- spellingcontrole
- taal-id
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Automatiseer PowerPoint- en OpenDocument-dia-localisatie in Java met Aspose.Slides, met praktische codevoorbeelden en tips voor een snellere wereldwijde uitrol."
---
## **Overzicht**

Dit artikel legt uit hoe u de `LanguageId` voor tekst in een presentatie kunt instellen met Aspose.Slides. Het toont hoe u een presentatie opent, een vorm met tekst toevoegt, een taalidentificator toewijst aan een tekstdelen, en het resultaat opslaat als een PPTX‑bestand.

## **Taal wijzigen voor een presentatie en vormtekst**
- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation)‑klasse.  
- Verkrijg de referentie van een dia door zijn Index te gebruiken.  
- Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAutoShape) van het type [Rectangle](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ShapeType#Rectangle) toe aan de dia.  
- Voeg wat tekst toe aan de TextFrame.  
- [Language Id instellen](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) voor tekst.  
- Schrijf de presentatie weg als een PPTX‑bestand.

De implementatie van de bovenstaande stappen wordt hieronder in een voorbeeld getoond.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Veroorzaakt de language ID automatische vertaling van tekst?**

Nee. [Language ID](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) in Aspose.Slides slaat de taal op voor spelling‑ en grammaticacontrole, maar vertaalt of wijzigt de tekst niet. Het is metadata die PowerPoint begrijpt voor correctie.

**Heeft de language ID invloed op afbreking en regeleinden bij het weergeven?**

In Aspose.Slides wordt de [language ID](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) gebruikt voor correctie. De kwaliteit van afbreken en regelterugloop hangt voornamelijk af van de beschikbaarheid van [juiste lettertypen](/slides/nl/java/powerpoint-fonts/) en van de lay‑out/regelafbreekinstellingen voor het schrijfsysteem. Zorg ervoor dat de benodigde lettertypen beschikbaar zijn, configureer [lettertype‑substitutieregels](/slides/nl/java/font-substitution/) en/of [embed lettertypen](/slides/nl/java/embedded-font/) in de presentatie.

**Kan ik verschillende talen instellen binnen één alinea?**

Ja. De [Language ID](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) wordt toegepast op het niveau van een tekstdelen, waardoor één alinea meerdere talen kan bevatten met verschillende correctie‑instellingen.