---
title: Zvuk
type: docs
weight: 70
url: /cs/nodejs-java/examples/elements/audio/
keywords:
- ukázka kódu
- zvuk
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Objevte příklady audia v Aspose.Slides pro Node.js: vkládání, přehrávání, ořezávání a extrakci zvuku v prezentacích PPT, PPTX a ODP pomocí přehledného JavaScript kódu."
---
Tento článek ukazuje, jak vložit audio rámečky a ovládat přehrávání pomocí **Aspose.Slides for Node.js via Java**. Následující příklady ukazují základní operace s audiem.

## **Add an Audio Frame**

Níže uvedený ukázkový kód přidá audio rámeček na snímek prezentace.

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

Tento kód získá první audio rámeček na snímku.

```js
function accessAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Přístup k prvnímu audio rámečku na snímku.
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

Smaže dříve přidaný audio rámeček.

```js
function removeAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Předpokládejte, že první tvar je audio rámeček.
        let audioFrame = slide.getShapes().get_Item(0);

        // Odstraňte audio rámeček.
        slide.getShapes().remove(audioFrame);

        presentation.save("audio_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Set Audio Playback**

Nastavte audio rámeček tak, aby se přehrával automaticky, když se snímek zobrazí.

```js
function setAudioPlayback() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Předpokládejte, že první tvar je audio rámeček.
        let audioFrame = slide.getShapes().get_Item(0);

        // Přehrávání automaticky při zobrazení snímku.
        audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);

        presentation.save("audio_playback.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```