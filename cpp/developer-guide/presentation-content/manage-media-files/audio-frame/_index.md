---
title: Audio Frame
type: docs
weight: 10
url: /cpp/audio-frame/
---

## **Creating Audio Frame**
Aspose.Slides for C++ allows you to add audio files to slides. Audio files are embedded in slides as audio frames. 
To add an audio file in a slide using Aspose.Slides for C++, please follow these steps:

1. Create an instance of the [Presentation ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation)class.
2. Obtain the reference of a slide by using its Index.
3. Open the audio file stream to be embedded in the slide.
4. Add the embedded audio Frame (containing the audio file) to the slide.
5. Set [PlayMode](https://apireference.aspose.com/slides/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) and Volume exposed by [IAudioFrame](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_audio_frame) object.
6. Write the modified presentation as a PPTX file.

This code in C++ shows you how to add an embedded audio frame into a slide:

``` cpp
// Instantiate Presentation class that represents the presentation file
auto pres = System::MakeObject<Presentation>();

// Get the first slide
auto sld = pres->get_Slides()->idx_get(0);

// Load the wav sound file to stream
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// Add Audio Frame
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// Set Play Mode and Volume of the Audio
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// Write the PPTX file to disk
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Change Audio Frame properties**
Aspose.Slides for C++ allows you to change the properties for audio frames. 

This is the Audio Options pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

These are the correspondences between PowerPoint Audio Options and [AudioFrame](https://apireference.aspose.com/slides/cpp/class/aspose.slides.audio_frame) methods:
- Audio Options **Start** drop-down list matches the [AudioFrame::get_PlayMode()](https://apireference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a5379c1a9c1166234d674b32413215a2b) method 
- Audio Options **Volume** matches the [AudioFrame::get_Volume()](https://apireference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#af06a3176684b6a13326bc8526747d9f3)  method 
- Audio Options **Play Across Slides** matches the [AudioFrame::get_PlayAcrossSlides()](https://apireference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a3c6ffc45b319ce127384fc37e188f7b0)  method 
- Audio Options **Loop until Stopped** matches the [AudioFrame::get_PlayLoopMode()](https://apireference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a99b5b9cc650e93eba813bd8b2371315b)  method 
- Audio Options **Hide During Show** matches the  [AudioFrame::get_HideAtShowing() ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#abd008322e6a3d7d06bed527e329a9082)  method 
- Audio Options **Rewind after Playing** matches the [AudioFrame::get_RewindAudio() ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a4900e1df6477db16e8cdd859ad54e637) method 

To change the Audio Frame properties, please follow these steps:

1. [Сreate](#creating-audio-frame) or get the Audio Frame.
2. Set new values for the Audio Frame properties you need. 
3. Save the modified PPTX file.

This sample code demonstrates the operation:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// Get a shape
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Cast the shape to AudioFrame shape
auto audioFrame = System::DynamicCast<AudioFrame>(shape);

// Change Play mode to play on click
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Set Volume to Low
audioFrame->set_Volume(AudioVolumeMode::Low);

// Set audio to play across slides
audioFrame->set_PlayAcrossSlides(true);

// Set audio to not loop
audioFrame->set_PlayLoopMode(false);

// Hide AudioFrame during the slide show
audioFrame->set_HideAtShowing(true);

// Rewind audio to start after playing
audioFrame->set_RewindAudio(true);

// Save the PPTX file to disk
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

## **Extract Audio**
Aspose.Slides for C++ allows you to extract the sound used in slide show transitions. The sound is associated with slides.

To extract the audio, please follow these steps:

1. Create an instance of the Presentation class and load the presentation with slide transitions.
2. Access the desired slide.
3. Access the slideshow transitions for the slide.
4. Extract the sound in byte data.

This code in C++ shows you how to extract the audio used in a slide:

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