---
title: Specificeer fallback-lettertypen voor presentaties in PHP
linktitle: Fallback-lettertype
type: docs
weight: 10
url: /nl/php-java/create-fallback-font/
keywords:
- fallback-lettertype
- fallback-regel
- lettertype toepassen
- lettertype vervangen
- Unicode-bereik
- ontbrekende glyph
- juiste glyph
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheer Aspose.Slides voor PHP via Java om fallback-lettertypen in PPT-, PPTX- en ODP-bestanden in te stellen, zodat de weergave van tekst consistent blijft op elk apparaat of besturingssysteem."
---
## **Overzicht**

Aspose.Slides stelt u in staat om fallback-lettertypen op te geven voor het renderen en exporteren van presentaties. Fallback-lettertypen worden gebruikt wanneer het primaire lettertype geen glyphs voor bepaalde tekens bevat.

Het fallback‑gedrag wordt geconfigureerd via fallback‑regels. Elke regel koppelt een Unicode‑bereik aan een of meer lettertypen die de benodigde glyphs kunnen bevatten. U kunt regels definiëren voor verschillende tekenbereiken, fallback-lettertypen toevoegen of verwijderen uit bestaande regels, en meerdere regels organiseren in een collectie fallback‑lettertype‑regels.

Fallback‑regels zijn runtime‑renderinstellingen. Ze wijzigen het presentatiedocument zelf niet en worden niet opgeslagen in het PPTX‑bestand.

## **Fallback‑regels**

Aspose.Slides ondersteunt de klasse [FontFallBackRule](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FontFallBackRule) om de regels te specificeren die een fallback‑lettertype toepassen. De klasse [FontFallBackRule](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FontFallBackRule) vertegenwoordigt een koppeling tussen het opgegeven Unicode‑bereik, dat wordt gebruikt om ontbrekende glyphs te zoeken, en een lijst van lettertypen die de juiste glyphs kunnen bevatten:

```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # Met meerdere manieren kunt u een lijst met lettertypen toevoegen:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```

Het is ook mogelijk om een fallback‑lettertype te [remove](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontfallbackrule/remove/) of [addFallBackFonts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontfallbackrule/addfallbackfonts/) toe te voegen aan een bestaand [FontFallBackRule](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FontFallBackRule) object.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FontFallBackRulesCollection) kan worden gebruikt om een lijst van [FontFallBackRule](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FontFallBackRule) objecten te organiseren, wanneer er een behoefte is om fallback‑lettertype‑vervangingsregels voor meerdere Unicode‑bereiken op te geven.

{{% alert color="primary" title="Zie ook" %}} 
- [Maak een fallback-lettertypenverzameling](/slides/nl/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Veelgestelde vragen**

**Wat is het verschil tussen een fallback‑lettertype, lettertype‑substitutie en lettertype‑inbedding?**

Een fallback‑lettertype wordt alleen gebruikt voor tekens die ontbreken in het primaire lettertype. [Font substitution](/slides/nl/php-java/font-substitution/) vervangt het volledige opgegeven lettertype door een ander lettertype. [Font embedding](/slides/nl/php-java/embedded-font/) verpakt de lettertypen in het uitvoerbestand zodat ontvangers de tekst zien zoals bedoeld.

**Worden fallback‑lettertypen toegepast tijdens exporten zoals PDF, PNG of SVG, of alleen bij weergave op het scherm?**

Ja. Fallback heeft invloed op alle [rendering and export operations](/slides/nl/php-java/convert-presentation/) waarbij tekens moeten worden getekend maar ontbreken in het bronlettertype.

**Verandert het configureren van fallback het presentatiedocument zelf, en blijft de instelling behouden bij toekomstige openingen?**

Nee. Fallback‑regels zijn runtime‑renderinstellingen in uw code; ze worden niet opgeslagen in de .pptx en verschijnen niet in PowerPoint.

**Beïnvloeden het besturingssysteem (Windows/Linux/macOS) en de set van lettertype‑mappen de fallback‑selectie?**

Ja. De engine zoekt lettertypen op in de beschikbare systeem‑mappen en eventuele [additional paths](/slides/nl/php-java/custom-font/) die u opgeeft. Als een lettertype fysiek niet beschikbaar is, kan een regel die ernaar verwijst niet effectief worden.

**Werkt fallback voor WordArt, SmartArt en diagrammen?**

Ja. Wanneer deze objecten tekst bevatten, wordt hetzelfde glyph‑substitutiemechanisme gebruikt om ontbrekende tekens te renderen.