---
title: Csoport alakzat
type: docs
weight: 170
url: /hu/androidjava/examples/elements/group-shape/
keywords:
- kódrészlet
- csoport alakzat
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Kezelje a csoportosított alakzatokat az Aspose.Slides for Android-ban: hozzon létre, ágyazzon be, igazítson, rendezzen át, és formázza a csoport alakzatokat Java példákkal PPT, PPTX és ODP prezentációkban."
---
Példák alakzatcsoportok létrehozására, elérésére, csoportosítás felbontására és eltávolítására a **Aspose.Slides for Android via Java** használatával.

## **Csoport alakzat hozzáadása**

Hozzon létre egy csoportot, amely két alap alakzatot tartalmaz.

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

## **Csoport alakzat elérése**

Szerezze meg az első csoport alakzatot egy dián.

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

## **Csoport alakzat eltávolítása**

Törölje a csoport alakzatot a diáról.

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

## **Alakzatok csoportosításának felbontása**

Az alakzatok áthelyezése a csoporttárolóból.

```java
static void ungroupShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        IAutoShape rect = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // Alakzat áthelyezése a csoportból.
        slide.getShapes().addClone(rect);
        group.getShapes().remove(rect);
    } finally {
        presentation.dispose();
    }
}
```