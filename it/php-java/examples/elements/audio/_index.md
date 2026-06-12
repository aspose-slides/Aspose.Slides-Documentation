---
title: Audio
type: docs
weight: 70
url: /it/php-java/examples/elements/audio/
keywords:
- audio
- fotogramma audio
- aggiungi audio
- accedi all'audio
- rimuovi audio
- riproduzione audio
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Lavora con l'audio in PHP usando Aspose.Slides: aggiungi, sostituisci, estrai e ritaglia suoni, imposta volume e riproduzione per diapositive e forme in PowerPoint e OpenDocument."
---
Illustra come incorporare fotogrammi audio e controllare la riproduzione con **Aspose.Slides for PHP via Java**. I seguenti esempi mostrano operazioni audio di base.

## **Aggiungi un fotogramma audio**

Inserisci un fotogramma audio.

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Crea un fotogramma audio.
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accedi a un fotogramma audio**

Questo codice recupera il primo fotogramma audio in una diapositiva.

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accedi al primo fotogramma audio nella diapositiva.
        $firstAudioFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
                $firstAudioFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Rimuovi un fotogramma audio**

Elimina un fotogramma audio precedentemente aggiunto.

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Supponendo che la prima forma nella diapositiva sia un fotogramma audio.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Rimuovi il fotogramma audio.
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Imposta la riproduzione audio**

Configura il fotogramma audio per riprodursi automaticamente quando la diapositiva appare.

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assumendo che la prima forma nella diapositiva sia un fotogramma audio.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Riproduci automaticamente quando la diapositiva appare.
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```