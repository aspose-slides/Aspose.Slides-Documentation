---
title: Slide Transition
type: docs
weight: 110
url: /java/examples/elements/slidetransition/
keywords:
- code example
- slide transition
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Master slide transitions in Aspose.Slides for Java: add, customize, and sequence effects and durations with Java examples for PPT, PPTX, and ODP presentations."
---

This article demonstrates applying slide transition effects and timings with **Aspose.Slides for Java**.

## **Add a Slide Transition**

Apply a fade transition effect to the first slide.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Apply a fade transition.
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **Access a Slide Transition**

Read the transition type currently assigned to a slide.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // Access the transition type.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Slide Transition**

Clear any transition effect by setting the type to `None`.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // Remove transition by setting none.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **Set Transition Duration**

Specify how long the slide is displayed before advancing automatically.

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // in milliseconds.
    } finally {
        presentation.dispose();
    }
}
```
