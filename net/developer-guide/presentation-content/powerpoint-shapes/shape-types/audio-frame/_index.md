---
title: Audio Frame
type: docs
weight: 10
url: /net/audio-frame/
---

## **Create Audio Frame**
Aspose.Slides for .NET allows developers to add audio files in their slides. These audio files are embedded in the slides as Audio Frames . An Audio Frame contains the embedded audio file. In this topic, we will discuss that how can developers embed audio frames in their slides using Aspose.Slides for .NET . To add an Embedded Audio Frame in a slide using Aspose.Slides for .NET , please follow the steps below:

- Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/aspose.slides/)
- Obtain the reference of a slide by using its Index
- Open the Audio File Stream to be embedded in the slide
- Add the Embedded Audio Frame (containing audio file) into the slide
- Set [PlayMode](https://apireference.aspose.com/net/slides/aspose.slides/audioplaymodepreset) and Volume exposed by [IAudioFrame](https://apireference.aspose.com/net/slides/aspose.slides/audioframe) object
- Write the modified presentation as a PPTX file

In the example given below, we have added an Embedded Audio Frame into the slide.

```c#
// Instantiate Prseetation class that represents the PPTX
using (Presentation pres = new Presentation())
{

    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Load the wav sound file to stram
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Add Audio Frame
    IAudioFrame af = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Set Play Mode and Volume of the Audio
    af.PlayMode = AudioPlayModePreset.Auto;
    af.Volume = AudioVolumeMode.Loud;

    //Write the PPTX file to disk
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```



## **Extract Audio**
Aspose.Slides for .NET allows developers to extract the sound that is used in slide show transitions associated with slides. To extract the audio, please follow the steps below:

- Create an instance of Presentation class and load the presentation with slide transitions
- Access the desired slide
- Access the slideshow transitions for slide
- Extract the sound in byte data

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

