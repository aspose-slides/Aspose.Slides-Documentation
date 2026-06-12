---
title: Gestire le serie di dati del grafico nelle presentazioni usando Java
linktitle: Serie di dati
type: docs
url: /it/java/chart-series/
keywords:
- serie del grafico
- sovrapposizione delle serie
- colore della serie
- colore della categoria
- nome della serie
- punto dati
- gap della serie
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come gestire le serie di grafico in Java per PowerPoint (PPT/PPTX) con esempi di codice pratici e le migliori pratiche per migliorare le tue presentazioni di dati."
---
## **Panoramica**

Questo articolo descrive il ruolo di [ChartSeries](https://reference.aspose.com/slides/it/java/com.aspose.slides/chartseries/) in Aspose.Slides, concentrandosi su come i dati sono strutturati e visualizzati all’interno delle presentazioni. Questi oggetti forniscono gli elementi fondamentali che definiscono set individuali di punti dati, categorie e parametri di aspetto in un grafico. Lavorando con [ChartSeries](https://reference.aspose.com/slides/it/java/com.aspose.slides/chartseries/), gli sviluppatori possono integrare agevolmente le fonti di dati sottostanti e mantenere il pieno controllo su come le informazioni vengono visualizzate, ottenendo presentazioni dinamiche basate sui dati che trasmettono chiaramente approfondimenti e analisi.

Una serie è una riga o una colonna di numeri tracciati in un grafico.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Impostare la sovrapposizione della serie di grafico**

Con la proprietà [IChartSeriesOverlap](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartseries/properties/overlap) è possibile specificare quanto le barre e le colonne devono sovrapporsi in un grafico 2D (intervallo: -100 a 100). Questa proprietà si applica a tutte le serie del gruppo di serie genitore: è una proiezione della proprietà di gruppo appropriata. Pertanto, la proprietà è di sola lettura.

Utilizzare la proprietà di lettura/scrittura `ParentSeriesGroup.Overlap` per impostare il valore desiderato per `Overlap`.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
1. Aggiungere un grafico a colonne raggruppate su una diapositiva.
1. Accedere alla prima serie del grafico.
1. Accedere al `ParentSeriesGroup` della serie e impostare il valore di sovrapposizione desiderato.
1. Scrivere la presentazione modificata in un file PPTX.

Questo codice Java mostra come impostare la sovrapposizione per una serie di grafico:

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

    // Scrive il file di presentazione su disco
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modificare il colore della serie**
Aspose.Slides per Java consente di modificare il colore di una serie in questo modo:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
1. Aggiungere un grafico alla diapositiva.
1. Accedere alla serie di cui si vuole cambiare il colore.
1. Impostare il tipo di riempimento e il colore di riempimento desiderati.
1. Salvare la presentazione modificata.

Questo codice Java mostra come cambiare il colore di una serie:

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

## **Modificare il colore della categoria della serie**
Aspose.Slides per Java consente di modificare il colore di una categoria di serie in questo modo:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
1. Aggiungere un grafico alla diapositiva.
1. Accedere alla categoria della serie di cui si vuole cambiare il colore.
1. Impostare il tipo di riempimento e il colore di riempimento desiderati.
1. Salvare la presentazione modificata.

Questo codice Java mostra come cambiare il colore di una categoria di serie:

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

## **Modificare il nome della serie** 

Per impostazione predefinita, i nomi della legenda di un grafico sono il contenuto delle celle sopra ciascuna colonna o riga di dati.

Nel nostro esempio (immagine di esempio),

* le colonne sono *Series 1, Series 2,* e *Series 3*;
* le righe sono *Category 1, Category 2, Category 3,* e *Category 4*.

Aspose.Slides per Java consente di aggiornare o modificare il nome di una serie nei dati del grafico e nella legenda.

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

Questo codice Java mostra come modificare il nome di una serie nella legenda tramite `Series`:

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

## **Impostare il colore di riempimento automatico della serie di grafico**

Aspose.Slides per Java consente di impostare il colore di riempimento automatico per le serie di grafico all’interno di un’area di tracciamento in questo modo:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
1. Ottenere il riferimento a una diapositiva tramite il suo indice.
1. Aggiungere un grafico con dati predefiniti basato sul tipo preferito (nell’esempio seguente, abbiamo usato `ChartType.ClusteredColumn`).
1. Accedere alla serie del grafico e impostare il colore di riempimento su Automatic.
1. Salvare la presentazione in un file PPTX.

Questo codice Java mostra come impostare il colore di riempimento automatico per una serie di grafico:

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

    // Scrive il file di presentazione su disco
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Impostare il colore di riempimento invertito per una serie di grafico**
Aspose.Slides consente di impostare il colore di riempimento invertito per le serie di grafico all’interno di un’area di tracciamento in questo modo:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
1. Ottenere il riferimento a una diapositiva tramite il suo indice.
1. Aggiungere un grafico con dati predefiniti basato sul tipo preferito (nell’esempio seguente, abbiamo usato `ChartType.ClusteredColumn`).
1. Accedere alla serie del grafico e impostare il colore di riempimento su invertito.
1. Salvare la presentazione in un file PPTX.

Questo codice Java dimostra l’operazione:

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

## **Impostare una serie per invertire quando il valore è negativo**
Aspose.Slides consente di impostare l’inversione tramite le proprietà `IChartDataPoint.InvertIfNegative` e `ChartDataPoint.InvertIfNegative`. Quando l’inversione è impostata tramite queste proprietà, il punto dati inverte i colori quando riceve un valore negativo.

Questo codice Java dimostra l’operazione:

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

## **Cancellare i dati di un punto specifico**
Aspose.Slides per Java consente di cancellare i dati `DataPoints` per una serie di grafico specifica in questo modo:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2. Ottenere il riferimento a una diapositiva tramite il suo indice.
3. Ottenere il riferimento a un grafico tramite il suo indice.
4. Iterare tutti i `DataPoints` del grafico e impostare `XValue` e `YValue` a null.
5. Cancellare tutti i `DataPoints` per la serie di grafico specifica.
6. Scrivere la presentazione modificata in un file PPTX.

Questo codice Java dimostra l’operazione:

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

## **Impostare la larghezza del gap della serie**
Aspose.Slides per Java consente di impostare la larghezza del gap di una serie tramite la proprietà **`GapWidth`** in questo modo:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
1. Accedere alla prima diapositiva.
1. Aggiungere un grafico con dati predefiniti.
1. Accedere a una qualsiasi serie del grafico.
1. Impostare la proprietà `GapWidth`.
1. Scrivere la presentazione modificata in un file PPTX.

Questo codice Java mostra come impostare la larghezza del gap di una serie:

```java
// Crea una presentazione vuota
Presentation pres = new Presentation();
try {
    // Accede alla prima diapositiva della presentazione
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Aggiunge un grafico con dati predefiniti
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Imposta l'indice del foglio dati del grafico
    int defaultWorksheetIndex = 0;
    
    // Ottiene il foglio dati del grafico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Aggiunge serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Aggiunge categorie
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Prende la seconda serie del grafico
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Popola i dati della serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Imposta il valore GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    
    // Salva la presentazione su disco
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Esiste un limite al numero di serie che un singolo grafico può contenere?**

Aspose.Slides non impone un tetto fisso al numero di serie aggiunte. Il limite pratico è determinato dalla leggibilità del grafico e dalla memoria disponibile per l’applicazione.

**Cosa fare se le colonne all’interno di un raggruppamento sono troppo vicine o troppo distanti?**

Regolare l’impostazione `GapWidth` per quella serie (o per il gruppo di serie genitore). Aumentare il valore amplia lo spazio tra le colonne, diminuendolo le avvicina.