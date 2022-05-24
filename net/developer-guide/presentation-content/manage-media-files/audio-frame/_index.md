---
title: Audio Frame
type: docs
weight: 10
url: /net/audio-frame/
keywords: "Add audio, Audio frame, Audio properties, Extract audio, C#, Csharp, Aspose.Slides for .NET"
description: "Add audio to PowerPoint presentation in C# or .NET"
---

## **Creating Audio Frame**
Aspose.Slides for .NET allows you to add audio files to slides. The audio files are embedded in slides as audio frames. 

1. Create an instance of the [Presentation ](https://apireference.aspose.com/slides/net/aspose.slides/presentation)class.
2. Get a slide's reference through its index.
3. Load the audio file stream you want to embed in the slide.
4. Add the embedded audio frame (containing the audio file) to the slide.
5. Set [PlayMode](https://apireference.aspose.com/slides/net/aspose.slides/audioplaymodepreset) and `Volume` exposed by the [IAudioFrame](https://apireference.aspose.com/slides/net/aspose.slides/audioframe) object.
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

## **Change Audio Frame Image**

When you add an audio file to a presentation, the audio appears as a frame with a standard default image (see the image in the section below). You change the audio frame's image (set your preferred image).

This C# code shows you how to change an audio frame's image:

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

PowerPoint Audio options that correspond to Aspose.Slides [AudioFrame](https://apireference.aspose.com/slides/net/aspose.slides/audioframe) properties:

- Audio Options **Start** drop-down menu matches the [AudioFrame.PlayMode](https://apireference.aspose.com/slides/net/aspose.slides/audioframe/properties/playmode) property 
- Audio Options **Volume** matches the [AudioFrame.Volume](https://apireference.aspose.com/slides/net/aspose.slides/audioframe/properties/volume) property 
- Audio Options **Play Across Slides** matches the [AudioFrame.PlayAcrossSlides](https://apireference.aspose.com/slides/net/aspose.slides/audioframe/properties/playacrossslides) property 
- Audio Options **Loop until Stopped** matches the [AudioFrame.PlayLoopMode](https://apireference.aspose.com/slides/net/aspose.slides/audioframe/properties/playloopmode) property 
- Audio Options **Hide During Show** matches the  [AudioFrame.HideAtShowing](https://apireference.aspose.com/slides/net/aspose.slides/audioframe/properties/hideatshowing) property 
- Audio Options **Rewind after Playing** matches the [AudioFrame.RewindAudio ](https://apireference.aspose.com/slides/net/aspose.slides/audioframe/properties/rewindaudio) property 

This is how you change an Audio Frame properties:

1. [Сreate](#create-audio-frame) or get the Audio Frame.
2. Set new values for the Audio Frame properties you want to adjust.
3. Save the modified PowerPoint file.

This C# code demonstrates an operation in which an audio's options are adjusted:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Gets the AudioFrame shape
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Changes the Play mode to play on click
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Sets the volume to Low
    audioFrame.Volume = AudioVolumeMode.Low;

    // Sets the audio to play across slides
    audioFrame.PlayAcrossSlides = true;

    // Disables loop for the audio
    audioFrame.PlayLoopMode = false;

    // Hides the AudioFrame in a slide show
    audioFrame.HideAtShowing = true;

    // Rewinds the audio to start after playing
    audioFrame.RewindAudio = true;

    // Save the PPTX file to disk
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

## **Extract Audio**
Aspose.Slides for .NET allows you to extract the sound used in slide show transitions. For example, you can extract the sound used in a specific slide.

1. Create an instance of the [Presentation ](https://apireference.aspose.com/slides/net/aspose.slides/presentation)class and load the presentation with the audio.
2. Get a slide's reference through its index.
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
