---
title: Video
type: docs
weight: 80
url: /cs/nodejs-java/examples/elements/video/
keywords:
- ukázkový kód
- video
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Přidávejte a ovládejte videa pomocí Aspose.Slides pro Node.js: vkládejte, přehrávejte, ořezávejte, nastavujte plakátové snímky a exportujte s příklady pro prezentace PPT, PPTX a ODP."
---
Tento článek demonstruje, jak vložit video rámečky a nastavit možnosti přehrávání pomocí **Aspose.Slides for Node.js via Java**.

## **Přidat video snímek**

Přidejte video snímek do snímku.

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Přidejte video.
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Přístup k video snímku**

Získejte první video snímek přidaný do snímku.

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // Přístup k prvnímu video snímku na snímku.
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

## **Odebrat video snímek**

Odstraňte video snímek ze snímku.

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Předpokládejte, že první tvar je video rámeček.
        let videoFrame = slide.getShapes().get_Item(0);

        // Odstraňte video rámeček.
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Nastavit přehrávání videa**

Nastavte video tak, aby se přehrávalo automaticky při zobrazení snímku.

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Předpokládejte, že první tvar je video rámeček.
        let videoFrame = slide.getShapes().get_Item(0);

        // Nastavte video tak, aby se přehrávalo automaticky.
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```