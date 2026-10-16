---
title: Aggiungere linee di tendenza ai grafici delle presentazioni in JavaScript
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
description: "Aggiungi e personalizza rapidamente le linee di tendenza nei grafici PowerPoint con JavaScript e Aspose.Slides per Node.js via Java — una guida pratica per coinvolgere il tuo pubblico."
---
## **Panoramica**

Questo articolo spiega come aggiungere linee di tendenza ai grafici delle presentazioni utilizzando Aspose.Slides. Mostra come creare un grafico, aggiungere linee di tendenza alle serie del grafico e lavorare con diversi tipi di linee di tendenza, tra cui esponenziale, lineare, logaritmica, media mobile, polinomiale e potenza.

Descrive inoltre come aggiungere una linea personalizzata a un grafico inserendo una forma linea, e include una breve FAQ sui valori di proiezione della linea di tendenza “forward” e “backward” e se le linee di tendenza vengono conservate durante l’esportazione in PDF o SVG e durante il rendering dei grafici come immagini.

## **Aggiungere una linea di tendenza**

Utilizza [TrendlineCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinecollection/#add) per aggiungere una linea di tendenza a una serie del grafico, selezionandone il tipo con [TrendlineType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinetype/). L'esempio crea un grafico a colonne raggruppate con dati predefiniti e aggiunge due linee di tendenza a ciascuna delle sue tre serie.

La linea di tendenza esponenziale nasconde la sua equazione e il valore R‑squared tramite [setDisplayEquation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayEquation) e [setDisplayRSquaredValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayRSquaredValue), mentre la linea di tendenza lineare è rossa. La linea di tendenza logaritmica utilizza [addTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#addTextFrameForOverriding) per un'etichetta personalizzata. La media mobile utilizza un [setPeriod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setPeriod) di tre punti dati e un [setTrendlineName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setTrendlineName) personalizzato.

La linea di tendenza polinomiale ha un [setOrder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setOrder) di tre e si estende di una categoria in avanti tramite [setForward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setForward). La linea di tendenza di potenza si estende di una categoria all’indietro tramite [setBackward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setBackward).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);

    const firstSeries = chart.getChartData().getSeries().get_Item(0);

    const exponentialTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    const linearTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(red);

    const secondSeries = chart.getChartData().getSeries().get_Item(1);

    const logarithmicTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    const movingAverageTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod(java.newByte(3));
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    const thirdSeries = chart.getChartData().getSeries().get_Item(2);

    const polynomialTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder(java.newByte(3));

    const powerTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Impostare l'intercetta di una linea di tendenza**

Utilizza [setIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setIntercept) per fissare il valore Y di una linea di tendenza a X = 0. Questa impostazione è supportata per le linee di tendenza lineari, esponenziali e polinomiali.

Ad esempio, un modello di costo di produzione potrebbe dover partire da costi fissi noti pari a 100, anche quando le misurazioni a volumi di produzione non nulli suggeriscono una base diversa. Per una linea di tendenza lineare, fissare l’intercetta vincola l’equazione `y = ax + b` a `b = 100`; la pendenza viene adattata ai dati sotto tale vincolo. Non si tratta semplicemente di spostare una linea già adattata. Le impostazioni di incrocio degli assi controllano dove gli assi del grafico si incontrano, non i coefficienti della linea di tendenza adattata.

L’esempio seguente crea un grafico a dispersione (XY) con volumi di produzione da 1 a 4 e costi di 170, 200, 230 e 260. Salva il grafico con l’intercetta automatica predefinita, imposta l’intercetta a 100 e salva un secondo PPTX. I due file differiscono solo per l’impostazione dell’intercetta. La linea di tendenza visualizza la sua equazione e si estende indietro fino a X = 0.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const nameCell = workbook.getCell(0, 0, 1, "Production cost");
    const series = chart.getChartData().getSeries().add(nameCell, aspose.slides.ChartType.ScatterWithMarkers);
    const costs = [170, 200, 230, 260];

    for (let i = 0; i < costs.length; i++) {
        const xCell = workbook.getCell(0, i + 1, 0, i + 1);
        const yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    const trendline = series.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", aspose.slides.SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Con il calcolo automatico, questi dati producono `y = 30x + 140`. Impostare l’intercetta a 100 invece produce approssimativamente `y = 43.33x + 100`: il valore adattato a zero corrisponde alla base nota, mentre la linea non attraversa più tutti i punti dati.

| Intercetta automatica | Intercetta fissa di 100 |
| --- | --- |
| ![Linea di tendenza lineare con intercetta calcolata automaticamente di 140](intercept-automatic.png) | ![Linea di tendenza lineare con intercetta fissa di 100](intercept-fixed.png) |

Entrambe le immagini usano gli stessi dati e le stesse scale degli assi. Le linee di tendenza sono estese indietro fino a X = 0 per mostrare le loro intercette.

Per impostazione predefinita, [getIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#getIntercept) restituisce `NaN`, che rappresenta un’intercetta non specificata anziché zero. L’intercetta viene quindi calcolata automaticamente dai dati.

## **Aggiungere una linea personalizzata**

Una linea personalizzata è una forma disegnata sopra il grafico piuttosto che una linea di tendenza calcolata dai dati della serie. Questo esempio utilizza [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAutoShape) per aggiungere una linea orizzontale alla diapositiva sopra il grafico. La posizione della linea è specificata in coordinate della diapositiva, misurate in punti, quindi inizia dal bordo sinistro del grafico e si trova a metà altezza del grafico. La sua larghezza corrisponde alla larghezza del grafico. Il [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) conferisce alla linea un colore rosso solido.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);

    const line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

    presentation.save("AddCustomLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Cosa significano 'forward' e 'backward' per una linea di tendenza?**

Sono le lunghezze della linea di tendenza proiettate in avanti/indietro: per i grafici a dispersione (XY) — in unità degli assi; per i grafici non a dispersione — in numero di categorie. Sono consentiti solo valori non negativi.

**La linea di tendenza sarà conservata durante l'esportazione della presentazione in PDF o SVG, o durante il rendering di una diapositiva in immagine?**

Sì. Aspose.Slides converte le presentazioni in [PDF](/slides/it/nodejs-java/convert-powerpoint-to-pdf/) o [SVG](/slides/it/nodejs-java/render-a-slide-as-an-svg-image/) e rende i grafici in immagini; le linee di tendenza, in quanto parte del grafico, sono conservate durante queste operazioni. È disponibile anche un metodo per [export an image of the chart](/slides/it/nodejs-java/create-shape-thumbnails/) stesso.