---
title: Personalizza i grafici a ciambella nelle presentazioni usando PHP
linktitle: Grafico a ciambella
type: docs
weight: 30
url: /it/php-java/doughnut-chart/
keywords:
- grafico a ciambella
- spazio centrale
- dimensione del foro
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come creare e personalizzare grafici a ciambella in Aspose.Slides per PHP tramite Java, supportando i formati PowerPoint per presentazioni dinamiche."
---
## **Panoramica**

Questo articolo mostra come lavorare con un grafico a ciambella in Aspose.Slides aggiungendo il grafico a una diapositiva, impostando la dimensione del suo foro centrale e salvando la presentazione. Si concentra sul metodo `setDoughnutHoleSize` e dimostra i passaggi di base necessari per personalizzare questo tipo di grafico nel codice.

Include anche una breve FAQ che copre scenari correlati ai grafici a ciambella, come l'uso di più serie per creare più anelli, lavorare con grafici a ciambella esplosi e esportare un grafico come immagine raster o SVG.

## **Specificare lo spazio centrale in un grafico a ciambella**

Per specificare la dimensione del foro in un grafico a ciambella, segui i passaggi seguenti:

1. Istanziare l'oggetto [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
1. Aggiungere un grafico a ciambella sulla diapositiva.
1. Specificare la dimensione del foro nel grafico a ciambella.
1. Scrivere la presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo impostato la dimensione del foro nel grafico a ciambella.

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # Scrivi la presentazione su disco
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Posso creare una ciambella a più livelli con più anelli?**

Sì. Aggiungi più serie a un unico grafico a ciambella—ogni serie diventa un anello separato. L'ordine degli anelli è determinato dall'ordine delle serie nella collezione.

**È supportata una ciambella "esplosa" (fette separate)?**

Sì. Esiste un tipo di grafico Exploded Doughnut [chart type](https://reference.aspose.com/slides/it/php-java/aspose.slides/charttype/) e una proprietà di esplosione sui punti dati; puoi separare le singole fette.

**Come posso ottenere un'immagine di un grafico a ciambella (PNG/SVG) per un report?**

Un grafico è una forma; puoi renderizzarlo a un [raster image](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getImage) o esportare il grafico a un [SVG image](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#writeAsSvg).