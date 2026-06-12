---
title: Gestisci le serie di dati del grafico nelle presentazioni su Android
linktitle: Serie di dati
type: docs
url: /it/androidjava/chart-series/
keywords:
- serie di grafico
- sovrapposizione della serie
- colore della serie
- colore della categoria
- nome della serie
- punto dati
- spazio della serie
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come gestire le serie di grafici su Android per PowerPoint (PPT/PPTX) con esempi pratici di codice Java e le migliori pratiche per migliorare le tue presentazioni di dati."
---
## **Panoramica**

Questo articolo descrive il ruolo di [ChartSeries](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/chartseries/) in Aspose.Slides, concentrandosi su come i dati sono strutturati e visualizzati all'interno delle presentazioni. questi oggetti forniscono gli elementi fondamentali che definiscono insiemi individuali di punti dati, categorie e parametri di aspetto in un grafico. Lavorando con [ChartSeries](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/chartseries/), gli sviluppatori possono integrare senza problemi le fonti dati sottostanti e mantenere il pieno controllo su come le informazioni vengono visualizzate, ottenendo presentazioni dinamiche, guidate dai dati, che comunicano chiaramente approfondimenti e analisi.

Una serie è una riga o colonna di numeri tracciata in un grafico.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Imposta la sovrapposizione della serie del grafico**

Con il metodo [IChartSeries.getOverlap](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartseries/#getOverlap--) è possibile determinare quanto le barre e le colonne devono sovrapporsi in un grafico 2D (intervallo: -100‑100). Questa proprietà si applica a tutte le serie del gruppo di serie padre: è una proiezione della proprietà di gruppo appropriata. Pertanto, questa proprietà è di sola lettura.

Utilizza il metodo di scrittura `getParentSeriesGroup().setOverlap()` per impostare il valore di sovrapposizione desiderato.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
1. Aggiungi un grafico a colonne raggruppate su una diapositiva.
1. Accedi alla prima serie del grafico.
1. Accedi al `ParentSeriesGroup` della serie del grafico e imposta il valore di sovrapposizione desiderato per la serie.
1. Scrivi la presentazione modificata in un file PPTX.

```java
Presentation pres = new Presentation();
try {
    // Aggiunge il grafico
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Imposta la sovrapposizione della serie
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Scrive il file della presentazione su disco
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modifica il colore della serie**

Aspose.Slides for Android via Java consente di modificare il colore di una serie in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
1. Aggiungi un grafico sulla diapositiva.
1. Accedi alla serie di cui vuoi cambiare il colore. 
1. Imposta il tipo di riempimento e il colore di riempimento desiderati.
1. Salva la presentazione modificata.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);

    point.setExplosion(30);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modifica il colore della categoria della serie**

Aspose.Slides for Android via Java consente di modificare il colore di una categoria di serie in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
1. Aggiungi un grafico sulla diapositiva.
1. Accedi alla categoria della serie di cui vuoi cambiare il colore.
1. Imposta il tipo di riempimento e il colore di riempimento desiderati.
1. Salva la presentazione modificata.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);

    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modifica il nome della serie** 

Per impostazione predefinita, i nomi della legenda di un grafico corrispondono al contenuto delle celle sopra ciascuna colonna o riga di dati. 

Nel nostro esempio (immagine di esempio),

* le colonne sono *Series 1, Series 2,* e *Series 3*;
* le righe sono *Category 1, Category 2, Category 3,* e *Category 4.* 

Aspose.Slides for Android via Java consente di aggiornare o modificare il nome di una serie nei dati del grafico e nella legenda.

Questo codice Java mostra come modificare il nome di una serie nei dati del grafico `ChartDataWorkbook`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Questo codice Java mostra come modificare il nome di una serie nella sua legenda tramite `Series`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Imposta il colore di riempimento della serie del grafico**

Aspose.Slides for Android via Java consente di impostare il colore di riempimento automatico per le serie del grafico all'interno di un'area di tracciamento in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
1. Ottieni il riferimento di una diapositiva tramite il suo indice.
1. Aggiungi un grafico con dati predefiniti basati sul tipo preferito (nell'esempio sotto, abbiamo usato `ChartType.ClusteredColumn`).
1. Accedi alla serie del grafico e imposta il colore di riempimento su Automatic.
1. Salva la presentazione in un file PPTX.

```java
Presentation pres = new Presentation();
try {
    // Crea un grafico a colonne raggruppate
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Imposta il formato di riempimento della serie su automatico
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // Scrive il file della presentazione su disco
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Imposta il colore di riempimento invertito per una serie del grafico**

Aspose.Slides consente di impostare il colore di riempimento invertito per le serie del grafico all'interno di un'area di tracciamento in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
1. Ottieni il riferimento di una diapositiva tramite il suo indice.
1. Aggiungi un grafico con dati predefiniti basati sul tipo preferito (nell'esempio sotto, abbiamo usato `ChartType.ClusteredColumn`).
1. Accedi alla serie del grafico e imposta il colore di riempimento su invertito.
1. Salva la presentazione in un file PPTX.

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Aggiunge nuove serie e categorie
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // Prende la prima serie del grafico e popola i suoi dati di serie.
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    Color seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Imposta una serie per invertire quando il valore è negativo**

Aspose.Slides consente di impostare l'inversione tramite le proprietà `IChartDataPoint.InvertIfNegative` e `ChartDataPoint.InvertIfNegative`. Quando l'inversione è impostata usando queste proprietà, il punto dati inverte i suoi colori al ricevere un valore negativo. 

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    IChartSeries chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));

    chartSeries.setInvertIfNegative(false);

    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Cancella i dati di un punto specifico**

Aspose.Slides for Android via Java consente di cancellare i dati dei `DataPoints` per una serie di grafico specifica in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva tramite il suo indice.
3. Ottieni il riferimento di un grafico tramite il suo indice.
4. Itera tutti i `DataPoints` del grafico e imposta `XValue` e `YValue` a null.
5. Cancella tutti i `DataPoints` per la serie di grafico specifica.
6. Scrivi la presentazione modificata in un file PPTX.

```java
Presentation pres = new Presentation("TestChart.pptx");
try {
    ISlide sl = pres.getSlides().get_Item(0);

    IChart chart = (IChart)sl.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints())
    {
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Imposta la larghezza dello spazio della serie**

Aspose.Slides for Android via Java consente di impostare la larghezza dello spazio di una serie tramite la proprietà **`GapWidth`** in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
1. Accedi alla prima diapositiva.
1. Aggiungi un grafico con dati predefiniti.
1. Accedi a qualsiasi serie del grafico.
1. Imposta la proprietà `GapWidth`.
1. Scrivi la presentazione modificata in un file PPTX.

```java
// Crea una presentazione vuota 
    // Accede alla prima diapositiva della presentazione
    // Aggiunge un grafico con dati predefiniti
    // Imposta l'indice del foglio dati del grafico
    // Recupera il foglio di lavoro dei dati del grafico
    // Aggiunge serie
    // Aggiunge categorie
    // Prende la seconda serie del grafico
    // Popola i dati della serie
    // Imposta il valore GapWidth
    // Salva la presentazione su disco
    Presentation pres = new Presentation();
    try {
        // Accesses the presentation's first slide
        ISlide slide = pres.getSlides().get_Item(0);
        
        // Adds a chart with default data
        IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
        
        // Sets the index of the chart data sheet
        int defaultWorksheetIndex = 0;
        
        // Gets the chart data worksheet
        IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
        
        // Adds series
        chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
        chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
        
        // Adds Categories
        chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
        chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
        chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
        
        // Takes the second chart series
        IChartSeries series = chart.getChartData().getSeries().get_Item(1);
        
        // Populates the series data
        series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
        series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
        series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
        series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
        series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
        series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
        
        // Sets GapWidth value
        series.getParentSeriesGroup().setGapWidth(50);
        
        // Saves presentation to disk
        pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
    } finally {
        if (pres != null) pres.dispose();
    }
```

## **FAQ**

**Esiste un limite al numero di serie che un singolo grafico può contenere?**

Aspose.Slides non impone un limite fisso al numero di serie che è possibile aggiungere. Il limite pratico è determinato dalla leggibilità del grafico e dalla quantità di memoria disponibile per la tua applicazione.

**Cosa succede se le colonne all'interno di un gruppo sono troppo vicine o troppo distanti?**

Regola l'impostazione `GapWidth` per quella serie (o per il suo gruppo di serie padre). Aumentare il valore allarga lo spazio tra le colonne, mentre diminuirlo le avvicina.