---
title: Gestire i marcatori dei dati del grafico nelle presentazioni usando Java
linktitle: Marcatore dati
type: docs
url: /it/java/chart-data-marker/
keywords:
- grafico
- punto dati
- marcatore
- opzioni del marcatore
- dimensione del marcatore
- tipo di riempimento
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come personalizzare i marcatori dei dati del grafico in Aspose.Slides per Java, migliorando l'impatto delle presentazioni nei formati PPT e PPTX con esempi di codice Java chiari."
---
## **Panoramica**

Questo articolo spiega come lavorare con i marcatori dei dati del grafico in Aspose.Slides. Mostra come creare un grafico, accedere a una serie e ai suoi punti dati, applicare riempimenti immagine ai marcatori a livello di punto dati, regolare la dimensione del marcatore e salvare la presentazione aggiornata. Inoltre, osserva che le forme di marcatore standard sono disponibili tramite l'enumerazione `MarkerStyleType` e che l'aspetto del marcatore viene conservato quando si esportano i grafici in formati raster o SVG.

## **Imposta le opzioni del marcatore del grafico**
I marcatori possono essere impostati sui punti dati del grafico all'interno di serie specifiche. Per impostare le opzioni del marcatore del grafico, segui i passaggi seguenti:

- Istanzia la classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
- Creare il grafico predefinito.
- Impostare l'immagine.
- Ottenere la prima serie del grafico.
- Aggiungere un nuovo punto dati.
- Scrivere la presentazione su disco.

Nell'esempio seguente, abbiamo impostato le opzioni del marcatore del grafico a livello dei punti dati.

```java
// Creazione di una presentazione vuota
Presentation pres = new Presentation();
try {
    // Accesso alla prima diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Creazione del grafico predefinito
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Ottenimento dell'indice del foglio di lavoro predefinito dei dati del grafico
    int defaultWorksheetIndex = 0;
    
    // Ottenimento del foglio di lavoro dei dati del grafico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Eliminazione della serie demo
    chart.getChartData().getSeries().clear();
    
    // Aggiunta di una nuova serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // Caricamento dell'immagine 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Caricamento dell'immagine 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Prendere la prima serie del grafico
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Aggiungere un nuovo punto (1:3) lì.
    IChartDataPoint point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, (double) 2.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, (double) 3.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    // Modifica del marcatore della serie del grafico
    series.getMarker().setSize(15);
    
    // Salvare la presentazione con il grafico
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Quali forme di marcatore sono disponibili di default?**

Sono disponibili forme standard (cerchio, quadrato, diamante, triangolo, ecc.); l'elenco è definito dalla classe [MarkerStyleType](https://reference.aspose.com/slides/it/java/com.aspose.slides/markerstyletype/). Se ti serve una forma non standard, usa un marcatore con riempimento immagine per emulare elementi grafici personalizzati.

**I marcatori vengono conservati quando si esporta un grafico in un'immagine o SVG?**

Sì. Quando i grafici vengono renderizzati in [formati raster](/slides/it/java/convert-powerpoint-to-png/) o si salvano [forme come SVG](/slides/it/java/render-a-slide-as-an-svg-image/), i marcatori mantengono il loro aspetto e le impostazioni, inclusi dimensione, riempimento e contorno.