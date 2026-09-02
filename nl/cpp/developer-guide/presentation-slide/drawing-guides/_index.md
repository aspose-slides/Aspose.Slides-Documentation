---
title: Beheer Tekenrichtlijnen in Presentaties in C++
linktitle: Tekenrichtlijnen
type: docs
weight: 85
url: /nl/cpp/drawing-guides/
keywords:
- tekenrichtlijn
- horizontale richtlijn
- verticale richtlijn
- uitlijningsrichtlijn
- diaweergave
- masterdia
- layoutdia
- notitiemaster
- handout‑master
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Voeg horizontale en verticale tekenrichtlijnen toe, benader ze en verwijder ze in PowerPoint‑presentaties met Aspose.Slides voor C++."
---
## **Overzicht**

Tekenrichtlijnen zijn verstelbare horizontale en verticale lijnen die gebruikers helpen vormen consistent uit te lijnen tijdens het bewerken van een presentatie in PowerPoint. Ze zijn vooral nuttig wanneer een applicatie een presentatie genereert die later handmatig wordt verfijnd: de applicatie kan dezelfde uitlijningshulpmiddelen opslaan die auteurs moeten volgen bij het toevoegen of verplaatsen van inhoud.

Tekenrichtlijnen zijn bewerking hulpmiddelen, geen dia‑inhoud. Ze verschijnen niet in een diavoorstelling of gerenderde output. Aspose.Slides for C++ maakt ze beschikbaar via de [IDrawingGuidesCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idrawingguidescollection/) interface. Een richtlijn wordt weergegeven door [IDrawingGuide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idrawingguide/) en heeft een oriëntatie, een positie en een kleur.

De positie wordt gemeten in points vanaf de linkerbovenhoek van de betreffende dia of master. Een verticale richtlijn gebruikt een horizontale coördinaat, doorgaans tussen nul en de breedte van de dia. Een horizontale richtlijn gebruikt een verticale coördinaat, doorgaans tussen nul en de hoogte van de dia.

## **Richtlijnen toevoegen aan de diaweergave**

Gebruik [ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/) om richtlijnen te beheren die worden weergegeven tijdens het bewerken van normale dia's. Roep [IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idrawingguidescollection/add/) aan met een [Orientation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/orientation/) waarde en een positie in points.

Het volgende voorbeeld voegt één verticale richtlijn toe rechts van het midden van de dia en één horizontale richtlijn eronder:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/IViewProperties.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

guides->Add(Orientation::Vertical, slideSize.get_Width() / 2 + 12.5f);
guides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 12.5f);

presentation->Save(u"drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Richtlijnen benaderen**

De methoden [IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idrawingguidescollection/get_count/) en [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idrawingguidescollection/idx_get/) bieden toegang tot bestaande richtlijnen. De methoden [IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idrawingguide/get_orientation/), [IDrawingGuide::get_Position](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idrawingguide/get_position/), en [IDrawingGuide::get_Color](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idrawingguide/get_color/) geven de huidige eigenschappen van een richtlijn terug. De bijbehorende setter‑methoden kunnen die eigenschappen wijzigen.

Het volgende voorbeeld leest de richtlijnen in de diaweergave uit de hierboven gemaakte presentatie:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuide.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"drawing-guides.pptx");
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

for (int32_t index = 0; index < guides->get_Count(); index++)
{
    auto guide = guides->idx_get(index);
    System::Console::WriteLine(
        System::String::Format(
            u"Guide {0}: orientation = {1}, position = {2}, color = {3}",
            index,
            guide->get_Orientation(),
            guide->get_Position(),
            guide->get_Color()));
}

presentation->Dispose();
```

## **Richtlijnen toevoegen aan master‑ en layoutdia’s**

Een diapresentatiemaster en elk van zijn layoutdia's kan een eigen collectie tekenrichtlijnen hebben. Gebruik [IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslide/get_drawingguides/) voor een masterdia en [ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslide/get_drawingguides/) voor een layoutdia.

Het volgende voorbeeld voegt een verticale richtlijn toe aan de eerste masterdia en een horizontale richtlijn aan de eerste layoutdia:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto masterGuides = presentation->get_Master(0)->get_DrawingGuides();
auto layoutGuides = presentation->get_LayoutSlide(0)->get_DrawingGuides();

masterGuides->Add(Orientation::Vertical, slideSize.get_Width() / 2 - 20.0f);
layoutGuides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 20.0f);

presentation->Save(u"master-layout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Richtlijnen toevoegen aan notitie‑ en handout‑masters**

Notitiemasters en handout‑masters ondersteunen ook tekenrichtlijnen. Gebruik [IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasternotesslide/get_drawingguides/) en [IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/) om hun collecties te benaderen. Als een presentatie een van deze masters niet bevat, maakt [IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) of [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) de standaard master aan en retourneert deze.

Het volgende voorbeeld voegt een horizontale richtlijn toe aan een notitiemaster en een verticale richtlijn aan een handout‑master:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/INotesSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto notesSize = presentation->get_NotesSize()->get_Size();
auto notesMaster = presentation->get_MasterNotesSlideManager()->SetDefaultMasterNotesSlide();
auto handoutMaster = presentation->get_MasterHandoutSlideManager()->SetDefaultMasterHandoutSlide();

notesMaster->get_DrawingGuides()->Add(Orientation::Horizontal, notesSize.get_Height() / 2 + 50.0f);
handoutMaster->get_DrawingGuides()->Add(Orientation::Vertical, notesSize.get_Width() / 2 - 50.0f);

presentation->Save(u"notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Tekenrichtlijnen wissen**

Roep [IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idrawingguidescollection/clear/) aan om elke richtlijn uit een bepaalde collectie te verwijderen. Het wissen van één collectie heeft geen invloed op richtlijnen die in een andere scope zijn opgeslagen.

Het volgende voorbeeld wist de richtlijnen in de diaweergave en alle richtlijnen op slide‑masters, layoutdia's, de notitiemaster en de handout‑master zonder ontbrekende masters aan te maken:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation-with-guides.pptx");

presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides()->Clear();

for (auto&& masterSlide : presentation->get_Masters())
{
    masterSlide->get_DrawingGuides()->Clear();
}

for (auto&& layoutSlide : presentation->get_LayoutSlides())
{
    layoutSlide->get_DrawingGuides()->Clear();
}

auto notesMaster = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (notesMaster != nullptr)
{
    notesMaster->get_DrawingGuides()->Clear();
}

auto handoutMaster = presentation->get_MasterHandoutSlideManager()->get_MasterHandoutSlide();
if (handoutMaster != nullptr)
{
    handoutMaster->get_DrawingGuides()->Clear();
}

presentation->Save(u"presentation-without-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Verschijnen tekenrichtlijnen in een diavoorstelling of geëxporteerde afbeeldingen?**

Nee. Tekenrichtlijnen zijn uitlijningshulpmiddelen voor het bewerken en worden niet gerenderd als presentatiew inhoud.

**Kan een tekenrichtlijn direct aan een individuele normale dia worden toegevoegd?**

Bewerkingsrichtlijnen voor normale dia's worden opgeslagen in de slide‑view‑eigenschappen van de presentatie. Aparte richtlijn‑collecties zijn beschikbaar voor slide‑masters, layoutdia's, notitiemasters en handout‑masters.

**Welke eenheden worden gebruikt voor de positie van richtlijnen?**

Posities worden opgegeven in points, waarbij 72 points gelijk zijn aan één inch. Verticale posities worden gemeten vanaf de linkerrand, en horizontale posities vanaf de bovenzijde.

**Verwijdert het wissen van tekenrichtlijnen vormen of wijzigt het de dia‑inhoud?**

Nee. De `Clear`‑methode verwijdert alleen de richtlijnen in de geselecteerde collectie. Vormen en andere dia‑inhoud blijven ongewijzigd.