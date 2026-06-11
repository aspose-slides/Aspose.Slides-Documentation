---
title: Dźwięk
type: docs
weight: 70
url: /pl/net/examples/elements/audio/
keywords:
- dźwięk
- ramka audio
- dodaj dźwięk
- uzyskaj dostęp do dźwięku
- usuń dźwięk
- odtwarzanie dźwięku
- przykład kodu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Odkryj przykłady audio Aspose.Slides for .NET: wstawianie, odtwarzanie, przycinanie i wyodrębnianie dźwięku w prezentacjach PPT, PPTX i ODP przy użyciu przejrzystego kodu C#."
---
Ten artykuł demonstruje, jak osadzać ramki audio i sterować ich odtwarzaniem za pomocą **Aspose.Slides for .NET**. Poniższe przykłady pokazują podstawowe operacje na dźwięku.

## **Add an Audio Frame**
Wstaw pustą ramkę audio, która później może zawierać osadzone dane dźwiękowe.

```csharp
static void AddAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Utwórz pustą ramkę audio (dźwięk zostanie osadzony później).
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## **Access an Audio Frame**
Ten kod pobiera pierwszą ramkę audio na slajdzie.

```csharp
static void AccessAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Uzyskaj dostęp do pierwszej ramki audio na slajdzie.
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## **Remove an Audio Frame**
Usuń wcześniej dodaną ramkę audio.

```csharp
static void RemoveAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Usuń ramkę audio.
    slide.Shapes.Remove(audioFrame);
}
```

## **Set Audio Playback**
Skonfiguruj ramkę audio, aby odtwarzała się automatycznie po wyświetleniu slajdu.

```csharp
static void SetAudioPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Odtwarzaj automatycznie, gdy slajd się pojawi.
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```