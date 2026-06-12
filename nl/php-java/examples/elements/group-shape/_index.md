---
title: Groepvorm
type: docs
weight: 170
url: /nl/php-java/examples/elements/group-shape/
keywords:
- groep
- groepvorm toevoegen
- groepvorm benaderen
- groepvorm verwijderen
- vormen ontgroeperen
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Werken met groepvormen in PHP met Aspose.Slides: maak en ontgroepeer, herschik kindvormen, stel transformaties en grenzen in voor zowel PowerPoint als OpenDocument."
---
Voorbeelden voor het maken van groepen van vormen, er toegang toe krijgen, ontgroeperen en verwijderen met **Aspose.Slides for PHP via Java**.

## **Groepvorm toevoegen**

Maak een groep aan die twee basisvormen bevat.

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

## **Toegang tot een groepvorm**

Haal de eerste groepvorm van een dia op.

```php
function accessGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Toegang tot de eerste groepvorm op de dia.
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

## **Verwijder een groepvorm**

Verwijder een groepvorm van de dia.

```php
function removeGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        
        // Aangenomen dat de eerste vorm op de dia een groepvorm is.
        $group = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($group);

        $presentation->save("group_shape_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Vormen uitgroeperen**

Verplaats vormen uit een groepscontainer.

```php
function ungroupShapes() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aangenomen dat de eerste vorm op de dia een groepvorm is.
        $group = $slide->getShapes()->get_Item(0);

        // Kloon elke vorm uit de groep en voeg deze toe aan de dia.
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