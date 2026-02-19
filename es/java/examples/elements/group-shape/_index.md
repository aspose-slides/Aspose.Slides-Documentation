---
title: Forma de grupo
type: docs
weight: 170
url: /es/java/examples/elements/group-shape/
keywords:
- ejemplo de código
- forma de grupo
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Gestiona formas agrupadas en Aspose.Slides for Java: crea, anida, alinea, reorganiza y estiliza grupos de formas con ejemplos en Java en presentaciones PPT, PPTX y ODP."
---
Ejemplos de creación de grupos de formas, acceso a ellos, desagrupación y eliminación usando **Aspose.Slides for Java**.

## **Agregar un grupo de formas**

Crear un grupo que contenga dos formas básicas.

```java
static void addGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
    } finally {
        presentation.dispose();
    }
}
```

## **Acceder a un grupo de formas**

Obtener el primer grupo de formas de una diapositiva.

```java
static void accessGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        IGroupShape firstGroup = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IGroupShape) {
                firstGroup = (IGroupShape) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar un grupo de formas**

Eliminar un grupo de formas de la diapositiva.

```java
static void removeGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();

        slide.getShapes().remove(group);
    } finally {
        presentation.dispose();
    }
}
```

## **Desagrupar formas**

Mover las formas fuera de un contenedor de grupo.

```java
static void ungroupShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        IAutoShape rect = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // Mover la forma fuera del grupo.
        slide.getShapes().addClone(rect);
        group.getShapes().remove(rect);
    } finally {
        presentation.dispose();
    }
}
```