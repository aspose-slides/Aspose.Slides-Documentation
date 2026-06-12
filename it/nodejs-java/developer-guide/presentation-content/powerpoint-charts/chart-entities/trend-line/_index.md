---
title: Aggiungi linee di tendenza ai grafici delle presentazioni in JavaScript
linktitle: Linea di tendenza
type: docs
url: /it/nodejs-java/trend-line/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aggiungi rapidamente e personalizza le linee di tendenza nei grafici PowerPoint con JavaScript e Aspose.Slides per Node.js via Java — una guida pratica per coinvolgere il tuo pubblico."
---
## **Panoramica**

Questo articolo spiega come aggiungere linee di tendenza ai grafici delle presentazioni utilizzando Aspose.Slides. Mostra come creare un grafico, aggiungere linee di tendenza alle serie del grafico e lavorare con diversi tipi di linee di tendenza, tra cui esponenziale, lineare, logaritmica, media mobile, polinomiale e potenza.

Descrive inoltre come aggiungere una linea personalizzata a un grafico inserendo una forma di linea e include una breve FAQ sui valori di proiezione della linea di tendenza in avanti e indietro e sul fatto se le linee di tendenza vengano conservate durante l'esportazione in PDF o SVG e quando i grafici vengono renderizzati come immagini.

## **Aggiungi linea di tendenza**

Aspose.Slides per Node.js via Java offre un'API semplice per la gestione di diverse linee di tendenza dei grafici:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva tramite il suo indice.
3. Aggiungi un grafico con dati predefiniti insieme al tipo desiderato (questo esempio utilizza ChartType.ClusteredColumn).
4. Aggiunta di una linea di tendenza esponenziale per la serie 1 del grafico.
5. Aggiunta di una linea di tendenza lineare per la serie 1 del grafico.
6. Aggiunta di una linea di tendenza logaritmica per la serie 2 del grafico.
7. Aggiunta di una linea di tendenza media mobile per la serie 2 del grafico.
8. Aggiunta di una linea di tendenza polinomiale per la serie 3 del grafico.
9. Aggiunta di una linea di tendenza di potenza per la serie 3 del grafico.
10. Scrivi la presentazione modificata in un file PPTX.

Il codice seguente viene utilizzato per creare un grafico con linee di tendenza.

```javascript
// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Crea un grafico a colonne raggruppate
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);
    // Aggiunta di linea di tendenza esponenziale per la serie 1 del grafico
    var tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    // Aggiunta di linea di tendenza lineare per la serie 1 del grafico
    var tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Linear);
    tredLineLin.setTrendlineType(aspose.slides.TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Aggiunta di linea di tendenza logaritmica per la serie 2 del grafico
    var tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    // Aggiunta di linea di tendenza media mobile per la serie 2 del grafico
    var tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod(3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    // Aggiunta di linea di tendenza polinomiale per la serie 3 del grafico
    var tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder(3);
    // Aggiunta di linea di tendenza di potenza per la serie 3 del grafico
    var tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Power);
    tredLinePower.setTrendlineType(aspose.slides.TrendlineType.Power);
    tredLinePower.setBackward(1);
    // Salvataggio della presentazione
    pres.save("ChartTrendLines_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aggiungi linea personalizzata**

Aspose.Slides per Node.js via Java offre un'API semplice per aggiungere linee personalizzate in un grafico. Per aggiungere una semplice linea normale a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation)
- Ottieni il riferimento di una diapositiva usando il suo indice
- Crea un nuovo grafico utilizzando il metodo AddChart esposto dall'oggetto Shapes
- Aggiungi un AutoShape di tipo Linea utilizzando il metodo AddAutoShape esposto dall'oggetto Shapes
- Imposta il colore delle linee della forma.
- Scrivi la presentazione modificata come file PPTX

Il codice seguente viene utilizzato per creare un grafico con linee personalizzate.

```javascript
// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    var shape = chart.getUserShapes().getShapes().addAutoShape(aspose.slides.ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("Presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Cosa significano 'forward' e 'backward' per una linea di tendenza?**

Sono le lunghezze della linea di tendenza proiettata in avanti/indietro: per i grafici a dispersione (XY) — in unità dell'asse; per i grafici non a dispersione — in numero di categorie. Sono consentiti solo valori non negativi.

**La linea di tendenza verrà conservata durante l'esportazione della presentazione in PDF o SVG, o durante il rendering di una diapositiva in un'immagine?**

Sì. Aspose.Slides converte le presentazioni in [PDF](/slides/it/nodejs-java/convert-powerpoint-to-pdf/)/[SVG](/slides/it/nodejs-java/render-a-slide-as-an-svg-image/) e renderizza i grafici come immagini; le linee di tendenza, essendo parte del grafico, sono conservate durante queste operazioni. È disponibile anche un metodo per [esportare un'immagine del grafico](/slides/it/nodejs-java/create-shape-thumbnails/).