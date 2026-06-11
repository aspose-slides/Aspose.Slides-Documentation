---
title: Ljud
type: docs
weight: 70
url: /sv/nodejs-java/examples/elements/audio/
keywords:
- kodexempel
- ljud
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Upptäck Aspose.Slides för Node.js ljudexempel: infoga, spela upp, trimma och extrahera ljud i PPT-, PPTX- och ODP-presentationer med tydlig JavaScript-kod."
---
Den här artikeln visar hur man bäddar in ljudramar och styr uppspelning med **Aspose.Slides for Node.js via Java**. Följande exempel visar grundläggande ljudoperationer.

## **Lägg till en ljudram**

Kodexemplet nedan lägger till en ljudram på en presentationsbild.

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

## **Åtkomst till en ljudram**

Den här koden hämtar den första ljudramen på en bild.

```js
function accessAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Åtkomst till den första ljudramen på bilden.
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

## **Ta bort en ljudram**

Ta bort en tidigare tillagd ljudram.

```js
function removeAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Anta att den första formen är ljudramen.
        let audioFrame = slide.getShapes().get_Item(0);

        // Ta bort ljudramen.
        slide.getShapes().remove(audioFrame);

        presentation.save("audio_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Ställ in ljuduppspelning**

Konfigurera ljudramen så att den spelas upp automatiskt när bilden visas.

```js
function setAudioPlayback() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Anta att den första formen är en ljudram.
        let audioFrame = slide.getShapes().get_Item(0);

        // Spela upp automatiskt när bilden visas.
        audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);

        presentation.save("audio_playback.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```