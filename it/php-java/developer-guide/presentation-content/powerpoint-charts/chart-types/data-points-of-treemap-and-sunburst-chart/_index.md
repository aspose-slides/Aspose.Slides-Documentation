---
title: Personalizza i punti dati nei grafici Treemap e Sunburst usando PHP
linktitle: Punti dati nei grafici Treemap e Sunburst
type: docs
url: /it/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- grafico treemap
- grafico sunburst
- punto dati
- colore etichetta
- colore ramo
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come gestire i punti dati nei grafici treemap e sunburst con Aspose.Slides per PHP via Java, compatibile con i formati PowerPoint."
---
## **Introduzione**

Tra gli altri tipi di grafici PowerPoint, esistono due tipi "gerarchici" – **Treemap** e **Sunburst** (chart anche noti come Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph o Multi Level Pie Chart). Questi grafici visualizzano dati gerarchici organizzati come un albero – dalle foglie alla cima del ramo. Le foglie sono definite dai punti dati della serie, e ogni livello di raggruppamento nidificato successivo è definito dalla categoria corrispondente. Aspose.Slides for PHP via Java consente di formattare i punti dati di Sunburst Chart e Treemap .

Ecco un grafico Sunburst, in cui i dati nella colonna Series1 definiscono i nodi foglia, mentre le altre colonne definiscono i punti dati gerarchici:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Cominciamo aggiungendo un nuovo grafico Sunburst alla presentazione:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="Vedi anche" %}} 
- [**Crea o Aggiorna Grafici di Presentazioni PowerPoint in PHP**](/slides/it/php-java/create-chart/)
{{% /alert %}}

Se è necessario formattare i punti dati del grafico, occorre utilizzare quanto segue:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapointlevelsmanager/), 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapointlevel/) classi 
e [**ChartDataPoint::getDataPointLevels**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) metodo 
forniscono l'accesso per formattare i punti dati di grafici Treemap e Sunburst. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapointlevelsmanager/)
viene utilizzato per accedere alle categorie multLivello – rappresenta il contenitore di 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapointlevel/) oggetti.
In pratica è un wrapper per 
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartcategorylevelsmanager/) con
le proprietà aggiunte specifiche per i punti dati. 
La classe [**ChartDataPointLevel**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapointlevel/) ha
due metodi: [**getFormat**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapointlevel/#getFormat) e 
[**getDataLabel**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdatapointlevel/#getLabel) che
forniscono l'accesso alle impostazioni corrispondenti.

## **Mostra il valore del punto dati**

Mostra il valore del punto dati "Leaf 4":

```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);

```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Imposta l'etichetta e il colore del punto dati**

Imposta l'etichetta del dato "Branch 1" per visualizzare il nome della serie ("Series1") invece del nome della categoria. Quindi imposta il colore del testo su giallo:

```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Imposta il colore del ramo del punto dati**

Cambia il colore del ramo "Steam 4":

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
    $stem4branch = $dataPoints->get_Item(9)->getDataPointLevels()->get_Item(1);
    $stem4branch->getFormat()->getFill()->setFillType(FillType::Solid);
    $stem4branch->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Posso modificare l'ordine (ordinamento) dei segmenti in Sunburst/Treemap?**

No. PowerPoint ordina i segmenti automaticamente (tipicamente per valori decrescenti, in senso orario). Aspose.Slides replica questo comportamento: non è possibile modificare direttamente l'ordine; è necessario farlo preelaborando i dati.

**Come influisce il tema della presentazione sui colori dei segmenti e delle etichette?**

I colori del grafico ereditano il [tema/palette](/slides/it/php-java/presentation-theme/) della presentazione, salvo che non vengano impostati esplicitamente riempimenti/font. Per risultati coerenti, fissare riempimenti solidi e la formattazione del testo nei livelli richiesti.

**L'esportazione in PDF/PNG conserverà i colori personalizzati dei rami e le impostazioni delle etichette?**

Sì. Durante l'esportazione della presentazione, le impostazioni del grafico (riempimenti, etichette) vengono conservate nei formati di output perché Aspose.Slides rende il grafico con la formattazione applicata.

**Posso calcolare le coordinate effettive di un'etichetta/elemento per posizionare un overlay personalizzato sopra il grafico?**

Sì. Dopo che il layout del grafico è stato convalidato, le coordinate *x* e *y* effettive sono disponibili per gli elementi (ad esempio, un [DataLabel](https://reference.aspose.com/slides/it/php-java/aspose.slides/datalabel/)), il che facilita il posizionamento preciso degli overlay.