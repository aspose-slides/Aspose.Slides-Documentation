---
title: Manage Video Frames in Presentations Using PHP
linktitle: Video Frame
type: docs
weight: 10
url: /php-java/video-frame/
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
- PHP
- Aspose.Slides
description: "Learn to programmatically add and extract video frames in PowerPoint and OpenDocument slides using Aspose.Slides for PHP via Java. Fast how-to guide."
---

## **Introduction**

Videos can help explain ideas and engage an audience. Aspose.Slides for PHP via Java lets you add video frames to slides, adjust playback settings, manage captions, and extract embedded video data.

PowerPoint supports local videos and links to online videos, such as YouTube videos.

To represent video data and video frames, Aspose.Slides provides the [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) class, [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) class, and other relevant types.

## **Create an Embedded Video Frame**

If the video file you want to add to your slide is stored locally, you can create a video frame to embed the video in your presentation.

This example embeds a local video on the first slide of an existing presentation and saves the result. Frame coordinates and dimensions are in points. The stream stays open until saving finishes because [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) keeps it locked while the presentation uses it.

```php
use aspose\slides\LoadingStreamBehavior;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $slide = $presentation->getSlides()->get_Item(0);

    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::KeepLocked);
    $slide->getShapes()->addVideoFrame(10, 10, 150, 250, $video);

    $presentation->save("embedded_video.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

You can also pass a local video path directly to [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame). This example embeds the video on the first slide of a new presentation. The video must remain accessible until the presentation is saved.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addVideoFrame(50, 150, 300, 150, "video.avi");

    $presentation->save("video_from_path.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Create a Video Frame with Video from a Web Source**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) supports online videos in presentations. You can create a video frame that links to an online video, such as a YouTube video.

This example adds a YouTube video link and thumbnail to the first slide. Replace the video identifier to use another video. The [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) method requests automatic playback. Downloading the thumbnail and playing the video require internet access. The presentation viewer must also support online video playback.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoId = "aqz-KE-bpKQ";
    $videoUrl = "https://www.youtube.com/embed/" . $videoId;
    $videoFrame = $slide->getShapes()->addVideoFrame(10, 10, 427, 240, $videoUrl);
    $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

    $thumbnailUrl = "https://img.youtube.com/vi/" . $videoId . "/hqdefault.jpg";
    $thumbnailLocation = new Java("java.net.URL", $thumbnailUrl);
    $thumbnailStream = $thumbnailLocation->openStream();
    try {
        $thumbnail = $presentation->getImages()->addImage($thumbnailStream);
        $videoFrame->getPictureFormat()->getPicture()->setImage($thumbnail);
    } finally {
        $thumbnailStream->close();
    }

    $presentation->save("online_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Play a Video in Full-Screen Mode**

In a training presentation, you can play a software demonstration in full-screen mode so the audience can see the details. Call [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) with `true` to enable this behavior during playback.

This example opens a presentation, finds the first [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) on the first slide, and enables full-screen playback. The input presentation must contain at least one slide with an existing video frame on the first slide.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setFullScreenMode(true);
            break;
        }
    }

    $presentation->save("full_screen_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Full-screen playback controls how the video is displayed. Independently, [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) controls whether it starts automatically or on click, and [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) controls whether it repeats. To choose the start behavior, set the playback mode to [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/). The example preserves the existing start and loop settings.

## **Rewind a Video After Playback**

In a training presentation, returning a demonstration video to its beginning makes it ready for the presenter to play again. Call [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) with `true` to return the video to the beginning after playback finishes.

This example opens a presentation, finds the first [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) on the first slide, and enables rewinding. It disables looping so playback can finish and sets playback to start on click. The input presentation must contain at least one slide with an existing video frame on the first slide.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setRewindVideo(true);
            $videoFrame->setPlayLoopMode(false);
            $videoFrame->setPlayMode(VideoPlayModePreset::OnClick);
            break;
        }
    }

    $presentation->save("rewind_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Rewinding returns the video to its beginning without starting it again. In contrast, calling [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) with `true` repeats playback automatically. Keep looping disabled when you want the video to finish and remain ready to replay. [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) independently controls automatic or on-click startup; this example uses [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) so the presenter controls when playback starts. Set the playback mode after the loop setting, as shown in the example. Rewinding works independently of [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode).

## **Trim a Video Frame**

Use [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) and [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) to skip part of the beginning or end of a video during playback. Both values are in milliseconds. Trimming changes playback settings without modifying the embedded video data.

**Set Trim Settings**

This example embeds a local video and skips the first 2.5 seconds and the last second during playback. Use a video longer than 3.5 seconds so a playable segment remains.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);
    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Read Trim Settings**

This example prints the trim values of the first video frame on the first slide in milliseconds. The presentation must contain at least one slide. If that slide has no video frame, nothing is printed. The preceding example produces values of 2500 and 1000.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            echo "Trim from start: " . java_values($videoFrame->getTrimFromStart()) . " ms\n";
            echo "Trim from end: " . java_values($videoFrame->getTrimFromEnd()) . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Manage Video Captions**

Aspose.Slides allows you to manage closed captions for video frames in PowerPoint presentations. Captions are stored in WebVTT format and are exposed through the [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) method.

**Add Captions to a Video Frame**

This example embeds a local video and adds a WebVTT caption track labeled English. The caption timestamps should match the video. The saved presentation includes both the video and its captions.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) class also provides an overload that lets you add captions from a stream.

**Extract Captions from a Video Frame**

This example saves all caption tracks from video frames on the first slide as separate WebVTT files. Sequential numbers keep the output files distinct. The console reports the number of extracted tracks. The presentation must contain at least one slide.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $trackCount = 0;
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $captionCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $captionCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                $trackCount++;
                $outputStream = new Java("java.io.FileOutputStream", "captions_" . $trackCount . ".vtt");
                try {
                    $outputStream->write($captionTrack->getBinaryData());
                } finally {
                    $outputStream->close();
                }
            }
        }
    }

    echo "Caption tracks extracted: " . $trackCount . "\n";
} finally {
    $presentation->dispose();
}
```

Each [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) object exposes the caption identifier, label, binary data, and caption text as a UTF-8 string.

**Remove Captions from a Video Frame**

This example removes all captions from the video frame at the first shape position on the first slide and saves the result. It assumes that the slide and shape exist and that the shape is a video frame.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFrame = $slide->getShapes()->get_Item(0);
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

If you need to remove only one caption track, use the [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) or [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) methods instead of [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear).

## **Extract Video from a Slide**

Besides adding videos to slides, Aspose.Slides allows you to extract videos embedded in presentations.

This example extracts embedded videos from every slide into separate, numbered binary files. Linked videos are skipped because they have no embedded data. The console prints each video’s MIME type and the total count. Output uses the generic `.bin` extension; change it to match the reported media type when needed.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_videos.pptx");
try {
    $videoCount = 0;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $videoFrame = $shape;
                $video = $videoFrame->getEmbeddedVideo();
                if (java_is_null($video)) {
                    echo "Skipped a linked video: no embedded data is available.\n";
                    continue;
                }

                $videoCount++;
                $outputStream = new Java("java.io.FileOutputStream", "extracted_video_" . $videoCount . ".bin");
                try {
                    $outputStream->write($video->getBinaryData());
                } finally {
                    $outputStream->close();
                }
                echo "Video " . $videoCount . ": " . java_values($video->getContentType()) . "\n";
            }
        }
    }

    echo "Embedded videos extracted: " . $videoCount . "\n";
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Which video playback parameters can be changed for a video frame?**

You can control the [playback mode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (auto or on click) and [looping](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode). These options are available via the [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) object's methods.

**Does adding a video affect the PPTX file size?**

Yes. When you embed a local video, the binary data is included in the document, so the presentation size grows in proportion to the file size. When you link to an online video and add a thumbnail, the presentation stores the link and preview image rather than the video data, so the size increase is usually smaller.

**Can I replace the video in an existing video frame without changing its position and size?**

Yes. You can swap the [video content](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) within the frame while preserving the shape's geometry; this is a common scenario for updating media in an existing layout.

**Can the content type (MIME) of an embedded video be determined?**

Yes. An embedded video has a [content type](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType) that you can read and use, for example when saving it to disk.
