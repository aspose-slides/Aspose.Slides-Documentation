---
title: "Aggiungere linee di tendenza ai grafici delle presentazioni in .NET"
linktitle: "Linea di tendenza"
type: docs
url: /it/net/trend-line/
keywords:
- grafico
- linea di tendenza
- linea di tendenza esponenziale
- linea di tendenza lineare
- linea di tendenza logaritmica
- linea di tendenza media mobile
- linea di tendenza polinomiale
- linea di tendenza di potenza
- linea di tendenza personalizzata
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Aggiungi e personalizza rapidamente le linee di tendenza nei grafici di PowerPoint con Aspose.Slides per .NET — una guida pratica per coinvolgere il tuo pubblico."
---
## **Panoramica**

Questo articolo spiega come aggiungere linee di tendenza ai grafici delle presentazioni utilizzando Aspose.Slides. Mostra come creare un grafico, aggiungere linee di tendenza alle serie del grafico e lavorare con diversi tipi di linee di tendenza, tra cui esponenziale, lineare, logaritmica, media mobile, polinomiale e potenza.

Descrive inoltre come aggiungere una linea personalizzata a un grafico inserendo una forma di linea e include una breve FAQ sui valori di proiezione della linea di tendenza in avanti e indietro e se le linee di tendenza vengono conservate durante l'esportazione in PDF o SVG e durante il rendering dei grafici come immagini.

## **Aggiungere una linea di tendenza**

Usa [ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/) per aggiungere una linea di tendenza a una serie del grafico, selezionando il suo tipo con [TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/). L'esempio crea un grafico a colonne raggruppate con dati predefiniti e aggiunge due linee di tendenza a ciascuna delle sue tre serie.

La linea di tendenza esponenziale nasconde la sua equazione e il valore R‑quadrato tramite [DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) e [DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/), mentre la linea di tendenza lineare è rossa. La linea di tendenza logaritmica utilizza [AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/) per un'etichetta personalizzata. La media mobile utilizza un [Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/) di tre punti dati e un [TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/) personalizzato.

La linea di tendenza polinomiale ha un [Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/) di tre e si estende di una categoria in avanti tramite [Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/). La linea di tendenza di potenza si estende di una categoria indietro tramite [Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

var firstSeries = chart.ChartData.Series[0];

var exponentialTrendline = firstSeries.TrendLines.Add(TrendlineType.Exponential);
exponentialTrendline.DisplayEquation = false;
exponentialTrendline.DisplayRSquaredValue = false;

var linearTrendline = firstSeries.TrendLines.Add(TrendlineType.Linear);
linearTrendline.Format.Line.FillFormat.FillType = FillType.Solid;
linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

var secondSeries = chart.ChartData.Series[1];

var logarithmicTrendline = secondSeries.TrendLines.Add(TrendlineType.Logarithmic);
logarithmicTrendline.AddTextFrameForOverriding("New log trend line");

var movingAverageTrendline = secondSeries.TrendLines.Add(TrendlineType.MovingAverage);
movingAverageTrendline.Period = 3;
movingAverageTrendline.TrendlineName = "New TrendLine Name";

var thirdSeries = chart.ChartData.Series[2];

var polynomialTrendline = thirdSeries.TrendLines.Add(TrendlineType.Polynomial);
polynomialTrendline.Forward = 1;
polynomialTrendline.Order = 3;

var powerTrendline = thirdSeries.TrendLines.Add(TrendlineType.Power);
powerTrendline.Backward = 1;

presentation.Save("ChartTrendLines.pptx", SaveFormat.Pptx);
```

## **Impostare l'intercetta di una linea di tendenza**

Usa [Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/) per fissare il valore Y di una linea di tendenza a X = 0. Questa impostazione è supportata per le linee di tendenza lineari, esponenziali e polinomiali.

Ad esempio, un modello di costo di produzione potrebbe dover partire da costi fissi noti pari a 100, anche quando le misurazioni a volumi di produzione diversi da zero suggeriscono una linea di base differente. Per una linea di tendenza lineare, fissare l'intercetta vincola l'equazione `y = ax + b` a `b = 100`; la pendenza viene adattata ai dati sotto questa restrizione. Non sposta semplicemente una linea già adattata. Le impostazioni di intersezione degli assi controllano dove gli assi del grafico si incontrano, non i coefficienti della linea di tendenza adattata.

L'esempio seguente crea un grafico a dispersione (XY) con volumi di produzione da 1 a 4 e costi di 170, 200, 230 e 260. Salva il grafico con l'intercetta automatica predefinita, imposta l'intercetta a 100 e salva un secondo PPTX. I due file differiscono solo per l'impostazione dell'intercetta. La linea di tendenza visualizza la sua equazione e si estende indietro fino a X = 0.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var nameCell = workbook.GetCell(0, 0, 1, "Production cost");
var series = chart.ChartData.Series.Add(nameCell, ChartType.ScatterWithMarkers);
double[] costs = { 170, 200, 230, 260 };

for (var i = 0; i < costs.Length; i++)
{
    var xCell = workbook.GetCell(0, i + 1, 0, i + 1);
    var yCell = workbook.GetCell(0, i + 1, 1, costs[i]);
    series.DataPoints.AddDataPointForScatterSeries(xCell, yCell);
}

var trendline = series.TrendLines.Add(TrendlineType.Linear);
trendline.DisplayEquation = true;
trendline.Backward = 1;

presentation.Save("AutomaticIntercept.pptx", SaveFormat.Pptx);

trendline.Intercept = 100;
presentation.Save("FixedIntercept.pptx", SaveFormat.Pptx);
```

Con il calcolo automatico, questi dati producono `y = 30x + 140`. Impostare l'intercetta a 100 invece produce approssimativamente `y = 43.33x + 100`: il valore adattato a zero corrisponde alla linea di base nota, mentre la linea non passa più attraverso tutti i punti dati.

| Intercetta automatica | Intercetta fissa di 100 |
| --- | --- |
| ![Linea di tendenza lineare con intercetta calcolata automaticamente a 140](intercept-automatic.png) | ![Linea di tendenza lineare con intercetta fissa a 100](intercept-fixed.png) |

Entrambe le immagini utilizzano gli stessi dati e le stesse scale degli assi. Le linee di tendenza sono estese indietro fino a X = 0 per mostrare le loro intercette.

Per impostazione predefinita, la proprietà contiene `double.NaN`, che rappresenta un'intercetta non specificata anziché zero. L'intercetta viene quindi calcolata automaticamente dai dati.

## **Aggiungere una linea personalizzata**

Una linea personalizzata è una forma disegnata sopra il grafico anziché una linea di tendenza calcolata dai dati della serie. Questo esempio utilizza [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) per aggiungere una linea orizzontale alla diapositiva sopra il grafico. La posizione della linea è specificata in coordinate della diapositiva, misurata in punti, quindi inizia dal bordo sinistro del grafico e si trova a metà altezza del grafico. La sua larghezza corrisponde a quella del grafico. Il [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) assegna alla linea un colore rosso solido.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

var line = slide.Shapes.AddAutoShape(ShapeType.Line, chart.X, chart.Y + chart.Height / 2, chart.Width, 0);
line.LineFormat.FillFormat.FillType = FillType.Solid;
line.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("AddCustomLines.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Cosa significano 'forward' e 'backward' per una linea di tendenza?**

Sono le lunghezze della linea di tendenza proiettata in avanti/indietro: per i grafici a dispersione (XY) — in unità d'asse; per i grafici non a dispersione — in numero di categorie. Sono consentiti solo valori non negativi.

**La linea di tendenza sarà conservata durante l'esportazione della presentazione in PDF o SVG, o durante il rendering di una diapositiva in un'immagine?**

Sì. Aspose.Slides converte le presentazioni in [PDF](/slides/it/net/convert-powerpoint-to-pdf/) o [SVG](/slides/it/net/render-a-slide-as-an-svg-image/) e rende i grafici in immagini; le linee di tendenza, in quanto parte del grafico, sono conservate durante queste operazioni. È disponibile anche un metodo per [esportare un'immagine del grafico](/slides/it/net/create-shape-thumbnails/) stesso.