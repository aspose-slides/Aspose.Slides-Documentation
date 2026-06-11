---
title: Anslutning
type: docs
weight: 190
url: /sv/php-java/examples/elements/connector/
keywords:
- anslutning
- lägg till anslutning
- hämta anslutning
- ta bort anslutning
- återanslut former
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Rita och kontrollera anslutningar i PHP med Aspose.Slides: lägg till, rikta, omdirigera, ange anslutningspunkter, pilar och stilar för att länka former i PPT, PPTX och ODP."
---
Visar hur man ansluter former med anslutningar och ändrar deras mål med **Aspose.Slides for PHP via Java**.

## **Lägg till en anslutning**

Infoga en anslutningsform mellan två punkter på bilden.

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

## **Hämta en anslutning**

Hämta den första anslutningsformen som lagts till på en bild.

```php
function accessConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Hämta den första anslutningen på bilden.
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

## **Ta bort en anslutning**

Radera en anslutning från bilden.

```php
function removeConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Förutsatt att den första formen på bilden är en anslutning.
        $connector = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($connector);

        $presentation->save("connector_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Återanslut former**

Fäst en anslutning till två former genom att tilldela start- och slutmål.

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