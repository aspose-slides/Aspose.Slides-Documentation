---
title: Video
type: docs
weight: 80
url: /vi/nodejs-java/examples/elements/video/
keywords:
- ví dụ mã
- video
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Thêm và điều khiển video bằng Aspose.Slides cho Node.js: chèn, phát, cắt, đặt khung poster, và xuất với các ví dụ cho các bài thuyết trình PPT, PPTX và ODP."
---
Bài viết này trình bày cách nhúng khung video và thiết lập các tùy chọn phát lại bằng **Aspose.Slides for Node.js via Java**.

## **Thêm khung video**

Thêm một khung video vào slide.

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Thêm một video.
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập khung video**

Lấy khung video đầu tiên đã được thêm vào slide.

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // Truy cập khung video đầu tiên trên slide.
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

## **Xóa khung video**

Xóa một khung video khỏi slide.

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Giả sử hình dạng đầu tiên là khung video.
        let videoFrame = slide.getShapes().get_Item(0);

        // Xóa khung video.
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Đặt phát lại video**

Cấu hình video để tự động phát khi slide được hiển thị.

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Giả sử hình dạng đầu tiên là khung video.
        let videoFrame = slide.getShapes().get_Item(0);

        // Cấu hình video để tự động phát.
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```