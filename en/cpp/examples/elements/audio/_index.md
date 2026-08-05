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
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Create an empty audio frame (audio will be embedded later).
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50.0f, 50.0f, 100.0f, 100.0f, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **Access an Audio Frame**

This code retrieves the first audio frame on a slide.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50.0f, 50.0f, 100.0f, 100.0f, MakeObject<MemoryStream>());

    // Access the first audio frame on the slide.
    auto firstAudio = SharedPtr<IAudioFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAudioFrame>(shape))
        {
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
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50.0f, 50.0f, 100.0f, 100.0f, MakeObject<MemoryStream>());

    // Remove the audio frame.
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **Set Audio Playback**

Configure the audio frame to play automatically when the slide appears.

```cpp
#include <DOM/AudioPlayModePreset.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50.0f, 50.0f, 100.0f, 100.0f, MakeObject<MemoryStream>());

    // Play automatically when the slide appears.
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```
