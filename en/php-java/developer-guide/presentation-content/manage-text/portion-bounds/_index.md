---
title: Get Text Portion Bounds from Presentations in PHP
linktitle: Portion Bounds
type: docs
weight: 47
url: /php-java/portion-bounds/
keywords:
- text portion bounds
- text portion
- text part
- text coordinates
- text position
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Learn how to retrieve text portion bounds in PowerPoint presentations using Aspose.Slides for PHP via Java."
---

## **Overview**

A text portion represents a specific fragment of text inside a paragraph and allows you to work with that fragment independently from surrounding content. In Aspose.Slides, portions can be used when you need to retrieve the bounds of a text fragment, apply formatting to only part of a paragraph, or control text behavior at a more detailed level.

This article shows how to get the bounding rectangle of a portion by using [Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/getrect/). It also shows how to get the coordinates of the beginning of a portion by using [Portion::getCoordinates](https://reference.aspose.com/slides/php-java/aspose.slides/portion/getcoordinates/). In addition, it highlights common portion-related scenarios, such as applying a hyperlink to a single text fragment, understanding how formatting is resolved through portion, paragraph, text frame, and theme inheritance, and handling cases where a specified font is unavailable.

## **Get Bounds of a Text Portion**

Use [Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/getrect/) to retrieve the bounding rectangle of a text portion:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $rectangle = $portion->getRect();
            $rectangleX = java_values($rectangle->getX());
            $rectangleY = java_values($rectangle->getY());
            $rectangleWidth = java_values($rectangle->getWidth());
            $rectangleHeight = java_values($rectangle->getHeight());

            echo("X = " . $rectangleX . "; Y = " . $rectangleY . "; Width = " . $rectangleWidth . "; Height = " . $rectangleHeight);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Get Coordinates of a Text Portion**

Use [Portion::getCoordinates](https://reference.aspose.com/slides/php-java/aspose.slides/portion/getcoordinates/) to retrieve the coordinates of the beginning of a text portion:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $point = $portion->getCoordinates();
            $pointX = java_values($point->getX());
            $pointY = java_values($point->getY());

            echo("X = " . $pointX . "; Y = " . $pointY);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Can I apply a hyperlink to only part of the text within a single paragraph?**

Yes, you can [assign a hyperlink](/slides/php-java/manage-hyperlinks/) to an individual portion; only that fragment will be clickable, not the entire paragraph.

**How does style inheritance work: what does a portion override, and what is taken from a paragraph or text frame?**

Portion-level properties have the highest precedence. If a property is not set on the [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/), Aspose.Slides takes it from the [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/). If it is not set there either, Aspose.Slides uses the [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) or [theme](https://reference.aspose.com/slides/php-java/aspose.slides/theme/) style.

**What happens if the font specified for a portion is missing on the target machine or server?**

[Font substitution rules](/slides/php-java/font-selection-sequence/) apply. The text may reflow: metrics, hyphenation, and width can change, which matters for precise positioning.

**Can I set portion-specific text fill transparency or a gradient independently of the rest of the paragraph?**

Yes, text color, fill, and transparency at the [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) level can differ from neighboring fragments.
