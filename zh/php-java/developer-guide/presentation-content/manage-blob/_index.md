---
title: 在 PHP 中管理演示文稿 BLOB 以实现高效内存使用
linktitle: 管理 BLOB
type: docs
weight: 10
url: /zh/php-java/manage-blob/
keywords:
- 大对象
- 大项目
- 大文件
- 添加 BLOB
- 导出 BLOB
- 将图像添加为 BLOB
- 减少内存
- 内存消耗
- 大型演示文稿
- 临时文件
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP via Java 中管理 BLOB 数据，以简化 PowerPoint 和 OpenDocument 文件操作，实现高效的演示文稿处理。"
---

## **关于 BLOB**

**BLOB**（**Binary Large Object**）通常是以二进制格式保存的大型项（照片、演示文稿、文档或媒体）。

Aspose.Slides for PHP via Java 允许您在涉及大文件时使用 BLOB 来降低内存消耗。

{{% alert title="Info" color="info" %}}
为了解决在流交互时的某些限制，Aspose.Slides 可能会复制流的内容。通过流加载大型演示文稿会导致复制演示文稿内容并且加载缓慢。因此，当您打算加载大型演示文稿时，强烈建议使用演示文稿文件路径而不是其流。
{{% /alert %}}

## **使用 BLOB 减少内存消耗**

### **通过 BLOB 向演示文稿添加大型文件**

[Aspose.Slides](/slides/zh/php-java/) for Java 允许您通过 BLOB 过程添加大型文件（本例中为大型视频文件），以降低内存消耗。

此示例展示了如何通过 BLOB 过程向演示文稿添加大型视频文件：
```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # 创建一个新演示文稿，将添加视频
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # 让我们将视频添加到演示文稿中 - 我们选择 KeepLocked 行为，因为我们
      # 不打算访问 "veryLargeVideo.avi" 文件。
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # 保存演示文稿。输出大型演示文稿时，内存消耗
      # 在 pres 对象的生命周期内保持低水平
      $pres->save("presentationWithLargeVideo.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **通过 BLOB 从演示文稿导出大型文件**

Aspose.Slides for PHP via Java 允许您通过 BLOB 过程从演示文稿中导出大型文件（例如音频或视频文件）。例如，您可能需要从演示文稿中提取大型媒体文件，但不希望将其加载到计算机内存中。通过 BLOB 过程导出文件，可保持低内存消耗。

以下代码演示了上述操作：
```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # 锁定源文件且不将其加载到内存中
  # 创建 Presentation 实例，锁定 “hugePresentationWithAudiosAndVideos.pptx” 文件。
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # 我们将每个视频保存到文件。为防止高内存使用，需要使用缓冲区
    # 以将演示文稿的视频流数据传输到新创建的视频文件流中。
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # 遍历视频
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # 打开演示文稿的视频流。请注意，我们有意避免访问属性
      # 比如 video.BinaryData —— 因为此属性返回包含完整视频的字节数组，这将
      # 导致字节加载到内存中。我们使用 video.GetStream，它返回 Stream —— 并且不
      # 需要我们将整个视频加载到内存中。
      $presVideoStream = $video->getStream();
      try {
        $outputFileStream = new Java("java.io.FileOutputStream", "video" . $index . ".avi");
        try {
          $bytesRead;
          while ($bytesRead = $presVideoStream->read($buffer, 0, java_values($Array->getLength($buffer))) > 0) {
            $outputFileStream->write($buffer, 0, $bytesRead);
          } 
        } finally {
          $outputFileStream->close();
        }
      } finally {
        $presVideoStream->close();
      }
      # 无论视频或演示文稿大小，内存消耗都将保持低水平。
    }
    # 如有必要，您可以对音频文件执行相同的步骤。
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```


### **将图像作为 BLOB 添加到演示文稿**

使用 [ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) 类的方法，您可以将大型图像作为流添加，以将其视为 BLOB。

以下 PHP 代码展示了如何通过 BLOB 过程添加大型图像：
```php
  $pathToLargeImage = "large_image.jpg";
  # 创建一个新演示文稿，将添加图像。
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # 将图像添加到演示文稿 - 我们选择 KeepLocked 行为，因为我们
      # 不打算访问 "largeImage.png" 文件。
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # 保存演示文稿。当输出大型演示文稿时，内存消耗
      # 在 pres 对象的生命周期内保持低水平
      $pres->save("presentationWithLargeImage.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **内存和大型演示文稿**

通常，加载大型演示文稿需要大量临时内存。演示文稿的所有内容会加载到内存中，加载后原文件不再被使用。

考虑一个包含 1.5 GB 视频文件的大型 PowerPoint 演示文稿（large.pptx）。以下 PHP 代码描述了加载该演示文稿的标准方法：

```php
  $pres = new Presentation("large.pptx");
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


但此方法会消耗约 1.6 GB 的临时内存。

### **以 BLOB 加载大型演示文稿**

通过 BLOB 过程，可以在使用极少内存的情况下加载大型演示文稿。以下 PHP 代码描述了使用 BLOB 过程加载大型演示文稿文件（large.pptx）的实现：
```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $pres = new Presentation("large.pptx", $loadOptions);
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **更改临时文件夹位置**

使用 BLOB 过程时，计算机会在默认临时文件夹中创建临时文件。如需将临时文件保存到其他文件夹，可使用 `setTempFilesRootPath` 修改存储设置：
```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```


{{% alert title="Info" color="info" %}}
当使用 `setTempFilesRootPath` 时，Aspose.Slides 不会自动创建用于存储临时文件的文件夹，您需要手动创建该文件夹。
{{% /alert %}}

## **常见问题**

**Aspose.Slides 演示文稿中哪些数据被视为 BLOB 并受 BLOB 选项控制？**

图像、音频和视频等大型二进制对象被视为 BLOB。整个演示文稿文件在加载或保存时也涉及 BLOB 处理。这些对象受 BLOB 策略管控，您可以管理内存使用并在需要时溢写到临时文件。

**在演示文稿加载期间，在哪里配置 BLOB 处理规则？**

使用带有 [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/) 的 [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/)。在此可以设置 BLOB 的内存限制、是否允许临时文件、临时文件的根路径以及源锁定行为。

**BLOB 设置会影响性能吗？如何在速度和内存之间取得平衡？**

是的。将 BLOB 保持在内存中可提升速度，但会增加 RAM 消耗；降低内存限制会将更多工作转移到临时文件，从而降低 RAM 占用但会增加 I/O。使用 [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) 方法可为您的工作负载和环境找到合适的平衡点。

**在打开极大型演示文稿（如数 GB）时，BLOB 选项有帮助吗？**

是的。[BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/) 专为此类场景设计：启用临时文件并使用源锁定，可显著降低峰值 RAM 使用并使处理极大演示文稿更稳定。

**可以在从流加载而不是磁盘文件时使用 BLOB 策略吗？**

可以。相同的规则适用于流：演示文稿实例可以拥有并锁定输入流（取决于所选的锁定模式），并在允许的情况下使用临时文件，从而在处理过程中保持可预测的内存使用。