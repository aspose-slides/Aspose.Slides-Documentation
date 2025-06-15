---
title: Audio
type: docs
weight: 70
url: /net/examples/elements/audio
---

Illustrates how to embed audio frames and control playback with **Aspose.Slides for .NET**. The following examples show basic audio operations.

## Add an Audio Frame

Insert an empty audio frame that can later hold embedded sound data.

```csharp
static void Add_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Create an empty audio frame (audio will be embedded later)
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## Access an Audio Frame

This code retrieves the first audio frame on a slide.

```csharp
static void Access_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Access the first audio frame on the slide
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## Remove an Audio Frame

Delete a previously added audio frame.

```csharp
static void Remove_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Remove the audio frame
    slide.Shapes.Remove(audioFrame);
}
```

## Set Audio Playback

Configure the audio frame to play automatically when the slide appears.

```csharp
static void Set_Audio_Playback()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Play automatically when the slide appears
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```
