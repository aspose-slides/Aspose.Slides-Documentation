---
title: "Beheer presentatiekopp en voetteksten in C++"
linktitle: "Kop en voettekst"
type: docs
weight: 140
url: /nl/cpp/presentation-header-and-footer/
keywords:
- kop
- koptekst
- voettekst
- voetteksttekst
- kop instellen
- voettekst instellen
- handout
- notities
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u voettekst-, datum‑tijd‑, dia‑nummer‑ en kop‑plaatsaanduidingen op dia’s, notitiepagina’s en hand‑outs kunt beheren met Aspose.Slides voor C++."
---
## **Overzicht**

PowerPoint gebruikt verschillende kop‑ en voettekst‑plaatsaanduidingen, afhankelijk van het paginatype. Aspose.Slides voor C++ stelt je in staat de tekst en zichtbaarheid van deze plaatsaanduidingen te beheren via kop‑/voettekst‑manager‑interfaces.

De beschikbare plaatsaanduidingen hangen af van de scope:

| Scope | Kop | Voettekst | Datum/tijd | Dia-/paginanummer |
|---|---|---|---|---|
| Reguliere dia | Nee | Ja | Ja | Ja |
| Notitie‑master | Ja | Ja | Ja | Ja |
| Notitie‑dia | Ja | Ja | Ja | Ja |
| Handout‑master | Ja | Ja | Ja | Ja |

Een reguliere presentatiedia heeft geen kop‑plaatsaanduiding. Koppen zijn beschikbaar op notitiepagina’s en hand‑outs. Voor reguliere dia’s gebruik je in plaats daarvan de voettekst‑, datum/tijd‑ en dia‑nummer‑plaatsaanduidingen.

De scope van een wijziging hangt af van de manager die je gebruikt. De [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideheaderfootermanager/) interface regelt één reguliere dia. De [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/inotesslideheaderfootermanager/) interface regelt één notitiedia. Master‑ en layout‑managers kunnen instellingen ook doorvoeren naar afhankelijke dia’s, terwijl de [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) interface de handout‑master regelt.

## **Instellen van voettekst, datum/tijd en dia‑nummers op reguliere dia’s**

Voor reguliere dia’s is de basisworkflow om de header/footer‑manager van elke dia te benaderen, de voettekst‑ en datum/tijd‑tekst in te stellen, de benodigde plaatsaanduidingen in te schakelen en de presentatie op te slaan. Dia‑nummers worden gegenereerd door de presentatie, dus je hoeft alleen de zichtbaarheid ervan te regelen.

Gebruik [`SetFooterText`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootertext/) en [`SetDateTimeText`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimetext/) om tekst in te stellen, en gebruik [`SetFooterVisibility`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimevisibility/) en [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseslideheaderfootermanager/setslidenumbervisibility/) om de overeenkomstige plaatsaanduidingen zichtbaar te maken.

Het volgende end‑to‑end‑voorbeeld past dezelfde voettekst, datum/tijd‑tekst en dia‑nummer‑zichtbaarheid toe op alle reguliere dia’s:

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

Als je slechts één dia wilt bijwerken, benader die dia rechtstreeks via [`Presentation::get_Slide`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_slide/) in plaats van door de volledige dia‑collectie te itereren.

## **Instellen van koppen en voetteksten op de Notitie‑master**

De notitie‑master definieert gemeenschappelijke opmaak en plaatsaanduidingsgedrag voor notitiepagina’s. Gebruik de [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasternotesslideheaderfootermanager/) interface wanneer je alleen de notitie‑master zelf wilt wijzigen.

Het volgende voorbeeld stelt kop, voettekst en datum/tijd‑tekst in op de notitie‑master en maakt alle ondersteunde plaatsaanduidingen zichtbaar op die master:

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

De [`IMasterNotesSlideManager::get_MasterNotesSlide`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) methode retourneert `nullptr` wanneer de presentatie geen notitie‑master bevat.

## **Instellingen van de Notitie‑master toepassen op onderliggende notitiedia’s**

Een notitie‑master kan kop‑ en voettekst‑instellingen toepassen op zichzelf en op alle afhankelijke notitiedia’s. Gebruik de speciale propagatiemethodes op [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasternotesslideheaderfootermanager/) wanneer dezelfde instellingen over de gehele notitie‑hiërarchie moeten worden doorgevoerd.

Bijvoorbeeld, [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheaderstext/) en [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) werken de notitie‑master‑kop en alle onderliggende koppen bij. Gelijkwaardige methodes zijn beschikbaar voor voetteksten, datum/tijd en dia‑nummers.

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

De hierboven gebruikte propagatiemethodes zijn [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), en [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Instellen van koppen en voetteksten op een individuele notitiedia**

Een notitiedia behoort tot een specifieke reguliere dia. Gebruik de [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/inotesslideheaderfootermanager/) interface wanneer je alleen die notitiepagina wilt aanpassen.

De [`INotesSlideManager::AddNotesSlide`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/inotesslidemanager/addnotesslide/) methode retourneert de notitiedia voor de huidige dia en maakt er een aan als deze nog niet bestaat. Het volgende voorbeeld configureert de notitiepagina die bij de eerste presentatiedia hoort:

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

Als je eerst instellingen van de notitie‑master doorvoert en daarna een individuele notitiedia wijzigt, laten de latere per‑dia‑instellingen je die notitiepagina onafhankelijk aanpassen.

## **Instellen van koppen en voetteksten op de Handout‑master**

Handout‑pagina’s gebruiken de handout‑master voor hun kop‑, voettekst‑, datum/tijd‑ en paginanummer‑plaatsaanduidingen. In tegenstelling tot notitiepagina’s worden handout‑instellingen beheerd via de handout‑master en niet via individuele handout‑dia’s.

Gebruik [`IMasterHandoutSlideManager::get_MasterHandoutSlide`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/) om de handout‑master te benaderen. Als deze niet aanwezig is, roep dan [`IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) aan om de standaard handout‑master aan te maken.

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

## **Begrijpen van scope en overerving**

Kies de header/footer‑manager die overeenkomt met de scope die je wilt wijzigen:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideheaderfootermanager/) wijzigt voettekst-, datum/tijd‑ en dia‑nummer‑instellingen voor één reguliere dia.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslideheaderfootermanager/) regelt een layout‑dia en kan ondersteunde instellingen doorvoeren naar afhankelijke dia’s.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslideheaderfootermanager/) regelt een reguliere dia‑master en kan ondersteunde instellingen doorvoeren naar afhankelijke dia’s.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasternotesslideheaderfootermanager/) regelt de notitie‑master en kan instellingen doorvoeren naar alle afhankelijke notitiedia’s.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/inotesslideheaderfootermanager/) wijzigt één notitiedia en ondersteunt een kop‑plaatsaanduiding, naast voettekst, datum/tijd en dia‑nummer.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) wijzigt de handout‑master en ondersteunt alle vier de plaatsaanduidingstypen.

Gebruik propagatie vanuit een master of layout wanneer dezelfde instelling door de gehele hiërarchie moet gelden. Gebruik een individuele dia‑ of notitiedia‑manager wanneer je een lokale instelling voor één pagina nodig hebt.

## **FAQ**

**Kan ik een kop toevoegen aan een reguliere dia?**

Nee. PowerPoint definieert geen kop‑plaatsaanduiding voor reguliere dia’s. Op reguliere dia’s gebruik je de voettekst‑, datum/tijd‑ en dia‑nummer‑plaatsaanduidingen. Kop‑plaatsaanduidingen zijn beschikbaar op notitiepagina’s en hand‑outs.

**Wat gebeurt er als een voettekst-, datum/tijd- of dia‑nummer‑plaatsaanduiding niet zichtbaar is?**

Gebruik de bijbehorende header/footer‑manager om de zichtbaarheid te controleren en in te schakelen wanneer nodig. Bijvoorbeeld, [`get_IsFooterVisible`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseslideheaderfootermanager/get_isfootervisible/) meldt of een voettekst‑plaatsaanduiding aanwezig is, en [`SetFooterVisibility`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/) wijzigt de zichtbaarheid ervan.

**Hoe begin ik met dia‑nummering vanaf een andere waarde dan 1?**

Gebruik [`Presentation::set_FirstSlideNumber`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/set_firstslidenumber/) om het eerste dia‑nummer in te stellen. De dia‑nummer‑plaatsaanduidingen gebruiken vervolgens de bijgewerkte nummeringsreeks.

**Wat gebeurt er met koppen en voetteksten bij het exporteren naar PDF, afbeeldingen of HTML?**

Zichtbare kop‑ en voettekst‑elementen worden samen met de rest van de presentatiewaarde gerenderd in het uitvoerformaat. Hun uiterlijk hangt af van het paginatype dat wordt geëxporteerd en de bijbehorende plaatsaanduidings‑zichtbaarheidsinstellingen.