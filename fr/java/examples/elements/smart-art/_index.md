---
title: SmartArt
type: docs
weight: 140
url: /fr/java/examples/elements/smart-art/
keywords:
- exemple de code
- SmartArt
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Travaillez avec SmartArt dans Aspose.Slides for Java : créez, modifiez, convertissez et stylisez des diagrammes avec Java pour les présentations PowerPoint et OpenDocument."
---
Cet article montre comment ajouter des graphiques SmartArt, y accéder, les supprimer et modifier les dispositions à l'aide de **Aspose.Slides for Java**.

## **Ajouter SmartArt**

Insérez un graphique SmartArt en utilisant l'une des dispositions intégrées.

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

## **Accéder à SmartArt**

Récupérez le premier objet SmartArt d'une diapositive.

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

## **Supprimer SmartArt**

Supprimez une forme SmartArt de la diapositive.

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

## **Modifier la disposition SmartArt**

Mettez à jour le type de disposition d'un graphique SmartArt existant.

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