---
title: Ottimizzare i calcoli dei grafici per le presentazioni in PHP
linktitle: Calcoli dei grafici
type: docs
weight: 50
url: /it/php-java/chart-calculations/
keywords:
- calcoli dei grafici
- elementi del grafico
- posizione dell'elemento
- posizione reale
- elemento figlio
- elemento genitore
- valori del grafico
- valore reale
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Comprendere i calcoli dei grafici, gli aggiornamenti dei dati e il controllo della precisione in Aspose.Slides for PHP via Java per PPT e PPTX, con esempi pratici di codice."
---
## **Panoramica**

Aspose.Slides fornisce API per lavorare con i calcoli dei grafici e i dati di layout nelle presentazioni. Questo articolo mostra come recuperare i valori reali degli elementi del grafico, includendo la posizione effettiva e le dimensioni degli elementi e i valori effettivi degli assi del grafico. Spiega inoltre che questi valori vengono popolati dopo la convalida del layout del grafico.

Inoltre, l’articolo dimostra come ottenere la posizione effettiva degli elementi genitore del grafico e come nascondere componenti del grafico come il titolo, gli assi, la legenda e le linee della griglia. Insieme, questi esempi ti aiutano a ispezionare le informazioni di layout del grafico e a controllare la visibilità degli elementi del grafico nelle presentazioni PowerPoint in modo programmatico.

## **Calcolare i valori effettivi degli elementi del grafico**
Aspose.Slides for PHP via Java fornisce un’API semplice per ottenere queste proprietà. I metodi della classe [Axis](https://reference.aspose.com/slides/it/php-java/aspose.slides/axis/) forniscono informazioni sulla posizione reale dell’elemento asse del grafico ([getActualMaxValue](https://reference.aspose.com/slides/it/php-java/aspose.slides/axis/getactualmaxvalue/), [getActualMinValue](https://reference.aspose.com/slides/it/php-java/aspose.slides/axis/getactualminvalue/), [getActualMajorUnit](https://reference.aspose.com/slides/it/php-java/aspose.slides/axis/getactualmajorunit/), [getActualMinorUnit](https://reference.aspose.com/slides/it/php-java/aspose.slides/axis/getactualminorunit/), [getActualMajorUnitScale](https://reference.aspose.com/slides/it/php-java/aspose.slides/axis/getactualmajorunitscale/), [getActualMinorUnitScale](https://reference.aspose.com/slides/it/php-java/aspose.slides/axis/getactualminorunitscale/)). È necessario chiamare il metodo [Chart.validateChartLayout](https://reference.aspose.com/slides/it/php-java/aspose.slides/chart/validatechartlayout/) in precedenza per riempire le proprietà con i valori effettivi.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Calcolare la posizione effettiva degli elementi genitore del grafico**
Aspose.Slides for PHP via Java fornisce un’API semplice per ottenere queste proprietà. I metodi della classe `ActualLayout` forniscono informazioni sulla posizione reale dell’elemento genitore del grafico (`getActualX`, `getActualY`, `getActualWidth`, `getActualHeight`). È necessario chiamare il metodo [Chart.validateChartLayout](https://reference.aspose.com/slides/it/php-java/aspose.slides/chart/validatechartlayout/) in precedenza per riempire le proprietà con i valori effettivi.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nascondere gli elementi del grafico**
Questo argomento ti aiuta a capire come nascondere informazioni dal grafico. Utilizzando Aspose.Slides for PHP via Java puoi nascondere **Titolo, Asse verticale, Asse orizzontale** e **Linee della griglia** dal grafico. Il codice di esempio qui sotto mostra come utilizzare queste proprietà.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # Nascondere il titolo del grafico
    $chart->setTitle(false);
    # /Nascondere l'asse dei valori
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # Visibilità dell'asse delle categorie
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # Nascondere la leggenda
    $chart->setLegend(false);
    # Nascondere le linee della griglia principale
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # Impostare il colore della linea della serie
    $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $series->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
    $pres->save("HideInformationFromChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**I file Excel esterni funzionano come fonte dati e come influisce questo sul ricalcolo?**

Sì. Un grafico può fare riferimento a un file Excel esterno: quando connetti o aggiorni la fonte esterna, le formule e i valori vengono prelevati da quel file e il grafico riflette gli aggiornamenti durante le operazioni di apertura/modifica. L’API ti consente di [specificare il file Excel esterno](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdata/setexternalworkbook/) e di gestire i dati collegati.

**Posso calcolare e visualizzare le linee di tendenza senza implementare da solo la regressione?**

Sì. Le [Linee di tendenza](/slides/it/php-java/trend-line/) (lineare, esponenziale e altre) vengono aggiunte e aggiornate da Aspose.Slides; i loro parametri sono ricalcolati automaticamente dai dati della serie, quindi non è necessario implementare i tuoi calcoli.

**Se una presentazione contiene più grafici con collegamenti esterni, posso controllare quale file Excel utilizza ciascun grafico per i valori calcolati?**

Sì. Ogni grafico può puntare al proprio [file Excel esterno](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdata/setexternalworkbook/), oppure puoi creare/sostituire un file Excel esterno per grafico in modo indipendente dagli altri.