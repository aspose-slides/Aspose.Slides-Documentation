---
title: Personalizza i grafici a torta nelle presentazioni usando PHP
linktitle: Grafico a torta
type: docs
url: /it/php-java/pie-chart/
keywords:
- grafico a torta
- gestire grafico
- personalizzare grafico
- opzioni grafico
- impostazioni grafico
- opzioni di tracciamento
- colore della fetta
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come creare e personalizzare i grafici a torta con Aspose.Slides per PHP via Java, esportabili in PowerPoint, potenziando la narrazione dei tuoi dati in pochi secondi."
---
## **Panoramica**

Questo articolo spiega come lavorare con i grafici a torta in Aspose.Slides. Mostra come configurare le opzioni del grafico secondario per i grafici Pie of Pie e Bar of Pie e come abilitare la colorazione automatica delle fette per un grafico a torta standard.

Gli esempi si concentrano su passaggi pratici di personalizzazione dei grafici, come aggiungere un grafico a una diapositiva, regolare le impostazioni delle serie e delle etichette, sostituire i dati predefiniti del grafico con categorie e valori personalizzati e salvare la presentazione aggiornata.

## **Opzioni del secondo grafico per i grafici Pie of Pie e Bar of Pie**
Aspose.Slides per PHP via Java ora supporta le opzioni del grafico secondario per i grafici Pie of Pie o Bar of Pie. In questo argomento, ti mostreremo come specificare tali opzioni usando Aspose.Slides. Per specificare le proprietà, procedi così:

1. Crea un'istanza dell'oggetto classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Aggiungi un grafico alla diapositiva.
1. Specifica le opzioni del secondo grafico.
1. Scrivi la presentazione su disco.

Nell'esempio riportato di seguito, abbiamo impostato diverse proprietà del grafico Pie of Pie.

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation();
  try {
    # Aggiungi un grafico alla diapositiva
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # Imposta diverse proprietà
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # Scrivi la presentazione su disco
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Imposta i colori automatici delle fette del grafico a torta**
Aspose.Slides per PHP via Java fornisce una semplice API per impostare i colori automatici delle fette di un grafico a torta. Il codice di esempio applica le impostazioni sopra descritte.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Accedi alla prima diapositiva.
1. Aggiungi un grafico con dati predefiniti.
1. Imposta il titolo del grafico.
1. Imposta la prima serie per mostrare i valori.
1. Imposta l'indice del foglio dati del grafico.
1. Recupera il foglio di lavoro dei dati del grafico.
1. Elimina le serie e le categorie generate di default.
1. Aggiungi nuove categorie.
1. Aggiungi nuove serie.

Scrivi la presentazione modificata in un file PPTX.

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation();
  try {
    # Aggiungi un grafico con dati predefiniti
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Impostazione del titolo del grafico
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Imposta la prima serie per mostrare i valori
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Impostazione dell'indice del foglio dati del grafico
    $defaultWorksheetIndex = 0;
    # Recupero del foglio di lavoro dei dati del grafico
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Elimina le serie e le categorie generate di default
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Aggiunta di nuove categorie
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Aggiunta di una nuova serie
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Ora popolamento dei dati della serie
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getParentSeriesGroup()->setColorVaried(true);
    $pres->save("Pie.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Le varianti 'Pie of Pie' e 'Bar of Pie' sono supportate?**

Sì, la libreria [supporta](https://reference.aspose.com/slides/it/php-java/aspose.slides/charttype/) un grafico secondario per i grafici a torta, comprese le tipologie 'Pie of Pie' e 'Bar of Pie'.

**Posso esportare solo il grafico come immagine (ad esempio, PNG)?**

Sì, è possibile [esportare il grafico stesso come immagine](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getImage) (ad esempio PNG) senza l'intera presentazione.