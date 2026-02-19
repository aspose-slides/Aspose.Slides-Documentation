---
title: Аудио
type: docs
weight: 70
url: /ru/androidjava/examples/elements/audio/
keywords:
- пример кода
- аудио
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Откройте для себя примеры работы с аудио в Aspose.Slides for Android: вставка, воспроизведение, обрезка и извлечение звука в презентациях PPT, PPTX и ODP с понятным Java‑кодом."
---
В этой статье демонстрируется, как внедрить аудио‑кадры и управлять воспроизведением с помощью **Aspose.Slides for Android via Java**. Ниже приведены примеры базовых операций с аудио.

## **Добавить аудио‑кадр**

Вставьте пустой аудио‑кадр, который позже может содержать встроенные звуковые данные.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Создайте пустой аудио‑кадр (аудио будет внедрено позже).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Получить доступ к аудио‑кадру**

Этот код извлекает первый аудио‑кадр на слайде.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Доступ к первому аудио‑кадру на слайде.
        IAudioFrame firstAudio = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAudioFrame) {
                firstAudio = (IAudioFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить аудио‑кадр**

Удалите ранее добавленный аудио‑кадр.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Удалить аудио‑кадр.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Настроить воспроизведение аудио**

Настройте аудио‑кадр для автоматического воспроизведения при отображении слайда.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Воспроизводить автоматически при появлении слайда.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```