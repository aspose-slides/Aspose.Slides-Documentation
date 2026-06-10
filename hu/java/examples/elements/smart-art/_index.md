---
title: SmartArt
type: docs
weight: 140
url: /hu/java/examples/elements/smart-art/
keywords:
- kód példa
- SmartArt
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "A SmartArt használata az Aspose.Slides for Java-ban: diagramok létrehozása, szerkesztése, konvertálása és stílusozása Java-val PowerPoint és OpenDocument prezentációkhoz."
---
Ez a cikk bemutatja, hogyan lehet SmartArt grafikákat hozzáadni, elérni, eltávolítani és módosítani az elrendezéseket az **Aspose.Slides for Java** használatával.

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

Szerezze meg az első SmartArt objektumot egy dián.

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

Töröljön egy SmartArt alakzatot a diáról.

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

## **SmartArt elrendezésének módosítása**

Frissítse egy meglévő SmartArt grafika elrendezéstípusát.

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