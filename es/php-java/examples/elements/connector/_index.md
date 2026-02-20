---
title: Conector
type: docs
weight: 190
url: /es/php-java/examples/elements/connector/
keywords:
- conector
- añadir conector
- acceder al conector
- eliminar conector
- volver a conectar formas
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Dibuje y controle conectores en PHP con Aspose.Slides: añada, rote, vuelva a rutear, establezca puntos de conexión, flechas y estilos para enlazar formas en PPT, PPTX y ODP."
---
Muestra cómo conectar formas con conectores y cambiar sus destinos usando **Aspose.Slides for PHP via Java**.

## **Añadir un conector**

Inserte una forma de conector entre dos puntos en la diapositiva.

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

## **Acceder a un conector**

Recupere la primera forma de conector añadida a una diapositiva.

```php
function accessConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acceder al primer conector de la diapositiva.
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

## **Eliminar un conector**

Elimine un conector de la diapositiva.

```php
function removeConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Suponiendo que la primera forma en la diapositiva es un conector.
        $connector = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($connector);

        $presentation->save("connector_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Volver a conectar formas**

Adjunte un conector a dos formas asignando los destinos de inicio y fin.

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