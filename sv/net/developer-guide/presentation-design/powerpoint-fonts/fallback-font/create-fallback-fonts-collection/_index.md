---
title: "Konfigurera reservteckensnittssamlingar i .NET"
linktitle: "Reservteckensnittssamling"
type: docs
weight: 20
url: /sv/net/create-fallback-fonts-collection/
keywords:
- reservteckensnitt
- reservregel
- teckensnittssamling
- konfigurera teckensnitt
- installera teckensnitt
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Ställ in en reservteckensnittssamling i Aspose.Slides för .NET för att hålla texten konsekvent och klar i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Aspose.Slides låter dig konfigurera en samling av reservteckensnittsregler för en presentation. Varje reservregel representeras av klassen `FontFallBackRule` och kan läggas till i en `FontFallBackRulesCollection`, som implementerar gränssnittet `IFontFallBackRulesCollection`.

Efter att du har skapat samlingen kan du tilldela den till egenskapen `FontFallBackRulesCollection` i presentationens `FontsManager`. `FontsManager` styr teckensnitt i hela presentationen, och varje `Presentation`‑instans har sin egen `FontsManager`.

När `FontsManager` har initierats med reservteckensnittssamlingen tillämpas de angivna reservteckensnitten under rendering av presentationen.

## **Tillämpa reservregler**

Instanser av klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/net/aspose.slides/FontFallBackRule) kan organiseras i [FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/fontfallbackrulescollection), som implementerar [IFontFallBackRulesCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontfallbackrulescollection) gränssnittet. Det är möjligt att lägga till eller ta bort regler från samlingen.

Sedan kan denna samling tilldelas [FontFallBackRulesCollection ](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)egenskapen i klassen [FontsManager](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsmanager). FontsManager styr teckensnitt i hela presentationen.

Varje [Presentation ](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) har en [FontsManager ](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/properties/fontsmanager)egenskap med sin egen instans av FontsManager‑klassen.

Här är ett exempel på hur du skapar en samling av reservteckensnittsregler och tilldelar den till FontsManager för en viss presentation:

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

När FontsManager har initierats med reservteckensnittssamlingen tillämpas reservteckensnitten under rendering av presentationen.

{{% alert color="primary" %}} 
Läs mer om hur du [Rendera presentation med reservteckensnitt](/slides/sv/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Vanliga frågor**

**Kommer mina reservregler att bäddas in i PPTX‑filen och vara synliga i PowerPoint efter sparande?**

Nej. Reservregler är inställningar för rendering vid körning; de serialiseras inte till PPTX och kommer inte att visas i PowerPoints användargränssnitt.

**Gäller reservteckensnitt för text i SmartArt, WordArt, diagram och tabeller?**

Ja. Samma glyfförändringsmekanism används för all text i dessa objekt.

**Distribuerar Aspose några teckensnitt med biblioteket?**

Nej. Du lägger till och använder teckensnitt på din sida och på eget ansvar.

**Kan ersättning/substitution för saknade teckensnitt och reserv för saknade glyfer användas tillsammans?**

Ja. De är oberoende steg i samma teckensnittslösningspipeline: först löser motorn teckensnittstillgänglighet ([replacement](/slides/sv/net/font-replacement/)/[substitution](/slides/sv/net/font-substitution/)), sedan fyller reservteckensnitt de tomrum som saknas glyfer i tillgängliga teckensnitt.