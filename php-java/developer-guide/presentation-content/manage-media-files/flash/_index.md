---
title: Flash
type: docs
weight: 10
url: /php-java/flash/
description: Extract Flash Objects from PowerPoint Presentation using Java
---

## **Extract Flash Objects from Presentation**

Aspose.Slides for PHP via Java provides a facility for extracting flash objects from a presentation. You can access the flash control by name and extract it from the presentation and including store SWF object data.

```php
  // Instantiate Presentation class that represents the PPTX
  $pres = new Presentation();
  try {
    $controls = $pres->getSlides()->get_Item(0)->getControls();
    $flashControl = null;
    foreach($controls as $control) {
      if ($control->getName() == "ShockwaveFlash1") {
        $flashControl = $control;
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }

```
