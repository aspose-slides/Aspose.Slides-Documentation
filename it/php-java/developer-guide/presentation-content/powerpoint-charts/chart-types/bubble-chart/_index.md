---
title: Personalizza i grafici a bolle nelle presentazioni usando PHP
linktitle: Grafico a bolle
type: docs
url: /it/php-java/bubble-chart/
keywords:
- grafico a bolle
- dimensione della bolla
- scalatura della dimensione
- rappresentazione della dimensione
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Crea e personalizza potenti grafici a bolle in PowerPoint con Aspose.Slides per PHP via Java per migliorare facilmente la visualizzazione dei dati."
---
## **Panoramica**

Questo articolo mostra come utilizzare i grafici a bolle in Aspose.Slides. Copre due specifiche opzioni di personalizzazione: la scala delle dimensioni delle bolle tramite il metodo `setBubbleSizeScale` e il controllo di come i valori di dimensione delle bolle sono rappresentati tramite il metodo `setBubbleSizeRepresentation`.

Gli esempi dimostrano come creare un grafico a bolle, regolare la scala delle dimensioni e passare alla rappresentazione della dimensione delle bolle usando la larghezza. L'articolo include anche una breve sezione FAQ che chiarisce il supporto per il tipo di grafico “Bubble with 3-D”, osserva che i limiti pratici del grafico dipendono dalle prestazioni e dalla versione di PowerPoint di destinazione, e spiega che l'esportazione preserva l'aspetto del grafico tramite il motore di rendering di Aspose.Slides.

## **Scala delle dimensioni del grafico a bolle**
Aspose.Slides per PHP via Java offre supporto per la scala delle dimensioni del grafico a bolle. In Aspose.Slides per PHP via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/getbubblesizescale/), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/) e [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/) sono stati aggiunti i metodi. Di seguito è riportato un esempio.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 100, 100, 400, 300);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);
    $pres->save("Result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Rappresentare i dati come dimensioni del grafico a bolle**
I metodi [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) e [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/) sono stati aggiunti alle classi [ChartSeries](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseries/), [ChartSeriesGroup](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartseriesgroup/) e alle classi correlate. **BubbleSizeRepresentation** specifica come i valori di dimensione delle bolle sono rappresentati nel grafico a bolle. I valori possibili sono: [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/it/php-java/aspose.slides/BubbleSizeRepresentationType#Area) e [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/it/php-java/aspose.slides/BubbleSizeRepresentationType#Width). Di conseguenza, l'enumerazione [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/it/php-java/aspose.slides/BubbleSizeRepresentationType) è stata aggiunta per specificare i modi possibili di rappresentare i dati come dimensioni del grafico a bolle. Il codice di esempio è fornito di seguito.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(BubbleSizeRepresentationType::Width);
    $pres->save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**È supportato un “grafico a bolle con effetto 3‑D” e in che cosa differisce da quello standard?**

Sì. Esiste un tipo di grafico separato, “Bubble with 3-D”. Applica uno stile 3‑D alle bolle ma non aggiunge un asse aggiuntivo; i dati rimangono X‑Y‑S (dimensione). Il tipo è disponibile nella classe [chart type](https://reference.aspose.com/slides/it/php-java/aspose.slides/charttype/).

**Esiste un limite al numero di serie e di punti in un grafico a bolle?**

Non c'è un limite rigido a livello di API; le restrizioni sono determinate da prestazioni e dalla versione di PowerPoint di destinazione. Si consiglia di mantenere un numero ragionevole di punti per garantire leggibilità e velocità di rendering.

**In che modo l'esportazione influisce sull'aspetto di un grafico a bolle (PDF, immagini)?**

L'esportazione nei formati supportati preserva l'aspetto del grafico; il rendering è effettuato dal motore Aspose.Slides. Per i formati raster/vettoriali, si applicano le regole generali di rendering dei grafici (risoluzione, antialiasing), quindi è opportuno scegliere un DPI sufficiente per la stampa.