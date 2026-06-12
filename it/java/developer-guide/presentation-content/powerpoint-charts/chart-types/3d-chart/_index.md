---
title: Personalizza i grafici 3D nelle presentazioni usando Java
linktitle: Grafico 3D
type: docs
url: /it/java/3d-chart/
keywords:
- grafico 3D
- rotazione
- profondità
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come creare e personalizzare grafici 3-D in Aspose.Slides per Java, con supporto per file PPT e PPTX—potenzia le tue presentazioni oggi."
---
## **Panoramica**

Questo articolo spiega come personalizzare un grafico 3D in Aspose.Slides configurando le impostazioni `Rotation3D` come `RotationX`, `RotationY`, `DepthPercents` e `RightAngleAxes`. Guidiamo attraverso la creazione di una presentazione, l'aggiunta di un grafico 3D con dati predefiniti, l'applicazione delle impostazioni di visualizzazione 3D richieste e il salvataggio della presentazione modificata come file PPTX.

## **Imposta RotationX, RotationY e DepthPercents Properties of a 3D Chart**

Aspose.Slides per Java fornisce un'API semplice per impostare queste proprietà. L'articolo seguente ti aiuterà a impostare diverse proprietà come **X,Y Rotation, DepthPercents** ecc. Il codice di esempio applica le impostazioni delle proprietà sopra citate.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Accedi alla prima diapositiva.
1. Aggiungi un grafico con dati predefiniti.
1. Imposta le proprietà Rotation3D.
1. Scrivi la presentazione modificata in un file PPTX.

```java
Presentation pres = new Presentation();
try {
    // Accedi alla prima diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Aggiungi un grafico con dati predefiniti
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Impostazione dell'indice del foglio dati del grafico
    int defaultWorksheetIndex = 0;
    
    // Recupero del foglio di lavoro dei dati del grafico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Aggiungi serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Aggiungi categorie
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Imposta le proprietà Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // Prendi la seconda serie del grafico
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Ora popolamento dei dati della serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Imposta valore OverLap
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Scrivi la presentazione su disco
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Quali tipi di grafico supportano la modalità 3D in Aspose.Slides?**

Aspose.Slides supporta varianti 3D dei grafici a colonne, inclusi Column 3D, Clustered Column 3D, Stacked Column 3D e 100% Stacked Column 3D, insieme ai tipi 3D correlati esposti tramite la classe [ChartType](https://reference.aspose.com/slides/it/java/com.aspose.slides/charttype/). Per un elenco preciso e aggiornato, controlla i membri di [ChartType](https://reference.aspose.com/slides/it/java/com.aspose.slides/charttype/) nella documentazione API della versione installata.

**Posso ottenere un'immagine raster di un grafico 3D per un report o il web?**

Sì. Puoi esportare un grafico in un'immagine tramite l'[chart API](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#getImage-int-float-float-) o [render the entire slide](/slides/it/java/convert-powerpoint-to-png/) in formati come PNG o JPEG. È utile quando è necessario un'anteprima pixel-perfetta o vuoi incorporare il grafico in documenti, dashboard o pagine web senza richiedere PowerPoint.

**Qual è la performance nella costruzione e nel rendering di grandi grafici 3D?**

Le prestazioni dipendono dal volume dei dati e dalla complessità visiva. Per ottenere i migliori risultati, mantieni gli effetti 3D al minimo, evita texture pesanti su pareti e aree del grafico, limita il numero di punti dati per serie quando possibile e renderizza in un output di dimensioni adeguate (risoluzione e dimensioni) per corrispondere al display o alle esigenze di stampa target.