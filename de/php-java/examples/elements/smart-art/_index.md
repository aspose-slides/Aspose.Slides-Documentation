---
title: SmartArt
type: docs
weight: 140
url: /de/php-java/examples/elements/smartart/
keywords:
- SmartArt
- SmartArt hinzufügen
- Auf SmartArt zugreifen
- SmartArt entfernen
- SmartArt Layout
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen und bearbeiten Sie SmartArt in PHP mit Aspose.Slides: Knoten hinzufügen, Layouts und Stile ändern, präzise in Formen konvertieren und für PPT, PPTX und ODP exportieren."
---
Zeigt, wie Sie SmartArt‑Grafiken hinzufügen, darauf zugreifen, sie entfernen und Layouts ändern, indem Sie **Aspose.Slides für PHP über Java** verwenden.

## **SmartArt hinzufügen**

Fügen Sie eine SmartArt‑Grafik mithilfe eines der integrierten Layouts ein.

```php
function addSmartArt() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $smart = $slide->getShapes()->addSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

        $presentation->save("smart_art.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **SmartArt zugreifen**

Rufen Sie das erste SmartArt‑Objekt auf einer Folie ab.

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zugriff auf das erste SmartArt auf der Folie.
        $firstSmartArt = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
                $firstSmartArt = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **SmartArt entfernen**

Löschen Sie eine SmartArt‑Form aus der Folie.

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Annahme: Die erste Form auf der Folie ist ein SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **SmartArt‑Layout ändern**

Aktualisieren Sie den Layouttyp einer vorhandenen SmartArt‑Grafik.

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Annahme: Die erste Form auf der Folie ist ein SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        // Layout des SmartArt ändern.
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```