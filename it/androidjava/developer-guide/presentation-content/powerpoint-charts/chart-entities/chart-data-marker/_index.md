---
title: Gestire i marker dei dati del grafico nelle presentazioni su Android
linktitle: Marker dati
type: docs
url: /it/androidjava/chart-data-marker/
keywords:
- grafico
- punto dati
- marker
- opzioni marker
- dimensione marker
- tipo di riempimento
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Personalizza i marker dei dati del grafico in Aspose.Slides per Android, potenziando l'impatto delle presentazioni nei formati PPT e PPTX con chiari esempi di codice Java."
---
## **Panoramica**

Questo articolo spiega come lavorare con i marker dei dati del grafico in Aspose.Slides. Mostra come creare un grafico, accedere a una serie e ai suoi punti dati, applicare riempimenti immagine ai marker a livello di punto dati, regolare la dimensione del marker e salvare la presentazione aggiornata. Nota inoltre che le forme standard dei marker sono disponibili tramite l'enumerazione `MarkerStyleType` e che l'aspetto del marker viene conservato durante l'esportazione dei grafici in formati raster o SVG.

## **Imposta le opzioni dei marker del grafico**
I marker possono essere impostati sui punti dati del grafico all'interno di serie specifiche. Per impostare le opzioni dei marker del grafico, segui i passaggi seguenti:

- Istanzia la classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
- Crea il grafico predefinito.
- Imposta l'immagine.
- Prendi la prima serie del grafico.
- Aggiungi un nuovo punto dati.
- Scrivi la presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo impostato le opzioni dei marker del grafico a livello dei punti dati.

```java
// Creazione di una presentazione vuota
Presentation pres = new Presentation();
try {
    // Accedi alla prima diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Creazione del grafico predefinito
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Recupero dell'indice del foglio di lavoro dei dati del grafico predefinito
    int defaultWorksheetIndex = 0;
    
    // Recupero del foglio di lavoro dei dati del grafico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Elimina la serie demo
    chart.getChartData().getSeries().clear();
    
    // Aggiungi una nuova serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // Carica l'immagine 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Carica l'immagine 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Prendi la prima serie del grafico
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Aggiungi un nuovo punto (1:3) lì.
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
    
    // Modifica il marker della serie del grafico
    series.getMarker().setSize(15);
    
    // Salva la presentazione con il grafico
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Quali forme di marker sono disponibili subito?**

Le forme standard sono disponibili (cerchio, quadrato, diamante, triangolo, ecc.); l'elenco è definito dalla classe [MarkerStyleType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/markerstyletype/). Se hai bisogno di una forma non standard, usa un marker con riempimento immagine per emulare elementi visivi personalizzati.

**I marker vengono conservati durante l'esportazione di un grafico in immagine o SVG?**

Sì. Quando si rendono i grafici in [formati raster](/slides/it/androidjava/convert-powerpoint-to-png/) o si salvano le [forme come SVG](/slides/it/androidjava/render-a-slide-as-an-svg-image/), i marker conservano il loro aspetto e le impostazioni, inclusi dimensione, riempimento e contorno.