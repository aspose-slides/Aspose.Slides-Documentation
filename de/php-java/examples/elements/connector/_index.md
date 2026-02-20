---
title: Verbinder
type: docs
weight: 190
url: /de/php-java/examples/elements/connector/
keywords:
- Verbinder
- Verbinder hinzufügen
- Zugriff auf Verbinder
- Verbinder entfernen
- Formen neu verbinden
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Zeichnen und steuern Sie Connectors in PHP mit Aspose.Slides: Hinzufügen, Routen, Umleiten, Festlegen von Verbindungspunkten, Pfeilen und Stilen, um Formen in PPT, PPTX und ODP zu verbinden."
---
Zeigt, wie man Formen mit Connectors verbindet und deren Ziele ändert, wobei **Aspose.Slides for PHP via Java** verwendet wird.

## **Connector hinzufügen**

Fügen Sie eine Connector-Form zwischen zwei Punkten auf der Folie ein.

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

## **Zugriff auf einen Connector**

Rufen Sie die erste zum Folie hinzugefügte Connector-Form ab.

```php
function accessConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zugriff auf den ersten Connector auf der Folie.
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

## **Connector entfernen**

Löschen Sie einen Connector von der Folie.

```php
function removeConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Angenommen, die erste Form auf der Folie ist ein Connector.
        $connector = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($connector);

        $presentation->save("connector_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Formen neu verbinden**

Verbinden Sie einen Connector mit zwei Formen, indem Sie Start- und Endziele zuweisen.

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