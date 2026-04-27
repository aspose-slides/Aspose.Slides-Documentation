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
- retrive video
- video frame
- web source
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Learn to programmatically add and extract video frames in PowerPoint and OpenDocument slides using Aspose.Slides for PHP via Java. Fast how-to guide."
---

A well-placed video in a presentation can make your message more compelling and increase engagement levels with your audience. 

PowerPoint allows you to add videos to a slide in a presentation in two ways:

* Add or embed a local video (stored on your machine)
* Add an online video (from a web source such as YouTube).

To allow you to add videos (video objects) to a presentation, Aspose.Slides provides the [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) class, [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) class, and other relevant types.

## **Create Embedded Video Frames**

If the video file you want to add to your slide is stored locally, you can create a video frame to embed the video in your presentation. 

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
1. Get a slide's reference through its index. 
1. Add a [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) object and pass the video file path to embed the video with the presentation.
1. Add a [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) object to create a frame for the video.
1. Save the modified presentation. 

This PHP code shows you how to add a video stored locally to a presentation:

```php
  # Instantiates the Presentation class
  $pres = new Presentation("pres.pptx");
  try {
    # Loads the video
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Gets the first slide and adds a videoframe
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # Saves the presentation to disk
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Alternatively, you can add a video by passing its file path directly to the [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addvideoframe/) method:

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $vf = $sld->getShapes()->addVideoFrame(50, 150, 300, 150, "video1.avi");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Create Video Frames with Video from Web Sources**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) support YouTube videos in presentations. If the video you want to use is available online (e.g. on YouTube), you can add it to your presentation through its web link. 

1. Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class
1. Get a slide's reference through its index. 
1. Add a [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) object and pass the link to the video.
1. Set a thumbnail for the video frame. 
1. Save the presentation. 

This PHP code shows you how to add a video from the web to a slide in a PowerPoint presentation:

```php
  # Instantiates a Presentation object that represents a presentation file
  $pres = new Presentation();
  try {
    addVideoFromYouTube($pres, "Tj75Arhq5ho");
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```

## **Manage Video Captions**

Aspose.Slides allows you to manage closed captions for video frames in PowerPoint presentations. Captions are stored in WebVTT format and are exposed through the [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) method.

**Add Captions to a Video Frame**

To add captions to a video frame:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
1. Add a video to the presentation.
1. Add a [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) object to a slide.
1. Use the [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) collection returned by [getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) to add a WebVTT caption track.
1. Save the modified presentation.

The following code shows you how to add captions to a video frame:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // Adds a new captions track from a WebVTT file.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) class also provides an overload that lets you add captions from a stream.

**Extract Captions from a Video Frame**

To extract captions from a video frame:

1. Load the presentation that contains the video.
1. Find the target [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) object.
1. Iterate through the [getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) collection.
1. Save each caption track to a `.vtt` file.

The following code shows you how to extract captions from a video frame:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trackCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                // Saves the captions track to a WebVTT file.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Each [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) object exposes the caption identifier, label, binary data, and caption text as a UTF-8 string.

**Remove Captions from a Video Frame**

To remove captions from a video frame:

1. Load the presentation that contains the video.
1. Get the target [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) object.
1. Remove caption tracks from the [getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) collection.
1. Save the modified presentation.

The following code shows you how to remove all captions from a video frame:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // type: VideoFrame

    // Removes all captions from the video frame.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

If you need to remove only one caption track, use the [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) or [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) methods instead of [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear).

## **Extract Video from Slides**

Besides adding videos to slides, Aspose.Slides allows you to extract videos embedded in presentations.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class to load the presentation containing the video.
2. Iterate through all the [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) objects.
3. Iterate through all the [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) objects to find a [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).
4. Save the video to disk.

This PHP code shows you how to extract the video on a presentation slide:

```php
  # Instantiates a Presentation object that represents a presentation file
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # Gets the File Extension
          $charIndex = $type->indexOf("/");
          $type = $type->substring($charIndex + 1);
          $fop = new Java("java.io.FileOutputStream", "testing2." . $type);
          $fop->write($buffer);
          $fop->flush();
          $fop->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Which video playback parameters can be changed for a VideoFrame?**

You can control the [playback mode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplaymode/) (auto or on click) and [looping](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplayloopmode/). These options are available via the [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) object's properties.

**Does adding a video affect the PPTX file size?**

Yes. When you embed a local video, the binary data is included in the document, so the presentation size grows in proportion to the file size. When you add an online video, a link and a thumbnail are embedded, so the size increase is smaller.

**Can I replace the video in an existing VideoFrame without changing its position and size?**

Yes. You can swap the [video content](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setembeddedvideo/) within the frame while preserving the shape's geometry; this is a common scenario for updating media in an existing layout.

**Can the content type (MIME) of an embedded video be determined?**

Yes. An embedded video has a [content type](https://reference.aspose.com/slides/php-java/aspose.slides/video/getcontenttype/) that you can read and use, for example when saving it to disk.
