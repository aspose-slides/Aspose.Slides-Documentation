---
title: Manage Video Frames in Presentations Using Java
linktitle: Video Frame
type: docs
weight: 10
url: /java/video-frame/
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
- Java
- Aspose.Slides
description: "Learn to programmatically add and extract video frames in PowerPoint and OpenDocument slides using Aspose.Slides for Java. Fast how-to guide."
---

## **Introduction**

A well-placed video in a presentation can make your message more compelling and increase engagement levels with your audience. 

PowerPoint allows you to add videos to a slide in a presentation in two ways:

* Add or embed a local video (stored on your machine)
* Add an online video (from a web source such as YouTube).

To allow you to add videos (video objects) to a presentation, Aspose.Slides provides the [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) interface, [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) interface, and other relevant types. 

## **Create Embedded Video Frames**

If the video file you want to add to your slide is stored locally, you can create a video frame to embed the video in your presentation. 

1. Create an instance of the [Presentation ](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)class.
1. Get a slide's reference through its index. 
1. Add an [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) object and pass the video file path to embed the video with the presentation. 
1. Add an [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) object to create a frame for the video.  
1. Save the modified presentation. 

This Java code shows you how to add a video stored locally to a presentation:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

// Instantiates the Presentation class
Presentation pres = new Presentation("pres.pptx");
try {
    // Loads the video
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Gets the first slide and adds a videoframe
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Saves the presentation to disk
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Alternatively, you can add a video by passing its file path directly to the [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) method:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```


## **Create Video Frames with Video from Web Sources**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) support YouTube videos in presentations. If the video you want to use is available online (e.g. on YouTube), you can add it to your presentation through its web link. 

1. Create an instance of [Presentation ](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)class
1. Get a slide's reference through its index. 
1. Add an [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) object and pass the link to the video.
1. Set a thumbnail for the video frame. 
1. Save the presentation. 

This Java code shows you how to add a video from the web to a slide in a PowerPoint presentation:

```java
import com.aspose.slides.*;

// Instantiates a Presentation object that represents a presentation file 
Presentation pres = new Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.MalformedURLException;
import java.net.URL;

private static void addVideoFromYouTube(Presentation pres, String videoID)
{
    // Adds a videoFrame
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // Loads thumbnail
    String thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";
    URL url;

    try {
        url = new URL(thumbnailUri);
        videoFrame.getPictureFormat().getPicture().setImage(pres.getImages().addImage(url.openStream()));
    } catch (MalformedURLException e) {
        e.printStackTrace();
    } catch (IOException e) {
        e.printStackTrace();
    }
}
```

## **Trim a Video Frame**

Aspose.Slides allows you to control which part of a video is played by setting the trim-from-start and trim-from-end values through [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) and [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-). Both values are specified in milliseconds and define how much time is skipped from the beginning and end of the video, respectively. These settings change the video playback settings in the presentation; they do not cut or otherwise modify the embedded video binary data.

**Set Trim Settings**

To create a video frame and set its trim settings:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Add an [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) object to the presentation.
1. Add an [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) object to a slide.
1. Set the trim-from-start and trim-from-end values through [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) and [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-).
1. Save the modified presentation.

The following code example skips the first 2.5 seconds and the last second of an embedded video during playback:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    FileInputStream videoStream = new FileInputStream("video.mp4");
    try {
        IVideo video = presentation.getVideos().addVideo(
                videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
        ISlide slide = presentation.getSlides().get_Item(0);
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500f);
        videoFrame.setTrimFromEnd(1000f);

        presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**Read Trim Settings**

To inspect existing trim settings, load a presentation, find an [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) object among the shapes on the first slide, and read the values through [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getTrimFromStart--) and [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getTrimFromEnd--).

The following code example finds the first video frame on the first slide and reports its trim settings in milliseconds:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            float trimFromStart = videoFrame.getTrimFromStart();
            float trimFromEnd = videoFrame.getTrimFromEnd();

            System.out.println("Trim from start: " + trimFromStart + " ms");
            System.out.println("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Manage Video Captions**

Aspose.Slides allows you to manage closed captions for video frames in PowerPoint presentations. Captions are stored in WebVTT format and are exposed through the [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) method.

**Add Captions to a Video Frame**

To add captions to a video frame:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class.
1. Add a video to the presentation.
1. Add an [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) object to a slide.
1. Use the [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) returned by [getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) to add a WebVTT caption track.
1. Save the modified presentation.

The following code shows you how to add captions to a video frame:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Adds a new captions track from a WebVTT file.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) interface also provides an overload that lets you add captions from a stream.

**Extract Captions from a Video Frame**

To extract captions from a video frame:

1. Load the presentation that contains the video.
1. Find the target [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) object.
1. Iterate through the caption tracks in the [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/).
1. Save each caption track to a `.vtt` file.

The following code shows you how to extract captions from a video frame:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Saves the captions track to a WebVTT file.
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Each [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) object exposes the caption identifier, label, binary data, and caption text as a UTF-8 string.

**Remove Captions from a Video Frame**

To remove captions from a video frame:

1. Load the presentation that contains the video.
1. Get the target [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) object.
1. Remove caption tracks from the [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/).
1. Save the modified presentation.

The following code shows you how to remove all captions from a video frame:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // Removes all captions from the video frame.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

If you need to remove only one caption track, use the [remove](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) or [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#removeAt-int-) methods instead of [clear](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#clear--).

## **Extract Video from Slides**

Besides adding videos to slides, Aspose.Slides allows you to extract videos embedded in presentations.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class to load the presentation containing the video. 
2. Iterate through all the [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) objects.
3. Iterate through all the [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) objects to find a [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/). 
4. Save the video to disk.

This Java code shows you how to extract the video on a presentation slide:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

// Instantiates a Presentation object that represents a presentation file 
Presentation pres = new Presentation("VideoSample.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        for (IShape shape : slide.getShapes()) 
        {
            if (shape instanceof VideoFrame) 
            {
                IVideoFrame vf = (IVideoFrame) shape;
                String type = vf.getEmbeddedVideo().getContentType();
                int ss = type.lastIndexOf('-');
                byte[] buffer = vf.getEmbeddedVideo().getBinaryData();

                //Gets the File Extension
                int charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);

                FileOutputStream fop = new FileOutputStream("testing2." + type);
                fop.write(buffer);
                fop.flush();
                fop.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Which video playback parameters can be changed for a VideoFrame?**

You can control the [playback mode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (auto or on click) and [looping](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). These options are available via the [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) object's properties.

**Does adding a video affect the PPTX file size?**

Yes. When you embed a local video, the binary data is included in the document, so the presentation size grows in proportion to the file size. When you add an online video, a link and a thumbnail are embedded, so the size increase is smaller.

**Can I replace the video in an existing VideoFrame without changing its position and size?**

Yes. You can swap the [video content](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) within the frame while preserving the shape's geometry; this is a common scenario for updating media in an existing layout.

**Can the content type (MIME) of an embedded video be determined?**

Yes. An embedded video has a [content type](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) that you can read and use, for example when saving it to disk.
