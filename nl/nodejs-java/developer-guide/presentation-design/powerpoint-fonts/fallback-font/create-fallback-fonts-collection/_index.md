---
title: Fallback-lettertypecollecties configureren in JavaScript
linktitle: Fallback-lettertypecollectie
type: docs
weight: 20
url: /nl/nodejs-java/create-fallback-fonts-collection/
keywords:
- fallback lettertype
- fallback regel
- lettertypecollectie
- lettertype configureren
- lettertype instellen
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Stel een fallback-lettertypecollectie in JavaScript in met Aspose.Slides voor Node.js om tekst consistent en scherp te houden in PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Aspose.Slides stelt u in staat om een verzameling fallback‑lettertype‑regels voor een presentatie te configureren. Elke fallback‑regel wordt vertegenwoordigd door de `FontFallBackRule`‑klasse en kan worden toegevoegd aan een `FontFallBackRulesCollection`.

Nadat u de verzameling hebt aangemaakt, kunt u deze toewijzen via de `setFontFallBackRulesCollection`‑methode van de `FontsManager` van de presentatie. De `FontsManager` beheert lettertypen in de gehele presentatie, en elk `Presentation`‑object heeft zijn eigen `FontsManager`.

Zodra de `FontsManager` is geïnitialiseerd met de fallback‑lettertype‑verzameling, worden de opgegeven fallback‑lettertypen toegepast tijdens het renderen van de presentatie.

## **Fallback‑regels toepassen**

Instanties van [FontFallBackRule](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FontFallBackRule)‑klasse kunnen worden georganiseerd in [FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FontFallBackRulesCollection), die de [FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FontFallBackRulesCollection)‑klasse implementeert. Het is mogelijk om regels toe te voegen aan of te verwijderen uit de verzameling.

Vervolgens kan deze verzameling worden toegewezen aan de [FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FontFallBackRulesCollection)‑methode van de [FontsManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FontsManager)‑klasse. FontsManager beheert lettertypen in de gehele presentatie.

Elke [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) heeft een [getFontsManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getFontsManager--)‑methode met zijn eigen instantie van de [FontsManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FontsManager)‑klasse.

Hier volgt een voorbeeld hoe u een collectie fallback‑lettertype‑regels kunt maken en toewijzen aan de [FontsManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getFontsManager--) van een bepaalde presentatie:  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var userRulesList = new aspose.slides.FontFallBackRulesCollection();
    userRulesList.add(new aspose.slides.FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    userRulesList.add(new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Nadat FontsManager is geïnitialiseerd met de fallback‑lettertype‑collectie, worden de fallback‑lettertypen toegepast tijdens het renderen van de presentatie.

{{% alert color="primary" %}} 
Lees meer over hoe u een presentatie rendert met fallback‑lettertype[/slides/nl/nodejs-java/render-presentation-with-fallback-font/].
{{% /alert %}}

## **Veelgestelde vragen**

**Worden mijn fallback‑regels in het PPTX‑bestand ingebed en zichtbaar in PowerPoint na het opslaan?**

Nee. Fallback‑regels zijn runtime‑renderingsinstellingen; ze worden niet geserialiseerd naar PPTX en verschijnen niet in de gebruikersinterface van PowerPoint.

**Zijn fallback‑regels van toepassing op tekst binnen SmartArt, WordArt, grafieken en tabellen?**

Ja. Hetzelfde glyf‑substitutiemechanisme wordt gebruikt voor alle tekst in deze objecten.

**Distribueert Aspose lettertypen met de bibliotheek?**

Nee. U voegt zelf lettertypen toe en gebruikt ze onder uw eigen verantwoordelijkheid.

**Kunnen vervanging/substitutie voor ontbrekende lettertypen en fallback voor ontbrekende glyphs samen worden gebruikt?**

Ja. Ze zijn onafhankelijke stadia van dezelfde lettertype‑resolutiepijplijn: eerst lost de engine de beschikbaarheid van lettertypen op ([vervanging](/slides/nl/nodejs-java/font-replacement/)/[substitutie](/slides/nl/nodejs-java/font-substitution/)), daarna vult fallback de leemtes voor ontbrekende glyphs in beschikbare lettertypen.