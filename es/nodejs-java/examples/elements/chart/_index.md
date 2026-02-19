---
title: Gráfico
type: docs
weight: 60
url: /es/nodejs-java/examples/elements/chart/
keywords:
- ejemplo de código
- gráfico
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Domina los gráficos con Aspose.Slides for Node.js via Java: crea, da formato, vincula datos y exporta gráficos en PPT, PPTX y ODP con ejemplos en JavaScript."
---
Ejemplos para agregar, acceder, eliminar y actualizar diferentes tipos de gráficos con **Aspose.Slides for Node.js via Java**. Los fragmentos a continuación demuestran operaciones básicas con gráficos.

## **Añadir un gráfico**

Este método añade un gráfico de área simple a la primera diapositiva.

```js
function addChart() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Añade un gráfico de área simple a la primera diapositiva.
        let chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 400, 300);

        presentation.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Acceder a un gráfico**

Después de crear un gráfico, puedes recuperarlo a través de la colección de formas.

```js
function accessChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Accede al primer gráfico en la diapositiva.
        let firstChart = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                firstChart = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar un gráfico**

El siguiente código elimina el gráfico de la diapositiva.

```js
function removeChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Elimina el gráfico.
        slide.getShapes().removeAt(0);

        presentation.save("chart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Actualizar datos del gráfico**

Puedes cambiar propiedades del gráfico, como el título.

```js
function updateChartData() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);
        let chart = slide.getShapes().get_Item(0);

        // Cambia el título del gráfico.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");

        presentation.save("chart_title.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```