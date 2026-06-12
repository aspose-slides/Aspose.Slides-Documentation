---
title: SmartArt
type: docs
weight: 140
url: /nl/androidjava/examples/elements/smart-art/
keywords:
- codevoorbeeld
- SmartArt
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Werk met SmartArt in Aspose.Slides voor Android: maak, bewerk, converteer en style diagrammen met Java voor PowerPoint- en OpenDocument-presentaties."
---
Dit artikel toont hoe je SmartArt-grafieken kunt toevoegen, openen, verwijderen en lay-outs kunt wijzigen met **Aspose.Slides for Android via Java**.

## **SmartArt toevoegen**

Voeg een SmartArt-grafiek in met een van de ingebouwde lay-outs.

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

## **SmartArt benaderen**

Haal het eerste SmartArt-object op een dia op.

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

## **SmartArt verwijderen**

Verwijder een SmartArt-vorm van de dia.

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

## **SmartArt‑lay-out wijzigen**

Werk het lay-outtype van een bestaande SmartArt-grafiek bij.

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