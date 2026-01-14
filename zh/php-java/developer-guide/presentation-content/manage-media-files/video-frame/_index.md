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
description: "学习如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 和 OpenDocument 幻灯片中以编程方式添加和提取视频帧。快速上手指南。"
---

在演示文稿中恰当地放置视频可以使您的信息更具说服力，并提高观众的参与度。

PowerPoint 允许您以两种方式向演示文稿的幻灯片添加视频：

* 添加或嵌入本地视频（存储在您的计算机上）
* 添加在线视频（来自诸如 YouTube 的网络来源）。

为使您能够向演示文稿添加视频（视频对象），Aspose.Slides 提供了 [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) 类、[VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) 类以及其他相关类型。

## **Create Embedded Video Frames**

如果要添加到幻灯片的视频文件存储在本地，您可以创建视频帧将视频嵌入到演示文稿中。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 添加一个 [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) 对象，并传入视频文件路径以将视频嵌入到演示文稿中。  
1. 添加一个 [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) 对象以创建视频的帧。  
1. 保存修改后的演示文稿。  

以下 PHP 代码展示了如何将本地存储的视频添加到演示文稿中：
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


或者，您也可以直接将文件路径传递给 [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addvideoframe/) 方法来添加视频：
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


## **Create Video Frames with Video from Web Sources**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支持在演示文稿中使用 YouTube 视频。如果您要使用的视频可在网上获取（例如 YouTube），可以通过其网络链接将其添加到演示文稿中。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 添加一个 [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) 对象，并传入视频链接。  
1. 为视频帧设置缩略图。  
1. 保存演示文稿。  

以下 PHP 代码展示了如何将网络视频添加到 PowerPoint 幻灯片中：
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


## **Extract Video from Slides**

除了向幻灯片添加视频，Aspose.Slides 还允许您提取嵌入在演示文稿中的视频。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例以加载包含视频的演示文稿。  
2. 遍历所有 [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) 对象。  
3. 遍历所有 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 对象以查找 [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/)。  
4. 将视频保存到磁盘。  

以下 PHP 代码展示了如何提取演示文稿幻灯片中的视频：
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

**Which video playback parameters can be changed for a VideoFrame?**

您可以控制播放模式（自动或点击）以及循环方式。这些选项可通过 [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) 对象的属性进行设置。

**Does adding a video affect the PPTX file size?**

是的。嵌入本地视频时，二进制数据会被写入文档，文件大小会随视频文件大小成比例增长。添加在线视频时，仅嵌入链接和缩略图，大小增长较小。

**Can I replace the video in an existing VideoFrame without changing its position and size?**

可以。您可以在保持形状几何尺寸不变的情况下，使用 [setEmbeddedVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setembeddedvideo/) 替换帧内的视频内容，这在更新已有布局的媒体时很常见。

**Can the content type (MIME) of an embedded video be determined?**

可以。嵌入的视频拥有可通过 [getContentType](https://reference.aspose.com/slides/php-java/aspose.slides/video/getcontenttype/) 读取的内容类型，例如在将其保存到磁盘时使用。