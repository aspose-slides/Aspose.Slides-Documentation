---
title: Video Frame
type: docs
weight: 10
url: /cpp/video-frame/
keywords: "Add video, create video frame, extract video, PowerPoint presentation, C++, CPP, Aspose.Slides for C++"
description: "Add Video frame to PowerPoint presentation in C++"

---

A well-placed video in a presentation can make your message more compelling and increase engagement levels with your audience. 

PowerPoint allows you to add videos to a slide in a presentation in two ways:

* Add or embed a local video (stored on your machine)
* Add an online video (from a web source such as YouTube).

To allow you to add videos (video objects) to a presentation, Aspose.Slides provides the [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) interface, [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) interface, and other relevant types. 

## **Create Embedded Video Frame**

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


## **Create Video Frame with Video from Web Source**

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

## **Extract Video From Slide**

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

