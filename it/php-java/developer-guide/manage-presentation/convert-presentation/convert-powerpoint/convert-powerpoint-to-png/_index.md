---
title: Converti le diapositive PowerPoint in PNG in PHP
linktitle: PowerPoint in PNG
type: docs
weight: 30
url: /it/php-java/convert-powerpoint-to-png/
keywords:
- convertire PowerPoint
- convertire presentazione
- convertire diapositiva
- convertire PPT
- convertire PPTX
- PowerPoint in PNG
- presentazione in PNG
- diapositiva in PNG
- PPT in PNG
- PPTX in PNG
- salvare PPT come PNG
- salvare PPTX come PNG
- esportare PPT in PNG
- esportare PPTX in PNG
- PHP
- Aspose.Slides
description: "Converti le presentazioni PowerPoint in immagini PNG di alta qualità velocemente con Aspose.Slides per PHP tramite Java, garantendo risultati precisi e automatizzati."
---
## **Panoramica**

Questo articolo spiega come convertire le presentazioni PowerPoint in immagini PNG utilizzando Aspose.Slides. Mostra come caricare file di presentazione in formati come PPT, PPTX e ODP, renderizzare le diapositive come immagini e salvare i risultati in formato PNG.

L'articolo dimostra anche come personalizzare le immagini PNG generate impostando valori di scala o specificando la larghezza e l'altezza desiderate.

## **Convertire PowerPoint in PNG**

Segui questi passaggi:

1. Istanzia la classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni l'oggetto diapositiva dalla collezione [Presentation.getSlides()](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getSlides) della classe [Slide](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/).
3. Usa il metodo [Slide.getImage()](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#getImage) per ottenere la miniatura di ciascuna diapositiva.
4. Usa il metodo [IImage.save(String formatName, int imageFormat)](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/#save) per salvare la miniatura della diapositiva in formato PNG.

Questo codice PHP mostra come convertire una presentazione PowerPoint in PNG:

```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage();
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convertire PowerPoint in PNG con dimensioni personalizzate**

Se desideri ottenere file PNG con una certa scala, puoi impostare i valori per `desiredX` e `desiredY`, che determinano le dimensioni della miniatura risultante.

Questo codice dimostra l'operazione descritta:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $scaleX = 2.0;
    $scaleY = 2.0;
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($scaleX, $scaleY);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convertire PowerPoint in PNG con dimensione personalizzata**

Se desideri ottenere file PNG con una certa dimensione, puoi passare i parametri `width` e `height` preferiti per `ImageSize`.

Questo codice mostra come convertire un PowerPoint in PNG specificando la dimensione delle immagini:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $size = new Java("java.awt.Dimension", 960, 720);
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($size);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Come posso esportare solo una forma specifica (ad esempio, un grafico o un'immagine) anziché l'intera diapositiva?**

Aspose.Slides supporta [generating thumbnails for individual shapes](/slides/it/php-java/create-shape-thumbnails/); è possibile renderizzare una forma in un'immagine PNG.

**La conversione parallela è supportata su un server?**

Sì, ma [don’t share](/slides/it/php-java/multithreading/) una singola istanza di presentazione tra i thread. Usa un'istanza separata per thread o processo.

**Quali sono le limitazioni della versione di prova quando si esporta in PNG?**

La modalità di valutazione aggiunge una filigrana alle immagini di output e applica [other restrictions](/slides/it/php-java/licensing/) finché non viene applicata una licenza.