---
title: Tinte
type: docs
weight: 180
url: /de/php-java/examples/elements/ink/
keywords:
- Tinte
- Zugriff auf Tinte
- Tinte entfernen
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie digitale Tinte auf Folien in PHP mit Aspose.Slides: Pen-Striche hinzufügen, Pfade bearbeiten, Farbe und Breite festlegen und Ergebnisse für PowerPoint und OpenDocument exportieren."
---
Bietet Beispiele zum Zugriff auf vorhandene Ink‑Formen und deren Entfernung mit **Aspose.Slides for PHP via Java**.

> ❗ **Hinweis:** Ink‑Formen stellen die Benutzereingabe von spezialisierten Geräten dar. Aspose.Slides kann keine neuen Ink‑Striche programmgesteuert erstellen, aber Sie können vorhandene Ink lesen und ändern.

## **Ink‑Zugriff**

Holen Sie die erste Ink‑Form auf einer Folie.

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zugriff auf die erste Ink-Form auf der Folie.
        $firstInk = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Ink"))) {
                $firstInk = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Ink entfernen**

Löschen Sie eine Ink‑Form von der Folie.

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Angenommen, die erste Form auf der Folie ist eine Ink-Form.
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```