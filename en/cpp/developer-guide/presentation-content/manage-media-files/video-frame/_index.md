---
title: Manage Video Frames in Presentations Using C++
linktitle: Video Frame
type: docs
weight: 10
url: /cpp/video-frame/
keywords:
- add video
- create video
- embed video
- extract video
- retrive video
- video frame
- web source
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Learn to programmatically add and extract video frames in PowerPoint and OpenDocument slides using Aspose.Slides for C++. Fast how-to guide."
---

## **Introduction**

A well-placed video in a presentation can make your message more compelling and increase engagement levels with your audience. 

PowerPoint allows you to add videos to a slide in a presentation in two ways:

* Add or embed a local video (stored on your machine)
* Add an online video (from a web source such as YouTube).

To allow you to add videos (video objects) to a presentation, Aspose.Slides provides the [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) interface, [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) interface, and other relevant types. 

## **Create an Embedded Video Frame**

If the video file you want to add to your slide is stored locally, you can create a video frame to embed the video in your presentation. 

1. Create an instance of the [Presentation ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)class.
1. Get a slide's reference through its index. 
1. Add an [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) object and pass the video file path to embed the video with the presentation. 
1. Add an [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) object to create a frame for the video.  
1. Save the modified presentation. 

This C++ code shows you how to add a video stored locally to a presentation:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Loads the video
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Gets the first slide and adds a videoframe
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Saves the presentation to disk
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

Alternatively, you can add a video by passing its file path directly to the [AddVideoFrame()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/) method:

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```


## **Create a Video Frame with Video from a Web Source**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) support YouTube videos in presentations. If the video you want to use is available online (e.g. on YouTube), you can add it to your presentation through its web link. 

1. Create an instance of [Presentation ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)class
1. Get a slide's reference through its index. 
1. Add an [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) object and pass the link to the video.
1. Set a thumbnail for the video frame. 
1. Save the presentation. 

This C++ code shows you how to add a video from the web to a slide in a PowerPoint presentation:

```c++
// The path to the documents directory.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Instantiates a Presentation object that represents a presentation file
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accesses the first slide
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Adds a Video Frame 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Sets the Play Mode and Volume of the Video
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Saves the presentation to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Manage Video Captions**

Aspose.Slides allows you to manage closed captions for video frames in PowerPoint presentations. Captions are stored in WebVTT format and are exposed through the [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) method.

**Add Captions to a Video Frame**

To add captions to a video frame:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. Add a video to the presentation.
1. Add an [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) object to a slide.
1. Use the [ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) returned by [get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) to add a WebVTT caption track.
1. Save the modified presentation.

The following code shows you how to add captions to a video frame:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// Adds a new captions track from a WebVTT file.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

The [ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) interface also provides an overload that lets you add captions from a stream.

**Extract Captions from a Video Frame**

To extract captions from a video frame:

1. Load the presentation that contains the video.
1. Find the target [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) object.
1. Iterate through the caption tracks returned by [get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/).
1. Save each caption track to a `.vtt` file.

The following code shows you how to extract captions from a video frame:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : videoFrame->get_CaptionTracks())
        {
            // Saves the captions track to a WebVTT file.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

Each [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) object exposes the caption identifier, label, binary data, and caption data as a UTF-8 string.

**Remove Captions from a Video Frame**

To remove captions from a video frame:

1. Load the presentation that contains the video.
1. Get the target [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) object.
1. Remove caption tracks from the collection returned by [get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/).
1. Save the modified presentation.

The following code shows you how to remove all captions from a video frame:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Removes all captions from the video frame.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

If you need to remove only one caption track, use the [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/remove/) or [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/removeat/) methods instead of [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/clear/).

## **Extract Video from a Slide**

Besides adding videos to slides, Aspose.Slides allows you to extract videos embedded in presentations.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class to load the presentation containing the video. 
2. Iterate through all the [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) objects.
3. Iterate through all the [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) objects to find a [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/). 
4. Save the video to disk.

This C++ code shows you how to extract the video on a presentation slide:

```c++
// The path to the documents directory.
const System::String templatePath = u"../templates/Video.pptx";
const System::String outPath = u"../out/Video_out";

auto presentation = System::MakeObject<Presentation>(templatePath);
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (System::ObjectExt::Is<VideoFrame>(shape))
        {
            System::SharedPtr<VideoFrame> vf = System::AsCast<VideoFrame>(shape);
            System::String type = vf->get_EmbeddedVideo()->get_ContentType();
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            auto buffer = vf->get_EmbeddedVideo()->get_BinaryData();

            auto stream = System::MakeObject<System::IO::FileStream>(
                outPath + type, System::IO::FileMode::Create, System::IO::FileAccess::Write,
                System::IO::FileShare::Read);
            stream->Write(buffer, 0, buffer->get_Length());
        }
    }
}
```

## **FAQ**

**Which video playback parameters can be changed for a VideoFrame?**

You can control the [playback mode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (auto or on click) and [looping](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/). These options are available via the [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/) object's properties.

**Does adding a video affect the PPTX file size?**

Yes. When you embed a local video, the binary data is included in the document, so the presentation size grows in proportion to the file size. When you add an online video, a link and a thumbnail are embedded, so the size increase is smaller.

**Can I replace the video in an existing VideoFrame without changing its position and size?**

Yes. You can swap the [video content](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) within the frame while preserving the shape's geometry; this is a common scenario for updating media in an existing layout.

**Can the content type (MIME) of an embedded video be determined?**

Yes. An embedded video has a [content type](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) that you can read and use, for example when saving it to disk.
