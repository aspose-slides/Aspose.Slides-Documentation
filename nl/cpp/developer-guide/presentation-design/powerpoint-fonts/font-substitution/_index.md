---
title: Lettertype‑substitutie configureren in presentaties in C++
linktitle: Lettertype‑substitutie
type: docs
weight: 70
url: /nl/cpp/font-substitution/
keywords:
- lettertype
- vervangend lettertype
- lettertype‑substitutie
- lettertype vervangen
- lettertype‑vervanging
- substitutieregel
- vervangingsregel
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Configureer regels voor lettertype‑substitutie en inspecteer vervangende lettertypen in Aspose.Slides voor C++ bij het renderen of converteren van PowerPoint‑ en OpenDocument‑presentaties."
---
## **Overzicht**

Lettertype‑substitutie stelt Aspose.Slides in staat om een beschikbaar lettertype te gebruiken in plaats van een lettertype dat niet toegankelijk is wanneer een presentatie wordt gerenderd of geconverteerd. De substitutie heeft invloed op de gerenderde output; het wijzigt het aan de presentatie toegewezen lettertype niet.

U kunt het te gebruiken lettertype definiëren wanneer een bepaald lettertype niet beschikbaar is, en u kunt de substituties inspecteren die Aspose.Slides tijdens het renderen zal uitvoeren. Dit helpt de output consistent te houden tussen omgevingen met verschillende geïnstalleerde lettertypen.

## **Lettertype‑substituties ophalen**

Gebruik de [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontsmanager/getsubstitutions/)‑methode om te bepalen welke lettertypen worden vervangen wanneer de presentatie wordt gerenderd. De methode retourneert [FontSubstitutionInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsubstitutioninfo/)-objecten die de oorspronkelijke en vervangende lettertype‑namen identificeren.

Het volgende C++‑voorbeeld geeft alle lettertype‑substituties voor een presentatie weer:

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

## **Lettertype‑substituties voor geselecteerde dia's ophalen**

Gebruik de [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontsmanager/getsubstitutions/)‑overload met een `System::ArrayPtr<int32_t> slides`‑argument om alleen de substituties te bekijken die nodig zijn om specifieke dia's te renderen. Dit is handig wanneer u een deel van een presentatie rendert of exporteert, een grote presentatie incrementeel controleert, dia's zoekt die afhankelijk zijn van niet‑beschikbare lettertypen, een minimale lettertype‑pakket voor een server of container voorbereidt, of renderingsverschillen diagnosticeert zonder ongerelateerde dia's te verwerken.

De `slides`‑array bevat één‑gebaseerde dia‑indexen: `1` identificeert de eerste dia. Daarentegen gebruikt de [Presentation::get_Slide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_slide/)‑methode een nul‑gebaseerde index, zodat dezelfde dia wordt benaderd als `presentation->get_Slide(0)`. Houd dit verschil in gedachten bij het samenstellen van de array om off‑by‑one‑fouten te voorkomen.

Roep de overload aan via de [Presentation::get_FontsManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_fontsmanager/)‑methode. Deze retourneert alleen de substituties die tijdens het renderen van de geselecteerde dia's zijn bepaald. Elk resultaat is een [FontSubstitutionInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsubstitutioninfo/)-object dat de oorspronkelijke en vervangende lettertype‑namen bevat. Het resultaat weerspiegelt de huidige lettertype‑omgeving, geconfigureerde fallback‑regels, substitutieregels opgeslagen in een [IFontSubstRuleCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontsubstrulecollection/), en [extern geladen lettertypen](/slides/nl/cpp/custom-font/).

Dezelfde substitutie kan door meer dan één geselecteerde dia vereist zijn. Dupliceer de resultaten niet wanneer u een lettertype‑inventaris of pre‑flight‑rapport maakt. Het volgende voorbeeld geeft elke geretourneerde substitutie weer en maakt vervolgens een gesorteerde lijst van unieke lettertype‑koppelingen:

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

De [IFontsManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontsmanager/) interface biedt beide overloads. Kies er één op basis van de reikwijdte van de renderoperatie:

| Overload | Use it when |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | U heeft substituties nodig voor de volledige presentatie. |
| [GetSubstitutions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with `System::ArrayPtr<int32_t> slides` | U heeft substituties nodig voor een geselecteerd bereik, incrementele controle, of gedeeltelijke export. |

## **Lettertype‑substitutieregels instellen**

Om het lettertype op te geven dat Aspose.Slides moet gebruiken wanneer een bronlettertype niet beschikbaar is:

1. Laad de presentatie.
2. Maak lettertype‑definities voor het bron‑ en vervangende lettertype.
3. Maak een [FontSubstRule](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsubstrule/) aan met de [WhenInaccessible](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsubstcondition/)‑voorwaarde.
4. Voeg de regel toe aan een [FontSubstRuleCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsubstrulecollection/).
5. Wijs de collectie toe via de [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/)‑methode.
6. Render of converteer de presentatie.

Het volgende C++‑voorbeeld vervangt `Arial` door `SomeRareFont` wanneer `SomeRareFont` niet beschikbaar is, en rendert vervolgens de eerste dia om het resultaat te verifiëren. Het vervangende lettertype moet beschikbaar zijn voor Aspose.Slides.

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
Voor een onvoorwaardelijke wijziging van de lettertypen die door een hele presentatie worden gebruikt, zie [Font Replacement](/slides/nl/cpp/font-replacement/).
{{% /alert %}}

## **Beperkingen voor wiskundige vergelijking‑lettertypen**

Lettertype‑substitutieregels maken deel uit van het standaardlettertype‑selectieproces dat tijdens het renderen en converteren wordt gebruikt. Ze werken voor gewone tekst wanneer Aspose.Slides een ontoegankelijk lettertype kan vervangen door het beschikbare lettertype dat door een regel is gespecificeerd.

Office Math‑vergelijkingen hebben een extra vereiste. Als een vergelijking **Cambria Math** gebruikt, kan Aspose.Slides dat exacte lettertype nodig hebben om de lay‑out van de vergelijking te berekenen en te renderen. Een regel die een ander wiskundig lettertype vervangt, zoals **STIX Two Math**, kan **Cambria Math** voor dit doel niet vervangen, en renderen kan nog steeds aangeven dat **Cambria Math** vereist is.

Om zo’n presentatie te renderen of converteren, maak **Cambria Math** beschikbaar voor Aspose.Slides. Installeer het in het besturingssysteem of laad het als een [extern lettertype](/slides/nl/cpp/custom-font/).

Deze beperking geldt voor de lay‑out van vergelijkingen. De hierboven beschreven substitutieregels blijven van toepassing op gewone presentatie‑tekst.

## **FAQ**

**Wat is het verschil tussen font replacement en font substitution?**

[Font replacement](/slides/nl/cpp/font-replacement/) wijzigt opzettelijk één lettertype naar een ander door de hele presentatie heen. Font substitution selecteert een lettertype voor de gerenderde output wanneer aan de geconfigureerde voorwaarde wordt voldaan, bijvoorbeeld wanneer het oorspronkelijke lettertype niet beschikbaar is.

**Wanneer worden substitutieregels toegepast?**

De regels maken deel uit van de [font selection sequence](/slides/nl/cpp/font-selection-sequence/) tijdens het renderen en converteren. Met `WhenInaccessible` wordt een regel alleen gebruikt wanneer Aspose.Slides geen toegang heeft tot het bronlettertype.

**Wat gebeurt er wanneer een lettertype ontbreekt en er geen substitutieregel is geconfigureerd?**

Aspose.Slides kiest het dichtstbijzijnde beschikbare lettertype volgens zijn lettertype‑selectieproces. Het resultaat hangt af van de lettertypen die beschikbaar zijn in de runtime‑omgeving.

**Kan ik externe lettertypen laden om substitutie te voorkomen?**

Ja. U kunt [extern lettertypen laden](/slides/nl/cpp/custom-font/) zodat Aspose.Slides ze kan gebruiken tijdens het renderen en converteren.

**Distribueert Aspose lettertypen met de bibliotheek?**

Nee. U bent verantwoordelijk voor het leveren van lettertypen en het naleven van hun licenties.

**Kunnen substitutieresultaten verschillen tussen Windows, Linux en macOS?**

Ja. Geïnstalleerde lettertypen en zoeklocaties voor lettertypen verschillen per besturingssysteem, waardoor een lettertype dat op de ene machine beschikbaar is, op een andere kan moeten worden vervangen.

**Hoe kan ik de lettertype‑selectie consistent maken bij batch‑conversies?**

Gebruik dezelfde lettertype‑bestanden en -versies op elke machine of container, [laad vereiste externe lettertypen](/slides/nl/cpp/custom-font/), en [embed lettertypen](/slides/nl/cpp/embedded-font/) wanneer de licentie dit toestaat. U kunt ook [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontsmanager/getsubstitutions/) aanroepen vóór export om onverwachte substituties te identificeren.