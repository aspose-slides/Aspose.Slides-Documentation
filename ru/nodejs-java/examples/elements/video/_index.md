---
title: Видео
type: docs
weight: 80
url: /ru/nodejs-java/examples/elements/video/
keywords:
- пример кода
- видео
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Добавляйте и управляйте видео с помощью Aspose.Slides для Node.js: вставляйте, воспроизводите, обрезайте, задавайте постеры кадров и экспортируйте, с примерами для презентаций PPT, PPTX и ODP."
---
В этой статье демонстрируется, как вставлять видеокадры и задавать параметры воспроизведения с использованием **Aspose.Slides for Node.js via Java**.

## **Добавить видеокадр**

Добавьте видеокадр на слайд.

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Добавить видео.
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Получить видеокадр**

Получите первый видеокадр, добавленный на слайд.

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // Получить первый видеокадр на слайде.
        let firstVideo = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IVideoFrame")) {
                firstVideo = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить видеокадр**

Удалите видеокадр со слайда.

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Предполагаем, что первая фигура является видеокадром.
        let videoFrame = slide.getShapes().get_Item(0);

        // Удалить видеокадр.
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Настроить воспроизведение видео**

Настройте воспроизведение видео автоматически при отображении слайда.

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Предполагаем, что первая фигура является видеокадром.
        let videoFrame = slide.getShapes().get_Item(0);

        // Настройте видео для автоматического воспроизведения.
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```