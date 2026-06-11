---
title: Wideo
type: docs
weight: 80
url: /pl/nodejs-java/examples/elements/video/
keywords:
- przykład kodu
- wideo
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dodawaj i steruj filmami za pomocą Aspose.Slides for Node.js: wstawiaj, odtwarzaj, przycinaj, ustawiaj klatki promocyjne oraz eksportuj, z przykładami dla prezentacji w formatach PPT, PPTX i ODP."
---
W tym artykule pokazano, jak osadzić ramki wideo i ustawić opcje odtwarzania przy użyciu **Aspose.Slides for Node.js via Java**.

## **Dodaj ramkę wideo**

Dodaj ramkę wideo do slajdu.

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Dodaj wideo.
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Uzyskaj dostęp do ramki wideo**

Pobierz pierwszą ramkę wideo dodaną do slajdu.

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // Uzyskaj dostęp do pierwszej ramki wideo na slajdzie.
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

## **Usuń ramkę wideo**

Usuń ramkę wideo ze slajdu.

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Załóż, że pierwszym kształtem jest ramka wideo.
        let videoFrame = slide.getShapes().get_Item(0);

        // Usuń ramkę wideo.
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Ustaw odtwarzanie wideo**

Skonfiguruj odtwarzanie wideo tak, aby odtwarzało się automatycznie po wyświetleniu slajdu.

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Załóż, że pierwszym kształtem jest ramka wideo.
        let videoFrame = slide.getShapes().get_Item(0);

        // Skonfiguruj odtwarzanie wideo automatycznie.
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```