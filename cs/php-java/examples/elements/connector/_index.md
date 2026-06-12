---
title: Spojnice
type: docs
weight: 190
url: /cs/php-java/examples/elements/connector/
keywords:
- spojnice
- přidat spojnici
- přístup ke spojnici
- odstranit spojnici
- znovu připojit tvary
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Vykreslete a ovládejte spojnice v PHP pomocí Aspose.Slides: přidávejte, směrujte, přesměrovávejte, nastavujte spojovací body, šipky a styly pro propojení tvarů v PPT, PPTX a ODP."
---
Ukazuje, jak propojit tvary pomocí spojnic a měnit jejich cíle pomocí **Aspose.Slides for PHP via Java**.

## **Přidat spojnici**

Vložte tvar spojnice mezi dva body na snímku.

```php
function addConnector() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $connector = $slide->Shapes->addConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

        $presentation->save("connector.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Přístup ke spojnici**

Získejte první tvar spojnice přidaný do snímku.

```php
function accessConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Přístup k první spojnici na snímku.
        $firstConnector = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $firstConnector = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Odebrat spojnici**

Odstraňte spojnici ze snímku.

```php
function removeConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Předpokládá se, že první tvar na snímku je spojnice.
        $connector = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($connector);

        $presentation->save("connector_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Znovu připojit tvary**

Připojte spojnici k dvěma tvarům přiřazením počátečního a koncového cíle.

```php
function reconnectShapes() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
        $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 50, 50);
        $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

        $connector->setStartShapeConnectedTo($shape1);
        $connector->setEndShapeConnectedTo($shape2);

        $presentation->save("shapes_reconnected.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```