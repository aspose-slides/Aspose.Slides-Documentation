---
title: Verbindungslinie
type: docs
weight: 190
url: /de/androidjava/examples/elements/connector/
keywords:
- Codebeispiel
- Verbindungslinie
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie mithilfe von Aspose.Slides für Android Verbindungslinien zwischen Formen hinzufügen, routen und formatieren, mit Java-Beispielen für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel zeigt, wie man Formen mit Verbindungslinien verbindet und deren Ziele mithilfe von **Aspose.Slides for Android via Java** ändert.

## **Verbindungslinie hinzufügen**

Fügen Sie eine Verbindungslinien-Form zwischen zwei Punkten auf der Folie ein.

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

## **Zugriff auf eine Verbindungslinie**

Rufen Sie die zuerst zur Folie hinzugefügte Verbindungslinien-Form ab.

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // Zugriff auf die erste Verbindungslinie auf der Folie.
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

## **Entfernen einer Verbindungslinie**

Löschen Sie eine Verbindungslinie von der Folie.

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

Binden Sie eine Verbindungslinie an zwei Formen, indem Sie Start- und Endziele zuweisen.

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