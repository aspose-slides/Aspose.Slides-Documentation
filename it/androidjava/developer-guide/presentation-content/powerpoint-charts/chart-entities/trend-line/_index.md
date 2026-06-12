---
title: Aggiungi linee di tendenza ai grafici delle presentazioni su Android
linktitle: Linea di tendenza
type: docs
url: /it/androidjava/trend-line/
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
- Android
- Java
- Aspose.Slides
description: "Aggiungi e personalizza rapidamente le linee di tendenza nei grafici PowerPoint con Aspose.Slides per Android via Java — una guida pratica per coinvolgere il tuo pubblico."
---
## **Panoramica**

Questo articolo spiega come aggiungere linee di tendenza ai grafici delle presentazioni utilizzando Aspose.Slides. Mostra come creare un grafico, aggiungere linee di tendenza alle serie del grafico e lavorare con diversi tipi di linee di tendenza, tra cui esponenziale, lineare, logaritmica, media mobile, polinomiale e di potenza.

Descrive inoltre come aggiungere una linea personalizzata a un grafico inserendo una forma di linea e include una breve FAQ sui valori di proiezione forward e backward della linea di tendenza e sul fatto che le linee di tendenza vengano preserve durante l’esportazione in PDF o SVG e durante il rendering dei grafici come immagini.

## **Aggiungi una Linea di Tendenza**
Aspose.Slides for Android via Java fornisce un’API semplice per gestire le diverse linee di tendenza dei grafici:

1. Crea un’istanza della classe [Presentazione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
1. Ottieni il riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un grafico con dati predefiniti insieme a uno dei tipi desiderati (questo esempio utilizza ChartType.ClusteredColumn).
1. Aggiunta di una linea di tendenza esponenziale per la serie 1 del grafico.
1. Aggiunta di una linea di tendenza lineare per la serie 1 del grafico.
1. Aggiunta di una linea di tendenza logaritmica per la serie 2 del grafico.
1. Aggiunta di una linea di tendenza media mobile per la serie 2 del grafico.
1. Aggiunta di una linea di tendenza polinomiale per la serie 3 del grafico.
1. Aggiunta di una linea di tendenza di potenza per la serie 3 del grafico.
1. Scrivi la presentazione modificata in un file PPTX.

Il codice seguente è usato per creare un grafico con linee di tendenza.

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    // Creazione di un grafico a colonne raggruppate
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Aggiunta linea di tendenza esponenziale per la serie 1 del grafico
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Aggiunta linea di tendenza lineare per la serie 1 del grafico
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Aggiunta linea di tendenza logaritmica per la serie 2 del grafico
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // Aggiunta linea di tendenza media mobile per la serie 2 del grafico
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // Aggiunta linea di tendenza polinomiale per la serie 3 del grafico
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Aggiunta linea di tendenza di potenza per la serie 3 del grafico
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Salvataggio della presentazione
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aggiungi una Linea Personalizzata**
Aspose.Slides for Android via Java fornisce un’API semplice per aggiungere linee personalizzate in un grafico. Per aggiungere una semplice linea piana a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

- Crea un’istanza della classe [Presentazione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation)
- Ottieni il riferimento a una diapositiva usando il suo indice
- Crea un nuovo grafico utilizzando il metodo AddChart esposto dall’oggetto Shapes
- Aggiungi un AutoShape di tipo Linea usando il metodo AddAutoShape esposto dall’oggetto Shapes
- Imposta il colore delle linee della forma.
- Scrivi la presentazione modificata come file PPTX

Il codice seguente è usato per creare un grafico con linee personalizzate.

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Cosa significano 'forward' e 'backward' per una linea di tendenza?**

Sono le lunghezze della linea di tendenza proiettata in avanti/indietro: per i grafici a dispersione (XY) — in unità degli assi; per i grafici non a dispersione — nel numero di categorie. Sono consentiti solo valori non negativi.

**La linea di tendenza viene preservata quando la presentazione viene esportata in PDF o SVG, o quando una diapositiva viene renderizzata come immagine?**

Sì. Aspose.Slides converte le presentazioni in [PDF](/slides/it/androidjava/convert-powerpoint-to-pdf/)/[SVG](/slides/it/androidjava/render-a-slide-as-an-svg-image/) e rende i grafici in immagini; le linee di tendenza, come parte del grafico, sono preservate durante queste operazioni. È disponibile anche un metodo per [esportare un’immagine del grafico](/slides/it/androidjava/create-shape-thumbnails/) stesso.