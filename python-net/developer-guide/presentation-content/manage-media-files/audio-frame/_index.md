---
title: Audio Frame
type: docs
weight: 10
url: /python-net/audio-frame/
keywords: "Add audio, Audio frame, Audio properties, Extract audio, Python, Aspose.Slides for Python via .NET"
description: "Add audio to PowerPoint presentation in Python"
---

## **Creating Audio Frame**
Aspose.Slides for Python via .NET allows you to add audio files to slides. Audio files are embedded in slides as audio frames. 
To add an audio file in a slide using Aspose.Slides for Python via .NET, please follow these steps:

1. Create an instance of the [Presentation ](https://apireference.aspose.com/slides/python-net/aspose.slides/presentation)class.
2. Obtain the reference of a slide by using its Index.
3. Open the audio file stream to be embedded in the slide.
4. Add the embedded audio Frame (containing the audio file) to the slide.
5. Set [PlayMode](https://apireference.aspose.com/slides/python-net/aspose.slides/audioplaymodepreset) and Volume exposed by [IAudioFrame](https://apireference.aspose.com/slides/python-net/aspose.slides/audioframe) object.
6. Write the modified presentation as a PPTX file.

This Python shows you how to add an embedded audio frame into a slide:

```py
import aspose.slides as slides

# Instantiate Presentation class that represents the presentation file
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Load the wav sound file to stream
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Add Audio Frame
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Set Play Mode and Volume of the Audio
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # Write the PPTX file to disk
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Change Audio Frame properties**
Aspose.Slides for Python via .NET allows you to change the properties for audio frames. 

This is the Audio Options pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

These are the correspondences between PowerPoint Audio Options and [AudioFrame](https://apireference.aspose.com/slides/python-net/aspose.slides/audioframe) properties:
- Audio Options **Start** drop-down list matches the [AudioFrame.PlayMode](https://apireference.aspose.com/slides/python-net/aspose.slides/audioframe/properties/playmode) property 
- Audio Options **Volume** matches the [AudioFrame.Volume](https://apireference.aspose.com/slides/python-net/aspose.slides/audioframe/properties/volume)  property 
- Audio Options **Play Across Slides** matches the [AudioFrame.PlayAcrossSlides](https://apireference.aspose.com/slides/python-net/aspose.slides/audioframe/properties/playacrossslides)  property 
- Audio Options **Loop until Stopped** matches the [AudioFrame.PlayLoopMode](https://apireference.aspose.com/slides/python-net/aspose.slides/audioframe/properties/playloopmode)  property 
- Audio Options **Hide During Show** matches the  [AudioFrame.HideAtShowing ](https://apireference.aspose.com/slides/python-net/aspose.slides/audioframe/properties/hideatshowing)  property 
- Audio Options **Rewind after Playing** matches the [AudioFrame.RewindAudio ](https://apireference.aspose.com/slides/python-net/aspose.slides/audioframe/properties/rewindaudio) property 

To change the Audio Frame properties, please follow these steps:

1. [Сreate](#create-audio-frame) or get the Audio Frame.
2. Set new values for the Audio Frame properties you need. 
3. Save the modified PPTX file.

This sample code demonstrates the operation:

```py 
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Get the AudioFrame shape
    audioFrame = pres.slides[0].shapes[0]

    # Change Play mode to play on click
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Set Volume to Low
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Set audio to play across slides
    audioFrame.play_across_slides = True

    # Set audio to not loop
    audioFrame.play_loop_mode = False

    # Hide AudioFrame during the slide show
    audioFrame.hide_at_showing = True

    # Rewind audio to start after playing
    audioFrame.rewind_audio = True

    # Save the PPTX file to disk
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Extract Audio**
Aspose.Slides for Python via .NET allows you to extract the sound used in slide show transitions. The sound is associated with slides.

To extract the audio, please follow these steps:

1. Create an instance of the Presentation class and load the presentation with slide transitions.
2. Access the desired slide.
3. Access the slideshow transitions for the slide.
4. Extract the sound in byte data.

This code in Python shows you how to extract the audio used in a slide:

```py
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # Access the desired slide
    slide = pres.slides[0]  

    # Get the slideshow transition effects for slide
    transition = slide.slide_show_transition

    #Extract sound in byte array
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```

