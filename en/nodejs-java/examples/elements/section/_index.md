---
title: Section
type: docs
weight: 90
url: /nodejs-java/examples/elements/section/
keywords:
- code example
- section
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Manage slide sections in Aspose.Slides for Node.js via Java: create, rename, reorder, and group slides with JavaScript examples for PPT, PPTX, and ODP."
---

Examples for managing presentation sections—add, access, remove, and rename them programmatically using **Aspose.Slides for Node.js via Java**.

## **Add a Section**

Create a section that starts at a specific slide.

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Specify the slide that marks the beginning of the section.
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Access a Section**

Read section information from a presentation.

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Access a section by index.
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Section**

Delete a previously added section.

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Remove the first section.
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Rename a Section**

Change the name of an existing section.

```js
function renameSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let section = presentation.getSections().get_Item(0);
        section.setName("New Name");

        presentation.save("section_renamed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```
