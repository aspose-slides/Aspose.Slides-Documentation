---
title: Аудио
type: docs
weight: 70
url: /ru/php-java/examples/elements/audio/
keywords:
- аудио
- аудиофрейм
- добавить аудио
- доступ к аудио
- удалить аудио
- воспроизведение аудио
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Работа с аудио в PHP с помощью Aspose.Slides: добавление, замена, извлечение и обрезка звуков, настройка громкости и воспроизведения для слайдов и объектов в PowerPoint и OpenDocument."
---
Иллюстрирует, как встроить аудиофреймы и управлять воспроизведением с помощью **Aspose.Slides for PHP via Java**. Ниже приведены примеры базовых операций с аудио.

## **Добавить аудиофрейм**

Вставить аудиофрейм.

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Создать аудиофрейм.
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Доступ к аудиофрейму**

Этот код получает первый аудиофрейм на слайде.

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Доступ к первому аудиофрейму на слайде.
        $firstAudioFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
                $firstAudioFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Удалить аудиофрейм**

Удалить ранее добавленный аудиофрейм.

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Предполагая, что первая фигура на слайде — аудиофрейм.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Удалить аудиофрейм.
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Установить воспроизведение аудио**

Настройте аудиофрейм на автоматическое воспроизведение при появлении слайда.

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Предполагая, что первая фигура на слайде — аудиофрейм.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Воспроизводить автоматически при появлении слайда.
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```