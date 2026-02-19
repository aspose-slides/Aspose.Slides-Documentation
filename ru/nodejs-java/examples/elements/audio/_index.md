---
title: Аудио
type: docs
weight: 70
url: /ru/nodejs-java/examples/elements/audio/
keywords:
- пример кода
- аудио
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Откройте для себя примеры аудио Aspose.Slides для Node.js: вставка, воспроизведение, обрезка и извлечение звука в презентациях PPT, PPTX и ODP с понятным кодом JavaScript."
---
Эта статья демонстрирует, как встраивать аудио‑фреймы и управлять их воспроизведением с помощью **Aspose.Slides for Node.js via Java**. Ниже приведены примеры базовых операций с аудио.

## **Add an Audio Frame**
Код ниже добавляет аудио‑фрейм на слайд презентации.

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
Этот код получает первый аудио‑фрейм на слайде.

```js
function accessAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Получить первый аудио‑фрейм на слайде.
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
Удалите ранее добавленный аудио‑фрейм.

```js
function removeAudio() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Предположим, что первая фигура является аудио‑фреймом.
        let audioFrame = slide.getShapes().get_Item(0);

        // Удалить аудио‑фрейм.
        slide.getShapes().remove(audioFrame);

        presentation.save("audio_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Set Audio Playback**
Настройте аудио‑фрейм для автоматического воспроизведения при отображении слайда.

```js
function setAudioPlayback() {
    let presentation = new aspose.slides.Presentation("audio.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Предположим, что первая фигура является аудио‑фреймом.
        let audioFrame = slide.getShapes().get_Item(0);

        // Воспроизводить автоматически при отображении слайда.
        audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);

        presentation.save("audio_playback.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```