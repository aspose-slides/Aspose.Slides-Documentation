---
title: Csatlakozó
type: docs
weight: 190
url: /hu/androidjava/examples/elements/connector/
keywords:
- kód példa
- Csatlakozó
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan adjon hozzá, irányítson és formázzon csatlakozókat alakzatok között az Aspose.Slides for Android használatával, Java példákkal PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk bemutatja, hogyan lehet alakzatokat összekötni csatlakozókkal, és módosítani a céljaikat a **Aspose.Slides for Android via Java** használatával.

## **Csatlakozó hozzáadása**

Helyezzen el egy csatlakozó alakzatot a dia két pontja közé.

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

## **Csatlakozó elérése**

Szerezze meg az első, a diára hozzáadott csatlakozó alakzatot.

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // Az első csatlakozó elérése a dián.
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

## **Csatlakozó eltávolítása**

Távolítsa el a csatlakozót a diáról.

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

## **Alakzatok újracsatlakoztatása**

Csatlakoztassa a csatlakozót két alakzathoz a kezdő- és befejező célpontok hozzárendelésével.

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