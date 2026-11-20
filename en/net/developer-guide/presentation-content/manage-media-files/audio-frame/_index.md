---
title: Manage Audio Frames in Presentations in .NET
linktitle: Audio Frame
type: docs
weight: 10
url: /net/audio-frame/
keywords:
- audio
- audio frame
- thumbnail
- add audio
- audio properties
- audio options
- extract audio
- .NET
- C#
- Aspose.Slides
description: "Embed audio in slides, change the audio icon, configure playback, manage WebVTT captions, and extract slide transition sounds with Aspose.Slides for .NET."
---

## **Overview**

An audio frame lets you play a sound on a slide. With Aspose.Slides for .NET, you can embed an audio clip, choose the image that represents it, adjust playback, and attach captions. You can also retrieve a sound assigned to a slide transition.

## **Create Audio Frames**

Use [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) to embed a local audio clip on the first slide. The first two coordinates position the frame on the slide, and the next two values set its width and height, all in points. This example sets [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) to start the clip automatically and [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) to the loud preset.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame.PlayMode = AudioPlayModePreset.Auto;
audioFrame.Volume = AudioVolumeMode.Loud;

presentation.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
```

## **Change the Audio Frame Thumbnail**

By default, an audio frame displays a speaker icon. To display a custom thumbnail, add an image to the presentation with [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) and assign it to the frame’s [Picture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) property. The example uses a JPEG as the thumbnail for an embedded audio clip.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var imageStream = File.OpenRead("eagle.jpeg");
var thumbnail = presentation.Images.AddImage(imageStream);

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

## **Change Audio Play Options**

PowerPoint’s **Audio Options** controls determine when a clip starts, how loud it sounds, and how it behaves during a slide show.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint control | Aspose.Slides property |
| --- | --- |
| Start | [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) |
| Volume preset | [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) |
| Play Across Slides | [PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playacrossslides/) |
| Loop until Stopped | [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playloopmode/) |
| Hide During Show | [HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/hideatshowing/) |
| Rewind after Playing | [RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/rewindaudio/) |
| Fade In | [FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeinduration/) |
| Fade Out | [FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeoutduration/) |
| Trim Audio start time | [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) |
| Trim Audio end time | [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) |
| Volume slider | [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) |

The example finds the first audio frame on the first slide, sets [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) to start playback on a click, and selects the low volume preset. The clip continues across slides with looping disabled. The icon stays hidden during the show, and the clip rewinds after playback.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.PlayMode = AudioPlayModePreset.OnClick;
audioFrame.Volume = AudioVolumeMode.Low;
audioFrame.PlayAcrossSlides = true;
audioFrame.PlayLoopMode = false;
audioFrame.HideAtShowing = true;
audioFrame.RewindAudio = true;

presentation.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
```

For a clip longer than 3.5 seconds, this example skips the first 1.5 seconds and the last 2 seconds. [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) measures the duration to omit from the end of the clip. To get the end time shown in PowerPoint, subtract that offset from the full clip duration. The trimmed clip fades in over 200 milliseconds and fades out over 500 milliseconds. All four properties take values in milliseconds.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame.TrimFromStart = 1500f;
audioFrame.TrimFromEnd = 2000f;
audioFrame.FadeInDuration = 200f;
audioFrame.FadeOutDuration = 500f;

presentation.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
```

To set the playback volume to a specific percentage, use [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/). This example sets the first audio frame on the first slide to 85%.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.VolumeValue = 85f;

presentation.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
```

## **Manage Audio Captions**

Each audio frame has a [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/captiontracks/) collection. Use it to attach WebVTT captions to the clip, export existing tracks, or remove them.

### **Add Audio Captions**

The example embeds an audio clip on the first slide and uses [ICaptionsCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/add/) to attach a local WebVTT track. The first argument supplies the track label, and the second identifies the file containing the timed captions.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
```

### **Extract Audio Captions**

This example exports each caption track attached to an audio frame on the first slide. It writes the track’s [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/icaptions/binarydata/) to a WebVTT file and uses its [CaptionId](https://reference.aspose.com/slides/net/aspose.slides/icaptions/captionid/) as the file name so that each track has a separate output.

```csharp
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var audioFrame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in audioFrame.CaptionTracks)
    {
        File.WriteAllBytes($"{track.CaptionId}.vtt", track.BinaryData);
    }
}
```

### **Remove Audio Captions**

Use [Remove](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/remove/) or [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/removeat/) to delete an individual track. The example uses [Clear](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/clear/) to remove all captions from the first audio frame on the first slide while preserving the clip.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.CaptionTracks.Clear();

presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
```

### **Find a Line in Audio Captions**

To find a line in the audio captions on the first slide, read each track's [DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) in memory. In a plain-text WebVTT cue, the timing line contains `-->`, the caption lines follow it, and a blank line ends the cue. This example prints the track label and each caption line containing “café”.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var frame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in frame.CaptionTracks)
    {
        using var reader = new StringReader(track.DataAsString);
        var inCue = false;
        while (reader.ReadLine() is string line)
        {
            if (line.Length == 0)
                inCue = false;
            else if (line.Contains("-->"))
                inCue = true;
            else if (inCue && line.Contains("café", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"{track.Label}: {line}");
        }
    }
}
```

## **Extract Audio**

A slide transition can have its own sound. To retrieve it, read the transition’s [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) property. The example accesses the sound’s [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) and prints its size in bytes. If the first slide has no transition sound, it prints a message instead.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AudioSlide.pptx");
var slide = presentation.Slides[0];

var sound = slide.SlideShowTransition.Sound;
if (sound == null)
{
    Console.WriteLine("The first slide has no transition sound.");
    return;
}

var audioData = sound.BinaryData;
Console.WriteLine($"Transition sound: {audioData.Length} bytes.");
```

## **FAQ**

**Can I reuse the same audio clip across multiple slides without duplicating it?**

Yes. Add the clip once to the presentation’s [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) and pass the same audio object to [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) for each slide.

**Can I replace the sound in an existing audio frame?**

Yes. For a linked sound, update [LinkPathLong](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/linkpathlong/) to point to the replacement file. For an embedded sound, assign another clip from the presentation’s audio collection to [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/). Both approaches preserve the existing frame.

**Does trimming change the audio data stored in the presentation?**

No. [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) and [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) set playback boundaries. You can still retrieve the full clip from [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/).
