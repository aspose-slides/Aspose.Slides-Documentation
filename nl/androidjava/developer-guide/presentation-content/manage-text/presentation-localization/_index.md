---
title: Automatiseer presentatie-lokalisatie op Android
linktitle: Presentatie-lokalisatie
type: docs
weight: 100
url: /nl/androidjava/presentation-localization/
keywords:
- taal wijzigen
- spellingcontrole
- taal-id
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Automatiseer de lokalisatie van PowerPoint- en OpenDocument-dia's in Java met Aspose.Slides voor Android, met praktische code-voorbeelden en tips voor een snellere wereldwijde uitrol."
---
## **Overzicht**

Dit artikel legt uit hoe je de `LanguageId` voor tekst in een presentatie kunt instellen met Aspose.Slides. Het laat zien hoe je een presentatie opent, een vorm met tekst toevoegt, een taal‑identificatie toewijst aan een tekstgedeelte, en het resultaat opslaat als een PPTX‑bestand.

## **Taal wijzigen voor een presentatie en vormtekst**
- Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) aan.
- Verkrijg de referentie van een dia door gebruik te maken van de Index.
- Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IAutoShape) van het type [Rectangle](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ShapeType#Rectangle) toe aan de dia.
- Voeg wat tekst toe aan het TextFrame.
- [Setting Language Id](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) toepassen op tekst.
- Schrijf de presentatie weg als een PPTX-bestand.

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

**Veroorzaakt Language ID automatische vertaling van tekst?**

Nee. [Language ID](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) in Aspose.Slides slaat de taal op voor spellingscontrole en grammaticacontrole, maar het vertaalt de tekst niet en wijzigt de inhoud niet. Het is metadata die PowerPoint begrijpt voor controle.

**Heeft Language ID invloed op afbreking en regeleinden tijdens het renderen?**

In Aspose.Slides is [language ID](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) bedoeld voor proeflezen. De kwaliteit van afbreking en het omloop van regels hangt voornamelijk af van de beschikbaarheid van [proper fonts](/slides/nl/androidjava/powerpoint-fonts/) en de layout/regeleinde‑instellingen voor het schrijft systeem. Om correcte weergave te garanderen, zorg dat de benodigde lettertypen beschikbaar zijn, configureer [font substitution rules](/slides/nl/androidjava/font-substitution/), en/of [embed fonts](/slides/nl/androidjava/embedded-font/) in de presentatie.

**Kan ik verschillende talen instellen binnen één paragraaf?**

Ja. [Language ID](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) wordt toegepast op het niveau van tekstgedeelten, zodat één paragraaf meerdere talen kan bevatten met verschillende proefleze‑instellingen.