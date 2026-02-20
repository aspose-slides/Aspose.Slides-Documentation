---
title: Gráfico
type: docs
weight: 60
url: /es/php-java/examples/elements/chart/
keywords:
- gráfico
- agregar gráfico
- acceder al gráfico
- eliminar gráfico
- actualizar gráfico
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Crea y personaliza gráficos en PHP con Aspose.Slides: agrega datos, da formato a series, ejes y etiquetas, cambia tipos y exporta—funciona con PPT, PPTX y ODP."
---
Ejemplos de cómo añadir, acceder, eliminar y actualizar diferentes tipos de gráficos con **Aspose.Slides for PHP via Java**. Los fragmentos siguientes demuestran operaciones básicas con gráficos.

## **Agregar un gráfico**

Este método agrega un gráfico de áreas simple a la primera diapositiva.

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Agregar un gráfico de columnas simple a la diapositiva.
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Acceder a un gráfico**

Recupera el gráfico de la colección de formas.

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acceder al primer gráfico en la diapositiva.
        $firstChart = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Chart"))) {
                $firstChart = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Eliminar un gráfico**

El siguiente código elimina un gráfico de una diapositiva.

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Suponiendo que la primera forma de la diapositiva es el gráfico.
        $chart = $slide->getShapes()->get_Item(0);

        // Eliminar el gráfico.
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Actualizar datos del gráfico**

Puedes cambiar las propiedades del gráfico, como el título.

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Suponiendo que la primera forma de la diapositiva es el gráfico.
        $chart = $slide->getShapes()->get_Item(0);

        // Cambiar el título del gráfico.
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```