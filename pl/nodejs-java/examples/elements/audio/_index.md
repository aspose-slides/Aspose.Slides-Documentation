---
title: Audio
type: docs
weight: 70
url: /pl/nodejs-java/examples/elements/audio/
keywords:
- przykład kodu
- audio
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Odkryj przykłady audio Aspose.Slides dla Node.js: wstawianie, odtwarzanie, przycinanie i wyodrębnianie dźwięku w prezentacjach PPT, PPTX i ODP przy użyciu przejrzystego kodu JavaScript."
---
Ten artykuł pokazuje, jak osadzać ramki audio i kontrolować odtwarzanie przy użyciu **Aspose.Slides for Node.js via Java**. Poniższe przykłady przedstawiają podstawowe operacje na audio.

## **Dodaj ramkę audio**

Poniższy przykład kodu dodaje ramkę audio na slajdzie prezentacji.

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

## **Uzyskaj dostęp do ramki audio**

Ten kod pobiera pierwszą ramkę audio na slajdzie.

```js
function accessAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Uzyskaj dostęp do pierwszej ramki audio na slajdzie.
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

## **Usuń ramkę audio**

Usuń wcześniej dodaną ramkę audio.

```js
function removeAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Załóż, że pierwszym kształtem jest ramka audio.
        let audioFrame = slide.getShapes().get_Item(0);

        // Usuń ramkę audio.
        slide.getShapes().remove(audioFrame);

        presentation.save("audio_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Ustaw odtwarzanie audio**

Skonfiguruj ramkę audio, aby odtwarzała się automatycznie po wyświetleniu slajdu.

```js
function setAudioPlayback() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Załóż, że pierwszym kształtem jest ramka audio.
        let audioFrame = slide.getShapes().get_Item(0);

        // Odtwarzaj automatycznie po wyświetleniu slajdu.
        audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);

        presentation.save("audio_playback.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```