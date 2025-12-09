---
title: Аудио
type: docs
weight: 70
url: /ru/net/examples/elements/audio/
keywords:
- пример аудио
- аудио-фрейм
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
description: "Работайте с аудио в C# используя Aspose.Slides: добавляйте, заменяйте, извлекайте и обрезайте звуки, задавайте громкость и воспроизведение для слайдов и фигур в PowerPoint и OpenDocument."
---

Иллюстрирует, как внедрять аудиофреймы и управлять воспроизведением с помощью **Aspose.Slides for .NET**. Ниже приведены примеры базовых операций с аудио.

## Добавить аудиофрейм

Вставьте пустой аудиофрейм, который позже может содержать встроенные звуковые данные.
```csharp
static void Add_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Создайте пустой аудиофрейм (аудио будет встроено позже)
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```


## Получить доступ к аудиофрейму

Этот код извлекает первый аудиофрейм на слайде.
```csharp
static void Access_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Доступ к первому аудиофрейму на слайде
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```


## Удалить аудиофрейм

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


## Настроить воспроизведение аудио

Настройте аудиофрейм на автоматическое воспроизведение при появлении слайда.
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
