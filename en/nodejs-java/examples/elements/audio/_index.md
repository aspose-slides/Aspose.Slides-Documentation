---
title: Audio
type: docs
weight: 70
url: /nodejs-java/examples/elements/audio/
keywords:
- code example
- audio
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Discover Aspose.Slides for Node.js audio examples: insert, play, trim, and extract sound in PPT, PPTX, and ODP presentations with clear JavaScript code."
---

This article demonstrates how to embed audio frames and control playback with **Aspose.Slides for Node.js via Java**. The following examples show basic audio operations.

## **Add an Audio Frame**

The code example below adds an audio frame on a presentation slide.

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

## **Access an Audio Frame**

This code retrieves the first audio frame on a slide.

```js
function accessAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Access the first audio frame on the slide.
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

## **Remove an Audio Frame**

Delete a previously added audio frame.

```js
function removeAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Assume the first shape is the audio frame.
        let audioFrame = slide.getShapes().get_Item(0);

        // Remove the audio frame.
        slide.getShapes().remove(audioFrame);

        presentation.save("audio_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Set Audio Playback**

Configure the audio frame to play automatically when the slide appears.

```js
function setAudioPlayback() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Assume the first shape is an audio frame.
        let audioFrame = slide.getShapes().get_Item(0);

        // Play automatically when the slide appears.
        audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);

        presentation.save("audio_playback.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```
