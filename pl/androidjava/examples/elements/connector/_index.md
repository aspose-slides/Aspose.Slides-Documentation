---
title: Łącznik
type: docs
weight: 190
url: /pl/androidjava/examples/elements/connector/
keywords:
- przykład kodu
- Łącznik
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak dodawać, łączyć i stylizować łączniki między kształtami przy użyciu Aspose.Slides dla Androida, z przykładami w Javie dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł demonstruje, jak łączyć kształty za pomocą łączników i zmieniać ich cele przy użyciu **Aspose.Slides for Android via Java**.

## **Dodaj łącznik**

Wstaw kształt łącznika pomiędzy dwa punkty na slajdzie.

```java
static void addConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
    } finally {
        presentation.dispose();
    }
}
```

## **Uzyskaj dostęp do łącznika**

Pobierz pierwszy kształt łącznika dodany do slajdu.

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // Uzyskaj dostęp do pierwszego łącznika na slajdzie.
        IConnector connector = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IConnector) {
                connector = (IConnector) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Usuń łącznik**

Usuń łącznik ze slajdu.

```java
static void removeConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        slide.getShapes().remove(connector);
    } finally {
        presentation.dispose();
    }
}
```

## **Ponownie połącz kształty**

Dołącz łącznik do dwóch kształtów, przypisując cele początkowy i końcowy.

```java
static void reconnectShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        connector.setStartShapeConnectedTo(shape1);
        connector.setEndShapeConnectedTo(shape2);
    } finally {
        presentation.dispose();
    }
}
```