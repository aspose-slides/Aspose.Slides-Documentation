---
title: Gestire le guide di disegno nelle presentazioni in C++
linktitle: Guide di disegno
type: docs
weight: 85
url: /it/cpp/drawing-guides/
keywords:
- guida di disegno
- guida orizzontale
- guida verticale
- guida di allineamento
- visualizzazione diapositiva
- master diapositiva
- diapositiva di layout
- master note
- master handout
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Aggiungere, accedere e cancellare le guide di disegno orizzontali e verticali nelle presentazioni PowerPoint utilizzando Aspose.Slides per C++."
---
## **Panoramica**

Le guide di disegno sono linee orizzontali e verticali regolabili che aiutano gli utenti ad allineare le forme in modo coerente durante la modifica di una presentazione in PowerPoint. Sono particolarmente utili quando un'applicazione genera una presentazione che sarà poi affinata manualmente: l'applicazione può salvare gli stessi ausili di allineamento che gli autori devono seguire quando aggiungono o spostano i contenuti.

Le guide di disegno sono ausili per la modifica, non contenuto della diapositiva. Non compaiono in una presentazione o nell'output renderizzato. Aspose.Slides per C++ le espone tramite l'interfaccia [IDrawingGuidesCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/idrawingguidescollection/). Una guida è rappresentata da [IDrawingGuide](https://reference.aspose.com/slides/it/cpp/aspose.slides/idrawingguide/) e ha un'orientazione, una posizione e un colore.

La posizione è misurata in punti dall'angolo in alto a sinistra della diapositiva o del master pertinente. Una guida verticale utilizza una coordinata orizzontale, tipicamente compresa tra zero e la larghezza della diapositiva. Una guida orizzontale utilizza una coordinata verticale, tipicamente compresa tra zero e l'altezza della diapositiva.

## **Aggiungere guide alla visualizzazione della diapositiva**

Usa [ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/it/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/) per gestire le guide visualizzate durante la modifica delle diapositive normali. Chiama [IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/it/cpp/aspose.slides/idrawingguidescollection/add/) con un valore di [Orientation](https://reference.aspose.com/slides/it/cpp/aspose.slides/orientation/) e una posizione in punti.

Il seguente esempio aggiunge una guida verticale a destra del centro della diapositiva e una guida orizzontale al di sotto:

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

## **Accedere alle guide di disegno**

Il metodo [IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/it/cpp/aspose.slides/idrawingguidescollection/get_count/) e il metodo [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/it/cpp/aspose.slides/idrawingguidescollection/idx_get/) forniscono l'accesso alle guide esistenti. I metodi [IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/it/cpp/aspose.slides/idrawingguide/get_orientation/), [IDrawingGuide::get_Position](https://reference.aspose.com/slides/it/cpp/aspose.slides/idrawingguide/get_position/) e [IDrawingGuide::get_Color](https://reference.aspose.com/slides/it/cpp/aspose.slides/idrawingguide/get_color/) restituiscono le proprietà attuali di una guida. I relativi metodi setter possono modificare tali proprietà.

Il seguente esempio legge le guide della visualizzazione della diapositiva dalla presentazione creata sopra:

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

## **Aggiungere guide a master e diapositive di layout**

Un master di diapositiva e ciascuna delle sue diapositive di layout possono avere le proprie collezioni di guide di disegno. Usa [IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterslide/get_drawingguides/) per un master di diapositiva e [ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutslide/get_drawingguides/) per una diapositiva di layout.

Il seguente esempio aggiunge una guida verticale al primo master di diapositiva e una guida orizzontale al primo layout di diapositiva:

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

## **Aggiungere guide a master di note e handout**

I master di note e i master di handout supportano anche le guide di disegno. Usa [IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasternotesslide/get_drawingguides/) e [IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/) per accedere alle loro collezioni. Se una presentazione non contiene uno di questi master, [IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) o [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) crea il master predefinito e lo restituisce.

Il seguente esempio aggiunge una guida orizzontale a un master di note e una guida verticale a un master di handout:

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

## **Cancella le guide di disegno**

Chiama [IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/it/cpp/aspose.slides/idrawingguidescollection/clear/) per rimuovere tutte le guide da una determinata collezione. La cancellazione di una collezione non influisce sulle guide memorizzate in un altro ambito.

Il seguente esempio cancella le guide della visualizzazione della diapositiva e tutte le guide sui master di diapositiva, le diapositive di layout, il master di note e il master di handout senza creare i master mancanti:

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

**Le guide di disegno appaiono in una presentazione o in immagini esportate?**

No. Le guide di disegno sono ausili di allineamento per la modifica e non vengono renderizzate come contenuto della presentazione.

**È possibile aggiungere una guida di disegno direttamente a una singola diapositiva normale?**

Le guide di modifica delle diapositive normali sono memorizzate nelle proprietà di visualizzazione della diapositiva della presentazione. Collezioni separate di guide sono disponibili per i master di diapositiva, le diapositive di layout, i master di note e i master di handout.

**Quali unità vengono utilizzate per le posizioni delle guide?**

Le posizioni sono specificate in punti, dove 72 punti corrispondono a un pollice. Le posizioni verticali sono misurate dal bordo sinistro, e le posizioni orizzontali sono misurate dal bordo superiore.

**La cancellazione delle guide di disegno rimuove forme o modifica il contenuto della diapositiva?**

No. Il metodo `Clear` rimuove solo le guide nella collezione selezionata. Le forme e gli altri contenuti della diapositiva rimangono invariati.