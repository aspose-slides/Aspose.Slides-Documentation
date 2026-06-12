---
title: Gestisci i marcatori dei dati del grafico nelle presentazioni usando PHP
linktitle: Marcatore dati
type: docs
url: /it/php-java/chart-data-marker/
keywords:
- grafico
- punto dati
- marcatore
- opzioni marcatore
- dimensione marcatore
- tipo riempimento
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Impara a personalizzare i marcatori dei dati del grafico in Aspose.Slides per PHP, migliorando l'impatto della presentazione nei formati PPT e PPTX con esempi di codice chiari."
---
## **Panoramica**

Questo articolo spiega come lavorare con i marcatori dei dati dei grafici in Aspose.Slides. Mostra come creare un grafico, accedere a una serie e ai suoi punti dati, applicare riempimenti immagine ai marcatori a livello di punto dati, regolare la dimensione del marcatore e salvare la presentazione aggiornata. Evidenzia inoltre che le forme di marcatore standard sono disponibili tramite l'enumerazione `MarkerStyleType` e che l'aspetto del marcatore viene conservato durante l'esportazione dei grafici in formati raster o SVG.

## **Imposta opzioni del marcatore del grafico**
I marcatori possono essere impostati sui punti dati del grafico all'interno di serie specifiche. Per impostare le opzioni del marcatore del grafico, segui i passaggi seguenti:

- Instanzia la classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
- Crea il grafico predefinito.
- Imposta l'immagine.
- Preleva la prima serie del grafico.
- Aggiungi un nuovo punto dati.
- Scrivi la presentazione su disco.

Nell'esempio riportato di seguito, abbiamo impostato le opzioni del marcatore del grafico a livello di punti dati.

```php
  # Creazione di una presentazione vuota
  $pres = new Presentation();
  try {
    # Accesso alla prima slide
    $slide = $pres->getSlides()->get_Item(0);
    # Creazione del grafico predefinito
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # Ottenimento dell'indice del foglio di lavoro dei dati del grafico predefinito
    $defaultWorksheetIndex = 0;
    # Ottenimento del foglio di lavoro dei dati del grafico
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Eliminazione della serie demo
    $chart->getChartData()->getSeries()->clear();
    # Aggiunta di una nuova serie
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    # Caricamento dell'immagine 1
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # Caricamento dell'immagine 2
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # Prelievo della prima serie del grafico
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Aggiunta di un nuovo punto (1:3) lì.
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 2.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 3.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 4, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    # Modifica del marcatore della serie del grafico
    $series->getMarker()->setSize(15);
    # Salvataggio della presentazione con il grafico
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Quali forme di marcatore sono disponibili di default?**

Le forme standard sono disponibili (cerchio, quadrato, diamante, triangolo, ecc.); l'elenco è definito dalla classe [MarkerStyleType](https://reference.aspose.com/slides/it/php-java/aspose.slides/markerstyletype/). Se hai bisogno di una forma non standard, utilizza un marcatore con riempimento immagine per emulare elementi visivi personalizzati.

**I marcatori vengono conservati durante l'esportazione di un grafico in un'immagine o SVG?**

Sì. Quando si rendono i grafici in [formati raster](/slides/it/php-java/convert-powerpoint-to-png/) o si salvano [forme come SVG](/slides/it/php-java/render-a-slide-as-an-svg-image/), i marcatori mantengono il loro aspetto e le impostazioni, inclusi dimensione, riempimento e contorno.