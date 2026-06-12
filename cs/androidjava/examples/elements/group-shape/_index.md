---
title: Skupinový tvar
type: docs
weight: 170
url: /cs/androidjava/examples/elements/group-shape/
keywords:
- příklad kódu
- skupinový tvar
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Spravujte seskupené tvary v Aspose.Slides pro Android: vytvářejte, vnořujte, zarovnávejte, přeskupujte a stylizujte skupinové tvary pomocí příkladů v jazyce Java v prezentacích PPT, PPTX a ODP."
---
Příklady vytváření skupin tvarů, jejich přístupu, odskupování a odstraňování pomocí **Aspose.Slides for Android via Java**.

## **Přidání skupinového tvaru**

Vytvořte skupinu obsahující dva základní tvary.

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

## **Přístup ke skupinovému tvaru**

Získejte první skupinový tvar ze snímku.

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

## **Odstranění skupinového tvaru**

Odstraňte skupinový tvar ze snímku.

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

## **Rozdělení tvarů**

Přesuňte tvary mimo kontejner skupiny.

```java
static void ungroupShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        IAutoShape rect = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // Přesunout tvar mimo skupinu.
        slide.getShapes().addClone(rect);
        group.getShapes().remove(rect);
    } finally {
        presentation.dispose();
    }
}
```