---
title: Audio
type: docs
weight: 70
url: /de/nodejs-java/examples/elements/audio/
keywords:
- Codebeispiel
- Audio
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Node.js Audio-Beispiele: Einfügen, Abspielen, Trimmen und Extrahieren von Sound in PPT-, PPTX- und ODP-Präsentationen mit klarem JavaScript-Code."
---
In diesem Artikel wird gezeigt, wie Audio-Frames eingebettet und die Wiedergabe mit **Aspose.Slides for Node.js via Java** gesteuert werden kann. Die folgenden Beispiele zeigen grundlegende Audio-Operationen.

## **Audio-Frame hinzufügen**

Das nachstehende Codebeispiel fügt einem Folienpräsentations-Slide einen Audio-Frame hinzu.

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

## **Auf einen Audio-Frame zugreifen**

Dieser Code ruft den ersten Audio-Frame einer Folie ab.

```js
function accessAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Greifen Sie auf den ersten Audio-Frame auf der Folie zu.
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

## **Audio-Frame entfernen**

Entfernt einen zuvor hinzugefügten Audio-Frame.

```js
function removeAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Angenommen, die erste Form ist der Audio-Frame.
        let audioFrame = slide.getShapes().get_Item(0);

        // Entfernen Sie den Audio-Frame.
        slide.getShapes().remove(audioFrame);

        presentation.save("audio_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Audio-Wiedergabe festlegen**

Konfiguriert den Audio-Frame, damit er automatisch abgespielt wird, wenn die Folie angezeigt wird.

```js
function setAudioPlayback() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Angenommen, die erste Form ist ein Audio-Frame.
        let audioFrame = slide.getShapes().get_Item(0);

        // Automatisch abspielen, wenn die Folie angezeigt wird.
        audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);

        presentation.save("audio_playback.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```