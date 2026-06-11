---
title: Grupa kształtów
type: docs
weight: 170
url: /pl/java/examples/elements/group-shape/
keywords:
- przykład kodu
- grupa kształtów
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Zarządzaj grupowanymi kształtami w Aspose.Slides for Java: twórz, zagnieżdżaj, wyrównuj, zmieniaj kolejność i stylizuj grupy kształtów przy użyciu przykładów Java w prezentacjach PPT, PPTX i ODP."
---
Przykłady tworzenia grup kształtów, uzyskiwania do nich dostępu, rozgrupowywania i usuwania przy użyciu **Aspose.Slides for Java**.

## **Dodaj grupę kształtów**

Utwórz grupę zawierającą dwa podstawowe kształty.

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

## **Uzyskaj dostęp do grupy kształtów**

Pobierz pierwszą grupę kształtów ze slajdu.

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

## **Usuń grupę kształtów**

Usuń grupę kształtów ze slajdu.

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

## **Rozgrupuj kształty**

Przenieś kształty poza kontener grupy.

```java
static void ungroupShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        IAutoShape rect = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // Przenieś kształt poza grupę.
        slide.getShapes().addClone(rect);
        group.getShapes().remove(rect);
    } finally {
        presentation.dispose();
    }
}
```