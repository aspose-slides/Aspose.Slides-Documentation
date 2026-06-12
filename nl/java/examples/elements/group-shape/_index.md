---
title: Groepvorm
type: docs
weight: 170
url: /nl/java/examples/elements/group-shape/
keywords:
- codevoorbeeld
- groepsvorm
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Beheer gegroepeerde vormen in Aspose.Slides for Java: maak, nestel, uitlijn, herschik en style groepsvormen met Java-voorbeelden in PPT, PPTX en ODP-presentaties."
---
Voorbeelden voor het maken van groepen van vormen, het benaderen ervan, het ontgroeperen en verwijderen met **Aspose.Slides for Java**.

## **Groepvorm toevoegen**

Maak een groep die twee eenvoudige vormen bevat.

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

## **Toegang tot een groepsvorm**

Haal de eerste groepsvorm van een dia op.

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

## **Groepsvorm verwijderen**

Verwijder een groepsvorm van de dia.

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

## **Vormen ontgroeperen**

Verplaats vormen uit een groepscontainer.

```java
static void ungroupShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        IAutoShape rect = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // Verplaats vorm uit de groep.
        slide.getShapes().addClone(rect);
        group.getShapes().remove(rect);
    } finally {
        presentation.dispose();
    }
}
```