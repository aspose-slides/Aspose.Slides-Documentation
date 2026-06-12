---
title: Audio
type: docs
weight: 70
url: /it/nodejs-java/examples/elements/audio/
keywords:
- esempio di codice
- audio
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri gli esempi audio di Aspose.Slides per Node.js: inserimento, riproduzione, ritaglio ed estrazione del suono in presentazioni PPT, PPTX e ODP con codice JavaScript chiaro."
---
Questo articolo dimostra come incorporare i fotogrammi audio e controllare la riproduzione con **Aspose.Slides for Node.js via Java**. Gli esempi seguenti mostrano le operazioni audio di base.

## **Aggiungere un fotogramma audio**

L'esempio di codice seguente aggiunge un fotogramma audio su una diapositiva della presentazione.

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

## **Accedere a un fotogramma audio**

Questo codice recupera il primo fotogramma audio su una diapositiva.

```js
function accessAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Accedi al primo fotogramma audio nella diapositiva.
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

## **Rimuovere un fotogramma audio**

Elimina un fotogramma audio precedentemente aggiunto.

```js
function removeAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Assumi che la prima forma sia il fotogramma audio.
        let audioFrame = slide.getShapes().get_Item(0);

        // Rimuovi il fotogramma audio.
        slide.getShapes().remove(audioFrame);

        presentation.save("audio_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Impostare la riproduzione audio**

Configura il fotogramma audio affinché venga riprodotto automaticamente quando appare la diapositiva.

```js
function setAudioPlayback() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Assumi che la prima forma sia un fotogramma audio.
        let audioFrame = slide.getShapes().get_Item(0);

        // Riproduci automaticamente quando la diapositiva appare.
        audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);

        presentation.save("audio_playback.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```