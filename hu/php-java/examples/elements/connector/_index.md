---
title: Csatlakozó
type: docs
weight: 190
url: /hu/php-java/examples/elements/connector/
keywords:
- csatlakozó
- csatlakozó hozzáadása
- csatlakozó elérése
- csatlakozó eltávolítása
- alakzatok újrakapcsolása
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Alakítsa ki és vezérelje a csatlakozókat PHP-ben az Aspose.Slides segítségével: adjon hozzá, irányítson, módosítson útvonalat, állítson be csatlakozási pontokat, nyilakat és stílusokat, hogy alakzatokat kapcsoljon PPT, PPTX és ODP fájlokban."
---
Megmutatja, hogyan lehet alakzatokat összekapcsolni csatlakozókkal, és módosítani azok célpontjait a **Aspose.Slides for PHP via Java** használatával.

## **Csatlakozó hozzáadása**

Helyezzen el egy csatlakozó alakzatot a dia két pontja között.

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

## **Csatlakozó elérése**

A diára hozzáadott első csatlakozó alakzat lekérése.

```php
function accessConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Az első csatlakozó elérése a dián.
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

## **Csatlakozó eltávolítása**

Csatlakozó törlése a diáról.

```php
function removeConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Feltételezve, hogy a dia első alakzata egy csatlakozó.
        $connector = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($connector);

        $presentation->save("connector_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Alakzatok újrakapcsolása**

Csatlakozó hozzárendelése két alakzathoz a kezdő- és végcélpontok beállításával.

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