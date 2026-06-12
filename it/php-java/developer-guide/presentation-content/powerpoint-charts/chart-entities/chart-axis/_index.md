---
title: Personalizza gli assi dei grafici nelle presentazioni usando PHP
linktitle: Asse del grafico
type: docs
url: /it/php-java/chart-axis/
keywords:
- asse del grafico
- asse verticale
- asse orizzontale
- personalizzare l'asse
- manipolare l'asse
- gestire l'asse
- proprietà dell'asse
- valore massimo
- valore minimo
- linea dell'asse
- formato data
- titolo dell'asse
- posizione dell'asse
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come utilizzare Aspose.Slides per PHP tramite Java per personalizzare gli assi dei grafici nelle presentazioni PowerPoint per report e visualizzazioni."
---
## **Panoramica**

Questo articolo spiega come personalizzare gli assi dei grafici in Aspose.Slides. Mostra come ottenere i valori effettivi degli assi, scambiare i dati tra gli assi, nascondere l'asse verticale o orizzontale per i grafici a linee, modificare il tipo di asse di categoria, impostare il formato data per i valori dell'asse di categoria, ruotare il titolo di un asse, impostare la posizione dell'asse e visualizzare un'etichetta di unità sull'asse dei valori.

## **Ottenere i valori massimi sull'asse verticale nei grafici**
Aspose.Slides per PHP tramite Java consente di ottenere i valori minimo e massimo su un asse verticale. Segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Accedi alla prima diapositiva.
1. Aggiungi un grafico con dati predefiniti.
1. Ottieni il valore massimo effettivo sull'asse.
1. Ottieni il valore minimo effettivo sull'asse.
1. Ottieni l'unità principale effettiva dell'asse.
1. Ottieni l'unità secondaria effettiva dell'asse.
1. Ottieni la scala dell'unità principale effettiva dell'asse.
1. Ottieni la scala dell'unità secondaria effettiva dell'asse.

Questo codice di esempio—un'implementazione dei passaggi sopra—mostra come ottenere i valori richiesti :

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
    # Salva la presentazione
    $pres->save("MaxValuesVerticalAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Scambiare i dati tra gli assi**
Aspose.Slides consente di scambiare rapidamente i dati tra gli assi: i dati rappresentati sull'asse verticale (asse y) si spostano sull'asse orizzontale (asse x) e viceversa. 

Questo codice PHP mostra come eseguire lo scambio di dati tra gli assi in un grafico:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # Scambia righe e colonne
    $chart->getChartData()->switchRowColumn();
    # Salva la presentazione
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Disabilitare l'asse verticale per i grafici a linee**

Questo codice PHP mostra come nascondere l'asse verticale per un grafico a linee:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Disabilitare l'asse orizzontale per i grafici a linee**

Questo codice mostra come nascondere l'asse orizzontale per un grafico a linee:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Modificare l'asse di categoria**

Utilizzando la proprietà **CategoryAxisType**, è possibile specificare il tipo di asse di categoria preferito (**date** o **text**). Questo codice dimostra l'operazione:

```php
  $presentation = new Presentation("ExistingChart.pptx");
  try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);
    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Impostare il formato data per i valori dell'asse di categoria**
Aspose.Slides per PHP tramite Java consente di impostare il formato data per un valore dell'asse di categoria. L'operazione è dimostrata in questo codice PHP:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 50, 50, 450, 300);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B2", 1));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B3", 2));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B4", 3));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B5", 4));
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Impostare l'angolo di rotazione per il titolo di un asse del grafico**
Aspose.Slides per PHP tramite Java consente di impostare l'angolo di rotazione per il titolo di un asse del grafico. Questo codice PHP dimostra l'operazione:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Impostare la posizione dell'asse su un asse di categoria o di valore**
Aspose.Slides per PHP tramite Java consente di impostare la posizione dell'asse in un asse di categoria o di valore. Questo codice PHP mostra come eseguire l'operazione:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Abilitare la visualizzazione dell'etichetta di unità sull'asse dei valori del grafico**
Aspose.Slides per PHP tramite Java consente di configurare un grafico per mostrare un'etichetta di unità sul suo asse dei valori. Questo codice PHP dimostra l'operazione:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Come posso impostare il valore al quale un asse incrocia l'altro (incrocio degli assi)?**

Gli assi offrono una [impostazione di incrocio](https://reference.aspose.com/slides/it/php-java/aspose.slides/axis/setcrosstype/): è possibile scegliere di incrociare a zero, al valore massimo di categoria/valore o a un valore numerico specifico. Questo è utile per spostare l'asse X verso l'alto o verso il basso o per evidenziare una linea di base.

**Come posso posizionare le etichette dei tick rispetto all'asse (accanto, all'esterno, all'interno)?**

Imposta la [posizione dell'etichetta](https://reference.aspose.com/slides/it/php-java/aspose.slides/axis/setmajortickmark/) su "cross", "outside" o "inside". Questo influisce sulla leggibilità e aiuta a risparmiare spazio, soprattutto su grafici di piccole dimensioni.