---
title: Slide
type: docs
weight: 10
url: /nodejs-java/examples/elements/slide/
keywords:
- code example
- slide
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Control slides in Aspose.Slides for Node.js: create, clone, reorder, resize, set backgrounds, and apply transitions for PPT, PPTX, and ODP presentations."
---

This article provides a series of examples that demonstrate how to work with slides using **Aspose.Slides for Node.js via Java**. You’ll learn how to add, access, clone, reorder, and remove slides using the `Presentation` class.

Each example below includes a brief explanation followed by a code snippet in JavaScript.

## **Add a Slide**

To add a new slide, you must first select a layout. In this example, we use the `Blank` layout and add an empty slide to the presentation.

```js
function addSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getSlides().addEmptySlide(layoutSlide);

        presentation.save("slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note:** Each slide layout is derived from a master slide, which defines the overall design and placeholder structure. The image below illustrates how master slides and their associated layouts are organized in PowerPoint.

![Master and Layout Relationship](master-layout-slide.png)

## **Access Slides by Index**

You can access slides using their index. This is useful for iterating through or modifying specific slides.

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Access a slide by index.
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Clone a Slide**

This example demonstrates how to clone an existing slide. The cloned slide is automatically added to the end of the slide collection.

```js
function cloneSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        let clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.save("slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Reorder Slides**

You can change the order of slides by moving one to a new index. In this case, we move a slide to the first position.

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Reorder slides by moving the second slide to the first position.
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Slide**

To remove a slide, simply reference it and call `remove`. This example adds a second slide and then removes the original, leaving only the new one.

```js
function removeSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);

        presentation.save("slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```
