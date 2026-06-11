---
title: Konfigurera fallback-typsnittssamlingar i C++
linktitle: Fallback-typsnittssamling
type: docs
weight: 20
url: /sv/cpp/create-fallback-fonts-collection/
keywords:
- fallback-typsnitt
- fallback-regel
- typsnittssamling
- konfigurera typsnitt
- installera typsnitt
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Installera en fallback-typsnittssamling i Aspose.Slides för C++ för att hålla texten konsekvent och skarp i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Aspose.Slides låter dig konfigurera en samling av fallback‑typsnittregler för en presentation. Varje fallback‑regel representeras av klassen `FontFallBackRule` och kan läggas till i en `FontFallBackRulesCollection`, som implementerar gränssnittet `IFontFallBackRulesCollection`.

Efter att ha skapat samlingen kan du tilldela den med metoden `set_FontFallBackRulesCollection` i presentationens `FontsManager`. `FontsManager` styr typsnitt i hela presentationen, och varje `Presentation`‑instans har sin egen `FontsManager`.

När `FontsManager` har initierats med fallback‑typsnittssamlingen tillämpas de angivna fallback‑typsnitten under rendering av presentationen.

## **Tillämpa fallback‑regler**

Instanser av klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrule/) kan organiseras i [FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrulescollection/), som implementerar [IFontFallBackRulesCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontfallbackrulescollection/) gränssnittet. Det går att lägga till eller ta bort regler från samlingen.

Sedan kan denna samling skickas till [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/)‑metoden i klassen [FontsManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/). FontsManager styr typsnitt i hela presentationen.

Varje [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) har en [get_FontsManager()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_fontsmanager/)‑metod med sin egen instans av FontsManager‑klassen.

Här är ett exempel på hur man skapar en samling av fallback‑typsnittregler och tilldelar den i FontsManager för en viss presentation:

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Efter att FontsManager har initierats med fallback‑typsnittssamlingen tillämpas fallback‑typsnitten under rendering av presentationen.

{{% alert color="primary" %}} 
Läs mer om hur du [Renderar presentation med fallback‑typsnitt](/slides/sv/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Kommer mina fallback‑regler att bäddas in i PPTX‑filen och vara synliga i PowerPoint efter sparande?**  
Nej. Fallback‑regler är inställningar för rendering i körning; de serialiseras inte till PPTX och visas inte i PowerPoints användargränssnitt.

**Gäller fallback för text i SmartArt, WordArt, diagram och tabeller?**  
Ja. samma glyf‑substitutionsmekanism används för all text i dessa objekt.

**Distribuerar Aspose några typsnitt tillsammans med biblioteket?**  
Nej. Du lägger till och använder typsnitt på din sida och på eget ansvar.

**Kan ersättning/substitution för saknade typsnitt och fallback för saknade glyfer användas tillsammans?**  
Ja. De är oberoende steg i samma typsnitts‑upplösnings‑pipeline: först löser motorn typsnitts‑tillgänglighet ([replacement](/slides/sv/cpp/font-replacement/)/[substitution](/slides/sv/cpp/font-substitution/)), sedan fyller fallback i luckorna för saknade glyfer i tillgängliga typsnitt.