---
title: Audio
type: docs
weight: 70
url: /nl/nodejs-java/examples/elements/audio/
keywords:
- codevoorbeeld
- audio
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Ontdek audio‑voorbeelden van Aspose.Slides voor Node.js: invoegen, afspelen, bijsnijden en geluid extraheren in PPT‑, PPTX‑ en ODP‑presentaties met duidelijke JavaScript‑code."
---
Dit artikel toont hoe je audio‑frames kunt insluiten en de weergave kunt beheren met **Aspose.Slides for Node.js via Java**. De volgende voorbeelden laten basis‑audio‑bewerkingen zien.

## **Audio-frame toevoegen**

Het onderstaande codevoorbeeld voegt een audio‑frame toe aan een presentatie‑slide.

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

## **Audio-frame benaderen**

Deze code haalt het eerste audio‑frame op een slide op.

```js
function accessAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Toegang tot het eerste audio‑frame op de dia.
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

## **Audio-frame verwijderen**

Verwijder een eerder toegevoegd audio‑frame.

```js
function removeAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Veronderstel dat de eerste vorm het audio-frame is.
        let audioFrame = slide.getShapes().get_Item(0);

        // Verwijder het audio-frame.
        slide.getShapes().remove(audioFrame);

        presentation.save("audio_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Audio-afspelen instellen**

Stel het audio‑frame in om automatisch af te spelen wanneer de slide verschijnt.

```js
function setAudioPlayback() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Veronderstel dat de eerste vorm een audio-frame is.
        let audioFrame = slide.getShapes().get_Item(0);

        // Automatisch afspelen wanneer de dia verschijnt.
        audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);

        presentation.save("audio_playback.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```