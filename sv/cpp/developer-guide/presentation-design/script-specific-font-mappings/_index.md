---
title: Hantera skript-specifika temateckensnitt i C++
linktitle: Skript-specifika temateckensnitt
type: docs
weight: 15
url: /sv/cpp/script-specific-font-mappings/
keywords:
- skript-specifikt teckensnitt
- temateckensnittskartläggning
- flerspråkig presentation
- skriftsystem
- kyrilliskt teckensnitt
- arabiskt teckensnitt
- japanskt teckensnitt
- georgiskt teckensnitt
- thaana-teckensnitt
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Inspektera, lägga till, ersätta och ta bort skript-specifika teckensnittskartläggningar i PowerPoint-teman med Aspose.Slides för C++."
---
## **Översikt**

Ett presentationstema kan välja olika teckensnittsfamiljer för olika skriftsystem. Detta möjliggör flerspråkig text som fortfarande använder temats teckensnitt att följa ett samordnat teckensnittsschema samtidigt som lämpliga teckensnitt används för kyrilliska, arabiska, japanska, georgiska, thaana och andra skript.

Temaets [IFontScheme](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/ifontscheme/) innehåller en huvudteckensnittssamling, som vanligtvis används för rubriker, och en bi‑teckensnittssamling, som vanligtvis används för brödtext. Förutom deras latinska och östasiatiska teckensnittsegenskaper exponeras kartläggningar från skriftsystem‑taggar till teckensnittsfamiljenamn via [IFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifonts/)-gränssnittet.

Denna artikel visar hur man inspekterar och ändrar dessa kartläggningar i presentationens mastertema samt verifierar att ändringarna överlever en spara‑och‑läs‑om‑cykel.

## **Förstå skripttaggar**

Skriftteckensnittsmetoderna använder fyrabokstaviga BCP 47‑skript‑subtaggar för att identifiera skriftsystem. Vanliga värden inkluderar:

| Skript‑tagg | Skriftsystem |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arabic |
| `Hans` | Simplified Chinese |
| `Jpan` | Japanese |
| `Geor` | Georgian |
| `Thaa` | Thaana |

## **Åtkomst och inspektion av skript‑teckensnittskartläggningar**

Använd [Presentation::get_MasterTheme](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_mastertheme/) för att komma åt presentationens temanivå. Metoderna [FontScheme::get_Major](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/fontscheme/get_major/) och [FontScheme::get_Minor](https://reference.aspose.com/slides/sv/cpp/aspose.slides.theme/fontscheme/get_minor/) returnerar de två [IFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifonts/)-samlingarna.

Anropa [Fonts::GetScriptFontMap](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fonts/getscriptfontmap/) för att hämta alla kartläggningar från en samling. För att slå upp ett skriftsystem, anropa [Fonts::GetScriptFont](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fonts/getscriptfont/) med dess skript‑tagg. `GetScriptFont` returnerar en null‑sträng när den samlingen inte definierar den begärda kartläggningen.

## **Ändra kartläggningar och verifiera beständighet**

Använd [Fonts::SetScriptFont](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fonts/setscriptfont/) för att skapa en kartläggning eller ersätta dess nuvarande teckensnittsfamilj. Använd [Fonts::RemoveScriptFont](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fonts/removescriptfont/) för att ta bort en kartläggning.

Det följande end‑to‑end‑exemplet läser alla befintliga huvud‑ och bi‑kartläggningar, slår upp det japanska huvudteckensnittet, ändrar det kyrilliska huvudteckensnittet, tar bort Thaana‑bi‑kartläggningen, sparar presentationen och öppnar den igen för att verifiera båda ändringarna. För att göra borttagningssteget oberoende av det ursprungliga temat skapar exemplet först en Thaana‑kartläggning endast om en sådan ännu inte är definierad.

```cpp
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/collections/idictionary.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto fontScheme = presentation->get_MasterTheme()->get_FontScheme();
auto majorFonts = fontScheme->get_Major();
auto minorFonts = fontScheme->get_Minor();

Console::WriteLine(u"Existing major mappings:");
for (auto&& mapping : majorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

Console::WriteLine(u"Existing minor mappings:");
for (auto&& mapping : minorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

auto japaneseFont = majorFonts->GetScriptFont(u"Jpan");
if (japaneseFont.IsNull())
{
    Console::WriteLine(u"No major Japanese font is defined.");
}
else
{
    Console::WriteLine(u"Major Japanese font: {0}", japaneseFont);
}

majorFonts->SetScriptFont(u"Cyrl", u"Arial");

if (minorFonts->GetScriptFont(u"Thaa").IsNull())
{
    minorFonts->SetScriptFont(u"Thaa", u"Arial");
}

minorFonts->RemoveScriptFont(u"Thaa");
presentation->Save(u"script-font-mappings.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"script-font-mappings.pptx");
auto savedFontScheme = savedPresentation->get_MasterTheme()->get_FontScheme();
auto savedMajorFonts = savedFontScheme->get_Major();
auto savedMinorFonts = savedFontScheme->get_Minor();
auto savedCyrillicFont = savedMajorFonts->GetScriptFont(u"Cyrl");
auto savedThaanaFont = savedMinorFonts->GetScriptFont(u"Thaa");

if (savedCyrillicFont == u"Arial")
{
    Console::WriteLine(u"The Cyrillic mapping was preserved.");
}
else
{
    Console::WriteLine(u"The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont.IsNull())
{
    Console::WriteLine(u"The Thaana mapping removal was preserved.");
}
else
{
    Console::WriteLine(u"The Thaana mapping still exists.");
}
```

Verifieringen använder samma null‑sträng‑beteende som en ordinär uppslagning: efter att borttagningen sparats returnerar `GetScriptFont(u"Thaa")` en null‑sträng för bi‑samlingen.

## **Skilj på temakartläggningar från andra teckensnittsinställningar**

Skript‑specifika temakartläggningar deltar i teckensnittsurval, men de löser ett annat problem än direkt textformatering, substitution och reservteckensnitt:

| Mekanism | Syfte | Effekt av att ändra en temakartläggning |
|---|---|---|
| Skript‑specifik temateckensnittskartläggning | Väljer ett huvud‑ eller bi‑temateckensnitt för ett skriftsystem. | Text som fortfarande använder motsvarande temateckensnitt kan lösa sig till den nya kartlagda familjen. |
| Teckensnitt som tilldelas explicit till ett textavsnitt | Fixerar den begärda teckensnittsfamiljen på det avsnittet istället för att förlita sig på temat. | Avsnittet kan förbli oförändrat eftersom dess direkta formatering åsidosätter temavalet. |
| Teckensnittssubstitution | Ersätter ett begärt teckensnitt när det teckensnittet är otillgängligt eller när en substitutionsregel gäller. | Den verkar efter att ett teckensnitt har begärts; den omdefinierar inte temats skript‑kartläggning. |
| Teckensnittsfallback | Tillhandahåller glyfer som det valda teckensnittet inte innehåller, ofta för specifika Unicode‑intervall. | Den fyller i saknade glyf‑täckningar; den ändrar inte den lagrade temakartläggningen. |

För mer information om de två sista mekanismerna, se [Teckensnittssubstitution](/slides/sv/cpp/font-substitution/) och [Reservteckensnitt](/slides/sv/cpp/fallback-font/).

Att ändra en kartläggning i [Presentation::get_MasterTheme](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_mastertheme/) påverkar endast innehåll vars effektiva formatering fortfarande beror på det temat. Text kan istället ärva ett temas överskuggning från en master, layout eller bild, eller använda ett explicit tilldelat teckensnitt. Inspektera dessa nivåer när det synliga resultatet inte följer presentationens temakartläggning.

## **Gör kartlagda teckensnitt tillgängliga och validera resultatet**

En skriptkartläggning lagrar ett teckensnittsfamiljenamn; den installerar eller laddar inte den motsvarande teckensnittsfilen. För konsekvent rendering och export måste varje kartlagt teckensnitt vara installerat i miljön eller tillhandahållas till Aspose.Slides via en anpassad källa såsom [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/loadexternalfonts/) eller [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/). Se [Anpassade teckensnitt](/slides/sv/cpp/custom-font/) för de tillgängliga laddningsalternativen.

Verifiering av den sparade kartläggningen bekräftar endast att temadefinitionen bevarades. Den bevisar inte att teckensnittet är tillgängligt, innehåller alla erforderliga glyfer eller ger den avsedda layouten. Rendera representativ text för varje behövt skriftsystem till en bild eller PDF och inspektera resultatet. Detta fångar saknade teckensnitt, ofullständig glyf‑täckning, fallback‑beteende och layoutförändringar innan presentationen distribueras. Se [Konvertera PowerPoint‑presentationer](/slides/sv/cpp/convert-powerpoint/) för renderings‑ och exportexempel.

## **Vanliga frågor**

**Vad returnerar `GetScriptFont` när ett skript inte är kartlagt?**

[Fonts::GetScriptFont](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fonts/getscriptfont/) returnerar en null‑sträng när den begärda skriptkartläggningen inte är definierad i den huvud‑ eller bi‑teckensnittssamlingen.

**Lägger `SetScriptFont` till en andra kartläggning när skriptet redan finns?**

Nej. [Fonts::SetScriptFont](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fonts/setscriptfont/) skapar kartläggningen när den saknas och ersätter den kartlagda teckensnittsfamiljen när samma skript‑tagg redan finns.

**Varför ändrade en ändring av temakartläggning inte viss text?**

Texten kan ha ett explicit tilldelat teckensnitt, ärva ett annat tema via en överskuggning, eller påverkas av substitution eller fallback under rendering. En skriptkartläggning på presentationsnivå styr endast text vars effektiva formatering fortfarande hänvisar till den temateckensnittssamlingen.

**Är sparande och återöppning tillräckligt för att validera flerspråkig output?**

Nej. Återöppning verifierar beständighet av temadata. Rendera även representativ text från varje behövt skriftsystem för att bekräfta att de kartlagda teckensnitten är tillgängliga och innehåller de nödvändiga glyferna.