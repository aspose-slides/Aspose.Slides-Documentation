---
title: SmartArt
type: docs
weight: 140
url: /pl/java/examples/elements/smart-art/
keywords:
- przykład kodu
- SmartArt
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Pracuj z SmartArt w Aspose.Slides for Java: twórz, edytuj, konwertuj i stylizuj diagramy w Javie dla prezentacji PowerPoint i OpenDocument."
---
Ten artykuł demonstruje, jak dodawać grafiki SmartArt, uzyskiwać do nich dostęp, usuwać je i zmieniać układy przy użyciu **Aspose.Slides for Java**.

## **Add SmartArt**
Wstaw grafikę SmartArt, korzystając z jednego z wbudowanych układów.

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

## **Access SmartArt**
Pobierz pierwszy obiekt SmartArt na slajdzie.

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

## **Remove SmartArt**
Usuń kształt SmartArt ze slajdu.

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

## **Change SmartArt Layout**
Zaktualizuj typ układu istniejącej grafiki SmartArt.

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