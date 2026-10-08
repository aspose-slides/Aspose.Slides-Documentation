---
title: Lettertypevervanging configureren in presentaties met C++
linktitle: Lettertypevervanging
type: docs
weight: 70
url: /nl/cpp/font-substitution/
keywords:
- lettertype
- vervangend lettertype
- lettertypevervanging
- lettertype vervangen
- vervanging van lettertype
- vervangingsregel
- vervangingsregel
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Configureer lettertypevervangingsregels en inspecteer de vervangen lettertypes in Aspose.Slides voor C++ bij het renderen of converteren van PowerPoint- en OpenDocument‑presentaties."
---
## **Overzicht**

Lettertypevervanging stelt Aspose.Slides in staat een beschikbaar lettertype te gebruiken in plaats van een lettertype dat niet toegankelijk is wanneer een presentatie wordt gerenderd of geconverteerd. De vervanging beïnvloedt de gerenderde uitvoer; het wijzigt het aan de presentatie toegewezen lettertype niet.

U kunt het te gebruiken lettertype definiëren wanneer een specifiek lettertype niet beschikbaar is, en u kunt de vervangingen die Aspose.Slides tijdens het renderen zal toepassen inspecteren. Dit helpt de uitvoer consistent te houden tussen omgevingen met verschillende geïnstalleerde lettertypes.

Als een lettertype beschikbaar is maar geen specifiek vet lettertype heeft, zie [Lettertypes zonder een specifiek vet lettertype behandelen](/slides/nl/cpp/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Die sectie legt uit hoe de getroffen tekst te rasteren tijdens PDF‑export en de gevolgen voor tekstselectie, zoeken en schalen.

## **Lettertypevervangingen ophalen**

Gebruik de [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/)‑methode om te bepalen welke lettertypes worden vervangen wanneer de presentatie wordt gerenderd. De methode retourneert [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/)‑objecten die de oorspronkelijke en vervangen lettertype‑namen identificeren.

Het volgende C++‑voorbeeld geeft alle lettertypevervangingen voor een presentatie weer:

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

## **Lettertypevervangingen ophalen voor geselecteerde dia's**

Gebruik de [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/)‑overload met een `System::ArrayPtr<int32_t> slides`‑argument om alleen de vervangingen te inspecteren die nodig zijn om specifieke dia's te renderen. Dit is handig wanneer u een deel van een presentatie rendert of exporteert, een grote presentatie incrementeel controleert, dia's locateert die afhankelijk zijn van niet‑beschikbare lettertypes, een minimaal lettertype‑pakket voorbereidt voor een server of container, of weergaveverschillen diagnosticeert zonder irrelevante dia's te verwerken.

`slides`‑array bevat één‑gebaseerde dia‑indexen: `1` identificeert de eerste dia. In tegenstelling hiermee gebruikt de [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/)‑methode een nul‑gebaseerde index, zodat dezelfde dia wordt benaderd als `presentation->get_Slide(0)`. Houd dit verschil in gedachten bij het opbouwen van de array om off‑by‑one‑fouten te vermijden.

Roep de overload aan via de [Presentation::get_FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/)‑methode. Deze retourneert alleen de vervangingen die bepaald zijn tijdens het renderen van de geselecteerde dia's. Elk resultaat is een [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/)‑object dat de oorspronkelijke en vervangen lettertype‑namen bevat. Het resultaat weerspiegelt de huidige lettertype‑omgeving, geconfigureerde fallback‑regels, vervangingsregels opgeslagen in een [IFontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsubstrulecollection/), en [extern geladen lettertypes](/slides/nl/cpp/custom-font/).

Dezelfde substitutie kan door meer dan één geselecteerde dia vereist zijn. Dedupliceer de resultaten wanneer u een lettertype‑inventaris of pre‑flight‑rapport maakt. Het volgende voorbeeld rapporteert elke geretourneerde substitutie en maakt daarna een gesorteerde lijst van unieke lettertype‑toewijzingen:

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

De [IFontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/)‑interface biedt beide overloads. Kies er één op basis van de reikwijdte van de render‑operatie:

| Overload | Wanneer te gebruiken |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | U heeft vervangingen nodig voor de volledige presentatie. |
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with `System::ArrayPtr<int32_t> slides` | U heeft vervangingen nodig voor een geselecteerd bereik, incrementele controle, of gedeeltelijke export. |

## **Lettertypevervangingsregels instellen**

Om het lettertype op te geven dat Aspose.Slides moet gebruiken wanneer een bronlettertype niet beschikbaar is:

1. Laad de presentatie.
2. Maak lettertype‑definities voor het bron‑ en vervangende lettertype.
3. Maak een [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/) met de [WhenInaccessible](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstcondition/)‑conditie.
4. Voeg de regel toe aan een [FontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrulecollection/).
5. Wijs de collectie toe met de [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/)‑methode.
6. Render de presentatie of converteer deze.

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
Voor een onvoorwaardelijke wijziging van de in een presentatie gebruikte lettertypes, zie [Lettertypevervanging](/slides/nl/cpp/font-replacement/).
{{% /alert %}}

## **Beperkingen voor wiskundige vergelijking lettertypes**

Lettertypevervangingsregels maken deel uit van het standaard lettertype‑selectieproces dat tijdens het renderen en converteren wordt gebruikt. Ze werken voor reguliere tekst wanneer Aspose.Slides een ontoegankelijk lettertype kan vervangen door het beschikbare lettertype dat in een regel is opgegeven.

Office Math‑vergelijkingen hebben een extra eis. Als een vergelijking **Cambria Math** gebruikt, kan Aspose.Slides dat exacte lettertype nodig hebben om de lay‑out van de vergelijking te berekenen en te renderen. Een regel die een ander wiskundig lettertype vervangt, zoals **STIX Two Math**, kan **Cambria Math** niet voor dit doel vervangen, en de weergave kan nog steeds aangeven dat **Cambria Math** vereist is.

Om zo'n presentatie te renderen of te converteren, zorg ervoor dat **Cambria Math** beschikbaar is voor Aspose.Slides. Installeer het in het besturingssysteem of laad het als een [extern lettertype](/slides/nl/cpp/custom-font/).

Deze beperking geldt voor de lay‑out van de vergelijking. De hierboven beschreven vervangingsregels blijven van toepassing op reguliere presentatietekst.

## **FAQ**

**Wat is het verschil tussen lettertypevervanging en lettertypevervanging (substitutie)?**

[Lettertypevervanging](/slides/nl/cpp/font-replacement/) verandert opzettelijk één lettertype in een ander door de hele presentatie heen. Lettertypevervanging selecteert een lettertype voor de gerenderde uitvoer wanneer aan de geconfigureerde voorwaarde wordt voldaan, zoals wanneer het oorspronkelijke lettertype niet beschikbaar is.

**Wanneer worden substitutieregels toegepast?**

De regels maken deel uit van de [lettertype‑selectiereeks](/slides/nl/cpp/font-selection-sequence/) tijdens het renderen en converteren. Met `WhenInaccessible` wordt een regel alleen gebruikt wanneer Aspose.Slides geen toegang heeft tot het bronlettertype.

**Wat gebeurt er als een lettertype ontbreekt en er geen substitutieregel is geconfigureerd?**

Aspose.Slides selecteert het meest passende beschikbare lettertype volgens zijn lettertype‑selectieproces. Het resultaat hangt af van de in de runtime‑omgeving beschikbare lettertypes.

**Kan ik externe lettertypes laden om vervanging te vermijden?**

Ja. U kunt [externe lettertypes laden](/slides/nl/cpp/custom-font/) zodat Aspose.Slides ze kan gebruiken tijdens het renderen en converteren.

**Distribueert Aspose lettertypes mee met de bibliotheek?**

Nee. U bent verantwoordelijk voor het leveren van lettertypes en het naleven van hun licenties.

**Kunnen substitutieresultaten verschillen tussen Windows, Linux en macOS?**

Ja. Geïnstalleerde lettertypes en zoeklocaties voor lettertypes verschillen per besturingssysteem, zodat een lettertype dat op de ene machine beschikbaar is, op een andere machine mogelijk vervangen moet worden.

**Hoe kan ik de lettertype‑selectie consistent maken bij batchconversies?**

Gebruik dezelfde lettertypebestanden en -versies op elke machine of container, [vereiste externe lettertypes laden](/slides/nl/cpp/custom-font/), en [lettertypes insluiten](/slides/nl/cpp/embedded-font/) wanneer de licentie dit toestaat. U kunt ook [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) aanroepen vóór export om onverwachte substituties te identificeren.