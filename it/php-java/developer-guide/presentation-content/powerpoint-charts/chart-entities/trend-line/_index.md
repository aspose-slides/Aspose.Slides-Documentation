---
title: Aggiungere linee di tendenza ai grafici delle presentazioni in PHP
linktitle: Linea di tendenza
type: docs
url: /it/php-java/trend-line/
keywords:
- grafico
- linea di tendenza
- linea di tendenza esponenziale
- linea di tendenza lineare
- linea di tendenza logaritmica
- linea di tendenza della media mobile
- linea di tendenza polinomiale
- linea di tendenza di potenza
- linea di tendenza personalizzata
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Aggiungi e personalizza rapidamente le linee di tendenza nei grafici PowerPoint con Aspose.Slides per PHP via Java — una guida pratica per coinvolgere il tuo pubblico."
---
## **Panoramica**

Questo articolo spiega come aggiungere linee di tendenza ai grafici delle presentazioni utilizzando Aspose.Slides. Mostra come creare un grafico, aggiungere linee di tendenza alle serie del grafico e lavorare con diversi tipi di linee di tendenza, inclusi esponenziali, lineari, logaritmici, medie mobili, polinomiali e di potenza.

Descrive inoltre come aggiungere una linea personalizzata a un grafico inserendo una forma linea, e include una breve FAQ sui valori di proiezione della linea di tendenza in avanti e indietro e se le linee di tendenza vengono conservate durante l'esportazione in PDF o SVG e durante il rendering dei grafici come immagini.

## **Aggiungere una linea di tendenza**
Aspose.Slides per PHP via Java fornisce un'API semplice per gestire diverse linee di tendenza dei grafici:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
2. Ottieni un riferimento a una diapositiva tramite il suo indice.
3. Aggiungi un grafico con dati predefiniti insieme a uno qualsiasi dei tipi desiderati (questo esempio utilizza ChartType::ClusteredColumn).
4. Aggiunta della linea di tendenza esponenziale per la serie 1 del grafico.
5. Aggiunta della linea di tendenza lineare per la serie 1 del grafico.
6. Aggiunta della linea di tendenza logaritmica per la serie 2 del grafico.
7. Aggiunta della linea di tendenza della media mobile per la serie 2 del grafico.
8. Aggiunta della linea di tendenza polinomiale per la serie 3 del grafico.
9. Aggiunta della linea di tendenza di potenza per la serie 3 del grafico.
10. Scrivi la presentazione modificata in un file PPTX.

Il codice seguente è utilizzato per creare un grafico con linee di tendenza.

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation();
  try {
    # Creazione di un grafico a colonne raggruppate
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # Aggiunta della linea di tendenza esponenziale per la serie 1 del grafico
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # Aggiunta della linea di tendenza lineare per la serie 1 del grafico
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Aggiunta della linea di tendenza logaritmica per la serie 2 del grafico
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("New log trend line");
    # Aggiunta della linea di tendenza della media mobile per la serie 2 del grafico
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("New TrendLine Name");
    # Aggiunta della linea di tendenza polinomiale per la serie 3 del grafico
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # Aggiunta della linea di tendenza di potenza per la serie 3 del grafico
    $tredLinePower = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Power);
    $tredLinePower->setTrendlineType(TrendlineType::Power);
    $tredLinePower->setBackward(1);
    # Salvataggio della presentazione
    $pres->save("ChartTrendLines_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aggiungere una linea personalizzata**
Aspose.Slides per PHP via Java fornisce un'API semplice per aggiungere linee personalizzate in un grafico. Per aggiungere una semplice linea piana a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation)
- Ottieni il riferimento di una diapositiva utilizzando il suo indice
- Crea un nuovo grafico usando il metodo AddChart esposto dall'oggetto Shapes
- Aggiungi un AutoShape di tipo Linea usando il metodo AddAutoShape esposto dall'oggetto Shapes
- Imposta il colore delle linee della forma.
- Scrivi la presentazione modificata come file PPTX

Il codice seguente è utilizzato per creare un grafico con linee personalizzate.

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $shape = $chart->getUserShapes()->getShapes()->addAutoShape(ShapeType::Line, 0, $chart->getHeight() / 2, $chart->getWidth(), 0);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("Presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Cosa significano 'forward' e 'backward' per una linea di tendenza?**

Sono le lunghezze della linea di tendenza proiettata in avanti/indietro: per i grafici a dispersione (XY) — in unità dell'asse; per i grafici non a dispersione — in numero di categorie. Sono ammessi solo valori non negativi.

**La linea di tendenza verrà conservata durante l'esportazione della presentazione in PDF o SVG, o durante il rendering di una diapositiva in un'immagine?**

Sì. Aspose.Slides converte le presentazioni in [PDF](/slides/it/php-java/convert-powerpoint-to-pdf/)/[SVG](/slides/it/php-java/render-a-slide-as-an-svg-image/) e rende i grafici in immagini; le linee di tendenza, come parte del grafico, vengono conservate durante queste operazioni. È disponibile anche un metodo per [esportare un'immagine del grafico](/slides/it/php-java/create-shape-thumbnails/).