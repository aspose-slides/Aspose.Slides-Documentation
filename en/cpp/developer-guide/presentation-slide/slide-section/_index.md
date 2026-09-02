---
title: Manage Slide Sections in Presentations with C++
linktitle: Slide Section
type: docs
weight: 100
url: /cpp/slide-section/
keywords:
- create section
- add section
- edit section
- change section
- section name
- retrieve section slides
- process section slides
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Manage slide sections with Aspose.Slides for C++: create, rename, reorder, retrieve, and process section slides in PPTX presentations."
---

## **Introduction**

Sections organize consecutive slides into named groups without changing the slide content. With Aspose.Slides for C++, you can create, reorder, rename, inspect, and remove sections through the [Presentation::get_Sections](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_sections/) method.

Sections are especially useful when:

- a large presentation needs to be divided into logical topics or chapters;
- different groups of slides are assigned to different collaborators;
- slides need to be processed, moved, or merged as groups.

Choose concise section names that describe the purpose of the grouped slides. Because sections are part of the presentation structure, use the section APIs to determine membership instead of deriving it from slide positions.

## **Create and Manage Sections**

Use [ISectionCollection::AddSection](https://reference.aspose.com/slides/cpp/aspose.slides/isectioncollection/addsection/) to create a section by specifying its name and starting slide. Aspose.Slides determines which slides belong to the section from the presentation's current section structure.

The same [ISectionCollection](https://reference.aspose.com/slides/cpp/aspose.slides/isectioncollection/) also lets you:

- move a section together with its slides by using [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/cpp/aspose.slides/isectioncollection/reordersectionwithslides/);
- remove only the section definition with [ISectionCollection::RemoveSection](https://reference.aspose.com/slides/cpp/aspose.slides/isectioncollection/removesection/), which retains its slides;
- remove a section and its slides with [ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/cpp/aspose.slides/isectioncollection/removesectionwithslides/);
- add an empty section at the end with [ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/cpp/aspose.slides/isectioncollection/appendemptysection/).

The following example creates two sections, moves one of them, removes it together with its slides, and appends an empty section:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto titleSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto resultsSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", titleSlide);
auto resultsSection = sections->AddSection(u"Results", resultsSlide);

sections->ReorderSectionWithSlides(resultsSection, 0);
sections->RemoveSectionWithSlides(resultsSection);
sections->AppendEmptySection(u"Appendix");
```

After these operations, the presentation contains the `Introduction` section with its slides and an empty `Appendix` section. The `Results` section and its slides have been removed.

## **Rename Sections**

To rename a section, call [ISection::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/isection/set_name/). The section's slides and position remain unchanged.

The following example creates a section and changes its name:

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto section = presentation->get_Sections()->AddSection(u"Overview", slide);
section->set_Name(u"Introduction");
```

## **Retrieve Slides from Sections**

The [Presentation::get_Sections](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_sections/) method returns an [ISectionCollection](https://reference.aspose.com/slides/cpp/aspose.slides/isectioncollection/) that you can enumerate. For each [ISection](https://reference.aspose.com/slides/cpp/aspose.slides/isection/), call [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/cpp/aspose.slides/isection/getslideslistofsection/) to obtain the slides that currently belong to it. The method returns an [ISectionSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/isectionslidecollection/), which provides a count, indexed access, and enumeration.

The following example creates two populated sections and one empty section, then prints each section's [name](https://reference.aspose.com/slides/cpp/aspose.slides/isection/get_name/), [identifier](https://reference.aspose.com/slides/cpp/aspose.slides/isection/get_sectionid/), [starting slide](https://reference.aspose.com/slides/cpp/aspose.slides/isection/get_startedfromslide/), slide count, and slide numbers. It uses indexed access to read the first slide and a range-based `for` loop to process every slide. For the empty section, the returned collection has a count of zero, indexed access is not used, and enumeration performs no iterations.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", firstSlide);
sections->AddSection(u"Details", thirdSlide);
sections->AppendEmptySection(u"Appendix");

for (const auto& section : sections)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    auto startingSlide = section->get_StartedFromSlide();

    System::Console::WriteLine(u"Section: {0}", section->get_Name());
    System::Console::WriteLine(u"ID: {0}", section->get_SectionId().ToString());
    if (startingSlide == nullptr)
    {
        System::Console::WriteLine(u"Starting slide: none");
    }
    else
    {
        System::Console::WriteLine(u"Starting slide: {0}", startingSlide->get_SlideNumber());
    }
    System::Console::WriteLine(u"Slide count: {0}", sectionSlides->get_Count());

    if (sectionSlides->get_Count() > 0)
    {
        System::Console::WriteLine(u"First slide via index: {0}", sectionSlides->idx_get(0)->get_SlideNumber());
    }

    System::Console::Write(u"Slide numbers:");
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
}
```

Section membership is determined by the presentation's section structure. Do not calculate a section's range manually from [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/cpp/aspose.slides/isection/get_startedfromslide/), slide indexes, and the next section's starting slide.

Structural edits can change both the slides returned for a section and their slide numbers. This includes reordering slides, cloning a slide into a section, moving a section together with its slides, removing slides, and removing sections. The next example calls [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/cpp/aspose.slides/isection/getslideslistofsection/) after every such change instead of retaining assumptions about the section's former boundaries.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
auto firstSection = sections->AddSection(u"First", firstSlide);
auto secondSection = sections->AddSection(u"Second", thirdSlide);

auto printSectionSlides = [](const System::String& label, const System::SharedPtr<ISection>& section)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    System::Console::Write(u"{0} ({1} slides):", label, sectionSlides->get_Count());
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
};

printSectionSlides(u"Initially", firstSection);

auto slidesBeforeClone = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->AddClone(slidesBeforeClone->idx_get(0), firstSection);
printSectionSlides(u"After cloning into the section", firstSection);

auto slidesBeforeReorder = firstSection->GetSlidesListOfSection();
auto firstSlideInSection = slidesBeforeReorder->idx_get(0);
auto lastSlideInSection = slidesBeforeReorder->idx_get(slidesBeforeReorder->get_Count() - 1);
auto firstSectionPosition = firstSlideInSection->get_SlideNumber() - 1;
presentation->get_Slides()->Reorder(firstSectionPosition, lastSlideInSection);
printSectionSlides(u"After reordering slides", firstSection);

sections->ReorderSectionWithSlides(firstSection, 1);
printSectionSlides(u"After moving the section", firstSection);

auto slidesBeforeRemoval = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->Remove(slidesBeforeRemoval->idx_get(0));
printSectionSlides(u"After removing a slide", firstSection);

sections->RemoveSectionWithSlides(secondSection);
for (const auto& section : sections)
{
    printSectionSlides(u"Remaining section", section);
}
```

Call [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/cpp/aspose.slides/isection/getslideslistofsection/) again whenever slides or sections are reordered, cloned, moved, or removed. This keeps subsequent processing aligned with the current presentation structure.

The PPT (PowerPoint 97–2003) format does not preserve section metadata. Use this workflow with a format that supports sections, such as PPTX; converting to PPT removes the section structure needed for later enumeration.

## **FAQ**

**Are sections preserved when saving to the PPT (PowerPoint 97–2003) format?**

No. The PPT format does not support section metadata, so section grouping is lost when saving to .ppt.

**Can an entire section be "hidden"?**

No. A section has no visibility state. To hide its contents, call [ISlide::set_Hidden](https://reference.aspose.com/slides/cpp/aspose.slides/islide/set_hidden/) for each slide in the section.

**How can I find the section that contains a slide?**

Enumerate [Presentation::get_Sections](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_sections/), call [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/cpp/aspose.slides/isection/getslideslistofsection/) for each section, and compare the returned slides with the target slide. For a non-empty section, [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/cpp/aspose.slides/isection/get_startedfromslide/) returns its first slide; for an empty section, it returns `nullptr`.
