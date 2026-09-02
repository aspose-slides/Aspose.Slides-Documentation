---
title: Manage Drawing Guides in Presentations in PHP
linktitle: Drawing Guides
type: docs
weight: 85
url: /php-java/drawing-guides/
keywords:
- drawing guide
- horizontal guide
- vertical guide
- alignment guide
- slide view
- master slide
- layout slide
- notes master
- handout master
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Add, access, and clear horizontal and vertical drawing guides in PowerPoint presentations using Aspose.Slides for PHP via Java."
---

## **Overview**

Drawing guides are adjustable horizontal and vertical lines that help users align shapes consistently while editing a presentation in PowerPoint. They are especially useful when an application generates a presentation that will later be refined manually: the application can save the same alignment aids that authors should follow when adding or moving content.

Drawing guides are editing aids, not slide content. They do not appear in a slide show or rendered output. Aspose.Slides for PHP via Java exposes them through the [DrawingGuidesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/drawingguidescollection/) class. A guide is represented by [DrawingGuide](https://reference.aspose.com/slides/php-java/aspose.slides/drawingguide/) and has an orientation, a position, and a color.

The position is measured in points from the top-left corner of the relevant slide or master. A vertical guide uses a horizontal coordinate, typically between zero and the slide width. A horizontal guide uses a vertical coordinate, typically between zero and the slide height.

## **Add Guides to the Slide View**

Use [CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) to manage guides displayed while editing normal slides. Call [DrawingGuidesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/drawingguidescollection/#add) with an [Orientation](https://reference.aspose.com/slides/php-java/aspose.slides/orientation/) value and a position in points.

The following example adds one vertical guide to the right of the slide center and one horizontal guide below it:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();

    $guides->add(Orientation::Vertical, $slideWidth / 2 + 12.5);
    $guides->add(Orientation::Horizontal, $slideHeight / 2 + 12.5);

    $presentation->save("drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Access Drawing Guides**

The [DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/php-java/aspose.slides/drawingguidescollection/#getCount) and [DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/php-java/aspose.slides/drawingguidescollection/#get_Item) methods provide access to existing guides. The [DrawingGuide::getOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide::getPosition](https://reference.aspose.com/slides/php-java/aspose.slides/drawingguide/#getPosition), and [DrawingGuide::getColor](https://reference.aspose.com/slides/php-java/aspose.slides/drawingguide/#getColor) methods return values that can also be changed through the corresponding setter methods.

The following example reads the slide-view guides from the presentation created above:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("drawing-guides.pptx");
try {
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();
    $guideCount = java_values($guides->getCount());

    for ($index = 0; $index < $guideCount; $index++) {
        $guide = $guides->get_Item($index);
        $orientation = java_values($guide->getOrientation());
        $position = java_values($guide->getPosition());
        $color = java_values($guide->getColor()->toString());
        echo sprintf("Guide %d: orientation = %d, position = %.2f, color = %s", $index, $orientation, $position, $color) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Add Guides to Master and Layout Slides**

A slide master and each of its layout slides can have their own drawing-guide collections. Use [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/#getDrawingGuides) for a master slide and [LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/#getDrawingGuides) for a layout slide.

The following example adds a vertical guide to the first master slide and a horizontal guide to the first layout slide:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $masterGuides = $presentation->getMasters()->get_Item(0)->getDrawingGuides();
    $layoutGuides = $presentation->getLayoutSlides()->get_Item(0)->getDrawingGuides();

    $masterGuides->add(Orientation::Vertical, $slideWidth / 2 - 20);
    $layoutGuides->add(Orientation::Horizontal, $slideHeight / 2 + 20);

    $presentation->save("master-layout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Add Guides to Notes and Handout Masters**

Notes masters and handout masters also support drawing guides. Use [MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/php-java/aspose.slides/masternotesslide/#getDrawingGuides) and [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides) to access their collections. If a presentation does not contain one of these masters, retrieve the appropriate manager with [Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) or [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager), then create the default master with `setDefaultMasterNotesSlide` or `setDefaultMasterHandoutSlide`.

The following example adds a horizontal guide to a notes master and a vertical guide to a handout master:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $notesSize = $presentation->getNotesSize()->getSize();
    $notesWidth = java_values($notesSize->getWidth());
    $notesHeight = java_values($notesSize->getHeight());
    $notesMaster = $presentation->getMasterNotesSlideManager()->setDefaultMasterNotesSlide();
    $handoutMaster = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();

    $notesMaster->getDrawingGuides()->add(Orientation::Horizontal, $notesHeight / 2 + 50);
    $handoutMaster->getDrawingGuides()->add(Orientation::Vertical, $notesWidth / 2 - 50);

    $presentation->save("notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Clear Drawing Guides**

Call [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/drawingguidescollection/#clear) to remove every guide from a particular collection. Clearing one collection does not affect guides stored in another scope.

The following example clears the slide-view guides and all guides on slide masters, layout slides, the notes master, and the handout master without creating missing masters:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation-with-guides.pptx");
try {
    $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides()->clear();

    $masterCount = java_values($presentation->getMasters()->size());
    for ($index = 0; $index < $masterCount; $index++) {
        $presentation->getMasters()->get_Item($index)->getDrawingGuides()->clear();
    }

    $layoutCount = java_values($presentation->getLayoutSlides()->size());
    for ($index = 0; $index < $layoutCount; $index++) {
        $presentation->getLayoutSlides()->get_Item($index)->getDrawingGuides()->clear();
    }

    $notesMaster = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
        $notesMaster->getDrawingGuides()->clear();
    }

    $handoutMaster = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();
    if (!java_is_null($handoutMaster)) {
        $handoutMaster->getDrawingGuides()->clear();
    }

    $presentation->save("presentation-without-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Do drawing guides appear in a slide show or exported images?**

No. Drawing guides are alignment aids for editing and are not rendered as presentation content.

**Can a drawing guide be added directly to an individual normal slide?**

Normal-slide editing guides are stored in the presentation's slide-view properties. Separate guide collections are available for slide masters, layout slides, notes masters, and handout masters.

**Which units are used for guide positions?**

Positions are specified in points, where 72 points equal one inch. Vertical positions are measured from the left edge, and horizontal positions are measured from the top edge.

**Does clearing drawing guides remove shapes or change slide content?**

No. The [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/drawingguidescollection/#clear) method removes only the guides in the selected collection. Shapes and other slide content remain unchanged.
