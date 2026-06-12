---
title: Configureer fallback-lettertype-collecties in Java
linktitle: Fallback-lettertype-collectie
type: docs
weight: 20
url: /nl/java/create-fallback-fonts-collection/
keywords:
- fallback-lettertype
- fallback-regel
- lettertype-collectie
- lettertype configureren
- lettertype instellen
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Stel een fallback-lettertype-collectie in Aspose.Slides voor Java in om tekst consistent en scherp te houden in PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Aspose.Slides stelt u in staat om een collectie van fallback‑lettertype‑regels voor een presentatie te configureren. Elke fallback‑regel wordt vertegenwoordigd door de klasse `FontFallBackRule` en kan worden toegevoegd aan een `FontFallBackRulesCollection`, die de interface `IFontFallBackRulesCollection` implementeert.

Nadat u de collectie hebt aangemaakt, kunt u deze toewijzen aan de eigenschap `FontFallBackRulesCollection` van de `FontsManager` van de presentatie. De `FontsManager` regelt de lettertypen in de hele presentatie, en elke `Presentation`‑instantie heeft zijn eigen `FontsManager`.

Zodra de `FontsManager` is geïnitialiseerd met de fallback‑lettertype‑collectie, worden de opgegeven fallback‑lettertypen toegepast tijdens het renderen van de presentatie.

## **Toepassen van fallbackregels**

Instanties van de klasse [FontFallBackRule](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRule) kunnen worden georganiseerd in een [FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRulesCollection), die de [IFontFallBackRulesCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IFontFallBackRulesCollection) interface implementeert. Het is mogelijk om regels toe te voegen of te verwijderen uit de collectie.

Vervolgens kan deze collectie worden toegewezen aan de [FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRulesCollection)‑methode van de [FontsManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontsManager)‑klasse. FontsManager regelt lettertypen in de hele presentatie.

Elke [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) heeft een [getFontsManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getFontsManager--)‑methode met zijn eigen instantie van de klasse [FontsManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontsManager).

Hier volgt een voorbeeld hoe u een collectie van fallback‑lettertype‑regels maakt en toewijst aan de [FontsManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getFontsManager--) van een bepaalde presentatie:

```java
Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```

Nadat de FontsManager is geïnitialiseerd met de fallback‑lettertype‑collectie, worden de fallback‑lettertypen toegepast tijdens het renderen van de presentatie.

{{% alert color="primary" %}} 
Lees meer over hoe u een [Presentatie rendert met fallback‑lettertype](/slides/nl/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Veelgestelde vragen**

**Worden mijn fallback‑regels ingebed in het PPTX‑bestand en zichtbaar in PowerPoint na het opslaan?**

Nee. Fallback‑regels zijn runtime‑renderingsinstellingen; ze worden niet geserialiseerd naar PPTX en zullen niet verschijnen in de UI van PowerPoint.

**Is fallback van toepassing op tekst binnen SmartArt, WordArt, grafieken en tabellen?**

Ja. Hetzelfde glyph‑substitutiemechanisme wordt gebruikt voor alle tekst in deze objecten.

**Distribueert Aspose enige lettertypen met de bibliotheek?**

Nee. U voegt lettertypen toe en gebruikt ze zelf, onder uw eigen verantwoordelijkheid.

**Kunnen vervanging/substitutie voor ontbrekende lettertypen en fallback voor ontbrekende glyphs samen worden gebruikt?**

Ja. Ze vormen onafhankelijke stappen in dezelfde lettertype‑resolutiepijplijn: eerst lost de engine de beschikbaarheid van lettertypen op ([vervanging](/slides/nl/java/font-replacement/)/[substitutie](/slides/nl/java/font-substitution/)), daarna vult fallback de leemtes voor ontbrekende glyphs in de beschikbare lettertypen.