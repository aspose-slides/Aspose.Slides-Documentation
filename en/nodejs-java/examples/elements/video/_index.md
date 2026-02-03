---
title: Video
type: docs
weight: 80
url: /nodejs-java/examples/elements/video/
keywords:
- code example
- video
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Add and control videos with Aspose.Slides for Node.js: insert, play, trim, set poster frames, and export with examples for PPT, PPTX, and ODP presentations."
---

This article demonstrates how to embed video frames and set playback options using **Aspose.Slides for Node.js via Java**.

## **Add a Video Frame**

Add a video frame to a slide.

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Add a video.
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Access a Video Frame**

Retrieve the first video frame added to a slide.

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // Access the first video frame on the slide.
        let firstVideo = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IVideoFrame")) {
                firstVideo = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Video Frame**

Delete a video frame from the slide.

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Assume the first shape is the video frame.
        let videoFrame = slide.getShapes().get_Item(0);

        // Remove the video frame.
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Set Video Playback**

Configure the video to play automatically when the slide is displayed.

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Assume the first shape is the video frame.
        let videoFrame = slide.getShapes().get_Item(0);

        // Configure the video to play automatically.
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```
