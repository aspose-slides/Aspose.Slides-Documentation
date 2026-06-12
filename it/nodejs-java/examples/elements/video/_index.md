---
title: Video
type: docs
weight: 80
url: /it/nodejs-java/examples/elements/video/
keywords:
- esempio di codice
- video
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Aggiungi e controlla i video con Aspose.Slides per Node.js: inserisci, riproduci, taglia, imposta i fotogrammi di copertina e esporta con esempi per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come incorporare fotogrammi video e impostare le opzioni di riproduzione utilizzando **Aspose.Slides for Node.js via Java**.

## **Aggiungi un fotogramma video**

Aggiungi un fotogramma video a una diapositiva.

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Aggiungi un video.
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Accedi a un fotogramma video**

Recupera il primo fotogramma video aggiunto a una diapositiva.

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // Accedi al primo fotogramma video sulla diapositiva.
        let firstVideo = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IVideoFrame")) {
                firstVideo = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovi un fotogramma video**

Elimina un fotogramma video dalla diapositiva.

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Supponi che la prima forma sia il fotogramma video.
        let videoFrame = slide.getShapes().get_Item(0);

        // Rimuovi il fotogramma video.
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Imposta la riproduzione video**

Configura il video affinché venga riprodotto automaticamente quando la diapositiva viene visualizzata.

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Supponi che la prima forma sia il fotogramma video.
        let videoFrame = slide.getShapes().get_Item(0);

        // Configura il video per la riproduzione automatica.
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```