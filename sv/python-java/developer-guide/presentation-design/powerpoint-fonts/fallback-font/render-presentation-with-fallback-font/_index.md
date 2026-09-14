---
title: Rendera presentationer med fallback‑typsnitt i Python via Java
linktitle: Rendera presentationer
type: docs
weight: 30
url: /sv/python-java/render-presentation-with-fallback-font/
keywords:
- fallback‑typsnitt
- rendera PowerPoint
- rendera presentation
- rendera bild
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Rendera presentationer med fallback‑typsnitt i Aspose.Slides för Python via Java – håll texten konsekvent i PPT, PPTX och ODP med steg‑för‑steg Python‑kodexempel."
---
## **Översikt**

Aspose.Slides låter dig rendera presentationer med fallback‑teckensnittsregler. Den här artikeln visar hur du skapar en samling av fallback‑teckensnittsregler, ändrar dess regler genom att ta bort eller lägga till fallback‑teckensnitt, och tilldelar samlingen med metoden [FontsManager.setFontFallBackRulesCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection).

När samlingen av fallback‑teckensnittsregler har tilldelats presentationens [FontsManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/), tillämpas reglerna under operationer som att spara, rendera och konvertera presentationen. Exemplet visar hur man använder de konfigurerade reglerna när man renderar en bild av en bildspelsbild och sparar den som en JPEG‑bild.

## **Rendera en bild med fallback‑teckensnittsregler**

Följande exempel innehåller dessa steg:

1. [Skapa en samling av fallback‑teckensnittsregler](/slides/sv/python-java/create-fallback-fonts-collection/).
2. [Ta bort](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontfallbackrule/#remove) en fallback‑teckensnitt från en regel och [lägg till fallback‑teckensnitt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) till en annan regel.
3. Tilldela samlingen av regler med [setFontFallBackRulesCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) på teckensnittshanteraren som returneras av [getFontsManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getFontsManager).
4. Använd [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) metoden för att spara presentationen i samma format eller ett annat format. Efter att samlingen av fallback‑teckensnittsregler har tilldelats [FontsManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/), tillämpas dessa regler under operationer på presentationen: sparning, rendering, konvertering, med mera.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# Skapa en ny regelssamling.
fallback_rules = FontFallBackRulesCollection()

# Skapa flera regler.
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # Försök att ta bort fallback‑typsnittet "Tahoma" från reglerna.
    fallback_rule.remove("Tahoma")

    # Uppdatera reglerna för det angivna intervallet.
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# Ta bort en befintlig regel, behåll åtminstone en regel för rendering.
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # Tilldela den förberedda regelssamlingen.
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # Rendera en miniatyrbild med den konfigurerade regelssamlingen.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Spara bilden till disk i JPEG‑format.
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Obs" %}}
Läs mer om hur du [konvertera PPT och PPTX till JPG i Python via Java](/slides/sv/python-java/convert-powerpoint-to-jpg/).
{{% /alert %}}