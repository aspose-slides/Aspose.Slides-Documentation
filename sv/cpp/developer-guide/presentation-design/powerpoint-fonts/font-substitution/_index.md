---
title: Konfigurera teckensnittsbyte i presentationer i C++
linktitle: Teckensnittsbyte
type: docs
weight: 70
url: /sv/cpp/font-substitution/
keywords:
- teckensnitt
- substituerat teckensnitt
- teckensnittsbyte
- ersätt teckensnitt
- teckensnittsersättning
- substitutionsregel
- ersättningsregel
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Konfigurera regler för teckensnittsbyte och granska substituerade teckensnitt i Aspose.Slides för C++ när du renderar eller konverterar PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Font substitution allows Aspose.Slides to use an available font in place of a font that cannot be accessed when a presentation is rendered or converted. The substitution affects the rendered output; it does not change the font assigned to the presentation content.

Du kan definiera vilket teckensnitt som ska användas när ett visst teckensnitt är otillgängligt, och du kan granska de byten som Aspose.Slides kommer att göra under renderingen. Detta hjälper till att hålla utdata konsekvent över miljöer med olika installerade teckensnitt.

Om ett teckensnitt är tillgängligt men saknar en dedikerad fet teckensnittsstil, se [Hantera teckensnitt utan en dedikerad fet teckensnittsstil](/slides/sv/cpp/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Den sektionen förklarar hur man rasteriserar den påverkade texten vid PDF‑export och vilka följder det har för textmarkering, sökning och skalning.

## **Hämta teckensnittsbyten**

Use the [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) method to determine which fonts will be substituted when the presentation is rendered. The method returns [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) objects that identify the original and substituted font names.

Den följande C++‑exemplet listar alla teckensnittsbyten för en presentation:

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

## **Hämta teckensnittsbyten för valda bilder**

Use the [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) overload with a `System::ArrayPtr<int32_t> slides` argument to inspect only the substitutions required to render specific slides. This is useful when you are rendering or exporting part of a presentation, checking a large presentation incrementally, locating slides that depend on unavailable fonts, preparing a minimal font package for a server or container, or diagnosing rendering differences without processing unrelated slides.

`slides`‑arrayen innehåller ett‑baserade bildindex: `1` identifierar den första bilden. Till skillnad från det, använder [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) metoden ett noll‑baserat index, så samma bild nås som `presentation->get_Slide(0)`. Tänk på denna skillnad när du bygger arrayen för att undvika fel med ett steg.

Call the overload through the [Presentation::get_FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/) method. It returns only the substitutions determined while rendering the selected slides. Each result is a [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) object containing the original and substituted font names. The result reflects the current font environment, configured fallback rules, substitution rules stored in an [IFontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsubstrulecollection/), and [externally loaded fonts](/slides/sv/cpp/custom-font/).

Samma substitution kan krävas av mer än en vald bild. Deduplikera resultaten när du skapar ett teckensnittsinventarium eller en förhandsgranskningsrapport. Följande exempel rapporterar varje återgiven substitution och skapar sedan en sorterad lista med unika teckensnittsmappningar:

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

The [IFontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/) interface provides both overloads. Choose one according to the scope of the rendering operation:

| Överlagring | Använd den när |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) without arguments | Du behöver byten för hela presentationen. |
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with `System::ArrayPtr<int32_t> slides` | Du behöver byten för ett valt intervall, inkrementell kontroll eller partiell export. |

## **Ange teckensnittsbytesregler**

To specify the font that Aspose.Slides should use when a source font is unavailable:

1. Load the presentation.
2. Create font definitions for the source and substitute fonts.
3. Create a [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/) with the [WhenInaccessible](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstcondition/) condition.
4. Add the rule to a [FontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrulecollection/).
5. Assign the collection by using the [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/) method.
6. Render or convert the presentation.

The following C++ example substitutes `Arial` for `SomeRareFont` when `SomeRareFont` is unavailable, and then renders the first slide to verify the result. The substitute font must be available to Aspose.Slides.

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
För en villkorslös förändring av de teckensnitt som används i hela presentationen, se [Teckensnittsbyte](/slides/sv/cpp/font-replacement/).
{{% /alert %}}

## **Begränsningar för matematiska ekvations‑teckensnitt**

Font substitution rules are part of the standard font selection process used during rendering and conversion. They work for regular text when Aspose.Slides can replace an inaccessible font with the available font specified by a rule.

Office Math‑ekvationer har ett extra krav. Om en ekvation använder **Cambria Math**, kan Aspose.Slides behöva exakt detta teckensnitt för att beräkna och rendera ekvationslayouten. En regel som ersätter ett annat matematikteckensnitt, såsom **STIX Two Math**, kan inte ersätta **Cambria Math** för detta ändamål, och renderingen kan fortfarande rapportera att **Cambria Math** krävs.

För att rendera eller konvertera en sådan presentation, gör **Cambria Math** tillgängligt för Aspose.Slides. Installera det i operativsystemet eller läs in det som ett [external font](/slides/sv/cpp/custom-font/).

Denna begränsning gäller endast ekvationslayout. De ovan beskrivna substitutionsreglerna gäller fortfarande för vanlig presentationstext.

## **Vanliga frågor**

**Vad är skillnaden mellan teckensnittsbyte och teckensnittsbyte?**  
[Font replacement](/slides/sv/cpp/font-replacement/) ändrar medvetet ett teckensnitt till ett annat i hela presentationen. Teckensnittsbyte väljer ett teckensnitt för den renderade utdata när det konfigurerade villkoret är uppfyllt, till exempel när det ursprungliga teckensnittet är otillgängligt.

**När tillämpas substitutionsregler?**  
Reglerna deltar i [font selection sequence](/slides/sv/cpp/font-selection-sequence/) under renderering och konvertering. Med `WhenInaccessible` används en regel endast när Aspose.Slides inte kan komma åt källteckensnittet.

**Vad händer när ett teckensnitt saknas och ingen substitutionsregel är konfigurerad?**  
Aspose.Slides väljer det närmaste tillgängliga teckensnittet enligt sin teckensnittsväljningsprocess. Resultatet beror på vilka teckensnitt som finns i körmiljön.

**Kan jag läsa in externa teckensnitt för att undvika substitution?**  
Ja. Du kan [load external fonts](/slides/sv/cpp/custom-font/) så att Aspose.Slides kan använda dem under renderering och konvertering.

**Distribuerar Aspose teckensnitt med biblioteket?**  
Nej. Du ansvarar för att tillhandahålla teckensnitt och följa deras licenser.

**Kan substitutionsresultat skilja sig mellan Windows, Linux och macOS?**  
Ja. Installerade teckensnitt och sökvägar för teckensnitt varierar mellan operativsystem, så ett teckensnitt som finns på en maskin kan kräva substitution på en annan.

**Hur kan jag göra teckensnittsväljning konsekvent i batch‑konverteringar?**  
Använd samma teckensnittsfiler och versioner på varje maskin eller container, [load required external fonts](/slides/sv/cpp/custom-font/), och [embed fonts](/slides/sv/cpp/embedded-font/) när licensvillkoren tillåter det. Du kan också anropa [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) före export för att identifiera oväntade substitutioner.