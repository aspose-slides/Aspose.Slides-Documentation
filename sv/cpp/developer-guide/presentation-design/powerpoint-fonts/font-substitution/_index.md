---
title: "Konfigurera teckensnittssubstitution i presentationer i C++"
linktitle: "Teckensnittssubstitution"
type: docs
weight: 70
url: /sv/cpp/font-substitution/
keywords:
- teckensnitt
- ersättningsteckensnitt
- teckensnittssubstitution
- byta teckensnitt
- teckensnittsersättning
- substitionsregel
- ersättningsregel
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Konfigurera teckensnittssubstitutionsregler och granska substituerade teckensnitt i Aspose.Slides för C++ när du renderar eller konverterar PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Fontsubstitution tillåter Aspose.Slides att använda ett tillgängligt teckensnitt i stället för ett teckensnitt som inte kan nås när en presentation renderas eller konverteras. Substitutionen påverkar den renderade utdata; den ändrar inte det teckensnitt som är tilldelat presentationens innehåll.

Du kan definiera vilket teckensnitt som ska användas när ett specifikt teckensnitt är otillgängligt, och du kan granska de substitutioner som Aspose.Slides kommer att göra under rendering. Detta hjälper till att hålla utdata konsekvent över miljöer med olika installerade teckensnitt.

## **Hämta teckensnittssubstitutioner**

Använd metoden [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontsmanager/getsubstitutions/) för att bestämma vilka teckensnitt som kommer att substitueras när presentationen renderas. Metoden returnerar [FontSubstitutionInfo](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsubstitutioninfo/)‑objekt som identifierar de ursprungliga och substituerade teckensnittsnamnen.

Följande C++‑exempel listar alla teckensnittssubstitutioner för en presentation:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

for (auto&& substitution : presentation->get_FontsManager()->GetSubstitutions())
{
    Console::WriteLine(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
}

presentation->Dispose();
```

## **Hämta teckensnittssubstitutioner för valda bilder**

Använd överlagringen av [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontsmanager/getsubstitutions/) med argumentet `System::ArrayPtr<int32_t> slides` för att granska endast de substitutioner som krävs för att rendera specifika bilder. Detta är användbart när du renderar eller exporterar en del av en presentation, kontrollerar en stor presentation inkrementellt, lokaliserar bilder som är beroende av otillgängliga teckensnitt, förbereder ett minimalt teckensnittspaket för en server eller container, eller diagnostiserar renderingsskillnader utan att bearbeta irrelevanta bilder.

`slides`‑arrayen innehåller ettbaserade bildindex: `1` identifierar den första bilden. Till skillnad från detta använder metoden [Presentation::get_Slide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_slide/) ett nollbaserat index, så samma bild nås som `presentation->get_Slide(0)`. Ha denna skillnad i åtanke när du bygger arrayen för att undvika fel med en förskjutning.

Anropa överlagringen via metoden [Presentation::get_FontsManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_fontsmanager/). Den returnerar endast de substitutioner som bestämdes under rendering av de valda bilderna. Varje resultat är ett [FontSubstitutionInfo](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsubstitutioninfo/)‑objekt som innehåller det ursprungliga och det substituerade teckensnittsnamnet. Resultatet speglar den aktuella teckensnittsmiljön, konfigurerade reservregler, substitutionsregler lagrade i en [IFontSubstRuleCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontsubstrulecollection/) och [externt laddade teckensnitt](/slides/sv/cpp/custom-font/).

Samma substitution kan krävas av mer än en vald bild. Avduplicera resultaten när du skapar ett teckensnittsinventarium eller en förhandsgranskningsrapport. Följande exempel rapporterar varje återställd substitution och skapar sedan en sorterad lista med unika teckensnittsmappningar:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

auto selectedSlides = MakeArray<int32_t>({1, 3, 5});
auto substitutions = presentation->get_FontsManager()->GetSubstitutions(selectedSlides);
auto sortedPreflightEntries = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

Console::WriteLine(u"Substitutions for the selected slides:");
for (auto&& substitution : substitutions)
{
    auto entry = String::Format(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
    Console::WriteLine(entry);
    sortedPreflightEntries->Add(entry);
}

Console::WriteLine(u"Deduplicated font preflight report:");
for (auto&& entry : sortedPreflightEntries)
{
    Console::WriteLine(entry);
}

presentation->Dispose();
```

Gränssnittet [IFontsManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontsmanager/) erbjuder båda överlagringarna. Välj en enligt omfattningen av renderingsåtgärden:

| Överlagring | Använd den när |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontsmanager/getsubstitutions/) med inga argument | Du behöver substitutioner för hela presentationen. |
| [GetSubstitutions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontsmanager/getsubstitutions/) med `System::ArrayPtr<int32_t> slides` | Du behöver substitutioner för ett valt intervall, inkrementell kontroll eller partiell export. |

## **Ange teckensnittssubstitutionsregler**

För att ange vilket teckensnitt Aspose.Slides ska använda när ett källteckensnitt är otillgängligt:

1. Ladda presentationen.
2. Skapa teckensnittdefinitioner för käll‑ och substitutteckensnittet.
3. Skapa en [FontSubstRule](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsubstrule/) med villkoret [WhenInaccessible](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsubstcondition/).
4. Lägg till regeln i en [FontSubstRuleCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsubstrulecollection/).
5. Tilldela samlingen genom att använda metoden [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/).
6. Rendera eller konvertera presentationen.

Följande C++‑exempel substituerar `Arial` för `SomeRareFont` när `SomeRareFont` är otillgängligt, och renderar sedan den första bilden för att verifiera resultatet. Det substituterade teckensnittet måste vara tillgängligt för Aspose.Slides.

```cpp
#include <DOM/FontSubstCondition.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/Fonts/FontSubstRule.h>
#include <DOM/Fonts/FontSubstRuleCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");

auto sourceFont = MakeObject<FontData>(u"SomeRareFont");
auto substituteFont = MakeObject<FontData>(u"Arial");
auto substitutionRule = MakeObject<FontSubstRule>(sourceFont, substituteFont, FontSubstCondition::WhenInaccessible);

auto substitutionRules = MakeObject<FontSubstRuleCollection>();
substitutionRules->Add(substitutionRule);
presentation->get_FontsManager()->set_FontSubstRuleList(substitutionRules);

auto image = presentation->get_Slide(0)->GetImage(1.0f, 1.0f);
image->Save(u"slide.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
För en ovillkorlig förändring av de teckensnitt som används i hela presentationen, se [Font Replacement](/slides/sv/cpp/font-replacement/).
{{% /alert %}}

## **Begränsningar för matematiska ekvationsteckensnitt**

Teckensnittssubstitutionsregler är en del av den standardmässiga teckensnittsvalprocessen som används under rendering och konvertering. De fungerar för vanlig text när Aspose.Slides kan ersätta ett otillgängligt teckensnitt med det tillgängliga teckensnitt som anges av en regel.

Office Math‑ekvationer har ett extra krav. Om en ekvation använder **Cambria Math** kan Aspose.Slides behöva exakt det teckensnittet för att beräkna och rendera ekvationslayouten. En regel som substituerar ett annat matematiskt teckensnitt, såsom **STIX Two Math**, kan inte ersätta **Cambria Math** för detta ändamål, och renderingen kan fortfarande rapportera att **Cambria Math** krävs.

För att rendera eller konvertera en sådan presentation, gör **Cambria Math** tillgängligt för Aspose.Slides. Installera det i operativsystemet eller ladda det som ett [externt teckensnitt](/slides/sv/cpp/custom-font/).

Denna begränsning gäller ekvationslayouten. Substitutionsreglerna som beskrivits ovan gäller fortfarande för vanlig presentationstext.

## **FAQ**

**Vad är skillnaden mellan teckensnittsersättning och teckensnittssubstitution?**

[Font replacement](/slides/sv/cpp/font-replacement/) ändrar avsiktligt ett teckensnitt till ett annat i hela presentationen. Teckensnittssubstitution väljer ett teckensnitt för den renderade utdata när det konfigurerade villkoret är uppfyllt, till exempel när det ursprungliga teckensnittet är otillgängligt.

**När tillämpas substitutionsregler?**

Reglerna deltar i [teckensnittsvalsekvensen](/slides/sv/cpp/font-selection-sequence/) under rendering och konvertering. Med `WhenInaccessible` används en regel endast när Aspose.Slides inte kan komma åt källteckensnittet.

**Vad händer när ett teckensnitt saknas och ingen substitueringsregel är konfigurerad?**

Aspose.Slides väljer det närmaste tillgängliga teckensnittet enligt sin teckensnittsvalprocess. Resultatet beror på vilka teckensnitt som finns tillgängliga i körmiljön.

**Kan jag ladda externa teckensnitt för att undvika substitution?**

Ja. Du kan [ladda externa teckensnitt](/slides/sv/cpp/custom-font/) så att Aspose.Slides kan använda dem under rendering och konvertering.

**Distribuerar Aspose teckensnitt med biblioteket?**

Nej. Du ansvarar för att tillhandahålla teckensnitt och för att följa deras licenser.

**Kan substitutionsresultat skilja sig mellan Windows, Linux och macOS?**

Ja. Installerade teckensnitt och sökvägar för teckensnitt skiljer sig åt mellan operativsystem, så ett teckensnitt som är tillgängligt på en maskin kan kräva substitution på en annan.

**Hur kan jag göra teckensnittsvalet konsekvent i batchkonverteringar?**

Använd samma teckensnitt­filer och versioner på varje maskin eller container, [ladda erforderliga externa teckensnitt](/slides/sv/cpp/custom-font/) och [bädda in teckensnitt](/slides/sv/cpp/embedded-font/) när licensiering tillåter. Du kan också anropa [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontsmanager/getsubstitutions/) innan export för att identifiera oväntade substitutioner.