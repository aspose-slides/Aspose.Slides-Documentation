---
title: Configureer fallback-lettertypecollecties op Android
linktitle: Fallback-lettertypecollectie
type: docs
weight: 20
url: /nl/androidjava/create-fallback-fonts-collection/
keywords:
- fallback-lettertype
- fallback-regel
- lettertypecollectie
- lettertype configureren
- lettertype instellen
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Stel een fallback-lettertypecollectie in Aspose.Slides voor Android via Java in om tekst consistent en scherp te houden in PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Aspose.Slides stelt u in staat om een verzameling fallback‑lettertype‑regels voor een presentatie te configureren. Elke fallback‑regel wordt weergegeven door de `FontFallBackRule`‑klasse en kan worden toegevoegd aan een `FontFallBackRulesCollection`, die de `IFontFallBackRulesCollection`‑interface implementeert.

Nadat u de collectie hebt aangemaakt, kunt u deze toewijzen aan de `FontFallBackRulesCollection`‑eigenschap van de `FontsManager` van de presentatie. De `FontsManager` beheert lettertypen in de hele presentatie, en elke `Presentation`‑instantie heeft zijn eigen `FontsManager`.

Zodra de `FontsManager` is geinitialiseerd met de fallback‑lettertype‑collectie, worden de opgegeven fallback‑lettertypen toegepast tijdens het renderen van de presentatie.

## **Fallbackregels toepassen**

Instanties van de [FontFallBackRule](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRule)‑klasse kunnen worden georganiseerd in een [FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRulesCollection), die de [IFontFallBackRulesCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IFontFallBackRulesCollection)‑interface implementeert. Het is mogelijk om regels toe te voegen of te verwijderen uit de collectie.

Vervolgens kan deze collectie worden toegewezen aan de [FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRulesCollection)‑methode van de [FontsManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontsManager)‑klasse. De FontsManager beheert lettertypen in de hele presentatie.

Elke [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) heeft een [getFontsManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getFontsManager--)‑methode met zijn eigen instantie van de [FontsManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontsManager)‑klasse.

Hier volgt een voorbeeld hoe u een collectie fallback‑lettertype‑regels kunt maken en deze kunt toewijzen aan de [FontsManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getFontsManager--) van een bepaalde presentatie:

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
Lees meer over hoe u een [Presentatie renderen met fallback‑lettertype](/slides/nl/androidjava/render-presentation-with-fallback-font/) .
{{% /alert %}}

## **FAQ**

### Worden mijn fallback‑regels in het PPTX‑bestand ingebed en zichtbaar in PowerPoint na het opslaan?

Nee. Fallback‑regels zijn runtime‑renderingsinstellingen; ze worden niet geserialiseerd naar PPTX en verschijnen niet in de PowerPoint‑interface.

### Wordt fallback toegepast op tekst binnen SmartArt, WordArt, grafieken en tabellen?

Ja. Hetzelfde glyph‑substitutiemechanisme wordt gebruikt voor alle tekst in deze objecten.

### Distribueert Aspose lettertypen mee met de bibliotheek?

Nee. U voegt zelf lettertypen toe en gebruikt ze op uw eigen verantwoordelijkheid.

### Kunnen vervanging/substitutie voor ontbrekende lettertypen en fallback voor ontbrekende glyphs samen worden gebruikt?

Ja. Het zijn onafhankelijke fasen van dezelfde lettertype‑resolutiepijplijn: eerst bepaalt de engine de beschikbaarheid van lettertypen ([replacement](/slides/nl/androidjava/font-replacement/)/[substitution](/slides/nl/androidjava/font-substitution/)), daarna vult fallback de ontbrekende glyphs op in de beschikbare lettertypen.