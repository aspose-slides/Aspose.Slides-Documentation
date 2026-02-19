---
title: Tabla
type: docs
weight: 120
url: /es/nodejs-java/examples/elements/table/
keywords:
- ejemplo de código
- tabla
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Trabaje con tablas en Aspose.Slides para Node.js: cree, formatee, combine celdas, aplique estilos, importe datos y exporte, con ejemplos para PPT, PPTX y ODP."
---
Ejemplos para añadir tablas, acceder a ellas, eliminarlas y combinar celdas usando **Aspose.Slides for Node.js via Java**.

## **Añadir una tabla**

Cree una tabla simple con dos filas y dos columnas.

```js
function addTable() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let widths = java.newArray("double", [80, 80]);
        let heights = java.newArray("double", [30, 30]);
        let table = slide.getShapes().addTable(50, 50, widths, heights);

        presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Acceder a una tabla**

Recupere la primera forma de tabla de la diapositiva.

```js
function accessTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Acceder a la primera tabla de la diapositiva.
        let firstTable = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
                firstTable = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar una tabla**

Elimine una tabla de una diapositiva.

```js
function removeTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Suponga que la primera forma es una tabla.
        let table = slide.getShapes().get_Item(0);

        slide.getShapes().remove(table);

        presentation.save("table_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Combinar celdas de tabla**

Combine celdas adyacentes de una tabla en una única celda.

```js
function mergeTableCells() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Suponga que la primera forma es una tabla.
        let table = slide.getShapes().get_Item(0);

        // Combinar celdas.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);

        presentation.save("cells_merged.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```