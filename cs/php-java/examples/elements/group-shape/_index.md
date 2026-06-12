---
title: Skupinový tvar
type: docs
weight: 170
url: /cs/php-java/examples/elements/group-shape/
keywords:
- skupina
- přidat skupinový tvar
- přístup ke skupinovému tvaru
- odstranit skupinový tvar
- rozčlenit tvary
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Pracujte se skupinovými tvary v PHP pomocí Aspose.Slides: vytvářejte a rozdělujte, přeskupujte podřízené tvary, nastavujte transformace a ohraničení napříč PowerPoint a OpenDocument."
---
Příklady vytváření skupin tvarů, přístupu k nim, rozdělení a odstraňování pomocí **Aspose.Slides for PHP via Java**.

## **Přidání skupinového tvaru**

Vytvořte skupinu obsahující dva základní tvary.

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

## **Přístup ke skupinovému tvaru**

Získejte první skupinový tvar ze snímku.

```php
function accessGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Přístup k prvnímu skupinovému tvaru na snímku.
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

## **Odstranění skupinového tvaru**

Smažte skupinový tvar ze snímku.

```php
function removeGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        
        // Předpokládáme, že první tvar na snímku je skupinový tvar.
        $group = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($group);

        $presentation->save("group_shape_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Rozdělení tvarů**

Přesuňte tvary mimo kontejner skupiny.

```php
function ungroupShapes() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Předpokládáme, že první tvar na snímku je skupinový tvar.
        $group = $slide->getShapes()->get_Item(0);

        // Klonujte každý tvar ze skupiny a přidejte jej do snímku.
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