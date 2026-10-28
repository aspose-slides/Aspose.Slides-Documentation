---
title: Manage Presentation Notes in C++
linktitle: Presentation Notes
type: docs
weight: 110
url: /cpp/presentation-notes/
keywords:
- notes
- notes slide
- add notes
- remove notes
- notes style
- master notes
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Remove slide notes and customize master notes text styles in PowerPoint and OpenDocument presentations with Aspose.Slides for C++."
---

## **Overview**

Aspose.Slides for C++ lets you remove notes from individual slides or an entire presentation, customize the text style defined in the master notes slide, and remove notes and handout masters. This article shows how to perform these operations and save the updated presentation.

To read or change notes page dimensions, switch orientation, and check export behavior, see [Notes Page Size](/slides/cpp/notes-size/).

## **Remove Notes from a Slide**

To remove notes from a specific slide, use its [get_NotesSlideManager](https://reference.aspose.com/slides/cpp/aspose.slides/slide/get_notesslidemanager/) and call [RemoveNotesSlide](https://reference.aspose.com/slides/cpp/aspose.slides/notesslidemanager/removenotesslide/). The example loads a presentation containing at least one slide and removes the notes from the first slide, accessed at index zero. Notes on other slides remain unchanged, and the updated presentation is saved in PPTX format.

```cpp
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto notesManager = presentation->get_Slide(0)->get_NotesSlideManager();
notesManager->RemoveNotesSlide();

presentation->Save(u"presentation_without_first_slide_notes.pptx", SaveFormat::Pptx);
```

## **Remove Notes from All Slides**

To remove all slide notes, iterate through the collection returned by [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) and call [RemoveNotesSlide](https://reference.aspose.com/slides/cpp/aspose.slides/notesslidemanager/removenotesslide/) for each slide. This example processes every slide in an existing presentation and saves a PPTX copy without slide notes.

```cpp
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (const auto& slide : System::IterateOver(presentation->get_Slides()))
{
    slide->get_NotesSlideManager()->RemoveNotesSlide();
}

presentation->Save(u"presentation_without_notes.pptx", SaveFormat::Pptx);
```

## **Remove Notes and Handout Masters**

Notes and handout masters define shared formatting and placeholders for their respective page types. Removing a master is a separate operation from removing an individual slide's notes with [RemoveNotesSlide](https://reference.aspose.com/slides/cpp/aspose.slides/notesslidemanager/removenotesslide/).

### **Remove an Unused Notes Master**

When cleaning up a template that has no notes pages, you can remove its unused notes master. Access [get_MasterNotesSlideManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masternotesslidemanager/), check [get_MasterNotesSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/), and call [RemoveMasterNotesSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasternotesslidemanager/removemasternotesslide/).

The following example requires a presentation to contain no notes pages. It removes the notes master if one exists, including its formatting and header/footer placeholders, and saves the template.

```cpp
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"template_without_notes.pptx");

auto manager = presentation->get_MasterNotesSlideManager();
if (manager->get_MasterNotesSlide() != nullptr)
{
    manager->RemoveMasterNotesSlide();
}

presentation->Save(u"template_without_notes_master.pptx", SaveFormat::Pptx);
```

After removal, [get_MasterNotesSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) returns `nullptr`. If the master is already absent, the example skips removal and still saves the presentation.

### **Remove a Handout Master**

To remove a handout master, access [get_MasterHandoutSlideManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masterhandoutslidemanager/), check [get_MasterHandoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/), and call [RemoveMasterHandoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterhandoutslidemanager/removemasterhandoutslide/).

For this example, use a presentation containing slide notes and customized notes and handout masters. Give the handout master a visible banner and header/footer text so that the effect of removal is easy to compare in handout output.

```cpp
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation_with_custom_masters.pptx");

auto manager = presentation->get_MasterHandoutSlideManager();
if (manager->get_MasterHandoutSlide() != nullptr)
{
    manager->RemoveMasterHandoutSlide();
}

presentation->Save(u"presentation_without_handout_master.pptx", SaveFormat::Pptx);
```

After removal, [get_MasterHandoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/) returns `nullptr`. Existing slide notes and the notes master remain unchanged. If the handout master is already absent, the example simply saves the presentation.

In handout output, the removed master's banner, formatting, and header, footer, date/time, and page-number placeholders no longer appear. The presentation slides still appear in the handout layout, including any footer or date text on the slides themselves. Slide numbers added by the handout export settings are separate from the master's page-number placeholder.

If you only want to hide handout headers or footers, change the corresponding placeholder visibility through the [handout master's header/footer manager](/slides/cpp/presentation-header-and-footer/#set-headers-and-footers-on-the-handout-master) instead. This keeps the master and its other formatting, such as a custom banner.

## **Add a Notes Style**

The [get_NotesStyle](https://reference.aspose.com/slides/cpp/aspose.slides/masternotesslide/get_notesstyle/) method of [IMasterNotesSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasternotesslide/) returns the master notes text style. The example accesses the existing [get_MasterNotesSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) and uses [GetLevel](https://reference.aspose.com/slides/cpp/aspose.slides/textstyle/getlevel/) with index zero to select the first paragraph level. It sets the bullet type to [BulletType::Symbol](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/) and saves the presentation in PPTX format. The input must contain a master notes slide for the style change to take effect; otherwise, the presentation is saved without changing the notes style.

```cpp
#include <DOM/BulletType.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto notesMaster = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (notesMaster != nullptr)
{
    auto notesStyle = notesMaster->get_NotesStyle();
    auto paragraphFormat = notesStyle->GetLevel(0);
    paragraphFormat->get_Bullet()->set_Type(BulletType::Symbol);
}

presentation->Save(u"presentation_with_notes_style.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Which API provides access to the notes of a specific slide?**

Use the slide's [get_NotesSlideManager](https://reference.aspose.com/slides/cpp/aspose.slides/slide/get_notesslidemanager/) method. The manager's [get_NotesSlide](https://reference.aspose.com/slides/cpp/aspose.slides/notesslidemanager/get_notesslide/) method returns the notes slide, or `nullptr` if the slide has no notes.

**Does working with notes require Microsoft PowerPoint to be installed?**

No. Aspose.Slides works with notes in PowerPoint and OpenDocument presentations without requiring Microsoft PowerPoint to be installed.
