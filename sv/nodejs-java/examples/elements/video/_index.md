---
title: Video
type: docs
weight: 80
url: /sv/nodejs-java/examples/elements/video/
keywords:
- kodexempel
- video
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lägg till och kontrollera videor med Aspose.Slides för Node.js: infoga, spela upp, trimma, ange postervisningsramar och exportera med exempel för PPT-, PPTX- och ODP-presentationer."
---
Denna artikel visar hur man bäddar in videoramar och ställer in uppspelningsalternativ med **Aspose.Slides for Node.js via Java**.

## **Lägg till en videoram**

Lägg till en videoram på en bild.

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Lägg till en video.
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Åtkomst till en videoram**

Hämta den första videoramen som lagts till på en bild.

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // Åtkomst till den första videoramen på bilden.
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

## **Ta bort en videoram**

Ta bort en videoram från bilden.

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Anta att den första formen är videoramen.
        let videoFrame = slide.getShapes().get_Item(0);

        // Ta bort videoramen.
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Ställ in videouppspelning**

Konfigurera videon så att den spelas upp automatiskt när bilden visas.

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Anta att den första formen är videoramen.
        let videoFrame = slide.getShapes().get_Item(0);

        // Konfigurera videon så att den spelas upp automatiskt.
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```