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
description: "学习如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 和 OpenDocument 幻灯片中以编程方式添加和提取视频帧。快速入门指南。"
---
## **介绍**

在演示文稿中恰当地放置视频可以让您的信息更具说服力，并提升观众的参与度。

PowerPoint 允许您通过两种方式将视频添加到幻灯片中：

* 添加或嵌入本地视频（存储在您的机器上）
* 添加在线视频（如 YouTube）。

为了让您能够向演示文稿中添加视频（视频对象），Aspose.Slides 提供了 [Video](https://reference.aspose.com/slides/zh/php-java/aspose.slides/video/) 类、[VideoFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/) 类以及其他相关类型。

## **创建嵌入式视频帧**

如果要添加到幻灯片的视频文件保存在本地，您可以创建视频帧并将视频嵌入到演示文稿中。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 添加一个 [Video](https://reference.aspose.com/slides/zh/php-java/aspose.slides/video/) 对象，并传入视频文件路径以将视频嵌入演示文稿。  
1. 添加一个 [VideoFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/) 对象，以创建视频的帧。  
1. 保存修改后的演示文稿。  

下面的 PHP 代码演示了如何将本地存储的视频添加到演示文稿中：

```php
  # 实例化 Presentation 类
  $pres = new Presentation("pres.pptx");
  try {
    # 加载视频
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # 获取第一张幻灯片并添加视频帧
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # 将演示文稿保存到磁盘。
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

## **创建来自网络来源的视频帧**

Microsoft [PowerPoint 2013 及更高版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支持在演示文稿中使用 YouTube 视频。如果您要使用的视频已在线可用（例如在 YouTube 上），可以通过其网络链接将其添加到演示文稿中。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 添加一个 [Video](https://reference.aspose.com/slides/zh/php-java/aspose.slides/video/) 对象，并传入视频链接。  
1. 为视频帧设置缩略图。  
1. 保存演示文稿。  

下面的 PHP 代码演示了如何将网络视频添加到 PowerPoint 幻灯片中：

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

## **剪辑视频帧**

Aspose.Slides 通过 [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/#setTrimFromStart) 和 [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/#setTrimFromEnd) 方法允许您设置 trim-from-start 和 trim-from-end 值，以控制播放视频的哪一部分。两个值均以毫秒为单位，分别定义从视频开头和结尾跳过的时间长度。这些设置只影响演示文稿中的视频播放行为，不会剪裁或修改嵌入的视频二进制数据。

**设置剪辑参数**

创建视频帧并设置剪辑参数的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。  
1. 向演示文稿中添加一个 [Video](https://reference.aspose.com/slides/zh/php-java/aspose.slides/video/) 对象。  
1. 向幻灯片中添加一个 [VideoFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/) 对象。  
1. 通过 [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/#setTrimFromStart) 和 [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/#setTrimFromEnd) 设置剪辑起始和结束值。  
1. 保存修改后的演示文稿。  

下面的代码示例在播放期间跳过嵌入视频的前 2.5 秒和最后 1 秒：

```php
$presentation = new Presentation();
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $video = $presentation->getVideos()->addVideo(
        $videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);

    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

**读取剪辑参数**

要检查现有的剪辑设置，加载演示文稿，在第一张幻灯片的形状中查找 [VideoFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/) 对象，并通过 [VideoFrame::getTrimFromStart](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/#getTrimFromStart) 与 [VideoFrame::getTrimFromEnd](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/#getTrimFromEnd) 读取值。

下面的代码示例查找第一张幻灯片上的第一个视频帧并以毫秒为单位报告其剪辑设置：

```php
$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trimFromStart = java_values($videoFrame->getTrimFromStart());
            $trimFromEnd = java_values($videoFrame->getTrimFromEnd());

            echo "Trim from start: " . $trimFromStart . " ms\n";
            echo "Trim from end: " . $trimFromEnd . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **管理视频字幕**

Aspose.Slides 允许您管理 PowerPoint 演示文稿中视频帧的闭合字幕。字幕以 WebVTT 格式存储，并可通过 [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/#getCaptionTracks) 方法获取。

**向视频帧添加字幕**

向视频帧添加字幕的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。  
1. 向演示文稿中添加视频。  
1. 向幻灯片中添加一个 [VideoFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/) 对象。  
1. 使用由 [getCaptionTracks](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/#getCaptionTracks) 返回的 [CaptionsCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/captionscollection/) 集合来添加 WebVTT 字幕轨道。  
1. 保存修改后的演示文稿。  

下面的代码演示了如何向视频帧添加字幕：

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // 添加一个来自 WebVTT 文件的新字幕轨道。
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/captionscollection/) 类还提供了一个重载，可让您从流中添加字幕。

**从视频帧提取字幕**

从视频帧提取字幕的步骤：

1. 加载包含视频的演示文稿。  
1. 查找目标 [VideoFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/) 对象。  
1. 遍历 [getCaptionTracks](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/#getCaptionTracks) 集合。  
1. 将每个字幕轨道保存为 `.vtt` 文件。  

下面的代码演示了如何从视频帧中提取字幕：

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

每个 [Captions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/captions/) 对象都会公开字幕标识符、标签、二进制数据以及作为 UTF-8 字符串的字幕文本。

**从视频帧移除字幕**

从视频帧中移除字幕的步骤：

1. 加载包含视频的演示文稿。  
1. 获取目标 [VideoFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/) 对象。  
1. 从 [getCaptionTracks](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/#getCaptionTracks) 集合中移除字幕轨道。  
1. 保存修改后的演示文稿。  

下面的代码演示了如何移除视频帧中的所有字幕：

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // 类型: VideoFrame

    // 移除视频帧的所有字幕。
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

如果只需要移除单个字幕轨道，请使用 [remove](https://reference.aspose.com/slides/zh/php-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/zh/php-java/aspose.slides/captionscollection/#removeAt) 方法，而不是 [clear](https://reference.aspose.com/slides/zh/php-java/aspose.slides/captionscollection/#clear)。

## **从幻灯片中提取视频**

除了向幻灯片添加视频，Aspose.Slides 还能提取嵌入在演示文稿中的视频。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例以加载包含视频的演示文稿。  
2. 遍历所有 [Slide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/) 对象。  
3. 遍历所有 [Shape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/) 对象以查找 [VideoFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/)。  
4. 将视频保存到磁盘。  

下面的 PHP 代码演示了如何提取演示文稿幻灯片中的视频：

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

## **常见问题**

**可以更改 VideoFrame 的哪些视频播放参数？**

您可以通过 [VideoFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/) 对象的属性控制 [播放模式](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/setplaymode/)（自动或点击）以及 [循环播放](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/setplayloopmode/)。

**添加视频会影响 PPTX 文件大小吗？**

会的。嵌入本地视频时，二进制数据会写入文档，演示文稿大小会随视频文件大小成比例增长。添加在线视频时，仅嵌入链接和缩略图，大小增长相对较小。

**是否可以在不更改位置和大小的情况下替换已有 VideoFrame 中的视频？**

可以。您可以在保持形状几何特性的前提下，使用 [setEmbeddedVideo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/videoframe/setembeddedvideo/) 替换帧内的视频内容，这在更新已有布局的媒体时非常常见。

**能否确定嵌入视频的内容类型（MIME）？**

可以。嵌入视频拥有可通过 [Video](https://reference.aspose.com/slides/zh/php-java/aspose.slides/video/getcontenttype/) 读取的 [content type](https://reference.aspose.com/slides/zh/php-java/aspose.slides/video/getcontenttype/)，您可以将其用于保存到磁盘等场景。