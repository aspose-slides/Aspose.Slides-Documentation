---
title: 视频
type: docs
weight: 80
url: /zh/nodejs-java/examples/elements/video/
keywords:
- 代码示例
- 视频
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 添加和控制视频：插入、播放、剪辑、设置海报帧，并提供 PPT、PPTX 和 ODP 演示文稿的示例。"
---
本文演示如何使用 **Aspose.Slides for Node.js via Java** 嵌入视频帧并设置播放选项。

## **添加视频帧**

向幻灯片添加视频帧。

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 添加视频。
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **访问视频帧**

检索添加到幻灯片的第一个视频帧。

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // 访问幻灯片上的第一个视频帧。
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

## **删除视频帧**

从幻灯片中删除视频帧。

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 假设第一个形状是视频帧。
        let videoFrame = slide.getShapes().get_Item(0);

        // 删除视频帧。
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **设置视频播放**

配置视频在幻灯片显示时自动播放。

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 假设第一个形状是视频帧。
        let videoFrame = slide.getShapes().get_Item(0);

        // 配置视频自动播放。
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```