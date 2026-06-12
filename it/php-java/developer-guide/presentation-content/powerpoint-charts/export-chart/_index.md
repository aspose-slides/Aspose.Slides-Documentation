---
title: Esporta i grafici della presentazione in PHP
linktitle: Esporta grafico
type: docs
weight: 90
url: /it/php-java/export-chart/
keywords:
- grafico
- grafico in immagine
- grafico come immagine
- estrarre immagine del grafico
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come esportare i grafici delle presentazioni con Aspose.Slides per PHP via Java, supportando i formati PPT e PPTX, e ottimizza la generazione di report in qualsiasi flusso di lavoro."
---
## **Panoramica**

Aspose.Slides consente di esportare un grafico da una presentazione come immagine. Questo articolo mostra come ottenere un'immagine da un grafico e salvarla, utile quando è necessario riutilizzare i visual del grafico al di fuori di una presentazione PowerPoint.

## **Ottenere un'immagine del grafico**
Aspose.Slides per PHP via Java offre il supporto per l'estrazione dell’immagine di un grafico specifico. Di seguito è riportato un esempio.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Posso esportare un grafico come vettore (SVG) anziché come immagine raster?**

Sì. Un grafico è una forma e il suo contenuto può essere salvato in SVG usando il metodo di salvataggio [shape-to-SVG saving method](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/writeassvg/).

**Come posso impostare le dimensioni esatte del grafico esportato in pixel?**

Usa le sovraccariche di rendering dell’immagine che consentono di specificare dimensioni o scala – la libreria supporta il rendering di oggetti con dimensioni/scala specificate.

**Cosa devo fare se i caratteri nelle etichette e nella legenda appaiono errati dopo l’esportazione?**

[Carica i caratteri necessari](/slides/it/php-java/custom-font/) tramite [FontsLoader](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsloader/) in modo che il rendering del grafico mantenga metriche e aspetto del testo.

**L’esportazione rispetta il tema, gli stili e gli effetti di PowerPoint?**

Sì. Il renderer di Aspose.Slides segue la formattazione della presentazione (temi, stili, riempimenti, effetti), quindi l’aspetto del grafico viene mantenuto.

**Dove posso trovare le capacità di rendering/esportazione disponibili oltre alle immagini dei grafici?**

Vedi l'[API](https://reference.aspose.com/slides/it/php-java/aspose.slides/)/[documentazione](/slides/it/php-java/convert-powerpoint/) per le destinazioni di output ([PDF](/slides/it/php-java/convert-powerpoint-to-pdf/), [SVG](/slides/it/php-java/render-a-slide-as-an-svg-image/), [XPS](/slides/it/php-java/convert-powerpoint-to-xps/), [HTML](/slides/it/php-java/convert-powerpoint-to-html/), ecc.) e le relative opzioni di rendering.