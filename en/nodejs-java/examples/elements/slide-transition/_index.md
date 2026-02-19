---
title: Slide Transition
type: docs
weight: 110
url: /nodejs-java/examples/elements/slide-transition/
keywords:
- code example
- slide transition
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Master slide transitions in Aspose.Slides for Node.js: add, customize, and sequence effects and durations with examples for PPT, PPTX, and ODP presentations."
---

This article demonstrates applying slide transition effects and timings with **Aspose.Slides for Node.js via Java**.

## **Add a Slide Transition**

Apply a fade transition effect to the first slide.

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Apply a fade transition.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Access a Slide Transition**

Read the transition type currently assigned to a slide.

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Access the transition type.
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Slide Transition**

Clear any transition effect by setting the type to `None`.

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Remove transition by setting none.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Set Transition Duration**

Specify how long the slide is displayed before advancing automatically.

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // in milliseconds.

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```
