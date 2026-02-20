---
title: Audio
type: docs
weight: 70
url: /es/php-java/examples/elements/audio/
keywords:
- audio
- marco de audio
- añadir audio
- acceder al audio
- eliminar audio
- reproducción de audio
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Trabaje con audio en PHP usando Aspose.Slides: añada, reemplace, extraiga y recorte sonidos, establezca el volumen y la reproducción para diapositivas y formas en PowerPoint y OpenDocument."
---
Ilustra cómo incrustar marcos de audio y controlar la reproducción con **Aspose.Slides for PHP via Java**. Los siguientes ejemplos muestran operaciones básicas de audio.

## **Añadir un marco de audio**

Inserte un marco de audio.

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Crear un marco de audio.
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Acceder a un marco de audio**

Este código recupera el primer marco de audio en una diapositiva.

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acceder al primer marco de audio en la diapositiva.
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

## **Eliminar un marco de audio**

Elimine un marco de audio añadido previamente.

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Suponiendo que la primera forma en la diapositiva es un marco de audio.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Eliminar el marco de audio.
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Configurar la reproducción de audio**

Configure el marco de audio para que se reproduzca automáticamente cuando aparezca la diapositiva.

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Suponiendo que la primera forma en la diapositiva es un marco de audio.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Reproducir automáticamente cuando aparezca la diapositiva.
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```