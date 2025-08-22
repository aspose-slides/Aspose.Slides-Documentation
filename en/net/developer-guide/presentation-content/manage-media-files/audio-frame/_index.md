---
title: Audio Frame - Insert and Extract Audio in PowerPoint Using C#
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
description: "Create and control audio frames in Aspose.Slides for .NET—C# examples to embed, trim, loop, and configure playback across PPT, PPTX, and ODP presentations."
---

## **Create Audio Frames**

Aspose.Slides for .NET allows you to add audio files to slides. The audio files are embedded in slides as audio frames. 

1. Create an instance of the [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
2. Get a slide's reference through its index.
3. Load the audio file stream you want to embed in the slide.
4. Add the embedded audio frame (containing the audio file) to the slide.
5. Set [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioplaymodepreset) and `Volume` exposed by the [IAudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) object.
6. Save the modified presentation.

This C# code shows you how to add an embedded audio frame to a slide:

```c#
// Instantiates a presentation class that represents a presentation file
using (Presentation pres = new Presentation())
{
    // Gets the first slide
    ISlide sld = pres.Slides[0];
    
    // Loads the the wav sound file to stream
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Adds the Audio Frame
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Sets the Play Mode and Volume of the Audio
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // Writes the PowerPoint file to disk
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **Change Audio Frame Thumbnail**

When you add an audio file to a presentation, the audio appears as a frame with a standard default image (see the image in the section below). You change the audio frame's thumbnail (set your preferred image).

This C# code shows you how to change an audio frame's thumbnail or preview image:

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // Adds an audio frame to the slide with a specified position and size.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // Adds an image to presentation resources.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // Sets the image for the audio frame.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
	//Saves the modified presentation to disk
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **Change Audio Play Options**

Aspose.Slides for .NET allows you to change options that control an audio's playback or properties. For example, you can adjust an audio's volume, set the audio to play looped, or even hide the audio icon.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) properties:

- **Start** drop-down menu matches the [AudioFrame.PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playmode) property 
- **Volume** matches the [AudioFrame.Volume](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/volume) property 
- **Play Across Slides** matches the [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playacrossslides) property 
- **Loop until Stopped** matches the [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playloopmode) property 
- **Hide During Show** matches the  [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/hideatshowing) property 
- **Rewind after Playing** matches the [AudioFrame.RewindAudio ](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/rewindaudio) property 

PowerPoint **Editing** options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) properties:

- **Fade In** matches the [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeinduration/) property 
- **Fade Out** matches the [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeoutduration/) property 
- **Trim Audio Start Time** matches the [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromstart/) property 
- **Trim Audio End Time** value equals the audio duration minus the value of [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromend/) property

The PowerPoint **Volume controll** on the audio control panel corresponds to the [AudioFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/audioframe/volumevalue/) property. It lets you change the audio volume as a percentage.

This is how you change the Audio Play options:

1. [Сreate](#create-audio-frame) or get the Audio Frame.
2. Set new values for the Audio Frame properties you want to adjust.
3. Save the modified PowerPoint file.

This C# code demonstrates an operation in which an audio's options are adjusted:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Gets the AudioFrame shape
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Sets the Play mode to play on click
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Sets the volume to Low
    audioFrame.Volume = AudioVolumeMode.Low;

    // Sets the audio to play across slides
    audioFrame.PlayAcrossSlides = true;

    // Disables loop for the audio
    audioFrame.PlayLoopMode = false;

    // Hides the AudioFrame during the slide show
    audioFrame.HideAtShowing = true;

    // Rewinds the audio to start after playing
    audioFrame.RewindAudio = true;

    // Saves the PowerPoint file to disk
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

This C# example shows how to add a new audio frame with embedded audio, trim it, and set the fade durations:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Sets the trimming start offset to 1.5 seconds
    audioFrame.TrimFromStart = 1500f;
    // Sets the trimming end offset to 2 seconds
    audioFrame.TrimFromEnd = 2000f;

    // Sets the fade-in duration to 200 ms
    audioFrame.FadeInDuration = 200f;
    // Sets the fade-out duration to 500 ms
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```

The following code sample shows how to retrieve an audio frame with embedded audio and set its volume to 85%:

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Gets an audio frame shape
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Sets the audio volume to 85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```

## **Extract Audio**
Aspose.Slides for .NET allows you to extract the sound used in slide show transitions. For example, you can extract the sound used in a specific slide.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class and load the presentation containing the audio.
2. Get the relevant slide's reference through its index.
3. Access the slideshow transitions for the slide.
4. Extract the sound in byte data.

This C# code shows you how to extract the audio used in a slide:

```c#
string presName = "AudioSlide.pptx";

// Instantiates a Presentation class that represents a presentation file
Presentation pres = new Presentation(presName);

// Accesses the slide
ISlide slide = pres.Slides[0];

// Gets the slideshow transition effects for the slide
ISlideShowTransition transition = slide.SlideShowTransition;

//Extracts the sound in byte array
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```
