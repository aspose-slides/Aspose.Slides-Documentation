---
title: Gestire le serie di dati dei grafici nelle presentazioni usando JavaScript
linktitle: Serie di dati
type: docs
url: /it/nodejs-java/chart-series/
keywords:
- serie di grafico
- sovrapposizione delle serie
- colore della serie
- colore della categoria
- nome della serie
- punto dati
- gap della serie
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: Scopri come gestire le serie dei grafici in JavaScript per PowerPoint (PPT/PPTX) con esempi di codice pratici e best practice per migliorare le tue presentazioni dei dati.
---
## **Panoramica**

Questo articolo descrive il ruolo di [ChartSeries](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/) in Aspose.Slides, concentrandosi su come i dati sono strutturati e visualizzati nelle presentazioni. Questi oggetti forniscono gli elementi fondamentali che definiscono insiemi individuali di punti dati, categorie e parametri di aspetto in un grafico. Lavorando con [ChartSeries](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/), gli sviluppatori possono integrare senza problemi le sorgenti dati sottostanti e mantenere il pieno controllo su come le informazioni vengono visualizzate, ottenendo presentazioni dinamiche basate sui dati che trasmettono chiaramente approfondimenti e analisi.

Una serie è una riga o colonna di numeri tracciati in un grafico.

![serie-di-grafico-powerpoint](chart-series-powerpoint.png)

## **Impostare la Sovrapposizione delle Serie del Grafico**

Con il metodo [ChartSeries.getOverlap](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartseries/#getOverlap) è possibile specificare quanto le barre e le colonne devono sovrapporsi in un grafico 2D (intervallo: -100 a 100). Questa proprietà si applica a tutte le serie del gruppo di serie genitore: è una proiezione della proprietà di gruppo appropriata. Pertanto, questa proprietà è di sola lettura.

Utilizzare la proprietà di lettura/scrittura `ParentSeriesGroup.getOverlap` per impostare il valore desiderato per `Overlap`.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Aggiungere un grafico a colonne raggruppate su una diapositiva.
1. Accedere alla prima serie del grafico.
1. Accedere al `ParentSeriesGroup` della serie e impostare il valore di sovrapposizione desiderato.
1. Scrivere la presentazione modificata in un file PPTX.

Questo codice JavaScript mostra come impostare la sovrapposizione per una serie del grafico:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Aggiunge il grafico
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0) {
        // Imposta la sovrapposizione della serie
        series.get_Item(0).getParentSeriesGroup().setOverlap(-30);
    }
    // Scrive il file di presentazione su disco
    pres.save("SetChartSeriesOverlap_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Modificare il Colore della Serie**

Aspose.Slides for Node.js via Java consente di modificare il colore di una serie in questo modo:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Aggiungere un grafico sulla diapositiva.
1. Accedere alla serie di cui si desidera modificare il colore.
1. Impostare il tipo di riempimento e il colore di riempimento desiderati.
1. Salvare la presentazione modificata.

Questo codice JavaScript mostra come modificare il colore di una serie:

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);
    point.setExplosion(30);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Modificare il Colore della Categoria della Serie**

Aspose.Slides for Node.js via Java consente di modificare il colore della categoria di una serie in questo modo:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Aggiungere un grafico sulla diapositiva.
1. Accedere alla categoria della serie di cui si desidera modificare il colore.
1. Impostare il tipo di riempimento e il colore di riempimento desiderati.
1. Salvare la presentazione modificata.

Questo codice JavaScript mostra come modificare il colore della categoria di una serie:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Modificare il Nome della Serie** 

Per impostazione predefinita, i nomi della legenda di un grafico corrispondono al contenuto delle celle sopra ciascuna colonna o riga di dati. 

Nel nostro esempio (immagine di esempio), 

* le colonne sono *Series 1, Series 2,* e *Series 3*;
* le righe sono *Category 1, Category 2, Category 3,* e *Category 4.* 

Aspose.Slides for Node.js via Java consente di aggiornare o modificare il nome di una serie nei dati del grafico e nella legenda.

Questo codice JavaScript mostra come modificare il nome di una serie nei dati del grafico `ChartDataWorkbook`:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Questo codice JavaScript mostra come modificare il nome di una serie nella legenda tramite `Series`:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries().get_Item(0);
    var name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Impostare il Colore di Riempimento della Serie del Grafico**

Aspose.Slides for Node.js via Java consente di impostare il colore di riempimento automatico per le serie del grafico all'interno dell'area di tracciamento in questo modo:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Ottenere il riferimento di una diapositiva mediante il suo indice.
1. Aggiungere un grafico con dati predefiniti basati sul tipo desiderato (nell'esempio seguente, abbiamo usato `ChartType.ClusteredColumn`).
1. Accedere alla serie del grafico e impostare il colore di riempimento su Automatic.
1. Salvare la presentazione in un file PPTX.

Questo codice JavaScript mostra come impostare il colore di riempimento automatico per una serie del grafico:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Crea un grafico a colonne raggruppate
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 50, 600, 400);
    // Imposta il formato di riempimento della serie su automatico
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }
    // Scrive il file di presentazione su disco
    pres.save("AutoFillSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Impostare le Serie del Grafico con Riempimento Invertito**

Aspose.Slides consente di impostare il colore di riempimento invertito per le serie del grafico all'interno dell'area di tracciamento in questo modo:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Ottenere il riferimento di una diapositiva mediante il suo indice.
1. Aggiungere un grafico con dati predefiniti basati sul tipo desiderato (nell'esempio seguente, abbiamo usato `ChartType.ClusteredColumn`).
1. Accedere alla serie del grafico e impostare il colore di riempimento su invertito.
1. Salvare la presentazione in un file PPTX.

Questo codice JavaScript dimostra l'operazione:

```javascript
var inverColor = java.getStaticFieldValue("java.awt.Color", "RED");
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Aggiunge nuove serie e categorie
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));
    // Prende la prima serie del grafico e popola i dati della serie.
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    var seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    pres.save("SetInvertFillColorChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Impostare l'Invertimento della Serie Quando il Valore è Negativo**

Aspose.Slides consente di impostare l'inversione tramite il metodo `ChartDataPoint.setInvertIfNegative`. Quando l'inversione è impostata mediante le proprietà, il punto dati inverte i colori quando riceve un valore negativo. 

Questo codice JavaScript dimostra l'operazione:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();
    var chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));
    chartSeries.setInvertIfNegative(false);
    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Cancellare i Dati di Specifici Punti Dati**

Aspose.Slides for Node.js via Java consente di cancellare i dati dei `DataPoints` per una serie di grafico specifica in questo modo:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Ottenere il riferimento di una diapositiva tramite il suo indice.
3. Ottenere il riferimento di un grafico tramite il suo indice.
4. Iterare tutti i `DataPoints` del grafico e impostare `XValue` e `YValue` su null.
5. Cancellare tutti`DataPoints` per le serie di grafico specifiche.
6. Scrivere la presentazione modificata in un file PPTX.

Questo codice JavaScript dimostra l'operazione:

```javascript
var pres = new aspose.slides.Presentation("TestChart.pptx");
try {
    var sl = pres.getSlides().get_Item(0);
    var chart = sl.getShapes().get_Item(0);
    for (let i = 0; i < chart.getChartData().getSeries().get_Item(0).getDataPoints().size(); i++) {
        let dataPoint = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(i);
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }
    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();
    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Impostare la Larghezza del Divario della Serie**

Aspose.Slides for Node.js via Java consente di impostare la larghezza del divario di una serie tramite la proprietà **`GapWidth`** in questo modo:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Accedere alla prima diapositiva.
1. Aggiungere un grafico con dati predefiniti.
1. Accedere a qualsiasi serie del grafico.
1. Impostare la proprietà `GapWidth`.
1. Scrivere la presentazione modificata in un file PPTX.

Questo codice JavaScript mostra come impostare la larghezza del divario di una serie:

```javascript
// Crea una presentazione vuota
var pres = new aspose.slides.Presentation();
try {
    // Accede alla prima diapositiva della presentazione
    var slide = pres.getSlides().get_Item(0);
    // Aggiunge un grafico con dati predefiniti
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 0, 0, 500, 500);
    // Imposta l'indice del foglio dati del grafico
    var defaultWorksheetIndex = 0;
    // Ottiene il foglio di lavoro dei dati del grafico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Aggiunge serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Aggiunge categorie
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Prende la seconda serie del grafico
    var series = chart.getChartData().getSeries().get_Item(1);
    // Popola i dati della serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Imposta il valore di GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    // Salva la presentazione su disco
    pres.save("GapWidth_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Esiste un limite al numero di serie che un singolo grafico può contenere?**

Aspose.Slides non impone un limite fisso al numero di serie aggiunte. Il limite pratico è determinato dalla leggibilità del grafico e dalla memoria disponibile per l'applicazione.

**Cosa succede se le colonne all'interno di un gruppo sono troppo vicine o troppo distanti?**

Regolare l'impostazione della Larghezza del Divario per quella serie (o per il suo gruppo di serie genitore). Incrementare il valore aumenta lo spazio tra le colonne, mentre diminuirlo le avvicina.