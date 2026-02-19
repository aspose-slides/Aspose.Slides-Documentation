---
title: Verbinder
type: docs
weight: 190
url: /de/java/examples/elements/connector/
keywords:
- Codebeispiel
- Connector
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Java Verbindungs‑elemente zwischen Formen hinzufügen, routen und formatieren, mit Java‑Beispielen für PPT-, PPTX- und ODP‑Präsentationen."
---
Dieser Artikel zeigt, wie man Formen mit Verbindern verbindet und deren Zielpunkte ändert, wobei **Aspose.Slides for Java** verwendet wird.

## **Verbindung hinzufügen**

Fügen Sie eine Verbindungsform zwischen zwei Punkten auf der Folie ein.

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

## **Verbindung abrufen**

Rufen Sie die erste zur Folie hinzugefügte Verbindungsform ab.

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // Greifen Sie auf den ersten Verbinder auf der Folie zu.
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

## **Verbindung entfernen**

Löschen Sie eine Verbindung von der Folie.

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

## **Formen neu verbinden**

Binden Sie eine Verbindung an zwei Formen, indem Sie Start- und Endziele zuweisen.

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