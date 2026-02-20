---
title: 视频
type: docs
weight: 80
url: /zh/php-java/examples/elements/video/
keywords:
- 视频
- 视频帧
- 添加视频
- 访问视频
- 删除视频
- 视频播放
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 处理视频：插入、替换、裁剪、设置海报帧和播放选项，并将演示文稿导出为 PPT、PPTX 和 ODP。"
---
演示如何使用 **Aspose.Slides for PHP via Java** 嵌入视频帧并设置播放选项。

## **添加视频帧**

在幻灯片中插入视频帧。

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 添加视频帧。
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **访问视频帧**

检索添加到幻灯片的第一个视频帧。

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 访问幻灯片上的第一个视频帧。
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

## **删除视频帧**

从幻灯片中删除视频帧。

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假设幻灯片上的第一个形状是视频帧。
        $videoFrame = $slide->getShapes()->get_Item(0);

        // 删除视频帧。
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **设置视频播放**

配置视频在幻灯片显示时自动播放。

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假设幻灯片上的第一个形状是视频帧。
        $videoFrame = $slide->getShapes()->get_Item(0);

        // 将视频配置为自动播放。
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```