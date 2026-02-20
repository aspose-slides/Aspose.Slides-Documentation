---
title: Video
type: docs
weight: 80
url: /php-java/examples/elements/video/
keywords:
- video
- video frame
- add video
- access video
- remove video
- video playback
- code examples
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Work with video in PHP using Aspose.Slides: insert, replace, trim, set poster frames and playback options, and export presentations for PPT, PPTX and ODP."
---

Shows how to embed video frames and set playback options using **Aspose.Slides for PHP via Java**.

## **Add a Video Frame**

Insert a video frame into a slide.

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Add a video frame.
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Access a Video Frame**

Retrieve the first video frame added to a slide.

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Access the first video frame on the slide.
        $firstVideoFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $firstVideoFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove a Video Frame**

Delete a video frame from the slide.

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assuming the first shape on the slide is the video frame.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Remove the video frame.
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Set Video Playback**

Configure the video to play automatically when the slide is displayed.

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assuming the first shape on the slide is the video frame.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Configure the video to play automatically.
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```
