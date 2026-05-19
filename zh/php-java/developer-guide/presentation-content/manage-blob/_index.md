---
title: 在 PHP 中管理演示文稿 BLOB 以实现高效内存使用
linktitle: 管理 BLOB
type: docs
weight: 10
url: /zh/php-java/manage-blob/
keywords:
- 大型对象
- 大型项目
- 大型文件
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
## **概述**

Aspose.Slides 提供基于 BLOB 的处理方式，用于演示文稿中的大型二进制数据，以帮助在处理大型图像、音频、视频和演示文稿文件时降低内存消耗。

本文展示了如何使用基于 BLOB 的处理向演示文稿添加大型媒体、从演示文稿导出大型媒体以及更高效地加载大型演示文稿。它还解释了在处理过程中如何使用临时文件以及如何更改用于存储这些文件的文件夹。

## **关于 BLOB**

**BLOB** (**Binary Large Object**) 通常是以二进制格式保存的大型项目（照片、演示文稿、文档或媒体）。

Aspose.Slides for PHP via Java 允许您以降低内存消耗的方式对对象使用 BLOB，尤其是在涉及大型文件时。

{{% alert title="Info" color="info" %}}
为规避与流交互时的某些限制，Aspose.Slides 可能会复制流的内容。通过流加载大型演示文稿会导致演示文稿内容被复制，从而造成加载缓慢。因此，当您打算加载大型演示文稿时，强烈建议使用演示文稿文件路径而不是其流。
{{% /alert %}}

## **使用 BLOB 减少内存消耗**

### **通过 BLOB 将大文件添加到演示文稿**

[Aspose.Slides](/slides/zh/php-java/) for Java 允许您通过涉及 BLOB 的过程将大文件（此处为大视频文件）添加到演示文稿，以降低内存消耗。

下面的 Java 示例演示了如何通过 BLOB 过程将大视频文件添加到演示文稿：

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # 创建一个将添加视频的新演示文稿
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # 我们将视频添加到演示文稿 - 我们选择 KeepLocked 行为，因为我们
      # 不打算访问 "veryLargeVideo.avi" 文件。
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # 保存演示文稿。虽然输出大型演示文稿，但内存消耗
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

### **通过 BLOB 从演示文稿导出大文件**

Aspose.Slides for PHP via Java 允许您通过涉及 BLOB 的过程从演示文稿中导出大文件（此处为音频或视频文件）。例如，您可能需要从演示文稿中提取大型媒体文件，但不希望该文件被加载到计算机内存中。通过 BLOB 过程导出文件，可保持内存消耗低。

以下代码演示了上述操作：

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # 锁定源文件且不将其加载到内存中
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # 创建 Presentation 实例，并锁定 "hugePresentationWithAudiosAndVideos.pptx" 文件。
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # 让我们将每个视频保存到文件。为防止高内存使用，我们需要一个将被使用的缓冲区
    # 用于将演示文稿的视频流数据传输到新创建的视频文件的流中。
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # 遍历视频
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # 打开演示文稿的视频流。请注意，我们有意避免访问属性
      # 如 video.BinaryData ——因为此属性返回包含完整视频的字节数组，这会
      # 导致字节被加载到内存中。我们使用 video.GetStream，它将返回 Stream，并且不
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
      # 无论视频或演示文稿的大小如何，内存消耗都将保持低水平。
    }
    # 如有必要，您可以对音频文件采用相同的步骤。
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **将图像作为 BLOB 添加到演示文稿**

使用 [ImageCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagecollection/) 类的方法，您可以将大型图像作为流添加，以便将其视为 BLOB。

下面的 PHP 代码展示了如何通过 BLOB 过程添加大型图像：

```php
  $pathToLargeImage = "large_image.jpg";
  # 创建一个将添加图像的新演示文稿。
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # 让我们将图像添加到演示文稿 - 我们选择 KeepLocked 行为，因为我们
      # 不打算访问 "largeImage.png" 文件。
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # 保存演示文稿。虽然输出大型演示文稿，但内存消耗
      # 在 pres 对象的整个生命周期内保持低水平
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

通常，加载大型演示文稿需要大量临时内存。演示文稿的全部内容会被加载到内存中，而加载来源的文件则不再使用。

考虑一个包含 1.5 GB 视频文件的大 PowerPoint 演示文稿（large.pptx）。以下 PHP 代码描述了标准的加载方法：

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

### **将大型演示文稿作为 BLOB 加载**

通过涉及 BLOB 的过程，您可以在使用很少内存的情况下加载大型演示文稿。以下 PHP 代码展示了使用 BLOB 过程加载大型演示文稿文件（large.pptx）的实现：

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

### **更改临时文件夹**

使用 BLOB 过程时，电脑会在默认的临时文件夹中创建临时文件。如果希望将临时文件保存在其他文件夹，可使用 `setTempFilesRootPath` 更改存储设置：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Info" color="info" %}}
使用 `setTempFilesRootPath` 时，Aspose.Slides 不会自动创建用于存放临时文件的文件夹。您需要手动创建该文件夹。
{{% /alert %}}

### **释放演示文稿对象以释放内存**

在处理大型演示文稿时，请确保正确释放 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 实例，以释放其占用的内存。使用完演示文稿后调用 `dispose()`，以释放未受管理的资源。

```php
$presentation = new Presentation("large.pptx");

# ...处理演示文稿...
$presentation->save("large.pdf", SaveFormat::Pdf);

# 明确释放资源。
$presentation->dispose();
```

## **常见问题**

**Aspose.Slides 演示文稿中哪些数据被视为 BLOB 并受 BLOB 选项控制？**

图片、音频、视频等大型二进制对象会被视为 BLOB。整个演示文稿文件在加载或保存时也涉及 BLOB 处理。这些对象受 BLOB 策略管理，您可以通过这些策略控制内存使用并在需要时将数据写入临时文件。

**在演示文稿加载期间，我在哪里配置 BLOB 处理规则？**

使用 [LoadOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/) 配合 [BlobManagementOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/blobmanagementoptions/)。在此可以设置 BLOB 的内存上限，是否允许临时文件，临时文件的根路径，以及源锁定行为。

**BLOB 设置会影响性能吗，如何在速度与内存之间取得平衡？**

会。将 BLOB 完全保留在内存中可实现最高速度，但会增加 RAM 消耗；降低内存限制会将更多工作转移到临时文件，从而降低 RAM 使用，但会带来额外的 I/O 开销。使用 [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/zh/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) 方法可以根据工作负载和环境找到合适的平衡点。

**在打开极大型演示文稿（例如 GB 级）时，BLOB 选项有帮助吗？**

有。[BlobManagementOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/blobmanagementoptions/) 专为此类场景设计：开启临时文件并使用源锁定可显著降低峰值 RAM 使用，提升对超大文件的处理稳定性。

**我可以在从流而非磁盘文件加载时使用 BLOB 策略吗？**

可以。相同的规则同样适用于流：演示文稿实例可以拥有并锁定输入流（取决于所选的锁定模式），并在允许的情况下使用临时文件，从而在处理期间保持可预测的内存使用。