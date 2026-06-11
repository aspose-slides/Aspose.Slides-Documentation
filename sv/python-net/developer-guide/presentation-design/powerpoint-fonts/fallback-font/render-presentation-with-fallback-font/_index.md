---
title: Rendera presentationer med fallback-typsnitt i Python
linktitle: Rendera presentationer
type: docs
weight: 30
url: /sv/python-net/render-presentation-with-fallback-font/
keywords:
- fallback-typsnitt
- rendera PowerPoint
- rendera presentation
- rendera bild
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Rendera presentationer med fallback-typsnitt i Aspose.Slides för Python via .NET – behåll texten konsekvent i PPT, PPTX och ODP med steg-för-steg kodexempel."
---
## **Översikt**

Aspose.Slides låter dig rendera presentationer med hjälp av fallback fontregler. Den här artikeln visar hur du skapar en samling av fallback fontregler, ändrar dess regler genom att ta bort eller lägga till fallback‑teckensnitt, och tilldelar samlingen till egenskapen `FontsManager.font_fall_back_rules_collection`.

När samlingen av fallback fontregler har tilldelats presentationens `fonts_manager` tillämpas reglerna under operationer som att spara, rendera och konvertera presentationen. Exemplet visar hur de konfigurerade reglerna används när en bild av en bildspelssida renderas och sparas som en PNG‑bild.

## **Rendera en bild med fallback fontregler**

Följande exempel innehåller dessa steg:

1. Vi [skapar en samling av fallback fontregler](/slides/sv/python-net/create-fallback-fonts-collection/).
1. [Ta bort](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontfallbackrule/remove/) en fallback fontregel och [add_fall_back_fonts](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) till en annan regel.
1. Ange reglernas samling till egenskapen [FontsManager.font_fall_back_rules_collection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/).
1. Med metoden [Presentation.save()](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) kan vi spara presentationen i samma format, eller spara den i ett annat. Efter att samlingen av fallback fontregler har satts på FontsManager tillämpas dessa regler under alla operationer på presentationen: spara, rendera, konvertera osv.

```py
import aspose.slides as slides

# Skapa en ny instans av en reglersamling
rulesList = slides.FontFallBackRulesCollection()

# skapa ett antal regler
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	#Försöker ta bort fallback-typsnittet "Tahoma" från laddade regler
	fallBackRule.remove("Tahoma")

	#Och uppdatera regler för angivet intervall
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

#Vi kan också ta bort befintliga regler från listan
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	#Tilldelar en förberedd regellista för användning
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# Renderar en miniatyrbild med den initierade reglersamlingen och sparar till PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert color="primary" %}} 
Läs mer om hur du [konverterar PowerPoint Slides to PNG in Python](/slides/sv/python-net/convert-powerpoint-to-png/).
{{% /alert %}}