---
title: Configureer fallback-lettertypecollecties in Python via Java
linktitle: Fallback-lettertypecollectie
type: docs
weight: 20
url: /nl/python-java/create-fallback-fonts-collection/
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
- Java
- Aspose.Slides
description: "Stel een fallback-lettertypecollectie in Aspose.Slides voor Python via Java in om tekst consistent en scherp te houden in PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Aspose.Slides stelt u in staat om een collectie van fallback‑lettertype‑regels voor een presentatie te configureren. Elke fallback‑regel wordt weergegeven door de klasse [FontFallBackRule](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontfallbackrule/) en kan worden toegevoegd aan een [FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontfallbackrulescollection/).

Na het maken van de collectie kunt u deze toewijzen met behulp van de methode [setFontFallBackRulesCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) van de [FontsManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/) van de presentatie. De [FontsManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/) beheert lettertypen voor de gehele presentatie, en elke [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑instantie heeft zijn eigen [FontsManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/).

Zodra de [FontsManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/) is geïnitialiseerd met de fallback‑lettertype‑collectie, worden de opgegeven fallback‑lettertypen toegepast tijdens het renderen van de presentatie.

## **Fallback‑regels toepassen**

Instanties van de klasse [FontFallBackRule](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontfallbackrule/) kunnen worden georganiseerd in een [FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontfallbackrulescollection/). U kunt regels aan de collectie toevoegen of ervan verwijderen.

Deze collectie kan vervolgens worden toegewezen met behulp van de methode [setFontFallBackRulesCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) van de klasse [FontsManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/), die de lettertypen voor de gehele presentatie beheert.

Elke [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) heeft een methode [getFontsManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getFontsManager) die zijn eigen instantie van de klasse [FontsManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/) retourneert.

Het volgende voorbeeld toont hoe u een collectie van fallback‑lettertype‑regels kunt maken en deze kunt toewijzen aan de [FontsManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/) van een presentatie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, Presentation

presentation = Presentation()
try:
    fallback_rules = FontFallBackRulesCollection()

    tamil_rule = FontFallBackRule(0x0B80, 0x0BFF, "Vijaya")
    fallback_rules.add(tamil_rule)
    hiragana_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")
    fallback_rules.add(hiragana_rule)

    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)
finally:
    presentation.dispose()
```

Na het initialiseren van de [FontsManager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/) met de fallback‑lettertype‑collectie, worden de fallback‑lettertypen toegepast tijdens het renderen van de presentatie.

{{% alert color="info" title="Note" %}}
Lees meer over hoe u een presentatie kunt renderen met een fallback‑lettertype[/slides/nl/python-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Worden mijn fallback‑regels in het PPTX‑bestand ingebed en zichtbaar in PowerPoint na het opslaan?**

Nee. Fallback‑regels zijn runtime‑renderingsinstellingen; ze worden niet geserialiseerd in het PPTX‑bestand en zullen niet zichtbaar zijn in de PowerPoint‑interface.

**Is fallback van toepassing op tekst binnen SmartArt, WordArt, grafieken en tabellen?**

Ja. Hetzelfde glyph‑substitutiemechanisme wordt gebruikt voor alle tekst in deze objecten.

**Distribueert Aspose lettertypen met de bibliotheek?**

Nee. U voegt lettertypen toe en gebruikt ze aan uw kant en onder uw eigen verantwoordelijkheid.

**Kunnen vervanging/substitutie voor ontbrekende lettertypen en fallback voor ontbrekende glyphs samen worden gebruikt?**

Ja. Ze zijn onafhankelijke fasen van dezelfde font‑resolutie‑pipeline: eerst lost de engine de beschikbaarheid van lettertypen op ([replacement](/slides/nl/python-java/font-replacement/)/[substitution](/slides/nl/python-java/font-substitution/)), vervolgens vult fallback de gaten voor ontbrekende glyphs in beschikbare lettertypen.