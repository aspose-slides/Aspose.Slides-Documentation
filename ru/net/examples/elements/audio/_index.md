---
title: Аудио
type: docs
weight: 70
url: /ru/net/examples/elements/audio/
keywords:
- пример аудио
- аудиофрейм
- добавить аудио
- доступ к аудио
- удалить аудио
- воспроизведение аудио
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Работа с аудио в C# с помощью Aspose.Slides: добавление, замена, извлечение и обрезка звуков, настройка громкости и воспроизведения для слайдов и фигур в PowerPoint и OpenDocument."
---

Илюстрирует, как внедрять аудиофреймы и управлять воспроизведением с помощью **Aspose.Slides for .NET**. Следующие примеры показывают базовые операции с аудио.

## **Add an Audio Frame**
Добавить аудиофрейм

Insert an empty audio frame that can later hold embedded sound data.
Вставьте пустой аудиофрейм, который позже может содержать внедрённые звуковые данные.
```csharp
static void Add_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Создать пустой аудио фрейм (аудио будет внедрено позже)
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```


## **Access an Audio Frame**
Доступ к аудиофрейму

This code retrieves the first audio frame on a slide.
Этот код извлекает первый аудиофрейм на слайде.
```csharp
static void Access_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Получить первый аудиофрейм на слайде
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```


## **Remove an Audio Frame**
Удалить аудиофрейм

Delete a previously added audio frame.
Удалите ранее добавленный аудиофрейм.
```csharp
static void Remove_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Удалить аудиофрейм
    slide.Shapes.Remove(audioFrame);
}
```


## **Set Audio Playback**
Настроить воспроизведение аудио

Configure the audio frame to play automatically when the slide appears.
Настройте аудиофрейм для автоматического воспроизведения при появлении слайда.
```csharp
static void Set_Audio_Playback()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Воспроизводить автоматически при появлении слайда
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```
