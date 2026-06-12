---
title: Video
type: docs
weight: 80
url: /nl/nodejs-java/examples/elements/video/
keywords:
- codevoorbeeld
- video
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Video's toevoegen en beheren met Aspose.Slides voor Node.js: invoegen, afspelen, bijsnijden, poster-frames instellen en exporteren met voorbeelden voor PPT-, PPTX- en ODP-presentaties."
---
Dit artikel laat zien hoe u videoframes kunt insluiten en afspeelopties kunt instellen met behulp van **Aspose.Slides for Node.js via Java**.

## **Voeg een videoframe toe**

Voeg een videoframe toe aan een dia.

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Voeg een video toe.
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Toegang tot een videoframe**

Haal het eerste videoframe op dat aan een dia is toegevoegd.

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // Toegang tot het eerste videoframe op de dia.
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

## **Verwijder een videoframe**

Verwijder een videoframe van de dia.

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Neem aan dat de eerste vorm het videoframe is.
        let videoFrame = slide.getShapes().get_Item(0);

        // Verwijder het videoframe.
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Stel video afspelen in**

Configureer de video om automatisch af te spelen wanneer de dia wordt weergegeven.

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Neem aan dat de eerste vorm het videoframe is.
        let videoFrame = slide.getShapes().get_Item(0);

        // Stel in dat de video automatisch afspeelt.
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```