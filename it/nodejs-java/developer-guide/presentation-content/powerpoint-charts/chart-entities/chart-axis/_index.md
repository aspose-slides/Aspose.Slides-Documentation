---
title: Personalizza gli assi dei grafici nelle presentazioni usando JavaScript
linktitle: Asse del grafico
type: docs
url: /it/nodejs-java/chart-axis/
keywords:
- asse del grafico
- asse verticale
- asse orizzontale
- personalizzare asse
- manipolare asse
- gestire asse
- proprietà dell'asse
- valore massimo
- valore minimo
- linea dell'asse
- formato data
- titolo dell'asse
- posizione dell'asse
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come utilizzare JavaScript con Aspose.Slides per Node.js via Java per personalizzare gli assi dei grafici nelle presentazioni PowerPoint per report e visualizzazioni."
---
## **Panoramica**

Questo articolo spiega come personalizzare gli assi del grafico in Aspose.Slides. Mostra come ottenere i valori effettivi degli assi, scambiare i dati tra gli assi, nascondere l'asse verticale o orizzontale per i grafici a linee, modificare il tipo di asse di categoria, impostare il formato data per i valori dell'asse di categoria, ruotare il titolo di un asse, impostare la posizione dell'asse e visualizzare un'etichetta di unità sull'asse dei valori.

## **Ottenere i valori massimi sull'asse verticale nei grafici**

Aspose.Slides for Node.js via Java consente di ottenere i valori minimo e massimo su un asse verticale. Segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Accedi alla prima diapositiva.
1. Aggiungi un grafico con dati predefiniti.
1. Ottieni il valore massimo effettivo sull'asse.
1. Ottieni il valore minimo effettivo sull'asse.
1. Ottieni l'unità principale effettiva dell'asse.
1. Ottieni l'unità secondaria effettiva dell'asse.
1. Ottieni la scala dell'unità principale effettiva dell'asse.
1. Ottieni la scala dell'unità secondaria effettiva dell'asse.

Questo codice di esempio—un'implementazione dei passaggi precedenti—mostra come ottenere i valori richiesti in JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
    // Salva la presentazione
    pres.save("MaxValuesVerticalAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Scambio dei dati tra gli assi**

Aspose.Slides consente di scambiare rapidamente i dati tra gli assi: i dati rappresentati sull'asse verticale (asse y) vengono spostati sull'asse orizzontale (asse x) e viceversa.

Questo codice JavaScript mostra come eseguire lo scambio di dati tra gli assi su un grafico:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    // Scambia righe e colonne
    chart.getChartData().switchRowColumn();
    // Salva la presentazione
    pres.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Disabilitare l'asse verticale per i grafici a linee**

Questo codice JavaScript mostra come nascondere l'asse verticale per un grafico a linee:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Disabilitare l'asse orizzontale per i grafici a linee**

Questo codice mostra come nascondere l'asse orizzontale per un grafico a linee:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Modifica dell'asse di categoria**

Utilizzando la proprietà **CategoryAxisType**, è possibile specificare il tipo di asse di categoria preferito (**date** o **text**). Questo codice JavaScript dimostra l'operazione:

```javascript
var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);
    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Impostazione del formato data per il valore dell'asse di categoria**

Aspose.Slides for Node.js via Java consente di impostare il formato data per un valore dell'asse di categoria. L'operazione è dimostrata in questo codice JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 450, 300);
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(java.newInstanceSync("GregorianCalendar", 2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(java.newInstanceSync("GregorianCalendar", 2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(java.newInstanceSync("GregorianCalendar", 2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(java.newInstanceSync("GregorianCalendar", 2018, 1, 1))));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
const dayjs = require('dayjs');

function convertToOADate(date) {
    const baseDate = dayjs('1899-12-30');

    const days = date.diff(baseDate, 'day');

    const fractionalDay = (date.hour() / 24) +
                          (date.minute() / (60 * 24)) +
                          (date.second() / (60 * 24 * 60));

    const oaDate = days + fractionalDay;

    return String(oaDate);
}
```

## **Impostazione dell'angolo di rotazione per il titolo dell'asse del grafico**

Aspose.Slides for Node.js via Java consente di impostare l'angolo di rotazione per il titolo di un asse del grafico. Questo codice JavaScript dimostra l'operazione:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Impostazione della posizione dell'asse in un asse di categoria o di valore**

Aspose.Slides for Node.js via Java consente di impostare la posizione dell'asse in un asse di categoria o di valore. Questo codice JavaScript mostra come eseguire l'operazione:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Abilitare la visualizzazione dell'etichetta di unità sull'asse dei valori del grafico**

Aspose.Slides for Node.js via Java consente di configurare un grafico per mostrare un'etichetta di unità sul suo asse dei valori. Questo codice JavaScript dimostra l'operazione:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Come faccio a impostare il valore al quale un asse incrocia l'altro (incrocio degli assi)?**

Gli assi offrono un [crossing setting](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/axis/setcrosstype/): è possibile scegliere di incrociare a zero, al valore massimo della categoria/valore, oppure a un valore numerico specifico. Questo è utile per spostare l'asse X verso l'alto o verso il basso o per enfatizzare una linea di base.

**Come posso posizionare le etichette di tick rispetto all'asse (accanto, all'esterno, all'interno)?**

Imposta la [label position](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/axis/setmajortickmark/) su "cross", "outside" o "inside". Questo influisce sulla leggibilità e aiuta a risparmiare spazio, soprattutto sui grafici piccoli.