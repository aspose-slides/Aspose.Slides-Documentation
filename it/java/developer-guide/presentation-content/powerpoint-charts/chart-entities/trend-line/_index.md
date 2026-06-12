---
title: Aggiungere linee di tendenza ai grafici di presentazione in Java
linktitle: Linea di tendenza
type: docs
url: /it/java/trend-line/
keywords:
- grafico
- linea di tendenza
- linea di tendenza esponenziale
- linea di tendenza lineare
- linea di tendenza logaritmica
- linea di tendenza a media mobile
- linea di tendenza polinomiale
- linea di tendenza di potenza
- linea di tendenza personalizzata
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Aggiungi e personalizza rapidamente le linee di tendenza nei grafici PowerPoint con Aspose.Slides per Java — una guida pratica per coinvolgere il tuo pubblico."
---
## **Panoramica**

Questo articolo spiega come aggiungere linee di tendenza a grafici di presentazione utilizzando Aspose.Slides. Mostra come creare un grafico, aggiungere linee di tendenza alle serie del grafico e lavorare con diversi tipi di linee di tendenza, tra cui esponenziale, lineare, logaritmica, media mobile, polinomiale e potenza.

Descrive inoltre come aggiungere una linea personalizzata a un grafico inserendo una forma di linea e include una breve FAQ sui valori di proiezione in avanti e indietro della linea di tendenza e se le linee di tendenza vengono conservate durante l'esportazione in PDF o SVG e durante il rendering dei grafici come immagini.

## **Aggiungere una linea di tendenza**
Aspose.Slides per Java fornisce un'API semplice per gestire le diverse linee di tendenza dei grafici:

1. Creare un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
1. Ottenere il riferimento a una diapositiva tramite il suo indice.
1. Aggiungere un grafico con dati predefiniti insieme a uno dei tipi desiderati (questo esempio utilizza ChartType.ClusteredColumn).
1. Aggiungere una linea di tendenza esponenziale per la serie 1 del grafico.
1. Aggiungere una linea di tendenza lineare per la serie 1 del grafico.
1. Aggiungere una linea di tendenza logaritmica per la serie 2 del grafico.
1. Aggiungere una linea di tendenza a media mobile per la serie 2 del grafico.
1. Aggiungere una linea di tendenza polinomiale per la serie 3 del grafico.
1. Aggiungere una linea di tendenza di potenza per la serie 3 del grafico.
1. Scrivere la presentazione modificata in un file PPTX.

Il codice seguente viene utilizzato per creare un grafico con linee di tendenza.

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    // Creazione di un grafico a colonne raggruppate
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Aggiunta di una linea di tendenza esponenziale per la serie 1 del grafico
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Aggiunta di una linea di tendenza lineare per la serie 1 del grafico
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Aggiunta di una linea di tendenza logaritmica per la serie 2 del grafico
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // Aggiunta di una linea di tendenza a media mobile per la serie 2 del grafico
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // Aggiunta di una linea di tendenza polinomiale per la serie 3 del grafico
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Aggiunta di una linea di tendenza di potenza per la serie 3 del grafico
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Salvataggio della presentazione
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aggiungere una linea personalizzata**
Aspose.Slides per Java fornisce un'API semplice per aggiungere linee personalizzate in un grafico. Per aggiungere una semplice linea singola a una diapositiva selezionata della presentazione, seguire i passaggi seguenti:

- Creare un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation)
- Ottenere il riferimento a una diapositiva utilizzando il suo indice
- Creare un nuovo grafico utilizzando il metodo AddChart esposto dall'oggetto Shapes
- Aggiungere un'AutoShape di tipo Linea usando il metodo AddAutoShape esposto dall'oggetto Shapes
- Impostare il colore delle linee della forma.
- Scrivere la presentazione modificata come file PPTX

Il codice seguente viene utilizzato per creare un grafico con linee personalizzate.

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

**Cosa significano 'avanti' e 'indietro' per una linea di tendenza?**

Sono le lunghezze della linea di tendenza proiettate in avanti/indietro: per i grafici a dispersione (XY) — in unità dell'asse; per i grafici non a dispersione — in numero di categorie. Sono consentiti solo valori non negativi.

**La linea di tendenza viene conservata quando la presentazione viene esportata in PDF o SVG, o quando una diapositiva viene renderizzata come immagine?**

Sì. Aspose.Slides converte le presentazioni in [PDF](/slides/it/java/convert-powerpoint-to-pdf/)/[SVG](/slides/it/java/render-a-slide-as-an-svg-image/) e renderizza i grafici in immagini; le linee di tendenza, in quanto parte del grafico, vengono conservate durante queste operazioni. È disponibile anche un metodo per [esportare un'immagine del grafico](/slides/it/java/create-shape-thumbnails/) stesso.