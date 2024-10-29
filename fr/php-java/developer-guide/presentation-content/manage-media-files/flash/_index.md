---
title: Flash
type: docs
weight: 10
url: /fr/php-java/flash/
description: Extraire des objets Flash d'une présentation PowerPoint en utilisant PHP
---

## **Extraire des objets Flash de la présentation**

Aspose.Slides pour PHP via Java fournit une fonctionnalité pour extraire des objets flash d'une présentation. Vous pouvez accéder au contrôle flash par son nom et l'extraire de la présentation, y compris les données d'objet SWF.

```php
  # Instancier la classe Presentation qui représente le PPTX
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