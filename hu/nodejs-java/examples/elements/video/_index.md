---
title: Videó
type: docs
weight: 80
url: /hu/nodejs-java/examples/elements/video/
keywords:
- kód példa
- videó
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Videók hozzáadása és vezérlése az Aspose.Slides for Node.js segítségével: beillesztés, lejátszás, vágás, poszterkeretek beállítása, valamint exportálás PPT, PPTX és ODP prezentációkhoz példákkal."
---
Ez a cikk bemutatja, hogyan lehet videókereteket beágyazni és beállítani a lejátszási lehetőségeket a **Aspose.Slides for Node.js via Java** használatával.

## **Videókeret hozzáadása**

Videókeret hozzáadása egy diára.

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Videó hozzáadása.
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Videókeret elérése**

Az első, a diára hozzáadott videókeret lekérdezése.

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // Az első videókeret elérése a dián.
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

## **Videókeret eltávolítása**

Videókeret törlése a diából.

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Feltételezzük, hogy az első alakzat a videókeret.
        let videoFrame = slide.getShapes().get_Item(0);

        // A videókeret eltávolítása.
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Videó lejátszás beállítása**

A videó úgy van beállítva, hogy automatikusan lejátszódjon, amikor a dia megjelenik.

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Feltételezzük, hogy az első alakzat a videókeret.
        let videoFrame = slide.getShapes().get_Item(0);

        // A videó automatikus lejátszásának beállítása.
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```