---
title: Conector
type: docs
weight: 190
url: /es/androidjava/examples/elements/connector/
keywords:
- ejemplo de código
- Conector
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda cómo agregar, enrutar y dar estilo a los conectores entre formas usando Aspose.Slides for Android, con ejemplos en Java para presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo conectar formas con conectores y cambiar sus destinos utilizando **Aspose.Slides for Android via Java**.

## **Agregar un conector**

Inserte una forma de conector entre dos puntos de la diapositiva.

```java
static void addConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
    } finally {
        presentation.dispose();
    }
}
```

## **Acceder a un conector**

Recupere la primera forma de conector añadida a una diapositiva.

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // Acceder al primer conector de la diapositiva.
        IConnector connector = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IConnector) {
                connector = (IConnector) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar un conector**

Elimine un conector de la diapositiva.

```java
static void removeConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        slide.getShapes().remove(connector);
    } finally {
        presentation.dispose();
    }
}
```

## **Reconectar formas**

Adjunte un conector a dos formas asignando los destinos de inicio y fin.

```java
static void reconnectShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        connector.setStartShapeConnectedTo(shape1);
        connector.setEndShapeConnectedTo(shape2);
    } finally {
        presentation.dispose();
    }
}
```