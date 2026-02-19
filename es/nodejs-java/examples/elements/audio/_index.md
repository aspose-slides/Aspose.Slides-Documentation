---
title: Audio
type: docs
weight: 70
url: /es/nodejs-java/examples/elements/audio/
keywords:
- ejemplo de código
- audio
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Descubra los ejemplos de audio de Aspose.Slides para Node.js: inserte, reproduzca, recorte y extraiga sonido en presentaciones PPT, PPTX y ODP con código JavaScript claro."
---
Este artículo muestra cómo incrustar marcos de audio y controlar la reproducción con **Aspose.Slides for Node.js via Java**. Los siguientes ejemplos muestran operaciones básicas de audio.

## **Añadir un marco de audio**

El ejemplo de código a continuación añade un marco de audio en una diapositiva de la presentación.

```js
function addAudio() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let audioData = java.newInstanceSync(
            "java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));

        let audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioData);

        presentation.save("audio.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Acceder a un marco de audio**

Este código recupera el primer marco de audio de una diapositiva.

```js
function accessAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Acceder al primer marco de audio en la diapositiva.
        let firstAudio = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAudioFrame")) {
                firstAudio = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar un marco de audio**

Elimina un marco de audio añadido previamente.

```js
function removeAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Suponer que la primera forma es el marco de audio.
        let audioFrame = slide.getShapes().get_Item(0);

        // Eliminar el marco de audio.
        slide.getShapes().remove(audioFrame);

        presentation.save("audio_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Establecer la reproducción de audio**

Configura el marco de audio para que se reproduzca automáticamente cuando aparezca la diapositiva.

```js
function setAudioPlayback() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Suponer que la primera forma es un marco de audio.
        let audioFrame = slide.getShapes().get_Item(0);

        // Reproducir automáticamente cuando aparezca la diapositiva.
        audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);

        presentation.save("audio_playback.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```