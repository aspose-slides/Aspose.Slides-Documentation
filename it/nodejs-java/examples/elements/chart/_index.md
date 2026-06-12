---
title: Grafico
type: docs
weight: 60
url: /it/nodejs-java/examples/elements/chart/
keywords:
- esempio di codice
- grafico
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci i grafici con Aspose.Slides per Node.js via Java: crea, formatta, associa dati ed esporta i grafici in PPT, PPTX e ODP con esempi JavaScript."
---
Esempi di aggiunta, accesso, rimozione e aggiornamento di diversi tipi di grafico con **Aspose.Slides for Node.js via Java**. Gli snippet seguenti mostrano le operazioni di base sui grafici.

## **Aggiungi un grafico**

Questo metodo aggiunge un semplice grafico ad area alla prima diapositiva.

```js
function addChart() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Aggiungi un semplice grafico ad area alla prima diapositiva.
        let chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 400, 300);

        presentation.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Accedi a un grafico**

Dopo aver creato un grafico, è possibile recuperarlo tramite la raccolta forme.

```js
function accessChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Accedi al primo grafico sulla diapositiva.
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

## **Rimuovi un grafico**

Il codice seguente rimuove il grafico dalla diapositiva.

```js
function removeChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Rimuovi il grafico.
        slide.getShapes().removeAt(0);

        presentation.save("chart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Aggiorna i dati del grafico**

È possibile modificare le proprietà del grafico, ad esempio il titolo.

```js
function updateChartData() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);
        let chart = slide.getShapes().get_Item(0);

        // Cambia il titolo del grafico.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");

        presentation.save("chart_title.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```