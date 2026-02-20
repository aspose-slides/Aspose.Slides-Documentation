---
title: Ink
type: docs
weight: 180
url: /php-java/examples/elements/ink/
keywords:
- ink
- access ink
- remove ink
- code examples
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Handle digital ink on slides in PHP with Aspose.Slides: add pen strokes, edit paths, set color and width, and export results for PowerPoint and OpenDocument."
---

Provides examples of accessing existing ink shapes and removing them using **Aspose.Slides for PHP via Java**.

> ❗ **Note:** Ink shapes represent user input from specialized devices. Aspose.Slides cannot create new ink strokes programmatically, but you can read and modify existing ink.

## **Access Ink**

Get the first ink shape on a slide.

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Access the first ink shape on the slide.
        $firstInk = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Ink"))) {
                $firstInk = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove Ink**

Delete an ink shape from the slide.

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assuming the first shape on the slide is an ink shape.
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```
