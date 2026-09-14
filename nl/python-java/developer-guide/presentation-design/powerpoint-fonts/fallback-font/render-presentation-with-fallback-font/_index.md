---
title: Presentaties renderen met fallback-lettertypen in Python via Java
linktitle: Presentaties renderen
type: docs
weight: 30
url: /nl/python-java/render-presentation-with-fallback-font/
keywords:
- fallback-lettertype
- PowerPoint renderen
- presentatie renderen
- dia renderen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Render presentaties met fallback-lettertypen in Aspose.Slides voor Python via Java – houd tekst consistent over PPT, PPTX en ODP met stapsgewijze Python-codevoorbeelden."
---
## **Overzicht**

Aspose.Slides stelt je in staat presentaties te renderen met behulp van fallback‑lettertype‑regels. Dit artikel laat zien hoe je een collectie van fallback‑lettertype‑regels maakt, de regels wijzigt door fallback‑lettertypen te verwijderen of toe te voegen, en de collectie toewijst met de [FontsManager.setFontFallBackRulesCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection)‑methode.

Zodra de collectie van fallback‑lettertype‑regels is toegewezen aan de [FontsManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/) van de presentatie, worden de regels toegepast tijdens bewerkingen zoals opslaan, renderen en converteren van de presentatie. Het voorbeeld toont hoe de geconfigureerde regels te gebruiken bij het renderen van een dia‑miniatuur en het opslaan als een JPEG‑afbeelding.

## **Dia renderen met fallback‑lettertype‑regels**

Het volgende voorbeeld bevat deze stappen:

1. [Maak een fallback‑lettertype‑regelscollectie](/slides/nl/python-java/create-fallback-fonts-collection/).
1. [Verwijder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontfallbackrule/#remove) een fallback‑lettertype uit een regel en [voeg fallback‑lettertypen toe](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) aan een andere regel.
1. Wijs de regelscollectie toe met [setFontFallBackRulesCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) op de font‑manager die wordt geretourneerd door [getFontsManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getFontsManager).
1. Gebruik de [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save)‑methode om de presentatie op te slaan in hetzelfde formaat of een ander formaat. Nadat de collectie van fallback‑lettertype‑regels is toegewezen aan [FontsManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/), worden deze regels toegepast tijdens bewerkingen op de presentatie: opslaan, renderen, converteren, enzovoort.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# Maak een nieuwe regelscollectie aan.
fallback_rules = FontFallBackRulesCollection()

# Maak verschillende regels aan.
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # Probeer het fallback-lettertype "Tahoma" uit de regels te verwijderen.
    fallback_rule.remove("Tahoma")

    # Werk de regels bij voor het opgegeven bereik.
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# Verwijder een bestaande regel, maar behoud minimaal één regel voor het renderen.
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # Ken de voorbereide regelscollectie toe.
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # Render een miniatuur met behulp van de geconfigureerde regelscollectie.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Sla de afbeelding op schijf op in JPEG-formaat.
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Lees meer over hoe je [PPT en PPTX naar JPG converteert in Python via Java](/slides/nl/python-java/convert-powerpoint-to-jpg/).
{{% /alert %}}