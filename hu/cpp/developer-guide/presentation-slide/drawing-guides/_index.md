---
title: Rajzolóújszabályok kezelése prezentációkban C++-ban
linktitle: Rajzolóújszabályok
type: docs
weight: 85
url: /hu/cpp/drawing-guides/
keywords:
- rajzolóújszabály
- vízszintes útmutató
- függőleges útmutató
- igazítási útmutató
- dia nézet
- mester dia
- elrendezés dia
- jegyzet mester
- szórólap mester
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Állítsa be, érje el és törölje a vízszintes és függőleges rajzolóújszabályokat PowerPoint prezentációkban az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

A rajzolóújszabályok állítható vízszintes és függőleges vonalak, amelyek segítik a felhasználókat a formák konzisztens igazításában a PowerPoint prezentáció szerkesztése során. Különösen akkor hasznosak, ha egy alkalmazás generál egy prezentációt, amelyet később kézzel fognak finomítani: az alkalmazás elmentheti ugyanazokat az igazítási segédeket, amelyeket a szerzőknek követniük kell a tartalom hozzáadásakor vagy áthelyezésekor.

A rajzolóújszabályok szerkesztési segédeszközök, nem diátartalom. Nem jelennek meg diavetítésben vagy a megjelenített kimenetben. Az Aspose.Slides for C++ ezeket a [IDrawingGuidesCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idrawingguidescollection/) interfészen keresztül teszi elérhetővé. Egy útmutató a [IDrawingGuide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idrawingguide/) által van reprezentálva, és rendelkezik orientációval, pozícióval és színnel.

A pozíció pontban van mérve a megfelelő dia vagy minta bal felső sarkától. A függőleges útmutató vízszintes koordinátát használ, általában 0 és a dia szélessége között. A vízszintes útmutató függőleges koordinátát használ, általában 0 és a dia magassága között.

## **Útmutatók hozzáadása a dia nézethez**

Használja a [ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/) metódust a normál diák szerkesztése közben megjelenő útmutatók kezeléséhez. Hívja a [IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idrawingguidescollection/add/) metódust egy [Orientation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/orientation/) értékkel és pontban megadott pozícióval.

Az alábbi példa egy függőleges útmutatót ad a dia középpontjától jobbra, és egy vízszintes útmutatót alatta:

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

## **Útmutatók elérése**

Az [IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idrawingguidescollection/get_count/) metódus és az [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idrawingguidescollection/idx_get/) metódus hozzáférést biztosít a meglévő útmutatókhoz. Az [IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idrawingguide/get_orientation/), az [IDrawingGuide::get_Position](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idrawingguide/get_position/) és az [IDrawingGuide::get_Color](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idrawingguide/get_color/) metódusok visszaadják egy útmutató aktuális tulajdonságait. A megfelelő beállító metódusaik megváltoztathatják ezeket a tulajdonságokat.

Az alábbi példa beolvassa a fenti példában létrehozott prezentáció dia-nézet útmutatóit:

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

## **Útmutatók hozzáadása a minta- és elrendezés diákhoz**

A dia mester és minden elrendezés diája saját rajzolóújszabály-gyűjteménnyel rendelkezhet. Használja az [IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslide/get_drawingguides/) metódust egy mester dia esetén, és az [ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslide/get_drawingguides/) metódust egy elrendezés dia esetén.

Az alábbi példa egy függőleges útmutatót ad az első minta diához és egy vízszintes útmutatót az első elrendezés diához:

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

## **Útmutatók hozzáadása a jegyzet és a szórólap mesterekhez**

A jegyzet mesterek és a szórólap mesterek is támogatják a rajzolóújszabályokat. Használja a [IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasternotesslide/get_drawingguides/) és a [IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/) metódusokat a gyűjteményeik eléréséhez. Ha egy prezentáció nem tartalmaz ilyen mestert, a [IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) vagy a [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) létrehozza az alapértelmezett mestert és visszaadja azt.

Az alábbi példa egy vízszintes útmutatót ad egy jegyzet mesterhez és egy függőleges útmutatót egy szórólap mesterhez:

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

## **Rajzolóújszabályok törlése**

Hívja az [IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/hu/cpp/aspose.slides/idrawingguidescollection/clear/) metódust, hogy minden útmutatót eltávolítson egy adott gyűjteményből. Egy gyűjtemény törlése nem befolyásolja a másik tartományban tárolt útmutatókat.

Az alábbi példa törli a dia-nézet útmutatókat és az összes útmutatót a dia mestereken, elrendezés diákon, a jegyzet mesteren és a szórólap mesteren, anélkül hogy hiányzó mestereket hozna létre:

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

## **GYIK**

**Megjelennek a rajzolóújszabályok diavetítésben vagy exportált képeken?**

Nem. A rajzolóújszabályok szerkesztési segédeszközök, és nem jelennek meg a prezentáció tartalmaként.

**Lehet-e rajzolóújszabályt közvetlenül egy adott normál diára hozzáadni?**

A normál diák szerkesztési útmutatói a prezentáció dia-nézet tulajdonságaiban tárolódnak. Külön útmutatógyűjtemények érhetők el dia mesterek, elrendezés diák, jegyzet mesterek és szórólap mesterek számára.

**Milyen mértékegységeket használnak az útmutatók pozícióihoz?**

A pozíciókat pontban adják meg, ahol 72 pont egy hüvelyknek felel meg. A függőleges pozíciók a bal élből, a vízszintes pozíciók a felső élből mérődnek.

**A rajzolóújszabályok törlése eltávolítja-e az alakzatokat vagy megváltoztatja a diatartalmat?**

Nem. A `Clear` metódus csak a kiválasztott gyűjtemény útmutatóit távolítja el. Az alakzatok és egyéb diatartalom változatlan marad.