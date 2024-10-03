---
title: Video Frame
type: docs
weight: 10
url: /net/video-frame/
keywords: "Add video, create video frame, extract video, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Add Video frame to PowerPoint presentation in C# or .NET"
---

A well-placed video in a presentation can make your message more compelling and increase engagement levels with your audience. 

PowerPoint allows you to add videos to a slide in a presentation in two ways:

* Add or embed a local video (stored on your machine)
* Add an online video (from a web source such as YouTube).

To allow you to add videos (video objects) to a presentation, Aspose.Slides provides the [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) interface, [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) interface, and other relevant types. 

## **Create Embedded Video Frame**

If the video file you want to add to your slide is stored locally, you can create a video frame to embed the video in your presentation. 

1. Create an instance of the [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
1. Get a slide's reference through its index. 
1. Add an [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) object and pass the video file path to embed the video with the presentation. 
1. Add an [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) object to create a frame for the video.  
1. Save the modified presentation. 

This C# code shows you how to add a video stored locally to a presentation:

```c#
// Instantiates the Presentation class
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Loads the video
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // Gets the first slide and adds a videoframe
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // Saves the presentation to disk
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
Alternatively, you can add a video by passing its file path directly to the [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) method:

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Create Video Frame with Video from Web Source**
Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) support YouTube videos in presentations. If the video you want to use is available online (e.g. on YouTube), you can add it to your presentation through its web link. 

1. Create an instance of [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class
1. Get a slide's reference through its index. 
1. Add an [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) object and pass the link to the video.
1. Set a thumbnail for the video frame. 
1. Save the presentation. 

This C# code shows you how to add a video from the web to a slide in a PowerPoint presentation:

```c#
public static void Run()
{
    // Instantiates a Presentation object that represents a presentation file 
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // Adds a VideoFrame
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // Loads thumbnail
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **Extract Video From Slide**
Besides adding videos to slides, Aspose.Slides allows you to extract videos embedded in presentations.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class to load the presentation containing the video. 
2. Iterate through all the [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) objects.
3. Iterate through all the [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) objects to find a [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe). 
4. Save the video to disk.

This C# code shows you how to extract the video on a presentation slide:

```c#
// Instantiates a Presentation object that represents a presentation file 
Presentation presentation = new Presentation("Video.pptx");

// Iterates through slides
foreach (ISlide slide in presentation.Slides)
{
    // Iterates through shapes
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Saves video to disk once VideoFrame containing video is found
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
