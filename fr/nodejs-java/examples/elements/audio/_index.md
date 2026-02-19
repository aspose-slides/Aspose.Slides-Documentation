---
title: Audio
type: docs
weight: 70
url: /fr/nodejs-java/examples/elements/audio/
keywords:
- exemple de code
- audio
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Découvrez les exemples audio d'Aspose.Slides pour Node.js : insérer, lire, découper et extraire le son dans les présentations PPT, PPTX et ODP avec un code JavaScript clair."
---
Cet article montre comment intégrer des cadres audio et contrôler la lecture avec **Aspose.Slides for Node.js via Java**. Les exemples suivants illustrent les opérations audio de base.

## **Ajouter un cadre audio**

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

## **Accéder à un cadre audio**

```js
function accessAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Accéder au premier cadre audio sur la diapositive.
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

## **Supprimer un cadre audio**

```js
function removeAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Supposer que la première forme est le cadre audio.
        let audioFrame = slide.getShapes().get_Item(0);

        // Supprimer le cadre audio.
        slide.getShapes().remove(audioFrame);

        presentation.save("audio_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Définir la lecture audio**

```js
function setAudioPlayback() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Supposer que la première forme est un cadre audio.
        let audioFrame = slide.getShapes().get_Item(0);

        // Lire automatiquement lorsque la diapositive apparaît.
        audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);

        presentation.save("audio_playback.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```