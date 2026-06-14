---
title: Video
type: docs
weight: 80
url: /vi/php-java/examples/elements/video/
keywords:
- video
- khung video
- thêm video
- truy cập video
- xóa video
- phát lại video
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Làm việc với video trong PHP bằng Aspose.Slides: chèn, thay thế, cắt ghép, thiết lập khung poster và các tùy chọn phát lại, và xuất bản trình chiếu sang PPT, PPTX và ODP."
---
Hiển thị cách nhúng khung video và thiết lập các tùy chọn phát lại bằng **Aspose.Slides for PHP via Java**.

## **Thêm Khung Video**

Chèn một khung video vào slide.

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Thêm một khung video.
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Truy cập Khung Video**

Lấy khung video đầu tiên được thêm vào slide.

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Truy cập khung video đầu tiên trên slide.
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

## **Xóa Khung Video**

Xóa một khung video khỏi slide.

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Giả sử hình dạng đầu tiên trên slide là khung video.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Xóa khung video.
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Cài đặt Phát lại Video**

Cấu hình video để tự động phát khi slide được hiển thị.

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Giả sử hình dạng đầu tiên trên slide là khung video.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Cấu hình video để tự động phát.
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```