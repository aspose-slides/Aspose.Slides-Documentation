---
title: Manage Text Portions in Presentations Using PHP
linktitle: Text Portion
type: docs
weight: 70
url: /php-java/portion/
keywords:
- text portion
- text part
- text coordinates
- text position
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Learn how to manage text portions in PowerPoint presentations using Aspose.Slides for PHP via Java, boosting performance and customization."
---

## **Get Coordinates of a Text Portion**
[**getCoordinates()**](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--) method has been added to [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPortion) and [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) class which allows retrieving the coordinates of the beginning of the portion.

```php
  # Instantiate Prseetation class that represents the PPTX
  $pres = new Presentation();
  try {
    # Reshaping the context of presentation
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    foreach($textFrame->getParagraphs() as $paragraph) {
      foreach($paragraph->getPortions() as $portion) {
        $point = $portion->getCoordinates();
        echo("X: " . $point->$x . " Y: " . $point->$y);
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Can I apply a hyperlink to only part of the text within a single paragraph?**

Yes, you can [assign a hyperlink](/slides/php-java/manage-hyperlinks/) to an individual portion; only that fragment will be clickable, not the entire paragraph.

**How does style inheritance work: what does a Portion override, and what is taken from Paragraph/TextFrame?**

Portion-level properties have the highest precedence. If a property is not set on the [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/), the engine takes it from the [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/); if it is not set there either, from the [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) or the [theme](https://reference.aspose.com/slides/php-java/aspose.slides/theme/) style.

**What happens if the font specified for a Portion is missing on the target machine/server?**

[Font substitution rules](/slides/php-java/font-selection-sequence/) apply. The text may reflow: metrics, hyphenation, and width can change, which matters for precise positioning.

**Can I set a Portion-specific text fill transparency or gradient independent of the rest of the paragraph?**

Yes, text color, fill, and transparency at the [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) level can differ from neighboring fragments.
