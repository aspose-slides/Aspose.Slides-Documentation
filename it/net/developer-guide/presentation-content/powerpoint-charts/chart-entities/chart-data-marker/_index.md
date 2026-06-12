---
title: Gestire i marcatori dei dati del grafico nelle presentazioni in .NET
linktitle: Marcatore dati
type: docs
url: /it/net/chart-data-marker/
keywords:
- grafico
- punto dati
- marcatore
- opzioni marcatore
- dimensione marcatore
- tipo di riempimento
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come personalizzare i marcatori dei dati del grafico in Aspose.Slides per .NET, aumentare l'impatto delle presentazioni nei formati PPT e PPTX con chiari esempi di codice C#."
---
## **Panoramica**

Questo articolo spiega come lavorare con i marcatori dei dati dei grafici in Aspose.Slides. Mostra come creare un grafico, accedere a una serie e ai relativi punti dati, applicare riempimenti immagine ai marcatori a livello di punto dati, regolare la dimensione del marcatore e salvare la presentazione aggiornata. Evidenzia inoltre che le forme di marcatore standard sono disponibili tramite l'enumerazione `MarkerStyleType` e che l'aspetto del marcatore viene mantenuto durante l'esportazione dei grafici in formati raster o SVG.

## **Imposta le opzioni del marcatore del grafico**
I marcatori possono essere impostati sui punti dati del grafico all'interno di serie specifiche. Per impostare le opzioni del marcatore del grafico, segui i passaggi seguenti:

- Istanziare la classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
- Creare il grafico predefinito.
- Impostare l'immagine.
- Prendere la prima serie del grafico.
- Aggiungere un nuovo punto dati.
- Scrivere la presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo impostato le opzioni del marcatore del grafico a livello di punti dati.

```c#
// Crea un'istanza della classe Presentation
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Creating the default chart
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// Getting the default chart data worksheet index
int defaultWorksheetIndex = 0;

// Getting the chart data worksheet
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Elimina la serie demo
chart.ChartData.Series.Clear();

// Aggiungi una nuova serie
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// Imposta l'immagine
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Imposta l'immagine
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// Prendi la prima serie del grafico
IChartSeries series = chart.ChartData.Series[0];

// Aggiungi un nuovo punto (1:3) lì.
IChartDataPoint point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, (double)2.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, (double)3.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

// Modifica il marcatore della serie del grafico
series.Marker.Size = 15;

// Salva la presentazione su disco
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Quali forme di marcatore sono disponibili di default?**

Sono disponibili forme standard (cerchio, quadrato, diamante, triangolo, ecc.); l'elenco è definito dall'enumerazione [MarkerStyleType](https://reference.aspose.com/slides/it/net/aspose.slides.charts/markerstyletype/). Se ti serve una forma non standard, utilizza un marcatore con riempimento immagine per emulare elementi visivi personalizzati.

**I marcatori vengono mantenuti quando si esporta un grafico in immagine o SVG?**

Sì. Quando si rendono i grafici in [raster formats](/slides/it/net/convert-powerpoint-to-png/) o si salvano [shapes as SVG](/slides/it/net/render-a-slide-as-an-svg-image/), i marcatori conservano il loro aspetto e le impostazioni, inclusi dimensione, riempimento e contorno.