---
title: SmartArt
type: docs
weight: 140
url: /pl/androidjava/examples/elements/smart-art/
keywords:
- przykład kodu
- SmartArt
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Pracuj z SmartArt w Aspose.Slides dla Androida: twórz, edytuj, konwertuj i stylizuj diagramy w Javie dla prezentacji PowerPoint i OpenDocument."
---
Ten artykuł demonstruje, jak dodać grafikę SmartArt, uzyskać do niej dostęp, usunąć ją i zmienić układy przy użyciu **Aspose.Slides for Android via Java**.

## **Dodaj SmartArt**

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

## **Uzyskaj dostęp do SmartArt**

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

## **Usuń SmartArt**

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

## **Zmień układ SmartArt**

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