---
title: Automatiseer presentatielokalisatie in PHP
linktitle: Presentatielokalisatie
type: docs
weight: 100
url: /nl/php-java/presentation-localization/
keywords:
- taal wijzigen
- spellingcontrole
- taal-ID
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Automatiseer de lokalisatie van PowerPoint- en OpenDocument-dia's met Aspose.Slides voor PHP via Java, met praktische codevoorbeelden en tips voor snellere wereldwijde uitrol."
---
## **Overzicht**

Dit artikel legt uit hoe u de `LanguageId` voor tekst in een presentatie kunt instellen met behulp van Aspose.Slides. Het toont hoe u een presentatie opent, een vorm met tekst toevoegt, een taalidentificatie aan een tekstdelen toekent, en het resultaat opslaat als een PPTX‑bestand.

## **Taal wijzigen voor een presentatie en vormtekst**
- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑klasse.
- Haal de referentie van een dia op door zijn Index te gebruiken.
- Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) van het type [Rectangle](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ShapeType#Rectangle) toe aan de dia.
- Voeg wat tekst toe aan het TextFrame.
- Stel de [Language Id](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setLanguageId) in voor de tekst.
- Schrijf de presentatie weg als een PPTX‑bestand.

De implementatie van de bovenstaande stappen wordt hieronder in een voorbeeld getoond.

```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text to apply spellcheck language");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Veelgestelde vragen**

**Veroorzaakt de language ID automatische tekstvertaling?**

Nee. [Language ID](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setLanguageId) in Aspose.Slides slaat de taal op voor spellingcontrole en grammatica‑controle, maar vertaalt of wijzigt de tekst niet. Het is metadata die PowerPoint begrijpt voor proeflezen.

**Heeft de language ID invloed op afbreken en regeleinden tijdens het renderen?**

In Aspose.Slides is de [language ID](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setLanguageId) bedoeld voor proeflezen. De kwaliteit van afbreken en het doorlopen van regels hangt voornamelijk af van de beschikbaarheid van [juiste lettertypen](/slides/nl/php-java/powerpoint-fonts/) en van de layout‑/regeleinde‑instellingen voor het schrijftaal. Zorg voor de benodigde lettertypen, configureer [lettertype‑vervangingsregels](/slides/nl/php-java/font-substitution/), en/of [embed fonts](/slides/nl/php-java/embedded-font/) in de presentatie om correcte weergave te garanderen.

**Kan ik verschillende talen instellen binnen één alinea?**

Ja. [Language ID](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setLanguageId) wordt toegepast op tekstdelen, waardoor één alinea meerdere talen met verschillende proeflezen‑instellingen kan bevatten.