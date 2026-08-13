---
title: "Konfigurera reservteckensnittssamlingar i C++"
linktitle: "Reservteckensnittssamling"
type: docs
weight: 20
url: /sv/cpp/create-fallback-fonts-collection/
keywords:
- "reservteckensnitt"
- "reservregel"
- "teckensnittssamling"
- "konfigurera teckensnitt"
- "installera teckensnitt"
- "PowerPoint"
- "OpenDocument"
- "presentation"
- "C++"
- "Aspose.Slides"
description: "Skapa en reservteckensnittssamling i Aspose.Slides för C++ för att hålla texten konsekvent och skarp i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Aspose.Slides gör det möjligt att konfigurera en samling av reservteckensnittregler för en presentation. Varje reservregel representeras av klassen `FontFallBackRule` och kan läggas till i en `FontFallBackRulesCollection`, som implementerar `IFontFallBackRulesCollection`-gränssnittet.

Efter att ha skapat samlingen kan du tilldela den med metoden `set_FontFallBackRulesCollection` i presentationens `FontsManager`. `FontsManager` styr teckensnitt i hela presentationen, och varje `Presentation`-instans har sin egen `FontsManager`.

När `FontsManager` har initierats med reservteckensnittssamlingen appliceras de specificerade reservteckensnitten under rendering av presentationen.

## **Tillämpa reservregler**

Instanser av [FontFallBackRule](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrule/) kan organiseras i [FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrulescollection/), som implementerar [IFontFallBackRulesCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontfallbackrulescollection/)-gränssnittet. Det går att lägga till eller ta bort regler från samlingen.

Därefter kan denna samling skickas till metoden [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) i klassen [FontsManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/). FontsManager styr teckensnitt i hela presentationen.

Varje [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) har en [get_FontsManager()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_fontsmanager/) metod med sin egen instans av FontsManager-klassen.

Här är ett exempel på hur man skapar en samling av reservteckensnittregler och tilldelar den till FontsManager för en viss presentation:  

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontFallBackRule.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

När FontsManager har initierats med reservteckensnittssamlingen appliceras reservteckensnitten under rendering av presentationen.

{{% alert color="info" %}} 
Läs mer om hur du [Rendera presentation med reservteckensnitt](/slides/sv/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Vanliga frågor**

### Kommer mina reservregler att bäddas in i PPTX-filen och vara synliga i PowerPoint efter sparning?

Nej. Reservregler är inställningar för renderning vid körning; de serialiseras inte till PPTX och kommer inte att visas i PowerPoints användargränssnitt.

### Gäller reservteckensnitt för text inuti SmartArt, WordArt, diagram och tabeller?

Ja. Samma glyf‑substitutionsmekanism används för all text i dessa objekt.

### Distribuerar Aspose några teckensnitt med biblioteket?

Nej. Du lägger till och använder teckensnitt på din sida och på eget ansvar.

### Kan ersättning/substitution för saknade teckensnitt och reserv för saknade glyfer användas tillsammans?

Ja. De är oberoende steg i samma teckensnittslösnings‑pipeline: först löser motorn teckensnittstillgänglighet ([replacement](/slides/sv/cpp/font-replacement/)/[substitution](/slides/sv/cpp/font-substitution/)), sedan fyller reservteckensnitt luckor för saknade glyfer i tillgängliga teckensnitt.