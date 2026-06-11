---
title: Kształt grupowy
type: docs
weight: 170
url: /pl/php-java/examples/elements/group-shape/
keywords:
- grupa
- dodaj kształt grupowy
- uzyskaj dostęp do kształtu grupowego
- usuń kształt grupowy
- rozgrupuj kształty
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Pracuj z grupowymi kształtami w PHP przy użyciu Aspose.Slides: twórz i rozgrupowuj, zmieniaj kolejność kształtów potomnych, ustaw transformacje i granice w PowerPoint i OpenDocument."
---
Przykłady tworzenia grup kształtów, uzyskiwania do nich dostępu, rozgrupowywania i usuwania przy użyciu **Aspose.Slides for PHP via Java**.

## **Dodaj grupowy kształt**

Utwórz grupę zawierającą dwa podstawowe kształty.

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

## **Uzyskaj dostęp do grupowego kształtu**

Pobierz pierwszy grupowy kształt ze slajdu.

```php
function accessGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Uzyskaj dostęp do pierwszego grupowego kształtu na slajdzie.
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

## **Usuń grupowy kształt**

Usuń grupowy kształt ze slajdu.

```php
function removeGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        
        // Zakładając, że pierwszy kształt na slajdzie jest grupowym kształtem.
        $group = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($group);

        $presentation->save("group_shape_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Rozgrupuj kształty**

Przenieś kształty poza kontener grupy.

```php
function ungroupShapes() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zakładając, że pierwszy kształt na slajdzie jest grupowym kształtem.
        $group = $slide->getShapes()->get_Item(0);

        // Sklonuj każdy kształt z grupy i dodaj go do slajdu.
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