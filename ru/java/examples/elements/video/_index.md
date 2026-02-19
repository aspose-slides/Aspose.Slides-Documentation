---
title: Видео
type: docs
weight: 80
url: /ru/java/examples/elements/video/
keywords:
- пример кода
- видео
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Добавляйте и управляйте видео с помощью Aspose.Slides for Java: вставка, воспроизведение, обрезка, установка постеров и экспорт с примерами Java для презентаций PPT, PPTX и ODP."
---
Эта статья демонстрирует, как внедрять видеокадры и задавать параметры воспроизведения с помощью **Aspose.Slides for Java**.

## **Добавить видеокадр**

Вставьте пустой видеокадр на слайд.

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Добавить видео.
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **Получить доступ к видеокадру**

Получите первый видеокадр, добавленный на слайд.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Доступ к первому видеокадру на слайде.
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

## **Установить воспроизведение видео**

Настройте воспроизведение видео автоматически при отображении слайда.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Настройте видео для автоматического воспроизведения.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```