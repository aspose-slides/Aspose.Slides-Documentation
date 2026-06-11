---
title: Łącznik
type: docs
weight: 190
url: /pl/php-java/examples/elements/connector/
keywords:
- łącznik
- dodaj łącznik
- pobierz łącznik
- usuń łącznik
- ponownie połącz kształty
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Rysuj i steruj łącznikami w PHP za pomocą Aspose.Slides: dodawaj, wyznaczaj trasy, zmieniaj trasy, ustawiaj punkty połączeń, strzałki i style, aby łączyć kształty w plikach PPT, PPTX i ODP."
---
Pokazuje, jak łączyć kształty przy użyciu łączników i zmieniać ich cele przy użyciu **Aspose.Slides for PHP via Java**.

## **Add a Connector**
Dodaj łącznik

Wstaw kształt łącznika pomiędzy dwa punkty na slajdzie.

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

## **Access a Connector**
Uzyskaj dostęp do łącznika

Pobierz pierwszy kształt łącznika dodany do slajdu.

```php
function accessConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Uzyskaj dostęp do pierwszego łącznika na slajdzie.
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

## **Remove a Connector**
Usuń łącznik

Usuń łącznik ze slajdu.

```php
function removeConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zakładając, że pierwszy kształt na slajdzie jest łącznikiem.
        $connector = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($connector);

        $presentation->save("connector_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Reconnect Shapes**
Ponownie połącz kształty

Dołącz łącznik do dwóch kształtów, przypisując cele początkowy i końcowy.

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