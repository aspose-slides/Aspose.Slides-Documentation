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

Aspose.Slides stelt u in staat om een collectie fallback‑lettertype‑regels voor een presentatie te configureren. Elke fallback‑regel wordt vertegenwoordigd door de `FontFallBackRule`‑klasse en kan worden toegevoegd aan een `FontFallBackRulesCollection`, die de `IFontFallBackRulesCollection`‑interface implementeert.

Nadat u de collectie heeft aangemaakt, kunt u deze toewijzen aan de `FontFallBackRulesCollection`‑eigenschap van de `FontsManager` van de presentatie. De `FontsManager` regelt lettertypen in de hele presentatie, en elke `Presentation`‑instantie heeft zijn eigen `FontsManager`.

Zodra de `FontsManager` is geïnitialiseerd met de fallback‑lettertype‑collectie, worden de opgegeven fallback‑lettertypen toegepast tijdens het renderen van de presentatie.

## **Fallback‑regels toepassen**

Instanties van de [FontFallBackRule](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRule)‑klasse kunnen worden georganiseerd in een [FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRulesCollection), die de [IFontFallBackRulesCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IFontFallBackRulesCollection)‑interface implementeert. Het is mogelijk om regels toe te voegen aan of te verwijderen uit de collectie.

Vervolgens kan deze collectie worden toegewezen aan de [FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontFallBackRulesCollection)‑methode van de [FontsManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontsManager)‑klasse. FontsManager regelt de lettertypen in de hele presentatie.

Elke [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) heeft een [getFontsManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getFontsManager--)‑methode met zijn eigen instantie van de [FontsManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FontsManager)‑klasse.

Hier volgt een voorbeeld hoe u een collectie fallback‑lettertype‑regels maakt en deze toewijst aan de [FontsManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getFontsManager--) van een bepaalde presentatie:

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
Lees meer over hoe u een presentatie rendert met fallback‑lettertype[/slides/nl/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Worden mijn fallback‑regels ingebed in het PPTX‑bestand en zichtbaar in PowerPoint na het opslaan?**

Nee. Fallback‑regels zijn runtime‑renderinstellingen; ze worden niet geserialiseerd in het PPTX‑bestand en verschijnen niet in de UI van PowerPoint.

**Is fallback van toepassing op tekst binnen SmartArt, WordArt, grafieken en tabellen?**

Ja. Hetzelfde glyph‑substitutie‑mechanisme wordt gebruikt voor alle tekst in deze objecten.

**Distribueert Aspose lettertypen met de bibliotheek?**

Nee. U voegt lettertypen toe en gebruikt ze aan uw kant en onder uw eigen verantwoordelijkheid.

**Kunnen vervanging/substitutie voor ontbrekende lettertypen en fallback voor ontbrekende glyphs samen worden gebruikt?**

Ja. Het zijn onafhankelijke stadia van dezelfde lettertype‑resolutiepijplijn: eerst bepaalt de engine de beschikbaarheid van lettertypen ([vervanging](/slides/nl/androidjava/font-replacement/)/[substitutie](/slides/nl/androidjava/font-substitution/)), daarna vult fallback de hiaten voor ontbrekende glyphs in beschikbare lettertypen.