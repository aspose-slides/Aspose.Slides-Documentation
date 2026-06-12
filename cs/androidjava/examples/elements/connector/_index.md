---
title: Spojka
type: docs
weight: 190
url: /cs/androidjava/examples/elements/connector/
keywords:
- ukázka kódu
- Spojka
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak pomocí Aspose.Slides pro Android přidávat, vést a stylovat spojnice mezi tvary, s ukázkami v Java pro prezentace PPT, PPTX a ODP."
---
Tento článek ukazuje, jak spojit tvary pomocí spojnic a změnit jejich cíle pomocí **Aspose.Slides for Android via Java**.

## **Přidat spojku**

Vložte tvar spojnice mezi dva body na snímku.

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

## **Přístup ke spojce**

Získejte první tvar spojnice přidaný na snímek.

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // Přístup k prvnímu spojce na snímku.
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

## **Odstranit spojku**

Odstraňte spojnici ze snímku.

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

## **Znovu připojit tvary**

Připojte spojnici ke dvěma tvarům přiřazením počátečního a koncového cíle.

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