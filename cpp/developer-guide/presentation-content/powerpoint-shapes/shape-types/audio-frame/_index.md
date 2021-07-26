---
title: Audio Frame
type: docs
weight: 10
url: /cpp/audio-frame/
---

## **Create Audio Frame**
Aspose.Slides for C++ allows developers to add audio files in their slides. These audio files are embedded in the slides as Audio Frames. An Audio Frame contains the embedded audio file. In this topic, we will discuss that how can developers embed audio frames in their slides using Aspose.Slides for C++. To add an Embedded Audio Frame in a slide using Aspose.Slides for C++, please follow the steps below:

- Create an instance of [Presentation class](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation)
- Obtain the reference of a slide by using its Index
- Open the Audio File Stream to be embedded in the slide
- Add the Embedded Audio Frame (containing audio file) into the slide
- Set [PlayMode](https://apireference.aspose.com/slides/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) and Volume exposed by [IAudioFrame](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_audio_frame) object
- Write the modified presentation as a PPTX file

In the example given below, we have added an Embedded Audio Frame into the slide.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddAudioFrame-AddAudioFrame.cpp" >}}


## **Extract Audio**
Aspose.Slides for C++ allows developers to extract the sound that is used in slide show transitions associated with slides. To extract the audio, please follow the steps below:

- Create an instance of Presentation class and load the presentation with slide transitions
- Access the desired slide
- Access the slideshow transitions for slide
- Extract the sound in byte data

``` cpp
String presName = u"AudioSlide.pptx";

// Instantiate Presentation class that represents the presentation file
auto pres = System::MakeObject<Presentation>(presName);

// Access the desired slide
auto slide = pres->get_Slides()->idx_get(0);

// Get the slideshow transition effects for slide
auto transition = slide->get_SlideShowTransition();

// Extract sound in byte array
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```
