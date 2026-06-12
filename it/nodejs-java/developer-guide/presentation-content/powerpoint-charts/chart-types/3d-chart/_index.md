---
title: Personalizza i grafici 3D nelle presentazioni usando JavaScript
linktitle: Grafico 3D
type: docs
url: /it/nodejs-java/3d-chart/
keywords:
- grafico 3D
- rotazione
- profondità
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come creare e personalizzare grafici 3-D in Aspose.Slides per Node.js via Java, con supporto per file PPT e PPTX—potenzia le tue presentazioni oggi."
---
## **Panoramica**

Questo articolo spiega come personalizzare un grafico 3D in Aspose.Slides configurando le impostazioni `Rotation3D` come `RotationX`, `RotationY`, `DepthPercents` e `RightAngleAxes`. Descrive passo passo la creazione di una presentazione, l'aggiunta di un grafico 3D con dati predefiniti, l'applicazione delle impostazioni di visualizzazione 3D richieste e il salvataggio della presentazione modificata in un file PPTX.

## **Impostare le proprietà RotationX, RotationY e DepthPercents del grafico 3D**

Aspose.Slides per Node.js via Java fornisce un'API semplice per impostare queste proprietà. L'articolo seguente ti aiuterà a impostare diverse proprietà come **Rotazione X, Rotazione Y, DepthPercents** ecc. Il codice di esempio applica l'impostazione delle proprietà sopra citate.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Accedi alla prima diapositiva.
1. Aggiungi un grafico con dati predefiniti.
1. Imposta le proprietà Rotation3D.
1. Scrivi la presentazione modificata in un file PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Accedi alla prima diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Aggiungi un grafico con dati predefiniti
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
    // Impostazione dell'indice del foglio dati del grafico
    var defaultWorksheetIndex = 0;
    // Recupero del foglio di lavoro dei dati del grafico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Aggiungi serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Aggiungi categorie
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Imposta le proprietà Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    // Preleva la seconda serie del grafico
    var series = chart.getChartData().getSeries().get_Item(1);
    // Ora popolamento dei dati della serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Imposta valore Overlap
    series.getParentSeriesGroup().setOverlap(100);
    // Scrivi la presentazione su disco
    pres.save("Rotation3D_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Quali tipi di grafico supportano la modalità 3D in Aspose.Slides?**

Aspose.Slides supporta le varianti 3D dei grafici a colonne, inclusi Column 3D, Clustered Column 3D, Stacked Column 3D e 100% Stacked Column 3D, insieme ai relativi tipi 3D esposti tramite l'enumerazione [ChartType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/). Per un elenco esatto e aggiornato, controlla i membri di [ChartType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/) nella documentazione API della versione installata.

**Posso ottenere un'immagine raster di un grafico 3D per un report o per il web?**

Sì. Puoi esportare un grafico in immagine tramite l'[chart API](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getImage) o [render the entire slide](/slides/it/nodejs-java/convert-powerpoint-to-png/) in formati come PNG o JPEG. Questo è utile quando hai bisogno di un'anteprima pixel‑perfect o vuoi incorporare il grafico in documenti, dashboard o pagine web senza richiedere PowerPoint.

**Quanto è efficiente la creazione e il rendering di grandi grafici 3D?**

Le prestazioni dipendono dal volume dei dati e dalla complessità visiva. Per i migliori risultati, mantieni gli effetti 3D minimi, evita texture pesanti su pareti e aree del grafico, limita il numero di punti dati per serie quando possibile e rendi l'output a una dimensione adeguata (risoluzione e dimensioni) per corrispondere al display o alla stampa target.