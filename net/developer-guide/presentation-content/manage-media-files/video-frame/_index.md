---
title: Video Frame
type: docs
weight: 10
url: /net/video-frame/
keywords: "Add video, create video frame, extract video, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Add Video frame to PowerPoint presentation in C# or .NET"
---


## **Create Embedded Video Frame**
Developers can also add and play video files in the slides to enrich their presentations. Aspose.Slides for .NET supports adding Video Frames to the slides that make it possible for developers to add videos to their presentations. This topic will help developers to follow the simple steps with examples for adding video frames in their slides. To add a Video Frame in a slide using Aspose.Slides for .NET, please follow the steps below:

1. Create an instance of [Presentation ](https://apireference.aspose.com/slides/net/aspose.slides/presentation)class.
1. Obtain the reference of a slide by using its Index.
1. Add the Video Frame (containing the video file name) into the slide.
1. Write the modified presentation as a PPTX file.

In the example below, we added a Video Frame into the slide.

```c#
// Instantiate Presentation class that represents the PPTX
using (Presentation pres = new Presentation())
{

    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Embedd vide inside presentation
    IVideo vid = pres.Videos.AddVideo(new FileStream("Wildlife.mp4", FileMode.Open));

    // Add Video Frame
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 350, vid);

    // Set video to Video Frame
    vf.EmbeddedVideo = vid;

    // Set Play Mode and Volume of the Video
    vf.PlayMode = VideoPlayModePreset.Auto;
    vf.Volume = AudioVolumeMode.Loud;

    // Write the PPTX file to disk
    pres.Save("VideoFrame_out.pptx", SaveFormat.Pptx);
}
```
It is possible to add a video passing path to the video file directly into AddVideoFrame method:

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Create Video Frame with Video from Web Source**
PowerPoint 2010 and newer versions support YouTube videos. To play these videos in PowerPoint make sure your [environment meet requirements ](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)for embedding videos from web source.

Follow these steps:

1. Create an instance of [Presentation ](https://apireference.aspose.com/slides/net/aspose.slides/presentation)class
1. Obtain the reference of a slide by using its Index
1. Add the Video Frame by passing video URL
1. Set Image for Video Frame
1. Save presentation as a PPTX file

This sample code shows you how to to add a video from YouTube to your presentation using Aspose.Slides:

```c#
public static void Run()
{
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    //add videoFrame
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    //load thumbnail
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **Extract Video From Slide**
Aspose.Slides for .NET supports extracting video from the slide. In order to extract the video. Please follow the steps below:

- Load a Presentation containing a video.
- Loop through all the slides of the [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation).
- Search for Video Frame.
- Save the Video to disk.
  In the example given below, we have saved the video file from a slide.

```c#
// Instantiate a Presentation object that represents a presentation file 
Presentation presentation = new Presentation("Video.pptx");

foreach (ISlide slide in presentation.Slides)
{
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        if (shape is VideoFrame)
        {
            IVideoFrame vf = shape as IVideoFrame;
            String type = vf.EmbeddedVideo.ContentType;
            int ss = type.LastIndexOf('/');
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            Byte[] buffer = vf.EmbeddedVideo.BinaryData;
            using (FileStream stream = new FileStream("NewVideo_out." + type, FileMode.Create, FileAccess.Write, FileShare.Read))
            {                                                     
                stream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
```

