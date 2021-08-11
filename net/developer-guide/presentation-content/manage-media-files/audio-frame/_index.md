---
title: Audio Frame
type: docs
weight: 10
url: /net/audio-frame/
---

## **Creating Audio Frame**
Aspose.Slides for .NET allows you to add audio files to slides. Audio files are embedded in slides as audio frames. 
To add an audio file in a slide using Aspose.Slides for .NET, please follow these steps:

1. Create an instance of the [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class.
2. Obtain the reference of a slide by using its Index.
3. Open the audio file stream to be embedded in the slide.
4. Add the embedded audio Frame (containing the audio file) to the slide.
5. Set [PlayMode](https://apireference.aspose.com/net/slides/aspose.slides/audioplaymodepreset) and Volume exposed by [IAudioFrame](https://apireference.aspose.com/net/slides/aspose.slides/audioframe) object.
6. Write the modified presentation as a PPTX file.

This C# shows you how to add an embedded audio frame into a slide:

```c#
// Instantiate Presentation class that represents the presentation file
using (Presentation pres = new Presentation())
{

    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Load the wav sound file to stream
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Add Audio Frame
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Set Play Mode and Volume of the Audio
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // Write the PPTX file to disk
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **Change Audio Frame properties**
Aspose.Slides for .NET allows you to change the properties for audio frames. 

This is the Audio Options pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

These are the correspondences between PowerPoint Audio Options and [AudioFrame](https://apireference.aspose.com/net/slides/aspose.slides/audioframe) properties:
- Audio Options **Start** drop-down list matches the [AudioFrame.PlayMode](https://apireference.aspose.com/slides/net/aspose.slides/audioframe/properties/playmode) property 
- Audio Options **Volume** matches the [AudioFrame.Volume](https://apireference.aspose.com/slides/net/aspose.slides/audioframe/properties/volume)  property 
- Audio Options **Play Across Slides** matches the [AudioFrame.PlayAcrossSlides](https://apireference.aspose.com/slides/net/aspose.slides/audioframe/properties/playacrossslides)  property 
- Audio Options **Loop until Stopped** matches the [AudioFrame.PlayLoopMode](https://apireference.aspose.com/slides/net/aspose.slides/audioframe/properties/playloopmode)  property 
- Audio Options **Hide During Show** matches the  [AudioFrame.HideAtShowing ](https://apireference.aspose.com/slides/net/aspose.slides/audioframe/properties/hideatshowing)  property 
- Audio Options **Rewind after Playing** matches the [AudioFrame.RewindAudio ](https://apireference.aspose.com/slides/net/aspose.slides/audioframe/properties/rewindaudio) property 

To change the Audio Frame properties, please follow these steps:

1. [Сreate](#create-audio-frame) or get the Audio Frame.
2. Set new values for the Audio Frame properties you need. 
3. Save the modified PPTX file.

This sample code demonstrates the operation:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Get the AudioFrame shape
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Change Play mode to play on click
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Set Volume to Low
    audioFrame.Volume = AudioVolumeMode.Low;

    // Set audio to play across slides
    audioFrame.PlayAcrossSlides = true;

    // Set audio to not loop
    audioFrame.PlayLoopMode = false;

    // Hide AudioFrame during the slide show
    audioFrame.HideAtShowing = true;

    // Rewind audio to start after playing
    audioFrame.RewindAudio = true;

    // Save the PPTX file to disk
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

## **Extract Audio**
Aspose.Slides for .NET allows you to extract the sound used in slide show transitions. The sound is associated with slides.

To extract the audio, please follow these steps:

1. Create an instance of the Presentation class and load the presentation with slide transitions.
2. Access the desired slide.
3. Access the slideshow transitions for the slide.
4. Extract the sound in byte data.

This code in C# shows you how to extract the audio used in a slide:

```c#
string presName = "AudioSlide.pptx";

// Instantiate Presentation class that represents the presentation file
Presentation pres = new Presentation(presName);

// Access the desired slide
ISlide slide = pres.Slides[0];

// Get the slideshow transition effects for slide
ISlideShowTransition transition = slide.SlideShowTransition;

//Extract sound in byte array
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```

