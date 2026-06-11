---
title: Gruppform
type: docs
weight: 170
url: /sv/php-java/examples/elements/group-shape/
keywords:
- grupp
- lägga till gruppform
- komma åt gruppform
- ta bort gruppform
- avgruppera former
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Arbeta med gruppformer i PHP med Aspose.Slides: skapa och avgruppera, ändra ordning på underordnade former, sätt transformationer och gränser i PowerPoint och OpenDocument."
---
Exempel på att skapa grupper av former, komma åt dem, avgruppera och ta bort dem med **Aspose.Slides for PHP via Java**.

## **Lägg till en gruppform**

Skapa en grupp som innehåller två grundläggande former.

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

## **Kom åt en gruppform**

Hämta den första gruppformen från en bild.

```php
function accessGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Åtkomst till den första gruppformen på bilden.
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

## **Ta bort en gruppform**

Ta bort en gruppform från bilden.

```php
function removeGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        
        // Antar att den första formen på bilden är en gruppform.
        $group = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($group);

        $presentation->save("group_shape_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Avgruppera former**

Flytta former ur en gruppbehållare.

```php
function ungroupShapes() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Antar att den första formen på bilden är en gruppform.
        $group = $slide->getShapes()->get_Item(0);

        // Klona varje form från gruppen och lägg till den på bilden.
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