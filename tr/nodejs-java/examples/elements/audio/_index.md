---
title: Ses
type: docs
weight: 70
url: /tr/nodejs-java/examples/elements/audio/
keywords:
- kod örneği
- ses
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ses örneklerini keşfedin: PPT, PPTX ve ODP sunumlarında sesi ekleyin, oynatın, kırpın ve çıkarın, açık JavaScript kodu ile."
---
Bu makale, **Aspose.Slides for Node.js via Java** ile ses çerçevelerini gömmeyi ve oynatmayı kontrol etmeyi gösterir. Aşağıdaki örnekler temel ses işlemlerini gösterir.

## **Ses Çerçevesi Ekle**

Aşağıdaki kod örneği, sunum slaytına bir ses çerçevesi ekler.

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

## **Ses Çerçevesine Eriş**

Bu kod, bir slayttaki ilk ses çerçevesini alır.

```js
function accessAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Slayttaki ilk ses çerçevesine eriş.
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

## **Ses Çerçevesini Kaldır**

Daha önce eklenmiş bir ses çerçevesini sil.

```js
function removeAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // İlk şeklin ses çerçevesi olduğunu varsayın.
        let audioFrame = slide.getShapes().get_Item(0);

        // Ses çerçevesini kaldır.
        slide.getShapes().remove(audioFrame);

        presentation.save("audio_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Ses Oynatımını Ayarla**

Ses çerçevesini, slayt göründüğünde otomatik olarak oynatılacak şekilde yapılandırın.

```js
function setAudioPlayback() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // İlk şeklin bir ses çerçevesi olduğunu varsayın.
        let audioFrame = slide.getShapes().get_Item(0);

        // Slayt göründüğünde otomatik olarak oynat.
        audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);

        presentation.save("audio_playback.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```