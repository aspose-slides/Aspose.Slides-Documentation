---
title: Aggiungere linee di tendenza ai grafici delle presentazioni in Java
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
description: "Aggiungi rapidamente e personalizza le linee di tendenza nei grafici di PowerPoint con Aspose.Slides per Java — una guida pratica per coinvolgere il tuo pubblico."
---
## **Panoramica**

Questo articolo spiega come aggiungere linee di tendenza ai grafici delle presentazioni utilizzando Aspose.Slides. Mostra come creare un grafico, aggiungere linee di tendenza alle serie del grafico e lavorare con diversi tipi di linee di tendenza, inclusi esponenziale, lineare, logaritmica, media mobile, polinomiale e potenza.

Descrive inoltre come aggiungere una linea personalizzata a un grafico inserendo una forma di linea e include una breve sezione FAQ sui valori di proiezione in avanti e indietro delle linee di tendenza e sul fatto se le linee di tendenza vengano conservate durante l'esportazione in PDF o SVG e durante il rendering dei grafici come immagini.

## **Aggiungere una linea di tendenza**

Utilizza [ITrendlineCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/itrendlinecollection/#add-int-) per aggiungere una linea di tendenza a una serie di un grafico, scegliendo il suo tipo con [TrendlineType](https://reference.aspose.com/slides/java/com.aspose.slides/trendlinetype/). L'esempio crea un grafico a colonne raggruppate con dati predefiniti e aggiunge due linee di tendenza a ciascuna delle sue tre serie.

La linea di tendenza esponenziale nasconde la sua equazione e il valore R‑quadrato tramite [setDisplayEquation](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) e [setDisplayRSquaredValue](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-), mentre la linea di tendenza lineare è rossa. La linea di tendenza logaritmica utilizza [addTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) per un'etichetta personalizzata. La media mobile utilizza un [setPeriod](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setPeriod-byte-) di tre punti dati e un [setTrendlineName](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-) personalizzato.

La linea di tendenza polinomiale ha un [setOrder](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setOrder-byte-) di tre e si estende di una categoria in avanti tramite [setForward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setForward-double-). La linea di tendenza di potenza si estende di una categoria all'indietro tramite [setBackward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setBackward-double-).

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

    IChartSeries firstSeries = chart.getChartData().getSeries().get_Item(0);

    ITrendline exponentialTrendline = firstSeries.getTrendLines().add(TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    ITrendline linearTrendline = firstSeries.getTrendLines().add(TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);

    IChartSeries secondSeries = chart.getChartData().getSeries().get_Item(1);

    ITrendline logarithmicTrendline = secondSeries.getTrendLines().add(TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    ITrendline movingAverageTrendline = secondSeries.getTrendLines().add(TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod((byte) 3);
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    IChartSeries thirdSeries = chart.getChartData().getSeries().get_Item(2);

    ITrendline polynomialTrendline = thirdSeries.getTrendLines().add(TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder((byte) 3);

    ITrendline powerTrendline = thirdSeries.getTrendLines().add(TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **Impostare l'intercetta di una linea di tendenza**

Utilizza [setIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#setIntercept-double-) per fissare il valore Y di una linea di tendenza a X = 0. Questa impostazione è supportata per le linee di tendenza lineari, esponenziali e polinomiali.

Ad esempio, un modello di costo di produzione potrebbe dover partire da costi fissi noti di 100, anche quando le misurazioni a volumi di produzione diversi da zero suggeriscono una linea di base diversa. Per una linea di tendenza lineare, fissare l'intercetta vincola l'equazione `y = ax + b` a `b = 100`; la pendenza viene adattata ai dati sotto tale vincolo. Non si tratta semplicemente di spostare una linea già adattata. Le impostazioni di intersezione degli assi controllano dove gli assi del grafico si incontrano, non i coefficienti della linea di tendenza adattata.

Il seguente esempio crea un grafico a dispersione (XY) con volumi di produzione da 1 a 4 e costi di 170, 200, 230 e 260. Salva il grafico con l'intercetta automatica predefinita, imposta l'intercetta a 100 e salva un secondo PPTX. I due file differiscono solo nell'impostazione dell'intercetta. La linea di tendenza mostra la sua equazione e si estende indietro fino a X = 0.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell nameCell = workbook.getCell(0, 0, 1, "Production cost");
    IChartSeries series = chart.getChartData().getSeries().add(nameCell, ChartType.ScatterWithMarkers);
    double[] costs = { 170, 200, 230, 260 };

    for (int i = 0; i < costs.length; i++) {
        IChartDataCell xCell = workbook.getCell(0, i + 1, 0, i + 1);
        IChartDataCell yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    ITrendline trendline = series.getTrendLines().add(TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Con il calcolo automatico, questi dati producono `y = 30x + 140`. Impostare l'intercetta a 100 invece produce approssimativamente `y = 43.33x + 100`: il valore adattato a zero corrisponde alla linea di base nota, mentre la linea non passa più attraverso tutti i punti dati.

| Intercetta automatica | Intercetta fissa di 100 |
| --- | --- |
| ![Linear trend line with an automatically calculated intercept of 140](intercept-automatic.png) | ![Linear trend line with a fixed intercept of 100](intercept-fixed.png) |

Entrambe le immagini utilizzano gli stessi dati e le stesse scale degli assi. Le linee di tendenza sono estese indietro a X = 0 per mostrare le loro intercezioni.

Per impostazione predefinita, [getIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#getIntercept--) restituisce `Double.NaN`, che rappresenta un'intercetta non specificata anziché zero. L'intercetta viene quindi calcolata automaticamente dai dati.

## **Aggiungere una linea personalizzata**

Una linea personalizzata è una forma disegnata sopra il grafico anziché una linea di tendenza calcolata dai dati della serie. Questo esempio utilizza [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) per aggiungere una linea orizzontale alla diapositiva sopra il grafico. La posizione della linea è specificata in coordinate della diapositiva, misurate in punti, quindi inizia dal bordo sinistro del grafico e si trova a metà altezza del grafico. La sua larghezza corrisponde alla larghezza del grafico. Il [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) assegna alla linea un colore rosso pieno.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

    IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Cosa significano 'forward' e 'backward' per una linea di tendenza?**

Sono le lunghezze della linea di tendenza proiettata in avanti/indietro: per i grafici a dispersione (XY) — in unità dell'asse; per i grafici non a dispersione — in numero di categorie. Sono consentiti solo valori non negativi.

**La linea di tendenza verrà conservata durante l'esportazione della presentazione in PDF o SVG, o durante il rendering di una diapositiva in un'immagine?**

Sì. Aspose.Slides converte le presentazioni in [PDF](/slides/it/java/convert-powerpoint-to-pdf/) o [SVG](/slides/it/java/render-a-slide-as-an-svg-image/) e rende i grafici in immagini; le linee di tendenza, come parte del grafico, sono conservate durante queste operazioni. È disponibile anche un metodo per [esportare un'immagine del grafico](/slides/it/java/create-shape-thumbnails/).