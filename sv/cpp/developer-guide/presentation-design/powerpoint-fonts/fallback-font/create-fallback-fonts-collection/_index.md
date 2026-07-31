---
title: Konfigurera reservtypsnittssamlingar i C++
linktitle: Reservtypsnittssamling
type: docs
weight: 20
url: /sv/cpp/create-fallback-fonts-collection/
keywords:
- reservtypsnitt
- reservtypsnittsregel
- typsnittssamling
- konfigurera typsnitt
- ställa in typsnitt
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Skapa en samling av reservtypsnitt i Aspose.Slides för C++ för att hålla texten konsekvent och skarp i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Aspose.Slides låter dig konfigurera en samling av reservtypsnittregler för en presentation. Varje reservtypsnittregel representeras av klassen `FontFallBackRule` och kan läggas till i en `FontFallBackRulesCollection`, som implementerar gränssnittet `IFontFallBackRulesCollection`.

Efter att du har skapat samlingen kan du tilldela den med hjälp av metoden `set_FontFallBackRulesCollection` i presentationens `FontsManager`. `FontsManager` styr typsnitt i hela presentationen, och varje `Presentation`‑instans har sin egen `FontsManager`.

När `FontsManager` har initierats med samlingen av reservtypsnitt tillämpas de angivna reservtypsnitten under rendering av presentationen.

## **Tillämna reservtypsnittregler**

Instanser av klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrule/) kan organiseras i [FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrulescollection/), som implementerar [IFontFallBackRulesCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontfallbackrulescollection/)‑gränssnittet. Det går att lägga till eller ta bort regler från samlingen.

Sedan kan denna samling överföras till metoden [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) i klassen [FontsManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/). FontsManager styr typsnitt i hela presentationen.

Varje [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) har en metod [get_FontsManager()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_fontsmanager/) med sin egen instans av FontsManager‑klassen.

Här är ett exempel på hur du skapar en samling av reservtypsnittregler och tilldelar den till FontsManager för en viss presentation:  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Efter att FontsManager har initierats med samlingen av reservtypsnitt tillämpas reservtypsnitten under rendering av presentationen.

{{% alert color="primary" %}} 
Läs mer om hur du [Renderar presentation med reservtypsnitt](/slides/sv/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Vanliga frågor**

**Kommer mina reservtypsnittregler att bäddas in i PPTX‑filen och vara synliga i PowerPoint efter sparning?**

Nej. Reservtypsnittregler är inställningar för rendering vid körning; de serialiseras inte till PPTX och kommer inte att visas i PowerPoints användargränssnitt.

**Gäller reservtypsnitt för text i SmartArt, WordArt, diagram och tabeller?**

Ja. Samma glyf‑substitutionsmekanism används för all text i dessa objekt.

**Distribuerar Aspose några typsnitt med biblioteket?**

Nej. Du lägger till och använder typsnitt på din sida och på eget ansvar.

**Kan ersättning/substitution för saknade typsnitt och reservtypsnitt för saknade glyfer användas tillsammans?**

Ja. De är oberoende steg i samma teckensnittslösningspipeline: först löser motorn tillgängligheten för teckensnitt ([ersättning](/slides/sv/cpp/font-replacement/)/[substitution](/slides/sv/cpp/font-substitution/)), sedan fyller reservtypsnitt de luckor som saknade glyfer i tillgängliga teckensnitt lämnar.