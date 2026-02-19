---
title: Видео
type: docs
weight: 80
url: /ru/androidjava/examples/elements/video/
keywords:
  - пример кода
  - видео
  - PowerPoint
  - OpenDocument
  - презентация
  - Android
  - Java
  - Aspose.Slides
description: "Добавляйте и управляйте видео с помощью Aspose.Slides for Android: вставка, воспроизведение, обрезка, установка постеров и экспорт с примерами на Java для презентаций PPT, PPTX и ODP."
---
В этой статье показано, как внедрять видеокадры и задавать параметры воспроизведения с помощью **Aspose.Slides for Android via Java**.

## **Добавить видеокадр**
Вставьте пустой видеокадр на слайд.

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Добавьте видео.
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **Получить видеокадр**
Получите первый видеокадр, добавленный на слайд.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Получить первый видеокадр на слайде.
        IVideoFrame firstVideo = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                firstVideo = (IVideoFrame) shape;
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

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Удалить видеокадр.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Настроить воспроизведение видео**
Настройте автоматическое воспроизведение видео при отображении слайда.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Настройте автоматическое воспроизведение видео.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```