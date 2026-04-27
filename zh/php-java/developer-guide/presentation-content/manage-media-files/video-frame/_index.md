---
title: 使用 PHP 管理演示文稿中的视频帧
linktitle: 视频帧
type: docs
weight: 10
url: /zh/php-java/video-frame/
keywords:
- 添加视频
- 创建视频
- 嵌入视频
- 提取视频
- 检索视频
- 视频帧
- 网络来源
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "学习使用 Aspose.Slides for PHP via Java 在 PowerPoint 和 OpenDocument 幻灯片中以编程方式添加和提取视频帧。快速实用指南。"
---
在演示文稿中恰当地放置视频可以使您的信息更具说服力，并提升观众的参与度。 

PowerPoint 允许您以两种方式向演示文稿的幻灯片添加视频：

* 添加或嵌入本地视频（存储在您的机器上）
* 添加在线视频（来自如 YouTube 的网络来源）。

为了让您向演示文稿添加视频（video 对象），Aspose.Slides 提供了 [Video](https://reference.aspose.com/slides/zh/php-java/aspose.slides/video/) 类、[VideoFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/) 类以及其他相关类型。

## **创建嵌入式视频帧**

如果您要添加到幻灯片的视频文件保存在本地，您可以创建视频帧将视频嵌入演示文稿中。 

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。 
1. 通过索引获取幻灯片的引用。 
1. 添加一个 [Video](https://reference.aspose.com/slides/zh/php-java/aspose.slides/video/) 对象，并传入视频文件路径以将视频嵌入演示文稿。 
1. 添加一个 [VideoFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/) 对象，以为视频创建帧。 
1. 保存修改后的演示文稿。 

以下 PHP 代码演示了如何将本地存储的视频添加到演示文稿中：

```php
  # 实例化 Presentation 类
  $pres = new Presentation("pres.pptx");
  try {
    # 加载视频
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # 获取第一张幻灯片并添加视频帧
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # 将演示文稿保存到磁盘
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

或者，您可以直接将文件路径传递给 [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/addvideoframe/) 方法来添加视频：

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $vf = $sld->getShapes()->addVideoFrame(50, 150, 300, 150, "video1.avi");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **使用网络来源视频创建视频帧**

Microsoft [PowerPoint 2013 及更高版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支持在演示文稿中使用 YouTube 视频。如果您想使用的视频可在线获取（例如在 YouTube 上），可以通过其网页链接将其添加到演示文稿中。 

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例 
1. 通过索引获取幻灯片的引用。 
1. 添加一个 [Video](https://reference.aspose.com/slides/zh/php-java/aspose.slides/video/) 对象，并传入视频链接。 
1. 为视频帧设置缩略图。 
1. 保存演示文稿。 

以下 PHP 代码演示了如何从网络向 PowerPoint 演示文稿的幻灯片添加视频：

```php
  # 实例化一个表示演示文稿文件的 Presentation 对象
  $pres = new Presentation();
  try {
    addVideoFromYouTube($pres, "Tj75Arhq5ho");
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **管理视频字幕**

Aspose.Slides 允许您管理 PowerPoint 演示文稿中视频帧的闭合字幕。字幕以 WebVTT 格式存储，并通过 [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/#getCaptionTracks) 方法公开。  

**向视频帧添加字幕**

向视频帧添加字幕的步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。 
1. 向演示文稿添加视频。 
1. 向幻灯片添加一个 [VideoFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/) 对象。 
1. 使用由 [getCaptionTracks](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/#getCaptionTracks) 返回的 [CaptionsCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/captionscollection/) 集合来添加 WebVTT 字幕轨道。 
1. 保存修改后的演示文稿。 

以下代码演示了如何向视频帧添加字幕：

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // 添加来自 WebVTT 文件的新字幕轨道。
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/captionscollection/) 类还提供了一个重载，允许您从流中添加字幕。  

**从视频帧提取字幕**

从视频帧提取字幕的步骤：

1. 加载包含视频的演示文稿。 
1. 查找目标 [VideoFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/) 对象。 
1. 遍历 [getCaptionTracks](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/#getCaptionTracks) 集合。 
1. 将每个字幕轨道保存为 `.vtt` 文件。 

以下代码演示了如何从视频帧提取字幕：

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trackCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                // 保存字幕轨道到 WebVTT 文件。
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

每个 [Captions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/captions/) 对象会公开字幕标识符、标签、二进制数据以及以 UTF-8 字符串形式的字幕文本。  

**从视频帧删除字幕**

从视频帧删除字幕的步骤：

1. 加载包含视频的演示文稿。 
1. 获取目标 [VideoFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/) 对象。 
1. 从 [getCaptionTracks](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/#getCaptionTracks) 集合中移除字幕轨道。 
1. 保存修改后的演示文稿。 

以下代码演示了如何删除视频帧中的所有字幕：

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // 类型: VideoFrame

    // 删除视频帧中的所有字幕。
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

如果只需要删除单个字幕轨道，请使用 [remove](https://reference.aspose.com/slides/zh/php-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/zh/php-java/aspose.slides/captionscollection/#removeAt) 方法，而不是 [clear](https://reference.aspose.com/slides/zh/php-java/aspose.slides/captionscollection/#clear)。  

## **从幻灯片中提取视频**

除了向幻灯片添加视频外，Aspose.Slides 还允许您提取嵌入在演示文稿中的视频。  

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例，以加载包含视频的演示文稿。 
2. 遍历所有 [Slide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/) 对象。 
3. 遍历所有 [Shape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/) 对象，以查找 [VideoFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/)。 
4. 将视频保存到磁盘。 

以下 PHP 代码演示了如何提取演示文稿幻灯片中的视频：

```php
  # 实例化一个表示演示文稿文件的 Presentation 对象
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # 获取文件扩展名
          $charIndex = $type->indexOf("/");
          $type = $type->substring($charIndex + 1);
          $fop = new Java("java.io.FileOutputStream", "testing2." . $type);
          $fop->write($buffer);
          $fop->flush();
          $fop->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**可以更改 VideoFrame 的哪些视频播放参数？**

您可以通过 [VideoFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/) 对象的属性控制 [playback mode](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/setplaymode/)（自动或点击）和 [looping](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/setplayloopmode/)。  

**添加视频会影响 PPTX 文件大小吗？**

会。嵌入本地视频时，二进制数据会包含在文档中，导致演示文稿的大小按文件大小成比例增加。添加在线视频时，只会嵌入链接和缩略图，大小增长较小。  

**我能在不更改位置和大小的情况下替换现有 VideoFrame 中的视频吗？**

可以。您可以在保留形状几何的前提下，交换帧内的 [video content](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/setembeddedvideo/)，这在更新已有布局中的媒体时很常见。  

**可以判断嵌入视频的内容类型（MIME）吗？**

可以。嵌入的视频具有可读取的 [content type](https://reference.aspose.com/slides/zh/php-java/aspose.slides/video/getcontenttype/)，例如在保存到磁盘时可使用该信息。