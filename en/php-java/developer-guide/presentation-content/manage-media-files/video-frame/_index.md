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

To allow you to add videos (video objects) to a presentation, Aspose.Slides provides the [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) interface, [IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/) interface, and other relevant types.

## **Create Embedded Video Frames**

If the video file you want to add to your slide is stored locally, you can create a video frame to embed the video in your presentation. 

1. Create an instance of the [Presentation ](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)class.
1. Get a slide's reference through its index. 
1. Add an [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) object and pass the video file path to embed the video with the presentation.
1. Add an [IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/) object to create a frame for the video.
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

Alternatively, you can add a video by passing its file path directly to the [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) method:

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

1. Create an instance of [Presentation ](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)class
1. Get a slide's reference through its index. 
1. Add an [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) object and pass the link to the video.
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

## **Extract Video from Slides**

Besides adding videos to slides, Aspose.Slides allows you to extract videos embedded in presentations.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class to load the presentation containing the video.
2. Iterate through all the [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/) objects.
3. Iterate through all the [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) objects to find a [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).
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
