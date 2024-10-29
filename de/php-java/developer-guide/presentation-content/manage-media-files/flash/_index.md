---
title: Flash
type: docs
weight: 10
url: /de/php-java/flash/
description: Extrahieren Sie Flash-Objekte aus PowerPoint-Präsentationen mit PHP
---

## **Flash-Objekte aus der Präsentation extrahieren**

Aspose.Slides für PHP über Java bietet die Möglichkeit, Flash-Objekte aus einer Präsentation zu extrahieren. Sie können das Flash-Steuerelement nach Namen abrufen und es aus der Präsentation extrahieren sowie SWF-Objektdaten speichern.

```php
  # Instanziieren Sie die Präsentationsklasse, die das PPTX repräsentiert
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