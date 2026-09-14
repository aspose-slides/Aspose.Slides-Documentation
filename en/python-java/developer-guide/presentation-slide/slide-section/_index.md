---
title: Manage Slide Sections in Presentations with Python via Java
linktitle: Slide Section
type: docs
weight: 90
url: /python-java/slide-section/
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
- Python
- Java
- Aspose.Slides
description: "Manage slide sections with Aspose.Slides for Python via Java: create, rename, reorder, retrieve, and process section slides in PPTX presentations."
---

## **Introduction**

Sections organize consecutive slides into named groups without changing the slide content. With Aspose.Slides for Python via Java, you can create, reorder, rename, inspect, and remove sections through the [Presentation.getSections](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSections) method.

Sections are especially useful when:

- a large presentation needs to be divided into logical topics or chapters;
- different groups of slides are assigned to different collaborators;
- slides need to be processed, moved, or merged as groups.

Choose concise section names that describe the purpose of the grouped slides. Because sections are part of the presentation structure, use the section APIs to determine membership instead of deriving it from slide positions.

## **Create and Manage Sections**

Use [SectionCollection.addSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectioncollection/#addSection) to create a section by specifying its name and starting slide. Aspose.Slides determines which slides belong to the section from the presentation's current section structure.

The same [SectionCollection](https://reference.aspose.com/slides/python-java/aspose.slides/sectioncollection/) also lets you:

- move a section together with its slides by using [reorderSectionWithSlides](https://reference.aspose.com/slides/python-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- remove only the section definition with [removeSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectioncollection/#removeSection), which retains its slides;
- remove a section and its slides with [removeSectionWithSlides](https://reference.aspose.com/slides/python-java/aspose.slides/sectioncollection/#removeSectionwithslides);
- add an empty section at the end with [appendEmptySection](https://reference.aspose.com/slides/python-java/aspose.slides/sectioncollection/#appendEmptySection).

The following example creates two sections, moves one of them, removes it together with its slides, and appends an empty section:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    title_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    results_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", title_slide)
    results_section = presentation.getSections().addSection("Results", results_slide)

    presentation.getSections().reorderSectionWithSlides(results_section, 0)
    presentation.getSections().removeSectionWithSlides(results_section)
    presentation.getSections().appendEmptySection("Appendix")
finally:
    presentation.dispose()
```

After these operations, the presentation contains the `Introduction` section with its slides and an empty `Appendix` section. The `Results` section and its slides have been removed.

## **Rename Sections**

To rename a section, call its [Section.setName](https://reference.aspose.com/slides/python-java/aspose.slides/section/#setName) method. The section's slides and position remain unchanged.

The following example creates a section and changes its name:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    section = presentation.getSections().addSection("Overview", slide)
    section.setName("Introduction")
finally:
    presentation.dispose()
```

## **Retrieve Slides from Sections**

The [Presentation.getSections](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSections) method returns a [SectionCollection](https://reference.aspose.com/slides/python-java/aspose.slides/sectioncollection/) that you can iterate over. For each [Section](https://reference.aspose.com/slides/python-java/aspose.slides/section/), call [Section.getSlidesListOfSection](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSlidesListOfSection) to obtain the slides that currently belong to it. The method returns a [SectionSlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/sectionslidecollection/), which provides a count, indexed access, and iteration.

The following example creates two populated sections and one empty section, then prints each section's [name](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSectionId), [starting slide](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getStartedFromSlide), slide count, and slide numbers. It uses [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/python-java/aspose.slides/sectionslidecollection/#get_Item) to read the first slide and a `for` statement to process every slide. For the empty section, the returned collection has a size of zero, the method is not called, and iteration performs no operations.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", first_slide)
    presentation.getSections().addSection("Details", third_slide)
    presentation.getSections().appendEmptySection("Appendix")

    for section in presentation.getSections():
        section_slides = section.getSlidesListOfSection()
        starting_slide = "none" if section.getStartedFromSlide() is None else str(section.getStartedFromSlide().getSlideNumber())

        print("Section: ", section.getName(), sep="")
        print("ID: ", section.getSectionId(), sep="")
        print("Starting slide: ", starting_slide, sep="")
        print("Slide count: ", section_slides.size(), sep="")

        if section_slides.size() > 0:
            print("First slide via get_Item: ", section_slides.get_Item(0).getSlideNumber(), sep="")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()
finally:
    presentation.dispose()
```

Section membership is determined by the presentation's section structure. Do not calculate a section's range manually from [Section.getStartedFromSlide](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getStartedFromSlide), slide indexes, and the next section's starting slide.

Structural edits can change both the slides returned for a section and their slide numbers. This includes reordering slides, cloning a slide into a section, moving a section together with its slides, removing slides, and removing sections. The next example calls [Section.getSlidesListOfSection](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSlidesListOfSection) after every such change instead of retaining assumptions about the section's former boundaries.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    first_section = presentation.getSections().addSection("First", first_slide)
    second_section = presentation.getSections().addSection("Second", third_slide)

    def print_section_slides(label, section):
        section_slides = section.getSlidesListOfSection()
        print(f"{label} ({section_slides.size()} slides):", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.getSlidesListOfSection()
    presentation.getSlides().addClone(slides_before_clone.get_Item(0), first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.getSlidesListOfSection()
    first_section_position = slides_before_reorder.get_Item(0).getSlideNumber() - 1
    presentation.getSlides().reorder(first_section_position, slides_before_reorder.get_Item(slides_before_reorder.size() - 1))
    print_section_slides("After reordering slides", first_section)

    presentation.getSections().reorderSectionWithSlides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.getSlidesListOfSection()
    presentation.getSlides().remove(slides_before_removal.get_Item(0))
    print_section_slides("After removing a slide", first_section)

    presentation.getSections().removeSectionWithSlides(second_section)
    for section in presentation.getSections():
        print_section_slides("Remaining section", section)
finally:
    presentation.dispose()
```

Call [Section.getSlidesListOfSection](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSlidesListOfSection) again whenever slides or sections are reordered, cloned, moved, or removed. This keeps subsequent processing aligned with the current presentation structure.

The PPT (PowerPoint 97–2003) format does not preserve section metadata. Use this workflow with a format that supports sections, such as PPTX; converting to PPT removes the section structure needed for later iteration.

## **FAQ**

**Are sections preserved when saving to the PPT (PowerPoint 97–2003) format?**

No. The PPT format does not support section metadata, so section grouping is lost when saving to .ppt.

**Can an entire section be "hidden"?**

No. A section has no visibility state. To hide its contents, call [Slide.setHidden](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#setHidden) for each slide in the section.

**How can I find the section that contains a slide?**

Iterate over the collection returned by [Presentation.getSections](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSections), call [Section.getSlidesListOfSection](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSlidesListOfSection) for each section, and compare the returned slides with the target slide. For a non-empty section, [Section.getStartedFromSlide](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getStartedFromSlide) returns its first slide; for an empty section, it returns `None`.
