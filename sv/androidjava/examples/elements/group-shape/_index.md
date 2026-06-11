---
title: Gruppform
type: docs
weight: 170
url: /sv/androidjava/examples/elements/group-shape/
keywords:
- kodexempel
- gruppform
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Hantera grupperade former i Aspose.Slides för Android: skapa, nästla, justera, omordna och formatera gruppformer med Java-exempel i PPT-, PPTX- och ODP-presentationer."
---
Exempel på att skapa grupper av former, komma åt dem, avgruppera och ta bort dem med **Aspose.Slides for Android via Java**.

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

## **Kom åt en gruppform**

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

Flytta formerna ur en gruppbehållare.

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