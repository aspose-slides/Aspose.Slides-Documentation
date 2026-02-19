---
title: SmartArt
type: docs
weight: 140
url: /es/androidjava/examples/elements/smart-art/
keywords:
- ejemplo de código
- SmartArt
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Trabaje con SmartArt en Aspose.Slides para Android: cree, edite, convierta y estilice diagramas con Java para presentaciones de PowerPoint y OpenDocument."
---
Este artículo muestra cómo agregar gráficos SmartArt, acceder a ellos, eliminarlos y cambiar diseños utilizando **Aspose.Slides for Android via Java**.

## **Agregar SmartArt**

Inserte un gráfico SmartArt usando uno de los diseños incorporados.

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

## **Acceder a SmartArt**

Recupere el primer objeto SmartArt de una diapositiva.

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

## **Eliminar SmartArt**

Elimine una forma SmartArt de la diapositiva.

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

## **Cambiar diseño de SmartArt**

Actualice el tipo de diseño de un gráfico SmartArt existente.

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