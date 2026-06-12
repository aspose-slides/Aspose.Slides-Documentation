---
title: Connector
type: docs
weight: 190
url: /nl/php-java/examples/elements/connector/
keywords:
- connector
- connector toevoegen
- toegang tot connector
- connector verwijderen
- vormen opnieuw verbinden
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Teken en beheer connectoren in PHP met Aspose.Slides: voeg toe, routeer, herrouteer, stel verbindingpunten, pijlen en stijlen in om vormen te koppelen in PPT, PPTX en ODP."
---
Toont hoe vormen met connectoren te verbinden en hun doelpunten te wijzigen met **Aspose.Slides for PHP via Java**.

## **Connector toevoegen**

Voeg een connectorvorm toe tussen twee punten op de dia.

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

## **Toegang tot een connector**

Haal de eerste toegevoegde connectorvorm op van een dia.

```php
function accessConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Toegang tot de eerste connector op de dia.
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

## **Connector verwijderen**

Verwijder een connector van de dia.

```php
function removeConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aangenomen dat de eerste vorm op de dia een connector is.
        $connector = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($connector);

        $presentation->save("connector_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Vormen opnieuw verbinden**

Koppel een connector aan twee vormen door start‑ en einddoelpunten toe te wijzen.

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