---
title: Manage Drawing Guides in Presentations in C++
linktitle: Drawing Guides
type: docs
weight: 85
url: /cpp/drawing-guides/
keywords:
- drawing guide
- horizontal guide
- vertical guide
- alignment guide
- slide view
- master slide
- layout slide
- notes master
- handout master
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Add, access, and clear horizontal and vertical drawing guides in PowerPoint presentations using Aspose.Slides for C++."
---

## **Overview**

Drawing guides are adjustable horizontal and vertical lines that help users align shapes consistently while editing a presentation in PowerPoint. They are especially useful when an application generates a presentation that will later be refined manually: the application can save the same alignment aids that authors should follow when adding or moving content.

Drawing guides are editing aids, not slide content. They do not appear in a slide show or rendered output. Aspose.Slides for C++ exposes them through the [IDrawingGuidesCollection](https://reference.aspose.com/slides/cpp/aspose.slides/idrawingguidescollection/) interface. A guide is represented by [IDrawingGuide](https://reference.aspose.com/slides/cpp/aspose.slides/idrawingguide/) and has an orientation, a position, and a color.

The position is measured in points from the top-left corner of the relevant slide or master. A vertical guide uses a horizontal coordinate, typically between zero and the slide width. A horizontal guide uses a vertical coordinate, typically between zero and the slide height.

## **Add Guides to the Slide View**

Use [ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/) to manage guides displayed while editing normal slides. Call [IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/idrawingguidescollection/add/) with an [Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/orientation/) value and a position in points.

The following example adds one vertical guide to the right of the slide center and one horizontal guide below it:

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

## **Access Drawing Guides**

The [IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/cpp/aspose.slides/idrawingguidescollection/get_count/) method and [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idrawingguidescollection/idx_get/) method provide access to existing guides. The [IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/idrawingguide/get_orientation/), [IDrawingGuide::get_Position](https://reference.aspose.com/slides/cpp/aspose.slides/idrawingguide/get_position/), and [IDrawingGuide::get_Color](https://reference.aspose.com/slides/cpp/aspose.slides/idrawingguide/get_color/) methods return the current properties of a guide. Their corresponding setter methods can change those properties.

The following example reads the slide-view guides from the presentation created above:

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

## **Add Guides to Master and Layout Slides**

A slide master and each of its layout slides can have their own drawing-guide collections. Use [IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_drawingguides/) for a master slide and [ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/get_drawingguides/) for a layout slide.

The following example adds a vertical guide to the first master slide and a horizontal guide to the first layout slide:

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

## **Add Guides to Notes and Handout Masters**

Notes masters and handout masters also support drawing guides. Use [IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/cpp/aspose.slides/imasternotesslide/get_drawingguides/) and [IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/) to access their collections. If a presentation does not contain one of these masters, [IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) or [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) creates the default master and returns it.

The following example adds a horizontal guide to a notes master and a vertical guide to a handout master:

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

## **Clear Drawing Guides**

Call [IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/idrawingguidescollection/clear/) to remove every guide from a particular collection. Clearing one collection does not affect guides stored in another scope.

The following example clears the slide-view guides and all guides on slide masters, layout slides, the notes master, and the handout master without creating missing masters:

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

**Do drawing guides appear in a slide show or exported images?**

No. Drawing guides are alignment aids for editing and are not rendered as presentation content.

**Can a drawing guide be added directly to an individual normal slide?**

Normal-slide editing guides are stored in the presentation's slide-view properties. Separate guide collections are available for slide masters, layout slides, notes masters, and handout masters.

**Which units are used for guide positions?**

Positions are specified in points, where 72 points equal one inch. Vertical positions are measured from the left edge, and horizontal positions are measured from the top edge.

**Does clearing drawing guides remove shapes or change slide content?**

No. The `Clear` method removes only the guides in the selected collection. Shapes and other slide content remain unchanged.
