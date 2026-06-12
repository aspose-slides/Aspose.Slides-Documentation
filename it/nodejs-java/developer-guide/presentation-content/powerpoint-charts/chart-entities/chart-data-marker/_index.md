---
title: Gestire i Marcatori dei Dati del Grafico nelle Presentazioni Usando JavaScript
linktitle: Marcatore Dati
type: docs
url: /it/nodejs-java/chart-data-marker/
keywords:
- grafico
- punto dati
- marcatore
- opzioni marcatore
- dimensione marcatore
- tipo di riempimento
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come personalizzare i marcatori dei dati dei grafici in Aspose.Slides per Node.js, migliorando l'impatto delle presentazioni nei formati PPT e PPTX con esempi di codice chiari."
---
## **Panoramica**

Questo articolo spiega come lavorare con i marcatori dei dati dei grafici in Aspose.Slides. Mostra come creare un grafico, accedere a una serie e ai suoi punti dati, applicare riempimenti immagine ai marcatori a livello di punto dati, regolare la dimensione del marcatore e salvare la presentazione aggiornata. Evidenzia anche che le forme di marcatore standard sono disponibili tramite l'enumerazione `MarkerStyleType` e che l'aspetto del marcatore viene conservato durante l'esportazione dei grafici in formati raster o SVG.

## **Imposta le Opzioni dei Marcatori del Grafico**

I marcatori possono essere impostati sui punti dati del grafico all'interno di serie specifiche. Per impostare le opzioni del marcatore del grafico, segui i passaggi seguenti:

- Istanziare la classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
- Creare il grafico predefinito.
- Impostare l'immagine.
- Prelevare la prima serie del grafico.
- Aggiungere un nuovo punto dati.
- Scrivere la presentazione su disco.

Nell'esempio riportato di seguito, abbiamo impostato le opzioni dei marcatori del grafico a livello di punti dati.

```javascript
// Creazione di una presentazione vuota
var pres = new aspose.slides.Presentation();
try {
    // Accesso alla prima slide
    var slide = pres.getSlides().get_Item(0);
    // Creazione del grafico predefinito
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
    // Ottenimento dell'indice del foglio di lavoro dei dati del grafico predefinito
    var defaultWorksheetIndex = 0;
    // Ottenimento del foglio di lavoro dei dati del grafico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Eliminazione della serie di esempio
    chart.getChartData().getSeries().clear();
    // Aggiunta di una nuova serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    // Caricamento dell'immagine 1
    var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
    // Caricamento dell'immagine 2
    var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
    // Prendi la prima serie del grafico
    var series = chart.getChartData().getSeries().get_Item(0);
    // Aggiungi nuovo punto (1:3) lì.
    var point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 2.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 3.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    // Modifica del marcatore della serie del grafico
    series.getMarker().setSize(15);
    // Salva la presentazione con il grafico
    pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Quali forme di marcatore sono disponibili di default?**

Sono disponibili forme standard (cerchio, quadrato, diamante, triangolo, ecc.); l'elenco è definito dall'enumerazione [MarkerStyleType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/markerstyletype/). Se ti serve una forma non standard, usa un marcatore con riempimento immagine per emulare elementi grafici personalizzati.

**I marcatori vengono conservati quando si esporta un grafico in un'immagine o SVG?**

Sì. Quando si rendono i grafici in [formati raster](/slides/it/nodejs-java/convert-powerpoint-to-png/) o si salvano [forme come SVG](/slides/it/nodejs-java/render-a-slide-as-an-svg-image/), i marcatori mantengono il loro aspetto e le impostazioni, inclusi dimensione, riempimento e contorno.