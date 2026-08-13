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
description: "Stel een fallback-lettertype-collectie in Aspose.Slides voor Java in om de tekst consistent en scherp te houden in PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Met Aspose.Slides kunt u een collectie van fallback‑lettertype‑regels voor een presentatie configureren. Elke fallback‑regel wordt vertegenwoordigd door de `FontFallBackRule`‑klasse en kan worden toegevoegd aan een `FontFallBackRulesCollection`, die de `IFontFallBackRulesCollection`‑interface implementeert.

Nadat u de collectie hebt aangemaakt, kunt u deze toewijzen aan de eigenschap `FontFallBackRulesCollection` van de `FontsManager` van de presentatie. De `FontsManager` beheert lettertypen in de hele presentatie, en elke `Presentation`‑instantie heeft zijn eigen `FontsManager`.

Zodra de `FontsManager` is geïnitialiseerd met de fallback‑lettertype‑collectie, worden de opgegeven fallback‑lettertypen toegepast tijdens het renderen van de presentatie.

## **Fallback‑regels toepassen**

Instanties van de klasse [FontFallBackRule](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRule) kunnen worden georganiseerd in een [FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRulesCollection), die de [IFontFallBackRulesCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IFontFallBackRulesCollection) interface implementeert. Het is mogelijk om regels aan de collectie toe te voegen of te verwijderen.

Vervolgens kan deze collectie worden toegewezen aan de [FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontFallBackRulesCollection)‑methode van de [FontsManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontsManager)‑klasse. FontsManager beheert lettertypen in de hele presentatie.

Elke [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) heeft een [getFontsManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getFontsManager--)‑methode met zijn eigen instantie van de [FontsManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontsManager)‑klasse.

Hier volgt een voorbeeld hoe u een collectie van fallback‑lettertype‑regels maakt en deze toewijst aan de [FontsManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getFontsManager--) van een bepaalde presentatie:  

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}} 
Lees meer over hoe u een [Presentatie renderen met fallback‑lettertype](/slides/nl/java/render-presentation-with-fallback-font/) kunt.
{{% /alert %}}

## **Veelgestelde vragen**

### Worden mijn fallback‑regels ingebed in het PPTX‑bestand en zichtbaar in PowerPoint na het opslaan?

Nee. Fallback‑regels zijn instellingen voor het renderen tijdens runtime; ze worden niet geserialiseerd naar PPTX en verschijnen niet in de gebruikersinterface van PowerPoint.

### Wordt fallback toegepast op tekst binnen SmartArt, WordArt, grafieken en tabellen?

Ja. Hetzelfde glyph‑substitutiemechanisme wordt gebruikt voor alle tekst in deze objecten.

### Distribueert Aspose lettertypen met de bibliotheek?

Nee. U voegt lettertypen toe en gebruikt ze zelf, onder uw eigen verantwoordelijkheid.

### Kunnen vervanging/substitutie voor ontbrekende lettertypen en fallback voor ontbrekende glyphs samen worden gebruikt?

Ja. Het zijn onafhankelijke stappen in dezelfde pipeline voor font‑resolutie: eerst bepaalt de engine de beschikbaarheid van lettertypen ([replacement](/slides/nl/java/font-replacement/)/[substitution](/slides/nl/java/font-substitution/)), daarna vult fallback de ontbrekende glyphs in de beschikbare lettertypen aan.