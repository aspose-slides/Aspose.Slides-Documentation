---
title: SmartArt
type: docs
weight: 140
url: /it/java/examples/elements/smart-art/
keywords:
- esempio di codice
- SmartArt
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Lavora con SmartArt in Aspose.Slides per Java: crea, modifica, converti e stile diagrammi con Java per presentazioni PowerPoint e OpenDocument."
---
Questo articolo dimostra come aggiungere grafiche SmartArt, accedervi, rimuoverle e modificare i layout utilizzando **Aspose.Slides for Java**.

## **Aggiungi SmartArt**

Inserisci una grafica SmartArt utilizzando uno dei layout predefiniti.

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

## **Accedi a SmartArt**

Recupera il primo oggetto SmartArt su una diapositiva.

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

## **Rimuovi SmartArt**

Elimina una forma SmartArt dalla diapositiva.

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

## **Modifica layout SmartArt**

Aggiorna il tipo di layout di una grafica SmartArt esistente.

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