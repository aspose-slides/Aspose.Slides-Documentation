---
title: Video
type: docs
weight: 80
url: /de/nodejs-java/examples/elements/video/
keywords:
- Codebeispiel
- Video
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Videos mit Aspose.Slides für Node.js hinzufügen und steuern: Einfügen, Abspielen, Trimmen, Poster-Frames festlegen und mit Beispielen für PPT-, PPTX- und ODP-Präsentationen exportieren."
---
Dieser Artikel zeigt, wie man Video-Frames einbettet und Wiedergabeoptionen festlegt, indem man **Aspose.Slides for Node.js via Java** verwendet.

## **Video-Frame hinzufügen**
Fügen Sie einer Folie ein Video-Frame hinzu.

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Video hinzufügen.
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Auf ein Video-Frame zugreifen**
Rufen Sie das erste zu einer Folie hinzugefügte Video-Frame ab.

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // Greifen Sie auf das erste Video-Frame auf der Folie zu.
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

## **Video-Frame entfernen**
Löschen Sie ein Video-Frame von der Folie.

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Angenommen, das erste Shape ist das Video-Frame.
        let videoFrame = slide.getShapes().get_Item(0);

        // Video-Frame entfernen.
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Video-Wiedergabe festlegen**
Konfigurieren Sie das Video so, dass es automatisch abgespielt wird, wenn die Folie angezeigt wird.

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Angenommen, das erste Shape ist das Video-Frame.
        let videoFrame = slide.getShapes().get_Item(0);

        // Video so konfigurieren, dass es automatisch abgespielt wird.
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```