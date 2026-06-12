---
title: Connector
type: docs
weight: 190
url: /nl/java/examples/elements/connector/
keywords:
- codevoorbeeld
- Connector
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u connectoren tussen vormen kunt toevoegen, routeren en opmaken met Aspose.Slides voor Java, met Java-voorbeelden voor PPT-, PPTX- en ODP-presentaties."
---
Dit artikel laat zien hoe je vormen met connectoren verbindt en hun doelstellingen wijzigt met behulp van **Aspose.Slides for Java**.

## **Connector toevoegen**

Voeg een connectorvorm in tussen twee punten op de dia.

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

## **Toegang tot een connector**

Verkrijg de eerste connectorvorm die aan een dia is toegevoegd.

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // Toegang tot de eerste connector op de dia.
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

## **Connector verwijderen**

Verwijder een connector van de dia.

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

## **Vormen opnieuw verbinden**

Koppel een connector aan twee vormen door start- en einddoelen toe te wijzen.

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