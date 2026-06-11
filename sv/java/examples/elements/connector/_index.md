---
title: Koppling
type: docs
weight: 190
url: /sv/java/examples/elements/connector/
keywords:
- kodexempel
- Koppling
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du lägger till, ruttar och formaterar kopplingar mellan former med Aspose.Slides för Java, med Java-exempel för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur du ansluter former med kopplingar och ändrar deras mål med hjälp av **Aspose.Slides for Java**.

## **Lägg till en connector**

Infoga en connectorform mellan två punkter på bilden.

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

## **Åtkomst till en connector**

Hämta den första connectorformen som lagts till på en bild.

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // Åtkomst till den första kopplingen på bilden.
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

## **Ta bort en connector**

Ta bort en connector från bilden.

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

## **Koppla om former**

Fäst en connector till två former genom att tilldela start- och slutmål.

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