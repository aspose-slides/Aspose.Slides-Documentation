---
title: 影片
type: docs
weight: 80
url: /zh-hant/nodejs-java/examples/elements/video/
keywords:
- 程式碼範例
- 影片
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 來新增與控制影片：插入、播放、剪裁、設定海報框架，並提供 PPT、PPTX 和 ODP 簡報的範例匯出。"
---
本文示範如何使用 **Aspose.Slides for Node.js via Java** 內嵌影片框架並設定播放選項。

## **新增影片框架**
在投影片中加入影片框架。

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 新增影片。
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **存取影片框架**
取得投影片中加入的第一個影片框架。

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // 存取投影片上的第一個影片框架。
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

## **移除影片框架**
從投影片中刪除影片框架。

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 假設第一個形狀就是影片框架。
        let videoFrame = slide.getShapes().get_Item(0);

        // 移除影片框架。
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **設定影片播放**
設定影片在投影片顯示時自動播放。

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 假設第一個形狀就是影片框架。
        let videoFrame = slide.getShapes().get_Item(0);

        // 設定影片自動播放。
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```