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
- retrieve video
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

Videos can help explain ideas and engage an audience. Aspose.Slides for Java lets you add video frames to slides, adjust playback settings, manage captions, and extract embedded video data.

PowerPoint supports local videos and links to online videos, such as YouTube videos.

To represent video data and video frames, Aspose.Slides provides the [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) interface, [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) interface, and other relevant types.

## **Create an Embedded Video Frame**

If the video file you want to add to your slide is stored locally, you can create a video frame to embed the video in your presentation.

This example embeds a local video on the first slide of an existing presentation and saves the result. Frame coordinates and dimensions are in points. The stream stays open until saving finishes because [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) keeps it locked while the presentation uses it.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.KeepLocked);
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

    presentation.save("embedded_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

You can also pass a local video path directly to [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). This example embeds the video on the first slide of a new presentation. The video must remain accessible until the presentation is saved.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Create a Video Frame with Video from a Web Source**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) supports online videos in presentations. You can create a video frame that links to an online video, such as a YouTube video.

This example adds a YouTube video link and thumbnail to the first slide. Replace the video identifier to use another video. The [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) method requests automatic playback. Downloading the thumbnail and playing the video require internet access. The presentation viewer must also support online video playback.

```java
import com.aspose.slides.*;
import java.io.InputStream;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    String videoId = "aqz-KE-bpKQ";
    String videoUrl = "https://www.youtube.com/embed/" + videoId;
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    String thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    URL thumbnailLocation = new URL(thumbnailUrl);
    try (InputStream thumbnailStream = thumbnailLocation.openStream()) {
        IPPImage thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    }

    presentation.save("online_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Play a Video in Full-Screen Mode**

In a training presentation, you can play a software demonstration in full-screen mode so the audience can see the details. Call [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) with `true` to enable this behavior during playback.

This example opens a presentation, finds the first [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) on the first slide, and enables full-screen playback. The input presentation must contain at least one slide with an existing video frame on the first slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Full-screen playback controls how the video is displayed. Independently, [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) controls whether it starts automatically or on click, and [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) controls whether it repeats. To choose the start behavior, set the playback mode to [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/). The example preserves the existing start and loop settings.

## **Rewind a Video After Playback**

In a training presentation, returning a demonstration video to its beginning makes it ready for the presenter to play again. Call [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) with `true` to return the video to the beginning after playback finishes.

This example opens a presentation, finds the first [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) on the first slide, and enables rewinding. It disables looping so playback can finish and sets playback to start on click. The input presentation must contain at least one slide with an existing video frame on the first slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rewinding returns the video to its beginning without starting it again. In contrast, calling [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) with `true` repeats playback automatically. Keep looping disabled when you want the video to finish and remain ready to replay. [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) independently controls automatic or on-click startup; this example uses [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) so the presenter controls when playback starts. Set the playback mode after the loop setting, as shown in the example. Rewinding works independently of [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Trim a Video Frame**

Use [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) and [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) to skip part of the beginning or end of a video during playback. Both values are in milliseconds. Trimming changes playback settings without modifying the embedded video data.

**Set Trim Settings**

This example embeds a local video and skips the first 2.5 seconds and the last second during playback. Use a video longer than 3.5 seconds so a playable segment remains.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Read Trim Settings**

This example prints the trim values of the first video frame on the first slide in milliseconds. The presentation must contain at least one slide. If that slide has no video frame, nothing is printed. The preceding example produces values of 2500 and 1000.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            System.out.println("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            System.out.println("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
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

This example embeds a local video and adds a WebVTT caption track labeled English. The caption timestamps should match the video. The saved presentation includes both the video and its captions.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) interface also provides an overload that lets you add captions from a stream.

**Extract Captions from a Video Frame**

This example saves all caption tracks from video frames on the first slide as separate WebVTT files. Sequential numbers keep the output files distinct. The console reports the number of extracted tracks. The presentation must contain at least one slide.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                Path outputPath = Paths.get("captions_" + trackCount + ".vtt");
                Files.write(outputPath, captionTrack.getBinaryData());
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Each [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) object exposes the caption identifier, label, binary data, and caption text as a UTF-8 string.

**Remove Captions from a Video Frame**

This example removes all captions from the video frame at the first shape position on the first slide and saves the result. It assumes that the slide and shape exist and that the shape is a video frame.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

If you need to remove only one caption track, use the [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) or [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) methods instead of [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--).

## **Extract Video from a Slide**

Besides adding videos to slides, Aspose.Slides allows you to extract videos embedded in presentations.

This example extracts embedded videos from every slide into separate, numbered binary files. Linked videos are skipped because they have no embedded data. The console prints each video’s MIME type and the total count. Output uses the generic `.bin` extension; change it to match the reported media type when needed.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation_with_videos.pptx");
try {
    int videoCount = 0;
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                IVideoFrame videoFrame = (IVideoFrame) shape;
                IVideo video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    System.out.println("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                Path outputPath = Paths.get("extracted_video_" + videoCount + ".bin");
                Files.write(outputPath, video.getBinaryData());
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Which video playback parameters can be changed for a video frame?**

You can control the [playback mode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (auto or on click) and [looping](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). These options are available via the [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) object's methods.

**Does adding a video affect the PPTX file size?**

Yes. When you embed a local video, the binary data is included in the document, so the presentation size grows in proportion to the file size. When you link to an online video and add a thumbnail, the presentation stores the link and preview image rather than the video data, so the size increase is usually smaller.

**Can I replace the video in an existing video frame without changing its position and size?**

Yes. You can swap the [video content](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) within the frame while preserving the shape's geometry; this is a common scenario for updating media in an existing layout.

**Can the content type (MIME) of an embedded video be determined?**

Yes. An embedded video has a [content type](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) that you can read and use, for example when saving it to disk.
