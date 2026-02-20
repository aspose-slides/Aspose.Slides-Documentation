---
title: Видео
type: docs
weight: 80
url: /ru/php-java/examples/elements/video/
keywords:
- видео
- видеокадр
- добавить видео
- доступ к видео
- удалить видео
- воспроизведение видео
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Работайте с видео в PHP с помощью Aspose.Slides: вставляйте, заменяйте, обрезайте, задавайте постер-кадры и параметры воспроизведения, а также экспортируйте презентации в форматы PPT, PPTX и ODP."
---
Показывает, как встроить видеокадры и задать параметры воспроизведения, используя **Aspose.Slides for PHP via Java**.

## **Добавить видеокадр**

Вставьте видеокадр в слайд.

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Добавить видеокадр.
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Получить видеокадр**

Получите первый видеокадр, добавленный в слайд.

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Получить первый видеокадр на слайде.
        $firstVideoFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $firstVideoFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Удалить видеокадр**

Удалите видеокадр со слайда.

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Предполагается, что первая фигура на слайде является видеокадром.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Удалить видеокадр.
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Настроить воспроизведение видео**

Настройте видео на автоматическое воспроизведение при отображении слайда.

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Предполагается, что первая фигура на слайде является видеокадром.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Настроить видео на автоматическое воспроизведение.
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```