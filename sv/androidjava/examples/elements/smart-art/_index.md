---
title: SmartArt
type: docs
weight: 140
url: /sv/androidjava/examples/elements/smart-art/
keywords:
- kodexempel
- SmartArt
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Arbeta med SmartArt i Aspose.Slides för Android: skapa, redigera, konvertera och formatera diagram med Java för PowerPoint- och OpenDocument-presentationer."
---
Denna artikel demonstrerar hur du lägger till SmartArt-grafik, får åtkomst till dem, tar bort dem och ändrar layouter med **Aspose.Slides for Android via Java**.

## **Lägg till SmartArt**

Infoga en SmartArt-grafik med hjälp av en av de inbyggda layouterna.

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

Radera en SmartArt-form från bilden.

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