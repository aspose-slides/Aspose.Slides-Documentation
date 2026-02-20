---
title: SlideTransition
type: docs
weight: 110
url: /php-java/examples/elements/slide-transition/
keywords:
- slide transition
- add slide transition
- access slide transition
- remove slide transition
- transition duration
- code examples
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Control slide transitions in PHP with Aspose.Slides: choose types, speed, sound, and timing to polish presentations in PPT, PPTX and ODP."
---

Demonstrates applying slide transition effects and timings with **Aspose.Slides for PHP via Java**.

## **Add a Slide Transition**

Apply a fade transition effect to the first slide.

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Apply a fade transition.
        $slide->getSlideShowTransition()->setType(TransitionType::Fade);

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Access a Slide Transition**

Read the transition type assigned to a slide.

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Access the transition type.
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove a Slide Transition**

Clear any transition effect by setting the type to `None`.

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Remove transition by setting none.
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Set Transition Duration**

Specify how long the slide is displayed before advancing automatically.

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // in milliseconds.

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```
