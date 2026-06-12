---
title: Configureer fallback-lettertypecollecties in PHP
linktitle: Fallback-lettertypecollectie
type: docs
weight: 20
url: /nl/php-java/create-fallback-fonts-collection/
keywords:
- fallback-lettertype
- fallback-regel
- lettertypecollectie
- lettertype configureren
- lettertype instellen
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Stel een fallback-lettertypecollectie in Aspose.Slides voor PHP via Java in om tekst consistent en scherp te houden in PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Aspose.Slides stelt u in staat om een verzameling fallback‑lettertype‑regels voor een presentatie te configureren. Elke fallback‑regel wordt vertegenwoordigd door de `FontFallBackRule`‑klasse en kan worden toegevoegd aan een `FontFallBackRulesCollection`.

Nadat u de verzameling hebt gemaakt, kunt u deze toewijzen via de `setFontFallBackRulesCollection`‑methode van de `FontsManager` van de presentatie. De `FontsManager` beheert lettertypen in de hele presentatie, en elke `Presentation`‑instantie heeft zijn eigen `FontsManager`.

Zodra de `FontsManager` is geïnitieerd met de fallback‑lettertype‑verzameling, worden de opgegeven fallback‑lettertypen toegepast tijdens het renderen van de presentatie.

## **Fallback‑regels toepassen**

Instanties van [FontFallBackRule](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FontFallBackRule)‑klasse kunnen worden georganiseerd in een [FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FontFallBackRulesCollection). Het is mogelijk om regels toe te voegen of te verwijderen uit de verzameling.

Vervolgens kan deze verzameling worden toegewezen aan de [FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FontFallBackRulesCollection)‑methode van de [FontsManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FontsManager)‑klasse. FontsManager regelt lettertypen in de hele presentatie.

Elke [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) heeft een [getFontsManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation#getFontsManager)‑methode met zijn eigen instantie van de [FontsManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FontsManager)‑klasse.

Hier volgt een voorbeeld hoe u een verzameling fallback‑lettertype‑regels kunt maken en toewijzen aan de [FontsManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation#getFontsManager) van een bepaalde presentatie:

```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Nadat de FontsManager is geïnitialiseerd met de fallback‑lettertype‑verzameling, worden de fallback‑lettertypen toegepast tijdens het renderen van de presentatie.

{{% alert color="primary" %}} 
Lees meer over hoe u een [Presentatie rendert met fallback‑lettertype](/slides/nl/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Worden mijn fallback‑regels ingebed in het PPTX‑bestand en zichtbaar in PowerPoint na het opslaan?**

Nee. Fallback‑regels zijn runtime‑renderingsinstellingen; ze worden niet geserializeerd naar PPTX en verschijnen niet in de gebruikersinterface van PowerPoint.

**Wordt fallback toegepast op tekst binnen SmartArt, WordArt, grafieken en tabellen?**

Ja. Hetzelfde glyf‑substitutiemechanisme wordt gebruikt voor alle tekst in deze objecten.

**Distribueert Aspose lettertypen met de bibliotheek?**

Nee. U voegt zelf lettertypen toe en gebruikt ze onder eigen verantwoordelijkheid.

**Kunnen vervanging/substitutie voor ontbrekende lettertypen en fallback voor ontbrekende glyfen samen worden gebruikt?**

Ja. Het zijn onafhankelijke fasen van dezelfde lettertype‑resolutie‑pipeline: eerst lost de engine de beschikbaarheid van lettertypen op ([replacement](/slides/nl/php-java/font-replacement/)/[substitution](/slides/nl/php-java/font-substitution/)), daarna vult fallback de leemtes voor ontbrekende glyfen in beschikbare lettertypen.