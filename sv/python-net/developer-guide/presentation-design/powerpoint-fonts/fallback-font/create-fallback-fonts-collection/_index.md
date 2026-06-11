---
title: Konfigurera reservteckensnittssamlingar i Python
linktitle: Reservteckensnittssamling
type: docs
weight: 20
url: /sv/python-net/create-fallback-fonts-collection/
keywords:
- reservteckensnitt
- reservregel
- teckensnittssamling
- konfigurera teckensnitt
- installera teckensnitt
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Ställ in en reservteckensnittssamling i Aspose.Slides för Python via .NET för att hålla texten konsekvent och skarp i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Aspose.Slides låter dig konfigurera en samling av reservteckensnittregler för en presentation. Varje reservregel representeras av klassen `FontFallBackRule` och kan läggas till i en `FontFallBackRulesCollection`.

Efter att du har skapat samlingen kan du tilldela den till egenskapen `font_fall_back_rules_collection` i presentationens `fonts_manager`. `fonts_manager` styr teckensnitt i hela presentationen, och varje `Presentation`‑instans har sin egen `FontsManager`.

När `FontsManager` har initierats med reservteckensnittssamlingen appliceras de angivna reservteckensnitten under rendering av presentationen.

## **Tillämpa reservregler**

Instanser av klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/python-net/aspose.slides/FontFallBackRule/) kan organiseras i [FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontfallbackrulescollection/). Det är möjligt att lägga till eller ta bort regler från samlingen.

Därefter kan denna samling tilldelas egenskapen [font_fall_back_rules_collection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) i klassen [FontsManager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/). FontsManager styr teckensnitt i hela presentationen.

Varje [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) har en [fonts_manager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/fonts_manager/)‑egenskap med sin egen instans av klassen FontsManager.

Här är ett exempel på hur man skapar en samling av reservteckensnittregler och tilldelar den till FontsManager för en viss presentation:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

När FontsManager har initierats med reservteckensnittssamlingen appliceras reservteckensnitten under presentationens rendering.

{{% alert color="primary" %}} 
Läs mer om hur du [Renderar presentation med reservteckensnitt](/slides/sv/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Kommer mina reservregler att bäddas in i PPTX‑filen och vara synliga i PowerPoint efter sparande?**

Nej. Reservregler är inställningar för rendering i körning; de serialiseras inte till PPTX och kommer inte att visas i PowerPoints användargränssnitt.

**Gäller reservteckensnitt för text i SmartArt, WordArt, diagram och tabeller?**

Ja. Samma tecken‑substitutionsmekanism används för all text i dessa objekt.

**Distribuerar Aspose några teckensnitt med biblioteket?**

Nej. Du lägger till och använder teckensnitt på din sida och på eget ansvar.

**Kan ersättning/substitution för saknade teckensnitt och reserv för saknade tecken användas tillsammans?**

Ja. De är oberoende steg i samma teckensnittslösningspipeline: först löser motorn tillgängligheten för teckensnitt ([replacement](/slides/sv/python-net/font-replacement/)/[substitution](/slides/sv/python-net/font-substitution/)), sedan fyller reservteckensnitt luckor för saknade tecken i tillgängliga teckensnitt.