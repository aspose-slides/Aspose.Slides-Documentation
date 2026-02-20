---
title: Tabla
type: docs
weight: 120
url: /es/php-java/examples/elements/table/
keywords:
- tabla
- añadir tabla
- acceder tabla
- eliminar tabla
- combinar celdas
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Crear y dar formato a tablas en PHP con Aspose.Slides: insertar datos, combinar celdas, dar estilo a los bordes, alinear el contenido e importar/exportar para PPT, PPTX y ODP."
---
Ejemplos de cómo agregar tablas, acceder a ellas, eliminarlas y combinar celdas usando **Aspose.Slides for PHP via Java**.

## **Agregar una tabla**

Crea una tabla simple con dos filas y dos columnas.

```php
function addTable() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $widths = [80, 80];
        $heights = [30, 30];
        $table = $slide->getShapes()->addTable(50, 50, $widths, $heights);

        $presentation->save("table.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Acceder a una tabla**

Obtén la primera forma de tabla en la diapositiva.

```php
function accessTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acceder a la primera tabla en la diapositiva.
        $firstTable = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Table"))) {
                $firstTable = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Eliminar una tabla**

Elimina una tabla de una diapositiva.

```php
function removeTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Suponiendo que la tabla es la primera forma en la diapositiva.
        $table = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($table);

        $presentation->save("table_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Combinar celdas de tabla**

Combina celdas adyacentes de una tabla en una sola celda.

```php
function mergeTableCells() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Suponiendo que la tabla es la primera forma en la diapositiva.
        $table = $slide->getShapes()->get_Item(0);

        $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 1), false);

        $presentation->save("cells_merged.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```