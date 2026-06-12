---
title: Configureer fallback-lettertypecollecties in .NET
linktitle: Fallback-lettertypecollectie
type: docs
weight: 20
url: /nl/net/create-fallback-fonts-collection/
keywords:
- fallback-lettertype
- fallback-regel
- lettertypecollectie
- lettertype configureren
- lettertype instellen
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Stel een fallback-lettertypecollectie in Aspose.Slides voor .NET in om tekst consistent en scherp te houden in PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Aspose.Slides stelt u in staat om een collectie fallback‑lettertype‑regels voor een presentatie te configureren. Elke fallback‑regel wordt weergegeven door de `FontFallBackRule`‑klasse en kan worden toegevoegd aan een `FontFallBackRulesCollection`, die de `IFontFallBackRulesCollection`‑interface implementeert.

Na het aanmaken van de collectie kunt u deze toewijzen aan de `FontFallBackRulesCollection`‑eigenschap van de `FontsManager` van de presentatie. De `FontsManager` beheert lettertypen in de hele presentatie, en elke `Presentation`‑instantie heeft zijn eigen `FontsManager`.

Zodra de `FontsManager` is geïnitialiseerd met de fallback‑lettertype‑collectie, worden de opgegeven fallback‑lettertypen toegepast tijdens het renderen van de presentatie.

## **Fallback‑regels toepassen**

Instanties van de [FontFallBackRule](https://reference.aspose.com/slides/nl/net/aspose.slides/FontFallBackRule)‑klasse kunnen worden gegroepeerd in een [FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/fontfallbackrulescollection), die de [IFontFallBackRulesCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/ifontfallbackrulescollection)‑interface implementeert. Het is mogelijk om regels toe te voegen aan of te verwijderen uit de collectie.

Vervolgens kan deze collectie worden toegewezen aan de [FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)‑eigenschap van de [FontsManager](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager)‑klasse. De FontsManager beheert lettertypen in de hele presentatie.

Elke [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) heeft een [FontsManager](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/properties/fontsmanager)‑eigenschap met zijn eigen instantie van de FontsManager‑klasse.

Hier volgt een voorbeeld hoe u een collectie fallback‑lettertype‑regels kunt maken en toewijzen aan de FontsManager van een bepaalde presentatie:  

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

Nadat de FontsManager is geïnitialiseerd met de fallback‑lettertype‑collectie, worden de fallback‑lettertypen toegepast tijdens het renderen van de presentatie.

{{% alert color="primary" %}} 
Lees meer over hoe u [Render Presentation with Fallback Font](/slides/nl/net/render-presentation-with-fallback-font/) kunt renderen.
{{% /alert %}}

## **FAQ**

**Wordt mijn fallback‑regels ingebed in het PPTX‑bestand en zichtbaar in PowerPoint na het opslaan?**

Nee. Fallback‑regels zijn runtime‑renderinstellingen; ze worden niet geserialiseerd naar PPTX en verschijnen niet in de gebruikersinterface van PowerPoint.

**Is fallback ook van toepassing op tekst in SmartArt, WordArt, grafieken en tabellen?**

Ja. Hetzelfde glyph‑substitutiemechanisme wordt gebruikt voor alle tekst in deze objecten.

**Distribueert Aspose lettertypen met de bibliotheek?**

Nee. U voegt lettertypen toe en gebruikt ze zelf, onder uw eigen verantwoordelijkheid.

**Kunnen vervanging/substitutie voor ontbrekende lettertypen en fallback voor ontbrekende glyphs samen worden gebruikt?**

Ja. Ze zijn onafhankelijke stappen in dezelfde lettertype‑resolutiepijplijn: eerst lost de engine de beschikbaarheid van lettertypen op ([replacement](/slides/nl/net/font-replacement/)/[substitution](/slides/nl/net/font-substitution/)), daarna vult fallback de leemtes op voor ontbrekende glyphs in de beschikbare lettertypen.