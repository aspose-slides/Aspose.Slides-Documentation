---
title: Spojka
type: docs
weight: 190
url: /cs/java/examples/elements/connector/
keywords:
- ukázka kódu
- Spojka
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Zjistěte, jak pomocí Aspose.Slides pro Java přidávat, směrovat a stylovat spojky mezi tvary, s příklady v Javě pro prezentace PPT, PPTX a ODP."
---
Tento článek ukazuje, jak propojit tvary pomocí spojek a změnit jejich cíle pomocí **Aspose.Slides for Java**.

## **Přidat spojku**

Vložte tvar spojky mezi dva body na snímku.

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

Získejte první tvar spojky přidaný do snímku.

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // Přístup k první spojce na snímku.
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

Odstraňte spojku ze snímku.

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

Připojte spojku ke dvěma tvarům přiřazením počátečního a koncového cíle.

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