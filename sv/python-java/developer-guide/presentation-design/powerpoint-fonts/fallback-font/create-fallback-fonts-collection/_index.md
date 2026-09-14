---
title: Konfigurera reservtypsnittssamlingar i Python via Java
linktitle: Reservtypsnittssamling
type: docs
weight: 20
url: /sv/python-java/create-fallback-fonts-collection/
keywords:
- reservtypsnitt
- reservtypsnittregel
- typsnittssamling
- konfigurera typsnitt
- installera typsnitt
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Ställ in en reservtypsnittssamling i Aspose.Slides för Python via Java för att hålla texten konsekvent och skarp i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Aspose.Slides låter dig konfigurera en samling av reservtypsnittregler för en presentation. Varje reservtypsnittregel representeras av klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontfallbackrule/) och kan läggas till i en [FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontfallbackrulescollection/).

Efter att du har skapat samlingen kan du tilldela den med metoden [setFontFallBackRulesCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) för presentationens [FontsManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/). [FontsManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/) styr typsnitt i hela presentationen, och varje [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)‑instans har sin egen [FontsManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/).

När [FontsManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/) har initierats med reservtypsnittssamlingen tillämpas de angivna reservtypsnitten under rendering av presentationen.

## **Tillämpa reservtypsnittregler**

Instanser av klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontfallbackrule/) kan organiseras i en [FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontfallbackrulescollection/). Du kan lägga till eller ta bort regler från samlingen.

Denna samling kan sedan tilldelas med metoden [setFontFallBackRulesCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) i klassen [FontsManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/), som styr typsnitt i hela presentationen.

Varje [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) har en metod [getFontsManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getFontsManager) som returnerar dess egen instans av klassen [FontsManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/).

Följande exempel visar hur du skapar en samling av reservtypsnittregler och tilldelar den till [FontsManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/) för en presentation:

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

Efter att [FontsManager](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsmanager/) har initierats med reservtypsnittssamlingen tillämpas reservtypsnitten under presentationens rendering.

{{% alert color="info" title="Note" %}}
Läs mer om hur du [rendera en presentation med ett reservtypsnitt](/slides/sv/python-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Kommer mina reservtypsnittregler att bäddas in i PPTX-filen och vara synliga i PowerPoint efter sparande?**

Nej. Reservtypsnittregler är inställningar för rendering vid körning; de serialiseras inte till PPTX och kommer inte att visas i PowerPoints UI.

**Gäller reservtypsnitt för text i SmartArt, WordArt, diagram och tabeller?**

Ja. Samma teckenglyph‑substitutionsmekanism används för all text i dessa objekt.

**Distribuerar Aspose några typsnitt med biblioteket?**

Nej. Du lägger till och använder typsnitt på din sida och på eget ansvar.

**Kan ersättning/substitution för saknade typsnitt och reservtypsnitt för saknade glyphs användas tillsammans?**

Ja. De är oberoende steg i samma typsnittslösningspipeline: först löser motorn typsnittstillgänglighet ([replacement](/slides/sv/python-java/font-replacement/)/[substitution](/slides/sv/python-java/font-substitution/)), sedan fyller reservtypsnittet luckor för saknade glyphs i tillgängliga typsnitt.