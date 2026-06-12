---
title: Fallback-lettertypecollecties configureren in Python
linktitle: Fallback-lettertypecollectie
type: docs
weight: 20
url: /nl/python-net/create-fallback-fonts-collection/
keywords:
- fallback-lettertype
- fallback-regel
- lettertypecollectie
- lettertype configureren
- lettertype instellen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Stel een collectie van fallback-lettertypen in Aspose.Slides voor Python via .NET in om tekst consistent en scherp te houden in PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Aspose.Slides stelt u in staat een collectie van fallback‑lettertype‑regels voor een presentatie te configureren. Elke fallback‑regel wordt vertegenwoordigd door de `FontFallBackRule`‑klasse en kan worden toegevoegd aan een `FontFallBackRulesCollection`.

Nadat u de collectie hebt aangemaakt, kunt u deze toewijzen aan de eigenschap `font_fall_back_rules_collection` van de `fonts_manager` van de presentatie. De `fonts_manager` beheert lettertypen in de hele presentatie, en elke `Presentation`‑instantie heeft zijn eigen `FontsManager`.

Zodra de `FontsManager` is geïnitialiseerd met de fallback‑lettertype‑collectie, worden de opgegeven fallback‑lettertypen toegepast tijdens het renderen van de presentatie.

## **Fallback‑regels toepassen**

Instanties van de klasse [FontFallBackRule](https://reference.aspose.com/slides/nl/python-net/aspose.slides/FontFallBackRule/) kunnen worden georganiseerd in een [FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontfallbackrulescollection/). Het is mogelijk om regels toe te voegen aan of te verwijderen uit de collectie.

Vervolgens kan deze collectie worden toegewezen aan de eigenschap [font_fall_back_rules_collection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) van de klasse [FontsManager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/). De FontsManager beheert lettertypen in de hele presentatie.

Elke [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) heeft een eigenschap [fonts_manager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/fonts_manager/) met zijn eigen instantie van de FontsManager‑klasse.

Hier is een voorbeeld hoe u een collectie van fallback‑lettertype‑regels kunt maken en deze toewijst aan de FontsManager van een bepaalde presentatie:  

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

Nadat de FontsManager is geïnitialiseerd met de fallback‑lettertype‑collectie, worden de fallback‑lettertypen toegepast tijdens het renderen van de presentatie.

{{% alert color="primary" %}} 
Lees meer over hoe u een [Presentatie renderen met fallback‑lettertype](/slides/nl/python-net/render-presentation-with-fallback-font/) kunt.
{{% /alert %}}

## **Veelgestelde vragen**

**Worden mijn fallback‑regels ingebed in het PPTX‑bestand en zichtbaar in PowerPoint na het opslaan?**

Nee. Fallback‑regels zijn runtime‑renderingsinstellingen; ze worden niet geserialized naar het PPTX‑bestand en zullen niet verschijnen in de PowerPoint‑interface.

**Wordt fallback toegepast op tekst binnen SmartArt, WordArt, grafieken en tabellen?**

Ja. Hetzelfde glyph‑substitutiemechanisme wordt gebruikt voor alle tekst in deze objecten.

**Verspreidt Aspose lettertypen mee met de bibliotheek?**

Nee. U voegt lettertypen toe en gebruikt ze zelf, onder uw eigen verantwoordelijkheid.

**Kunnen vervanging/substitutie voor ontbrekende lettertypen en fallback voor ontbrekende glyphs samen worden gebruikt?**

Ja. Ze zijn onafhankelijke fasen van dezelfde lettertype‑resolutiepijplijn: eerst lost de engine de beschikbaarheid van lettertypen op ([replacement](/slides/nl/python-net/font-replacement/)/[substitution](/slides/nl/python-net/font-substitution/)), vervolgens vult fallback de gaten voor ontbrekende glyphs in beschikbare lettertypen.