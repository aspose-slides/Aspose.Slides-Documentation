---
title: Správa kreslicích vodítek v prezentacích v C++
linktitle: Kreslicí vodítka
type: docs
weight: 85
url: /cs/cpp/drawing-guides/
keywords:
- kreslicí vodítko
- vodorovné vodítko
- svislé vodítko
- zarovnávací vodítko
- pohled na snímek
- hlavní snímek
- rozvržový snímek
- master poznámek
- master podkladů
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Přidávejte, přistupujte a odstraňujte vodorovná a svislá kreslicí vodítka v prezentacích PowerPoint pomocí Aspose.Slides pro C++."
---
## **Přehled**

Kreslicí vodítka jsou nastavitelná vodorovná a svislá čára, které uživatelům pomáhají konzistentně zarovnávat tvary při úpravě prezentace v PowerPointu. Jsou zvláště užitečná, když aplikace generuje prezentaci, která bude později ručně doladěna: aplikace může uložit stejné pomůcky pro zarovnání, které by autoři měli dodržovat při přidávání nebo přesouvání obsahu.

Kreslicí vodítka jsou pomůcky pro úpravy, ne obsah snímku. Neobjevují se v prezentaci ani v renderovaném výstupu. Aspose.Slides for C++ je zpřístupňuje prostřednictvím rozhraní [IDrawingGuidesCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idrawingguidescollection/). Vodítko je reprezentováno rozhraním [IDrawingGuide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idrawingguide/) a má orientaci, pozici a barvu.

Pozice je měřena v bodech od levého horního rohu příslušného snímku nebo mistra. Vertikální vodítko používá vodorovnou souřadnici, obvykle mezi nulou a šířkou snímku. Horizontální vodítko používá svislou souřadnici, obvykle mezi nulou a výškou snímku.

## **Přidání vodítek do pohledu na snímek**

Pomocí [ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/) spravujte vodítka zobrazovaná při úpravě normálních snímků. Zavolejte [IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idrawingguidescollection/add/) s hodnotou [Orientation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/orientation/) a pozicí v bodech.

Následující příklad přidá jedno svislé vodítko napravo od středu snímku a jedno vodorovné vodítko pod něj:

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

## **Přístup k vodítkům**

Metoda [IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idrawingguidescollection/get_count/) a metoda [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idrawingguidescollection/idx_get/) poskytují přístup k existujícím vodítkům. Metody [IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idrawingguide/get_orientation/), [IDrawingGuide::get_Position](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idrawingguide/get_position/) a [IDrawingGuide::get_Color](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idrawingguide/get_color/) vracejí aktuální vlastnosti vodítka. Odpovídající metody nastavení mohou tyto vlastnosti měnit.

Následující příklad načte vodítka z pohledu na snímek v prezentaci vytvořené výše:

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

## **Přidání vodítek do hlavního snímku a rozvržových snímků**

Hlavní snímek a každý jeho rozvržový snímek mohou mít své vlastní kolekce kreslicích vodítek. Pro hlavní snímek použijte [IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslide/get_drawingguides/) a pro rozvržový snímek [ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutslide/get_drawingguides/).

Následující příklad přidá svislé vodítko do prvního hlavního snímku a vodorovné vodítko do prvního rozvržového snímku:

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

## **Přidání vodítek do poznámkových a letákových mistrovských snímků**

Mistrovské snímky poznámek a letáků také podporují kreslicí vodítka. Použijte [IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasternotesslide/get_drawingguides/) a [IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/) pro přístup k jejich kolekcím. Pokud prezentace neobsahuje některý z těchto mistrů, vytvoří výchozího mistra a vrátí jej metoda [IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) nebo [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/).

Následující příklad přidá vodorovné vodítko do mistrovského snímku poznámek a svislé vodítko do mistrovského snímku letáku:

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

## **Vymazání kreslicích vodítek**

Zavolejte [IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idrawingguidescollection/clear/) pro odebrání všech vodítek z konkrétní kolekce. Vymazání jedné kolekce neovlivní vodítka uložená v jiné oblasti.

Následující příklad vymaže vodítka z pohledu na snímek a všechna vodítka na hlavních snímcích, rozvržových snímcích, mistrovském snímku poznámek a mistrovském snímku letáku bez vytváření chybějících mistrů:

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

**Objevují se kreslicí vodítka v prezentaci nebo exportovaných obrázcích?**

Ne. Kreslicí vodítka jsou pomůcky pro zarovnání při úpravách a nejsou vykreslována jako obsah prezentace.

**Lze kreslicí vodítko přidat přímo k jednotlivému normálnímu snímku?**

Normální vodítka pro úpravy snímků jsou uložena v nastaveních pohledu na snímek prezentace. Samostatné kolekce vodítek jsou k dispozici pro hlavní snímky, rozvržové snímky, poznámkové a letákové mistrovské snímky.

**Jaké jednotky se používají pro umístění vodítek?**

Pozice jsou zadány v bodech, kde 72 bodů odpovídá jedné palci. Vertikální pozice se měří od levého okraje a horizontální pozice od horního okraje.

**Odstraňují vymazání kreslicích vodítek tvary nebo mění obsah snímku?**

Ne. Metoda `Clear` odstraňuje pouze vodítka ve vybrané kolekci. Tvary a ostatní obsah snímku zůstávají nezměněny.