---
title: Verwalten von Hilfslinien in Präsentationen in C++
linktitle: Hilfslinien
type: docs
weight: 85
url: /de/cpp/drawing-guides/
keywords:
- Hilfslinie
- horizontale Hilfslinie
- vertikale Hilfslinie
- Ausrichtungshilfe
- Folienansicht
- Masterfolie
- Layoutfolie
- Notizen-Master
- Handout-Master
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Hinzufügen, Zugreifen und Löschen von horizontalen und vertikalen Hilfslinien in PowerPoint-Präsentationen mit Aspose.Slides für C++."
---
## **Übersicht**

Hilfslinien sind einstellbare horizontale und vertikale Linien, die Benutzern dabei helfen, Formen beim Bearbeiten einer PowerPoint‑Präsentation konsistent auszurichten. Sie sind besonders nützlich, wenn eine Anwendung eine Präsentation erzeugt, die später manuell verfeinert wird: Die Anwendung kann dieselben Ausrichtungshilfen speichern, denen die Autoren beim Hinzufügen oder Verschieben von Inhalten folgen sollten.

Hilfslinien sind Bearbeitungshilfen, kein Folieninhalt. Sie erscheinen nicht in einer Bildschirmpräsentation oder in gerenderten Ausgaben. Aspose.Slides für C++ stellt sie über das Interface [IDrawingGuidesCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/idrawingguidescollection/) bereit. Eine Hilfslinie wird durch [IDrawingGuide](https://reference.aspose.com/slides/de/cpp/aspose.slides/idrawingguide/) repräsentiert und besitzt eine Orientierung, eine Position und eine Farbe.

Die Position wird in Punkten vom oberen linken Eckpunkt der jeweiligen Folie oder des Masters gemessen. Eine vertikale Hilfslinie verwendet eine horizontale Koordinate, typischerweise zwischen Null und der Folienbreite. Eine horizontale Hilfslinie verwendet eine vertikale Koordinate, typischerweise zwischen Null und der Folienhöhe.

## **Hilfslinien zur Folienansicht hinzufügen**

Verwenden Sie [ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/de/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/), um die während der Bearbeitung normaler Folien angezeigten Hilfslinien zu verwalten. Rufen Sie [IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/de/cpp/aspose.slides/idrawingguidescollection/add/) mit einem [Orientation](https://reference.aspose.com/slides/de/cpp/aspose.slides/orientation/)-Wert und einer Position in Punkten auf.

Das folgende Beispiel fügt eine vertikale Hilfslinie rechts von der Folienmitte und eine horizontale Hilfslinie darunter hinzu:

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

## **Zugriff auf Hilfslinien**

Die Methoden [IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/de/cpp/aspose.slides/idrawingguidescollection/get_count/) und [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/de/cpp/aspose.slides/idrawingguidescollection/idx_get/) ermöglichen den Zugriff auf vorhandene Hilfslinien. Die Methoden [IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/de/cpp/aspose.slides/idrawingguide/get_orientation/), [IDrawingGuide::get_Position](https://reference.aspose.com/slides/de/cpp/aspose.slides/idrawingguide/get_position/) und [IDrawingGuide::get_Color](https://reference.aspose.com/slides/de/cpp/aspose.slides/idrawingguide/get_color/) geben die aktuellen Eigenschaften einer Hilfslinie zurück. Die entsprechenden Settermethoden können diese Eigenschaften ändern.

Das folgende Beispiel liest die Hilfslinien der Folienansicht aus der oben erstellten Präsentation:

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

## **Hilfslinien zu Master- und Layoutfolien hinzufügen**

Ein Folienmaster und jede seiner Layoutfolien können eigene Hilfslinien‑Sammlungen besitzen. Verwenden Sie [IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslide/get_drawingguides/) für einen Master‑Slide und [ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutslide/get_drawingguides/) für eine Layout‑Folie.

Das folgende Beispiel fügt einer ersten Master‑Folien und einer ersten Layout‑Folien jeweils eine vertikale bzw. horizontale Hilfslinie hinzu:

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

## **Hilfslinien zu Notizen- und Handout‑Mastern hinzufügen**

Notizen‑Master und Handout‑Master unterstützen ebenfalls Hilfslinien. Verwenden Sie [IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasternotesslide/get_drawingguides/) und [IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/), um auf deren Sammlungen zuzugreifen. Wenn eine Präsentation keinen dieser Master enthält, erzeugt [IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) bzw. [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) den Standard‑Master und gibt ihn zurück.

Das folgende Beispiel fügt einem Notizen‑Master eine horizontale Hilfslinie und einem Handout‑Master eine vertikale Hilfslinie hinzu:

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

## **Hilfslinien löschen**

Rufen Sie [IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/de/cpp/aspose.slides/idrawingguidescollection/clear/) auf, um alle Hilfslinien aus einer bestimmten Sammlung zu entfernen. Das Leeren einer Sammlung wirkt sich nicht auf in einem anderen Kontext gespeicherte Hilfslinien aus.

Das folgende Beispiel löscht die Hilfslinien der Folienansicht sowie alle Hilfslinien auf Folienmastern, Layout‑Folien, dem Notizen‑Master und dem Handout‑Master, ohne fehlende Master zu erzeugen:

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

**Erscheinen Hilfslinien in einer Bildschirmpräsentation oder exportierten Bildern?**

Nein. Hilfslinien sind Ausrichtungshilfen für die Bearbeitung und werden nicht als Präsentationsinhalt gerendert.

**Kann eine Hilfslinie direkt zu einer einzelnen normalen Folie hinzugefügt werden?**

Hilfslinien für die Bearbeitung normaler Folien werden in den Folienansichtseigenschaften der Präsentation gespeichert. Separate Hilfslinien‑Sammlungen stehen für Folienmaster, Layout‑Folien, Notizen‑Master und Handout‑Master zur Verfügung.

**Welche Einheiten werden für die Positionen von Hilfslinien verwendet?**

Positionen werden in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Vertikale Positionen werden vom linken Rand gemessen, horizontale Positionen vom oberen Rand.

**Entfernt das Löschen von Hilfslinien Formen oder ändert den Folieninhalt?**

Nein. Die `Clear`‑Methode entfernt nur die Hilfslinien in der ausgewählten Sammlung. Formen und anderer Folieninhalt bleiben unverändert.