---
title: Extract Flash Objects from Presentations in PHP
linktitle: Flash
type: docs
weight: 10
url: /php-java/flash/
keywords:
- extract flash
- flash object
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Learn how to extract Flash objects from PowerPoint and OpenDocument slides with Aspose.Slides for PHP via Java, complete code samples and best practices."
---

## **Extract Flash Objects from Presentation**

Aspose.Slides for PHP via Java provides a facility for extracting flash objects from a presentation. You can access the flash control by name and extract it from the presentation and including store SWF object data.

```php
  # Instantiate Presentation class that represents the PPTX
  $pres = new Presentation();
  try {
    $controls = $pres->getSlides()->get_Item(0)->getControls();
    $flashControl = null;
    foreach($controls as $control) {
      if (java_values($control->getName()) == "ShockwaveFlash1") {
        $flashControl = $control;
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
