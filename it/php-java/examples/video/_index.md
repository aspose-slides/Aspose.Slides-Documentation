---
title: Video
type: docs
weight: 80
url: /it/php-java/examples/elements/video/
keywords:
- video
- fotogramma video
- aggiungi video
- accedi al video
- rimuovi video
- riproduzione video
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Lavora con i video in PHP usando Aspose.Slides: inserisci, sostituisci, ritaglia, imposta i fotogrammi poster e le opzioni di riproduzione, ed esporta le presentazioni in PPT, PPTX e ODP."
---
Mostra come incorporare i fotogrammi video e impostare le opzioni di riproduzione utilizzando **Aspose.Slides for PHP via Java**.

## **Aggiungi un Fotogramma Video**

Inserisci un fotogramma video in una diapositiva.

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aggiungi un fotogramma video.
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accedi a un Fotogramma Video**

Recupera il primo fotogramma video aggiunto a una diapositiva.

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accedi al primo fotogramma video sulla diapositiva.
        $firstVideoFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $firstVideoFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Rimuovi un Fotogramma Video**

Elimina un fotogramma video dalla diapositiva.

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assumendo che la prima forma sulla diapositiva sia il fotogramma video.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Rimuovi il fotogramma video.
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Imposta la Riproduzione Video**

Configura il video per riprodursi automaticamente quando la diapositiva viene visualizzata.

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assumendo che la prima forma sulla diapositiva sia il fotogramma video.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Configura il video per la riproduzione automatica.
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```