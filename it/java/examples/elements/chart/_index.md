---
title: Grafico
type: docs
weight: 60
url: /it/java/examples/elements/chart/
keywords:
- esempio di codice
- grafico
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Gestisci i grafici con Aspose.Slides per Java: crea, formatta, associa dati ed esporta grafici in PPT, PPTX e ODP con esempi Java."
---
Esempi di aggiunta, accesso, rimozione e aggiornamento di diversi tipi di grafico con **Aspose.Slides for Java**. I frammenti seguenti mostrano le operazioni di base sui grafici.

## **Aggiungi un grafico**

Questo metodo aggiunge un semplice grafico a area alla prima diapositiva.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Aggiungi un semplice grafico a area alla prima diapositiva.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **Accedi a un grafico**

Dopo aver creato un grafico, è possibile recuperarlo tramite la raccolta di forme.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // Accedi al primo grafico sulla diapositiva.
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

## **Rimuovi un grafico**

Il codice seguente rimuove un grafico da una diapositiva.

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // Rimuovi il grafico.
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **Aggiorna i dati del grafico**

È possibile modificare le proprietà del grafico, come il titolo.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // Modifica il titolo del grafico.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```