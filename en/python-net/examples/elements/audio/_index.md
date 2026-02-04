---
title: Audio
type: docs
weight: 70
url: /python-net/examples/elements/audio/
keywords:
- audio
- audio frame
- add audio
- access audio
- remove audio
- audio playback
- code examples
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Work with audio in Python using Aspose.Slides: add, replace, extract, and trim sounds, set volume and playback for slides and shapes in PowerPoint and OpenDocument."
---

Illustrates how to embed audio frames and control playback with **Aspose.Slides for Python via .NET**. The following examples show basic audio operations.

## **Add an Audio Frame**

The code example below adds an audio frame on a presentation slide.

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **Access an Audio Frame**

This code retrieves the first audio frame from the slide.

```py
def access_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        first_audio_frame = None
        for shape in slide.shapes:
            if isinstance(shape, slides.AudioFrame):
                first_audio_frame = shape
                break
```

## **Remove an Audio Frame**

Delete a previously added audio frame.

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Assuming the first shape is an AudioFrame.
        audio_frame = slide.shapes[0]

        # Remove the audio frame.
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Audio Playback**

Configure the audio frame to play automatically when the slide appears.

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Assuming the first shape is an AudioFrame.
        audio_frame = slide.shapes[0]

        # Play automatically when the slide appears.
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```
