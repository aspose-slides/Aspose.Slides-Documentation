---
title: SmartArt
type: docs
weight: 140
url: /sv/java/examples/elements/smart-art/
keywords:
- kodexempel
- SmartArt
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Arbeta med SmartArt i Aspose.Slides för Java: skapa, redigera, konvertera och formatera diagram med Java för PowerPoint- och OpenDocument-presentationer."
---
Den här artikeln visar hur du lägger till SmartArt-grafik, får åtkomst till dem, tar bort dem och ändrar layouter med hjälp av **Aspose.Slides for Java**.

## **Lägg till SmartArt**

Infoga en SmartArt-grafik med någon av de inbyggda layouterna.

```java
static void addSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
    } finally {
        presentation.dispose();
    }
}
```

## **Åtkomst till SmartArt**

Hämta det första SmartArt-objektet på en bild.

```java
static void accessSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        ISmartArt firstSmartArt = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ISmartArt) {
                firstSmartArt = (ISmartArt) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Ta bort SmartArt**

Ta bort en SmartArt-form från bilden.

```java
static void removeSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        slide.getShapes().remove(smartArt);
    } finally {
        presentation.dispose();
    }
}
```

## **Ändra SmartArt-layout**

Uppdatera layouttypen för en befintlig SmartArt-grafik.

```java
static void changeSmartArtLayout() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);
        smartArt.setLayout(SmartArtLayoutType.VerticalPictureList);
    } finally {
        presentation.dispose();
    }
}
```