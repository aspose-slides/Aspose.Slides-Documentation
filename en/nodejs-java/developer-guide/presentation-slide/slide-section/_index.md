---
title: Manage Slide Sections in Presentations with JavaScript
linktitle: Slide Section
type: docs
weight: 90
url: /nodejs-java/slide-section/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Manage slide sections with Aspose.Slides for Node.js via Java: create, rename, reorder, retrieve, and process section slides in PPTX presentations."
---

## **Introduction**

Sections organize consecutive slides into named groups without changing the slide content. With Aspose.Slides for Node.js via Java, you can create, reorder, rename, inspect, and remove sections through the [Presentation.getSections](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSections) method.

Sections are especially useful when:

- a large presentation needs to be divided into logical topics or chapters;
- different groups of slides are assigned to different collaborators;
- slides need to be processed, moved, or merged as groups.

Choose concise section names that describe the purpose of the grouped slides. Because sections are part of the presentation structure, use the section APIs to determine membership instead of deriving it from slide positions.

## **Create and Manage Sections**

Use [SectionCollection.addSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectioncollection/#addSection) to create a section by specifying its name and starting slide. Aspose.Slides determines which slides belong to the section from the presentation's current section structure.

The same [SectionCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectioncollection/) also lets you:

- move a section together with its slides by using [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- remove only the section definition with [SectionCollection.removeSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectioncollection/#removeSection), which retains its slides;
- remove a section and its slides with [SectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides);
- add an empty section at the end with [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection).

The following example creates two sections, moves one of them, removes it together with its slides, and appends an empty section:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const titleSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    const resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

After these operations, the presentation contains the `Introduction` section with its slides and an empty `Appendix` section. The `Results` section and its slides have been removed.

## **Rename Sections**

To rename a section, call its [Section.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/section/#setName) method. The section's slides and position remain unchanged.

The following example creates a section and changes its name:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Retrieve Slides from Sections**

The [Presentation.getSections](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSections) method returns a [SectionCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectioncollection/) that you can access by index. For each [Section](https://reference.aspose.com/slides/nodejs-java/aspose.slides/section/), call [Section.getSlidesListOfSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/section/#getSlidesListOfSection) to obtain the slides that currently belong to it. The method returns a [SectionSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectionslidecollection/), which provides a count and indexed access.

The following example creates two populated sections and one empty section, then prints each section's [name](https://reference.aspose.com/slides/nodejs-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/nodejs-java/aspose.slides/section/#getSectionId), [starting slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/section/#getStartedFromSlide), slide count, and slide numbers. It uses [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectionslidecollection/#get_Item) to read both the first slide and every slide in the collection. For the empty section, the returned collection has a size of zero, indexed access is skipped, and the loop performs no operations.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    const sections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < sections.size(); sectionIndex++) {
        const section = sections.get_Item(sectionIndex);
        const sectionSlides = section.getSlidesListOfSection();
        const startingSlideObject = section.getStartedFromSlide();
        const startingSlide = startingSlideObject === null ? "none" : startingSlideObject.getSlideNumber().toString();

        console.log("Section: " + section.getName());
        console.log("ID: " + section.getSectionId().toString());
        console.log("Starting slide: " + startingSlide);
        console.log("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            console.log("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        let slideNumbers = "Slide numbers:";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            slideNumbers += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(slideNumbers);
    }
} finally {
    presentation.dispose();
}
```

Section membership is determined by the presentation's section structure. Do not calculate a section's range manually from [Section.getStartedFromSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/section/#getStartedFromSlide), slide indexes, and the next section's starting slide.

Structural edits can change both the slides returned for a section and their slide numbers. This includes reordering slides, cloning a slide into a section, moving a section together with its slides, removing slides, and removing sections. The next example calls [Section.getSlidesListOfSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/section/#getSlidesListOfSection) after every such change instead of retaining assumptions about the section's former boundaries.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const firstSection = presentation.getSections().addSection("First", firstSlide);
    const secondSection = presentation.getSections().addSection("Second", thirdSlide);

    const printSectionSlides = (label, section) => {
        const sectionSlides = section.getSlidesListOfSection();
        let output = label + " (" + sectionSlides.size() + " slides):";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            output += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(output);
    };

    printSectionSlides("Initially", firstSection);

    const slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides("After cloning into the section", firstSection);

    const slidesBeforeReorder = firstSection.getSlidesListOfSection();
    const firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    const lastSlideInSection = slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1);
    presentation.getSlides().reorder(firstSectionPosition, lastSlideInSection);
    printSectionSlides("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides("After moving the section", firstSection);

    const slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    const remainingSections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < remainingSections.size(); sectionIndex++) {
        printSectionSlides("Remaining section", remainingSections.get_Item(sectionIndex));
    }
} finally {
    presentation.dispose();
}
```

Call [Section.getSlidesListOfSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/section/#getSlidesListOfSection) again whenever slides or sections are reordered, cloned, moved, or removed. This keeps subsequent processing aligned with the current presentation structure.

The PPT (PowerPoint 97–2003) format does not preserve section metadata. Use this workflow with a format that supports sections, such as PPTX; converting to PPT removes the section structure needed for later iteration.

## **FAQ**

**Are sections preserved when saving to the PPT (PowerPoint 97–2003) format?**

No. The PPT format does not support section metadata, so section grouping is lost when saving to .ppt.

**Can an entire section be "hidden"?**

No. A section has no visibility state. To hide its contents, call [Slide.setHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#setHidden) for each slide in the section.

**How can I find the section that contains a slide?**

Access each section in the collection returned by [Presentation.getSections](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSections), call [Section.getSlidesListOfSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/section/#getSlidesListOfSection) for each section, and compare the returned slides with the target slide. For a non-empty section, [Section.getStartedFromSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/section/#getStartedFromSlide) returns its first slide; for an empty section, it returns `null`.
