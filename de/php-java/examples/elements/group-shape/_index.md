---
title: Gruppenform
type: docs
weight: 170
url: /de/php-java/examples/elements/group-shape/
keywords:
- Gruppe
- Gruppenform hinzufügen
- Zugriff auf Gruppenform
- Gruppenform entfernen
- Formen entgruppieren
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Arbeiten Sie mit Gruppenformen in PHP mithilfe von Aspose.Slides: Erstellen und Auflösen, Neuordnen von untergeordneten Formen, Festlegen von Transformationen und Begrenzungen für PowerPoint und OpenDocument."
---
Beispiele für das Erstellen von Gruppen von Formen, den Zugriff darauf, das Aufheben von Gruppen und das Entfernen mit **Aspose.Slides for PHP via Java**.

## **Gruppe hinzufügen**

Erstelle eine Gruppe, die zwei einfache Formen enthält.

```php
function addGroupShape() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $group = $slide->getShapes()->addGroupShape();
        $group->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
        $group->getShapes()->addAutoShape(ShapeType::Ellipse, 60, 0, 50, 50);

        $presentation->save("group_shape.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Zugriff auf eine Gruppenform**

Rufe die erste Gruppenform einer Folie ab.

```php
function accessGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zugriff auf die erste Gruppenform auf der Folie.
        $firstGroup = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $firstGroup = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Gruppenform entfernen**

Lösche eine Gruppenform von der Folie.

```php
function removeGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        
        // Angenommen, die erste Form auf der Folie ist eine Gruppenform.
        $group = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($group);

        $presentation->save("group_shape_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Gruppen auflösen**

Verschiebe Formen aus einem Gruppencontainer.

```php
function ungroupShapes() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Angenommen, die erste Form auf der Folie ist eine Gruppenform.
        $group = $slide->getShapes()->get_Item(0);

        // Klone jede Form aus der Gruppe und füge sie der Folie hinzu.
        $shapeCount = java_values($group->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $group->getShapes()->get_Item($index);
            $slide->getShapes()->addClone($shape);
        }

        $slide->getShapes()->remove($group);

        $presentation->save("ungrouped_shapes.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```