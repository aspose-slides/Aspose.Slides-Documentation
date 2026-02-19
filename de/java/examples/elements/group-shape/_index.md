---
title: Gruppenform
type: docs
weight: 170
url: /de/java/examples/elements/group-shape/
keywords:
- Codebeispiel
- Gruppenform
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Verwalten Sie gruppierte Formen in Aspose.Slides für Java: Erstellen, verschachteln, ausrichten, neu anordnen und formatieren Sie Gruppenformen mit Java-Beispielen in PPT-, PPTX- und ODP-Präsentationen."
---
Beispiele zum Erstellen von Gruppen von Formen, zum Zugriff darauf, zum Aufheben der Gruppierung und zum Entfernen mit **Aspose.Slides for Java**.

## **Gruppenform hinzufügen**

Erstelle eine Gruppe, die zwei Grundformen enthält.

```java
static void addGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
    } finally {
        presentation.dispose();
    }
}
```

## **Zugriff auf eine Gruppenform**

Rufe die erste Gruppenform von einer Folie ab.

```java
static void accessGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        IGroupShape firstGroup = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IGroupShape) {
                firstGroup = (IGroupShape) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Gruppenform entfernen**

Lösche eine Gruppenform von der Folie.

```java
static void removeGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();

        slide.getShapes().remove(group);
    } finally {
        presentation.dispose();
    }
}
```

## **Gruppierung aufheben**

Verschiebe Formen aus einem Gruppencontainer heraus.

```java
static void ungroupShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        IAutoShape rect = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // Form aus der Gruppe verschieben.
        slide.getShapes().addClone(rect);
        group.getShapes().remove(rect);
    } finally {
        presentation.dispose();
    }
}
```