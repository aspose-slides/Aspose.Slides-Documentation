---
title: Configureer fallback-lettertype-collecties in .NET
linktitle: Fallback-lettertype-collectie
type: docs
weight: 20
url: /nl/net/create-fallback-fonts-collection/
keywords:
- fallback-lettertype
- fallback-regel
- lettertype-collectie
- lettertype configureren
- lettertype instellen
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Stel een fallback-lettertype-collectie in Aspose.Slides voor .NET in om tekst consistent en scherp te houden in PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Aspose.Slides stelt u in staat een collectie van fallback‑lettertype‑regels voor een presentatie te configureren. Elke fallback‑regel wordt vertegenwoordigd door de `FontFallBackRule`‑klasse en kan worden toegevoegd aan een `FontFallBackRulesCollection`, die de `IFontFallBackRulesCollection`‑interface implementeert.

Nadat u de collectie hebt gemaakt, kunt u deze toewijzen aan de `FontFallBackRulesCollection`‑eigenschap van de `FontsManager` van de presentatie. De `FontsManager` beheert lettertypen in de gehele presentatie, en elke `Presentation`‑instantie heeft zijn eigen `FontsManager`.

Zodra de `FontsManager` is geïnitialiseerd met de fallback‑lettertype‑collectie, worden de opgegeven fallback‑lettertypen toegepast tijdens het renderen van de presentatie.

## **Fallback‑regels toepassen**

Instanties van de [FontFallBackRule](https://reference.aspose.com/slides/nl/net/aspose.slides/FontFallBackRule)‑klasse kunnen worden georganiseerd in een [FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/fontfallbackrulescollection), die de [IFontFallBackRulesCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/ifontfallbackrulescollection)‑interface implementeert. Het is mogelijk om regels aan de collectie toe te voegen of te verwijderen.

Vervolgens kan deze collectie worden toegewezen aan de [FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)‑eigenschap van de [FontsManager](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager)‑klasse. De FontsManager beheert lettertypen in de gehele presentatie.

Elke [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑instantie heeft een [FontsManager](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/properties/fontsmanager)‑eigenschap met zijn eigen instantie van de FontsManager‑klasse.

Hier volgt een voorbeeld hoe u een collectie van fallback‑lettertype‑regels kunt maken en deze kunt toewijzen aan de FontsManager van een bepaalde presentatie:  

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

Nadat de FontsManager is geïnitialiseerd met de fallback‑lettertype‑collectie, worden de fallback‑lettertypen toegepast tijdens het renderen van de presentatie.

{{% alert color="info" %}} 
[Presentatie renderen met fallback‑lettertype](/slides/nl/net/render-presentation-with-fallback-font/) 
{{% /alert %}}

## **FAQ**

### Worden mijn fallback‑regels in het PPTX‑bestand ingebed en zichtbaar in PowerPoint na het opslaan?

Nee. Fallback‑regels zijn instellingen voor weergave tijdens uitvoering; ze worden niet geserialiseerd naar PPTX en verschijnen niet in de gebruikersinterface van PowerPoint.

### Wordt fallback toegepast op tekst binnen SmartArt, WordArt, grafieken en tabellen?

Ja. Hetzelfde glyf‑substitutiemechanisme wordt gebruikt voor alle tekst in deze objecten.

### Distribueert Aspose enige lettertypen met de bibliotheek?

Nee. U voegt zelf lettertypen toe en gebruikt ze, onder uw eigen verantwoordelijkheid.

### Kunnen vervanging/substitutie voor ontbrekende lettertypen en fallback voor ontbrekende glyfen samen worden gebruikt?

Ja. Ze zijn onafhankelijke fasen van dezelfde lettertype‑resolutie‑pipeline: eerst bepaalt de engine de beschikbaarheid van lettertypen ([vervanging](/slides/nl/net/font-replacement/)/[substitutie](/slides/nl/net/font-substitution/)), daarna vult fallback de leemtes voor ontbrekende glyfen in beschikbare lettertypen.