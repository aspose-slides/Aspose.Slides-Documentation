---
title: GroupShape
type: docs
weight: 170
url: /it/php-java/examples/elements/group-shape/
keywords:
- gruppo
- aggiungi forma di gruppo
- accedi alla forma di gruppo
- rimuovi forma di gruppo
- separa forme
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Lavora con le forme di gruppo in PHP usando Aspose.Slides: crea e separa, riordina le forme figlie, imposta trasformazioni e limiti in PowerPoint e OpenDocument."
---
Esempi di creazione di gruppi di forme, accesso a essi, separazione e rimozione usando **Aspose.Slides for PHP via Java**.

## **Aggiungi una Forma di Gruppo**

Crea un gruppo contenente due forme di base.

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

## **Accedi a una Forma di Gruppo**

Recupera la prima forma di gruppo da una diapositiva.

```php
function accessGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accedi alla prima forma di gruppo nella diapositiva.
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

## **Rimuovi una Forma di Gruppo**

Elimina una forma di gruppo dalla diapositiva.

```php
function removeGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        
        // Si assume che la prima forma nella diapositiva sia una forma di gruppo.
        $group = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($group);

        $presentation->save("group_shape_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Separare le Forme**

Sposta le forme fuori da un contenitore di gruppo.

```php
function ungroupShapes() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assumendo che la prima forma nella diapositiva sia una forma di gruppo.
        $group = $slide->getShapes()->get_Item(0);

        // Clona ogni forma dal gruppo e aggiungila alla diapositiva.
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