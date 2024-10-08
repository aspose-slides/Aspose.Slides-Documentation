---
title: 视频帧
type: docs
weight: 10
url: /zh/php-java/video-frame/
keywords: "添加视频, 创建视频帧, 提取视频, PowerPoint演示文稿, Java, Aspose.Slides for PHP via Java"
description: "在PowerPoint演示文稿中添加视频帧"
---

在演示文稿中恰当地放置视频可以使您的信息更具说服力，并提高与观众的参与度。

PowerPoint允许您通过两种方式将视频添加到演示文稿的幻灯片中：

* 添加或嵌入本地视频（存储在您的计算机上）
* 添加在线视频（来自网络来源，如YouTube）。

为了让您可以向演示文稿添加视频（视频对象），Aspose.Slides提供了[IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/)接口、[IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/)接口以及其他相关类型。

## **创建嵌入的视频帧**

如果您想添加到幻灯片中的视频文件存储在本地，您可以创建一个视频帧将视频嵌入到您的演示文稿中。

1. 创建[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个[IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/)对象，并传入视频文件路径以嵌入视频到演示文稿中。
1. 添加一个[IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/)对象以为视频创建一个框架。
1. 保存修改后的演示文稿。

以下PHP代码演示如何将本地存储的视频添加到演示文稿中：

```php
  # 实例化Presentation类
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

或者，您可以通过直接将其文件路径传递给[addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-)方法来添加视频：

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

## **从网络源创建视频帧**

Microsoft [PowerPoint 2013及更高版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)支持在演示文稿中使用YouTube视频。如果您要使用的视频在线可用（例如在YouTube上），可以通过其网络链接将其添加到演示文稿中。

1. 创建[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个[IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/)对象并传入视频链接。
1. 为视频帧设置缩略图。
1. 保存演示文稿。

以下PHP代码演示如何将来自网络的视频添加到PowerPoint演示文稿中的幻灯片：

```php
  # 实例化一个表示演示文稿文件的Presentation对象
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

## **从幻灯片中提取视频**

除了向幻灯片添加视频外，Aspose.Slides还允许您提取嵌入在演示文稿中的视频。

1. 创建一个[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例以加载包含视频的演示文稿。
2. 遍历所有[ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/)对象。
3. 遍历所有[IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/)对象以查找[VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/)。
4. 将视频保存到磁盘。

以下PHP代码演示了如何提取演示文稿幻灯片上的视频：

```php
  # 实例化一个表示演示文稿文件的Presentation对象
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