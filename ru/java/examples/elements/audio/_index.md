---
title: Аудио
type: docs
weight: 70
url: /ru/java/examples/elements/audio/
keywords:
- пример кода
- аудио
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Ознакомьтесь с примерами работы со звуком в Aspose.Slides for Java: вставка, воспроизведение, обрезка и извлечение звука в презентациях PPT, PPTX и ODP с понятным кодом на Java."
---
Эта статья демонстрирует, как встраивать аудиофреймы и управлять воспроизведением с помощью **Aspose.Slides for Java**. Ниже приведены примеры базовых аудиоопераций.

## **Добавить аудиофрейм**

Вставьте пустой аудиофрейм, который позже можно будет заполнить встроенными звуковыми данными.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Создайте пустой аудио фрейм (звуковой файл будет встроен позже).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Доступ к аудиофрейму**

Этот код получает первый аудиофрейм на слайде.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Доступ к первому аудио фрейму на слайде.
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

## **Удалить аудиофрейм**

Удалите ранее добавленный аудиофрейм.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Удалить аудио фрейм.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Установить воспроизведение аудио**

Настройте аудиофрейм для автоматического воспроизведения при появлении слайда.

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