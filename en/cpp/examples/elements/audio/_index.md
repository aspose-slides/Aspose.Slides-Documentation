---
title: Audio
type: docs
weight: 70
url: /cpp/examples/elements/audio/
keywords:
- code example
- audio
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Discover Aspose.Slides for C++ audio examples: insert, play, trim, and extract sound in PPT, PPTX, and ODP presentations with clear C++ code."
---

This article demonstrates how to embed audio frames and control playback with **Aspose.Slides for C++**. The following examples show basic audio operations.

## **Add an Audio Frame**

Insert an empty audio frame that can later hold embedded sound data.

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Create an empty audio frame (audio will be embedded later).
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **Access an Audio Frame**

This code retrieves the first audio frame on a slide.

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Access the first audio frame on the slide.
    auto firstAudio = SharedPtr<IAudioFrame>();
    for (auto i = 0; i < slide->get_Shapes()->get_Count(); ++i) {
        auto shape = slide->get_Shape(i);
        if (ObjectExt::Is<IAudioFrame>(shape)) {
            firstAudio = ExplicitCast<IAudioFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Remove an Audio Frame**

Delete a previously added audio frame.

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Remove the audio frame.
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **Set Audio Playback**

Configure the audio frame to play automatically when the slide appears.

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Play automatically when the slide appears.
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```
