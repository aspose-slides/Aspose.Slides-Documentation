---
title: Personalizza i grafici 3D nelle presentazioni in .NET
linktitle: Grafico 3D
type: docs
url: /it/net/3d-chart/
keywords:
- grafico 3D
- rotazione
- profondità
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come creare e personalizzare grafici 3-D in Aspose.Slides per .NET, con supporto per file PPT e PPTX—potenzia le tue presentazioni oggi."
---
## **Panoramica**

Questo articolo spiega come personalizzare un grafico 3D in Aspose.Slides configurando le impostazioni `Rotation3D` come `RotationX`, `RotationY`, `DepthPercents` e `RightAngleAxes`. Illustra la creazione di una presentazione, l'aggiunta di un grafico 3D con dati predefiniti, l'applicazione delle impostazioni della vista 3D richieste e il salvataggio della presentazione modificata come file PPTX.

## **Imposta le proprietà RotationX, RotationY e DepthPercents di un grafico 3D**
Aspose.Slides per .NET offre un'API semplice per impostare queste proprietà. L'articolo seguente ti aiuterà a impostare diverse proprietà come rotazione X, Y, **DepthPercents** ecc. Il codice di esempio applica l'impostazione delle suddette proprietà.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
1. Accedi alla prima diapositiva.
1. Aggiungi un grafico con dati predefiniti.
1. Imposta le proprietà Rotation3D.
1. Scrivi la presentazione modificata in un file PPTX.

```c#
// Crea un'istanza della classe Presentation
Presentation presentation = new Presentation();
           
// Accedi alla prima diapositiva
ISlide slide = presentation.Slides[0];

// Aggiungi un grafico con dati predefiniti
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// Imposta l'indice del foglio dati del grafico
int defaultWorksheetIndex = 0;

// Ottieni il foglio di lavoro dei dati del grafico
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Aggiungi serie
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// Aggiungi categorie
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// Imposta le proprietà Rotation3D
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// Prendi la seconda serie del grafico
IChartSeries series = chart.ChartData.Series[1];

// Ora si popola i dati della serie
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Imposta il valore OverLap
series.ParentSeriesGroup.Overlap = 100;         

// Scrivi la presentazione su disco
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Quali tipi di grafico supportano la modalità 3D in Aspose.Slides?**

Aspose.Slides supporta varianti 3D dei grafici a colonne, inclusi Column 3D, Clustered Column 3D, Stacked Column 3D e 100% Stacked Column 3D, insieme a tipi 3D correlati esposti tramite l'enumerazione [ChartType](https://reference.aspose.com/slides/it/net/aspose.slides.charts/charttype/). Per un elenco preciso e aggiornato, controlla i membri [ChartType](https://reference.aspose.com/slides/it/net/aspose.slides.charts/charttype/) nella documentazione API della versione installata.

**Posso ottenere un'immagine raster di un grafico 3D per un report o il web?**

Sì. Puoi esportare un grafico in un'immagine tramite le [chart API](https://reference.aspose.com/slides/it/net/aspose.slides/shape/getimage/) o [rendere l'intera diapositiva](/slides/it/net/convert-powerpoint-to-png/) in formati come PNG o JPEG. Questo è utile quando hai bisogno di un'anteprima pixel‑perfect o desideri incorporare il grafico in documenti, dashboard o pagine web senza richiedere PowerPoint.

**Qual è la performance nella creazione e nel rendering di grandi grafici 3D?**

Le prestazioni dipendono dal volume dei dati e dalla complessità visiva. Per ottenere i migliori risultati, mantieni gli effetti 3D al minimo, evita texture pesanti su pareti e aree del grafico, limita il numero di punti dati per serie quando possibile e rendi l'output con dimensioni adeguate (risoluzione e dimensioni) per corrispondere al display o alle esigenze di stampa target.