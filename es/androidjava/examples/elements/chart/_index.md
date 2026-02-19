---
title: Gráfico
type: docs
weight: 60
url: /es/androidjava/examples/elements/chart/
keywords:
- ejemplo de código
- gráfico
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Domina los gráficos con Aspose.Slides para Android: crea, da formato, enlaza datos y exporta gráficos en PPT, PPTX y ODP con ejemplos en Java."
---
Ejemplos de cómo agregar, acceder, eliminar y actualizar diferentes tipos de gráficos con **Aspose.Slides for Android via Java**. Los fragmentos a continuación demuestran operaciones básicas con gráficos.

## **Agregar un gráfico**

Este método agrega un gráfico de área simple a la primera diapositiva.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Añade un gráfico de área simple a la primera diapositiva.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **Acceder a un gráfico**

Después de crear un gráfico, puedes recuperarlo a través de la colección de formas.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // Accede al primer gráfico en la diapositiva.
        IChart firstChart = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                firstChart = (IChart) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar un gráfico**

El siguiente código elimina un gráfico de una diapositiva.

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // Elimina el gráfico.
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **Actualizar datos del gráfico**

Puedes cambiar propiedades del gráfico, como el título.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // Cambia el título del gráfico.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```