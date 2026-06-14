---
title: Video
type: docs
weight: 80
url: /vi/java/examples/elements/video/
keywords:
- ví dụ mã
- video
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Thêm và điều khiển video bằng Aspose.Slides cho Java: chèn, phát, cắt, đặt khung poster, và xuất với các ví dụ Java cho các bản trình bày PPT, PPTX và ODP."
---
Bài viết này trình bày cách nhúng khung video và thiết lập các tùy chọn phát lại bằng cách sử dụng **Aspose.Slides for Java**.

## **Thêm Khung Video**

Chèn một khung video trống vào một slide.

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Thêm một video.
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập Khung Video**

Lấy khung video đầu tiên đã được thêm vào một slide.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Truy cập khung video đầu tiên trên slide.
        IVideoFrame firstVideo = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                firstVideo = (IVideoFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa Khung Video**

Xóa một khung video khỏi slide.

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Xóa khung video.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Thiết lập Phát lại Video**

Cấu hình video để tự động phát khi slide được hiển thị.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Cấu hình video để tự động phát.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```