---
title: Slide
type: docs
weight: 10
url: /php-java/examples/elements/slide/
keywords:
- slide
- add slide
- access slide
- slide index
- clone slide
- reorder slides
- remove slide
- code examples
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Manage slides in PHP with Aspose.Slides: create, clone, reorder, hide, set backgrounds and size, apply transitions, and export for PowerPoint and OpenDocument."
---

This article provides a series of examples that demonstrate how to work with slides using **Aspose.Slides for PHP via Java**. You’ll learn how to add, access, clone, reorder, and remove slides using the `Presentation` class.

Each example below includes a brief explanation followed by a code snippet in PHP.

## **Add a Slide**

To add a new slide, you must first select a layout. In this example, we use the `Blank` layout and add an empty slide to the presentation.

```php
function addSlide() {
    $presentation = new Presentation();
    try {
        // Each slide is based on a layout, which itself is based on a master slide.
        // Use the Blank layout to create a new slide.
        $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Add a new empty slide using the selected layout.
        $presentation->getSlides()->addEmptySlide($blankLayout);

        $presentation->save("slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip:** Each slide layout is derived from a master slide, which defines the overall design and placeholder structure. The image below illustrates how master slides and their associated layouts are organized in PowerPoint.

![Master and Layout Relationship](master-layout-slide.png)

## **Access Slides by Index**

You can access slides using their index.

```php
function accessSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Access a slide by index.
        $firstSlide = $presentation->getSlides()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Clone a Slide**

This example demonstrates how to clone an existing slide. The cloned slide is automatically added to the end of the slide collection.

```php
function cloneSlide() {
    // By default, the presentation contains one empty slide.
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Clone the first slide; it will be added at the end of the presentation.
        $clonedSlide = $presentation->getSlides()->addClone($slide);

        // The cloned slide index is 1 (second slide in the presentation).
        $clonedSlideIndex = $presentation->getSlides()->indexOf($clonedSlide);

        $presentation->save("slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Reorder Slides**

You can change the order of slides by moving one to a new index. In this case, we move a slide to the first position.

```php
function reorderSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(1);

        // Move the slide to the first position (others shift down).
        $presentation->getSlides()->reorder(0, $slide);

        $presentation->save("slide_reordered.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove a Slide**

To remove a slide, simply reference it and call `remove`. This example removes slides by index and by reference.

```php
function removeSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Remove a slide by index.
        $presentation->getSlides()->removeAt(0);

        // Remove a slide by reference.
        $slide = $presentation->getSlides()->get_Item(0);
        $presentation->getSlides()->remove($slide);

        $presentation->save("slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```
