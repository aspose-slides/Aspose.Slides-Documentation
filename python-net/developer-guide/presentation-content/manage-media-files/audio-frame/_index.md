---
title: Audio Frame
type: docs
weight: 10
url: /python-net/audio-frame/
keywords: "Add audio, Audio frame, Audio properties, Extract audio, Python, Aspose.Slides for Python via .NET"
description: "Add audio to PowerPoint presentation in Python"
---

## **Creating Audio Frame**
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

PowerPoint Audio options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) properties:
- Audio Options **Start** drop-down list matches the [AudioFrame.PlayMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) property 
- Audio Options **Volume** matches the [AudioFrame.Volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/)  property 
- Audio Options **Play Across Slides** matches the [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/)  property 
- Audio Options **Loop until Stopped** matches the [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/)  property 
- Audio Options **Hide During Show** matches the  [AudioFrame.HideAtShowing ](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/)  property 
- Audio Options **Rewind after Playing** matches the [AudioFrame.RewindAudio ](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) property 

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

