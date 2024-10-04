---
title: Flash
type: docs
weight: 10
url: /es/php-java/flash/
description: Extraer objetos Flash de presentaciones de PowerPoint usando PHP
---

## **Extraer objetos Flash de la presentación**

Aspose.Slides para PHP a través de Java proporciona una función para extraer objetos Flash de una presentación. Puedes acceder al control Flash por nombre y extraerlo de la presentación incluyendo almacenar datos del objeto SWF.

```php
  # Instanciar la clase Presentation que representa el PPTX
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