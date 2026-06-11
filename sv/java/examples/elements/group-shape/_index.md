---
title: Gruppform
type: docs
weight: 170
url: /sv/java/examples/elements/group-shape/
keywords:
- kodexempel
- gruppform
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Hantera grupperade former i Aspose.Slides för Java: skapa, nästla, justera, omordna och formge gruppformer med Java-exempel i PPT, PPTX och ODP-presentationer."
---
Exempel på hur du skapar grupper av former, får åtkomst till dem, avgrupperar och tar bort dem med **Aspose.Slides for Java**.

## **Lägg till en gruppform**

Skapa en grupp som innehåller två grundläggande former.

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

## **Få åtkomst till en gruppform**

Hämta den första gruppformen från en bild.

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

## **Ta bort en gruppform**

Radera en gruppform från bilden.

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

## **Avgruppera former**

Flytta former ur en gruppbehållare.

```java
static void ungroupShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        IAutoShape rect = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // Flytta formen ur gruppen.
        slide.getShapes().addClone(rect);
        group.getShapes().remove(rect);
    } finally {
        presentation.dispose();
    }
}
```