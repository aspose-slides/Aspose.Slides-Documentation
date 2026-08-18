---
title: Hantera presentationens sidhuvuden och sidfötter i C++
linktitle: Sidhuvud och sidfot
type: docs
weight: 140
url: /sv/cpp/presentation-header-and-footer/
keywords:
- sidhuvud
- sidhuvudstext
- sidfot
- sidfotstext
- ange sidhuvud
- ange sidfot
- utdelning
- anteckningar
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du hanterar platshållare för sidfot, datum-tid, bildnummer och sidhuvud på bilder, anteckningssidor och utdelningar med Aspose.Slides för C++."
---
## **Översikt**

PowerPoint använder olika platshållare för sidhuvud och sidfot beroende på sidtyp. Aspose.Slides för C++ låter dig kontrollera texten och synligheten för dessa platshållare via gränssnitt för sidhuvud‑/sidfot‑hanterare.

De tillgängliga platshållarna beror på omfånget:

| Omfång | Sidhuvud | Sidfot | Datum/tid | Bild/sidnummer |
|---|---|---|---|---|
| Vanlig bild | Nej | Ja | Ja | Ja |
| Antecknings‑master | Ja | Ja | Ja | Ja |
| Anteckningsbild | Ja | Ja | Ja | Ja |
| Utdelnings‑master | Ja | Ja | Ja | Ja |

En vanlig presentationsbild har ingen sidhuvud‑platshållare. Sidhuvuden finns på anteckningssidor och utdelningar. För vanliga bilder bör du använda sidfot-, datum/tid‑ och bild‑/sidnummer‑platshållare istället.

Omfånget för en ändring beror på vilken hanterare du använder. Gränssnittet [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideheaderfootermanager/) styr en vanlig bild. Gränssnittet [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/inotesslideheaderfootermanager/) styr en anteckningsbild. Master‑ och layout‑hanterare kan även sprida inställningar till beroende bilder, medan gränssnittet [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) styr utdelnings‑mastern.

## **Ställ in sidfot, datum/tid och bildnummer på vanliga bilder**

För vanliga bilder är det grundläggande arbetsflödet att åtkomma varje bilds sidhuvud-/sidfot‑hanterare, ange texten för sidfot och datum/tid, aktivera de behövda platshållarna och spara presentationen. Bildnummer genereras av presentationen, så du behöver bara kontrollera deras synlighet.

Använd [`SetFooterText`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootertext/) och [`SetDateTimeText`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimetext/) för att ange text, och använd [`SetFooterVisibility`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimevisibility/), och [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseslideheaderfootermanager/setslidenumbervisibility/) för att visa motsvarande platshållare.

Följande end‑to‑end‑exempel tillämpar samma sidfot, datum/tid‑text och bildnummer‑synlighet på alla vanliga bilder:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (const auto& slide : System::IterateOver(presentation->get_Slides()))
{
    auto headerFooterManager = slide->get_HeaderFooterManager();

    headerFooterManager->SetFooterText(u"Company Confidential");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_slide_footers.pptx", SaveFormat::Pptx);
```

Om du bara behöver uppdatera en bild, åtkom den bilden direkt via [`Presentation::get_Slide`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_slide/) istället för att iterera igenom hela bildsamlingen.

## **Ställ in sidhuvuden och sidfötter på antecknings‑mastern**

Antecknings‑mastern definierar gemensam formatering och platshållarbeteende för anteckningssidor. Använd gränssnittet [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasternotesslideheaderfootermanager/) när du bara vill ändra själva antecknings‑mastern.

Följande exempel anger sidhuvud, sidfot och datum/tid‑text på antecknings‑mastern och gör alla stödjade platshållare synliga på den mastern:

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Notes header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Notes footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
```

[`IMasterNotesSlideManager::get_MasterNotesSlide`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/)‑metoden returnerar `nullptr` när presentationen inte innehåller en antecknings‑master.

## **Tillämpa antecknings‑masterns inställningar på underordnade anteckningsbilder**

En antecknings‑master kan tillämpa sidhuvuds‑ och sidfot‑inställningar på sig själv och på alla beroende anteckningsbilder. Använd de dedikerade spridningsmetoderna på [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasternotesslideheaderfootermanager/) när samma inställningar ska tillämpas över hela anteckningshierarkin.

Till exempel uppdaterar [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheaderstext/) och [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) antecknings‑masterns sidhuvud och alla underordnade sidhuvuden. Lika metoder finns för sidfötter, datum/tid och bildnummer.

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderAndChildHeadersText(u"Notes header");
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager->SetFooterAndChildFootersText(u"Notes footer");
    headerFooterManager->SetFooterAndChildFootersVisibility(true);

    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation->Save(u"presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
```

Spridningsmetoderna som användes ovan är [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), och [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Ställ in sidhuvuden och sidfötter på en enskild anteckningsbild**

En anteckningsbild hör till en specifik vanlig bild. Använd dess [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/inotesslideheaderfootermanager/)‑gränssnitt när du endast vill anpassa den anteckningssidan.

[`INotesSlideManager::AddNotesSlide`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/inotesslidemanager/addnotesslide/)‑metoden returnerar anteckningsbilden för den aktuella bilden och skapar en om den inte redan finns. Följande exempel konfigurerar anteckningssidan som är kopplad till den första presentationsbilden:

```cpp
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideHeaderFooterManager.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
auto headerFooterManager = notesSlide->get_HeaderFooterManager();

headerFooterManager->SetHeaderText(u"Header for the first notes page");
headerFooterManager->SetHeaderVisibility(true);

headerFooterManager->SetFooterText(u"Footer for the first notes page");
headerFooterManager->SetFooterVisibility(true);

headerFooterManager->SetDateTimeText(u"Date and time text");
headerFooterManager->SetDateTimeVisibility(true);

headerFooterManager->SetSlideNumberVisibility(true);

presentation->Save(u"presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
```

Om du först sprider inställningar från antecknings‑mastern och sedan ändrar en enskild anteckningsbild, låter de senare per‑bild‑inställningarna dig anpassa den anteckningssidan självständigt.

## **Ställ in sidhuvuden och sidfötter på utdelnings‑mastern**

Utdelningssidor använder utdelnings‑mastern för sina sidhuvuds‑, sidfot‑, datum/tid‑ och sidnummer‑platshållare. Till skillnad från anteckningssidor hanteras utdelningsinställningar via utdelnings‑mastern snarare än via enskilda utdelningsbilder.

Använd [`IMasterHandoutSlideManager::get_MasterHandoutSlide`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/) för att komma åt utdelnings‑mastern. Om den inte finns, anropa [`IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) för att skapa standard‑utdelnings‑mastern.

```cpp
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideHeaderFooterManager.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterHandoutSlideManager = presentation->get_MasterHandoutSlideManager();
auto masterHandoutSlide = masterHandoutSlideManager->get_MasterHandoutSlide();

if (masterHandoutSlide == nullptr)
{
    masterHandoutSlide = masterHandoutSlideManager->SetDefaultMasterHandoutSlide();
}

if (masterHandoutSlide != nullptr)
{
    auto headerFooterManager = masterHandoutSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Handout header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Handout footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_handout_footers.pptx", SaveFormat::Pptx);
```

## **Förstå omfång och arv**

Välj den sidhuvud‑/sidfot‑hanterare som matchar det omfång du vill ändra:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideheaderfootermanager/) ändrar inställningar för sidfot, datum/tid och bildnummer för en vanlig bild.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutslideheaderfootermanager/) styr en layout‑bild och kan sprida stödjade inställningar till beroende bilder.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterslideheaderfootermanager/) styr en vanlig bild‑master och kan sprida stödjade inställningar till beroende bilder.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasternotesslideheaderfootermanager/) styr antecknings‑mastern och kan sprida inställningar till alla beroende anteckningsbilder.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/inotesslideheaderfootermanager/) ändrar en anteckningsbild och stöder ett sidhuvud‑platshållare utöver sidfot, datum/tid och bildnummer.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) ändrar utdelnings‑mastern och stöder alla fyra platshållartyper.

Använd spridning från en master‑ eller layout‑hanterare när samma inställning ska gälla i hela dess hierarki. Använd en enskild bild‑ eller antecknings‑slide‑hanterare när du behöver en lokal inställning för en sida.

## **Vanliga frågor**

**Kan jag lägga till ett sidhuvud på en vanlig bild?**

Nej. PowerPoint definierar ingen sidhuvud‑platshållare för vanliga bilder. På vanliga bilder ska du använda sidfot‑, datum/tid‑ och bildnummer‑platshållare. Sidhuvuds‑platshållare finns på anteckningssidor och utdelningar.

**Vad händer om en sidfot, datum/tid eller bildnummer‑platshållare inte är synlig?**

Använd motsvarande sidhuvud‑/sidfot‑hanterare för att kontrollera dess synlighet och aktivera den vid behov. Till exempel rapporterar [`get_IsFooterVisible`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseslideheaderfootermanager/get_isfootervisible/) om en sidfot‑platshållare finns, och [`SetFooterVisibility`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/) ändrar dess synlighet.

**Hur startar jag bildnumreringen från ett annat värde än 1?**

Använd [`Presentation::set_FirstSlideNumber`](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/set_firstslidenumber/) för att ange det första bildnumret. Bildnummer‑platshållarna använder då den uppdaterade numreringssekvensen.

**Vad händer med sidhuvuden och sidfötter vid export till PDF, bilder eller HTML?**

Synliga sidhuvuds‑ och sidfots‑element renderas tillsammans med resten av presentationsinnehållet i det exporterade formatet. Deras utseende beror på vilken sidtyp som exporteras och de motsvarande platshållarens synlighetsinställningar.