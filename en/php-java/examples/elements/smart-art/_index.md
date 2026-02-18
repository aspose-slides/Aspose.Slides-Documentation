---
title: SmartArt
type: docs
weight: 140
url: /php-java/examples/elements/smartart/
keywords:
- SmartArt
- add SmartArt
- access SmartArt
- remove SmartArt
- SmartArt layout
- code examples
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Build and edit SmartArt in PHP with Aspose.Slides: add nodes, change layouts and styles, convert to shapes with precision, and export for PPT, PPTX and ODP."
---

Shows how to add SmartArt graphics, access them, remove them, and change layouts using **Aspose.Slides for PHP via Java**.

## **Add SmartArt**

Insert a SmartArt graphic using one of the built-in layouts.

```php
function addSmartArt() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $smart = $slide->getShapes()->addSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

        $presentation->save("smart_art.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Access SmartArt**

Retrieve the first SmartArt object on a slide.

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Access the first SmartArt on the slide.
        $firstSmartArt = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
                $firstSmartArt = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove SmartArt**

Delete a SmartArt shape from the slide.

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assuming the first shape on the slide is a SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Change SmartArt Layout**

Update the layout type of an existing SmartArt graphic.

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assuming the first shape on the slide is a SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        // Change the layout of the SmartArt.
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```
