---
title: Aggiungere linee di tendenza ai grafici delle presentazioni in .NET
linktitle: Linea di tendenza
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
description: "Aggiungi e personalizza rapidamente le linee di tendenza nei grafici PowerPoint con Aspose.Slides per .NET — una guida pratica per coinvolgere il tuo pubblico."
---
## **Panoramica**

Questo articolo spiega come aggiungere linee di tendenza ai grafici delle presentazioni utilizzando Aspose.Slides. Mostra come creare un grafico, aggiungere linee di tendenza alle serie del grafico e lavorare con diversi tipi di linee di tendenza, tra cui esponenziale, lineare, logaritmica, media mobile, polinomiale e potenza.

Descrive inoltre come aggiungere una linea personalizzata a un grafico inserendo una forma di linea e include una breve FAQ sui valori di proiezione della linea di tendenza in avanti e indietro e sul fatto se le linee di tendenza vengono conservate durante l'esportazione in PDF o SVG e durante il rendering dei grafici come immagini.

## **Aggiungere una linea di tendenza**
Aspose.Slides per .NET fornisce una API semplice per gestire diverse Linee di Tendenza dei grafici:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Ottieni il riferimento di una diapositiva tramite il suo indice.
3. Aggiungi un grafico con dati predefiniti e il tipo desiderato (questo esempio utilizza ChartType.ClusteredColumn).
4. Aggiunta di una linea di tendenza esponenziale per la serie 1 del grafico.
5. Aggiunta di una linea di tendenza lineare per la serie 1 del grafico.
6. Aggiunta di una linea di tendenza logaritmica per la serie 2 del grafico.
7. Aggiunta di una linea di tendenza media mobile per la serie 2 del grafico.
8. Aggiunta di una linea di tendenza polinomiale per la serie 3 del grafico.
9. Aggiunta di una linea di tendenza di potenza per la serie 3 del grafico.
10. Scrivi la presentazione modificata in un file PPTX.

Il codice seguente è usato per creare un grafico con linee di tendenza.

```c#
// Creazione di una presentazione vuota
Presentation pres = new Presentation();

// Creazione di un grafico a colonne raggruppate
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// Aggiunta di una linea di tendenza esponenziale per la serie 1 del grafico
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// Aggiunta di una linea di tendenza lineare per la serie 1 del grafico
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// Aggiunta di una linea di tendenza logaritmica per la serie 2 del grafico
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// Aggiunta di una linea di tendenza media mobile per la serie 2 del grafico
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// Aggiunta di una linea di tendenza polinomiale per la serie 3 del grafico
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// Aggiunta di una linea di tendenza di potenza per la serie 3 del grafico
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// Salvataggio della presentazione
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```

## **Aggiungere una linea personalizzata**
Aspose.Slides per .NET fornisce una API semplice per aggiungere linee personalizzate in un grafico. Per aggiungere una semplice linea semplice a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

- Crea un'istanza della classe Presentation
- Ottieni il riferimento di una diapositiva usando il suo indice
- Crea un nuovo grafico utilizzando il metodo AddChart esposto dall'oggetto Shapes
- Aggiungi un'AutoShape di tipo Linea usando il metodo AddAutoShape esposto dall'oggetto Shapes
- Imposta il colore delle linee della forma.
- Scrivi la presentazione modificata come file PPTX

Il codice seguente è usato per creare un grafico con linee personalizzate.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.UserShapes.Shapes.AddAutoShape(ShapeType.Line, 0, chart.Height / 2, chart.Width, 0);
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
    pres.Save("AddCustomLines.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Cosa significano 'forward' e 'backward' per una linea di tendenza?**

Sono le lunghezze della linea di tendenza proiettata in avanti/indietro: per i grafici a dispersione (XY) — in unità dell'asse; per i grafici non a dispersione — in numero di categorie. Sono ammessi solo valori non negativi.

**La linea di tendenza verrà conservata durante l'esportazione della presentazione in PDF o SVG, o durante il rendering di una diapositiva in un'immagine?**

Sì. Aspose.Slides converte le presentazioni in [PDF](/slides/it/net/convert-powerpoint-to-pdf/)/[SVG](/slides/it/net/render-a-slide-as-an-svg-image/) e rende i grafici in immagini; le linee di tendenza, come parte del grafico, sono conservate durante queste operazioni. È disponibile anche un metodo per [esportare un'immagine del grafico](/slides/it/net/create-shape-thumbnails/) stesso.