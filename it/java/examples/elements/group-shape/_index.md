---
title: Forma di gruppo
type: docs
weight: 170
url: /it/java/examples/elements/group-shape/
keywords:
- esempio di codice
- forma di gruppo
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Gestisci forme raggruppate in Aspose.Slides per Java: crea, annida, allinea, riordina e personalizza le forme di gruppo con esempi Java in presentazioni PPT, PPTX e ODP."
---
Esempi per creare gruppi di forme, accedervi, separare i gruppi e rimuoverli utilizzando **Aspose.Slides for Java**.

## **Aggiungi una forma di gruppo**
Crea un gruppo contenente due forme di base.

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

## **Accedi a una forma di gruppo**
Recupera la prima forma di gruppo da una diapositiva.

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

## **Rimuovi una forma di gruppo**
Elimina una forma di gruppo dalla diapositiva.

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

## **Annulla il raggruppamento delle forme**
Sposta le forme fuori da un contenitore di gruppo.

```java
static void ungroupShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        IAutoShape rect = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // Sposta la forma fuori dal gruppo.
        slide.getShapes().addClone(rect);
        group.getShapes().remove(rect);
    } finally {
        presentation.dispose();
    }
}
```