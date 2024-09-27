---
title: Flash
type: docs
weight: 10
url: /ru/php-java/flash/
description: Извлечение объектов Flash из презентации PowerPoint с помощью PHP
---

## **Извлечение объектов Flash из презентации**

Aspose.Slides для PHP через Java предоставляет возможность извлекать объекты Flash из презентации. Вы можете получить доступ к Flash-контролю по имени и извлечь его из презентации, включая хранение данных SWF-объектов.

```php
  # Создайте экземпляр класса Presentation, который представляет PPTX
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