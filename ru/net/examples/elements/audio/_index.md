---
title: Аудио
type: docs
weight: 70
url: /ru/net/examples/elements/audio/
keywords:
- аудио
- аудиофрейм
- добавить аудио
- доступ к аудио
- удалить аудио
- воспроизведение аудио
- пример кода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Откройте примеры работы с аудио в Aspose.Slides для .NET: вставка, воспроизведение, обрезка и извлечение звука в презентациях PPT, PPTX и ODP с понятным кодом C#."
---
В этой статье демонстрируется, как встраивать аудиофреймы и управлять воспроизведением с помощью **Aspose.Slides for .NET**. Ниже приведены базовые операции с аудио.

## **Добавить аудиофрейм**

Вставьте пустой аудиофрейм, который позже можно заполнить встроенными звуковыми данными.

```csharp
static void AddAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Создать пустой аудиофрейм (аудио будет встроено позже).
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## **Получить доступ к аудиофрейму**

Этот код извлекает первый аудиофрейм на слайде.

```csharp
static void AccessAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Получить первый аудиофрейм на слайде.
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## **Удалить аудиофрейм**

Удалите ранее добавленный аудиофрейм.

```csharp
static void RemoveAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Удалить аудиофрейм.
    slide.Shapes.Remove(audioFrame);
}
```

## **Настроить воспроизведение аудио**

Настройте аудиофрейм на автоматическое воспроизведение при появлении слайда.

```csharp
static void SetAudioPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Воспроизводить автоматически при появлении слайда.
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```