---
title: Aggiungere linee di tendenza ai grafici di presentazione in PHP
linktitle: Linea di tendenza
type: docs
url: /it/php-java/trend-line/
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
- PHP
- Aspose.Slides
description: "Aggiungi e personalizza rapidamente le linee di tendenza nei grafici PowerPoint con Aspose.Slides per PHP tramite Java — una guida pratica per coinvolgere il tuo pubblico."
---
## **Panoramica**

Questo articolo spiega come aggiungere linee di tendenza ai grafici delle presentazioni utilizzando Aspose.Slides. Mostra come creare un grafico, aggiungere linee di tendenza alle serie del grafico e lavorare con diversi tipi di linee di tendenza, inclusi esponenziale, lineare, logaritmica, media mobile, polinomiale e potenza.

Descrive inoltre come aggiungere una linea personalizzata a un grafico inserendo una forma linea e include una breve FAQ sui valori di proiezione in avanti e indietro delle linee di tendenza e sul fatto che le linee di tendenza vengano conservate durante l'esportazione in PDF o SVG e durante il rendering dei grafici come immagini.

## **Aggiungere una linea di tendenza**

Usa [TrendlineCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinecollection/add/) per aggiungere una linea di tendenza a una serie del grafico, selezionandone il tipo con [TrendlineType](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinetype/). L’esempio crea un grafico a colonne raggruppate con dati predefiniti e aggiunge due linee di tendenza a ciascuna delle sue tre serie.

La linea di tendenza esponenziale nasconde la sua equazione e il valore R‑squared tramite [setDisplayEquation](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayequation/) e [setDisplayRSquaredValue](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayrsquaredvalue/), mentre la linea di tendenza lineare è rossa. La linea di tendenza logaritmica utilizza [addTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/addtextframeforoverriding/) per un’etichetta personalizzata. La media mobile utilizza un [setPeriod](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setperiod/) di tre punti dati e un [setTrendlineName](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/settrendlinename/) personalizzato.

La linea di tendenza polinomiale ha un ordine di tre, impostato tramite [setOrder](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setorder/), e si estende di una categoria in avanti tramite [setForward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setforward/). La linea di tendenza potenza si estende di una categoria indietro tramite [setBackward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setbackward/).

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

    $firstSeries = $chart->getChartData()->getSeries()->get_Item(0);

    $exponentialTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Exponential);
    $exponentialTrendline->setDisplayEquation(false);
    $exponentialTrendline->setDisplayRSquaredValue(false);

    $linearTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Linear);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $secondSeries = $chart->getChartData()->getSeries()->get_Item(1);

    $logarithmicTrendline = $secondSeries->getTrendLines()->add(TrendlineType::Logarithmic);
    $logarithmicTrendline->addTextFrameForOverriding("New log trend line");

    $movingAverageTrendline = $secondSeries->getTrendLines()->add(TrendlineType::MovingAverage);
    $movingAverageTrendline->setPeriod(3);
    $movingAverageTrendline->setTrendlineName("New TrendLine Name");

    $thirdSeries = $chart->getChartData()->getSeries()->get_Item(2);

    $polynomialTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Polynomial);
    $polynomialTrendline->setForward(1);
    $polynomialTrendline->setOrder(3);

    $powerTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Power);
    $powerTrendline->setBackward(1);

    $presentation->save("ChartTrendLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Impostare l’intercetta di una linea di tendenza**

Usa [setIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setintercept/) per fissare il valore Y di una linea di tendenza a X = 0. Questa impostazione è supportata per le linee di tendenza lineari, esponenziali e polinomiali.

Ad esempio, un modello di costo di produzione potrebbe dover partire da costi fissi noti di 100, anche quando le misurazioni a volumi di produzione diversi dallo zero suggeriscono una baseline differente. Per una linea di tendenza lineare, fissare l’intercetta vincola l’equazione `y = ax + b` a `b = 100`; la pendenza viene adatta ai dati sotto tale vincolo. Non si tratta semplicemente di spostare una linea già adattata. Le impostazioni di attraversamento degli assi controllano dove gli assi del grafico si incontrano, non i coefficienti della linea di tendenza adattata.

L’esempio seguente crea un grafico a dispersione (XY) con volumi di produzione da 1 a 4 e costi di 170, 200, 230 e 260. Salva il grafico con l’intercetta automatica predefinita, imposta l’intercetta a 100 e salva un secondo PPTX. I due file differiscono solo per l’impostazione dell’intercetta. La linea di tendenza mostra la sua equazione e si estende indietro fino a X = 0.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $nameCell = $workbook->getCell(0, 0, 1, "Production cost");
    $series = $chart->getChartData()->getSeries()->add($nameCell, ChartType::ScatterWithMarkers);
    $costs = [170, 200, 230, 260];

    for ($i = 0; $i < count($costs); $i++) {
        $xCell = $workbook->getCell(0, $i + 1, 0, $i + 1);
        $yCell = $workbook->getCell(0, $i + 1, 1, $costs[$i]);
        $series->getDataPoints()->addDataPointForScatterSeries($xCell, $yCell);
    }

    $trendline = $series->getTrendLines()->add(TrendlineType::Linear);
    $trendline->setDisplayEquation(true);
    $trendline->setBackward(1);

    $presentation->save("AutomaticIntercept.pptx", SaveFormat::Pptx);

    $trendline->setIntercept(100);
    $presentation->save("FixedIntercept.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Con il calcolo automatico, questi dati producono `y = 30x + 140`. Impostare l’intercetta a 100 invece produce approssimativamente `y = 43.33x + 100`: il valore adattato a zero corrisponde alla baseline nota, mentre la linea non passa più per tutti i punti dati.

| Intercetta automatica | Intercetta fissa di 100 |
| --- | --- |
| ![Linea di tendenza lineare con intercetta calcolata automaticamente di 140](intercept-automatic.png) | ![Linea di tendenza lineare con intercetta fissa di 100](intercept-fixed.png) |

Entrambe le immagini usano gli stessi dati e le stesse scale degli assi. Le linee di tendenza sono estese indietro fino a X = 0 per mostrare le loro intercette.

Per impostazione predefinita, [getIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/getintercept/) restituisce `NaN`, che rappresenta un’intercetta non specificata anziché zero. L’intercetta viene quindi calcolata automaticamente dai dati.

## **Aggiungere una linea personalizzata**

Una linea personalizzata è una forma disegnata sopra il grafico piuttosto che una linea di tendenza calcolata dai dati della serie. Questo esempio utilizza [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) per aggiungere una linea orizzontale alla diapositiva sopra il grafico. La posizione della linea è specificata in coordinate della diapositiva, misurate in punti, quindi inizia dal bordo sinistro del grafico e si trova a metà altezza del grafico. La sua larghezza corrisponde alla larghezza del grafico. Il [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getlineformat/) assegna alla linea un colore rosso solido.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

    $lineY = java_values($chart->getY()) + java_values($chart->getHeight()) / 2;
    $line = $slide->getShapes()->addAutoShape(ShapeType::Line, $chart->getX(), $lineY, $chart->getWidth(), 0);
    $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("AddCustomLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Cosa significano “avanti” e “indietro” per una linea di tendenza?**

Sono le lunghezze della linea di tendenza proiettata in avanti/indietro: per i grafici a dispersione (XY) — in unità di asse; per i grafici non a dispersione — in numero di categorie. Sono consentiti solo valori non negativi.

**La linea di tendenza viene conservata quando la presentazione viene esportata in PDF o SVG, o quando una diapositiva viene resa come immagine?**

Sì. Aspose.Slides converte le presentazioni in [PDF](/slides/it/php-java/convert-powerpoint-to-pdf/) o [SVG](/slides/it/php-java/render-a-slide-as-an-svg-image/) e rende i grafici in immagini; le linee di tendenza, in quanto parte del grafico, vengono conservate durante queste operazioni. È inoltre disponibile un metodo per [esportare un’immagine del grafico](/slides/it/php-java/create-shape-thumbnails/) stesso.