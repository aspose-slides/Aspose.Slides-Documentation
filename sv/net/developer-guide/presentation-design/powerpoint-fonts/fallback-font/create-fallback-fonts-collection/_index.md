---
title: Konfigurera fallback-fontsamlingar i .NET
linktitle: Fallback-fontsamling
type: docs
weight: 20
url: /sv/net/create-fallback-fonts-collection/
keywords:
- fallback-font
- fallback-regel
- fontsamling
- konfigurera font
- installera font
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Ställ in en fallback-fontsamling i Aspose.Slides för .NET för att hålla texten konsekvent och skarp i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Aspose.Slides låter dig konfigurera en samling fallback‑fontregler för en presentation. Varje fallback‑regel representeras av klassen `FontFallBackRule` och kan läggas till i en `FontFallBackRulesCollection`, som implementerar gränssnittet `IFontFallBackRulesCollection`.

Efter att ha skapat samlingen kan du tilldela den till egenskapen `FontFallBackRulesCollection` i presentationens `FontsManager`. `FontsManager` styr teckensnitt i hela presentationen, och varje `Presentation`‑instans har sin egen `FontsManager`.

När `FontsManager` har initialiserats med fallback‑teckensnittssamlingen tillämpas de angivna fallback‑teckensnitten under presentationens rendering.

## **Tillämpa fallback‑regler**

Instanser av [FontFallBackRule](https://reference.aspose.com/slides/sv/net/aspose.slides/FontFallBackRule)‑klassen kan organiseras i [FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/fontfallbackrulescollection), som implementerar [IFontFallBackRulesCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontfallbackrulescollection)‑gränssnittet. Det går att lägga till eller ta bort regler i samlingen.

Sedan kan denna samling tilldelas [FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)‑egenskapen i klassen [FontsManager](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsmanager). FontsManager styr teckensnitt i hela presentationen.

Varje [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) har en [FontsManager](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/properties/fontsmanager)‑egenskap med sin egen instans av FontsManager‑klassen.

Här är ett exempel på hur man skapar en samling med fallback‑teckensnitt regler och tilldelar den till FontsManager för en viss presentation:

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

Efter att FontsManager har initialiserats med fallback‑teckensnittssamlingen tillämpas fallback‑teckensnitten under presentationens rendering.

{{% alert color="info" %}} 
Läs mer om hur du [Rendera presentation med fallback‑font](/slides/sv/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Vanliga frågor**

### Kommer mina fallback‑regler att bäddas in i PPTX‑filen och vara synliga i PowerPoint efter sparning?

Nej. Fallback‑regler är inställningar för körningstidens rendering; de serialiseras inte till PPTX och visas inte i PowerPoints användargränssnitt.

### Tillämpas fallback på text i SmartArt, WordArt, diagram och tabeller?

Ja. Samma glyf‑substitutionsmekanism används för all text i dessa objekt.

### Distribuerar Aspose några teckensnitt med biblioteket?

Nej. Du lägger till och använder teckensnitt på din sida och på ditt eget ansvar.

### Kan ersättning/substitution för saknade teckensnitt och fallback för saknade glyfer användas tillsammans?

Ja. De är oberoende steg i samma teckensnittslösningspipeline: först löser motorn teckensnittstillgänglighet ([ersättning](/slides/sv/net/font-replacement/)/[substitution](/slides/sv/net/font-substitution/)), sedan fyller fallback i luckor för saknade glyfer i tillgängliga teckensnitt.