---
title: Render presentaties met fallback-lettertypen in Python
linktitle: Render presentaties
type: docs
weight: 30
url: /nl/python-net/render-presentation-with-fallback-font/
keywords:
- fallback-lettertype
- PowerPoint weergeven
- presentatie weergeven
- dia weergeven
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Render presentaties met fallback-lettertypen in Aspose.Slides voor Python via .NET - houd de tekst consistent over PPT, PPTX en ODP met stapsgewijze codevoorbeelden."
---
## **Overzicht**

Aspose.Slides stelt u in staat presentaties weer te geven met behulp van fallback‑lettertype‑regels. Dit artikel laat zien hoe u een collectie van fallback‑lettertype‑regels maakt, de regels wijzigt door fallback‑lettertypen te verwijderen of toe te voegen, en de collectie toewijst aan de eigenschap `FontsManager.font_fall_back_rules_collection`.

Zodra de collectie fallback‑lettertype‑regels is toegewezen aan de `fonts_manager` van de presentatie, worden de regels toegepast tijdens bewerkingen zoals opslaan, renderen en converteren van de presentatie. Het voorbeeld toont hoe u de geconfigureerde regels gebruikt bij het renderen van een miniatuur van een dia en het opslaan ervan als PNG‑afbeelding.

## **Een dia renderen met fallback‑lettertype‑regels**

Het volgende voorbeeld omvat deze stappen:

1. We [maken een collectie van fallback‑lettertype‑regels](/slides/nl/python-net/create-fallback-fonts-collection/).
1. [Verwijder](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontfallbackrule/remove/) een fallback‑lettertype‑regel en [add_fall_back_fonts](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) aan een andere regel.
1. Stel de regels‑collectie in op de eigenschap [FontsManager.font_fall_back_rules_collection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/).
1. Met de [Presentation.save()](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑methode kunnen we de presentatie opslaan in hetzelfde formaat, of in een ander formaat. Nadat de collectie fallback‑lettertype‑regels is ingesteld op FontsManager, worden deze regels toegepast bij elke bewerking op de presentatie: opslaan, renderen, converteren, enz.

```py
import aspose.slides as slides

# Maak een nieuw exemplaar van een regelsverzameling
rulesList = slides.FontFallBackRulesCollection()

# maak een aantal regels
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# Probeer fallback-lettertype "Tahoma" te verwijderen uit de geladen regels
	fallBackRule.remove("Tahoma")

	# En om de regels bij te werken voor het opgegeven bereik
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

# We kunnen ook bestaande regels uit de lijst verwijderen
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# De voorbereide regelslijst toewijzen voor gebruik
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# Miniatuur renderen met de geïnitialiseerde regelsverzameling en opslaan als PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```


{{% alert color="primary" %}} 
Lees meer over hoe u [PowerPoint‑dia's naar PNG converteert in Python](/slides/nl/python-net/convert-powerpoint-to-png/).
{{% /alert %}}