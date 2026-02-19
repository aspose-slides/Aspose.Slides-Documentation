---
title: Tabla
type: docs
weight: 120
url: /es/androidjava/examples/elements/table/
keywords:
- ejemplo de código
- tabla
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Trabaja con tablas en Aspose.Slides para Android: crea, da formato, combina celdas, aplica estilos, importa datos y exporta con ejemplos en Java para PPT, PPTX y ODP."
---
Ejemplos para añadir tablas, acceder a ellas, eliminarlas y combinar celdas usando **Aspose.Slides for Android via Java**.

## **Añadir una tabla**

Crea una tabla sencilla con dos filas y dos columnas.

```java
static void addTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);
    } finally {
        presentation.dispose();
    }
}
```

## **Acceder a una tabla**

Obtén la primera forma de tabla en la diapositiva.

```java
static void accessTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Acceder a la primera tabla en la diapositiva.
        ITable firstTable = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                firstTable = (ITable) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar una tabla**

Elimina una tabla de una diapositiva.

```java
static void removeTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        slide.getShapes().remove(table);
    } finally {
        presentation.dispose();
    }
}
```

## **Combinar celdas de tabla**

Combina celdas adyacentes de una tabla en una sola celda.

```java
static void mergeTableCells() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Combinar celdas.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);
    } finally {
        presentation.dispose();
    }
}
```