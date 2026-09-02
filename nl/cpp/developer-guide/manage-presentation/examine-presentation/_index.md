---
title: Presentatie‑informatie ophalen en bijwerken in C++
linktitle: Presentatie‑informatie
type: docs
weight: 30
url: /nl/cpp/examine-presentation/
keywords:
- presentatieformaat
- presentatie‑eigenschappen
- document‑eigenschappen
- eigenschappen ophalen
- eigenschappen lezen
- eigenschappen wijzigen
- eigenschappen aanpassen
- eigenschappen bijwerken
- PPTX onderzoeken
- PPT onderzoeken
- ODP onderzoeken
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Verken dia's, structuur en metadata in PowerPoint‑ en OpenDocument‑presentaties met C++ voor snellere inzichten en slimmere content‑audits."
---
## **Overzicht**

Aspose.Slides kan het formaat van een presentatie identificeren en de documentmetadata lezen zonder een volledig presentatie‑objectmodel te maken. Dit is handig wanneer je bestanden moet classificeren, een inventaris wilt opbouwen of eigenschappen wilt inspecteren voordat je beslist of je de presentatie‑inhoud moet laden en verwerken.

Dit artikel toont een lichte inspectie via [PresentationFactory](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentationfactory/) en [IPresentationInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/), evenals gerichte updates via [IDocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idocumentproperties/).

## **Controleren van een presentatiefomaat**

Gebruik [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) om een bestand te inspecteren zonder een [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑instantie te maken. De methode [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/get_loadformat/) geeft het gedetecteerde formaat terug, zoals PPTX, PPT of ODP.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto fileNames = MakeArray<String>({u"pres.pptx", u"pres.ppt", u"pres.odp"});

for (const auto& fileName : fileNames)
{
    auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);
    Console::WriteLine(String::Format(u"{0}: {1}", fileName, ObjectExt::ToString(presentationInfo->get_LoadFormat())));
}
```

## **Een lichte presentatietinventaris opbouwen**

Wanneer je veel presentatiebestanden verwerkt, kun je een compacte inventaris nodig hebben voor validatie, indexering of een document‑beheersysteem. In dit scenario gebruik je [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) om een [IPresentationInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/)‑object te verkrijgen, en roep vervolgens [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) aan om de documentmetadata te lezen. Deze aanpak creëert geen [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑instantie en vereist niet dat je het volledige presentatie‑objectmodel doorloopt.

De uitgebreide eigenschappen die door [IDocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idocumentproperties/) worden blootgesteld, leveren de volgende inventariswaarden:

| Methode | Inventariswaarde |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idocumentproperties/get_slides/) | Totaal aantal dia's. |
| [get_HiddenSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | Aantal verborgen dia's. |
| [get_Notes](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idocumentproperties/get_notes/) | Aantal dia's met notities. |
| [get_Paragraphs](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | Totaal aantal alinea's, wanneer beschikbaar. |
| [get_Words](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idocumentproperties/get_words/) | Totaal aantal woorden. |
| [get_MultimediaClips](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | Totaal aantal audio‑ en videoclips. |

Het volgende voorbeeld leest deze waarden zonder een [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑object te maken en drukt een compacte inventaris af. Het combineert bovendien [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idocumentproperties/get_headingpairs/) met [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) om content‑groepen weer te geven, zoals lettertypen, thema's en dia‑titels.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IHeadingPair.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/console.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto filePath = String(u"sample.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);
auto documentProperties = presentationInfo->ReadDocumentProperties();

Console::WriteLine(String::Format(u"File: {0}", Path::GetFileName(filePath)));
Console::WriteLine(String::Format(u"Format: {0}", ObjectExt::ToString(presentationInfo->get_LoadFormat())));
Console::WriteLine(String::Format(u"Title: {0}", documentProperties->get_Title()));
Console::WriteLine(String::Format(u"Author: {0}", documentProperties->get_Author()));
Console::WriteLine(u"Statistics:");
Console::WriteLine(String::Format(u"  Slides: {0}", documentProperties->get_Slides()));
Console::WriteLine(String::Format(u"  Hidden slides: {0}", documentProperties->get_HiddenSlides()));
Console::WriteLine(String::Format(u"  Slides with notes: {0}", documentProperties->get_Notes()));
Console::WriteLine(String::Format(u"  Paragraphs: {0}", documentProperties->get_Paragraphs()));
Console::WriteLine(String::Format(u"  Words: {0}", documentProperties->get_Words()));
Console::WriteLine(String::Format(u"  Multimedia clips: {0}", documentProperties->get_MultimediaClips()));

auto headingPairs = documentProperties->get_HeadingPairs();
auto titlesOfParts = documentProperties->get_TitlesOfParts();
auto partIndex = 0;

if (headingPairs == nullptr || titlesOfParts == nullptr || headingPairs->get_Length() == 0 || titlesOfParts->get_Length() == 0)
{
    Console::WriteLine(u"Content groups: not available");
}
else
{
    Console::WriteLine(u"Content groups:");

    for (const auto& headingPair : headingPairs)
    {
        auto partCount = headingPair->get_Count();
        Console::WriteLine(String::Format(u"  {0} ({1})", headingPair->get_Name(), partCount));

        for (auto partOffset = 0; partOffset < partCount && partIndex < titlesOfParts->get_Length(); partOffset++)
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts->get_Length())
    {
        Console::WriteLine(u"  Other parts:");

        while (partIndex < titlesOfParts->get_Length())
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }
}
```

Elk [IHeadingPair](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iheadingpair/) levert een groepsnaam via [IHeadingPair::get_Name](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iheadingpair/get_name/) en het aantal items in die groep via [IHeadingPair::get_Count](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iheadingpair/get_count/). [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) retourneert een platte, geordende array, dus verwerk het aantal opeenvolgende titels dat door elk heading‑pair wordt gespecificeerd.

### **Opgeslagen metadata en formatbeperkingen**

De inventariseereigenschappen die door [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) worden geretourneerd, weerspiegelen de metadata die beschikbaar is in het bron‑document. Aspose.Slides laadt en doorloopt het presentatie‑objectmodel niet opnieuw om deze waarden voor deze oproep te herberekenen. Ontbrekende eigenschappen worden weergegeven met standaardwaarden, en opgeslagen waarden kunnen verouderd zijn als de applicatie die het bestand als laatste heeft opgeslagen de documenteigenschappen niet heeft bijgewerkt.

- **PPTX:** Het formaat levert uitgebreide documenteigenschappen voor dia‑, notitie‑, verborgen‑dia‑, alinea‑, woord‑ en multimedia‑tellingen, evenals heading‑pairs en part‑titles. De beschikbaarheid hangt af van welke eigenschappen zijn weggeschreven door de documentproducent.
- **PPT:** Het binaire formaat kan overeenkomstige document‑samenvattings‑eigenschappen opslaan. Als een eigenschap afwezig is of niet is ververst door de documentproducent, retourneert Aspose.Slides de opgeslagen of standaardwaarde in plaats van deze te berekenen uit de dia's.
- **ODP:** OpenDocument‑metadata levert algemene documentstatistieken, zoals pagina‑, alinea‑ en woord‑tellingen, maar deze waarden komen niet overeen met elke PowerPoint‑specifieke uitgebreide eigenschap. Metadata voor verborgen dia's, notitiedia's, multimedia, heading‑pairs en part‑titles kan ontbreken, en de inventariseereigenschappen kunnen standaardwaarden retourneren. Beschouw een nul‑waarde of een lege array niet als definitief bewijs dat de corresponderende inhoud afwezig is.

Gebruik de lichte metadata‑benadering voor inventarissen en voorlopige controles. Laad de presentatie en inspecteer het live‑objectmodel wanneer het resultaat moet weerspiegelen in‑memory wijzigingen of wanneer je de feitelijke presentatiewaarde wilt verifiëren.

## **Presentatie‑eigenschappen bijwerken**

De eigenschappen die door [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) worden geretourneerd, kunnen ook worden gewijzigd zonder een [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑instantie te maken. Pas de wijzigingen toe met [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/), en schrijf vervolgens de gebonden presentatie met [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/).

De onderstaande afbeelding toont de originele documenteigenschappen van de PowerPoint‑presentatie.

![Originele documenteigenschappen van de PowerPoint-presentatie](input_properties.png)

Het volgende voorbeeld wijzigt de titel en de laatste opgeslagen tijd en schrijft het resultaat naar een nieuw bestand:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto sourceFile = String(u"sample.pptx");
auto outputFile = String(u"sample_with_updated_properties.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(sourceFile);
auto documentProperties = presentationInfo->ReadDocumentProperties();

documentProperties->set_Title(u"Quarterly sales report");
documentProperties->set_LastSavedTime(DateTime::get_UtcNow());

presentationInfo->UpdateDocumentProperties(documentProperties);
presentationInfo->WriteBindedPresentation(outputFile);
```

De onderstaande afbeelding toont de bijgewerkte documenteigenschappen van de PowerPoint‑presentatie.

![Bijgewerkte documenteigenschappen van de PowerPoint-presentatie](output_properties.png)

## **Handige links**

Voor gerelateerde beveiligingscontroles en beschermingsinstellingen, zie de volgende artikelen:

- [Presentaties met wachtwoord beveiligen](/slides/nl/cpp/password-protected-presentation/)
- [Presentaties tegen schrijven beveiligen](/slides/nl/cpp/write-protected-presentation/)

## **FAQ**

**Hoe kan ik controleren of lettertypen zijn ingesloten en welke dat zijn?**

Laad de presentatie en gebruik [Presentation::get_FontsManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_fontsmanager/). Roep [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/getembeddedfonts/) aan om de ingesloten lettertypen te verkrijgen en [FontsManager::GetFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/getfonts/) om de door de presentatie gebruikte lettertypen te verkrijgen. Vergelijk de twee resultaten om lettertypen te vinden die nodig zijn voor weergave maar niet zijn ingesloten.

**Hoe kan ik snel zien of het bestand verborgen dia's bevat en hoeveel?**

Wanneer opgeslagen documentmetadata voldoende is, lees [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) via [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) en [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/). Dit is geschikt voor een lichte inventaris. Als de presentatie in het geheugen is aangepast, kan de opgeslagen metadata ontbreken of verouderd zijn, of moet je live‑waarden verifiëren door door [Presentation::get_Slides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_slides/) te itereren en elke dia‑[Slide::get_Hidden](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slide/get_hidden/)‑methode te inspecteren.

**Kan ik detecteren of een aangepaste dia‑grootte en oriëntatie worden gebruikt, en of deze afwijken van de standaardinstellingen?**

Ja. Laad de presentatie en lees [Presentation::get_SlideSize](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_slidesize/). Inspecteer [ISlideSize::get_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidesize/get_type/), [ISlideSize::get_Size](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidesize/get_size/) en [ISlideSize::get_Orientation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidesize/get_orientation/) om de huidige instellingen te vergelijken met de verwachte voorinstelling en afmetingen.

**Is er een snelle manier om te zien of grafieken externe gegevensbronnen gebruiken?**

Ja. Zoek elke [Chart](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chart/) en inspecteer [ChartData::get_DataSourceType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chartdata/get_datasourcetype/). Voor een externe werkmap, lees [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Het gegevenstype en pad identificeren een externe verwijzing, maar het verifiëren of het doel beschikbaar is, vereist een aparte resource‑check.

**Hoe kan ik 'zware' dia's beoordelen die de weergave of PDF‑export kunnen vertragen?**

Er bestaat geen enkele complexiteits‑eigenschap. Doorloop [Presentation::get_Slides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_slides/) en elke dia‑[IBaseSlide::get_Shapes](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseslide/get_shapes/)‑collectie. Gebruik het aantal vormen en de aanwezigheid van grote afbeeldingen, effecten, animaties of multimedia als screeningssignalen, en meet een representatieve render of export voordat je een dia als bevestigd prestatie‑knelpunt behandelt.