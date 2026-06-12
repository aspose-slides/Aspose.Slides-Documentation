---
title: Gestire le serie di dati del grafico nelle presentazioni usando PHP
linktitle: Serie di dati
type: docs
url: /it/php-java/chart-series/
keywords:
- serie di grafico
- sovrapposizione delle serie
- colore della serie
- colore della categoria
- nome della serie
- punto dati
- spazio tra le serie
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come gestire le serie di dati dei grafici in PHP per PowerPoint (PPT/PPTX) con esempi di codice pratici e best practice per migliorare le tue presentazioni dei dati."
---
## **Panoramica**

Questo articolo descrive il ruolo di [ChartSeries](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/) in Aspose.Slides, concentrandosi su come i dati sono strutturati e visualizzati all'interno delle presentazioni. Questi oggetti forniscono gli elementi fondamentali che definiscono set individuali di punti dati, categorie e parametri di aspetto in un grafico. Lavorando con [ChartSeries](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/), gli sviluppatori possono integrare senza problemi le fonti dati sottostanti e mantenere il pieno controllo su come le informazioni vengono visualizzate, producendo presentazioni dinamiche, guidate dai dati, che trasmettono chiaramente intuizioni e analisi.

Una serie è una riga o colonna di numeri tracciata in un grafico.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Imposta la sovrapposizione della serie del grafico**

Con il metodo [getParentSeriesGroup](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/#getParentSeriesGroup) è possibile specificare quanto barre e colonne debbano sovrapporsi in un grafico 2D (intervallo: -100 a 100). Questa proprietà si applica a tutte le serie del gruppo di serie genitore: è una proiezione della proprietà di gruppo appropriata. Pertanto, questa proprietà è di sola lettura.

Utilizza il metodo `ChartSeriesGroup::setOverlap` per impostare il valore desiderato per `Overlap`.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Aggiungi un grafico a colonne raggruppate su una diapositiva.
1. Accedi alla prima serie del grafico.
1. Accedi al `ParentSeriesGroup` della serie del grafico e imposta il valore di sovrapposizione desiderato per la serie. 
1. Scrivi la presentazione modificata in un file PPTX.

Questo codice PHP mostra come impostare la sovrapposizione per una serie del grafico:

```php
  $pres = new Presentation();
  try {
    # Aggiunge il grafico
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # Imposta la sovrapposizione della serie
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # Scrive il file di presentazione su disco
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Modifica il colore della serie**

Aspose.Slides for PHP via Java consente di modificare il colore di una serie in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Aggiungi un grafico sulla diapositiva.
1. Accedi alla serie di cui vuoi cambiare il colore. 
1. Imposta il tipo di riempimento e il colore di riempimento desiderati.
1. Salva la presentazione modificata.

Questo codice PHP mostra come cambiare il colore di una serie:

```php
  $pres = new Presentation("test.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(1);
    $point->setExplosion(30);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Modifica il colore della categoria della serie**

Aspose.Slides for PHP via Java consente di modificare il colore di una categoria di serie in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Aggiungi un grafico sulla diapositiva.
1. Accedi alla categoria della serie di cui vuoi cambiare il colore.
1. Imposta il tipo di riempimento e il colore di riempimento desiderati.
1. Salva la presentazione modificata.

Questo codice mostra come cambiare il colore di una categoria di serie:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Modifica il nome della serie** 

Per impostazione predefinita, i nomi della legenda di un grafico corrispondono al contenuto delle celle sopra ciascuna colonna o riga di dati. 

Nel nostro esempio (immagine di esempio), 

* le colonne sono *Series 1, Series 2,* e *Series 3*;
* le righe sono *Category 1, Category 2, Category 3,* e *Category 4.* 

Aspose.Slides for PHP via Java consente di aggiornare o modificare il nome di una serie nei dati del grafico e nella legenda.

Questo codice PHP mostra come cambiare il nome di una serie nei dati del grafico `ChartDataWorkbook`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("New name");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Questo codice PHP mostra come cambiare il nome di una serie nella legenda tramite `Series`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("New name");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Imposta il colore di riempimento della serie del grafico**

Aspose.Slides for PHP via Java consente di impostare il colore di riempimento automatico per le serie del grafico all'interno dell'area del diagramma in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Ottieni il riferimento di una diapositiva mediante il suo indice.
1. Aggiungi un grafico con dati predefiniti basato sul tipo preferito (nell'esempio seguente, abbiamo usato `ChartType::ClusteredColumn`).
1. Accedi alla serie del grafico e imposta il colore di riempimento su Automatic.
1. Salva la presentazione in un file PPTX.

Questo codice PHP mostra come impostare il colore di riempimento automatico per una serie del grafico:

```php
  $pres = new Presentation();
  try {
    # Crea un grafico a colonne raggruppate
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # Imposta il formato di riempimento della serie su automatico
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # Scrive il file di presentazione su disco
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Imposta il colore di riempimento invertito per una serie del grafico**
Aspose.Slides consente di impostare il colore di riempimento invertito per le serie del grafico all'interno dell'area del diagramma in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Ottieni il riferimento di una diapositiva mediante il suo indice.
1. Aggiungi un grafico con dati predefiniti basato sul tipo preferito (nell'esempio seguente, abbiamo usato `ChartType::ClusteredColumn`).
1. Accedi alla serie del grafico e imposta il colore di riempimento su invertito.
1. Salva la presentazione in un file PPTX.

Questo codice PHP dimostra l'operazione:

```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Aggiunge nuove serie e categorie
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Category 3"));
    # Prende la prima serie del grafico e popola i suoi dati di serie.
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 1, 1, -20));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 3, 1, -30));
    $seriesColor = $series->getAutomaticSeriesColor();
    $series->setInvertIfNegative(true);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColor);
    $series->getInvertedSolidFillColor()->setColor($inverColor);
    $pres->save("SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Imposta una serie per invertire quando il valore è negativo**
Aspose.Slides consente di impostare le inversioni tramite le proprietà `IChartDataPoint.InvertIfNegative` e `ChartDataPoint.InvertIfNegative`. Quando un'inversione è impostata usando le proprietà, il punto dati inverte i suoi colori quando riceve un valore negativo. 

Questo codice PHP dimostra l'operazione:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $chart->getChartData()->getSeries()->clear();
    $chartSeries = $series->add($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1"), $chart->getType());
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B2", -5));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B3", 3));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B4", -2));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B5", 1));
    $chartSeries->setInvertIfNegative(false);
    $chartSeries->getDataPoints()->get_Item(2)->setInvertIfNegative(true);
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Cancella i dati di punto specifici**
Aspose.Slides for PHP via Java consente di cancellare i dati dei `DataPoints` per una serie di grafico specifica in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva tramite il suo indice.
3. Ottieni il riferimento di un grafico tramite il suo indice.
4. Itera tutti i `DataPoints` del grafico e imposta `XValue` e `YValue` a null.
5. Cancella tutti i `DataPoints` per la serie del grafico specifica.
6. Scrivi la presentazione modificata in un file PPTX.

Questo codice PHP dimostra l'operazione:

```php
  $pres = new Presentation("TestChart.pptx");
  try {
    $sl = $pres->getSlides()->get_Item(0);
    $chart = $sl->getShapes()->get_Item(0);
    foreach($chart->getChartData()->getSeries()->get_Item(0)->getDataPoints() as $dataPoint) {
      $dataPoint->getXValue()->getAsCell()->setValue(null);
      $dataPoint->getYValue()->getAsCell()->setValue(null);
    }
    $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->clear();
    $pres->save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Imposta la larghezza del Gap della serie**
Aspose.Slides for PHP via Java consente di impostare la larghezza del Gap di una serie tramite la proprietà **`GapWidth`** in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Accedi alla prima diapositiva.
1. Aggiungi un grafico con dati predefiniti.
1. Accedi a qualsiasi serie del grafico.
1. Imposta la proprietà `GapWidth`.
1. Scrivi la presentazione modificata in un file PPTX.

Questo codice mostra come impostare la larghezza del Gap di una serie:

```php
  # Crea una presentazione vuota
  $pres = new Presentation();
  try {
    # Accede alla prima diapositiva della presentazione
    $slide = $pres->getSlides()->get_Item(0);
    # Aggiunge un grafico con dati predefiniti
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # Imposta l'indice del foglio dati del grafico
    $defaultWorksheetIndex = 0;
    # Ottiene il foglio di lavoro dei dati del grafico
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Aggiunge serie
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Aggiunge categorie
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Prende la seconda serie del grafico
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Popola i dati della serie
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Imposta il valore GapWidth
    $series->getParentSeriesGroup()->setGapWidth(50);
    # Salva la presentazione su disco
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**C'è un limite al numero di serie che un singolo grafico può contenere?**

Aspose.Slides non impone un limite fisso al numero di serie che è possibile aggiungere. Il limite pratico è determinato dalla leggibilità del grafico e dalla memoria disponibile per la tua applicazione.

**E se le colonne all'interno di un cluster sono troppo vicine tra loro o troppo distanti?**

Regola l'impostazione `GapWidth` per quella serie (o per il suo gruppo di serie genitore). Aumentare il valore allarga lo spazio tra le colonne, mentre diminuirlo le avvicina.