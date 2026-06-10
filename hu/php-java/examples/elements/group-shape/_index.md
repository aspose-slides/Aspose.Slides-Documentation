---
title: Csoport alakzat
type: docs
weight: 170
url: /hu/php-java/examples/elements/group-shape/
keywords:
- csoport
- csoport alakzat hozzáadása
- csoport alakzat elérése
- csoport alakzat eltávolítása
- csoport szétbontása
- kódpéldák
- PowerPoint
- OpenDocument
- bemutató
- PHP
- Aspose.Slides
description: "Csoport alakzatok kezelése PHP-ben az Aspose.Slides használatával: létrehozás és szétbontás, gyermek alakzatok átrendezése, transzformációk és határok beállítása PowerPoint és OpenDocument formátumokban."
---
Példák alakzatcsoportok létrehozására, elérésére, csoport szétbontására és eltávolítására a **Aspose.Slides for PHP via Java** használatával.

## **Csoport alakzat hozzáadása**

Hozzon létre egy csoportot, amely két egyszerű alakzatot tartalmaz.

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

## **Csoport alakzat elérése**

Az első csoport alakzat lekérdezése egy diából.

```php
function accessGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // A dián lévő első csoport alakzat elérése.
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

## **Csoport alakzat eltávolítása**

Törölje a csoport alakzatot a diáról.

```php
function removeGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        
        // Feltételezve, hogy a dián az első alakzat egy csoport alakzat.
        $group = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($group);

        $presentation->save("group_shape_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Alakzatok csoport szétbontása**

Az alakzatok áthelyezése a csoport tárolóból.

```php
function ungroupShapes() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Feltételezve, hogy a dián az első alakzat egy csoport alakzat.
        $group = $slide->getShapes()->get_Item(0);

        // Klónozza a csoport minden alakzatát, és hozzáadja a diához.
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