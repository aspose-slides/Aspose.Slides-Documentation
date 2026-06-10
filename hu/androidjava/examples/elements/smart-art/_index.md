---
title: SmartArt
type: docs
weight: 140
url: /hu/androidjava/examples/elements/smart-art/
keywords:
- kódrészlet
- SmartArt
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Dolgozzon a SmartArt-tal az Aspose.Slides for Android-ban: hozza létre, szerkessze, konvertálja és formázza a diagramokat Java-val PowerPoint és OpenDocument prezentációkhoz."
---
Ez a cikk bemutatja, hogyan lehet SmartArt grafikákat hozzáadni, elérni, eltávolítani, és módosítani az elrendezéseket a **Aspose.Slides for Android via Java** használatával.

## **SmartArt hozzáadása**

Illesszen be egy SmartArt grafikát az egyik beépített elrendezés használatával.

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

## **SmartArt elérése**

Hozza vissza az első SmartArt objektumot egy dián.

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

## **SmartArt eltávolítása**

Törölje a SmartArt alakzatot a diáról.

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

## **SmartArt elrendezés módosítása**

Frissítse egy létező SmartArt grafika elrendezéstípussát.

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