---
title: Erstellen einer PowerPoint-Präsentation mit PHP
linktitle: Präsentation erstellen
type: docs
weight: 10
url: /php-java/create-presentation/
keywords: ppt java erstellen, ppt präsentation erstellen, pptx java erstellen
description: Erfahren Sie, wie Sie PowerPoint-Präsentationen wie PPT, PPTX mit PHP von Grund auf erstellen.
---

## **Erstellen einer PowerPoint-Präsentation**
Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der Präsentationsklasse.
1. Erhalten Sie die Referenz einer Folie, indem Sie deren Index verwenden.
1. Fügen Sie eine AutoShape vom Typ Linie mit der Methode addAutoShape hinzu, die vom Shapes-Objekt bereitgestellt wird.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.

```php
  # Instanziieren Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation();
  try {
    # Holen Sie sich die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Fügen Sie eine AutoShape vom Typ Linie hinzu
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```