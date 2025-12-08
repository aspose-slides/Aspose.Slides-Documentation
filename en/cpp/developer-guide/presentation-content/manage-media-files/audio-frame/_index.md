---
title: Manage Audio in Presentations Using C++
linktitle: Audio Frame
type: docs
weight: 10
url: /cpp/audio-frame/
keywords:
- audio
- audio frame
- thumbnail
- add audio
- audio properties
- audio options
- extract audio
- C++
- Aspose.Slides
description: "Create and control audio frames in Aspose.Slides for C++—code examples to embed, trim, loop, and configure playback across PPT, PPTX, and ODP presentations."
---

## **Create Audio Frames**

Aspose.Slides for C++ allows you to add audio files to slides. The audio files are embedded in slides as audio frames. 

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
2. Get a slide's reference through its index.
3. Load the audio file stream you want to embed in the slide.
4. Add the embedded audio frame (containing the audio file) to the slide.
5. Set [PlayMode](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) and `Volume` exposed by the [IAudioFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_audio_frame) object.
6. Save the modified presentation.

This C++ code shows you how to add an embedded audio frame to a slide:

``` cpp
// Instantiates a Presentation class that represents a presentation file
auto pres = System::MakeObject<Presentation>();

// Gets the first slide
auto sld = pres->get_Slides()->idx_get(0);

// Loads the wav sound file to stream
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// Adds the Audio Frame
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// Sets the Play Mode and Volume of the Audio
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// Writes the PowerPoint file to disk
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Change the Audio Frame Thumbnail**

When you add an audio file to a presentation, the audio appears as a frame with a standard default image (see the image in the section below). You change the audio frame's thumbnail (set your preferred image).

This C++ code shows you how to change an audio frame's thumbnail or preview image:

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// Adds an audio frame to the slide with a specified position and size.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// Adds an image to presentation resources.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// Sets the image for the audio frame.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
//Saves the modified presentation to disk
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Change Audio Play Options**

Aspose.Slides for C++ allows you to change options that control an audio's playback or properties. For example, you can adjust an audio's volume, set the audio to play looped, or even hide the audio icon.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/) methods:

- **Start** drop-down list matches the [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playmode/) method 
- **Volume** matches the [AudioFrame::set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_volume/) method 
- **Play Across Slides** matches the [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playacrossslides/) method 
- **Loop until Stopped** matches the [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playloopmode/) method 
- **Hide During Show** matches the  [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_hideatshowing/) method 
- **Rewind after Playing** matches the [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_rewindaudio/) method 

PowerPoint **Editing** options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/) properties:

- **Fade In** matches the [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_fadeinduration/) method
- **Fade Out** matches the [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_fadeoutduration/) method
- **Trim Audio Start Time** matches the [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_trimfromstart/) method
- **Trim Audio End Time** value equals the audio duration minus the value of [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_trimfromend/) method

The PowerPoint **Volume controll** on the audio control panel corresponds to the [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_volumevalue/) method. It lets you change the audio volume as a percentage.

This is how you change the Audio Play options:

1. [Сreate](#creating-audio-frame) or get the Audio Frame.
2. Set new values for the Audio Frame properties you want to adjust.
3. Save the modified PowerPoint file.

This C++ code demonstrates an operation in which an audio's options are adjusted:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// GetS a shape
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Casts the shape to an AudioFrame shape
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// Sets the Play mode to play on click
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Sets the Volume to Low
audioFrame->set_Volume(AudioVolumeMode::Low);

// Sets the audio to play across slides
audioFrame->set_PlayAcrossSlides(true);

// Disables loop for the audio
audioFrame->set_PlayLoopMode(false);

// Hides the AudioFrame during the slide show
audioFrame->set_HideAtShowing(true);

// Rewinds the audio to start after playing
audioFrame->set_RewindAudio(true);

// Saves the PowerPoint file to disk
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

This C++ example shows how to add a new audio frame with embedded audio, trim it, and set the fade durations:

```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// Sets the trimming start offset to 1.5 seconds
audioFrame->set_TrimFromStart(1500);
// Sets the trimming end offset to 2 seconds
audioFrame->set_TrimFromEnd(2000);

// Sets the fade-in duration to 200 ms
audioFrame->set_FadeInDuration(200);
// Sets the fade-out duration to 500 ms
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

The following code sample shows how to retrieve an audio frame with embedded audio and set its volume to 85%:

```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// Gets an audio frame shape
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// Sets the audio volume to 85%
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

## **Extract Audio**
Aspose.Slides allows you to extract the sound used in slide show transitions. For example, you can extract the sound used in a specific slide.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class and load the presentation containing the audio.
2. Get the relevant slide's reference through its index.
3. Access the slideshow transitions for the slide.
4. Extract the sound in byte data.

This C++ code shows you how to extract the audio used in a slide:

``` cpp
String presName = u"AudioSlide.pptx";

// Instantiates a Presentation class that represents a presentation file
auto pres = System::MakeObject<Presentation>(presName);

// Accesses the desired slide
auto slide = pres->get_Slides()->idx_get(0);

// Gets the slideshow transition effects for the slide
auto transition = slide->get_SlideShowTransition();

// Extracts the sound in byte array
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```

## **FAQ**

**Can I reuse the same audio asset across multiple slides without inflating the file size?**

Yes. Add the audio once to the presentation’s shared [audio collection](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) and create additional audio frames that reference that existing asset. This avoids duplicating media data and keeps the presentation size under control.

**Can I replace the sound in an existing audio frame without recreating the shape?**

Yes. For a linked sound, update the [link path](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_linkpathlong/) to point to the new file. For an embedded sound, swap the [embedded audio](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_embeddedaudio/) object with another one from the presentation’s [audio collection](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/). The frame’s formatting and most playback settings remain intact.

**Does trimming change the underlying audio data stored in the presentation?**

No. Trimming adjusts only the playback boundaries. The original audio bytes remain untouched and accessible through the embedded audio or the presentation’s audio collection.
