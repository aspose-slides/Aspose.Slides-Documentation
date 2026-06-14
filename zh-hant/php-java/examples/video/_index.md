---
title: 影片
type: docs
weight: 80
url: /zh-hant/php-java/examples/elements/video/
keywords:
- 影片
- 影片框架
- 新增影片
- 存取影片
- 移除影片
- 影片播放
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中處理影片：插入、取代、剪裁、設定海報框架與播放選項，並將簡報匯出為 PPT、PPTX 與 ODP。"
---
展示如何使用 **Aspose.Slides for PHP via Java** 嵌入影片框架並設定播放選項。

## **新增影片框架**

在投影片中插入影片框架。

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 新增影片框架。
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **存取影片框架**

取得投影片中新增的第一個影片框架。

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 存取投影片上的第一個影片框架。
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

## **移除影片框架**

從投影片中刪除影片框架。

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假設投影片上的第一個形狀是影片框架。
        $videoFrame = $slide->getShapes()->get_Item(0);

        // 移除影片框架。
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **設定影片播放**

設定影片在投影片顯示時自動播放。

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假設投影片上的第一個形狀是影片框架。
        $videoFrame = $slide->getShapes()->get_Item(0);

        // 設定影片自動播放。
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```