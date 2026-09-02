---
title: Hantera ritningsguider i presentationer i C++
linktitle: Ritningsguider
type: docs
weight: 85
url: /sv/cpp/drawing-guides/
keywords:
- ritningsguide
- horisontell guide
- vertikal guide
- justeringsguide
- bildvy
- masterbild
- layoutbild
- anteckningsmaster
- utdelningsmaster
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lägg till, hämta och rensa horisontella och vertikala ritningsguider i PowerPoint-presentationer med Aspose.Slides för C++."
---
## **Översikt**

Ritningsguider är justerbara horisontella och vertikala linjer som hjälper användare att justera former konsekvent när de redigerar en presentation i PowerPoint. De är särskilt användbara när ett program genererar en presentation som senare kommer att finjusteras manuellt: programmet kan spara samma justeringshjälpmedel som författare bör följa när de lägger till eller flyttar innehåll.

Ritningsguider är redigeringshjälpmedel, inte bildinnehåll. De visas inte i en bildspelsuppvisning eller renderad utskrift. Aspose.Slides för C++ exponerar dem via gränssnittet [IDrawingGuidesCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idrawingguidescollection/). En guide representeras av [IDrawingGuide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idrawingguide/) och har en orientering, en position och en färg.

Positionen mäts i punkter från det övre vänstra hörnet av den relevanta bilden eller masterbilden. En vertikal guide använder en horisontell koordinat, vanligtvis mellan noll och bildens bredd. En horisontell guide använder en vertikal koordinat, vanligtvis mellan noll och bildens höjd.

## **Lägg till guider i bildvyn**

Använd [ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/) för att hantera guider som visas vid redigering av vanliga bilder. Anropa [IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idrawingguidescollection/add/) med ett [Orientation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/orientation/)‑värde och en position i punkter.

Följande exempel lägger till en vertikal guide till höger om bildens centrum och en horisontell guide under den:

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

## **Åtkomst till ritningsguider**

Metoden [IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idrawingguidescollection/get_count/) och metoden [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idrawingguidescollection/idx_get/) ger åtkomst till befintliga guider. Metoderna [IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idrawingguide/get_orientation/), [IDrawingGuide::get_Position](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idrawingguide/get_position/) och [IDrawingGuide::get_Color](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idrawingguide/get_color/) returnerar de aktuella egenskaperna för en guide. Dess motsvarande settermethod kan ändra dessa egenskaper.

Följande exempel läser guidarna i bildvyn från presentationen som skapades ovan:

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

## **Lägg till guider till master‑ och layoutbilder**

En bildmaster och var och en av dess layoutbilder kan ha sina egna samlingar av ritningsguider. Använd [IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterslide/get_drawingguides/) för en master‑bild och [ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutslide/get_drawingguides/) för en layout‑bild.

Följande exempel lägger till en vertikal guide till den första master‑bilden och en horisontell guide till den första layout‑bilden:

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

## **Lägg till guider till antecknings‑ och utdelnings‑master**

Antecknings‑ och utdelnings‑masterbilder stödjer också ritningsguider. Använd [IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasternotesslide/get_drawingguides/) och [IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/) för att komma åt deras samlingar. Om en presentation inte innehåller någon av dessa masterbilder skapar [IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) eller [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) standard‑mastern och returnerar den.

Följande exempel lägger till en horisontell guide till en antecknings‑master och en vertikal guide till en utdelnings‑master:

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

## **Rensa ritningsguider**

Anropa [IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idrawingguidescollection/clear/) för att ta bort alla guider från en viss samling. Att rensa en samling påverkar inte guider som lagras i en annan omfattning.

Följande exempel rensar guiderna i bildvyn och alla guider på bildmaster, layoutbilder, antecknings‑master och utdelnings‑master utan att skapa saknade masterbilder:

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

**Visas ritningsguider i ett bildspel eller exporterade bilder?**

Nej. Ritningsguider är justeringshjälpmedel för redigering och renderas inte som presentationsinnehåll.

**Kan en ritningsguide läggas till direkt på en enskild normal bild?**

Redigeringsguider för normal‑bilder lagras i presentationens bild‑vy‑egenskaper. Separata guidsamlingar finns för bildmaster, layoutbilder, antecknings‑master och utdelnings‑master.

**Vilka enheter används för guidpositioner?**

Positioner anges i punkter, där 72 punkter motsvarar en tum. Vertikala positioner mäts från vänster kant, och horisontella positioner mäts från överkant.

**Tar rensning av ritningsguider bort former eller ändrar bildinnehåll?**

Nej. Metoden `Clear` tar bara bort guiderna i den valda samlingen. Former och annat bildinnehåll förblir oförändrat.