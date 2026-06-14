---
title: Video
type: docs
weight: 80
url: /vi/androidjava/examples/elements/video/
keywords:
- ví dụ mã
- video
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Thêm và điều khiển video bằng Aspose.Slides cho Android: chèn, phát, cắt, đặt khung ảnh bìa và xuất với các ví dụ Java cho các bản trình bày PPT, PPTX và ODP."
---
Bài viết này minh họa cách nhúng khung video và thiết lập các tùy chọn phát lại bằng **Aspose.Slides for Android via Java**.

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

Lấy khung video đầu tiên đã được thêm vào slide.

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

Cấu hình video để phát tự động khi slide được hiển thị.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Cấu hình video để phát tự động.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```