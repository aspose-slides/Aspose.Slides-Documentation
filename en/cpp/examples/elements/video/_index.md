---
title: Video
type: docs
weight: 80
url: /cpp/examples/elements/video/
keywords:
- code example
- video
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Add and control videos with Aspose.Slides for C++: insert, play, trim, set poster frames, and export with C++ examples for PPT, PPTX, and ODP presentations."
---

This article demonstrates how to embed video frames and set playback options using **Aspose.Slides for C++**.

## **Add a Video Frame**

Insert an empty video frame onto a slide.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IVideoFrame.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Add a video.
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **Access a Video Frame**

Retrieve the first video frame added to a slide.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IVideoFrame.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Access the first video frame on the slide.
    auto firstVideo = SharedPtr<IVideoFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            firstVideo = ExplicitCast<IVideoFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Remove a Video Frame**

Delete a video frame from the slide.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IVideoFrame.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Remove the video frame.
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **Set Video Playback**

Configure the video to play automatically when the slide is displayed.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IVideoFrame.h>
#include <DOM/Presentation.h>
#include <DOM/VideoPlayModePreset.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Configure the video to play automatically.
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```
