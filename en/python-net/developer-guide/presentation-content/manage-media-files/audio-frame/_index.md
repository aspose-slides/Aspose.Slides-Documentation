---
title: Manage Audio Frames in Presentations Using Python
linktitle: Audio Frame
type: docs
weight: 10
url: /python-net/audio-frame/
keywords:
- audio
- audio frame
- thumbnail
- add audio
- audio properties
- audio options
- extract audio
- WebVTT
- Python
- Aspose.Slides
description: "Embed audio in slides, change the audio icon, configure playback, manage WebVTT captions, and extract slide transition sounds with Aspose.Slides for Python via .NET."
---

## **Overview**

An audio frame lets you play a sound on a slide. With Aspose.Slides for Python via .NET, you can embed an audio clip, choose the image that represents it, adjust playback, and attach captions. You can also retrieve a sound assigned to a slide transition.

## **Create Audio Frames**

Use [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) to embed a local audio clip on the first slide. The first two coordinates position the frame on the slide, and the next two values set its width and height, all in points. This example sets [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) to start the clip automatically and [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) to the loud preset.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 150, 100, 100, audio_stream)
    audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
    audio_frame.volume = slides.AudioVolumeMode.LOUD

    presentation.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Change the Audio Frame Thumbnail**

By default, an audio frame displays a speaker icon. To display a custom thumbnail, add an image to the presentation with [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) and assign it to the frame’s [picture_format.picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/) property. The example uses a JPEG as the thumbnail for an embedded audio clip.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("eagle.jpeg", "rb") as image_stream:
        thumbnail = presentation.images.add_image(image_stream)

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_stream)
    audio_frame.picture_format.picture.image = thumbnail

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Change Audio Play Options**

PowerPoint’s **Audio Options** controls determine when a clip starts, how loud it sounds, and how it behaves during a slide show.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint control | Aspose.Slides property |
| --- | --- |
| Start | [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) |
| Volume preset | [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) |
| Play Across Slides | [play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) |
| Loop until Stopped | [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) |
| Hide During Show | [hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) |
| Rewind after Playing | [rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) |
| Fade In | [fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) |
| Fade Out | [fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) |
| Trim Audio start time | [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) |
| Trim Audio end time | [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) |
| Volume slider | [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) |

The example finds the first audio frame on the first slide, sets [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) to start playback on a click, and selects the low volume preset. The clip continues across slides with looping disabled. The icon stays hidden during the show, and the clip rewinds after playback.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.play_mode = slides.AudioPlayModePreset.ON_CLICK
        audio_frame.volume = slides.AudioVolumeMode.LOW
        audio_frame.play_across_slides = True
        audio_frame.play_loop_mode = False
        audio_frame.hide_at_showing = True
        audio_frame.rewind_audio = True
        
        presentation.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

For a clip longer than 3.5 seconds, this example skips the first 1.5 seconds and the last 2 seconds. [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) measures the duration to omit from the end of the clip. To get the end time shown in PowerPoint, subtract that offset from the full clip duration. The trimmed clip fades in over 200 milliseconds and fades out over 500 milliseconds. All four properties take values in milliseconds.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)
    audio_frame.trim_from_start = 1500.0
    audio_frame.trim_from_end = 2000.0
    audio_frame.fade_in_duration = 200.0
    audio_frame.fade_out_duration = 500.0

    presentation.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

To set the playback volume to a specific percentage, use [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/). This example sets the first audio frame on the first slide to 85%.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.volume_value = 85.0
        presentation.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Manage Audio Captions**

Each audio frame has a [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/caption_tracks/) collection. Use it to attach WebVTT captions to the clip, export existing tracks, or remove them.

### **Add Audio Captions**

The example embeds an audio clip on the first slide and uses [CaptionsCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/add/) to attach a local WebVTT track. The first argument supplies the track label, and the second identifies the file containing the timed captions.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio_stream)
    audio_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **Extract Audio Captions**

This example exports each caption track attached to an audio frame on the first slide. It writes the track’s [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/captions/binary_data/) to a WebVTT file and uses its [caption_id](https://reference.aspose.com/slides/python-net/aspose.slides/captions/caption_id/) as the file name so that each track has a separate output.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                with open(f"{track.caption_id}.vtt", "wb") as output:
                    output.write(track.binary_data)
```

### **Remove Audio Captions**

Use [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) or [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) to delete an individual track. The example uses [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) to remove all captions from the first audio frame on the first slide while preserving the clip.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.caption_tracks.clear()
        presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **Find a Line in Audio Captions**

To find a line in the audio captions on the first slide, read each track's [data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) in memory. In a plain-text WebVTT cue, the timing line contains `-->`, the caption lines follow it, and a blank line ends the cue. This example prints the track label and each caption line containing “café”.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                in_cue = False
                for line in track.data_as_string.splitlines():
                    if not line:
                        in_cue = False
                    elif "-->" in line:
                        in_cue = True
                    elif in_cue and "café" in line.casefold():
                        print(f"{track.label}: {line}")
```

## **Extract Audio**

A slide transition can have its own sound. To retrieve it, read the transition’s [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) property. The example accesses the sound’s [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) and prints its size in bytes. If the first slide has no transition sound, it prints a message instead.

```python
import aspose.slides as slides

with slides.Presentation("AudioSlide.pptx") as presentation:
    slide = presentation.slides[0]

    sound = slide.slide_show_transition.sound
    if sound is None:
        print("The first slide has no transition sound.")
    else:
        audio_data = sound.binary_data
        print(f"Transition sound: {len(audio_data)} bytes.")
```

## **FAQ**

**Can I reuse the same audio clip across multiple slides without duplicating it?**

Yes. Add the clip once to the presentation’s [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) and pass the same audio object to [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) for each slide.

**Can I replace the sound in an existing audio frame?**

Yes. For a linked sound, update [link_path_long](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) to point to the replacement file. For an embedded sound, assign another clip from the presentation’s audio collection to [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/). Both approaches preserve the existing frame.

**Does trimming change the audio data stored in the presentation?**

No. [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) and [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) set playback boundaries. You can still retrieve the full clip from [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/).
