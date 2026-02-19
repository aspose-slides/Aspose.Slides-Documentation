---
title: SmartArt
type: docs
weight: 140
url: /de/java/examples/elements/smart-art/
keywords:
- Codebeispiel
- SmartArt
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Arbeiten Sie mit SmartArt in Aspose.Slides for Java: Erstellen, bearbeiten, konvertieren und gestalten Sie Diagramme mit Java für PowerPoint- und OpenDocument-Präsentationen."
---
Dieser Artikel demonstriert, wie man SmartArt‑Grafiken hinzufügt, darauf zugreift, sie entfernt und Layouts ändert, wobei **Aspose.Slides for Java** verwendet wird.

## **Add SmartArt**
Fügen Sie eine SmartArt‑Grafik mithilfe eines der integrierten Layouts ein.

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
Rufen Sie das erste SmartArt‑Objekt auf einer Folie ab.

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
Löschen Sie ein SmartArt‑Shape von der Folie.

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
Aktualisieren Sie den Layouttyp einer vorhandenen SmartArt‑Grafik.

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