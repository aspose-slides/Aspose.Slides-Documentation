---
title: Manage Video Frames in Presentations in .NET
linktitle: Video Frame
type: docs
weight: 10
url: /net/video-frame/
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
- .NET
- C#
- Aspose.Slides
description: "Learn to programmatically add and extract video frames in PowerPoint and OpenDocument slides using Aspose.Slides for .NET. Fast how-to guide."
---

## **Introduction**

A well-placed video in a presentation can make your message more compelling and increase engagement levels with your audience. 

PowerPoint allows you to add videos to a slide in a presentation in two ways:

* Add or embed a local video (stored on your machine)
* Add an online video (from a web source such as YouTube).

To allow you to add videos (video objects) to a presentation, Aspose.Slides provides the [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) interface, [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) interface, and other relevant types. 

## **Create an Embedded Video Frame**

If the video file you want to add to your slide is stored locally, you can create a video frame to embed the video in your presentation. 

1. Create an instance of the [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
1. Get a slide's reference through its index. 
1. Add an [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) object and pass the video file path to embed the video with the presentation. 
1. Add an [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) object to create a frame for the video.  
1. Save the modified presentation. 

This C# code shows you how to add a video stored locally to a presentation:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Create a Video Frame with Video from a Web Source**
Newer versions of Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) support online videos in presentations. If the video you want to use is available online (e.g. on YouTube), you can add it to your presentation through its web link.

1. Create an instance of [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class
1. Get a slide's reference through its index. 
1. Add an [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) object and pass the link to the video.
1. Set a thumbnail for the video frame. 
1. Save the presentation. 

This C# code shows you how to add a video from the web to a slide in a PowerPoint presentation:

```c#
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Trim a Video Frame**

Aspose.Slides allows you to control which part of a video is played by setting the trim-from-start and trim-from-end values through [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) and [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/). Both values are specified in milliseconds and define how much time is skipped from the beginning and end of the video, respectively. These settings change the video playback settings in the presentation; they do not cut or otherwise modify the embedded video binary data.

**Set Trim Settings**

To create a video frame and set its trim settings:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
1. Add an [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) object to the presentation.
1. Add an [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) object to a slide.
1. Set the trim-from-start and trim-from-end values through [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) and [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/).
1. Save the modified presentation.

The following code example skips the first 2.5 seconds and the last second of an embedded video during playback:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var slide = presentation.Slides[0];
var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);

videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Read Trim Settings**

To inspect existing trim settings, load a presentation, find an [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) object among the shapes on the first slide, and read the values through [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) and [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/).

The following code example finds the first video frame on the first slide and reports its trim settings in milliseconds:

```cs
using Aspose.Slides;

using var presentation = new Presentation("video_with_trim.pptx");

var slide = presentation.Slides[0];
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        var trimFromStart = videoFrame.TrimFromStart;
        var trimFromEnd = videoFrame.TrimFromEnd;

        Console.WriteLine($"Trim from start: {trimFromStart} ms");
        Console.WriteLine($"Trim from end: {trimFromEnd} ms");

        break;
    }
}
```

## **Manage Video Captions**

Aspose.Slides allows you to manage closed captions for video frames in PowerPoint presentations. Captions are stored in WebVTT format and are exposed through the [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) property.

**Add Captions to a Video Frame**

To add captions to a video frame:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
1. Add a video to the presentation.
1. Add an [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) object to a slide.
1. Use the [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) collection to add a WebVTT caption track.
1. Save the modified presentation.

The following code shows you how to add captions to a video frame:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // Adds a new captions track from a WebVTT file.
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

The [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) interface also provides an overload that lets you add captions from a stream.

**Extract Captions from a Video Frame**

To extract captions from a video frame:

1. Load the presentation that contains the video.
1. Find the target [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) object.
1. Iterate through the [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) collection.
1. Save each caption track to a `.vtt` file.

The following code shows you how to extract captions from a video frame:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            foreach (ICaptions captionTrack in videoFrame.CaptionTracks)
            {
                // Saves the captions track to a WebVTT file.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

Each [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) object exposes the caption identifier, label, binary data, and caption text as a UTF-8 string.

**Remove Captions from a Video Frame**

To remove captions from a video frame:

1. Load the presentation that contains the video.
1. Get the target [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) object.
1. Remove caption tracks from the [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) collection.
1. Save the modified presentation.

The following code shows you how to remove all captions from a video frame:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Removes all captions from the video frame.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

If you need to remove only one caption track, use the [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) or [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) methods instead of [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

## **Extract Video from a Slide**
Besides adding videos to slides, Aspose.Slides allows you to extract videos embedded in presentations.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class to load the presentation containing the video. 
2. Iterate through all the [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) objects.
3. Iterate through all the [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) objects to find a [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe). 
4. Save the video to disk.

This C# code shows you how to extract the video on a presentation slide:

```c#
using Aspose.Slides;

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

## **FAQ**

**Which video playback parameters can be changed for a VideoFrame?**

You can control the [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (auto or on click) and [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). These options are available via the [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) object's properties.

**Does adding a video affect the PPTX file size?**

Yes. When you embed a local video, the binary data is included in the document, so the presentation size grows in proportion to the file size. When you add an online video, a link and a thumbnail are embedded, so the size increase is smaller.

**Can I replace the video in an existing VideoFrame without changing its position and size?**

Yes. You can swap the [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) within the frame while preserving the shape's geometry; this is a common scenario for updating media in an existing layout.

**Can the content type (MIME) of an embedded video be determined?**

Yes. An embedded video has a [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) that you can read and use, for example when saving it to disk.
