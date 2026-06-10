---
title: Hang
type: docs
weight: 70
url: /hu/nodejs-java/examples/elements/audio/
keywords:
- kód példa
- hang
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Node.js hangpéldákat: hang beszúrása, lejátszása, vágása és kinyerése PPT, PPTX és ODP prezentációkban, egyértelmű JavaScript kóddal."
---
Ez a cikk bemutatja, hogyan lehet beágyazni hangkereteket, és vezérelni a lejátszást a **Aspose.Slides for Node.js via Java** használatával. A következő példák az alapvető hangműveleteket mutatják be.

## **Hangkeret hozzáadása**

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

## **Hangkeret elérése**

```js
function accessAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // A dián található első hangkeret elérése.
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

## **Hangkeret eltávolítása**

```js
function removeAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Feltételezzük, hogy az első alakzat a hangkeret.
        let audioFrame = slide.getShapes().get_Item(0);

        // A hangkeret eltávolítása.
        slide.getShapes().remove(audioFrame);

        presentation.save("audio_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Hanglejátszás beállítása**

```js
function setAudioPlayback() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Feltételezzük, hogy az első alakzat egy hangkeret.
        let audioFrame = slide.getShapes().get_Item(0);

        // Automatikus lejátszás, amikor a dia megjelenik.
        audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);

        presentation.save("audio_playback.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```