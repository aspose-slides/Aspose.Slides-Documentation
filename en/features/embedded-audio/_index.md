---
title: Add embedded audio and set playback options
description: Embed audio in slides and configure its playback settings.
type: docs
url: /features/embedded-audio/
weight: 1080
feature_id: embedded-audio
feature_group: media
translationKey: slides-feature-embedded-audio
feature_catalogue_version: 3
feature_guides:
- /slides/net/audio-frame/
---

## **Overview**

Add an audio clip to a slide and set options such as playback mode, volume, looping, trimming and fading. The media data is stored in the presentation and can be extracted again. This page covers embedded audio and its presentation settings.

## **Usage example**

This C# example uses Aspose.Slides for .NET. Generate a valid half-second, 8 kHz mono WAV tone at 440 Hz, embed it, and set automatic playback, medium volume and looping. The WAV header describes 16-bit PCM audio; no input file is needed. Playback depends on the slideshow application. The PNG shows the audio frame rather than playing the sound. It saves *embedded-audio.pptx* and *embedded-audio.png*. Install the library using the [installation guide](/slides/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.IO;
using System.Text;

using var audioStream = new MemoryStream();
using (var writer = new BinaryWriter(audioStream, Encoding.ASCII, true))
{
    var sampleRate = 8000;
    var sampleCount = 4000;
    writer.Write(Encoding.ASCII.GetBytes("RIFF"));
    writer.Write(36 + sampleCount * 2);
    writer.Write(Encoding.ASCII.GetBytes("WAVEfmt "));
    writer.Write(16);
    writer.Write((short)1);
    writer.Write((short)1);
    writer.Write(sampleRate);
    writer.Write(sampleRate * 2);
    writer.Write((short)2);
    writer.Write((short)16);
    writer.Write(Encoding.ASCII.GetBytes("data"));
    writer.Write(sampleCount * 2);
    for (var i = 0; i < sampleCount; i++)
    {
        var sample = (short)(Math.Sin(2 * Math.PI * 440 * i / sampleRate) * 4000);
        writer.Write(sample);
    }
}
audioStream.Position = 0;
using var presentation = new Presentation();
var slide = presentation.Slides[0];
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(80, 80, 80, 80, audioStream);
audioFrame.PlayMode = AudioPlayModePreset.Auto;
audioFrame.Volume = AudioVolumeMode.Medium;
audioFrame.PlayLoopMode = true;
presentation.Save("embedded-audio.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("embedded-audio.png", ImageFormat.Png);
```

## **FAQ**

### **Can I use the same workflow to write an external audio link?**

Use embedded audio for this workflow. Writing linked external audio has limitations, including when resaving an existing linked clip.

### **How can I extract the original embedded audio bytes?**

Read the embedded audio data from the frame and write those bytes to a file with the appropriate media extension. This extracts the source audio rather than converting it.

### **Can I configure looping and automatic playback?**

Yes. Configure the embedded frame's playback mode and loop option, as in this sample. These are instructions for the presentation player.

## **Guides**

- [Manage Audio Frames in Presentations in .NET](/slides/net/audio-frame/)
