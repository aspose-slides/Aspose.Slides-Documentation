---
title: Anslutning
type: docs
weight: 190
url: /sv/androidjava/examples/elements/connector/
keywords:
- kodexempel
- Anslutning
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du lägger till, styr och formaterar anslutningar mellan former med Aspose.Slides för Android, med Java-exempel för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur du kopplar ihop former med anslutningar och ändrar deras mål med hjälp av **Aspose.Slides for Android via Java**.

## **Lägg till en anslutning**

Infoga en anslutningsform mellan två punkter på bilden.

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

## **Hämta en anslutning**

Hämta den första anslutningsformen som lagts till på en bild.

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // Åtkomst till den första anslutningen på bilden.
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

## **Ta bort en anslutning**

Ta bort en anslutning från bilden.

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

## **Återanslut former**

Fäst en anslutning på två former genom att tilldela start- och slutmål.

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