---
title: Manage Audio in Presentations Using Python
linktitle: Audio Frame
type: docs
weight: 10
url: /python-net/audio-frame/
keywords:
- add audio
- embed audio
- audio frame
- audio file
- audio properties
- extract audio
- retrieve audio
- change audio
- play options
- play mode
- play across slides
- loop until stopped
- hide during show
- rewind after playing
- audio volume
- default image
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Easily add, extract & manage audio frames in PPT, PPTX and ODP with Aspose.Slides for Python via .NET. Explore code examples & boost your presentations today."
---

## **Create Audio Frames**

Aspose.Slides for Python via .NET allows you to add audio files to slides. The audio files are embedded in slides as audio frames. 

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a slide's reference through its index.
3. Load the audio file stream you want to embed in the slide.
4. Add the embedded audio frame (containing the audio file) to the slide.
5. Set [PlayMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioplaymodepreset) and `Volume` exposed by the [IAudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) object.
6. Save the modified presentation.

This Python code shows you how to add an embedded audio frame to a slide:

```python
import aspose.slides as slides

# InstantiateS a presentation class that represents a presentation file
with slides.Presentation() as pres:
    # Gets the first slide
    sld = pres.slides[0]

    # Loads the wav sound file to stream
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Adds the Audio Frame
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Sets the Play Mode and Volume of the Audio
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # Writes the PowerPoint file to disk
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Change Audio Frame Thumbnail**

When you add an audio file to a presentation, the audio appears as a frame with a standard default image (see the image in the section below). You change the audio frame's thumbnail (set your preferred image).

This Python code shows you how to change an audio frame's thumbnail or preview image:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Adds an audio frame to the slide with a specified position and size.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # Adds an image to presentation resources.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # Sets the image for the audio frame.
        audioFrame.picture_format.picture.image = audioImage
        
        #Saves the modified presentation to disk
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Change Audio Play Options**

Aspose.Slides for Python via .NET allows you to change options that control an audio's playback or properties. For example, you can adjust an audio's volume, set the audio to play looped, or even hide the audio icon.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) properties:

- **Start** drop-down list matches the [AudioFrame.play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) property 
- **Volume** matches the [AudioFrame.volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) property 
- **Play Across Slides** matches the [AudioFrame.play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) property 
- **Loop until Stopped** matches the [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) property 
- **Hide During Show** matches the [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) property 
- **Rewind after Playing** matches the [AudioFrame.rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) property 

PowerPoint **Editing** options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) properties:

- **Fade In** matches the [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) property 
- **Fade Out** matches the [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) property 
- **Trim Audio Start Time** matches the [AudioFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) property 
- **Trim Audio End Time** value equals the audio duration minus the value of [AudioFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) property

The PowerPoint **Volume controll** on the audio control panel corresponds to the [AudioFrame.volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) property. It lets you change the audio volume as a percentage.

This is how you change the Audio Play options:

1. [Сreate](#create-audio-frame) or get the Audio Frame.
2. Set new values for the Audio Frame properties you want to adjust.
3. Save the modified PowerPoint file.

This Python code demonstrates an operation in which an audio's options are adjusted:

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Gets the AudioFrame shape
    audioFrame = pres.slides[0].shapes[0]

    # Sets the Play mode to play on click
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Sets the Volume to Low
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Sets the audio to play across slides
    audioFrame.play_across_slides = True

    # Disables loop for the audio
    audioFrame.play_loop_mode = False

    # Hides the AudioFrame during the slide show
    audioFrame.hide_at_showing = True

    # Rewinds the audio to start after playing
    audioFrame.rewind_audio = True

    # Saves the PowerPoint file to disk
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

This Python example shows how to add a new audio frame with embedded audio, trim it, and set the fade durations:

```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # Sets the trimming start offset to 1.5 seconds
    audio_frame.trim_from_start = 1500.0
    # Sets the trimming end offset to 2 seconds
    audio_frame.trim_from_end = 2000.0

    # Sets the fade-in duration to 200 ms
    audio_frame.fade_in_duration = 200.0
    # Sets the fade-out duration to 500 ms
    audio_frame.fade_out_duration = 500.0

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

The following code sample shows how to retrieve an audio frame with embedded audio and set its volume to 85%:

```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Gets an audio frame shape
    audio_frame = pres.slides[0].shapes[0]

    # Sets the audio volume to 85%
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Extract Audio**
Aspose.Slides for Python via .NET allows you to extract the sound used in slide show transitions. For example, you can extract the sound used in a specific slide.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and load the presentation containing the audio.
2. Get the relevant slide's reference through its index.
3. Access the slideshow transitions for the slide.
4. Extract the sound in byte data.

This Python code shows you how to extract the audio used in a slide:

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # Accesses the desired slide
    slide = pres.slides[0]  

    # Gets the slideshow transition effects for the slide
    transition = slide.slide_show_transition

    #Extracts the sound in byte array
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```

## **FAQ**

**Can I reuse the same audio asset across multiple slides without inflating the file size?**

Yes. Add the audio once to the presentation’s shared [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) and create additional audio frames that reference that existing asset. This avoids duplicating media data and keeps the presentation size under control.

**Can I replace the sound in an existing audio frame without recreating the shape?**

Yes. For a linked sound, update the [link path](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) to point to the new file. For an embedded sound, swap the [embedded audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) object with another one from the presentation’s [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/). The frame’s formatting and most playback settings remain intact.

**Does trimming change the underlying audio data stored in the presentation?**

No. Trimming adjusts only the playback boundaries. The original audio bytes remain untouched and accessible through the embedded audio or the presentation’s audio collection.
